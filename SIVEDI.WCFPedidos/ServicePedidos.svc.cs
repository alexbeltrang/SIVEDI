﻿using SIVEDI.Clases;
using SIVEDI.Clases.TABLAS;
using SIVEDI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SIVEDI.WCFPedidos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicePedidos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicePedidos.svc o ServicePedidos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicePedidos : IServicePedidos
    {
        #region Cuentas
        public List<PedidosClienteTabla> getConsultaPedidosCliente(int intCodigoCliente)
        {
            List<PedidosClienteTabla> PedidosClienteTablaTabla = new List<PedidosClienteTabla>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getConsultaPedidosCliente("SPR_GET_PEDIDO_CLIENTE", intCodigoCliente);
            PedidosClienteTablaTabla = data.ExecuteQueryList<PedidosClienteTabla>(SP);
            return PedidosClienteTablaTabla;
        }

        #endregion

        #region ListaPrecios

        public List<ListaPreciosTabla> getListaPreciosTabla(int intOpcion, int intCodigoListaPrecios)
        {
            List<ListaPreciosTabla> PedidosListaPreciosTabla = new List<ListaPreciosTabla>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getListaPrecios("SPR_GET_LISTA_PRECIOS", intOpcion, intCodigoListaPrecios);
            PedidosListaPreciosTabla = data.ExecuteQueryList<ListaPreciosTabla>(SP);
            return PedidosListaPreciosTabla;
        }

        public List<ListaPreciosProductoComboBox> getlistaPreciosProd(int intOpcion, int intCodigoProducto, int intCodigoListaPrecio)
        {
            List<ListaPreciosProductoComboBox> PedidosListaPreciosProductoComboBox = new List<ListaPreciosProductoComboBox>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getlistaPreciosProd("SPR_GET_LISTA_PRECIOS_PRODUCTO", intOpcion, intCodigoProducto, intCodigoListaPrecio);
            PedidosListaPreciosProductoComboBox = data.ExecuteQueryList<ListaPreciosProductoComboBox>(SP);
            return PedidosListaPreciosProductoComboBox;
        }

        public List<ListaPreciosProducto> getlistaPreciosProdExporta(int intOpcion, int intCodigoProducto, int intCodigoListaPrecio)
        {
            List<ListaPreciosProducto> PedidosListaPreciosProducto = new List<ListaPreciosProducto>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getlistaPreciosProd("SPR_GET_LISTA_PRECIOS_PRODUCTO", intOpcion, intCodigoProducto, intCodigoListaPrecio);
            PedidosListaPreciosProducto = data.ExecuteQueryList<ListaPreciosProducto>(SP);
            return PedidosListaPreciosProducto;
        }
        public List<ListaPreciosProducto> getProductoNombreLista(string strNombreProducto, int intCodigoListaPrecios)
        {
            List<ListaPreciosProducto> PedidosListaPreciosProducto = new List<ListaPreciosProducto>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getProductoNombreLista("SPR_GET_LISTA_PRECIOS_PRODUCTO_NOMBRE", strNombreProducto, intCodigoListaPrecios);
            PedidosListaPreciosProducto = data.ExecuteQueryList<ListaPreciosProducto>(SP);
            return PedidosListaPreciosProducto;
        }

        public List<ListaPreciosCampana> getListaPreciosXcampana(int intCodigoCampana)
        {
            List<ListaPreciosCampana> PedidosListaPreciosCampana = new List<ListaPreciosCampana>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getListaPreciosXcampana("SPR_GET_LISTA_PRECIOS_X_CAMPANA", intCodigoCampana);
            PedidosListaPreciosCampana = data.ExecuteQueryList<ListaPreciosCampana>(SP);
            return PedidosListaPreciosCampana;
        }

        public List<ListaPreciosProducto> getProductoNombreListaProd(string strNombreProducto, int intCodigoListaPrecios)
        {
            List<ListaPreciosProducto> PedidosListaPreciosProducto = new List<ListaPreciosProducto>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getProductoNombreLista("SPR_GET_PRODUCTO_NOMBRE_LISTA", strNombreProducto, intCodigoListaPrecios);
            PedidosListaPreciosProducto = data.ExecuteQueryList<ListaPreciosProducto>(SP);
            return PedidosListaPreciosProducto;
        }

        public List<AsignaCodigoVenta> getProductoNombre(string strReferencia, string strNombreProducto)
        {
            List<AsignaCodigoVenta> AsignaCodigoVenta = new List<AsignaCodigoVenta>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getProductoNombre("SPR_GET_PRODUCTO_NOMBRE", strReferencia, strNombreProducto);
            AsignaCodigoVenta = data.ExecuteQueryList<AsignaCodigoVenta>(SP);
            return AsignaCodigoVenta;
        }

        public List<CodigoVentaTabla> getCodigoVenta(int intOpcion, int intCodigoProducto)
        {
            List<CodigoVentaTabla> CodigoVenta = new List<CodigoVentaTabla>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getCodigoVenta("SPR_GET_CODIGO_VENTA", intOpcion, intCodigoProducto);
            CodigoVenta = data.ExecuteQueryList<CodigoVentaTabla>(SP);
            return CodigoVenta;
        }

        public int insListaPrecios(ListaPrecios listaPrecios)
        {
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestPedidos.insListaPrecios("SPR_IU_LISTA_PRECIOS", listaPrecios);
            int codigoLista = data.ExecuteInsert(SP, "PO_NRESULT");
            return codigoLista;
        }

        public int iuListaPreciosProducto(ProductoListaPrecio productoListaPrecio)
        {
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestPedidos.iuListaPreciosProducto("SPR_IU_PROD_LISTA_PRECIO", productoListaPrecio);
            int codigoProductoLista = data.ExecuteInsert(SP, "PO_NRESULT");
            return codigoProductoLista;
        }

        public int updPreciosProdcuto(ProductoListaPrecio productoListaPrecio)
        {
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestPedidos.updPreciosProdcuto("SPR_UPD_CONDICION_PRODUCTO", productoListaPrecio);
            int codigoProductoLista = data.ExecuteInsert(SP, "PO_NRESULT");
            return codigoProductoLista;
        }

        public int DelCodigoListaPreciosProd(int intCodigoVenta)
        {
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestPedidos.DelCodigoListaPreciosProd("SPR_DEL_ASIGNACION_LISTA_PRECIO_PROD", intCodigoVenta);
            int codigoProductoLista = data.ExecuteUD(SP);
            return codigoProductoLista;
        }

        public int DelCodigoVenta(int intCodigoVenta)
        {
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestPedidos.DelCodigoVenta("SPR_DEL_CODIGO_VENTA", intCodigoVenta);
            int codigoProductoLista = data.ExecuteUD(SP);
            return codigoProductoLista;
        }


        public int iuCodigoVenta(CodigoVenta codigoVenta)
        {
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");

            StoreProcedure SP = spRequestPedidos.iuCodigoVenta("SPR_IU_CODIGO_VENTA", codigoVenta);
            int codigoProductoLista = data.ExecuteInsert(SP, "PO_NRESULT");
            return codigoProductoLista;
        }

        public List<EquivalenciasTabla> getEquivalencias(int intOpcion, int intCodigoEquivalencia, String strCodigoSolicita)
        {
            List<EquivalenciasTabla> PedidosEquivalenciasTabla = new List<EquivalenciasTabla>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getEquivalencias("SPR_GET_EQUIVALENCIAS", intOpcion, intCodigoEquivalencia, strCodigoSolicita);
            PedidosEquivalenciasTabla = data.ExecuteQueryList<EquivalenciasTabla>(SP);
            return PedidosEquivalenciasTabla;
        }

        public List<CombosTabla> getCombos(int intOpcion, int intCodigoCombo, string strCodigoVenta, int intCodigoListaPrecios)
        {
            List<CombosTabla> PedidosCombosTabla = new List<CombosTabla>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getCombos("SPR_GET_COMBO", intOpcion, intCodigoCombo, strCodigoVenta, intCodigoListaPrecios);
            PedidosCombosTabla = data.ExecuteQueryList<CombosTabla>(SP);
            return PedidosCombosTabla;
        }

        public List<ProductosCombo> getProductoCombos(int intCodigoCombo)
        {
            List<ProductosCombo> PedidosProductosCombo = new List<ProductosCombo>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getProductoCombos("SPR_GET_PRODUCTO_COMBO", intCodigoCombo);
            PedidosProductosCombo = data.ExecuteQueryList<ProductosCombo>(SP);
            return PedidosProductosCombo;
        }

        public List<ProductoPredidoTablas> getProductoPedidos(string strCodigoVenta, int intCodigoListaPrecios)
        {
            List<ProductoPredidoTablas> PedidosProductoPredidoTablas = new List<ProductoPredidoTablas>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getProductoPedidos("SPR_GET_PRODUCTO_PEDIDO", strCodigoVenta, intCodigoListaPrecios);
            PedidosProductoPredidoTablas = data.ExecuteQueryList<ProductoPredidoTablas>(SP);
            return PedidosProductoPredidoTablas;
        }

        public List<Cliente_pedido> getClientePedido(string strIdentificacion)
        {
            List<Cliente_pedido> PedidosCliente_pedido = new List<Cliente_pedido>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getClientePedido("SPR_GET_CLIENTE_PEDIDO", strIdentificacion);
            PedidosCliente_pedido = data.ExecuteQueryList<Cliente_pedido>(SP);
            return PedidosCliente_pedido;
        }

        public List<ClienteListaPrecios> getClienteListaPrecios(int intOpcion, string strIdentificacion)
        {
            List<ClienteListaPrecios> PedidosClienteListaPrecios = new List<ClienteListaPrecios>();
            sp_Pedidos spRequestPedidos = new sp_Pedidos();
            DataDB data = new DataDB("SIVEDIBDEntities");
            StoreProcedure SP = spRequestPedidos.getClienteListaPrecios("SPR_GET_CAMPANA_CLIENTE", intOpcion, strIdentificacion);
            PedidosClienteListaPrecios = data.ExecuteQueryList<ClienteListaPrecios>(SP);
            return PedidosClienteListaPrecios;
        }

        
        #endregion
    }
}
