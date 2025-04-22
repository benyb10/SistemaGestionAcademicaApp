namespace SistemaGestionAcademicaApp.Formularios
{
    internal class Usuario : Usuarios
    {
        public string Cedula { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string CorreoInstitucional { get; set; }
        public string Provincia { get; set; }
        public string Rol { get; set; }
    }
}