using SIVEDI.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace SIVEDI.Datos
{
    public class sp_Cuentas
    {
        public StoreProcedure getConsultaClientes(string spName, string strIdentificacionCliente)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CNUMERO_IDENTIFICACION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strIdentificacionCliente
                },
            };

            return storeProcedure;
        }
    }
}
