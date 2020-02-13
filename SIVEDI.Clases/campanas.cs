using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class campanas
    {
        public int CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public DateTime FECHA_INICIAL { get; set; }
        public DateTime FECHA_FINAL { get; set; }
        public int NIVEL { get; set; }
        public int CONSECUTIVO { get; set; }
        public bool ESTADO { get; set; }
    }
}
