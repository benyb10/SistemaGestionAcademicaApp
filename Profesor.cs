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
    public partial class Profesor: Form
    {
        public Profesor()
        {
            InitializeComponent();
        }

        private void btnGestionNotas_Click(object sender, EventArgs e)
        {
            new GestionNotas().Show();
            this.Hide();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
