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

        public StoreProcedure getListaPrecios(string spName, int intOpcion, int intCodigoListaPrecios)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_LISTA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoListaPrecios
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure insListaPrecios(string spName, ListaPrecios listaPrecios)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NLPR_NID",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = listaPrecios.CODIGO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_LISTA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = listaPrecios.CODIGO_LISTA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_LISTA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = listaPrecios.NOMBRE
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OES_ESTANDAR",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = listaPrecios.ES_ESTANDAR
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = listaPrecios.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_CAMPANA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = listaPrecios.CODIGO_CAMPANA
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = listaPrecios.CODIGO
                }
            };

            return storeProcedure;
        }

        public StoreProcedure iuListaPreciosProducto(string spName, ProductoListaPrecio productoListaPrecio)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_PRODUCTO_LISTA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = productoListaPrecio.CODIGO_PRODUCTO_LISTA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_LISTA_PRECIOS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = productoListaPrecio.CODIGO_LISTA_PRECIOS
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NPRECIO_LISTA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = productoListaPrecio.PRECIO_LISTA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NLIMITE_VENTA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = productoListaPrecio.LIMITE_VENTA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OPERMITE_DIGITAR",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = productoListaPrecio.PERMITE_DIGITAR
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OSUMA_VALOR_PUBLICO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = productoListaPrecio.SUMA_VALOR_PUBLICO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OSUMA_LLEGAR_ESCALA",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = productoListaPrecio.SUMA_LLEGAR_ESCALA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OSE_APLICA_ESCALA",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = productoListaPrecio.SE_APLICA_ESCALA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OAPLICA_SUPERA_MONTO_MIN",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = productoListaPrecio.APLICA_SUPERA_MONTO_MIN
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OES_ACCESORIO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = productoListaPrecio.ES_ACCESORIO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCOSTO_PRODUCTO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = productoListaPrecio.COSTO_PRODUCTO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESFALTANTE_ANUNCIADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = productoListaPrecio.ESFALTANTE_ANUNCIADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_VENTA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = productoListaPrecio.CODIGO_VENTA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OSUMA_NETO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = productoListaPrecio.SUMA_NETO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NPUNTOS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = productoListaPrecio.PUNTOS
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = productoListaPrecio.CODIGO_PRODUCTO_LISTA
                }
            };

            return storeProcedure;
        }
        public StoreProcedure getlistaPreciosProd(string spName, int intOpcion, int intCodigoProducto, int intCodigoListaPrecio)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_PRODUCTO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoProducto
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
                    Value = intCodigoListaPrecio
                }
            };

            return storeProcedure;
        }

    }
}
