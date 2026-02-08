using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Concretec.Pedidos.Utils;
using Concretec.Pedidos.BE;
using System.Configuration;
using System.IO;

namespace Concretec.Pedidos.BC
{
    public class Unidades : IUnidades

    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "BC Unidades.cs";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.AppSettings["conexion"].ToString(); }
        }

        public

        bool InsertaPlaneacionUnidadPlantaDetalle(PlaneacionUnidadPlantaDetalle unidades)
        {
            Metodo = "InsertaPlaneacionUnidadPlantaDetalle";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertaPlaneacionUnidadPlantaDetalle", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@EstatusId", unidades.EstatusId);
            command.Parameters.AddWithValue("@EstatusUnidadId", unidades.EstatusUnidadId);
            command.Parameters.AddWithValue("@FechaActualizacion", unidades.FechaActualizacion);
            command.Parameters.AddWithValue("@FechaRegistro", unidades.FechaRegistro);
            command.Parameters.AddWithValue("@MotivoInactivoOperador", unidades.MotivoInactivoOperador);
            command.Parameters.AddWithValue("@MotivoInactivoUnidad", unidades.MotivoInactivoUnidad);
            command.Parameters.AddWithValue("@OperadorIdAsignado", unidades.OperadorIdAsignado);
            command.Parameters.AddWithValue("@OperadorIdOriginal", unidades.OperadorIdOriginal);
            command.Parameters.AddWithValue("@PlaneacionId", unidades.PlaneacionId);
            command.Parameters.AddWithValue("@PlantaOrigenId", unidades.PlantaOrigenId);
            command.Parameters.AddWithValue("@UnidadId", unidades.UnidadId);
            command.Parameters.AddWithValue("@UsuarioIdActualizacion", unidades.UsuarioIdActualizacion);
            command.Parameters.AddWithValue("@UsuarioIdRegistro", unidades.UsuarioIdRegistro);

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

        public bool InsertaPlaneacionUnidad(ConsultaUnidad unidad_upd)
        {
            Metodo = "InsertaPlaneacionUnidad";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertaMovimientoDiarioUnidad", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDUnidad", unidad_upd.IDUnidad);
            command.Parameters.AddWithValue("@IDClaveUnidad", unidad_upd.IDClaveUnidad);
            command.Parameters.AddWithValue("@CveAlterna", unidad_upd.CveAlterna);
            command.Parameters.AddWithValue("@IdPlanta", unidad_upd.IdPlanta);
            command.Parameters.AddWithValue("@IdOperador", unidad_upd.IdOperador);
            command.Parameters.AddWithValue("@EstatusPlaneacion", unidad_upd.EstatusPlaneacion);
            command.Parameters.AddWithValue("@MotivoInactividad", unidad_upd.MotivoInactividad);
            command.Parameters.AddWithValue("@MotivoCambioOperador", unidad_upd.MotivoCambioOperador);
            command.Parameters.AddWithValue("@IdUsuario", unidad_upd.IdUsuario);
            bool salida = false;

            /**
                     unidad_upd.IDUnidad = int.Parse(txtUnidadId.Text.ToString());
                     unidad_upd.IDClaveUnidad = txtClave.Text.ToString();
                     unidad_upd.CveAlterna = txtCveAlterna.Text.ToString();
                     unidad_upd.IdPlanta = int.Parse(cboPlantaEdicion.SelectedValue.ToString());
                     unidad_upd.IdOperador = int.Parse(cboOperador.SelectedValue.ToString());

                     unidad_upd.EstatusPlaneacion = int.Parse(cboEstatus.SelectedValue.ToString());
                     unidad_upd.MotivoInactividad = int.Parse(cboMotivoInactividad.SelectedValue.ToString()); ;
                     unidad_upd.MotivoCambioOperador = int.Parse(cboMotivoOperador.SelectedValue.ToString()); ;
             **/
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

        public bool InsertarMovCR(int IdUnidad, int IdPlantaOrigen, int IdPlantaDestino, DateTime Inicio, DateTime? Fin, int IdUsuario, string Comentario)
        {
            Metodo = "InsertaUnidad";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("Inserta_MovimientoCr", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdUnidad", IdUnidad);
            command.Parameters.AddWithValue("@IdPlantaOrigen", IdPlantaOrigen);
            command.Parameters.AddWithValue("@IdPlantaDestino", IdPlantaDestino);
            command.Parameters.AddWithValue("@Inicio", Inicio);
            command.Parameters.AddWithValue("@Fin", Fin);
            command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            command.Parameters.AddWithValue("@Comentario", Comentario);
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

        public List<Unidad> ValidaExisteUnidad(string CveUnidad, string CveCiudad, int IdUnidad)
        {
            Metodo = "ValidaExisteUnidad";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ValidaExisteUnidad", conexion);
            command.Parameters.AddWithValue("@CveUnidad", CveUnidad);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@IDUnidad", IdUnidad);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<Unidad> salida = new List<Unidad>();
            SqlDataReader dr = null;
            Unidad elemento = new Unidad();

            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new Unidad();

                        elemento.IDUnidad = int.Parse(dr["IDUnidad"].ToString());
                        elemento.IDClave = dr["IDClaveUnidad"].ToString();
                        elemento.CvePlanta = dr["CvePlanta"].ToString();

                        salida.Add(elemento);
                    }
                }
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            finally
            {
                if ((dr != null) && (!dr.IsClosed)) { dr.Close(); }
                if (command != null) { command.Dispose(); }
                if (conexion != null) { conexion.Dispose(); }
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

        public string ObtenerUnidadesLibres(string CveCiudad, DateTime FechaPedido, DateTime FechaHoraPedido, int IDPlantaPadre)
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

        public List<ConsultaUnidad> BuscaUnidadMovs(string idUnidad)
        {
            Metodo = "BuscaUnidadMovs";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerUnidadesClaveMovs", conexion);
            command.Parameters.AddWithValue("@Clave", idUnidad);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<ConsultaUnidad> salida = new List<ConsultaUnidad>();
            ConsultaUnidad elemento = new ConsultaUnidad();
            SqlDataReader dr = null;
            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new ConsultaUnidad();

                        elemento.IDClaveUnidad = dr["IDClaveUnidad"].ToString();
                        elemento.CveAlterna = dr["CveAlterna"].ToString();
                        elemento.IDUnidad = int.Parse(dr["IDUnidad"].ToString());
                        elemento.NombreOperador = dr["NombreOperador"].ToString();
                        elemento.IdPlanta = int.Parse(dr["IdPlanta"].ToString());
                        elemento.Planta = dr["Planta"].ToString();
                        elemento.CveAlterna = dr["CveAlterna"].ToString();
                        elemento.IDEstatus = int.Parse(dr["IDEstatus"].ToString());
                        elemento.IdOperador = int.Parse(dr["IdOperador"].ToString());
                        elemento.MotivoInactividad = int.Parse(dr["MotivoInactividad"].ToString());
                        elemento.MotivoCambioOperador = int.Parse(dr["MotivoCambioOperador"].ToString());

                        salida.Add(elemento);
                    }
                }

            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            finally
            {
                if ((dr != null) && (!dr.IsClosed)) { dr.Close(); }
                if (command != null) { command.Dispose(); }
                if (conexion != null) { conexion.Dispose(); }
            }
            return salida;
        }


        public List<ConsultaUnidad> LeerUnidadesMovs(string Filtro, string planta)
        {
            Metodo = "LeerUnidadesMovs";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerUnidadesMovsFiltro", conexion);
            command.Parameters.AddWithValue("@Filtro", Filtro);
            command.Parameters.AddWithValue("@Planta", planta);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<ConsultaUnidad> salida = new List<ConsultaUnidad>();
            ConsultaUnidad elemento = new ConsultaUnidad();
            SqlDataReader dr = null;
            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new ConsultaUnidad();

                        elemento.IDClaveUnidad = dr["IDClaveUnidad"].ToString();
                        elemento.IDUnidad = int.Parse(dr["IDUnidad"].ToString());
                        elemento.NombreOperador = dr["NombreOperador"].ToString();
                        elemento.IdPlanta = int.Parse(dr["IdPlanta"].ToString());
                        elemento.Planta = dr["Planta"].ToString();
                        elemento.CveAlterna = dr["CveAlterna"].ToString();
                        elemento.Estatus = dr["Estatus"].ToString();
                        elemento.IDEstatus = int.Parse(dr["IDEstatus"].ToString());
                        elemento.StrMotivoInactividad = dr["StrMotivoInactividad"].ToString();
                        elemento.StrMotivoCambioOperador = dr["StrMotivoCambioOperador"].ToString();

                        salida.Add(elemento);
                    }
                }

            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            finally
            {
                if ((dr != null) && (!dr.IsClosed)) { dr.Close(); }
                if (command != null) { command.Dispose(); }
                if (conexion != null) { conexion.Dispose(); }
            }
            return salida;
        }

        public List<ConsultaUnidad> ObtenerUnidadesFiltro(string Filtro, string planta, string CveCiudad, int IdEstatus)
        {
            Metodo = "ObtenerUnidadesFiltro";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerUnidadesFiltro", conexion);
            command.Parameters.AddWithValue("@Filtro", Filtro);
            command.Parameters.AddWithValue("@Planta", planta);
            command.Parameters.AddWithValue("@Ciudad", CveCiudad);
            command.Parameters.AddWithValue("@IdEstatus", IdEstatus);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<ConsultaUnidad> salida = new List<ConsultaUnidad>();
            ConsultaUnidad elemento = new ConsultaUnidad();
            SqlDataReader dr = null;
            try
            {
                conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new ConsultaUnidad();

                        elemento.IDClaveUnidad = dr["IDClaveUnidad"].ToString();
                        elemento.Borrado = bool.Parse(dr["Borrado"].ToString());
                        elemento.IDUnidad = int.Parse(dr["IDUnidad"].ToString());
                        elemento.Modelo = dr["Modelo"].ToString();
                        elemento.Motor = dr["Motor"].ToString();
                        elemento.NumSerie = dr["NumSerie"].ToString();
                        elemento.Placas = dr["Placas"].ToString();
                        elemento.CentroCostos = dr["CentroCostos"].ToString();
                        elemento.TipoPlacas = dr["TipoPlacas"].ToString();
                        elemento.Propietario = dr["Propietario"].ToString();
                        elemento.Ubicado = dr["Ubicado"].ToString();
                        elemento.Marca = dr["Marca"].ToString();
                        elemento.TipoCobustible = dr["TipoCobustible"].ToString();
                        elemento.Aseguradora = dr["Aseguradora"].ToString();
                        elemento.Inciso = dr["Inciso"].ToString();
                        elemento.Poliza = dr["Poliza"].ToString();
                        elemento.NombreOperador = dr["NombreOperador"].ToString();
                        elemento.IdPlanta = int.Parse(dr["IdPlanta"].ToString());
                        elemento.Planta = dr["Planta"].ToString();
                        elemento.CveAlterna = dr["CveAlterna"].ToString();
                        elemento.Estatus = dr["Estatus"].ToString();
                        elemento.IDEstatus = int.Parse(dr["IDEstatus"].ToString());

                        salida.Add(elemento);
                    }
                }

            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            finally
            {
                if ((dr != null) && (!dr.IsClosed)) { dr.Close(); }
                if (command != null) { command.Dispose(); }
                if (conexion != null) { conexion.Dispose(); }
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

        public string ObtenerMC()
        {
            Metodo = "ObtenerMC";
            SqlConnection conexion = new SqlConnection();
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerMarcaCamion", conexion);
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

        public List<MovimientoCr> BuscaMovimientoCR(int IdUnidad)
        {
            Metodo = "BuscaMovimientoCR";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaMovimientosCr", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdUnidad", IdUnidad);

            List<MovimientoCr> salida = new List<MovimientoCr>();
            MovimientoCr elemento = new MovimientoCr();
            SqlDataReader dr = null;
            command.CommandTimeout = 120;

            try
            {
                conexion.Open();
                dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new MovimientoCr();
                        elemento.IdMovimientoCr = int.Parse(dr["IdMovimientoCr"].ToString());
                        elemento.IdUnidad = int.Parse(dr["IdUnidad"].ToString());
                        elemento.IdPlantaOrigen = int.Parse(dr["IdPlantaOrigen"].ToString());
                        elemento.IdPlantaDestino = int.Parse(dr["IdPlantaDestino"].ToString());
                        elemento.Inicio = string.Format(dr["Inicio"].ToString());
                        elemento.Fin = string.Format(dr["Fin"].ToString());
                        elemento.IdUsuario = int.Parse(dr["IdUsuario"].ToString());
                        elemento.FechaMovimiento = string.Format(dr["FechaMovimiento"].ToString());
                        elemento.PlantaOrigen = dr["PlantaOrigen"].ToString();
                        elemento.PlantaDestino = dr["PlantaDestino"].ToString();
                        elemento.NombreUnidad = dr["NombreUnidad"].ToString();
                        elemento.NombreUsuario = dr["NombreUsuario"].ToString();
                        elemento.Comentario = dr["Comentario"].ToString();

                        salida.Add(elemento);
                    }
                }

            }
            catch (Exception ex)
            {
                //if (conexion.State == ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            finally
            {
                if ((dr != null) && (!dr.IsClosed)) { dr.Close(); }
                if (command != null) { command.Dispose(); }
                //if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                if (conexion != null) { conexion.Dispose(); }

            }

            return salida;
        }

        public bool InsertaPlaneacionUnidad(PlaneacionUnidadPlanta planeacion, int Accion)
        {
            throw new NotImplementedException();
        }
    }
}
