using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class ReferenciaCliente
    {
        public decimal CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }
        public string CIUDAD { get; set; }
        public string TEL_FIJO { get; set; }
        public string TEL_CELULAR { get; set; }
        public string PARENTESCO { get; set; }
        public int CODIGO_CLIENTE { get; set; }
        public string TIPO_REFERENCIA { get; set; }
        public int CODIGO_TIPO_REFERENCIA { get; set; }
    }
}
