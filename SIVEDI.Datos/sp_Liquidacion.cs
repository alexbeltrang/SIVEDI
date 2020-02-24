using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Datos
{
    public class sp_Liquidacion
    {
        public StoreProcedure getlistaOfertas(string spName, int intCodigoOferta, int intOpcion, int intCodigoListaPrecios, int intCodigoEstadoActicliente, string strCodigoZona)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_OFERTA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoOferta
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_LISTA_PRECIOS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoListaPrecios
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_ESTADO_ACTI_CLIENTE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoEstadoActicliente
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_ZONA_CLIENTE",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strCodigoZona
                },

            };

            return storeProcedure;
        }
        public StoreProcedure getDatosProdImpulsa(string spName, int intCodigoOferta)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_OFERTA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoOferta
                }
            };

            return storeProcedure;
        }
        public StoreProcedure getlistaProductosAplicaOferta(string spName, int intCodigoOferta)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_OFERTA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoOferta
                }
            };

            return storeProcedure;
        }

    }
}
