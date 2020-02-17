using SIVEDI.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace SIVEDI.Datos
{
    public class sp_Pedidos
    {
        public StoreProcedure getConsultaPedidosCliente(string spName, int intCodigoCliente)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CLIENTE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoCliente
                },
            };

            return storeProcedure;
        }

    }
}
