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
    public partial class Estudiante: Form
    {
        public Estudiante()
        {
            InitializeComponent();
           

        }

        

        private void btnVerNotas_Click(object sender, EventArgs e)
        {
            new VerNotas().Show();
            this.Hide();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
