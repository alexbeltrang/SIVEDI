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

        public StoreProcedure getConcursos(string spName, string strCodigoZona, int intCodigoListaPrecios, bool blnEsIngreso, int intCodigoTipocliente, int intCodigoEstadoActividad)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_ZONA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strCodigoZona
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_LISTA_PRECIOS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoListaPrecios
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OES_INGRESOS",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = blnEsIngreso
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_TIPO_CLIENTE",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoTipocliente
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_ESTADO_ACTIVIDAD",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoEstadoActividad
                },

            };

            return storeProcedure;
        }

        public StoreProcedure getDetalleCampana(string spName, string strCodigoZona, int intCodigoConcurso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_ZONA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strCodigoZona
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoConcurso
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getValorPublicoPedido(string spName, string strCedulaAsesor, int intCampana)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CNUMERO_CEDULA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strCedulaAsesor
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CAMPANA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCampana
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getPremiosConcurso(string spName, int intValorPedido, int intCodigoConcurso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NVALOR_PEDIDO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intValorPedido
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoConcurso
                }
            };

            return storeProcedure;
        }
    }
}
