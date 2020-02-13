using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class usuarios
    {
        public int CODIGO { get; set; }
        public String NOMBRES { get; set; }
        public String APELLIDOS { get; set; }
        public String LOGIN { get; set; }
        public String PASSWORD { get; set; }
        public bool ESTADO { get; set; }
        public int COD_PERFIL { get; set; }
        public String EMAIL { get; set; }
    }
}
