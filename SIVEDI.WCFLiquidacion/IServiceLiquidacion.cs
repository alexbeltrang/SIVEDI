using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SIVEDI.WCFLiquidacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceLiquidacion" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceLiquidacion
    {
        [OperationContract]
        void DoWork();
    }
}
