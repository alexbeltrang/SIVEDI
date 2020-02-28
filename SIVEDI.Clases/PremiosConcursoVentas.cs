using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class PremiosConcursoVentas
    {
        public int CODIGO { get; set; }
        public string PRODUCTO { get; set; }
        public string NOMBRE { get; set; }
        public decimal VLR_MINIMO { get; set; }
        public decimal VLR_MAXIMO { get; set; }
        public int UNIDADES { get; set; }
        public decimal CODIGO_LISTA { get; set; }
    }
}
