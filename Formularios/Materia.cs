using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAcademicaApp.Formularios
{
    class Materia
    {
        [Key]
        [StringLength(10)]
        public string IdMateria { get; set; }

        public string NombreMateria { get; set; }

        public int Creditos { get; set; }

        public int IdSemestre { get; set; }

        public virtual Semestres Semestre { get; set; }

        public Materia() { }

        public Materia(string id, string nombre, Semestres semestre)
        {
            IdMateria = id;
            NombreMateria = nombre;
            Semestre = semestre;
        }

        public override string ToString()
        {
            return $"{NombreMateria} (Semestre {Semestre})";
        }
    }
}
