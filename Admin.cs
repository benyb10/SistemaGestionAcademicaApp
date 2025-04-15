using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaGestionAcademicaApp.Formularios;

namespace SistemaGestionAcademicaApp
{
    public partial class Admin: Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            new GestionUsuarios().Show();
            this.Hide();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void btnGestionMaterias_Click(object sender, EventArgs e)
        {
            new GestionMaterias().Show();
            this.Hide();
        }

        private void btnGestionEstudiantes_Click(object sender, EventArgs e)
        {
            new GestionEstudiantes().Show();
            this.Hide();
        }

        private void btnGestionMatriculas_Click(object sender, EventArgs e)
        {
            new GestionMatriculas().Show();
            this.Hide();
        }
    }
}
