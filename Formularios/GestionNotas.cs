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
    public partial class GestionNotas : Form
    {
        public GestionNotas()
        {
            InitializeComponent();
            try
            {
                CargarNombreCompleto();
                CargarMateriasDelProfesor(SesionActual.CedulaUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos iniciales: " + ex.Message);
            }
        }

        private void CargarNombreCompleto()
        {
            try
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
                                    }).FirstOrDefault();

                    lblNombreCompleto.Text = consulta?.NombreCompleto ?? "Estudiante no encontrado";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el nombre del estudiante: " + ex.Message);
            }
        }

        private void Limpiar() {
            txtNota1.Text = "";
            txtNota2.Text = "";
            txtSupletorio.Text = "";
        
        }

        private void CargarMateriasDelProfesor(string cedulaProfesor)
        {
            try
            {
                using (var db = new SistemaGestionAcademicaEntities1())
                {
                    var materias = db.Materias
                        .Where(m => m.IdProfesor == cedulaProfesor)
                        .ToList();

                    cbxMaterias.DataSource = materias;
                    cbxMaterias.DisplayMember = "NombreMateria";
                    cbxMaterias.ValueMember = "IdMateria";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar materias: " + ex.Message);
            }
        }

        private void ExportarEstudiantesAExcel()
        {
            if (dgvEstudiantes.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            try
            {
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i <= dgvEstudiantes.Columns.Count; i++)
                    excelApp.Cells[1, i] = dgvEstudiantes.Columns[i - 1].HeaderText;

                for (int i = 0; i < dgvEstudiantes.Rows.Count; i++)
                    for (int j = 0; j < dgvEstudiantes.Columns.Count; j++)
                        excelApp.Cells[i + 2, j + 1] = dgvEstudiantes.Rows[i].Cells[j].Value?.ToString() ?? "";

                excelApp.Visible = true;
                MessageBox.Show("Exportado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message);
            }
        }

        private void CargarEstudiantes()
        {
            try
            {
                string idMateria = cbxMaterias.SelectedValue.ToString();

                using (var db = new SistemaGestionAcademicaEntities1())
                {
                    var consulta = from m in db.Matriculas
                                   join u in db.Usuarios on m.CedulaEstudiante equals u.Cedula
                                   join n in db.Notas on m.IdMatricula equals n.IdMatricula
                                   where m.IdMateria == idMateria
                                   select new
                                   {
                                       m.IdMatricula,
                                       u.Cedula,
                                       u.PrimerNombre,
                                       u.PrimerApellido,
                                       n.Nota1,
                                       n.Nota2,
                                       n.Supletorio,
                                   };

                    dgvEstudiantes.DataSource = consulta.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estudiantes: " + ex.Message);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string idMateria = cbxMaterias.SelectedValue.ToString();
                string criterio = txtBuscar.Text.Trim();

                using (var db = new SistemaGestionAcademicaEntities1())
                {
                    var consulta = from m in db.Matriculas
                                   join u in db.Usuarios on m.CedulaEstudiante equals u.Cedula
                                   join n in db.Notas on m.IdMatricula equals n.IdMatricula
                                   where m.IdMateria == idMateria &&
                                         (u.Cedula.Contains(criterio) || u.PrimerNombre.Contains(criterio))
                                   select new
                                   {
                                       m.IdMatricula,
                                       u.Cedula,
                                       u.PrimerNombre,
                                       u.PrimerApellido,
                                       n.Nota1,
                                       n.Nota2,
                                       n.Supletorio,
                                   };

                    dgvEstudiantes.DataSource = consulta.ToList();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar estudiantes: " + ex.Message);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEstudiantes.CurrentRow != null)
                {
                    int idMat = Convert.ToInt32(dgvEstudiantes.CurrentRow.Cells["idMatricula"].Value);

                    using (var db = new SistemaGestionAcademicaEntities1())
                    {
                        var nota = db.Notas.FirstOrDefault(n => n.IdMatricula == idMat);
                        if (nota != null)
                        {
                            nota.Nota1 = Convert.ToDecimal(txtNota1.Text);
                            nota.Nota2 = Convert.ToDecimal(txtNota2.Text);
                            nota.Supletorio = Convert.ToDecimal(txtSupletorio.Text);

                            db.SaveChanges();
                            MessageBox.Show("Notas guardadas correctamente.");
                            btnBuscar_Click(sender, e);
                            Limpiar();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar notas: " + ex.Message);
            }
        }

        private void dgvEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    txtNota1.Text = dgvEstudiantes.Rows[e.RowIndex].Cells["Nota1"].Value?.ToString() ?? "";
                    txtNota2.Text = dgvEstudiantes.Rows[e.RowIndex].Cells["Nota2"].Value?.ToString() ?? "";
                    txtSupletorio.Text = dgvEstudiantes.Rows[e.RowIndex].Cells["Supletorio"].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar estudiante: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEstudiantes.CurrentRow != null)
                {
                    int idMat = Convert.ToInt32(dgvEstudiantes.CurrentRow.Cells["idMatricula"].Value);

                    using (var db = new SistemaGestionAcademicaEntities1())
                    {
                        var nota = db.Notas.FirstOrDefault(n => n.IdMatricula == idMat);
                        if (nota != null)
                        {
                            nota.Nota1 = Convert.ToDecimal(txtNota1.Text);
                            nota.Nota2 = Convert.ToDecimal(txtNota2.Text);
                            nota.Supletorio = Convert.ToDecimal(txtSupletorio.Text);

                            db.SaveChanges();
                            MessageBox.Show("Notas modificadas correctamente.");
                            btnBuscar_Click(sender, e);
                            Limpiar();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar notas: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEstudiantes.CurrentRow != null)
                {
                    int idMat = Convert.ToInt32(dgvEstudiantes.CurrentRow.Cells["idMatricula"].Value);

                    using (var db = new SistemaGestionAcademicaEntities1())
                    {
                        var nota = db.Notas.FirstOrDefault(n => n.IdMatricula == idMat);
                        if (nota != null)
                        {
                            nota.Nota1 = 0;
                            nota.Nota2 = 0;
                            nota.Supletorio = 0;

                            db.SaveChanges();
                            MessageBox.Show("Notas eliminadas correctamente.");
                            btnBuscar_Click(sender, e);
                            Limpiar();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar notas: " + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                new Profesor().Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la ventana: " + ex.Message);
            }
        }

        private void cbxMaterias_Click(object sender, EventArgs e)
        {
            try
            {
                CargarEstudiantes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estudiantes: " + ex.Message);
            }
        }

        private void btnExportarNotas_Click(object sender, EventArgs e)
        {
            ExportarEstudiantesAExcel();
        }
    }
}
