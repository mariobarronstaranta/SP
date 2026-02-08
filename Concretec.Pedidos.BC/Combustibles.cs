using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Concretec.Pedidos.Utils;
using System.Data;
using Concretec.Pedidos.BE;

namespace Concretec.Pedidos.BC
{
    public class Combustibles
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "BC Pedido.cs";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.AppSettings["conexion"].ToString(); }
        }

        public Tanque ValoresCalculoSalida(int idunidad , float odometro , float horimetro)
        {
            Metodo = "ValoresCalculoSalida";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("DATOSUNIDADCARGA", conexion);
            command.Parameters.AddWithValue("@IDUNIDAD", idunidad);
            command.Parameters.AddWithValue("@HORIMETRO", horimetro);
            command.Parameters.AddWithValue("@ODOMETRO", odometro);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            BE.Tanque salida = new Tanque();
            BE.Tanque elemento = new Tanque();
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Tanque();

                        elemento.IdUnidad               = int.Parse(dr["IDUNIDAD"].ToString().Trim());
                        elemento.DistRecorridaOdometro  = float.Parse(dr["ODOMETRO_DIFERENCIA"].ToString().Trim());
                        elemento.TiempoTrabajado        = float.Parse(dr["HORIMETRO_DIFERENCIA"].ToString().Trim());
                        elemento.UltimaFechaCarga       = DateTime.Parse(dr["ULTIMACARGA"].ToString().Trim());

                        salida = elemento;
                    }
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

        public bool RegistraSalidaCombustible(Tanque entidad)
        {
            Metodo = "RegistraSalidaCombustible";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("RegistraSalidaCombustible", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdTanque", entidad.IdTanque);
            command.Parameters.AddWithValue("@IdTipoMovimiento", entidad.TipoMovimientoId);
            command.Parameters.AddWithValue("@InvActualCms", entidad.InvActualCms);
            command.Parameters.AddWithValue("@FechaMovimiento", entidad.FechaMovimiento);
            command.Parameters.AddWithValue("@HoraMovimiento", entidad.HoraMovimiento);
            command.Parameters.AddWithValue("@TempActual", entidad.TempActual);
            command.Parameters.AddWithValue("@InvActualLts", entidad.InvActualLts);
            command.Parameters.AddWithValue("@InvActual15CLts", entidad.InvActual15CLts);
            command.Parameters.AddWithValue("@valor", 0);
            command.Parameters.AddWithValue("@UsuarioIdRegistro", entidad.UsuarioIdRegistro);
            //Campos Nuevos para datos propios de la salida
            command.Parameters.AddWithValue("@PlantaId", entidad.PlantaId_Unidad);
            command.Parameters.AddWithValue("@Unidad", entidad.IdUnidad);
            command.Parameters.AddWithValue("@Operador", entidad.OperadorId);
            command.Parameters.AddWithValue("@FolioVale", entidad.FolioVale);
            command.Parameters.AddWithValue("@ConsecutivoBomba", entidad.ConsecutivoBomba);
            command.Parameters.AddWithValue("@LitrosCargados", entidad.litrosCargados);
            command.Parameters.AddWithValue("@Odometro", entidad.odometro_actual);
            command.Parameters.AddWithValue("@Horimetro", entidad.horimetro_actual);
            //Campos calculados despues de la salida de combustible
            command.Parameters.AddWithValue("@LtsTempAmbiente", entidad.litrosCargados);
            command.Parameters.AddWithValue("@NInvExistente15C", entidad.NInvExistente15C);
            command.Parameters.AddWithValue("@NInvTAmbiente", entidad.NInvTAmbiente);
            command.Parameters.AddWithValue("@NInvCms", entidad.NInvCms);
            command.Parameters.AddWithValue("@ObservacionesIn", entidad.ObservacionesIdOut);

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


        public bool RegistraEntradaCombustible(Tanque entidad)
        {
            Metodo = "RegistraEntradaCombustible";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("RegistraEntradaCombustible", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdTanque", entidad.IdTanque);
            command.Parameters.AddWithValue("@IdTipoMovimiento", entidad.TipoMovimientoId);
            command.Parameters.AddWithValue("@InvActualCms", entidad.InvActualCms);
            command.Parameters.AddWithValue("@FechaMovimiento", entidad.FechaMovimiento);
            command.Parameters.AddWithValue("@HoraMovimiento", entidad.HoraMovimiento);
            command.Parameters.AddWithValue("@TempActual", entidad.TempActual);
            command.Parameters.AddWithValue("@InvActualLts", entidad.InvActualLts);
            command.Parameters.AddWithValue("@InvActual15CLts", entidad.InvActual15CLts);
            command.Parameters.AddWithValue("@valor", 0);
            command.Parameters.AddWithValue("@UsuarioIdRegistro", entidad.UsuarioIdRegistro);

            command.Parameters.AddWithValue("@ProveedorId", entidad.ProveedorId);
            command.Parameters.AddWithValue("@Remision", entidad.Remision);
            command.Parameters.AddWithValue("@LtsTempAmbiente", entidad.LtsTempAmbiente);
            command.Parameters.AddWithValue("@NInvExistente15C", entidad.NInvExistente15C);
            command.Parameters.AddWithValue("@NInvTAmbiente", entidad.NInvTAmbiente);
            command.Parameters.AddWithValue("@NInvCms", entidad.NInvCms);
            command.Parameters.AddWithValue("@ObservacionesIn", entidad.ObservacionesIn);

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


        public bool RegistraAjuste(int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, string observaciones)
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

        public bool ActualizaMovimientoIN(int idmovimiento, int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, string proveedor, string referencia)
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

        public bool RegistraMovimientoIN(int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, string proveedor, string referencia)
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

        public bool ActualizaLectura(int idlectura, int IdTanque, DateTime fecha, DateTime hora, float valorlectura, int idusuario,int temperatura,int lecturacms)
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
            command.Parameters.AddWithValue("@TEMPERATURA", temperatura);
            command.Parameters.AddWithValue("@Lectura_CMS", temperatura);

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

        public bool RegistraLectura(int IdTanque, DateTime fecha, DateTime hora, float valorlectura, int idusuario,int temperatura,int lecturacms)
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
            command.Parameters.AddWithValue("@TEMPERATURA", temperatura);
            command.Parameters.AddWithValue("@Lectura_CMS", lecturacms);

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

        public bool InsertaTanque(string Operacion, int IdTanque, string IdCiudad, int IdPlanta, int IdTipoCombustible,
                                    string Nombre, double capacidad, int idusuario,
                                    decimal Altura, string Forma, decimal DiametroA, decimal DiametroB)
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
            //Campos Nuevos
            command.Parameters.AddWithValue("@Altura", Altura);
            command.Parameters.AddWithValue("@Forma", Forma);
            command.Parameters.AddWithValue("@DiametroA", DiametroA);
            command.Parameters.AddWithValue("@DiametroB", DiametroB);

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

        public bool RegistraMovimientoOUT(int IdTanque, int IdTipoMovimiento, float valor, int IdUsuarioActualizacion, DateTime FechaMovimiento, DateTime HoraMovimiento, string proveedor, int IdUnidad, int IdOperador, float horimetro, float odometro,float temperatura)
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
            command.Parameters.AddWithValue("@Temperatura", temperatura);

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

        public string BuscaEntradaCombustibles(int idtanque, DateTime desde, DateTime hasta, string cveciudad, int idmovimiento)
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

        public List<Tanque> Busca_Resumen_Tanque(string ciudad,int idTanque)
        {
            Metodo = "Busca_Resumen_Tanque";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("DATOSTANQUE", conexion);
            command.Parameters.AddWithValue("@CveCiudad", ciudad);
            command.Parameters.AddWithValue("@TanqueId", idTanque);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<BE.Tanque> salida = new List<BE.Tanque>();
            BE.Tanque elemento = new BE.Tanque();
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Tanque();

                        elemento.IdTanque           = int.Parse(dr["IdTanque"].ToString().Trim());
                        elemento.Nombre             = dr["Nombre"].ToString().Trim();
                        elemento.ciudad             = dr["ciudad"].ToString().Trim();
                        elemento.IdPlanta           = int.Parse(dr["IdPlanta"].ToString().Trim());
                        elemento.capacidad          = dr["Capacidad"].ToString().Trim();
                        elemento.planta             = dr["CvePlanta"].ToString().Trim();
                        elemento.TempActual         = double.Parse(dr["TempActual"].ToString().Trim());
                        elemento.InvActualCms       = int.Parse(dr["InvActualCms"].ToString().Trim());
                        elemento.InvActualLts       = double.Parse(dr["InvActualLts"].ToString().Trim());
                        elemento.InvActual15CLts    = double.Parse(dr["InvActual15CLts"].ToString().Trim());
                        elemento.FechaMovimiento    = DateTime.Parse(dr["HoraMovimiento"].ToString().Trim());
                        elemento.Movimiento         = dr["Movimiento"].ToString().Trim();
                        //Campos para la edicion de Tanque
                        elemento.IdTipoCombustible  = int.Parse(dr["IdTipoCombustible"].ToString().Trim());
                        elemento.Altura             = decimal.Parse(dr["Altura"].ToString().Trim());
                        elemento.Forma              = dr["Forma"].ToString().Trim();
                        elemento.DiametroA          = decimal.Parse(dr["DiametroA"].ToString().Trim());
                        elemento.DiametroB          = decimal.Parse(dr["DiametroB"].ToString().Trim());

                        salida.Add(elemento);
                    }
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

        public List<Tanque> Busca_Remision_Tanque(string remision)
        {
            Metodo = "Busca_Remision_Tanque";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BUSCA_REMISION_TANQUE", conexion);
            command.Parameters.AddWithValue("@REMISION_CLAVE", remision);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<BE.Tanque> salida = new List<BE.Tanque>();
            BE.Tanque elemento = new BE.Tanque();
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Tanque();

                        elemento.idMovimientoDetalle    = int.Parse(dr["idMovimientoDetalle"].ToString().Trim());
                        elemento.IdMovimiento           = int.Parse(dr["IdMovimiento"].ToString().Trim());
                        elemento.Remision               = dr["Remision"].ToString().Trim();

                        salida.Add(elemento);
                    }
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

        public List<Tanque> Busca_Altura_Volumen_Tanque(int Temperatura, float Litros15C, int TanqueId)
        {
            Metodo = "Busca_Altura_Volumen_Tanque";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BUSCA_ALTURA_VOLUMEN_TANQUE", conexion);
            command.Parameters.AddWithValue("@TEMP_ACT", Temperatura);
            command.Parameters.AddWithValue("@LTS_15C", Litros15C);
            command.Parameters.AddWithValue("@TANQUEID", TanqueId);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<BE.Tanque> salida = new List<BE.Tanque>();
            BE.Tanque elemento = new BE.Tanque();
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Tanque();

                        elemento.IdTanque = int.Parse(dr["TanqueId"].ToString().Trim());
                        elemento.Volumen = float.Parse(dr["Volumen"].ToString().Trim());
                        elemento.Altura = decimal.Parse(dr["Altura"].ToString().Trim());
                        
                        salida.Add(elemento);
                    }
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

        public List<Tanque> Busca_Volumen_Temperatura(int TanqueId, float Temperatura, float volumen)
        {
            Metodo = "Busca_Volumen_Temperatura";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BUSCA_VOLUMEN_TEMPERATURA", conexion);
            command.Parameters.AddWithValue("@TANQUEID", TanqueId);
            command.Parameters.AddWithValue("@TEMPERATURA", Temperatura);
            command.Parameters.AddWithValue("@VOLUMEN", volumen);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<BE.Tanque> salida = new List<BE.Tanque>();
            BE.Tanque elemento = new BE.Tanque();
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Tanque();

                        elemento.AjusteVolumetricoId = int.Parse(dr["AjusteVolumetricoId"].ToString().Trim());
                        elemento.Temperatura = float.Parse(dr["Temperatura"].ToString().Trim());
                        elemento.FactorAjuste = float.Parse(dr["FactorAjuste"].ToString().Trim());
                        elemento.FactorEstimado = float.Parse(dr["FactorEstimado"].ToString().Trim());
                        elemento.Densidad = float.Parse(dr["Densidad"].ToString().Trim());
                        elemento.DensidadEstimada = float.Parse(dr["DensidadEstimada"].ToString().Trim());
                        elemento.VolumenAjustado = float.Parse(dr["VolumenAjustado"].ToString().Trim());
                        salida.Add(elemento);
                    }
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

        public List<Tanque> Busca_Volumen_Altura_Taque(int TanqueId, float altura)
        {
            Metodo = "Busca_Volumen_Altura_Taque";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BUSCA_VOLUMEN_ALTURA_TANQUE", conexion);
            command.Parameters.AddWithValue("@TANQUEID", TanqueId);
            command.Parameters.AddWithValue("@ALTURA", altura);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<BE.Tanque> salida = new List<BE.Tanque>();
            BE.Tanque elemento = new BE.Tanque();
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Tanque();

                        elemento.IdTanque = int.Parse(dr["TanqueId"].ToString().Trim());
                        elemento.Altura = decimal.Parse(dr["Altura"].ToString().Trim());
                        elemento.Volumen = float.Parse(dr["Volumen"].ToString().Trim());
                        salida.Add(elemento);
                    }
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

        public List<Tanque> BuscaInfoTanque(int TanqueId)
        {
            Metodo = "BuscaInfoTanque";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SELTANQUE_INFO", conexion);
            command.Parameters.AddWithValue("@TANQUEID", TanqueId);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<BE.Tanque> salida = new List<BE.Tanque>();
            BE.Tanque elemento = new BE.Tanque();
            try
            {
                conexion.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        elemento = new BE.Tanque();

                        
                        elemento.IdTanque       = int.Parse(dr["IdTanque"].ToString().Trim());
                        elemento.Nombre         = dr["Nombre"].ToString().Trim();
                        elemento.IdCiudad       = dr["CveCiudad"].ToString().Trim();
                        elemento.ciudad         = dr["Ciudad"].ToString().Trim();
                        elemento.IdPlanta       = int.Parse(dr["IdPlanta"].ToString().Trim());
                        elemento.planta         = dr["planta"].ToString().Trim();

                        elemento.capacidad      = dr["capacidad"].ToString().Trim();
                        elemento.IdTipoCombustible = int.Parse(dr["IdTipoCombustible"].ToString().Trim());
                        elemento.combustible    = dr["combustible"].ToString().Trim();
                        elemento.Altura         = decimal.Parse(dr["Altura"].ToString().Trim());
                        elemento.Forma          = dr["Forma"].ToString().Trim();

                        elemento.DiametroA      = decimal.Parse(dr["DiametroA"].ToString().Trim());
                        elemento.DiametroB      = decimal.Parse(dr["DiametroB"].ToString().Trim());
                        elemento.LecturaCms     = double.Parse(dr["LecturaCms"].ToString().Trim());
                        elemento.VolActual15C   = double.Parse(dr["VolActual15C"].ToString().Trim());
                        elemento.VolActualTA    = double.Parse(dr["VolActualTA"].ToString().Trim());
                        elemento.Temperatura    = float.Parse(dr["Temperatura"].ToString().Trim()); 

                        salida.Add(elemento);
                    }
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

        public string BuscaTanquesCombo(int IdPlanta)
        {
            Metodo = "BuscaTanquesCombo";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SP_TANQUES", conexion);
            command.Parameters.AddWithValue("@Operacion", "COMBO");
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
    }
}
