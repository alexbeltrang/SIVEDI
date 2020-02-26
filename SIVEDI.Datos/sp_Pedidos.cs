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

        public StoreProcedure getProductoNombreLista(string spName, string strNombreProducto, int intCodigoListaPrecios)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_PRODUCTO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strNombreProducto
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_LISTA_PRECIOS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoListaPrecios
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getProductoNombre(string spName, string strReferencia, string strNombreProducto)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CREFERENCIA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strReferencia
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strNombreProducto
                }
            };

            return storeProcedure;
        }

        public StoreProcedure updPreciosProdcuto(string spName, ProductoListaPrecio productoListaPrecio)
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
                    ParameterName = "@PI_NPRECIO_LISTA",
                    SqlDbType = System.Data.SqlDbType.Decimal,
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
                    SqlDbType = System.Data.SqlDbType.Decimal,
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
                    ParameterName = "@PI_OESPRINCIPAL",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = productoListaPrecio.ES_PRINCIPAL
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_PORCENTAJEIVA",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = productoListaPrecio.PORCENTAJE_IVA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CTIPO_PRODCUTO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = productoListaPrecio.TIPO_PRODUCTO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OSUMA_NETO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = productoListaPrecio.SUMA_NETO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NPUNTO_PREMIO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = productoListaPrecio.PUNTOS
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NPRECIO_CATALOGO",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = productoListaPrecio.PRECIO_CATALOGO
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

        public StoreProcedure DelCodigoListaPreciosProd(string spName, int intCodigoVenta)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_PRODUCTO_LISTA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoVenta
                },
                 new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Value = intCodigoVenta
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getCodigoVenta(string spName, int intOpcion, int intCodigoProducto)
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
                }
            };

            return storeProcedure;
        }

        public StoreProcedure DelCodigoVenta(string spName, int intCodigoVenta)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_VENTA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoVenta
                }
            };

            return storeProcedure;
        }

        public StoreProcedure iuCodigoVenta(string spName, CodigoVenta codigoVenta)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_PRODUCTO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = codigoVenta.REFERENCIA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_VENTA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = codigoVenta.CODIGO_VENTA
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OESTADO",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = codigoVenta.ESTADO
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_OES_PRINCIPAL",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = codigoVenta.ES_PRINCIPAL
                },
                new SqlParameter()
                {
                    ParameterName = "@PO_NRESULT",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction= System.Data.ParameterDirection.Output,
                    Value = codigoVenta.CODIGO
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getEquivalencias(string spName, int intOpcion, int intCodigoEquivalencia, String strCodigoSolicita)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_EQUIVALENCIA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoEquivalencia
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_SOLICITA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = intOpcion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getCombos(string spName, int intOpcion, int intCodigoCombo, string strCodigoVenta, int intCodigoListaPrecios)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NOPCION",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intOpcion
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_COMBO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoCombo
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_VENTA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strCodigoVenta
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_LISTA_PRECIOS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoListaPrecios
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getProductoCombos(string spName, int intCodigoCombo)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_COMBO",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoCombo
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getProductoPedidos(string spName, string strCodigoVenta, int intCodigoListaPrecios)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CCODIGO_VENTA",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strCodigoVenta
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_NCODIGO_LISTA_PRECIOS",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCodigoListaPrecios
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getClientePedido(string spName, string strIdentificacion)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CNUMERO_IDENTIFICACION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strIdentificacion
                }
            };

            return storeProcedure;
        }

        public StoreProcedure getClienteListaPrecios(string spName, int intOpcion, string strIdentificacion)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CIDENTIFICACION",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strIdentificacion
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

        public StoreProcedure getConcursoFiltro(string spName, int intCampanaEntrega, string strNombreConcruso)
        {
            StoreProcedure storeProcedure = new StoreProcedure();
            storeProcedure.Nombre = spName;
            storeProcedure.Parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PI_CCAMPANA_ENTREGA",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = intCampanaEntrega
                },
                new SqlParameter()
                {
                    ParameterName = "@PI_CNOMBRE_CONCURSO",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = strNombreConcruso
                }
            };

            return storeProcedure;
        }

    }
}
