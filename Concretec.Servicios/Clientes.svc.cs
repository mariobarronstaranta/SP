using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Concretec.Pedidos.Utils;
using Concretec.Pedidos.BE;
using System.ServiceModel.Activation;

namespace Concretec.Servicios
{
     [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Clientes" in code, svc and config file together.
    public class Clientes : IClientes
    {
        Concretec.Pedidos.Utils.BitacoraErrores BitError = new BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.0";
        readonly string Servicio = "Clientes.svc";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnConcretec"].ConnectionString; }
        }

        private string CN_AspelMty
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnAspelSQLMTY"].ConnectionString; }
        }

        private string CN_AspelGdl
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnAspelSQLGDL"].ConnectionString; }
        }

        private string CN_AspelAgs
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnAspelSQLAGS"].ConnectionString; }
        }

        private string CN_AspelLeon
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnAspelSQLLEON"].ConnectionString; }
        }

        private string CN_AspelPuebla
        {
            get
            { return ConfigurationManager.ConnectionStrings["cnAspelSQLPUEBLA"].ConnectionString; }
        }

        public bool LimpiaAspel()
        {
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LIMPIA_ASPEL", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            bool salida = false;
            Metodo = "LimpiaAspel";

            try
            {
                conexion.Open();
                command.ExecuteNonQuery();
                salida = true;
                
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            finally
            {
                if (command != null) { command.Dispose(); }
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                if (conexion != null) { conexion.Dispose(); }

            }
            return salida;
        }

        public bool AjustarClientes_Parcial()
        {
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("AjustarClientes_Parcial", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            bool salida = false;
            Metodo = "SincronizaClientes_SinAutorizaciones";

            try
            {
                conexion.Open();
                command.ExecuteNonQuery();
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
            finally
            {
                if (command != null) { command.Dispose(); }
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                if (conexion != null) { conexion.Dispose(); }
            }
            return salida;
        }

        public bool SincronizaApelPedidos()
        {
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("SINCRONIZAASPELPEDIDOS", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            bool salida = false;
            Metodo = "SincronizaApelPedidos";

            try
            {
                conexion.Open();
                command.ExecuteNonQuery();
                salida = true;
                command.Dispose();
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception ex)
            {
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }
            finally
            {
                if (command != null) { command.Dispose(); }
                if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                if (conexion != null) { conexion.Dispose(); }

            }
            return salida;
        }

        public bool AjustarClientes()
        {
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("AjustarClientes", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            bool salida = false;
            Metodo = "AjustarClientes";

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

        public string CString()
        {
            return this.ConnectionString;
        }

        public bool ActualizaAutorizacionCliente(int IDCliente, string username, int estatus, float SaldoAut, float LimiteCreditoAut)
        {
            Metodo = "ActualizaAutorizacionCliente";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ActualizaAutorizacionCliente", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDCliente", IDCliente);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@estatus", estatus);

            command.Parameters.AddWithValue("@SaldoAut", SaldoAut);
            command.Parameters.AddWithValue("@LimiteCreditoAut", LimiteCreditoAut);

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



        public bool AutorizacionCliente(int IDCliente, string username, int estatus)
        {
            Metodo = "AutorizacionCliente";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertaAutorizacionCliente", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDCliente", IDCliente);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@estatus", estatus);

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

        public bool HabilitarCliente(int IDCliente, string username, int estatus)
        {
            Metodo = "HabilitarCliente";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertaAutorizacionCliente", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDCliente", IDCliente);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@estatus", estatus);

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

        List<CLIE_CLIB> ObtieneDatosAdicional_Aspel(string CveCiudad)
        {
            Metodo = "ObtieneDatosAdicional_Aspel";
            SqlConnection conexion;
            switch (CveCiudad)
            {
                case "MTY":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelMty);
                    break;
                case "GDL":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelGdl);
                    break;
                case "AGS":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelAgs);
                    break;
                case "LEON":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelLeon);
                    break;
                case "PUE":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelPuebla);
                    break;
                default:
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelMty);
                    break;
            }
            SqlCommand command = new SqlCommand("ExportarClientes_ADICIONAL", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            conexion.Open();
            SqlDataReader dr = command.ExecuteReader();
            List<CLIE_CLIB> listaclientesaspel = new List<CLIE_CLIB>();
            CLIE_CLIB clientesaspel = new CLIE_CLIB();
            if (dr.HasRows)
            {
                try
                {
                    while (dr.Read())
                    {
                        clientesaspel = new CLIE_CLIB();

                        clientesaspel.CAMPLIB1 = dr["CAMPLIB1"].ToString().Trim();
                        clientesaspel.CAMPLIB2 = dr["CAMPLIB2"].ToString().Trim();
                        clientesaspel.CAMPLIB3 = dr["CAMPLIB3"].ToString().Trim();
                        clientesaspel.CAMPLIB4 = dr["CAMPLIB4"].ToString().Trim();
                        clientesaspel.CAMPLIB5 = dr["CAMPLIB5"].ToString().Trim();
                        clientesaspel.CAMPLIB6 = dr["CAMPLIB6"].ToString().Trim();
                        clientesaspel.CAMPLIB7 = dr["CAMPLIB7"].ToString().Trim();
                        clientesaspel.CAMPLIB8 = dr["CAMPLIB8"].ToString().Trim();
                        clientesaspel.CVE_CLIE = dr["CVE_CLIE"].ToString().Trim();

                        listaclientesaspel.Add(clientesaspel);
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
            }
            return listaclientesaspel;
        }

        bool InsertaAspelTemporal_CLIE_CLIB(string CveCiudad, CLIE_CLIB aspelclientes)
        {
            Metodo = "InsertaAspelTemporal_CLIE_CLIB";
            SqlConnection conexion;
            string storeprocedure = "";

            switch (CveCiudad)
            {
                case "MTY":
                    storeprocedure = "INSERTA_CLIE_CLIB01";
                    break;
                case "GDL":
                    storeprocedure = "INSERTA_CLIE_CLIB03";
                    break;
                case "AGS":
                    storeprocedure = "INSERTA_CLIE_CLIB02";
                    break;
                case "LEON":
                    storeprocedure = "INSERTA_CLIE_CLIB04";
                    break;
                case "PUE":
                    storeprocedure = "INSERTA_CLIE_CLIB05";
                    break;
                default:
                    storeprocedure = "INSERTA_CLIE_CLIB01";
                    break;
            }

            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand(storeprocedure, conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CVE_CLIE", aspelclientes.CVE_CLIE);
            command.Parameters.AddWithValue("@CAMPLIB1", aspelclientes.CAMPLIB1);
            command.Parameters.AddWithValue("@CAMPLIB2", aspelclientes.CAMPLIB2);
            command.Parameters.AddWithValue("@CAMPLIB3", aspelclientes.CAMPLIB3);
            command.Parameters.AddWithValue("@CAMPLIB4", aspelclientes.CAMPLIB4);
            command.Parameters.AddWithValue("@CAMPLIB5", aspelclientes.CAMPLIB5);
            command.Parameters.AddWithValue("@CAMPLIB6", aspelclientes.CAMPLIB6);
            command.Parameters.AddWithValue("@CAMPLIB7", aspelclientes.CAMPLIB7);
            command.Parameters.AddWithValue("@CAMPLIB8", aspelclientes.CAMPLIB8);

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

        bool InsertaAspelTemporal_CLIE(string CveCiudad,CLIE01 aspelclientes)
        {
            Metodo = "InsertaAspelTemporal_CLIE";
            SqlConnection conexion;
            string storeprocedure = "";

            switch (CveCiudad)
            {
                case "MTY":
                    storeprocedure = "INSERTA_CLIE01";
                    break;
                case "GDL":
                    storeprocedure = "INSERTA_CLIE03";
                    break;
                case "AGS":
                    storeprocedure = "INSERTA_CLIE02";
                    break;
                case "LEON":
                    storeprocedure = "INSERTA_CLIE04";
                    break;
                case "PUE":
                    storeprocedure = "INSERTA_CLIE05";
                    break;
                default:
                    storeprocedure = "INSERTA_CLIE01";
                    break;
            }

            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand(storeprocedure, conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CLAVE", aspelclientes.CLAVE);
            command.Parameters.AddWithValue("@STATUS", aspelclientes.STATUS);
            command.Parameters.AddWithValue("@NOMBRE", aspelclientes.NOMBRE);
            command.Parameters.AddWithValue("@RFC", aspelclientes.RFC);
            command.Parameters.AddWithValue("@CALLE", aspelclientes.CALLE);
            command.Parameters.AddWithValue("@NUMINT", aspelclientes.NUMINT);
            command.Parameters.AddWithValue("@NUMEXT", aspelclientes.NUMEXT);
            command.Parameters.AddWithValue("@CRUZAMIENTOS", aspelclientes.CRUZAMIENTOS);
            command.Parameters.AddWithValue("@CRUZAMIENTOS2", aspelclientes.CRUZAMIENTOS2);
            command.Parameters.AddWithValue("@COLONIA", aspelclientes.COLONIA);
            command.Parameters.AddWithValue("@CODIGO", aspelclientes.CODIGO);
            command.Parameters.AddWithValue("@LOCALIDAD", aspelclientes.LOCALIDAD);
            command.Parameters.AddWithValue("@MUNICIPIO", aspelclientes.MUNICIPIO);
            command.Parameters.AddWithValue("@ESTADO", aspelclientes.ESTADO);
            command.Parameters.AddWithValue("@PAIS", aspelclientes.PAIS);
            command.Parameters.AddWithValue("@NACIONALIDAD", aspelclientes.NACIONALIDAD);
            command.Parameters.AddWithValue("@REFERDIR", aspelclientes.REFERDIR);
            command.Parameters.AddWithValue("@TELEFONO", aspelclientes.TELEFONO);
            command.Parameters.AddWithValue("@CLASIFIC", aspelclientes.CLASIFIC);
            command.Parameters.AddWithValue("@FAX", aspelclientes.FAX);
            command.Parameters.AddWithValue("@PAG_WEB", aspelclientes.PAG_WEB);
            command.Parameters.AddWithValue("@CURP", aspelclientes.CURP);
            command.Parameters.AddWithValue("@CVE_ZONA", aspelclientes.CVE_ZONA);
            command.Parameters.AddWithValue("@IMPRIR", aspelclientes.IMPRIR);
            command.Parameters.AddWithValue("@MAIL", aspelclientes.MAIL);
            command.Parameters.AddWithValue("@NIVELSEC", aspelclientes.NIVELSEC);
            command.Parameters.AddWithValue("@ENVIOSILEN", aspelclientes.ENVIOSILEN);
            command.Parameters.AddWithValue("@EMAILPRED", aspelclientes.EMAILPRED);
            command.Parameters.AddWithValue("@DIAREV", aspelclientes.DIAREV);
            command.Parameters.AddWithValue("@DIAPAGO", aspelclientes.DIAPAGO);
            command.Parameters.AddWithValue("@CON_CREDITO", aspelclientes.CON_CREDITO);
            command.Parameters.AddWithValue("@DIASCRED", aspelclientes.DIAS_CRED);
            command.Parameters.AddWithValue("@LIMCRED", aspelclientes.LIMCRED);
            command.Parameters.AddWithValue("@SALDO", aspelclientes.SALDO);
            command.Parameters.AddWithValue("@LISTA_PREC", aspelclientes.LISTA_PREC);
            command.Parameters.AddWithValue("@CVE_BITA", aspelclientes.CVE_BITA);
            command.Parameters.AddWithValue("@ULT_PAGOD", aspelclientes.ULT_PAGOD);
            command.Parameters.AddWithValue("@ULT_PAGOM", aspelclientes.ULT_PAGOM);
            command.Parameters.AddWithValue("@ULT_PAGOF", aspelclientes.ULT_PAGOF);
            command.Parameters.AddWithValue("@DESCUENTO", aspelclientes.DESCUENTO);
            command.Parameters.AddWithValue("@ULT_VENTAD", aspelclientes.ULT_VENTAD);
            command.Parameters.AddWithValue("@ULT_COMPM", aspelclientes.ULT_COMPM);
            command.Parameters.AddWithValue("@FCH_ULTCOM", aspelclientes.FCH_ULTCOM);
            command.Parameters.AddWithValue("@VENTAS", aspelclientes.VENTAS);
            command.Parameters.AddWithValue("@CVE_VEND", aspelclientes.CVE_VEND);
            command.Parameters.AddWithValue("@CVE_OBS", aspelclientes.CVE_OBS);
            command.Parameters.AddWithValue("@TIPO_EMPRESA", aspelclientes.TIPO_EMPRESA);
            command.Parameters.AddWithValue("@MATRIZ", aspelclientes.MATRIZ);
            command.Parameters.AddWithValue("@PROSPECTO", aspelclientes.PROSPECTO);
            command.Parameters.AddWithValue("@CALLE_ENVIO", aspelclientes.CALLE_ENVIO);
            command.Parameters.AddWithValue("@NUMINT_ENVIO", aspelclientes.NUMINT_ENVIO);
            command.Parameters.AddWithValue("@NUMEXT_ENVIO", aspelclientes.NUMEXT_ENVIO);
            command.Parameters.AddWithValue("@CRUZAMIENTOS_ENVIO", aspelclientes.CRUZAMIENTOS_ENVIO);
            command.Parameters.AddWithValue("@CRUZAMIENTOS_ENVIO2", aspelclientes.CRUZAMIENTOS_ENVIO2);
            command.Parameters.AddWithValue("@COLONIA_ENVIO", aspelclientes.COLONIA_ENVIO);
            command.Parameters.AddWithValue("@LOCALIDAD_ENVIO", aspelclientes.LOCALIDAD_ENVIO);
            command.Parameters.AddWithValue("@MUNICIPIO_ENVIO", aspelclientes.MUNICIPIO_ENVIO);
            command.Parameters.AddWithValue("@ESTADO_ENVIO", aspelclientes.ESTADO_ENVIO);
            command.Parameters.AddWithValue("@PAIS_ENVIO", aspelclientes.PAIS_ENVIO);
            command.Parameters.AddWithValue("@CODIGO_ENVIO", aspelclientes.CODIGO_ENVIO);
            command.Parameters.AddWithValue("@CVE_ZONA_ENVIO", aspelclientes.CVE_ZONA_ENVIO);
            command.Parameters.AddWithValue("@REFERENCIA_ENVIO", aspelclientes.REFERENCIA_ENVIO);
            command.Parameters.AddWithValue("@CUENTA_CONTABLE", aspelclientes.CUENTA_CONTABLE);


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

        List<CLIE01> ObtieneClientes_Aspel(string CveCiudad)
        {
            Metodo = "ObtieneClientes_Aspel";
            SqlConnection conexion;
            switch (CveCiudad)
            {
                case "MTY":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelMty);
                    break;
                case "GDL":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelGdl);
                    break;
                case "AGS":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelAgs);
                    break;
                case "LEON":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelLeon);
                    break;
                case "PUE":
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelPuebla);
                    break;
                default:
                    conexion = new System.Data.SqlClient.SqlConnection(this.CN_AspelMty);
                    break;
            }
            SqlCommand command = new SqlCommand("ExportarClientes", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            conexion.Open();
            SqlDataReader dr = command.ExecuteReader();
            List<CLIE01> listaclientesaspel = new List<CLIE01>();
            CLIE01 clientesaspel = new CLIE01();
            if (dr.HasRows)
            {
                try
                {
                    while (dr.Read())
                    {
                        clientesaspel = new CLIE01();

                        clientesaspel.CLAVE = dr["CLAVE"].ToString().Trim();
                        
                        clientesaspel.STATUS = dr["STATUS"].ToString().Trim();
                        clientesaspel.NOMBRE = dr["NOMBRE"].ToString().Trim();
                        clientesaspel.RFC = dr["RFC"].ToString().Trim();
                        clientesaspel.CALLE = dr["CALLE"].ToString().Trim();
                        clientesaspel.NUMINT = dr["NUMINT"].ToString().Trim();
                        clientesaspel.NUMEXT = dr["NUMEXT"].ToString().Trim();
                        clientesaspel.CRUZAMIENTOS = dr["CRUZAMIENTOS"].ToString().Trim();
                        clientesaspel.CRUZAMIENTOS2 = dr["CRUZAMIENTOS2"].ToString().Trim();
                        clientesaspel.COLONIA = dr["COLONIA"].ToString().Trim();
                        clientesaspel.CODIGO = dr["CODIGO"].ToString();
                        clientesaspel.LOCALIDAD = dr["LOCALIDAD"].ToString();
                        clientesaspel.MUNICIPIO = dr["MUNICIPIO"].ToString();
                        clientesaspel.ESTADO = dr["ESTADO"].ToString();
                        clientesaspel.PAIS = dr["PAIS"].ToString();
                        clientesaspel.NACIONALIDAD = dr["NACIONALIDAD"].ToString();
                        clientesaspel.REFERDIR = dr["REFERDIR"].ToString();
                        clientesaspel.TELEFONO = dr["TELEFONO"].ToString();
                        clientesaspel.CLASIFIC = dr["CLASIFIC"].ToString();
                        clientesaspel.FAX = dr["FAX"].ToString();
                        clientesaspel.PAG_WEB = dr["PAG_WEB"].ToString();
                        clientesaspel.CURP = dr["CURP"].ToString();
                        clientesaspel.CVE_ZONA = dr["CVE_ZONA"].ToString();
                        clientesaspel.IMPRIR = dr["IMPRIR"].ToString();
                        clientesaspel.MAIL = dr["MAIL"].ToString();
                        clientesaspel.NIVELSEC = dr["NIVELSEC"].ToString();
                        clientesaspel.ENVIOSILEN = dr["ENVIOSILEN"].ToString();
                        clientesaspel.EMAILPRED = dr["EMAILPRED"].ToString();
                        clientesaspel.DIAREV = dr["DIAREV"].ToString();
                        clientesaspel.DIAPAGO = dr["DIAPAGO"].ToString();
                        clientesaspel.CON_CREDITO = dr["CON_CREDITO"].ToString();
                        clientesaspel.DIAS_CRED = dr["DIASCRED"].ToString();
                        clientesaspel.LIMCRED = dr["LIMCRED"].ToString();
                        clientesaspel.SALDO = float.Parse(dr["SALDO"].ToString());
                        clientesaspel.LISTA_PREC = int.Parse(dr["LISTA_PREC"].ToString());
                        clientesaspel.CVE_BITA = int.Parse(dr["CVE_BITA"].ToString());
                        clientesaspel.ULT_PAGOD = dr["ULT_PAGOD"].ToString();
                        clientesaspel.ULT_PAGOM = dr["ULT_PAGOM"].ToString();
                        clientesaspel.ULT_PAGOF = dr["ULT_PAGOF"].ToString();
                        clientesaspel.DESCUENTO = dr["DESCUENTO"].ToString();
                        clientesaspel.ULT_VENTAD = dr["ULT_VENTAD"].ToString();
                        clientesaspel.ULT_COMPM = float.Parse(dr["ULT_COMPM"].ToString());
                        clientesaspel.FCH_ULTCOM = DateTime.Parse(dr["FCH_ULTCOM"].ToString());
                        clientesaspel.VENTAS = float.Parse(dr["VENTAS"].ToString());
                        clientesaspel.CVE_VEND = dr["CVE_VEND"].ToString();
                        clientesaspel.CVE_OBS = int.Parse(dr["CVE_OBS"].ToString());
                        clientesaspel.TIPO_EMPRESA = dr["TIPO_EMPRESA"].ToString();
                        clientesaspel.MATRIZ = dr["MATRIZ"].ToString();
                        clientesaspel.PROSPECTO = dr["PROSPECTO"].ToString();
                        clientesaspel.CALLE_ENVIO = dr["CALLE_ENVIO"].ToString();
                        clientesaspel.NUMINT_ENVIO = dr["NUMINT_ENVIO"].ToString();
                        clientesaspel.NUMEXT_ENVIO = dr["NUMEXT_ENVIO"].ToString();
                        clientesaspel.CRUZAMIENTOS_ENVIO = dr["CRUZAMIENTOS_ENVIO"].ToString();
                        clientesaspel.CRUZAMIENTOS_ENVIO2 = dr["CRUZAMIENTOS_ENVIO2"].ToString();
                        clientesaspel.COLONIA_ENVIO = dr["COLONIA_ENVIO"].ToString();
                        clientesaspel.LOCALIDAD_ENVIO = dr["LOCALIDAD_ENVIO"].ToString();
                        clientesaspel.MUNICIPIO_ENVIO = dr["MUNICIPIO_ENVIO"].ToString();
                        clientesaspel.ESTADO_ENVIO = dr["ESTADO_ENVIO"].ToString();
                        clientesaspel.PAIS_ENVIO = dr["PAIS_ENVIO"].ToString();
                        clientesaspel.CODIGO_ENVIO = dr["CODIGO_ENVIO"].ToString();
                        clientesaspel.CVE_ZONA_ENVIO = dr["CVE_ZONA_ENVIO"].ToString();
                        clientesaspel.REFERENCIA_ENVIO = dr["REFERENCIA_ENVIO"].ToString();
                        clientesaspel.CUENTA_CONTABLE = dr["CUENTA_CONTABLE"].ToString();

                        listaclientesaspel.Add(clientesaspel);
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
            }
            return listaclientesaspel;
        }

        public bool SincronizaClientes_SinAutorizaciones(string CveCiudad)
        {
            Metodo = "SincronizaClientes_SinAutorizaciones";
            List<CLIE01> ListaDatosClientes = new List<CLIE01>();
            List<CLIE_CLIB> ListaDatosAdicionales = new List<CLIE_CLIB>();
            ListaDatosClientes = ObtieneClientes_Aspel(CveCiudad);
            ListaDatosAdicionales = ObtieneDatosAdicional_Aspel(CveCiudad);
            bool spInsertaAspelTemporal_CLIE = false;
            bool spInsertaAspelTemporal_CLIE_CLIB = false;
            bool spLimpiaAspel = false;
            bool spSincronizaAspelPedidos = false;

            //Limpiar los datos iniciales que pudiera haber en las tablas de trabajo
            spLimpiaAspel = LimpiaAspel();

            //Insertar los datos en CLIE 01,02,03,04 segun sean la ciudad
            foreach (CLIE01 elemento in ListaDatosClientes)
            { spInsertaAspelTemporal_CLIE = InsertaAspelTemporal_CLIE(CveCiudad, elemento); }

            //Insertar los datos en CLIE_CLIB 01,02,03,04 segun sean la ciudad
            foreach (CLIE_CLIB elemento in ListaDatosAdicionales)
            { spInsertaAspelTemporal_CLIE_CLIB = InsertaAspelTemporal_CLIE_CLIB(CveCiudad, elemento); }

            //Inicio del proceso de limpiar los clientes e insertarlos en la tabla Clientes
            spSincronizaAspelPedidos = AjustarClientes_Parcial();

            //Limpiar los datos iniciales que pudiera haber en las tablas de trabajo
            spLimpiaAspel = LimpiaAspel();

            return spSincronizaAspelPedidos;
        }

        public bool SincronizaClientes(string CveCiudad)
        {
            Metodo = "SincronizaClientes";
            List<CLIE01> ListaDatosClientes = new List<CLIE01>();
            List<CLIE_CLIB> ListaDatosAdicionales = new List<CLIE_CLIB>();
            ListaDatosClientes = ObtieneClientes_Aspel(CveCiudad);
            ListaDatosAdicionales = ObtieneDatosAdicional_Aspel(CveCiudad);
            bool spInsertaAspelTemporal_CLIE = false;
            bool spInsertaAspelTemporal_CLIE_CLIB = false;
            bool spLimpiaAspel = false;
            bool spSincronizaAspelPedidos = false;

            //Limpiar los datos iniciales que pudiera haber en las tablas de trabajo
            spLimpiaAspel = LimpiaAspel();

            //Insertar los datos en CLIE 01,02,03,04 segun sean la ciudad
            foreach (CLIE01 elemento in ListaDatosClientes)
            { spInsertaAspelTemporal_CLIE= InsertaAspelTemporal_CLIE(CveCiudad,elemento);}

            //Insertar los datos en CLIE_CLIB 01,02,03,04 segun sean la ciudad
            foreach (CLIE_CLIB elemento in ListaDatosAdicionales)
            {spInsertaAspelTemporal_CLIE_CLIB = InsertaAspelTemporal_CLIE_CLIB(CveCiudad, elemento);}

            //Inicio del proceso de limpiar los clientes e insertarlos en la tabla Clientes
            spSincronizaAspelPedidos = SincronizaApelPedidos();

            //Limpiar los datos iniciales que pudiera haber en las tablas de trabajo
            spLimpiaAspel = LimpiaAspel();

            return spSincronizaAspelPedidos;
        }

        public string BuscarClienteCve(string CveCliente, string CveCiudad)
        {
            Metodo = "BuscarClienteCve";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscarClienteCve", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCliente", CveCliente);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);

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

        public string BuscarCliente(int IDCliente, string CveCiudad)
        {

            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscarCliente", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDCliente", IDCliente);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            Metodo = "BuscarCliente";

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

        public string ObtenerClienteCartera(string Filtro, string CveCiudad, string Planta)
        {

            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerClientesCartera", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Filtro", Filtro);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@Planta", Planta);
            Metodo = "ObtenerClienteCartera";

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


        public string ObtenerCliente(string Filtro, string CveCiudad, string Planta)
        {

            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerClientesFiltro", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Filtro", Filtro);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@Planta", Planta);
            Metodo = "ObtenerCliente";

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


        public bool InsertarCliente(string ClaveCliente, bool Activo, string NombreCompleto, string RFC, string Direccion, string CP, string Poblacion, string Colonia, string Telefonos, string Fax, string CorreoElectronico, string TipoPago, string AttPago, string AttCobro, string RevisionPago, int IDPlanta, int IDCliente, int ACCION, string Planta, string IDVendedor)
        {
            Metodo = "InsertarCliente";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertaCliente", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ClaveCliente", ClaveCliente);
            command.Parameters.AddWithValue("@Activo", Activo);
            command.Parameters.AddWithValue("@NombreCompleto", NombreCompleto);
            command.Parameters.AddWithValue("@RFC", RFC);
            command.Parameters.AddWithValue("@Direccion", Direccion);
            command.Parameters.AddWithValue("@CP", CP);
            command.Parameters.AddWithValue("@Poblacion", Poblacion);
            command.Parameters.AddWithValue("@Colonia", Colonia);
            command.Parameters.AddWithValue("@Telefonos", Telefonos);
            command.Parameters.AddWithValue("@Fax", Fax);
            command.Parameters.AddWithValue("@CorreoElectronico", CorreoElectronico);
            command.Parameters.AddWithValue("@TipoPago", TipoPago);
            command.Parameters.AddWithValue("@AttPago", AttPago);
            command.Parameters.AddWithValue("@AttCobro", AttCobro);
            command.Parameters.AddWithValue("@RevisionPago", RevisionPago);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@IDCliente", IDCliente);
            command.Parameters.AddWithValue("@ACCION", ACCION);


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

        public string ObtenerClientesConPedido(string CveCiudad)
        {
            Metodo = "ObtenerClientesConObra";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerClientesConPedido", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);

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

        public string ObtenerClientesConObra(string CveCiudad)
        {
            Metodo = "ObtenerClientesConObra";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerClientesConObra", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);

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

        public string ObtenerClientesSaldo(string CveCiudad, int IDCliente)
        {
            Metodo = "ObtenerClientesSaldo";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerClientesConSaldo", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@IDCliente", IDCliente);

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

        public string ObtenerClientes(string CveCiudad)
        {
            Metodo = "ObtenerClientes";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerClientes", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);

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
