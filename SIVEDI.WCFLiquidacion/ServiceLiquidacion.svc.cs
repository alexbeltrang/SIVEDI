using SIVEDI.Clases;
using SIVEDI.Clases.TABLAS;
using SIVEDI.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SIVEDI.WCFLiquidacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceLiquidacion" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceLiquidacion.svc o ServiceLiquidacion.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceLiquidacion : IServiceLiquidacion
    {
        public void DoWork()
        {
        }

        public DataTable preliquidaPedido(DataTable dttPedidoOriginal, int intCodigoListaPrecios, string strConexion, int intCodigoEstadoActiCliente, string strCodigoZonaCliente, int intCodigoTipoCliente, bool blnEsIngreso, string strIdentificacionCliente, int intCodigoCiudadCliente, bool blnCobraFlete, int intTipoCliente)
        {

            DataTable dttPedidoDefinitivo = new DataTable();
            DataTable dttConcursosVentas = new DataTable();
            DataTable dttValorCampanas = new DataTable();
            decimal decPorcentajedescuento;
            int intValorMontoOferta;  // variable para almacenar el monto de la oferta para validar el pedido
            int intFactorConversion;  // variable para almacenar el factor de conversion
            int intUnidadesOferta;  // variable para almacenar el total de unidades que trae la oferta sera utilizada en la formula de calculo total
            decimal intTotalUnidadesBeneficiadas; // variable para almacenar el total de unidades que beneficia la oferta
            bool blnCumpleOferta, blnCumplepasaPedido, blnCumplecondCampana;
            decimal intValorNeto;
            int intValorPublicoAcumuladoAsesor;
            int intValorPublicoTotalCampanasParamentrizacion;
            int intTotalCumpleCampanas;
            decimal dclValorColchon;
            int intCodigoCampanaActual;
            DataTable dttDatosProductosconcurso = new DataTable();
            // se consulta a la base de datos las ofertas simples de la lista de precios que tiene asociado el asesor
            var dttOfertas = getlistaOfertas(0, 3, intCodigoListaPrecios, intCodigoEstadoActiCliente, strCodigoZonaCliente);
            // se recorren todas las ofertas
            foreach (OfertasSimples oferta in dttOfertas)
            {
                // se asigna el valor de conversion de la oferta a la variable
                intFactorConversion = Convert.ToInt32(oferta.FACTOR_CONVERSION);
                blnCumpleOferta = false;
                // se cargan los prodcutos que impulsan la oferta para se comparados con el pedido
                var dttProdImpulsaOferta = getDatosProdImpulsa(Convert.ToInt32(oferta.CODIGO));
                // aqui se valida si la oferta es por cantidad o monto
                if (oferta.ES_POR_CANTIDAD)
                {
                    // aqui se valida si la oferta entrega un obsequio
                    if (oferta.ES_OBSEQUIO)
                    {
                        int intUnidadesSolicitadas = 0;
                        // se reccoren los productos que impulsan la oferta para validar con el pedido que viene para ver si existe prodcuto digitado es igual a alguna de la oferta
                        foreach (OfertaImpulsa ofertaImpulsa in dttProdImpulsaOferta)
                        {
                            for (var w = 0; w <= dttPedidoOriginal.Rows.Count - 1; w++)
                            {
                                if (ofertaImpulsa.CODIGO_VENTA == dttPedidoOriginal.Rows[w]["CODIGO"].ToString())
                                {
                                    if (Convert.ToInt32(dttPedidoOriginal.Rows[w]["CANTIDAD"].ToString()) >= intFactorConversion)
                                    {
                                        intUnidadesSolicitadas = Convert.ToInt32(dttPedidoOriginal.Rows[w]["CANTIDAD"].ToString());
                                        blnCumpleOferta = true;
                                    }
                                }
                            }
                        }

                        // aqui se valida si el pedido cumple la oferta y se entra a otorgar los beneficios
                        if (blnCumpleOferta)
                        {
                            var dttProdAplicaOferta = getlistaProductosAplicaOferta(Convert.ToInt32(oferta.CODIGO));
                            foreach (ProductosAplicaOferta productosAplica in dttProdAplicaOferta)
                            {
                                intUnidadesOferta = productosAplica.UNIDADES;
                                intTotalUnidadesBeneficiadas = (Convert.ToDecimal(intUnidadesSolicitadas) / intFactorConversion);
                                intTotalUnidadesBeneficiadas = Math.Truncate(intTotalUnidadesBeneficiadas) * intUnidadesOferta;
                                // aqui se adiciona el producto con el beneficio
                                DataRow row;
                                row = dttPedidoOriginal.NewRow();
                                row["CODIGO"] = productosAplica.CODIGO_VENTA;
                                row["NOMBRE"] = productosAplica.NOMBRE_PRODUCTO;
                                row["CANTIDAD"] = intTotalUnidadesBeneficiadas;

                                var dttProductoFinal = getProductoPedidos(productosAplica.CODIGO_VENTA, intCodigoListaPrecios);
                                if (dttProductoFinal.FirstOrDefault().IVA > 0)
                                {
                                    row["PRECIO_NET"] = 0;
                                    row["PRECIO_TOTAL"] = 0;
                                    row["TIENE_IVA"] = "S";
                                    row["VALOR_IVA"] = 0;
                                }
                                else
                                {
                                    row["PRECIO_NET"] = 0;
                                    row["PRECIO_TOTAL"] = 0;
                                    row["TIENE_IVA"] = "N";
                                    row["VALOR_IVA"] = 0;
                                }
                                row["SAV_LISTA_PRECIOS_PROD"] = dttProductoFinal.FirstOrDefault().CODIGO;
                                row["PRECIO_UNI"] = 0;
                                row["PRECIO_PUB"] = 0;
                                row["SUMA_VALOR_PUBLICO"] = dttProductoFinal.FirstOrDefault().SUMA_VALOR_PUBLICO;
                                row["ESCALA_DESCUENTOS"] = dttProductoFinal.FirstOrDefault().SUMA_PARA_LLEGAR_ESCALA;
                                row["SE_LE_APLICA_ESCALA_DCTOS"] = dttProductoFinal.FirstOrDefault().APLICA_ESCALA;
                                row["MONTO_PEDIDO"] = dttProductoFinal.FirstOrDefault().APLICA_SUPERA_MONTO_MINIMO;
                                row["ES_ACCESORIO"] = dttProductoFinal.FirstOrDefault().ES_ACCESORIO;
                                row["PORC_IVA"] = dttProductoFinal.FirstOrDefault().IVA;
                                row["MOTIVO_VENTA"] = dttProductoFinal.FirstOrDefault().MOTIVO_VENTA;
                                row["CENTRO_GASTO"] = dttProductoFinal.FirstOrDefault().CENTRO_GASTO_VENTA;
                                row["MOTIVO_OBSEQUIO"] = dttProductoFinal.FirstOrDefault().MOTIVO_OBSEQUIO;
                                row["CENTRO_GASTO_OBSEQUIO"] = dttProductoFinal.FirstOrDefault().CENTRO_GASTO_OBSEQUIO;
                                row["TIPO_PRODUCTO"] = dttProductoFinal.FirstOrDefault().CODIGO_TIPO_PRODUCTO;
                                row["PORC_DESCUENTO_ESPECIAL"] = 0;
                                row["VALOR_DESCUENTO_ESPECIAL"] = 0;
                                row["PRECIO_LISTA"] = 0;
                                row["OFERTA_APLICADA"] = true;
                                row["ELIMINA"] = false;
                                row["PORC_ESCALA_DESCUENTO"] = "0";
                                row["VALOR_ESCALA_UNITARIO"] = "0";
                                row["VALOR_ESCALA_TOTAL"] = "0";
                                row["SUMA_NETO"] = dttProductoFinal.FirstOrDefault().SUMA_PARA_VALOR_NETO;
                                row["PUNTOS_PRODUCTO"] = "0";
                                dttPedidoOriginal.Rows.Add(row);
                            }
                        }
                    }
                    else if (oferta.ES_DESCUENTO)
                    {
                        // se reccoren los productos que impulsan la oferta para validar con el pedido que viene para ver si existe prodcuto digitado es igual a alguna de la oferta
                        blnCumpleOferta = false;
                        foreach (OfertaImpulsa ofertaImpulsa in dttProdImpulsaOferta)
                        {
                            for (var w = 0; w <= dttPedidoOriginal.Rows.Count - 1; w++)
                            {
                                if (ofertaImpulsa.CODIGO_VENTA == dttPedidoOriginal.Rows[w]["CODIGO"].ToString())
                                {
                                    if (Convert.ToInt32(dttPedidoOriginal.Rows[w]["CANTIDAD"].ToString()) >= intFactorConversion)
                                        blnCumpleOferta = true;
                                }
                            }
                        }

                        // aqui se valida si el pedido cumple la oferta y se entra a otorgar los beneficios
                        if (blnCumpleOferta)
                        {

                            dttProdAplicaOferta = objOfertas.getlistaProductosAplicaOferta(dttOfertas.Rows(i).Item("PRM_NID"), strConexion);
                            for (var x = 0; x <= dttProdAplicaOferta.Rows.Count - 1; x++)
                            {
                                for (var w = 0; w <= dttPedidoOriginal.Rows.Count - 1; w++)
                                {
                                    if (dttProdAplicaOferta.Rows(x).Item("CODIGO VENTA") == dttPedidoOriginal.Rows(w).Item("CODIGO"))
                                    {
                                        decPorcentajedescuento = dttProdAplicaOferta.Rows(x).Item("PORCENTAJE");
                                        intUnidadesOferta = dttProdAplicaOferta.Rows(x).Item("UNIDADES");
                                        intTotalUnidadesBeneficiadas = (dttPedidoOriginal.Rows(w).Item("CANTIDAD") / (double)intFactorConversion);
                                        intTotalUnidadesBeneficiadas = Math.Truncate(intTotalUnidadesBeneficiadas) * intUnidadesOferta;
                                        if (intTotalUnidadesBeneficiadas < dttPedidoOriginal.Rows(w).Item("CANTIDAD"))
                                        {
                                            dttPedidoOriginal.Rows(w).Item("CANTIDAD") = (dttPedidoOriginal.Rows(w).Item("CANTIDAD") - intTotalUnidadesBeneficiadas);
                                            if (dttPedidoOriginal.Rows(w).Item("TIENE_IVA") == "S")
                                                dttPedidoOriginal.Rows(w).Item("VALOR_IVA") = dttPedidoOriginal.Rows(w).Item("PRECIO_UNI") - (dttPedidoOriginal.Rows(w).Item("PRECIO_UNI") / (double)(1 + dttPedidoOriginal.Rows(w).Item("PORC_IVA")));
                                            // aqui se adiciona el producto con el beneficio
                                            DataRow row;
                                            row = dttPedidoOriginal.NewRow;
                                            row("CODIGO") = dttProdAplicaOferta.Rows(x).Item("CODIGO VENTA");
                                            row("NOMBRE") = dttProdAplicaOferta.Rows(x).Item("NOMBRE PRODUCTO");
                                            row("CANTIDAD") = intTotalUnidadesBeneficiadas;
                                            DataTable dttProductoFinal = new DataTable();
                                            dttProductoFinal = objOfertas.getProductoPedidos(dttProdAplicaOferta.Rows(x).Item("CODIGO VENTA"), intCodigoListaPrecios, strConexion);
                                            if (dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA") > 0)
                                            {
                                                intValorNeto = dttProductoFinal.Rows(0).Item("LPP_NPRECIO_LISTA") / (double)(1 + dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA"));
                                                intValorNeto = intValorNeto - ((intValorNeto * dttProdAplicaOferta.Rows(x).Item("PORCENTAJE")) / (double)100);
                                                row("PRECIO_PUB") = intValorNeto * (1 + dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA"));
                                                row("VALOR_DESCUENTO_ESPECIAL") = (dttProductoFinal.Rows(0).Item("LPP_NPRECIO_LISTA") / (double)(1 + dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA"))) - intValorNeto;
                                                row("PRECIO_NET") = intValorNeto;
                                                row("PRECIO_TOTAL") = (intValorNeto * intTotalUnidadesBeneficiadas);
                                                row("TIENE_IVA") = "S";
                                                row("VALOR_IVA") = (intValorNeto * (1 + dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA"))) - ((intValorNeto * (1 + dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA"))) / (double)(1 + dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA")));
                                                dttPedidoOriginal.Rows(w).Item("PRECIO_TOTAL") = intValorNeto * dttPedidoOriginal.Rows(w).Item("CANTIDAD");
                                                row("PRECIO_LISTA") = dttProductoFinal.Rows(0).Item("LPP_NPRECIO_LISTA");
                                            }
                                            else
                                            {
                                                intValorNeto = dttProductoFinal.Rows(0).Item("LPP_NPRECIO_LISTA");
                                                intValorNeto = intValorNeto - ((intValorNeto * dttProdAplicaOferta.Rows(x).Item("PORCENTAJE")) / (double)100);
                                                row("PRECIO_PUB") = intValorNeto;
                                                row("VALOR_DESCUENTO_ESPECIAL") = dttProductoFinal.Rows(0).Item("LPP_NPRECIO_LISTA") - intValorNeto;
                                                row("PRECIO_NET") = intValorNeto;
                                                row("PRECIO_TOTAL") = (intValorNeto * intTotalUnidadesBeneficiadas);
                                                row("TIENE_IVA") = "N";
                                                row("VALOR_IVA") = 0;
                                                intValorNeto = dttPedidoOriginal.Rows(w).Item("PRECIO_UNI");
                                                dttPedidoOriginal.Rows(w).Item("PRECIO_TOTAL") = intValorNeto * dttPedidoOriginal.Rows(w).Item("CANTIDAD");
                                                row("PRECIO_LISTA") = dttProductoFinal.Rows(0).Item("LPP_NPRECIO_LISTA");
                                            }
                                            row("SAV_LISTA_PRECIOS_PROD") = dttProductoFinal.Rows(0).Item("CODIGO");
                                            row("PRECIO_UNI") = dttProductoFinal.Rows(0).Item("LPP_NPRECIO_LISTA");
                                            row("SUMA_VALOR_PUBLICO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_PUBLICO");
                                            row("ESCALA_DESCUENTOS") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_LLEGAR_ESCALA");
                                            row("SE_LE_APLICA_ESCALA_DCTOS") = dttProductoFinal.Rows(0).Item("LPP_OSE_APLICA_ESCALA");
                                            row("MONTO_PEDIDO") = dttProductoFinal.Rows(0).Item("LPP_OAPLICA_SUPERA_MONTO_MIN");
                                            row("ES_ACCESORIO") = dttProductoFinal.Rows(0).Item("LPP_OES_ACCESORIO");
                                            row("PORC_IVA") = dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA");
                                            row("MOTIVO_VENTA") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_VENTA");
                                            row("CENTRO_GASTO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_VENTA");
                                            row("MOTIVO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_OBSEQUIO");
                                            row("CENTRO_GASTO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_OBSEQUIO");
                                            row("PORC_DESCUENTO_ESPECIAL") = dttProdAplicaOferta.Rows(x).Item("PORCENTAJE");
                                            row("TIPO_PRODUCTO") = dttProdAplicaOferta.Rows(0).Item("TPR_CID");
                                            row("OFERTA_APLICADA") = true;
                                            row("ELIMINA") = false;
                                            row("PORC_ESCALA_DESCUENTO") = "0";
                                            row("VALOR_ESCALA_UNITARIO") = "0";
                                            row("VALOR_ESCALA_TOTAL") = "0";
                                            row("SUMA_NETO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_NETO");
                                            row("PUNTOS_PRODUCTO") = dttProductoFinal.Rows(0).Item("LPP_NPUNTO_PREMIO") * intTotalUnidadesBeneficiadas;
                                            dttPedidoOriginal.Rows(w).Item("PUNTOS_PRODUCTO") = dttProductoFinal.Rows(0).Item("LPP_NPUNTO_PREMIO") * dttPedidoOriginal.Rows(w).Item("CANTIDAD");

                                            dttPedidoOriginal.Rows.Add(row);
                                        }
                                        else
                                        {
                                            dttPedidoOriginal.Rows(w).Item("ELIMINA") = true;
                                            // aqui se adiciona el producto con el beneficio
                                            DataRow row;
                                            row = dttPedidoOriginal.NewRow;
                                            row("CODIGO") = dttProdAplicaOferta.Rows(x).Item("CODIGO VENTA");
                                            row("NOMBRE") = dttProdAplicaOferta.Rows(x).Item("NOMBRE PRODUCTO");
                                            row("CANTIDAD") = intTotalUnidadesBeneficiadas;
                                            DataTable dttProductoFinal = new DataTable();
                                            dttProductoFinal = objOfertas.getProductoPedidos(dttProdAplicaOferta.Rows(x).Item("CODIGO VENTA"), intCodigoListaPrecios, strConexion);
                                            if (dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA") > 0)
                                            {
                                                intValorNeto = dttProductoFinal.Rows(0).Item("LPP_NPRECIO_LISTA") / (double)(1 + dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA"));
                                                intValorNeto = intValorNeto - ((intValorNeto * dttProdAplicaOferta.Rows(x).Item("PORCENTAJE")) / (double)100);
                                                row("PRECIO_PUB") = intValorNeto * (1 + dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA"));
                                                row("VALOR_DESCUENTO_ESPECIAL") = ((intValorNeto * dttProdAplicaOferta.Rows(x).Item("PORCENTAJE")) / (double)100);
                                                row("PRECIO_NET") = intValorNeto;
                                                row("PRECIO_TOTAL") = (intValorNeto * intTotalUnidadesBeneficiadas);
                                                row("TIENE_IVA") = "S";
                                                row("VALOR_IVA") = (intValorNeto * (1 + dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA"))) - ((intValorNeto * (1 + dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA"))) / (double)(1 + dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA")));
                                                dttPedidoOriginal.Rows(w).Item("PRECIO_TOTAL") = intValorNeto * dttPedidoOriginal.Rows(w).Item("CANTIDAD");
                                                row("PRECIO_LISTA") = dttProductoFinal.Rows(0).Item("LPP_NPRECIO_LISTA");
                                            }
                                            else
                                            {
                                                intValorNeto = dttProductoFinal.Rows(0).Item("LPP_NPRECIO_LISTA");
                                                intValorNeto = intValorNeto - ((intValorNeto * dttProdAplicaOferta.Rows(x).Item("PORCENTAJE")) / (double)100);
                                                row("PRECIO_PUB") = intValorNeto;
                                                row("VALOR_DESCUENTO_ESPECIAL") = ((intValorNeto * dttProdAplicaOferta.Rows(x).Item("PORCENTAJE")) / (double)100);
                                                row("PRECIO_NET") = intValorNeto;
                                                row("PRECIO_TOTAL") = (intValorNeto * intTotalUnidadesBeneficiadas);
                                                row("TIENE_IVA") = "N";
                                                row("VALOR_IVA") = "0";
                                                intValorNeto = dttPedidoOriginal.Rows(w).Item("PRECIO_UNI");
                                                dttPedidoOriginal.Rows(w).Item("PRECIO_TOTAL") = intValorNeto * dttPedidoOriginal.Rows(w).Item("CANTIDAD");
                                                row("PRECIO_LISTA") = dttProductoFinal.Rows(0).Item("LPP_NPRECIO_LISTA");
                                            }
                                            row("SAV_LISTA_PRECIOS_PROD") = dttProductoFinal.Rows(0).Item("CODIGO");
                                            row("PRECIO_UNI") = dttProductoFinal.Rows(0).Item("LPP_NPRECIO_LISTA");
                                            row("SUMA_VALOR_PUBLICO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_PUBLICO");
                                            row("ESCALA_DESCUENTOS") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_LLEGAR_ESCALA");
                                            row("SE_LE_APLICA_ESCALA_DCTOS") = dttProductoFinal.Rows(0).Item("LPP_OSE_APLICA_ESCALA");
                                            row("MONTO_PEDIDO") = dttProductoFinal.Rows(0).Item("LPP_OAPLICA_SUPERA_MONTO_MIN");
                                            row("ES_ACCESORIO") = dttProductoFinal.Rows(0).Item("LPP_OES_ACCESORIO");
                                            row("PORC_IVA") = dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA");
                                            row("MOTIVO_VENTA") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_VENTA");
                                            row("CENTRO_GASTO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_VENTA");
                                            row("MOTIVO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_OBSEQUIO");
                                            row("CENTRO_GASTO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_OBSEQUIO");
                                            row("PORC_DESCUENTO_ESPECIAL") = dttProdAplicaOferta.Rows(x).Item("PORCENTAJE");
                                            row("TIPO_PRODUCTO") = dttProdAplicaOferta.Rows(0).Item("TPR_CID");
                                            row("OFERTA_APLICADA") = true;
                                            row("ELIMINA") = false;
                                            row("PORC_ESCALA_DESCUENTO") = "0";
                                            row("VALOR_ESCALA_UNITARIO") = "0";
                                            row("VALOR_ESCALA_TOTAL") = "0";
                                            row("SUMA_NETO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_NETO");
                                            row("PUNTOS_PRODUCTO") = dttProductoFinal.Rows(0).Item("LPP_NPUNTO_PREMIO") * intTotalUnidadesBeneficiadas;
                                            dttPedidoOriginal.Rows.Add(row);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (dttOfertas.Rows(i).Item("PRM_OESPORMONTO"))
                {
                    DataTable dttProductoPromocionado = new DataTable();
                    int intTotalMontoSolicitado;
                    int intUnidadesSolicitadas;
                    intValorMontoOferta = dttOfertas.Rows(i).Item("PRM_NVALOR_MONTO");

                    if (dttOfertas.Rows(i).Item("PRM_OESPROMOCION"))
                    {
                        dttProductoPromocionado = objOfertas.getlistaProductosAplicaOferta(dttOfertas.Rows(i).Item("PRM_NID"), strConexion); // se traen los productos que puede llevar en la oferta y por cada uno se hace la validación
                        for (var a = 0; a <= dttProductoPromocionado.Rows.Count - 1; a++)
                        {
                            for (var w = 0; w <= dttPedidoOriginal.Rows.Count - 1; w++) // este ciclo es para revisar si el usuario digito el prodcuto promocionado
                            {
                                if (dttProductoPromocionado.Rows(a).Item("CODIGO VENTA") == dttPedidoOriginal.Rows(w).Item("CODIGO"))
                                {
                                    intUnidadesSolicitadas = dttPedidoOriginal.Rows(w).Item("CANTIDAD");
                                    for (var z = 0; z <= dttProdImpulsaOferta.Rows.Count - 1; z++) // se reccorre la tabla que tiene los productos que impulsan la oferta
                                    {
                                        for (var b = 0; b <= dttPedidoOriginal.Rows.Count - 1; b++) // se reccorre la tabla que tiene los productos que digito el usuario
                                        {
                                            if (dttProdImpulsaOferta.Rows(z).Item("CODIGO VENTA") == dttPedidoOriginal.Rows(b).Item("CODIGO"))
                                                intTotalMontoSolicitado = intTotalMontoSolicitado + dttPedidoOriginal.Rows(b).Item("PRECIO_LISTA") * dttPedidoOriginal.Rows(b).Item("CANTIDAD");
                                        }
                                    }
                                    if (intTotalMontoSolicitado >= intValorMontoOferta)
                                    {
                                        dttPedidoOriginal.Rows(w).Item("CANTIDAD") = System.Convert.ToInt32(intTotalMontoSolicitado / (double)dttProductoPromocionado.Rows(a).Item("VENTA"));
                                        dttPedidoOriginal.Rows(w).Item("PRECIO_TOTAL") = ((dttPedidoOriginal.Rows(w).Item("PRECIO_UNI") / (double)(1 + dttPedidoOriginal.Rows(w).Item("PORC_IVA")))) * dttPedidoOriginal.Rows(w).Item("CANTIDAD");
                                        dttPedidoOriginal.Rows(w).Item("OFERTA_APLICADA") = true;
                                    }
                                    else
                                        dttPedidoOriginal.Rows(w).Item("ELIMINA") = true;
                                }
                            }
                        }
                    }
                }
            }


            /*    

                // aqui se eliminan los productos de promociones que se digitaron pero que no estan habilitados para el asesor
                dttOfertas = objOfertas.getlistaOfertas(0, 4, intCodigoListaPrecios, strConexion, intCodigoEstadoActiCliente, strCodigoZonaCliente);
                for (var i = 0; i <= dttOfertas.Rows.Count - 1; i++)
                {
                    if (dttOfertas.Rows(i).Item("PRM_OESPROMOCION"))
                    {
                        dttProdAplicaOferta = objOfertas.getlistaProductosAplicaOferta(dttOfertas.Rows(i).Item("PRM_NID"), strConexion);
                        for (var z = 0; z <= dttProdAplicaOferta.Rows.Count - 1; z++) // se reccorre la tabla que tiene los productos que aplican la oferta
                        {
                            for (var b = 0; b <= dttPedidoOriginal.Rows.Count - 1; b++) // se reccorre la tabla que tiene los productos que digito el usuario
                            {
                                if (!dttPedidoOriginal.Rows(b).Item("OFERTA_APLICADA"))
                                {
                                    if (dttProdAplicaOferta.Rows(z).Item("CODIGO VENTA") == dttPedidoOriginal.Rows(b).Item("CODIGO"))
                                        dttPedidoOriginal.Rows(b).Item("ELIMINA") = true;
                                }
                            }
                        }
                    }
                }



                DataRow rowDef;
                {
                    var withBlock = dttPedidoDefinitivo;
                    withBlock.Columns.Add(new DataColumn("CODIGO", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("NOMBRE", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("CANTIDAD", typeof(int)));
                    withBlock.Columns.Add(new DataColumn("PRECIO_UNI", typeof(int)));
                    withBlock.Columns.Add(new DataColumn("PRECIO_PUB", typeof(int)));
                    withBlock.Columns.Add(new DataColumn("PRECIO_NET", typeof(int)));
                    withBlock.Columns.Add(new DataColumn("PRECIO_TOTAL", typeof(int)));
                    withBlock.Columns.Add(new DataColumn("TIENE_IVA", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("TIPO_REG", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("ELIMINA", typeof(bool)));
                    withBlock.Columns.Add(new DataColumn("TIPO_PRODUCTO", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("ESCALA_DESCUENTOS", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("SE_LE_APLICA_ESCALA_DCTOS", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("ES_ACCESORIO", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("MONTO_PEDIDO", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("ES_PRODUCTO_CRP", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("PORC_IVA", typeof(decimal)));
                    withBlock.Columns.Add(new DataColumn("VALOR_IVA", typeof(int)));
                    withBlock.Columns.Add(new DataColumn("PORC_DESCUENTO_ESPECIAL", typeof(decimal)));
                    withBlock.Columns.Add(new DataColumn("VALOR_DESCUENTO_ESPECIAL", typeof(int)));
                    withBlock.Columns.Add(new DataColumn("LISTA_PRECIOS", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("SAV_LISTA_PRECIOS_PROD", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("MOTIVO_VENTA", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("CENTRO_GASTO", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("GRUPO_PRODUCTO", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("BODEGA", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("OFERTA_APLICADA", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("ES_SALIDA", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("TIENE_FALTANTE", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("CODIGO_CONCURSO", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("SUMA_VALOR_PUBLICO", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("MOTIVO_OBSEQUIO", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("CENTRO_GASTO_OBSEQUIO", typeof(string)));
                    withBlock.Columns.Add(new DataColumn("PRECIO_LISTA", typeof(int)));
                    withBlock.Columns.Add(new DataColumn("PORC_ESCALA_DESCUENTO", typeof(decimal)));
                    withBlock.Columns.Add(new DataColumn("VALOR_ESCALA_UNITARIO", typeof(int)));
                    withBlock.Columns.Add(new DataColumn("VALOR_ESCALA_TOTAL", typeof(int)));
                    withBlock.Columns.Add(new DataColumn("SUMA_NETO", typeof(bool)));
                    withBlock.Columns.Add(new DataColumn("PUNTOS_PRODUCTO", typeof(int)));
                }

                int intLinea = 0;
                for (var i = 0; i <= dttPedidoOriginal.Rows.Count - 1; i++)
                {
                    if (!dttPedidoOriginal.Rows(i).Item("ELIMINA"))
                    {
                        rowDef = dttPedidoDefinitivo.NewRow;
                        rowDef("CODIGO") = dttPedidoOriginal.Rows(i).Item("CODIGO");
                        rowDef("NOMBRE") = dttPedidoOriginal.Rows(i).Item("NOMBRE");
                        rowDef("CANTIDAD") = dttPedidoOriginal.Rows(i).Item("CANTIDAD");
                        rowDef("PRECIO_UNI") = dttPedidoOriginal.Rows(i).Item("PRECIO_UNI");
                        rowDef("PRECIO_PUB") = dttPedidoOriginal.Rows(i).Item("PRECIO_PUB");
                        rowDef("PRECIO_NET") = dttPedidoOriginal.Rows(i).Item("PRECIO_NET");
                        rowDef("PRECIO_TOTAL") = dttPedidoOriginal.Rows(i).Item("PRECIO_TOTAL");
                        rowDef("TIENE_IVA") = dttPedidoOriginal.Rows(i).Item("TIENE_IVA");
                        rowDef("TIPO_REG") = dttPedidoOriginal.Rows(i).Item("TIPO_REG");
                        rowDef("ELIMINA") = dttPedidoOriginal.Rows(i).Item("ELIMINA");
                        rowDef("TIPO_PRODUCTO") = dttPedidoOriginal.Rows(i).Item("TIPO_PRODUCTO");
                        rowDef("ESCALA_DESCUENTOS") = dttPedidoOriginal.Rows(i).Item("ESCALA_DESCUENTOS");
                        rowDef("SE_LE_APLICA_ESCALA_DCTOS") = dttPedidoOriginal.Rows(i).Item("SE_LE_APLICA_ESCALA_DCTOS");
                        rowDef("ES_ACCESORIO") = dttPedidoOriginal.Rows(i).Item("ES_ACCESORIO");
                        rowDef("MONTO_PEDIDO") = dttPedidoOriginal.Rows(i).Item("MONTO_PEDIDO");
                        rowDef("ES_PRODUCTO_CRP") = dttPedidoOriginal.Rows(i).Item("ES_PRODUCTO_CRP");
                        rowDef("PORC_IVA") = dttPedidoOriginal.Rows(i).Item("PORC_IVA");
                        rowDef("VALOR_IVA") = dttPedidoOriginal.Rows(i).Item("VALOR_IVA");
                        rowDef("PORC_DESCUENTO_ESPECIAL") = dttPedidoOriginal.Rows(i).Item("PORC_DESCUENTO_ESPECIAL");
                        rowDef("VALOR_DESCUENTO_ESPECIAL") = dttPedidoOriginal.Rows(i).Item("VALOR_DESCUENTO_ESPECIAL");
                        rowDef("LISTA_PRECIOS") = dttPedidoOriginal.Rows(i).Item("LISTA_PRECIOS");
                        rowDef("SAV_LISTA_PRECIOS_PROD") = dttPedidoOriginal.Rows(i).Item("SAV_LISTA_PRECIOS_PROD");
                        rowDef("MOTIVO_VENTA") = dttPedidoOriginal.Rows(i).Item("MOTIVO_VENTA");
                        rowDef("CENTRO_GASTO") = dttPedidoOriginal.Rows(i).Item("CENTRO_GASTO");
                        rowDef("GRUPO_PRODUCTO") = dttPedidoOriginal.Rows(i).Item("GRUPO_PRODUCTO");
                        rowDef("BODEGA") = dttPedidoOriginal.Rows(i).Item("BODEGA");
                        rowDef("OFERTA_APLICADA") = dttPedidoOriginal.Rows(i).Item("OFERTA_APLICADA");
                        rowDef("ES_SALIDA") = dttPedidoOriginal.Rows(i).Item("ES_SALIDA");
                        rowDef("TIENE_FALTANTE") = dttPedidoOriginal.Rows(i).Item("TIENE_FALTANTE");
                        rowDef("CODIGO_CONCURSO") = dttPedidoOriginal.Rows(i).Item("CODIGO_CONCURSO");
                        rowDef("SUMA_VALOR_PUBLICO") = dttPedidoOriginal.Rows(i).Item("SUMA_VALOR_PUBLICO");
                        rowDef("MOTIVO_OBSEQUIO") = dttPedidoOriginal.Rows(i).Item("MOTIVO_OBSEQUIO");
                        rowDef("CENTRO_GASTO_OBSEQUIO") = dttPedidoOriginal.Rows(i).Item("CENTRO_GASTO_OBSEQUIO");
                        rowDef("PRECIO_LISTA") = dttPedidoOriginal.Rows(i).Item("PRECIO_LISTA");
                        rowDef("PORC_ESCALA_DESCUENTO") = "0";
                        rowDef("VALOR_ESCALA_UNITARIO") = "0";
                        rowDef("VALOR_ESCALA_TOTAL") = "0";
                        rowDef("SUMA_NETO") = dttPedidoOriginal.Rows(i).Item("SUMA_NETO");
                        rowDef("PUNTOS_PRODUCTO") = dttPedidoOriginal.Rows(i).Item("PUNTOS_PRODUCTO");
                        dttPedidoDefinitivo.Rows.Add(rowDef);
                        intLinea = intLinea + 1;
                    }
                }
                intValorPublicoAcumuladoAsesor = 0;
                intValorPublicoTotalCampanasParamentrizacion = 0;
                intTotalCumpleCampanas = 0;
                for (var p = 0; p <= dttPedidoDefinitivo.Rows.Count - 1; p++)
                {
                    if (dttPedidoDefinitivo.Rows(p).Item("SUMA_VALOR_PUBLICO"))
                        intValorPublicoAcumuladoAsesor = intValorPublicoAcumuladoAsesor + (dttPedidoDefinitivo.Rows(p).Item("PRECIO_PUB") * dttPedidoDefinitivo.Rows(p).Item("CANTIDAD"));
                }





                // aqui se entregan los premios al pedido de los concursos que estén activos para la campaña
                dttConcursosVentas = objconcursoVentas.getConcursos(strCodigoZonaCliente, intCodigoListaPrecios, false, intCodigoTipoCliente, intCodigoEstadoActiCliente, strConexion);
                if (dttConcursosVentas.Rows.Count > 0)
                {
                    for (var v = 0; v <= dttConcursosVentas.Rows.Count - 1; v++)
                    {
                        dclValorColchon = dttConcursosVentas.Rows(v).Item("ZON_NPORC_COLCHON");
                        intCodigoCampanaActual = objconcursoVentas.getClienteListaPrecios(strIdentificacionCliente, 2, strConexion);
                        dttValorCampanas = objconcursoVentas.getDetalleCampana(strCodigoZonaCliente, dttConcursosVentas.Rows(v).Item("CON_NID"), strConexion);

                        if (dttConcursosVentas.Rows(v).Item("CON_OVALIDA_CAMP_ACTUAL"))
                        {
                            for (var g = 0; g <= dttValorCampanas.Rows.Count - 1; g++)
                            {
                                dttValorCampanas.Rows(g).Item("CAM_ZONA_NVALOR_MONTO") = dttValorCampanas.Rows(g).Item("CAM_ZONA_NVALOR_MONTO") - (dttValorCampanas.Rows(g).Item("CAM_ZONA_NVALOR_MONTO") * (dclValorColchon / (double)100));
                                if (dttValorCampanas.Rows(g).Item("CAM_NID") == intCodigoCampanaActual)
                                    dttValorCampanas.Rows(g).Item("VALOR_PEDIDO_AS") = intValorPublicoAcumuladoAsesor;
                                else
                                {
                                    dttValorCampanas.Rows(g).Item("VALOR_PEDIDO_AS") = objconcursoVentas.getValorPublicoPedido(strIdentificacionCliente, dttValorCampanas.Rows(g).Item("CAM_NID"), strConexion);
                                    intValorPublicoAcumuladoAsesor = intValorPublicoAcumuladoAsesor + dttValorCampanas.Rows(g).Item("VALOR_PEDIDO_AS");
                                }
                            }
                        }
                        else
                            for (var g = 0; g <= dttValorCampanas.Rows.Count - 1; g++)
                            {
                                dttValorCampanas.Rows(g).Item("VALOR_PEDIDO_AS") = objconcursoVentas.getValorPublicoPedido(strIdentificacionCliente, dttValorCampanas.Rows(g).Item("CAM_NID"), strConexion);
                                intValorPublicoAcumuladoAsesor = intValorPublicoAcumuladoAsesor + dttValorCampanas.Rows(g).Item("VALOR_PEDIDO_AS");
                            }


                        blnCumplepasaPedido = true;

                        for (var b = 0; b <= dttValorCampanas.Rows.Count - 1; b++)
                        {
                            if (dttValorCampanas.Rows(b).Item("VALOR_PEDIDO_AS") <= 0)
                            {
                                blnCumplepasaPedido = false;
                                blnCumplecondCampana = false;
                            }
                        }
                        if (blnCumplepasaPedido)
                        {
                            if (dttConcursosVentas.Rows(v).Item("ES_ACUMULADO"))
                            {
                                for (var t = 0; t <= dttValorCampanas.Rows.Count - 1; t++)
                                    intValorPublicoTotalCampanasParamentrizacion = intValorPublicoTotalCampanasParamentrizacion + dttValorCampanas.Rows(t).Item("CAM_ZONA_NVALOR_MONTO");
                                if (dttConcursosVentas.Rows(v).Item("CON_OENTREGA_PREMIO_ACUMULADO"))
                                {
                                    if (intValorPublicoAcumuladoAsesor >= intValorPublicoTotalCampanasParamentrizacion)
                                    {
                                        dttDatosProductosconcurso = objconcursoVentas.getPremiosConcurso(intValorPublicoAcumuladoAsesor, dttConcursosVentas.Rows(v).Item("CON_NID"), strConexion);

                                        for (var w = 0; w <= dttDatosProductosconcurso.Rows.Count - 1; w++)
                                        {
                                            DataRow row;
                                            row = dttPedidoDefinitivo.NewRow;
                                            row("CODIGO") = dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA");
                                            row("NOMBRE") = dttDatosProductosconcurso.Rows(w).Item("PRD_CNOMBRE");
                                            row("CANTIDAD") = dttDatosProductosconcurso.Rows(w).Item("OBS_NUNIDADES_ENTREGA");
                                            DataTable dttProductoFinal = new DataTable();
                                            dttProductoFinal = objOfertas.getProductoPedidos(dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA"), intCodigoListaPrecios, strConexion);
                                            if (dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA") > 0)
                                            {
                                                row("PRECIO_NET") = 0;
                                                row("PRECIO_TOTAL") = 0;
                                                row("TIENE_IVA") = "S";
                                                row("VALOR_IVA") = 0;
                                            }
                                            else
                                            {
                                                row("PRECIO_NET") = 0;
                                                row("PRECIO_TOTAL") = 0;
                                                row("TIENE_IVA") = "N";
                                                row("VALOR_IVA") = 0;
                                            }
                                            row("SAV_LISTA_PRECIOS_PROD") = dttProductoFinal.Rows(0).Item("CODIGO");
                                            row("PRECIO_UNI") = 0;
                                            row("PRECIO_PUB") = 0;
                                            row("SUMA_VALOR_PUBLICO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_PUBLICO");
                                            row("ESCALA_DESCUENTOS") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_LLEGAR_ESCALA");
                                            row("SE_LE_APLICA_ESCALA_DCTOS") = dttProductoFinal.Rows(0).Item("LPP_OSE_APLICA_ESCALA");
                                            row("MONTO_PEDIDO") = dttProductoFinal.Rows(0).Item("LPP_OAPLICA_SUPERA_MONTO_MIN");
                                            row("ES_ACCESORIO") = dttProductoFinal.Rows(0).Item("LPP_OES_ACCESORIO");
                                            row("PORC_IVA") = dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA");
                                            row("MOTIVO_VENTA") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_VENTA");
                                            row("CENTRO_GASTO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_VENTA");
                                            row("MOTIVO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_OBSEQUIO");
                                            row("CENTRO_GASTO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_OBSEQUIO");
                                            row("TIPO_PRODUCTO") = dttProductoFinal.Rows(0).Item("TPR_CID");
                                            row("PRECIO_LISTA") = 0;
                                            row("PORC_DESCUENTO_ESPECIAL") = 0;
                                            row("VALOR_DESCUENTO_ESPECIAL") = 0;
                                            row("OFERTA_APLICADA") = true;
                                            row("ELIMINA") = false;
                                            row("PORC_ESCALA_DESCUENTO") = "0";
                                            row("VALOR_ESCALA_UNITARIO") = "0";
                                            row("VALOR_ESCALA_TOTAL") = "0";
                                            row("SUMA_NETO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_NETO");
                                            row("PUNTOS_PRODUCTO") = 0;
                                            dttPedidoDefinitivo.Rows.Add(row);
                                        }
                                    }
                                }
                                else
                                {
                                    dttDatosProductosconcurso = objconcursoVentas.getPremiosConcurso(intValorPublicoAcumuladoAsesor, dttConcursosVentas.Rows(v).Item("CON_NID"), strConexion);

                                    for (var w = 0; w <= dttDatosProductosconcurso.Rows.Count - 1; w++)
                                    {
                                        DataRow row;
                                        row = dttPedidoDefinitivo.NewRow;
                                        row("CODIGO") = dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA");
                                        row("NOMBRE") = dttDatosProductosconcurso.Rows(w).Item("PRD_CNOMBRE");
                                        row("CANTIDAD") = dttDatosProductosconcurso.Rows(w).Item("OBS_NUNIDADES_ENTREGA");
                                        DataTable dttProductoFinal = new DataTable();
                                        dttProductoFinal = objOfertas.getProductoPedidos(dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA"), intCodigoListaPrecios, strConexion);
                                        if (dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA") > 0)
                                        {
                                            row("PRECIO_NET") = 0;
                                            row("PRECIO_TOTAL") = 0;
                                            row("TIENE_IVA") = "S";
                                            row("VALOR_IVA") = 0;
                                        }
                                        else
                                        {
                                            row("PRECIO_NET") = 0;
                                            row("PRECIO_TOTAL") = 0;
                                            row("TIENE_IVA") = "N";
                                            row("VALOR_IVA") = 0;
                                        }
                                        row("SAV_LISTA_PRECIOS_PROD") = dttProductoFinal.Rows(0).Item("CODIGO");
                                        row("PRECIO_UNI") = 0;
                                        row("PRECIO_PUB") = 0;
                                        row("SUMA_VALOR_PUBLICO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_PUBLICO");
                                        row("ESCALA_DESCUENTOS") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_LLEGAR_ESCALA");
                                        row("SE_LE_APLICA_ESCALA_DCTOS") = dttProductoFinal.Rows(0).Item("LPP_OSE_APLICA_ESCALA");
                                        row("MONTO_PEDIDO") = dttProductoFinal.Rows(0).Item("LPP_OAPLICA_SUPERA_MONTO_MIN");
                                        row("ES_ACCESORIO") = dttProductoFinal.Rows(0).Item("LPP_OES_ACCESORIO");
                                        row("PORC_IVA") = dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA");
                                        row("MOTIVO_VENTA") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_VENTA");
                                        row("CENTRO_GASTO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_VENTA");
                                        row("MOTIVO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_OBSEQUIO");
                                        row("CENTRO_GASTO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_OBSEQUIO");
                                        row("TIPO_PRODUCTO") = dttProductoFinal.Rows(0).Item("TPR_CID");
                                        row("PRECIO_LISTA") = 0;
                                        row("PORC_DESCUENTO_ESPECIAL") = 0;
                                        row("VALOR_DESCUENTO_ESPECIAL") = 0;
                                        row("OFERTA_APLICADA") = true;
                                        row("ELIMINA") = false;
                                        row("PORC_ESCALA_DESCUENTO") = "0";
                                        row("VALOR_ESCALA_UNITARIO") = "0";
                                        row("VALOR_ESCALA_TOTAL") = "0";
                                        row("SUMA_NETO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_NETO");
                                        row("PUNTOS_PRODUCTO") = 0;
                                        dttPedidoDefinitivo.Rows.Add(row);
                                    }
                                }
                            }
                            else
                            {
                                for (var g = 0; g <= dttValorCampanas.Rows.Count - 1; g++)
                                {
                                    if (dttValorCampanas.Rows(g).Item("VALOR_PEDIDO_AS") >= dttValorCampanas.Rows(g).Item("CAM_ZONA_NVALOR_MONTO"))
                                        intTotalCumpleCampanas = intTotalCumpleCampanas + 1;
                                }
                                if (intTotalCumpleCampanas == dttValorCampanas.Rows.Count)
                                    blnCumplecondCampana = true;
                                else
                                    blnCumplecondCampana = false;

                                if (blnCumplecondCampana)
                                {
                                    if (dttConcursosVentas.Rows(v).Item("CON_OENTREGA_PREMIO_ACUMULADO"))
                                    {
                                        dttDatosProductosconcurso = objconcursoVentas.getPremiosConcurso(intValorPublicoAcumuladoAsesor, dttConcursosVentas.Rows(v).Item("CON_NID"), strConexion);

                                        for (var w = 0; w <= dttDatosProductosconcurso.Rows.Count - 1; w++)
                                        {
                                            DataRow row;
                                            row = dttPedidoDefinitivo.NewRow;
                                            row("CODIGO") = dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA");
                                            row("NOMBRE") = dttDatosProductosconcurso.Rows(w).Item("PRD_CNOMBRE");
                                            row("CANTIDAD") = dttDatosProductosconcurso.Rows(w).Item("OBS_NUNIDADES_ENTREGA");
                                            DataTable dttProductoFinal = new DataTable();
                                            dttProductoFinal = objOfertas.getProductoPedidos(dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA"), intCodigoListaPrecios, strConexion);
                                            if (dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA") > 0)
                                            {
                                                row("PRECIO_NET") = 0;
                                                row("PRECIO_TOTAL") = 0;
                                                row("TIENE_IVA") = "S";
                                                row("VALOR_IVA") = 0;
                                            }
                                            else
                                            {
                                                row("PRECIO_NET") = 0;
                                                row("PRECIO_TOTAL") = 0;
                                                row("TIENE_IVA") = "N";
                                                row("VALOR_IVA") = 0;
                                            }
                                            row("SAV_LISTA_PRECIOS_PROD") = dttProductoFinal.Rows(0).Item("CODIGO");
                                            row("PRECIO_UNI") = 0;
                                            row("PRECIO_PUB") = 0;
                                            row("SUMA_VALOR_PUBLICO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_PUBLICO");
                                            row("ESCALA_DESCUENTOS") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_LLEGAR_ESCALA");
                                            row("SE_LE_APLICA_ESCALA_DCTOS") = dttProductoFinal.Rows(0).Item("LPP_OSE_APLICA_ESCALA");
                                            row("MONTO_PEDIDO") = dttProductoFinal.Rows(0).Item("LPP_OAPLICA_SUPERA_MONTO_MIN");
                                            row("ES_ACCESORIO") = dttProductoFinal.Rows(0).Item("LPP_OES_ACCESORIO");
                                            row("PORC_IVA") = dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA");
                                            row("MOTIVO_VENTA") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_VENTA");
                                            row("CENTRO_GASTO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_VENTA");
                                            row("MOTIVO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_OBSEQUIO");
                                            row("CENTRO_GASTO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_OBSEQUIO");
                                            row("TIPO_PRODUCTO") = dttProductoFinal.Rows(0).Item("TPR_CID");
                                            row("PRECIO_LISTA") = 0;
                                            row("PORC_DESCUENTO_ESPECIAL") = 0;
                                            row("VALOR_DESCUENTO_ESPECIAL") = 0;
                                            row("OFERTA_APLICADA") = true;
                                            row("ELIMINA") = false;
                                            row("PORC_ESCALA_DESCUENTO") = "0";
                                            row("VALOR_ESCALA_UNITARIO") = "0";
                                            row("VALOR_ESCALA_TOTAL") = "0";
                                            row("SUMA_NETO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_NETO");
                                            row("PUNTOS_PRODUCTO") = 0;
                                            dttPedidoDefinitivo.Rows.Add(row);
                                        }
                                    }
                                    else
                                    {
                                        dttDatosProductosconcurso = objconcursoVentas.getPremiosConcurso(intValorPublicoAcumuladoAsesor, dttConcursosVentas.Rows(v).Item("CON_NID"), strConexion);

                                        for (var w = 0; w <= dttDatosProductosconcurso.Rows.Count - 1; w++)
                                        {
                                            DataRow row;
                                            row = dttPedidoDefinitivo.NewRow;
                                            row("CODIGO") = dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA");
                                            row("NOMBRE") = dttDatosProductosconcurso.Rows(w).Item("PRD_CNOMBRE");
                                            row("CANTIDAD") = dttDatosProductosconcurso.Rows(w).Item("OBS_NUNIDADES_ENTREGA");
                                            DataTable dttProductoFinal = new DataTable();
                                            dttProductoFinal = objOfertas.getProductoPedidos(dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA"), intCodigoListaPrecios, strConexion);
                                            if (dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA") > 0)
                                            {
                                                row("PRECIO_NET") = 0;
                                                row("PRECIO_TOTAL") = 0;
                                                row("TIENE_IVA") = "S";
                                                row("VALOR_IVA") = 0;
                                            }
                                            else
                                            {
                                                row("PRECIO_NET") = 0;
                                                row("PRECIO_TOTAL") = 0;
                                                row("TIENE_IVA") = "N";
                                                row("VALOR_IVA") = 0;
                                            }
                                            row("SAV_LISTA_PRECIOS_PROD") = dttProductoFinal.Rows(0).Item("CODIGO");
                                            row("PRECIO_UNI") = 0;
                                            row("PRECIO_PUB") = 0;
                                            row("SUMA_VALOR_PUBLICO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_PUBLICO");
                                            row("ESCALA_DESCUENTOS") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_LLEGAR_ESCALA");
                                            row("SE_LE_APLICA_ESCALA_DCTOS") = dttProductoFinal.Rows(0).Item("LPP_OSE_APLICA_ESCALA");
                                            row("MONTO_PEDIDO") = dttProductoFinal.Rows(0).Item("LPP_OAPLICA_SUPERA_MONTO_MIN");
                                            row("ES_ACCESORIO") = dttProductoFinal.Rows(0).Item("LPP_OES_ACCESORIO");
                                            row("PORC_IVA") = dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA");
                                            row("MOTIVO_VENTA") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_VENTA");
                                            row("CENTRO_GASTO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_VENTA");
                                            row("MOTIVO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_OBSEQUIO");
                                            row("CENTRO_GASTO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_OBSEQUIO");
                                            row("TIPO_PRODUCTO") = dttProductoFinal.Rows(0).Item("TPR_CID");
                                            row("PRECIO_LISTA") = 0;
                                            row("PORC_DESCUENTO_ESPECIAL") = 0;
                                            row("VALOR_DESCUENTO_ESPECIAL") = 0;
                                            row("OFERTA_APLICADA") = true;
                                            row("ELIMINA") = false;
                                            row("PORC_ESCALA_DESCUENTO") = "0";
                                            row("VALOR_ESCALA_UNITARIO") = "0";
                                            row("VALOR_ESCALA_TOTAL") = "0";
                                            row("SUMA_NETO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_NETO");
                                            row("PUNTOS_PRODUCTO") = 0;
                                            dttPedidoDefinitivo.Rows.Add(row);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                if (blnEsIngreso)
                {
                    dttConcursosVentas = objconcursoVentas.getConcursos(strCodigoZonaCliente, intCodigoListaPrecios, blnEsIngreso, intCodigoTipoCliente, intCodigoEstadoActiCliente, strConexion);


                    for (var v = 0; v <= dttConcursosVentas.Rows.Count - 1; v++)
                    {
                        dclValorColchon = dttConcursosVentas.Rows(v).Item("ZON_NPORC_COLCHON");
                        intCodigoCampanaActual = objconcursoVentas.getClienteListaPrecios(strIdentificacionCliente, 2, strConexion);
                        dttValorCampanas = objconcursoVentas.getDetalleCampana(strCodigoZonaCliente, dttConcursosVentas.Rows(v).Item("CON_NID"), strConexion);

                        if (dttConcursosVentas.Rows(v).Item("CON_OVALIDA_CAMP_ACTUAL"))
                        {
                            for (var g = 0; g <= dttValorCampanas.Rows.Count - 1; g++)
                            {
                                dttValorCampanas.Rows(g).Item("CAM_ZONA_NVALOR_MONTO") = dttValorCampanas.Rows(g).Item("CAM_ZONA_NVALOR_MONTO") - (dttValorCampanas.Rows(g).Item("CAM_ZONA_NVALOR_MONTO") * (dclValorColchon / (double)100));
                                if (dttValorCampanas.Rows(g).Item("CAM_NID") == intCodigoCampanaActual)
                                    dttValorCampanas.Rows(g).Item("VALOR_PEDIDO_AS") = intValorPublicoAcumuladoAsesor;
                                else
                                {
                                    dttValorCampanas.Rows(g).Item("VALOR_PEDIDO_AS") = objconcursoVentas.getValorPublicoPedido(strIdentificacionCliente, dttValorCampanas.Rows(g).Item("CAM_NID"), strConexion);
                                    intValorPublicoAcumuladoAsesor = intValorPublicoAcumuladoAsesor + dttValorCampanas.Rows(g).Item("VALOR_PEDIDO_AS");
                                }
                            }
                        }
                        else
                            for (var g = 0; g <= dttValorCampanas.Rows.Count - 1; g++)
                            {
                                dttValorCampanas.Rows(g).Item("VALOR_PEDIDO_AS") = objconcursoVentas.getValorPublicoPedido(strIdentificacionCliente, dttValorCampanas.Rows(g).Item("CAM_NID"), strConexion);
                                intValorPublicoAcumuladoAsesor = intValorPublicoAcumuladoAsesor + dttValorCampanas.Rows(g).Item("VALOR_PEDIDO_AS");
                            }


                        blnCumplepasaPedido = true;

                        for (var b = 0; b <= dttValorCampanas.Rows.Count - 1; b++)
                        {
                            if (dttValorCampanas.Rows(b).Item("VALOR_PEDIDO_AS") <= 0)
                            {
                                blnCumplepasaPedido = false;
                                blnCumplecondCampana = false;
                            }
                        }
                        if (blnCumplepasaPedido)
                        {
                            if (dttConcursosVentas.Rows(v).Item("ES_ACUMULADO"))
                            {
                                for (var t = 0; t <= dttValorCampanas.Rows.Count - 1; t++)
                                    intValorPublicoTotalCampanasParamentrizacion = intValorPublicoTotalCampanasParamentrizacion + dttValorCampanas.Rows(t).Item("CAM_ZONA_NVALOR_MONTO");
                                if (dttConcursosVentas.Rows(v).Item("CON_OENTREGA_PREMIO_ACUMULADO"))
                                {
                                    if (intValorPublicoAcumuladoAsesor >= intValorPublicoTotalCampanasParamentrizacion)
                                    {
                                        dttDatosProductosconcurso = objconcursoVentas.getPremiosConcurso(intValorPublicoAcumuladoAsesor, dttConcursosVentas.Rows(v).Item("CON_NID"), strConexion);

                                        for (var w = 0; w <= dttDatosProductosconcurso.Rows.Count - 1; w++)
                                        {
                                            DataRow row;
                                            row = dttPedidoDefinitivo.NewRow;
                                            row("CODIGO") = dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA");
                                            row("NOMBRE") = dttDatosProductosconcurso.Rows(w).Item("PRD_CNOMBRE");
                                            row("CANTIDAD") = dttDatosProductosconcurso.Rows(w).Item("OBS_NUNIDADES_ENTREGA");
                                            DataTable dttProductoFinal = new DataTable();
                                            dttProductoFinal = objOfertas.getProductoPedidos(dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA"), intCodigoListaPrecios, strConexion);
                                            if (dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA") > 0)
                                            {
                                                row("PRECIO_NET") = 0;
                                                row("PRECIO_TOTAL") = 0;
                                                row("TIENE_IVA") = "S";
                                                row("VALOR_IVA") = 0;
                                            }
                                            else
                                            {
                                                row("PRECIO_NET") = 0;
                                                row("PRECIO_TOTAL") = 0;
                                                row("TIENE_IVA") = "N";
                                                row("VALOR_IVA") = 0;
                                            }
                                            row("SAV_LISTA_PRECIOS_PROD") = dttProductoFinal.Rows(0).Item("CODIGO");
                                            row("PRECIO_UNI") = 0;
                                            row("PRECIO_PUB") = 0;
                                            row("SUMA_VALOR_PUBLICO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_PUBLICO");
                                            row("ESCALA_DESCUENTOS") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_LLEGAR_ESCALA");
                                            row("SE_LE_APLICA_ESCALA_DCTOS") = dttProductoFinal.Rows(0).Item("LPP_OSE_APLICA_ESCALA");
                                            row("MONTO_PEDIDO") = dttProductoFinal.Rows(0).Item("LPP_OAPLICA_SUPERA_MONTO_MIN");
                                            row("ES_ACCESORIO") = dttProductoFinal.Rows(0).Item("LPP_OES_ACCESORIO");
                                            row("PORC_IVA") = dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA");
                                            row("MOTIVO_VENTA") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_VENTA");
                                            row("CENTRO_GASTO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_VENTA");
                                            row("MOTIVO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_OBSEQUIO");
                                            row("CENTRO_GASTO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_OBSEQUIO");
                                            row("TIPO_PRODUCTO") = dttProductoFinal.Rows(0).Item("TPR_CID");
                                            row("PRECIO_LISTA") = 0;
                                            row("PORC_DESCUENTO_ESPECIAL") = 0;
                                            row("VALOR_DESCUENTO_ESPECIAL") = 0;
                                            row("OFERTA_APLICADA") = true;
                                            row("ELIMINA") = false;
                                            row("PORC_ESCALA_DESCUENTO") = "0";
                                            row("VALOR_ESCALA_UNITARIO") = "0";
                                            row("VALOR_ESCALA_TOTAL") = "0";
                                            row("SUMA_NETO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_NETO");
                                            row("PUNTOS_PRODUCTO") = 0;
                                            dttPedidoDefinitivo.Rows.Add(row);
                                        }
                                    }
                                }
                                else
                                {
                                    dttDatosProductosconcurso = objconcursoVentas.getPremiosConcurso(intValorPublicoAcumuladoAsesor, dttConcursosVentas.Rows(v).Item("CON_NID"), strConexion);

                                    for (var w = 0; w <= dttDatosProductosconcurso.Rows.Count - 1; w++)
                                    {
                                        DataRow row;
                                        row = dttPedidoDefinitivo.NewRow;
                                        row("CODIGO") = dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA");
                                        row("NOMBRE") = dttDatosProductosconcurso.Rows(w).Item("PRD_CNOMBRE");
                                        row("CANTIDAD") = dttDatosProductosconcurso.Rows(w).Item("OBS_NUNIDADES_ENTREGA");
                                        DataTable dttProductoFinal = new DataTable();
                                        dttProductoFinal = objOfertas.getProductoPedidos(dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA"), intCodigoListaPrecios, strConexion);
                                        if (dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA") > 0)
                                        {
                                            row("PRECIO_NET") = 0;
                                            row("PRECIO_TOTAL") = 0;
                                            row("TIENE_IVA") = "S";
                                            row("VALOR_IVA") = 0;
                                        }
                                        else
                                        {
                                            row("PRECIO_NET") = 0;
                                            row("PRECIO_TOTAL") = 0;
                                            row("TIENE_IVA") = "N";
                                            row("VALOR_IVA") = 0;
                                        }
                                        row("SAV_LISTA_PRECIOS_PROD") = dttProductoFinal.Rows(0).Item("CODIGO");
                                        row("PRECIO_UNI") = 0;
                                        row("PRECIO_PUB") = 0;
                                        row("SUMA_VALOR_PUBLICO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_PUBLICO");
                                        row("ESCALA_DESCUENTOS") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_LLEGAR_ESCALA");
                                        row("SE_LE_APLICA_ESCALA_DCTOS") = dttProductoFinal.Rows(0).Item("LPP_OSE_APLICA_ESCALA");
                                        row("MONTO_PEDIDO") = dttProductoFinal.Rows(0).Item("LPP_OAPLICA_SUPERA_MONTO_MIN");
                                        row("ES_ACCESORIO") = dttProductoFinal.Rows(0).Item("LPP_OES_ACCESORIO");
                                        row("PORC_IVA") = dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA");
                                        row("MOTIVO_VENTA") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_VENTA");
                                        row("CENTRO_GASTO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_VENTA");
                                        row("MOTIVO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_OBSEQUIO");
                                        row("CENTRO_GASTO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_OBSEQUIO");
                                        row("TIPO_PRODUCTO") = dttProductoFinal.Rows(0).Item("TPR_CID");
                                        row("PRECIO_LISTA") = 0;
                                        row("PORC_DESCUENTO_ESPECIAL") = 0;
                                        row("VALOR_DESCUENTO_ESPECIAL") = 0;
                                        row("OFERTA_APLICADA") = true;
                                        row("ELIMINA") = false;
                                        row("PORC_ESCALA_DESCUENTO") = "0";
                                        row("VALOR_ESCALA_UNITARIO") = "0";
                                        row("VALOR_ESCALA_TOTAL") = "0";
                                        row("SUMA_NETO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_NETO");
                                        row("PUNTOS_PRODUCTO") = 0;
                                        dttPedidoDefinitivo.Rows.Add(row);
                                    }
                                }
                            }
                            else
                            {
                                for (var g = 0; g <= dttValorCampanas.Rows.Count - 1; g++)
                                {
                                    if (dttValorCampanas.Rows(g).Item("VALOR_PEDIDO_AS") >= dttValorCampanas.Rows(g).Item("CAM_ZONA_NVALOR_MONTO"))
                                        intTotalCumpleCampanas = intTotalCumpleCampanas + 1;
                                }
                                if (intTotalCumpleCampanas == dttValorCampanas.Rows.Count)
                                    blnCumplecondCampana = true;
                                else
                                    blnCumplecondCampana = false;

                                if (blnCumplecondCampana)
                                {
                                    if (dttConcursosVentas.Rows(v).Item("CON_OENTREGA_PREMIO_ACUMULADO"))
                                    {
                                        dttDatosProductosconcurso = objconcursoVentas.getPremiosConcurso(intValorPublicoAcumuladoAsesor, dttConcursosVentas.Rows(v).Item("CON_NID"), strConexion);

                                        for (var w = 0; w <= dttDatosProductosconcurso.Rows.Count - 1; w++)
                                        {
                                            DataRow row;
                                            row = dttPedidoDefinitivo.NewRow;
                                            row("CODIGO") = dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA");
                                            row("NOMBRE") = dttDatosProductosconcurso.Rows(w).Item("PRD_CNOMBRE");
                                            row("CANTIDAD") = dttDatosProductosconcurso.Rows(w).Item("OBS_NUNIDADES_ENTREGA");
                                            DataTable dttProductoFinal = new DataTable();
                                            dttProductoFinal = objOfertas.getProductoPedidos(dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA"), intCodigoListaPrecios, strConexion);
                                            if (dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA") > 0)
                                            {
                                                row("PRECIO_NET") = 0;
                                                row("PRECIO_TOTAL") = 0;
                                                row("TIENE_IVA") = "S";
                                                row("VALOR_IVA") = 0;
                                            }
                                            else
                                            {
                                                row("PRECIO_NET") = 0;
                                                row("PRECIO_TOTAL") = 0;
                                                row("TIENE_IVA") = "N";
                                                row("VALOR_IVA") = 0;
                                            }
                                            row("SAV_LISTA_PRECIOS_PROD") = dttProductoFinal.Rows(0).Item("CODIGO");
                                            row("PRECIO_UNI") = 0;
                                            row("PRECIO_PUB") = 0;
                                            row("SUMA_VALOR_PUBLICO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_PUBLICO");
                                            row("ESCALA_DESCUENTOS") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_LLEGAR_ESCALA");
                                            row("SE_LE_APLICA_ESCALA_DCTOS") = dttProductoFinal.Rows(0).Item("LPP_OSE_APLICA_ESCALA");
                                            row("MONTO_PEDIDO") = dttProductoFinal.Rows(0).Item("LPP_OAPLICA_SUPERA_MONTO_MIN");
                                            row("ES_ACCESORIO") = dttProductoFinal.Rows(0).Item("LPP_OES_ACCESORIO");
                                            row("PORC_IVA") = dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA");
                                            row("MOTIVO_VENTA") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_VENTA");
                                            row("CENTRO_GASTO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_VENTA");
                                            row("MOTIVO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_OBSEQUIO");
                                            row("CENTRO_GASTO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_OBSEQUIO");
                                            row("TIPO_PRODUCTO") = dttProductoFinal.Rows(0).Item("TPR_CID");
                                            row("PRECIO_LISTA") = 0;
                                            row("PORC_DESCUENTO_ESPECIAL") = 0;
                                            row("VALOR_DESCUENTO_ESPECIAL") = 0;
                                            row("OFERTA_APLICADA") = true;
                                            row("ELIMINA") = false;
                                            row("PORC_ESCALA_DESCUENTO") = "0";
                                            row("VALOR_ESCALA_UNITARIO") = "0";
                                            row("VALOR_ESCALA_TOTAL") = "0";
                                            row("SUMA_NETO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_NETO");
                                            row("PUNTOS_PRODUCTO") = 0;
                                            dttPedidoDefinitivo.Rows.Add(row);
                                        }
                                    }
                                    else
                                    {
                                        dttDatosProductosconcurso = objconcursoVentas.getPremiosConcurso(intValorPublicoAcumuladoAsesor, dttConcursosVentas.Rows(v).Item("CON_NID"), strConexion);

                                        for (var w = 0; w <= dttDatosProductosconcurso.Rows.Count - 1; w++)
                                        {
                                            DataRow row;
                                            row = dttPedidoDefinitivo.NewRow;
                                            row("CODIGO") = dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA");
                                            row("NOMBRE") = dttDatosProductosconcurso.Rows(w).Item("PRD_CNOMBRE");
                                            row("CANTIDAD") = dttDatosProductosconcurso.Rows(w).Item("OBS_NUNIDADES_ENTREGA");
                                            DataTable dttProductoFinal = new DataTable();
                                            dttProductoFinal = objOfertas.getProductoPedidos(dttDatosProductosconcurso.Rows(w).Item("CDV_CCODIGO_VENTA"), intCodigoListaPrecios, strConexion);
                                            if (dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA") > 0)
                                            {
                                                row("PRECIO_NET") = 0;
                                                row("PRECIO_TOTAL") = 0;
                                                row("TIENE_IVA") = "S";
                                                row("VALOR_IVA") = 0;
                                            }
                                            else
                                            {
                                                row("PRECIO_NET") = 0;
                                                row("PRECIO_TOTAL") = 0;
                                                row("TIENE_IVA") = "N";
                                                row("VALOR_IVA") = 0;
                                            }
                                            row("SAV_LISTA_PRECIOS_PROD") = dttProductoFinal.Rows(0).Item("CODIGO");
                                            row("PRECIO_UNI") = 0;
                                            row("PRECIO_PUB") = 0;
                                            row("SUMA_VALOR_PUBLICO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_PUBLICO");
                                            row("ESCALA_DESCUENTOS") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_LLEGAR_ESCALA");
                                            row("SE_LE_APLICA_ESCALA_DCTOS") = dttProductoFinal.Rows(0).Item("LPP_OSE_APLICA_ESCALA");
                                            row("MONTO_PEDIDO") = dttProductoFinal.Rows(0).Item("LPP_OAPLICA_SUPERA_MONTO_MIN");
                                            row("ES_ACCESORIO") = dttProductoFinal.Rows(0).Item("LPP_OES_ACCESORIO");
                                            row("PORC_IVA") = dttProductoFinal.Rows(0).Item("LPP_NPORC_IVA");
                                            row("MOTIVO_VENTA") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_VENTA");
                                            row("CENTRO_GASTO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_VENTA");
                                            row("MOTIVO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CMOTIVO_OBSEQUIO");
                                            row("CENTRO_GASTO_OBSEQUIO") = dttProductoFinal.Rows(0).Item("PRD_CCENTRO_GASTO_OBSEQUIO");
                                            row("TIPO_PRODUCTO") = dttProductoFinal.Rows(0).Item("TPR_CID");
                                            row("PRECIO_LISTA") = 0;
                                            row("PORC_DESCUENTO_ESPECIAL") = 0;
                                            row("VALOR_DESCUENTO_ESPECIAL") = 0;
                                            row("OFERTA_APLICADA") = true;
                                            row("ELIMINA") = false;
                                            row("PORC_ESCALA_DESCUENTO") = "0";
                                            row("VALOR_ESCALA_UNITARIO") = "0";
                                            row("VALOR_ESCALA_TOTAL") = "0";
                                            row("SUMA_NETO") = dttProductoFinal.Rows(0).Item("LPP_OSUMA_VALOR_NETO");
                                            row("PUNTOS_PRODUCTO") = 0;
                                            dttPedidoDefinitivo.Rows.Add(row);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                if (blnCobraFlete)
                {
                    // aqui se adiciona el flete al pedido
                    DataTable dttValorFlete = new DataTable();
                    dttValorFlete = objOfertas.getValorFleteCiudad(intCodigoCiudadCliente, 0, 1, strConexion);
                    if (dttValorFlete.Rows.Count > 0)
                    {
                        DataTable dttFlete = new DataTable();
                        string strCodigoFlete;
                        strCodigoFlete = objOfertas.getValorVariable("FLETE", 1, strConexion);
                        dttFlete = objOfertas.getProductoPedidos(strCodigoFlete, intCodigoListaPrecios, strConexion);
                        DataRow row;
                        row = dttPedidoDefinitivo.NewRow;

                        row("CODIGO") = dttFlete.Rows(0).Item("CDV_CCODIGO_VENTA").ToString.Trim;
                        row("NOMBRE") = dttFlete.Rows(0).Item("PRD_CNOMBRE").ToString.Trim;
                        row("CANTIDAD") = 1;
                        row("PRECIO_UNI") = dttValorFlete.Rows(0).Item("VALOR FLETE");
                        row("PRECIO_PUB") = dttValorFlete.Rows(0).Item("VALOR FLETE");
                        row("SUMA_VALOR_PUBLICO") = dttFlete.Rows(0).Item("LPP_OSUMA_VALOR_PUBLICO");
                        row("ESCALA_DESCUENTOS") = dttFlete.Rows(0).Item("LPP_OSUMA_LLEGAR_ESCALA");
                        row("SE_LE_APLICA_ESCALA_DCTOS") = dttFlete.Rows(0).Item("LPP_OSE_APLICA_ESCALA");
                        row("MONTO_PEDIDO") = dttFlete.Rows(0).Item("LPP_OAPLICA_SUPERA_MONTO_MIN");
                        row("ES_ACCESORIO") = dttFlete.Rows(0).Item("LPP_OES_ACCESORIO");
                        row("PORC_IVA") = dttValorFlete.Rows(0).Item("PORC. IVA");
                        row("MOTIVO_VENTA") = dttFlete.Rows(0).Item("PRD_CMOTIVO_VENTA").ToString.Trim;
                        row("CENTRO_GASTO") = dttFlete.Rows(0).Item("PRD_CCENTRO_GASTO_VENTA").ToString.Trim;
                        row("MOTIVO_OBSEQUIO") = dttFlete.Rows(0).Item("PRD_CMOTIVO_OBSEQUIO").ToString.Trim;
                        row("CENTRO_GASTO_OBSEQUIO") = dttFlete.Rows(0).Item("PRD_CCENTRO_GASTO_OBSEQUIO").ToString.Trim;
                        row("SAV_LISTA_PRECIOS_PROD") = dttFlete.Rows(0).Item("CODIGO");
                        row("TIPO_PRODUCTO") = dttFlete.Rows(0).Item("TPR_CID");
                        row("OFERTA_APLICADA") = true;
                        row("ELIMINA") = false;
                        if (dttValorFlete.Rows(0).Item("PORC. IVA") > 0)
                        {
                            row("TIENE_IVA") = "S";
                            row("VALOR_IVA") = dttValorFlete.Rows(0).Item("VALOR FLETE") - (dttValorFlete.Rows(0).Item("VALOR FLETE") / (double)(1 + dttValorFlete.Rows(0).Item("PORC. IVA")));
                            row("PRECIO_NET") = dttValorFlete.Rows(0).Item("VALOR FLETE") / (double)(1 + dttValorFlete.Rows(0).Item("PORC. IVA"));
                            row("PRECIO_TOTAL") = row("PRECIO_NET") * row("CANTIDAD");
                        }
                        else
                        {
                            row("TIENE_IVA") = "N";
                            row("VALOR_IVA") = 0;
                            row("PRECIO_NET") = dttValorFlete.Rows(0).Item("VALOR FLETE") - (dttValorFlete.Rows(0).Item("VALOR FLETE") * dttValorFlete.Rows(0).Item("PORC. IVA"));
                            row("PRECIO_TOTAL") = row("PRECIO_NET") * row("CANTIDAD");
                        }
                        row("PORC_DESCUENTO_ESPECIAL") = "0";
                        row("VALOR_DESCUENTO_ESPECIAL") = "0";
                        row("PRECIO_LISTA") = dttValorFlete.Rows(0).Item("VALOR FLETE");
                        row("ELIMINA") = false;
                        row("PORC_ESCALA_DESCUENTO") = "0";
                        row("VALOR_ESCALA_UNITARIO") = "0";
                        row("VALOR_ESCALA_TOTAL") = "0";
                        row("SUMA_NETO") = dttValorFlete.Rows(0).Item("LPP_OSUMA_VALOR_NETO");
                        row("PUNTOS_PRODUCTO") = 0;
                        dttPedidoDefinitivo.Rows.Add(row);
                    }
                }
                // aqui se liquida la escala de descuento del pedido
                Int32 intValorPedido;
                int strValorPorcentajeAccesorio;
                strValorPorcentajeAccesorio = objOfertas.getValorVariable("ESCACCESORIO", 1, strConexion);
                for (var i = 0; i <= dttPedidoDefinitivo.Rows.Count - 1; i++)
                {
                    if (dttPedidoDefinitivo.Rows(i).Item("ESCALA_DESCUENTOS"))
                        intValorPedido = intValorPedido + (dttPedidoDefinitivo.Rows(i).Item("PRECIO_LISTA") * dttPedidoDefinitivo.Rows(i).Item("CANTIDAD"));
                }
                DataTable dttEscalaDesceunto = new DataTable();
                dttEscalaDesceunto = objOfertas.getEscala(0, intTipoCliente, intValorPedido, 2, strCodigoZonaCliente, strConexion);
                for (var i = 0; i <= dttPedidoDefinitivo.Rows.Count - 1; i++)
                {
                    if (dttPedidoDefinitivo.Rows(i).Item("ES_ACCESORIO"))
                    {
                        if (dttPedidoDefinitivo.Rows(i).Item("TIENE_IVA") == "S")
                        {
                            decimal valorIva;
                            decimal valorEscala;
                            decimal porEscala;
                            porEscala = strValorPorcentajeAccesorio / (double)100;
                            valorEscala = dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET");
                            valorEscala = valorEscala * porEscala;
                            dttPedidoDefinitivo.Rows(i).Item("VALOR_ESCALA_TOTAL") = valorEscala * dttPedidoDefinitivo.Rows(i).Item("CANTIDAD");
                            dttPedidoDefinitivo.Rows(i).Item("VALOR_ESCALA_UNITARIO") = valorEscala;
                            dttPedidoDefinitivo.Rows(i).Item("PORC_ESCALA_DESCUENTO") = strValorPorcentajeAccesorio;
                            dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET") = dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET") - valorEscala;
                            valorIva = dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET") * (1 + dttPedidoDefinitivo.Rows(i).Item("PORC_IVA"));
                            dttPedidoDefinitivo.Rows(i).Item("VALOR_IVA") = valorIva - dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET");
                        }
                        else
                        {
                            dttPedidoDefinitivo.Rows(i).Item("VALOR_ESCALA_UNITARIO") = (dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET") * strValorPorcentajeAccesorio) / (double)100;
                            dttPedidoDefinitivo.Rows(i).Item("VALOR_ESCALA_TOTAL") = dttPedidoDefinitivo.Rows(i).Item("VALOR_ESCALA_UNITARIO") * dttPedidoDefinitivo.Rows(i).Item("CANTIDAD");
                            dttPedidoDefinitivo.Rows(i).Item("PORC_ESCALA_DESCUENTO") = strValorPorcentajeAccesorio;
                            dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET") = dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET") - dttPedidoDefinitivo.Rows(i).Item("VALOR_ESCALA_UNITARIO");
                        }
                    }
                    else if (dttPedidoDefinitivo.Rows(i).Item("SE_LE_APLICA_ESCALA_DCTOS"))
                    {
                        if (dttPedidoDefinitivo.Rows(i).Item("TIENE_IVA") == "S")
                        {
                            decimal valorIva;
                            decimal valorEscala;
                            decimal porEscala;
                            porEscala = dttEscalaDesceunto.Rows(0).Item("ESC_NDESCUENTO_INICIAL") / (double)100;
                            valorEscala = dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET");
                            valorEscala = valorEscala * porEscala;
                            dttPedidoDefinitivo.Rows(i).Item("VALOR_ESCALA_TOTAL") = valorEscala * dttPedidoDefinitivo.Rows(i).Item("CANTIDAD");
                            dttPedidoDefinitivo.Rows(i).Item("VALOR_ESCALA_UNITARIO") = valorEscala;
                            dttPedidoDefinitivo.Rows(i).Item("PORC_ESCALA_DESCUENTO") = dttEscalaDesceunto.Rows(0).Item("ESC_NDESCUENTO_INICIAL");
                            dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET") = dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET") - valorEscala;
                            valorIva = dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET") * (1 + dttPedidoDefinitivo.Rows(i).Item("PORC_IVA"));
                            dttPedidoDefinitivo.Rows(i).Item("VALOR_IVA") = valorIva - dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET");
                        }
                        else
                        {
                            dttPedidoDefinitivo.Rows(i).Item("VALOR_ESCALA_UNITARIO") = (dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET") * dttEscalaDesceunto.Rows(0).Item("ESC_NDESCUENTO_INICIAL")) / (double)100;
                            dttPedidoDefinitivo.Rows(i).Item("VALOR_ESCALA_TOTAL") = dttPedidoDefinitivo.Rows(i).Item("VALOR_ESCALA_UNITARIO") * dttPedidoDefinitivo.Rows(i).Item("CANTIDAD");
                            dttPedidoDefinitivo.Rows(i).Item("PORC_ESCALA_DESCUENTO") = dttEscalaDesceunto.Rows(0).Item("ESC_NDESCUENTO_INICIAL");
                            dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET") = dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET") - dttPedidoDefinitivo.Rows(i).Item("VALOR_ESCALA_UNITARIO");
                        }
                    }
                }
                // Dim intValorDescontarNeto As Integer = 0
                // For i = 0 To dttPedidoDefinitivo.Rows.Count - 1
                // intValorDescontarNeto = dttPedidoDefinitivo.Rows(i).Item("VALOR_ESCALA_UNITARIO") + dttPedidoDefinitivo.Rows(i).Item("VALOR_DESCUENTO_ESPECIAL") + dttPedidoDefinitivo.Rows(i).Item("VALOR_IVA")
                // dttPedidoDefinitivo.Rows(i).Item("PRECIO_NET") = dttPedidoDefinitivo.Rows(i).Item("LPP_NPRECIO_LISTA") - intValorDescontarNeto
                // Next
                                              */
            return dttPedidoDefinitivo;
        }



        private List<OfertasSimples> getlistaOfertas(int intCodigoOferta, int intOpcion, int intCodigoListaPrecios, int intCodigoEstadoActicliente, string strCodigoZona)
        {
            List<OfertasSimples> PedidosOfertasSimples = new List<OfertasSimples>();
            sp_Liquidacion spRequestPedidos = new sp_Liquidacion();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getlistaOfertas("SPR_GET_OFERTA_SIMPLE", intCodigoOferta, intOpcion, intCodigoListaPrecios, intCodigoEstadoActicliente, strCodigoZona);
            PedidosOfertasSimples = data.ExecuteQueryList<OfertasSimples>(SP);
            return PedidosOfertasSimples;
        }

        private List<OfertaImpulsa> getDatosProdImpulsa(int intCodigoOferta)
        {
            List<OfertaImpulsa> PedidosOfertaImpulsa = new List<OfertaImpulsa>();
            sp_Liquidacion spRequestPedidos = new sp_Liquidacion();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getDatosProdImpulsa("SPR_GET_PROD_OFERTA_IMPULSA", intCodigoOferta);
            PedidosOfertaImpulsa = data.ExecuteQueryList<OfertaImpulsa>(SP);
            return PedidosOfertaImpulsa;
        }
        private List<ProductosAplicaOferta> getlistaProductosAplicaOferta(int intCodigoOferta)
        {
            List<ProductosAplicaOferta> PedidosProductosAplicaOferta = new List<ProductosAplicaOferta>();
            sp_Liquidacion spRequestPedidos = new sp_Liquidacion();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getDatosProdImpulsa("SPR_GET_PRODUCTO_APLICA_OFERTA", intCodigoOferta);
            PedidosProductosAplicaOferta = data.ExecuteQueryList<ProductosAplicaOferta>(SP);
            return PedidosProductosAplicaOferta;
        }

        private List<ProductoPredidoTablas> getProductoPedidos(string strCodigoVenta, int intCodigoListaPrecios)
        {
            List<ProductoPredidoTablas> PedidosProductoPredidoTablas = new List<ProductoPredidoTablas>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getProductoPedidos("SPR_GET_PRODUCTO_PEDIDO", strCodigoVenta, intCodigoListaPrecios);
            PedidosProductoPredidoTablas = data.ExecuteQueryList<ProductoPredidoTablas>(SP);
            return PedidosProductoPredidoTablas;
        }
    }
}
