namespace SIVEDI.Clases
{
    public class LoginUsuario
    {
        public int intIdUsuario { get; set; }
        public int intCodigoPerfil { get; set; }
        public string strNombreUsuario { get; set; }
        public string strEmailUsuario { get; set; }
        public bool blnEstado { get; set; }
        public bool blnCambiaPassword { get; set; }
        public bool blnResultado { get; set; }
    }
}
