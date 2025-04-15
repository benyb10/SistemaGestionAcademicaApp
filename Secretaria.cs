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
    public partial class Secretaria: Form
    {
        public Secretaria()
        {
            InitializeComponent();
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
