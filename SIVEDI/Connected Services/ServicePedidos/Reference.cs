﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIVEDI.ServicePedidos {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicePedidos.IServicePedidos")]
    public interface IServicePedidos {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePedidos/getConsultaPedidosCliente", ReplyAction="http://tempuri.org/IServicePedidos/getConsultaPedidosClienteResponse")]
        SIVEDI.Clases.TABLAS.PedidosClienteTabla[] getConsultaPedidosCliente(int intCodigoCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePedidos/getConsultaPedidosCliente", ReplyAction="http://tempuri.org/IServicePedidos/getConsultaPedidosClienteResponse")]
        System.Threading.Tasks.Task<SIVEDI.Clases.TABLAS.PedidosClienteTabla[]> getConsultaPedidosClienteAsync(int intCodigoCliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePedidos/getListaPreciosTabla", ReplyAction="http://tempuri.org/IServicePedidos/getListaPreciosTablaResponse")]
        SIVEDI.Clases.TABLAS.ListaPreciosTabla[] getListaPreciosTabla(int intOpcion, int intCodigoListaPrecios);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePedidos/getListaPreciosTabla", ReplyAction="http://tempuri.org/IServicePedidos/getListaPreciosTablaResponse")]
        System.Threading.Tasks.Task<SIVEDI.Clases.TABLAS.ListaPreciosTabla[]> getListaPreciosTablaAsync(int intOpcion, int intCodigoListaPrecios);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePedidos/insListaPrecios", ReplyAction="http://tempuri.org/IServicePedidos/insListaPreciosResponse")]
        int insListaPrecios(SIVEDI.Clases.ListaPrecios listaPrecios);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePedidos/insListaPrecios", ReplyAction="http://tempuri.org/IServicePedidos/insListaPreciosResponse")]
        System.Threading.Tasks.Task<int> insListaPreciosAsync(SIVEDI.Clases.ListaPrecios listaPrecios);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePedidos/getlistaPreciosProd", ReplyAction="http://tempuri.org/IServicePedidos/getlistaPreciosProdResponse")]
        SIVEDI.Clases.TABLAS.ListaPreciosProductoComboBox[] getlistaPreciosProd(int intOpcion, int intCodigoProducto, int intCodigoListaPrecio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePedidos/getlistaPreciosProd", ReplyAction="http://tempuri.org/IServicePedidos/getlistaPreciosProdResponse")]
        System.Threading.Tasks.Task<SIVEDI.Clases.TABLAS.ListaPreciosProductoComboBox[]> getlistaPreciosProdAsync(int intOpcion, int intCodigoProducto, int intCodigoListaPrecio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePedidos/iuListaPreciosProducto", ReplyAction="http://tempuri.org/IServicePedidos/iuListaPreciosProductoResponse")]
        int iuListaPreciosProducto(SIVEDI.Clases.ProductoListaPrecio productoListaPrecio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePedidos/iuListaPreciosProducto", ReplyAction="http://tempuri.org/IServicePedidos/iuListaPreciosProductoResponse")]
        System.Threading.Tasks.Task<int> iuListaPreciosProductoAsync(SIVEDI.Clases.ProductoListaPrecio productoListaPrecio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePedidos/getlistaPreciosProdExporta", ReplyAction="http://tempuri.org/IServicePedidos/getlistaPreciosProdExportaResponse")]
        SIVEDI.Clases.TABLAS.ListaPreciosProducto[] getlistaPreciosProdExporta(int intOpcion, int intCodigoProducto, int intCodigoListaPrecio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicePedidos/getlistaPreciosProdExporta", ReplyAction="http://tempuri.org/IServicePedidos/getlistaPreciosProdExportaResponse")]
        System.Threading.Tasks.Task<SIVEDI.Clases.TABLAS.ListaPreciosProducto[]> getlistaPreciosProdExportaAsync(int intOpcion, int intCodigoProducto, int intCodigoListaPrecio);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicePedidosChannel : SIVEDI.ServicePedidos.IServicePedidos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicePedidosClient : System.ServiceModel.ClientBase<SIVEDI.ServicePedidos.IServicePedidos>, SIVEDI.ServicePedidos.IServicePedidos {
        
        public ServicePedidosClient() {
        }
        
        public ServicePedidosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicePedidosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicePedidosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicePedidosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SIVEDI.Clases.TABLAS.PedidosClienteTabla[] getConsultaPedidosCliente(int intCodigoCliente) {
            return base.Channel.getConsultaPedidosCliente(intCodigoCliente);
        }
        
        public System.Threading.Tasks.Task<SIVEDI.Clases.TABLAS.PedidosClienteTabla[]> getConsultaPedidosClienteAsync(int intCodigoCliente) {
            return base.Channel.getConsultaPedidosClienteAsync(intCodigoCliente);
        }
        
        public SIVEDI.Clases.TABLAS.ListaPreciosTabla[] getListaPreciosTabla(int intOpcion, int intCodigoListaPrecios) {
            return base.Channel.getListaPreciosTabla(intOpcion, intCodigoListaPrecios);
        }
        
        public System.Threading.Tasks.Task<SIVEDI.Clases.TABLAS.ListaPreciosTabla[]> getListaPreciosTablaAsync(int intOpcion, int intCodigoListaPrecios) {
            return base.Channel.getListaPreciosTablaAsync(intOpcion, intCodigoListaPrecios);
        }
        
        public int insListaPrecios(SIVEDI.Clases.ListaPrecios listaPrecios) {
            return base.Channel.insListaPrecios(listaPrecios);
        }
        
        public System.Threading.Tasks.Task<int> insListaPreciosAsync(SIVEDI.Clases.ListaPrecios listaPrecios) {
            return base.Channel.insListaPreciosAsync(listaPrecios);
        }
        
        public SIVEDI.Clases.TABLAS.ListaPreciosProductoComboBox[] getlistaPreciosProd(int intOpcion, int intCodigoProducto, int intCodigoListaPrecio) {
            return base.Channel.getlistaPreciosProd(intOpcion, intCodigoProducto, intCodigoListaPrecio);
        }
        
        public System.Threading.Tasks.Task<SIVEDI.Clases.TABLAS.ListaPreciosProductoComboBox[]> getlistaPreciosProdAsync(int intOpcion, int intCodigoProducto, int intCodigoListaPrecio) {
            return base.Channel.getlistaPreciosProdAsync(intOpcion, intCodigoProducto, intCodigoListaPrecio);
        }
        
        public int iuListaPreciosProducto(SIVEDI.Clases.ProductoListaPrecio productoListaPrecio) {
            return base.Channel.iuListaPreciosProducto(productoListaPrecio);
        }
        
        public System.Threading.Tasks.Task<int> iuListaPreciosProductoAsync(SIVEDI.Clases.ProductoListaPrecio productoListaPrecio) {
            return base.Channel.iuListaPreciosProductoAsync(productoListaPrecio);
        }
        
        public SIVEDI.Clases.TABLAS.ListaPreciosProducto[] getlistaPreciosProdExporta(int intOpcion, int intCodigoProducto, int intCodigoListaPrecio) {
            return base.Channel.getlistaPreciosProdExporta(intOpcion, intCodigoProducto, intCodigoListaPrecio);
        }
        
        public System.Threading.Tasks.Task<SIVEDI.Clases.TABLAS.ListaPreciosProducto[]> getlistaPreciosProdExportaAsync(int intOpcion, int intCodigoProducto, int intCodigoListaPrecio) {
            return base.Channel.getlistaPreciosProdExportaAsync(intOpcion, intCodigoProducto, intCodigoListaPrecio);
        }
    }
}
