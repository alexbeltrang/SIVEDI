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
    }
}
