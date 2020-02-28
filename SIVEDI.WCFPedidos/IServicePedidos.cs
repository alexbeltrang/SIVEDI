using SIVEDI.Clases;
using SIVEDI.Clases.TABLAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SIVEDI.WCFPedidos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicePedidos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicePedidos
    {
        [OperationContract]
        List<PedidosClienteTabla> getConsultaPedidosCliente(int intCodigoCliente);
        [OperationContract]
        List<ListaPreciosTabla> getListaPreciosTabla(int intOpcion, int intCodigoListaPrecios);
        [OperationContract]
        int insListaPrecios(ListaPrecios listaPrecios);
        [OperationContract]
        List<ListaPreciosProductoComboBox> getlistaPreciosProd(int intOpcion, int intCodigoProducto, int intCodigoListaPrecio);
        [OperationContract]
        int iuListaPreciosProducto(ProductoListaPrecio productoListaPrecio);
        [OperationContract]
        List<ListaPreciosProducto> getlistaPreciosProdExporta(int intOpcion, int intCodigoProducto, int intCodigoListaPrecio);
        [OperationContract]
        List<ListaPreciosProducto> getProductoNombreLista(string strNombreProducto, int intCodigoListaPrecios);
        [OperationContract]
        List<ListaPreciosProducto> getProductoNombreListaProd(string strNombreProducto, int intCodigoListaPrecios);
        [OperationContract]
        int updPreciosProdcuto(ProductoListaPrecio productoListaPrecio);
        [OperationContract]
        int DelCodigoListaPreciosProd(int intCodigoVenta);
        [OperationContract]
        List<AsignaCodigoVenta> getProductoNombre(string strReferencia, string strNombreProducto);
        [OperationContract]
        List<CodigoVentaTabla> getCodigoVenta(int intOpcion, int intCodigoProducto);
        [OperationContract]
        int DelCodigoVenta(int intCodigoVenta);
        [OperationContract]
        int iuCodigoVenta(CodigoVenta codigoVenta);
        [OperationContract]
        List<EquivalenciasTabla> getEquivalencias(int intOpcion, int intCodigoEquivalencia, String strCodigoSolicita);
        [OperationContract]
        List<CombosTabla> getCombos(int intOpcion, int intCodigoCombo, string strCodigoVenta, int intCodigoListaPrecios);
        [OperationContract]
        List<ProductoPredidoTablas> getProductoPedidos(string strCodigoVenta, int intCodigoListaPrecios);
        [OperationContract]
        List<Cliente_pedido> getClientePedido(string strIdentificacion);
        [OperationContract]
        List<ClienteListaPrecios> getClienteListaPrecios(int intOpcion, string strIdentificacion);
        [OperationContract]
        List<ProductosCombo> getProductoCombos(int intCodigoCombo);
        [OperationContract]
        List<ListaPreciosCampana> getListaPreciosXcampana(int intCodigoCampana);


    }
}
