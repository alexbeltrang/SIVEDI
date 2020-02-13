using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace SIVEDI.Datos
{
    [Serializable]
    public class StoreProcedure
    {
        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public List<SqlParameter> Parametros { get; set; }
    }
}
