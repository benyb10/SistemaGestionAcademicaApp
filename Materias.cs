//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaGestionAcademicaApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Materias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Materias()
        {
            this.Matriculas = new HashSet<Matriculas>();
        }
    
        public string IdMateria { get; set; }
        public string NombreMateria { get; set; }
        public Nullable<int> Creditos { get; set; }
        public Nullable<int> IdSemestre { get; set; }
        public string IdProfesor { get; set; }
    
        public virtual Semestres Semestres { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matriculas> Matriculas { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
