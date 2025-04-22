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
    public partial class GestionUsuarios : Form
    {
        public GestionUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
            cmbRol.Items.AddRange(new string[] { "ADMINISTRADOR", "ESTUDIANTE", "PROFESOR", "SECRETARIA" });
            CargarUsuarios();
            CargarNombreCompleto();
        }

        private void ExportarUsuariosAExcel()
        {
            if (dgvUsuarios.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            try
            {
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                // Encabezados
                for (int i = 1; i <= dgvUsuarios.Columns.Count; i++)
                {
                    excelApp.Cells[1, i] = dgvUsuarios.Columns[i - 1].HeaderText;
                }

                // Datos
                for (int i = 0; i < dgvUsuarios.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvUsuarios.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dgvUsuarios.Rows[i].Cells[j].Value?.ToString() ?? "";
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

                    lblNombreCompleto.Text = consulta != null
                        ? consulta.NombreCompleto
                        : "Estudiante no encontrado";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el nombre completo: " + ex.Message);
            }
        }


        private void CargarUsuarios()
        {
            try
            {
                using (var db = new SistemaGestionAcademicaEntities1())
                {
                    var usuarios = db.Usuarios
                        .Select(u => new
                        {
                            u.Cedula,
                            u.PrimerNombre,
                            u.SegundoNombre,
                            u.PrimerApellido,
                            u.SegundoApellido,
                            u.CorreoInstitucional,
                            u.Provincia,
                            u.Rol
                        })
                        .ToList();

                    dgvUsuarios.DataSource = usuarios;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            new Admin().Show();
            this.Hide();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRol.SelectedItem == null)
                {
                    MessageBox.Show("Por favor seleccione un rol.");
                    return;
                }

                using (var db = new SistemaGestionAcademicaEntities1())
                {
                    var nuevoUsuario = new Usuarios
                    {
                        Cedula = txtCedula.Text.Trim(),
                        PrimerNombre = txtPrimerNombre.Text.Trim(),
                        SegundoNombre = txtSegundoNombre.Text.Trim(),
                        PrimerApellido = txtPrimerApellido.Text.Trim(),
                        SegundoApellido = txtSegundoApellido.Text.Trim(),
                        CorreoInstitucional = txtCorreo.Text.Trim(),
                        Provincia = txtProvincia.Text.Trim(),
                        Rol = cmbRol.SelectedItem.ToString()
                    };

                    db.Usuarios.Add(nuevoUsuario);
                    db.SaveChanges();
                    MessageBox.Show("Usuario agregado correctamente.");
                    CargarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar usuario: " + ex.Message);
            }
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string cedula = txtCedula.Text.Trim();

                using (var db = new SistemaGestionAcademicaEntities1())
                {
                    var usuario = db.Usuarios.FirstOrDefault(u => u.Cedula == cedula);
                    if (usuario != null)
                    {
                        usuario.PrimerNombre = txtPrimerNombre.Text.Trim();
                        usuario.SegundoNombre = txtSegundoNombre.Text.Trim();
                        usuario.PrimerApellido = txtPrimerApellido.Text.Trim();
                        usuario.SegundoApellido = txtSegundoApellido.Text.Trim();
                        usuario.CorreoInstitucional = txtCorreo.Text.Trim();
                        usuario.Provincia = txtProvincia.Text.Trim();
                        usuario.Rol = cmbRol.SelectedItem?.ToString() ?? "";

                        db.SaveChanges();
                        MessageBox.Show("Usuario modificado correctamente.");
                        CargarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario: " + ex.Message);
            }
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string cedula = txtCedula.Text.Trim();

                using (var db = new SistemaGestionAcademicaEntities1())
                {
                    var usuario = db.Usuarios.FirstOrDefault(u => u.Cedula == cedula);
                    if (usuario != null)
                    {
                        db.Usuarios.Remove(usuario);
                        db.SaveChanges();
                        MessageBox.Show("Usuario eliminado correctamente.");
                        CargarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar usuario: " + ex.Message);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string cedulaActual = txtCedula.Text.Trim();
                using (var db = new SistemaGestionAcademicaEntities1())
                {
                    var usuarios = db.Usuarios
                        .Where(u => u.Cedula == cedulaActual)
                        .Select(u => new
                        {
                            u.Cedula,
                            u.PrimerNombre,
                            u.SegundoNombre,
                            u.PrimerApellido,
                            u.SegundoApellido,
                            u.CorreoInstitucional,
                            u.Provincia,
                            u.Rol
                        })
                        .ToList();

                    dgvUsuarios.DataSource = usuarios;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar usuario: " + ex.Message);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                    txtCedula.Text = fila.Cells["Cedula"].Value?.ToString() ?? "";
                    txtPrimerNombre.Text = fila.Cells["PrimerNombre"].Value?.ToString()?.Split(' ')[0] ?? "";
                    txtSegundoNombre.Text = fila.Cells["SegundoNombre"].Value?.ToString()?.Split(' ')[0] ?? "";
                    txtPrimerApellido.Text = fila.Cells["PrimerApellido"].Value?.ToString()?.Split(' ')[0] ?? "";
                    txtSegundoApellido.Text = fila.Cells["SegundoApellido"].Value?.ToString()?.Split(' ')[0] ?? "";
                    txtCorreo.Text = fila.Cells["CorreoInstitucional"].Value?.ToString() ?? "";
                    txtProvincia.Text = fila.Cells["Provincia"].Value?.ToString() ?? "";
                    cmbRol.SelectedItem = fila.Cells["Rol"].Value?.ToString() ?? null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar usuario: " + ex.Message);
            }
        }

        private void btnExportarUsuarios_Click(object sender, EventArgs e)
        {
            ExportarUsuariosAExcel();
        }
    }
}
