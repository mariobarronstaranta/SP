using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Concretec.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IConfiguracion" in both code and config file together.
    [ServiceContract]
    public interface IConfiguracion
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        bool ActualizaParametro(string IDParametro, string Valor, string Descripcion);
    }
}
