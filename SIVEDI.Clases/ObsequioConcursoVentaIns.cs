using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class ObsequioConcursoVentaIns
    {
        public int CODIGO_OBSEQUIO { get; set; }
        public int CODIGO_LISTA_PRECIOS { get; set; }
        public decimal VALOR_MINIMO { get; set; }
        public decimal VALOR_MAXIMO { get; set; }
        public int UNIDADES { get; set; }
        public int CODIGO_CONCURSO { get; set; }
    }
}
