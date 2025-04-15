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

namespace SistemaGestionAcademicaApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasenia = txtContrasenia.Text;

            using (var db = new SistemaGestionAcademicaEntities1())
            {
                var user = db.Usuarios
                             .FirstOrDefault(u => u.Cedula == usuario && u.Cedula == contrasenia);

                if (user != null)
                {
                    MessageBox.Show($"Bienvenido {user.PrimerNombre} {user.PrimerApellido} - Rol: {user.Rol}");

                    // Abrir la ventana correspondiente según el rol
                    switch (user.Rol.ToUpper())
                    {
                        case "ADMINISTRADOR":
                            new Admin().Show();
                            break;
                        case "PROFESOR":
                            new Profesor().Show();
                            break;
                        case "SECRETARIA":
                            new Secretaria().Show();
                            break;
                        case "ESTUDIANTE":
                            new Estudiante().Show();
                            break;
                        default:
                            MessageBox.Show("Rol no reconocido.");
                            break;
                    }
                    SesionActual.CedulaUsuario = usuario;
                    this.Hide(); // Ocultar el formulario de login
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Mostrar un mensaje de confirmación antes de salir
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario confirma, cerrar la aplicación
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}