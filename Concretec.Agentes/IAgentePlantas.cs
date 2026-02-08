using System.Collections.Generic;
using Concretec.Pedidos.BE;

namespace Concretec.Agentes
{
    public interface IAgentePlantas
    {
        bool ActPlanta(int IDPlanta, string Nombre, string CveDosificadora, bool Estatus, string Telefono, string Telefono2, string IDCiudad, string Calle, string NumInt, string NumExt, int Accion, string Colonia, string Municipio, int IDJefePlanta, string CvePlanta, int IDPlantaAlterna1, int IDPlantaAlterna2);
        List<Planta> ConsultaPlanta(int IdPlanta);
        bool InsertarPlanta(int IDPlanta, string Nombre, string CveDosificadora, bool Estatus, string Telefono, string Telefono2, string IDCiudad, string Calle, string NumInt, string NumExt, int Accion, string Colonia, string Municipio, int IDJefePlanta, string CvePlanta, int IDPlantaAlterna1, int IDPlantaAlterna2);
        List<Planta> ObtenerPlantas();
        List<Planta> ObtenerPlantasBombeo();
        List<Planta> ObtenerPlantasCiudad(string CveCiudad);
        List<Planta> ObtenerPlantasFiltro(string nombre, string cveDosificadora, string CveCiudad);
        List<Planta> ObtenerPlantasObra(string CveCiudad);
    }
}