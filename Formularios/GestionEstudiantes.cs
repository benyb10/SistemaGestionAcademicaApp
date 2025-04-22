using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaGestionAcademicaApp;

namespace SistemaGestionAcademicaApp.Formularios
{
    public partial class GestionEstudiantes: Form
    {
        public GestionEstudiantes()
        {
            InitializeComponent();
            CargarEstudiantes();
            CargarNombreCompleto();
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

                    lblNombreCompleto.Text = consulta != null ? consulta.NombreCompleto : "Estudiante no encontrado";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar nombre completo: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtCedula.Clear();
            txtPrimerNombre.Clear();
            txtSegundoNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            txtCorreo.Clear();
            txtProvincia.Clear();
            txtBuscar.Clear(); // Si tienes un campo de búsqued
            txtCedula.Focus(); // Opcional: enfoca el primer campo
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

                // Encabezados
                for (int i = 1; i <= dgvEstudiantes.Columns.Count; i++)
                {
                    excelApp.Cells[1, i] = dgvEstudiantes.Columns[i - 1].HeaderText;
                }

                // Filas
                for (int i = 0; i < dgvEstudiantes.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvEstudiantes.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dgvEstudiantes.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                }

                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message);
            }
        }

        private void CargarEstudiantes(string filtro = "")
        {
            try
            {
                using (var db = new SistemaGestionAcademicaEntities1())
                {
                    var estudiantes = db.Usuarios
                        .Where(u => u.Rol == "ESTUDIANTE" &&
                                   (u.Cedula.Contains(filtro) || u.PrimerNombre.Contains(filtro)))
                        .Select(u => new
                        {
                            u.Cedula,
                            Nombre = u.PrimerNombre + " " + u.SegundoNombre,
                            Apellido = u.PrimerApellido + " " + u.SegundoApellido,
                            u.CorreoInstitucional,
                            u.Provincia
                        })
                        .ToList();

                    dgvEstudiantes.DataSource = estudiantes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estudiantes: " + ex.Message);
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new SistemaGestionAcademicaEntities1())
                {
                    string cedula = txtCedula.Text.Trim();

                    if (db.Usuarios.Any(u => u.Cedula == cedula))
                    {
                        MessageBox.Show("La cédula ya está registrada.");
                        return;
                    }

                    var nuevo = new Usuarios
                    {
                        Cedula = cedula,
                        PrimerNombre = txtPrimerNombre.Text,
                        SegundoNombre = txtSegundoNombre.Text,
                        PrimerApellido = txtPrimerApellido.Text,
                        SegundoApellido = txtSegundoApellido.Text,
                        CorreoInstitucional = txtCorreo.Text,
                        Provincia = txtProvincia.Text,
                        Rol = "ESTUDIANTE"
                    };

                    db.Usuarios.Add(nuevo);
                    db.SaveChanges();
                    MessageBox.Show("Estudiante registrado exitosamente.");
                    CargarEstudiantes();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar estudiante: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new SistemaGestionAcademicaEntities1())
                {
                    string cedula = txtCedula.Text.Trim();
                    var estudiante = db.Usuarios.FirstOrDefault(u => u.Cedula == cedula && u.Rol == "ESTUDIANTE");

                    if (estudiante != null)
                    {
                        estudiante.PrimerNombre = txtPrimerNombre.Text;
                        estudiante.SegundoNombre = txtSegundoNombre.Text;
                        estudiante.PrimerApellido = txtPrimerApellido.Text;
                        estudiante.SegundoApellido = txtSegundoApellido.Text;
                        estudiante.CorreoInstitucional = txtCorreo.Text;
                        estudiante.Provincia = txtProvincia.Text;

                        db.SaveChanges();
                        MessageBox.Show("Datos modificados correctamente.");
                        CargarEstudiantes();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Estudiante no encontrado.");
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar estudiante: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string cedula = txtCedula.Text.Trim();

                using (var db = new SistemaGestionAcademicaEntities1())
                {
                    var estudiante = db.Usuarios.FirstOrDefault(u => u.Cedula == cedula && u.Rol == "ESTUDIANTE");

                    if (estudiante != null)
                    {
                        db.Usuarios.Remove(estudiante);
                        db.SaveChanges();
                        MessageBox.Show("Estudiante eliminado.");
                        CargarEstudiantes();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Estudiante no encontrado.");
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar estudiante: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();
            CargarEstudiantes(filtro);
        }

        private void dgvEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvEstudiantes.Rows[e.RowIndex];

                    txtCedula.Text = fila.Cells["Cedula"].Value?.ToString() ?? "";
                    string[] nombres = fila.Cells["Nombre"].Value?.ToString().Split(' ') ?? new string[] { "", "" };
                    string[] apellidos = fila.Cells["Apellido"].Value?.ToString().Split(' ') ?? new string[] { "", "" };

                    txtPrimerNombre.Text = nombres.Length > 0 ? nombres[0] : "";
                    txtSegundoNombre.Text = nombres.Length > 1 ? nombres[1] : "";

                    txtPrimerApellido.Text = apellidos.Length > 0 ? apellidos[0] : "";
                    txtSegundoApellido.Text = apellidos.Length > 1 ? apellidos[1] : "";

                    txtCorreo.Text = fila.Cells["CorreoInstitucional"].Value?.ToString() ?? "";
                    txtProvincia.Text = fila.Cells["Provincia"].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos seleccionados: " + ex.Message);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al regresar: " + ex.Message);
            }

        }

        private void btnExportarEstudiantes_Click(object sender, EventArgs e)
        {
            ExportarEstudiantesAExcel();
        }
    }
}
