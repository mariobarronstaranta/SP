using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Concretec.Pedidos.Utils;
using System.ServiceModel.Activation;

namespace Concretec.Servicios
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Unidades" in code, svc and config file together.
    public class Unidades : IUnidades
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        string Aplicacion = "Programacion de Pedidos V 2.0";
        string Servicio = "Unidades.svc";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnConcretec"].ConnectionString; }
        }

        public bool RegistraAjuste(int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento,string observaciones)
        {
            Metodo = "RegistraAjuste";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Operacion", "SET_AJUSTE");
            command.Parameters.AddWithValue("@IdTanque", IdTanque);
            command.Parameters.AddWithValue("@IdTipoMovimiento", IdTipoMovimiento);
            command.Parameters.AddWithValue("@Lectura", valor);
            command.Parameters.AddWithValue("@UA", IdUsuarioActualizacion);
            command.Parameters.AddWithValue("@Flectura", FechaMovimiento);
            command.Parameters.AddWithValue("@Observaciones", observaciones);
           

            bool salida = false;
            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool RegistraMovimientoOUT(int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, DateTime HoraMovimiento, string proveedor, int IdUnidad, int IdOperador, float horimetro, float odometro)
        {
            Metodo = "RegistraMovimientoOUT";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Operacion", "SET_SALIDA");
            command.Parameters.AddWithValue("@IdTanque", IdTanque);
            command.Parameters.AddWithValue("@IdTipoMovimiento", IdTipoMovimiento);
            command.Parameters.AddWithValue("@Lectura", valor);
            command.Parameters.AddWithValue("@UA", IdUsuarioActualizacion);
            command.Parameters.AddWithValue("@FA", FechaMovimiento);
            command.Parameters.AddWithValue("@Hlectura", HoraMovimiento);
            //
            command.Parameters.AddWithValue("@IdUnidad", IdUnidad);
            command.Parameters.AddWithValue("@IdOperador", IdOperador);
            command.Parameters.AddWithValue("@horimetro", horimetro);
            command.Parameters.AddWithValue("@odometro", odometro);

            bool salida = false;
            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool ActualizaMovimientoIN(int idmovimiento, int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, string proveedor,string referencia)
        {
            Metodo = "ActualizaMovimientoIN";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Operacion", "UPD_MOVIMIENTO_ENTRADA");
            command.Parameters.AddWithValue("@IdTanque", IdTanque);
            command.Parameters.AddWithValue("@IdTipoMovimiento", IdTipoMovimiento);
            command.Parameters.AddWithValue("@Lectura", valor);
            command.Parameters.AddWithValue("@UA", IdUsuarioActualizacion);
            command.Parameters.AddWithValue("@FA", FechaMovimiento);
            command.Parameters.AddWithValue("@Proveedor", proveedor);
            command.Parameters.AddWithValue("@Id_Movimiento", idmovimiento);
            command.Parameters.AddWithValue("@Referencia", referencia);

            bool salida = false;
            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool RegistraMovimientoIN(int IdTanque, int IdTipoMovimiento,float valor,int IdUsuarioActualizacion,DateTime FechaMovimiento,string proveedor,string referencia)
        {
            Metodo = "RegistraMovimientoIN";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Operacion", "SET_MOVIMIENTO_ENTRADA");
            command.Parameters.AddWithValue("@IdTanque", IdTanque);
            command.Parameters.AddWithValue("@IdTipoMovimiento", IdTipoMovimiento);
            command.Parameters.AddWithValue("@Lectura", valor);
            command.Parameters.AddWithValue("@UA", IdUsuarioActualizacion);
            command.Parameters.AddWithValue("@FA", FechaMovimiento);
            command.Parameters.AddWithValue("@Proveedor", proveedor);
            command.Parameters.AddWithValue("@referencia", referencia);

            bool salida = false;
            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool ActualizaLectura(int idlectura,int IdTanque, DateTime fecha, DateTime hora, float valorlectura, int idusuario)
        {
            Metodo = "ActualizaLectura";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Operacion", "UPD_LECTURA");
            command.Parameters.AddWithValue("@IdLectura", idlectura);
            command.Parameters.AddWithValue("@IdTanque", IdTanque);
            command.Parameters.AddWithValue("@Flectura", fecha);
            command.Parameters.AddWithValue("@Hlectura", hora);
            command.Parameters.AddWithValue("@Lectura", valorlectura);
            command.Parameters.AddWithValue("@UA", idusuario);

            bool salida = false;
            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool RegistraLectura(int IdTanque, DateTime fecha, DateTime hora, float valorlectura, int idusuario)
        {
            Metodo = "RegistraLectura";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Operacion", "SET_LECTURA");
            command.Parameters.AddWithValue("@IdTanque", IdTanque);
            command.Parameters.AddWithValue("@Flectura", fecha);
            command.Parameters.AddWithValue("@Hlectura", hora);
            command.Parameters.AddWithValue("@Lectura", valorlectura);
            command.Parameters.AddWithValue("@UA", idusuario);

            bool salida = false;
            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool InsertaTanque(string Operacion, int IdTanque, string IdCiudad, int IdPlanta,int IdTipoCombustible, string Nombre, double capacidad,int idusuario)
        {
            Metodo = "InsertaTanque";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Operacion", Operacion);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@IdCiudad", IdCiudad);
            command.Parameters.AddWithValue("@IdPlanta", IdPlanta);
            command.Parameters.AddWithValue("@Capacidad", capacidad);
            command.Parameters.AddWithValue("@IdTipoCombustible", IdTipoCombustible);
            command.Parameters.AddWithValue("@UA", idusuario);
            command.Parameters.AddWithValue("@IdTanque", IdTanque);
            
            bool salida = false;
            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool InsertarUnidad(
                            string CveUnidad,
                            string CveAlterna,
                            bool Borrado,
                            int? Orden,
                            int? ACCION,
                            int? IDPersonal,
                            int? IDAseguradora,
                            int? IDPlanta,
                            string Poliza,
                            string Inciso,
                            DateTime? InicioVigencia,
                            DateTime? FinVigencia,
                            int? IDMarca,
                            int? IDTipoCombustible,
                            int? IDTipoPlacas,
                            int? IDCentroCostos,
                            bool Estatus,
                            int? Modelo,
                            string Motor,
                            string NumSerie,
                            string Placas,
                            string Ubicado,
                            string Propietario,
                            DateTime? VerificacionVehicular)
        {
                                         
            Metodo = "InsertaUnidad";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertatUnidad", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDClaveUnidad",CveUnidad);
			command.Parameters.AddWithValue("@CveAlterna",CveAlterna);
            command.Parameters.AddWithValue("@Borrado", Borrado);
            command.Parameters.AddWithValue("@Orden", Orden);
            command.Parameters.AddWithValue("@ACCION", ACCION);
            command.Parameters.AddWithValue("@IDPersonal", IDPersonal);
            command.Parameters.AddWithValue("@IDAseguradora", IDAseguradora);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@Poliza", Poliza);
            command.Parameters.AddWithValue("@Inciso", Inciso);
            command.Parameters.AddWithValue("@InicioVigencia", InicioVigencia);
            command.Parameters.AddWithValue("@FinVigencia", FinVigencia);
            command.Parameters.AddWithValue("@IDMarca", IDMarca);
            command.Parameters.AddWithValue("@IDTipoCombustible", IDTipoCombustible);
            command.Parameters.AddWithValue("@IDTipoPlacas", IDTipoPlacas);
            command.Parameters.AddWithValue("@IDCentroCostos", IDCentroCostos);
            command.Parameters.AddWithValue("@Estatus", Estatus);
            command.Parameters.AddWithValue("@Modelo", Modelo);
            command.Parameters.AddWithValue("@Motor", Motor);
            command.Parameters.AddWithValue("@NumSerie", NumSerie);
            command.Parameters.AddWithValue("@Placas", Placas);
            command.Parameters.AddWithValue("@Ubicado", Ubicado);
            command.Parameters.AddWithValue("@Propietario", Propietario);
            command.Parameters.AddWithValue("@VerificacionVehicular", VerificacionVehicular);
            bool salida = false;

            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }


        public bool ActUnidad(int IDUnidad, 
                            string CveUnidad,
                            string CveAlterna,
                            bool Borrado,
                            int? Orden,
                            int? ACCION,
                            int? IDPersonal,
                            int? IDAseguradora,
                            int? IDPlanta,
                            string Poliza,
                            string Inciso,
                            DateTime? InicioVigencia,
                            DateTime? FinVigencia,
                            int? IDMarca,
                            int? IDTipoCombustible,
                            int? IDTipoPlacas,
                            int? IDCentroCostos,
                            bool Estatus,
                            int? Modelo,
                            string Motor,
                            string NumSerie,
                            string Placas,
                            string Ubicado,
                            string Propietario,
                            DateTime? VerificacionVehicular)
        {
            Metodo = "ActUnidad";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ActualizaUnidad", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDUnidad", IDUnidad);
            command.Parameters.AddWithValue("@IDClaveUnidad", CveUnidad);
            command.Parameters.AddWithValue("@CveAlterna", CveAlterna);
            command.Parameters.AddWithValue("@Borrado", Borrado);
            command.Parameters.AddWithValue("@Orden", Orden);
            command.Parameters.AddWithValue("@ACCION", ACCION);
            command.Parameters.AddWithValue("@IDPersonal", IDPersonal);
            command.Parameters.AddWithValue("@IDAseguradora", IDAseguradora);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@Poliza", Poliza);
            command.Parameters.AddWithValue("@Inciso", Inciso);
            command.Parameters.AddWithValue("@InicioVigencia", InicioVigencia);
            command.Parameters.AddWithValue("@FinVigencia", FinVigencia);
            command.Parameters.AddWithValue("@IDMarca", IDMarca);
            command.Parameters.AddWithValue("@IDTipoCombustible", IDTipoCombustible);
            command.Parameters.AddWithValue("@IDTipoPlacas", IDTipoPlacas);
            command.Parameters.AddWithValue("@IDCentroCostos", IDCentroCostos);
            command.Parameters.AddWithValue("@Estatus", Estatus);
            command.Parameters.AddWithValue("@Modelo", Modelo);
            command.Parameters.AddWithValue("@Motor", Motor);
            command.Parameters.AddWithValue("@NumSerie", NumSerie);
            command.Parameters.AddWithValue("@Placas", Placas);
            command.Parameters.AddWithValue("@Ubicado", Ubicado);
            command.Parameters.AddWithValue("@Propietario", Propietario);
            command.Parameters.AddWithValue("@VerificacionVehicular", VerificacionVehicular);
            bool salida = false;

            try
            {
                conexion.Open();
                int result = command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string ValidaExisteUnidad(string CveUnidad)
        {
            Metodo = "ValidaExisteUnidad";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ValidaExisteUnidad", conexion);
            command.Parameters.AddWithValue("@CveUnidad", CveUnidad);


            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;


            

            try
            {
                conexion.Open();


                salida = command.ExecuteScalar().ToString();
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }

        public string BuscaAjustes(int idTanque, DateTime desde, DateTime hasta)
        {
            Metodo = "BuscaAjustes";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.Parameters.AddWithValue("@Operacion", "SEL_BUSCA_AJUSTES");

            command.Parameters.AddWithValue("@IdTanque", idTanque);
            command.Parameters.AddWithValue("@desde", desde);
            command.Parameters.AddWithValue("@hasta", hasta);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }

        public string BuscaConsumos(int idTanque, DateTime desde, DateTime hasta)
        {
            Metodo = "BuscaConsumos";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.Parameters.AddWithValue("@Operacion", "SEL_BUSCA_CONSUMOS");

            command.Parameters.AddWithValue("@IdTanque", idTanque);
            command.Parameters.AddWithValue("@desde", desde);
            command.Parameters.AddWithValue("@hasta", hasta);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }

        public string BuscaSalidaCombustibles(int idmovimiento, int idtanque, DateTime desde, DateTime hasta, string cveciudad, int idunidad, int idplanta)
        {
            Metodo = "BuscaSalidaEntradaCombustibles";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.Parameters.AddWithValue("@Operacion", "SEL_MOVIMIENTO_SALIDA");

            command.Parameters.AddWithValue("@IdTanque", idtanque);
            command.Parameters.AddWithValue("@desde", desde);
            command.Parameters.AddWithValue("@hasta", hasta);
            command.Parameters.AddWithValue("@IdCiudad", cveciudad);
            command.Parameters.AddWithValue("@IdUnidad", idunidad);
            command.Parameters.AddWithValue("@IdPlanta", idplanta);
            command.Parameters.AddWithValue("@Id_Movimiento", idmovimiento);
            
            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }

        public string BuscaEntradaCombustibles(int idtanque,DateTime desde,DateTime hasta,string cveciudad,int idmovimiento)
        {
            Metodo = "BuscaEntradaCombustibles";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.Parameters.AddWithValue("@Operacion", "SEL_MOVIMIENTO_ENTRADA");
            command.Parameters.AddWithValue("@IdTanque", idtanque);
            command.Parameters.AddWithValue("@desde", desde);
            command.Parameters.AddWithValue("@hasta", hasta);
            command.Parameters.AddWithValue("@IdCiudad", cveciudad);
            command.Parameters.AddWithValue("@Id_Movimiento", idmovimiento);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }

        public string BuscaTanquesCombo(string IdCiudad)
        {
            Metodo = "BuscaTanquesCombo";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.Parameters.AddWithValue("@Operacion", "COMBO");
            command.Parameters.AddWithValue("@IdCiudad", IdCiudad);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }

        public string BuscaTanques(int IdTanque, string IdCiudad, int IdTipoCombustible, string Nombre)
        {
            Metodo = "BuscaTanques";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.Parameters.AddWithValue("@Operacion", "SEL");
            command.Parameters.AddWithValue("@IdTanque", IdTanque);
            command.Parameters.AddWithValue("@IdCiudad", IdCiudad);
            command.Parameters.AddWithValue("@IdTipoCombustible", IdTipoCombustible);
            command.Parameters.AddWithValue("@Nombre", Nombre);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }


        public string BuscaUnidadesLibres(int idPlanta, int TipoViaje, DateTime FechaViaje, string HoraInicio, string HoraFin)
        {
            Metodo = "BuscaUnidadesLibres";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BUSCAUNIDADESLIBRES", conexion);
            command.Parameters.AddWithValue("@idPlanta", idPlanta);
            command.Parameters.AddWithValue("@TipoViaje", TipoViaje);
            command.Parameters.AddWithValue("@FechaViaje", FechaViaje);
            command.Parameters.AddWithValue("@HoraInicio", HoraInicio);
            command.Parameters.AddWithValue("@HoraFin", HoraFin);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }

        public string ValidaUnidadLibre(string Fecha, string Hora, int IdPlanta)
        {
            Metodo = "ValidaUnidadLibre";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ValidaUnidadLibre", conexion);
            command.Parameters.AddWithValue("@Fecha", Fecha);
            command.Parameters.AddWithValue("@Hora", Hora);
            command.Parameters.AddWithValue("@IdPlanta", IdPlanta);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }

        public string ObtenerBombasOcupadas(string CveCiudad, DateTime FechaPedido)
        {
            Metodo = "ObtenerBombasOcupadas";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerBombasOcupadas", conexion);
            command.Parameters.AddWithValue("@CVECIUDAD", CveCiudad);
            command.Parameters.AddWithValue("@FECHAPEDIDO", FechaPedido);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }

        public string ObtenerUnidadesOcupadas(string CveCiudad, DateTime FechaPedido)
        {
            Metodo = "ObtenerUnidadesOcupadas";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerUnidadesOcupadas", conexion);
            command.Parameters.AddWithValue("@CVECIUDAD", CveCiudad);
            command.Parameters.AddWithValue("@FECHAPEDIDO", FechaPedido);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }

        public string ObtenerUnidadesLibres(string CveCiudad, DateTime FechaPedido, DateTime FechaHoraPedido,int IDPlantaPadre)
        {
            Metodo = "ObtenerUnidadesLibres";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerUnidadesLibres", conexion);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@FechaPedido", FechaPedido);
            command.Parameters.AddWithValue("@FechaHoraPedido", FechaHoraPedido);
            command.Parameters.AddWithValue("@PlantaPadre", IDPlantaPadre);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }


        public string ObtenerUnidadesClave(string Filtro)
        {
            Metodo = "ObtenerUnidadesClave";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerUnidadesClave", conexion);
            command.Parameters.AddWithValue("@Clave", Filtro);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }

        public string ObtenerUnidadesFiltro(string Filtro, string planta, string CveCiudad)
        {
            Metodo = "ObtenerUnidadesFiltro";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerUnidadesFiltro", conexion);
            command.Parameters.AddWithValue("@Filtro", Filtro);
            command.Parameters.AddWithValue("@Planta", planta);
            command.Parameters.AddWithValue("@Ciudad", CveCiudad);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }

        public string ObtenerBombas()
        {
            Metodo = "ObtenerBombas";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerUnidadesBombas", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }

        public string BuscaLecturaEdicion(int IdLectura)
        {
            Metodo = "BuscaLecturaEdicion";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.Parameters.AddWithValue("@Operacion", "SEL_LECTURA_EDICION");
            command.Parameters.AddWithValue("@IdLectura", IdLectura);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }


        public string BuscaLecturas(string IdCiudad, int IdTanque, DateTime finicial, DateTime ffinal)
        {
            Metodo = "BuscaLecturas";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.Parameters.AddWithValue("@Operacion", "SEL_LECTURAS");
            command.Parameters.AddWithValue("@IdCiudad", IdCiudad);
            command.Parameters.AddWithValue("@IdTanque", IdTanque);
            command.Parameters.AddWithValue("@desde", finicial);
            command.Parameters.AddWithValue("@hasta", ffinal);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }

        public string ObtenerUnidades()
        {
            Metodo = "ObtenerUnidades";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerUnidades", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }


        public string ObtenerCentroCostos()
        {
            Metodo = "ObtenerCentroCostros";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerCentroCostos", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;
        }


        public string ObtenerAseguradoras()
        {
            Metodo = "ObetenerAseguradoras";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerAseguradoras", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            string salida = string.Empty;
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            return salida;

        }

        public string ObtenerTipoPlaca()
        {
            Metodo = "ObetenerTipoPlaca";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerTipoPlacas", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            string salida = string.Empty;

            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string ObtenerTipoCombustible()
        {
            Metodo = "ObtenerTipoCombustible";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerTipoCombustible", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            string salida = string.Empty;

            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    salida = dr.GetString(0);
                }
                command.Dispose();
                dr.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); 
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

    }
}
