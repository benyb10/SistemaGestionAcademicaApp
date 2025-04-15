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
    public partial class VerNotas: Form
    {
        public VerNotas()
        {
            InitializeComponent();
            ConfigurarGridSoloLectura();
            CargarMateriasConNotas();
            CargarNombreCompleto();

        }
        private void ExportarNotasAExcel()
        {
            if (dgvMateriasNotas.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            try
            {
                // Crear el objeto Excel
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                // Agregar encabezados
                for (int i = 1; i <= dgvMateriasNotas.Columns.Count; i++)
                {
                    excelApp.Cells[1, i] = dgvMateriasNotas.Columns[i - 1].HeaderText;
                }

                // Agregar filas
                for (int i = 0; i < dgvMateriasNotas.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvMateriasNotas.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dgvMateriasNotas.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                }

                // Mostrar el archivo generado
                excelApp.Visible = true;
                MessageBox.Show("Exportado Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message);
            }
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
        private void CargarMateriasConNotas()
        {
            string cedulaEstudiante = SesionActual.CedulaUsuario;

            using (var db = new SistemaGestionAcademicaEntities1())
            {
                var consulta = (from m in db.Matriculas
                                join mat in db.Materias on m.IdMateria equals mat.IdMateria
                                join u in db.Usuarios on mat.IdProfesor equals u.Cedula
                                join n in db.Notas on m.IdMatricula equals n.IdMatricula
                                where m.CedulaEstudiante == cedulaEstudiante
                                select new
                                {
                                    Materia = mat.NombreMateria,
                                    Profesor = u.PrimerNombre + " " + u.PrimerApellido,
                                    Nota1 = n.Nota1,
                                    Nota2 = n.Nota2,
                                    Supletorio = n.Supletorio
                                }).ToList();

                var resultado = consulta.Select(x => new
                {
                    x.Materia,
                    x.Profesor,
                    x.Nota1,
                    x.Nota2,
                    x.Supletorio,
                    Estado = ObtenerEstado(x.Nota1, x.Nota2, x.Supletorio)
                }).ToList();

                dgvMateriasNotas.DataSource = resultado;

            }

        }

        private void ConfigurarGridSoloLectura()
        {
            dgvMateriasNotas.ReadOnly = true;
            dgvMateriasNotas.AllowUserToAddRows = false;
            dgvMateriasNotas.AllowUserToDeleteRows = false;
        }
        private string ObtenerEstado(decimal? nota1, decimal? nota2, decimal? supletorio)
        {
            decimal promedio = ((nota1 ?? 0) + (nota2 ?? 0)) / 2;
            if (promedio >= 7)
                return "Aprobado";
            else if ((promedio < 7 && supletorio >= 7))
                return "Aprobado (Supletorio)";
            else
                return "Reprobado";
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            new Estudiante().Show();
            this.Hide();
        }

        private void btnExportarNotas_Click(object sender, EventArgs e)
        {
            ExportarNotasAExcel();
        }
    }
}
