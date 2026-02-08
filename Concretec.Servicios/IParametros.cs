using System.ServiceModel;

namespace Concretec.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IParametros" in both code and config file together.
    [ServiceContract]
    public interface IParametros
    {
        [OperationContract]
        bool ActualizaParametro(int IDParametro,string Valor, string Descripcion);

        [OperationContract]
        string LlenaCombos(string TipoCombo, string CveCiudad, string Parametro1, string Parametro2, string Parametro3); 
    }
}
