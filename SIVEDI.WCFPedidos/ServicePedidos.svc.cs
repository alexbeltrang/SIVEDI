using SIVEDI.Clases;
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
            StoreProcedure SP = spRequestPedidos.getListaPrecios("SPR_GET_LISTA_PRECIOS",intOpcion, intCodigoListaPrecios);
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
        #endregion
    }
}
