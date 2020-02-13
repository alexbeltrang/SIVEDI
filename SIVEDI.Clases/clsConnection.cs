using System.Data;

namespace SIVEDI.Clases
{
    public class clsConnection
    {
        // Definición variables Globales tipo String
        public static int intIdUsuario;
        public static int intCodigoPerfil;
        public static string strNombreUsuario;
        public static string strEmailUsuario;
        public static string strCadenaConexionBaseDatos;
        public static string strNombreProducto;
        public static string strCodigoVentaProducto;
        public static string strReferenciaProducto;


        // Definición variables Globales tipo Integer
        public static int intCodigoPais;
        public static int intCodigoDepto;
        public static int intCodigoProducto;
        public static int intCodigoOfertaSimle;
        public static int intCodigoCombo;
        public static int intCodigoEquivalencia;
        public static int intCodigoConcursoVentas;

        // Definición variables Globales tipo Booleanas
        public static bool blnAyudaEnlinea = false;
        public static bool blnVentanasEnbebidas = false;
        public static bool blnDepartamentosdesdePais = false;
        public static bool blnCiudadesdesdeDepto = false;
        public static bool blnbuscaRespDesdeReg = false;
        public static bool blnbuscaRespDesdeZon = false;
        public static bool blnbuscaRespDesdeSec = false;
        public static bool blnActualizaConexiones = false;
        public static bool blnActualizaOfertasSimples = false;
        public static bool blnActualizaCombos = false;
        public static bool blnActualizaEquivalencias = false;
        public static bool blnActualizaListaconcursosNvo = false;
        // Definición datatables Globales 
        public static DataTable dttMenus = new DataTable();
    }
}
