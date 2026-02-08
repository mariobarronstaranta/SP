namespace Concretec.Pedidos.BC
{
    public interface IPlantas
    {
        string ConsultaPlanta(int IdPlanta);
        string LeerPlantasObras(string CveCiudad);
        string ObtenerPlantasCiudad(string CveCiudad);
        string ObtenerPlantasBombeo();
        string ObtenerPlantas();
        string ObtenerPlantasFiltro(string Nombre, string CveDosificadora, string CveCiudad);
        bool InsertarPlanta(int IDPlanta, string Nombre, string CveDosificadora, bool Estatus, string Telefono, string Telefono2, string IDCiudad, string Calle, string NumInt, string NumExt, int Accion, string Colonia, string Municipio, int IDJefePlanta, string CvePlanta, int IDPlantaAlterna1, int IDPlantaAlterna2);
    }
}