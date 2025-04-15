using System.ComponentModel.DataAnnotations;

namespace SistemaGestionAcademicaApp.Formularios
{
    internal class Matricula : Matriculas
    {
        public int IdMatricula { get; set; }

        public string CedulaSecretaria { get; set; }

        public string CedulaEstudiante { get; set; }

        [StringLength(10)]
        public string IdMateria { get; set; }

        public byte RepiteMateria { get; set; }

        public virtual Usuarios Estudiante { get; set; }

        public virtual Usuarios Secretaria { get; set; }

        public virtual Materias Materia { get; set; }
    }
}