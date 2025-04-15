using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionAcademicaApp.Formularios
{
    public partial class GestionMaterias: Form
    {
        public GestionMaterias()
        {
            InitializeComponent();
            CargarMaterias();
            CargarSemestresYProfesores();
            CargarNombreCompleto();
        }


        private void CargarNombreCompleto()
        {
            string cedulaEstudiante = SesionActual.CedulaUsuario;

            using (var db = new SistemaGestionAcademicaEntities1())
            {
                var consulta = (from m in db.Usuarios
                                where m.Cedula == cedulaEstudiante
                                select new
                                {
                                    NombreCompleto = m.PrimerNombre + " " + m.SegundoNombre + " " +
                                                     m.PrimerApellido + " " + m.SegundoApellido
                                }).FirstOrDefault(); // <-- Esto obtiene el primer resultado

                if (consulta != null)
                {
                    lblNombreCompleto.Text = consulta.NombreCompleto;
                }
                else
                {
                    lblNombreCompleto.Text = "Estudiante no encontrado";
                }
            }
        }

        private void LimpiarCampos()
        {
            txtIdMateria.Text = "";
            txtNombreMateria.Text = "";
            txtCreditos.Text = "";
            txtIdMateria.Enabled = true;
            cmbSemestre.SelectedIndex = -1;
            cmbProfesor.SelectedIndex = -1;
        }

        private void ExportarMateriasAExcel()
        {
            if (dgvMaterias.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            try
            {
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                // Encabezados
                for (int i = 1; i <= dgvMaterias.Columns.Count; i++)
                {
                    excelApp.Cells[1, i] = dgvMaterias.Columns[i - 1].HeaderText;
                }

                // Filas
                for (int i = 0; i < dgvMaterias.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvMaterias.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dgvMaterias.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                }

                excelApp.Visible = true;
                MessageBox.Show("Exportado Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message);
            }
        }

        private void CargarMaterias()
        {
            using (var db = new SistemaGestionAcademicaEntities1())
            {
                var materias = db.Materias
                                 .Select(m => new
                                 {
                                     m.IdMateria,
                                     m.NombreMateria,
                                     m.Creditos,
                                     m.IdSemestre,
                                     m.IdProfesor
                                 })
                                 .ToList();

                dgvMaterias.DataSource = materias;
            }
        }

        private void CargarSemestresYProfesores()
        {
            using (var db = new SistemaGestionAcademicaEntities1())
            {
                // Cargar semestres
                var semestres = db.Semestres.Select(s => new { s.IdSemestre, s.NombreSemestre }).ToList();
                cmbSemestre.DataSource = semestres;
                cmbSemestre.DisplayMember = "NombreSemestre";
                cmbSemestre.ValueMember = "IdSemestre";

                // Cargar profesores
                var profesores = db.Usuarios.Where(u => u.Rol == "PROFESOR")
                                            .Select(p => new { p.Cedula, Nombre = p.PrimerNombre + " " + p.PrimerApellido })
                                            .ToList();
                cmbProfesor.DataSource = profesores;
                cmbProfesor.DisplayMember = "Nombre";
                cmbProfesor.ValueMember = "Cedula";
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string id = txtIdMateria.Text.Trim();
            string nombre = txtNombreMateria.Text.Trim();
            int creditos = int.Parse(txtCreditos.Text.Trim());
            int idSemestre = Convert.ToInt32(cmbSemestre.SelectedValue);
            string idProfesor = cmbProfesor.SelectedValue.ToString();

            using (var db = new SistemaGestionAcademicaEntities1())
            {
                var materia = new Materias
                {
                    IdMateria = id,
                    NombreMateria = nombre,
                    Creditos = creditos,
                    IdSemestre = idSemestre,
                    IdProfesor = idProfesor
                };

                db.Materias.Add(materia);
                db.SaveChanges();
                MessageBox.Show("Materia registrada correctamente.");
                CargarMaterias();
                LimpiarCampos();
            }
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMaterias.Rows[e.RowIndex];
                txtIdMateria.Text = row.Cells["IdMateria"].Value.ToString();
                txtNombreMateria.Text = row.Cells["NombreMateria"].Value.ToString();
                txtCreditos.Text = row.Cells["Creditos"].Value.ToString();
                cmbSemestre.SelectedValue = Convert.ToInt32(row.Cells["IdSemestre"].Value);
                cmbProfesor.SelectedValue = row.Cells["IdProfesor"].Value.ToString();

                txtIdMateria.Enabled = false; // Para evitar cambiar el ID de la materia
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string id = txtIdMateria.Text.Trim();

            using (var db = new SistemaGestionAcademicaEntities1())
            {
                var materia = db.Materias.FirstOrDefault(m => m.IdMateria == id);
                if (materia != null)
                {
                    materia.NombreMateria = txtNombreMateria.Text.Trim();
                    materia.Creditos = int.Parse(txtCreditos.Text.Trim());
                    materia.IdSemestre = Convert.ToInt32(cmbSemestre.SelectedValue);
                    materia.IdProfesor = cmbProfesor.SelectedValue.ToString();

                    db.SaveChanges();
                    MessageBox.Show("Materia modificada correctamente.");
                    CargarMaterias();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Materia no encontrada.");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = txtIdMateria.Text.Trim();

            if (MessageBox.Show("¿Está seguro de eliminar esta materia?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var db = new SistemaGestionAcademicaEntities1())
                {
                    var materia = db.Materias.FirstOrDefault(m => m.IdMateria == id);
                    if (materia != null)
                    {
                        db.Materias.Remove(materia);
                        db.SaveChanges();
                        MessageBox.Show("Materia eliminada correctamente.");
                        CargarMaterias();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Materia no encontrada.");
                    }
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            new Admin().Show();
            this.Hide();
        }

        private void btnExportarMaterias_Click(object sender, EventArgs e)
        {
            ExportarMateriasAExcel();
        }
    }
}
