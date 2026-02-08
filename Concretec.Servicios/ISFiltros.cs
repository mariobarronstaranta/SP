using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Concretec.Servicios
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISFiltros" in both code and config file together.
    [ServiceContract]
    public interface ISFiltros
    {
        [OperationContract]
        string LlenaCombos(string TipoCombo, string CveCiudad, string Parametro1, string Parametro2, string Parametro3); 
    }
}
