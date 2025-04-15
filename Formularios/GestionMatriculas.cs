using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaGestionAcademicaApp;

namespace SistemaGestionAcademicaApp.Formularios
{
    public partial class GestionMatriculas: Form
    {
        public GestionMatriculas()
        {
            InitializeComponent();
            CargarMatriculas();
            CargarRepiteMateria();
            CargarSemestres();
            cmbSemestres.SelectedIndexChanged += cmbSemestres_SelectedIndexChanged;
            CargarEstudiantes();
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

        private void cmbSemestres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSemestres.SelectedValue != null && int.TryParse(cmbSemestres.SelectedValue.ToString(), out int idSemestre))
            {
                CargarMaterias(idSemestre);
            }
        }

        private void CargarSemestres()
        {
            using (var db = new SistemaGestionAcademicaEntities1())
            {
                var semestres = db.Semestres
                                 .Select(s => new {
                                     s.IdSemestre,
                                     s.NombreSemestre
                                 })
                                 .ToList();

                cmbSemestres.DataSource = semestres;
                cmbSemestres.DisplayMember = "NombreSemestre";
                cmbSemestres.ValueMember = "IdSemestre";
            }
        }
        private void ExportarMatriculasAExcel()
        {
            if (dataGridMatriculas.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            try
            {
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                // Encabezados
                for (int i = 1; i <= dataGridMatriculas.Columns.Count; i++)
                {
                    excelApp.Cells[1, i] = dataGridMatriculas.Columns[i - 1].HeaderText;
                }

                // Cuerpo de la tabla
                for (int i = 0; i < dataGridMatriculas.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridMatriculas.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dataGridMatriculas.Rows[i].Cells[j].Value?.ToString() ?? "";
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

        private void CargarMatriculas()
        {
            using (var db = new SistemaGestionAcademicaEntities1())
            {
                var lista = (from m in db.Matriculas
                             join est in db.Usuarios on m.CedulaEstudiante equals est.Cedula
                             join mat in db.Materias on m.IdMateria equals mat.IdMateria
                             select new
                             {
                                 m.IdMatricula,
                                 m.CedulaEstudiante,
                                 Estudiante = est.PrimerNombre+" "+est.PrimerApellido,
                                 Materia = mat.NombreMateria,
                                 m.RepiteMateria
                             }).ToList();

                dataGridMatriculas.DataSource = lista;
            }
        }
        private void CargarRepiteMateria()
        {
            cmbRepiteMateria.Items.Clear();
            cmbRepiteMateria.Items.Add(1);
            cmbRepiteMateria.Items.Add(2);
            cmbRepiteMateria.Items.Add(3);
            cmbRepiteMateria.SelectedIndex = 0;
        }
        private void CargarMaterias(int idSemestre)
        {
            using (var db = new SistemaGestionAcademicaEntities1())
            {
                var materias = db.Materias
                                 .Where(m => m.IdSemestre == idSemestre)
                                 .Select(m => new {
                                     m.IdMateria,
                                     m.NombreMateria
                                 })
                                 .ToList();

                cmbMaterias.DataSource = materias;
                cmbMaterias.DisplayMember = "NombreMateria";
                cmbMaterias.ValueMember = "IdMateria";
            }
        }
        private void CargarEstudiantes()
        {
            using (var db = new SistemaGestionAcademicaEntities1())
            {
                var estudiantes = db.Usuarios
                                    .Where(u => u.Rol == "ESTUDIANTE")
                                    .Select(u => new {
                                        u.Cedula,
                                        NombreCompleto = u.PrimerNombre+" "+u.PrimerApellido,
                                    })
                                    .ToList();

                dataGridEstudiantes.DataSource = estudiantes;
            }
        }
        private void button_Matricular_Click(object sender, EventArgs e)
        {
            string cedulaEstudiante = txtBuscarCedula.Text.Trim();
            string cedulaSecretaria = SesionActual.CedulaUsuario;
            string idMateria = cmbMaterias.SelectedValue.ToString();
            byte repite = byte.Parse(cmbRepiteMateria.SelectedItem.ToString());

            try
            {
                using (var db = new SistemaGestionAcademicaEntities1())
                {
                    // 1. Crear la matrícula
                    var nuevaMatricula = new Matriculas
                    {
                        CedulaSecretaria = cedulaSecretaria,
                        CedulaEstudiante = cedulaEstudiante,
                        IdMateria = idMateria,
                        RepiteMateria = repite
                    };

                    db.Matriculas.Add(nuevaMatricula);
                    db.SaveChanges();

                    // 2. Obtener el ID de matrícula recién insertado
                    int idMatriculaCreada = nuevaMatricula.IdMatricula;

                    // 3. Crear registro en la tabla Notas con valores por defecto
                    var notaInicial = new Notas
                    {
                        IdMatricula = idMatriculaCreada,
                        Nota1 = 0,
                        Nota2 = 0,
                        Supletorio = 0
                    };

                    db.Notas.Add(notaInicial);
                    db.SaveChanges();

                    // 4. Confirmar al usuario
                    MessageBox.Show("Estudiante matriculado y notas iniciales registradas.");
                    CargarMatriculas(); // refresca el DataGrid de matrículas
                }
            }
            catch (DbUpdateException ex)
            {
                var inner = ex.InnerException;
                while (inner.InnerException != null)
                {
                    inner = inner.InnerException;
                }

                MessageBox.Show($"Error al guardar:\n{inner.Message}");
            }
        }

        private void btnBuscarEstudiante_Click(object sender, EventArgs e)
        {
            string cedula = txtBuscarCedula.Text.Trim();

            using (var db = new SistemaGestionAcademicaEntities1())
            {
                var estudiante = db.Usuarios
                                   .Where(u => u.Rol == "ESTUDIANTE" && u.Cedula == cedula)
                                   .Select(u => new {
                                       u.Cedula,
                                       NombreCompleto = u.PrimerNombre + " " + u.PrimerApellido,
                                   })
                                   .ToList();

                dataGridEstudiantes.DataSource = estudiante;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            using (var db = new SistemaGestionAcademicaEntities1())
            {
                var rol = db.Usuarios.FirstOrDefault(u => u.Cedula == SesionActual.CedulaUsuario && u.Rol == "ADMINISTRADOR");

                if (rol != null)
                {
                    new Admin().Show();
                    this.Hide();
                }
                else
                {
                    new Secretaria().Show();
                    this.Hide();
                }
            }
        }

        private void button_Modificar_Click(object sender, EventArgs e)
        {
            if (dataGridMatriculas.CurrentRow != null)
            {
                int idMatricula = Convert.ToInt32(dataGridMatriculas.CurrentRow.Cells["IdMatricula"].Value);
                string nuevaMateria = cmbMaterias.SelectedValue.ToString();
                byte nuevoRepite = byte.Parse(cmbRepiteMateria.SelectedItem.ToString());
                string nuevaCedula = txtBuscarCedula.Text;

                using (var db = new SistemaGestionAcademicaEntities1())
                {
                    var matricula = db.Matriculas.FirstOrDefault(m => m.IdMatricula == idMatricula);
                    if (matricula != null)
                    {
                        matricula.CedulaEstudiante = nuevaCedula;
                        matricula.IdMateria = nuevaMateria;
                        matricula.RepiteMateria = nuevoRepite;

                        db.SaveChanges();
                        MessageBox.Show("Matrícula modificada correctamente.");
                        CargarMatriculas();
                    }
                }
            }
        }

        private void dataGridMatriculas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtBuscarCedula.Text = dataGridMatriculas.Rows[e.RowIndex].Cells["CedulaEstudiante"].Value.ToString();

                // Seleccionar materia en combo
                string nombreMateria = dataGridMatriculas.Rows[e.RowIndex].Cells["Materia"].Value.ToString();
                cmbMaterias.SelectedIndex = cmbMaterias.FindStringExact(nombreMateria);

                // Seleccionar repite
                byte repite = Convert.ToByte(dataGridMatriculas.Rows[e.RowIndex].Cells["RepiteMateria"].Value);
                cmbRepiteMateria.SelectedItem = repite;

            }
        }

        private void button_Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridMatriculas.CurrentRow != null)
            {
                int idMatricula = Convert.ToInt32(dataGridMatriculas.CurrentRow.Cells["IdMatricula"].Value);

                var confirm = MessageBox.Show("¿Está seguro de eliminar esta matrícula?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (var db = new SistemaGestionAcademicaEntities1())
                    {
                        var matricula = db.Matriculas.FirstOrDefault(m => m.IdMatricula == idMatricula);
                        if (matricula != null)
                        {
                            db.Matriculas.Remove(matricula);
                            db.SaveChanges();
                            MessageBox.Show("Matrícula eliminada.");
                            CargarMatriculas();
                        }
                    }
                }
            }
        }

        private void btnExportarMatriculas_Click(object sender, EventArgs e)
        {
            ExportarMatriculasAExcel();
        }
    }
}
