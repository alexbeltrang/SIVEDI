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
    }
}
