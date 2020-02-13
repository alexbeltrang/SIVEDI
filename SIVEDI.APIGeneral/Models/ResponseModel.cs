using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIVEDI.APIGeneral.Models
{
    public class ResponseModel
    {
        public EnumResponseViewModel Codigo { get; set; }
        public string Mensaje { get; set; }
        public object Respuesta { get; set; }
    }
}