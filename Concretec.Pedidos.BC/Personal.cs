using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Concretec.Pedidos.Utils;
using Concretec.Pedidos.BE;
using System.Configuration;
using System.Data;

namespace Concretec.Pedidos.BC
{
    public class Personal : IPersonal
    {

        Concretec.Pedidos.Utils.BitacoraErrores BitError = new Concretec.Pedidos.Utils.BitacoraErrores();
        readonly string Aplicacion = "Programacion de Pedidos V 2.5";
        readonly string Servicio = "BC Personal.cs";
        string Metodo = string.Empty;

        private string ConnectionString
        {
            get
            { return ConfigurationManager.AppSettings["conexion"].ToString(); }
        }

        public string ObtenerPersonalFiltro(string Filtro, string TipoPersonal, string CveCiudad, int Planta, string Estatus)
        {
            Metodo = "ObtenerPersonalFiltro";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerPersonalFiltro", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Filtro", Filtro);
            command.Parameters.AddWithValue("@TipoPersonal", TipoPersonal);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@Planta", Planta);
            command.Parameters.AddWithValue("@Estatus", Estatus);
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
                if (conexion.State == ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string ObtenerChoferUnidad(int IDUnidad, string CveCiudad)
        {
            Metodo = "ObtenerChoferUnidad";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ObtenerChoferUnidad", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDUnidad", IDUnidad);
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
                if (conexion.State == ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string BuscarEmpleadoClave(string ClavePersonal)
        {
            Metodo = "BuscarEmpleadoClave";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaPersonalClave", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idpersonal", ClavePersonal);
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
                //conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public string BuscarEmpleado(string ClavePersonal)
        {
            Metodo = "BuscarEmpleado";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("BuscaPersonal", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idpersonal", ClavePersonal);
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
                //conexion.Dispose();
            }
            catch (Exception ex)
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool InsertarPersonal(
            string CvePersonal,
            string Nombre,
            string APaterno,
            string AMaterno,
            string Puesto,
            string TipoPersonal,
            string CveCiudad,
            int IDPlanta,
            string interno,
            string Estatus)
        {
            Metodo = "InsertarPersonal";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertarPersonal", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CvePersonal", CvePersonal);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@APaterno", APaterno);
            command.Parameters.AddWithValue("@AMaterno", AMaterno);
            command.Parameters.AddWithValue("@Puesto", Puesto);
            command.Parameters.AddWithValue("@TipoPersonal", TipoPersonal);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@interno", interno);
            command.Parameters.AddWithValue("@Estatus", Estatus);

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
                if (conexion.State == ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool ActualizaPersonal(
            int idpersonal,
            string CvePersonal,
            string Nombre,
            string APaterno,
            string AMaterno,
            string Puesto,
            string TipoPersonal,
            string CveCiudad,
            int IDPlanta,
            string interno,
            string Estatus)
        {
            Metodo = "ActualizaPersonal";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("ActualizaPersonal", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IDPersonal", idpersonal);
            command.Parameters.AddWithValue("@CvePersonal", CvePersonal);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@APaterno", APaterno);
            command.Parameters.AddWithValue("@AMaterno", AMaterno);
            command.Parameters.AddWithValue("@Puesto", Puesto);
            command.Parameters.AddWithValue("@TipoPersonal", TipoPersonal);
            command.Parameters.AddWithValue("@CveCiudad", CveCiudad);
            command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            command.Parameters.AddWithValue("@interno", interno);
            command.Parameters.AddWithValue("@Estatus", Estatus);

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
                if (conexion.State == ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public List<Archivos> ListaArchivos()
        {
            List<Archivos> Salida = new List<Archivos>();
            Archivos item = new Archivos();

            item = new Archivos();
            item.Ciudad = "MTY";
            item.Nombre = "PERINTMTY.xlsx";
            item.TipoArchivo = "Personal";
            Salida.Add(item);

            return Salida;
        }

        public bool CargaPersonalExcel()
        {
            //AgenteClientes Agente = new AgenteClientes();
            bool Insertar = new bool();
            //bool Actualizar = new bool();
            Metodo = "CargaPersonalExcel";
            List<Archivos> Lista = new List<Archivos>();
            BE.Personal ClienteInformix = new BE.Personal();
            List<BE.Personal> ListaClientes = new List<BE.Personal>();
            OleDbConnection _connection = new OleDbConnection();
            StringBuilder ConnectionString = new StringBuilder("");
            ConnectionString.Append(@"Provider=Microsoft.ACE.OLEDB.12.0;");
            ConnectionString.Append(@"Excel 12.0 Xml;HDR=YES");
            ConnectionString.Append(@"Data Source=C:\Concretec\;");
            _connection.ConnectionString = ConnectionString.ToString();


            // ------------------------------------------------------------------------------
            Lista = ListaArchivos();
            foreach (Archivos ii in Lista)
            {
                _connection.Open();
                ClienteInformix = new BE.Personal();

                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        ClienteInformix = new BE.Personal();
                        OleDbCommand _Comando = new OleDbCommand("SELECT * FROM " + ii.Nombre.ToString() + ";", _connection);
                        OleDbDataReader DR = _Comando.ExecuteReader();
                        ListaClientes = new List<BE.Personal>();

                        if (DR.HasRows)
                        {
                            while (DR.Read())
                            {
                                ClienteInformix = new BE.Personal();
                                ClienteInformix.ClavePersonal = DR["ClaveNueva"].ToString().Trim();
                                ListaClientes.Add(ClienteInformix);
                            }
                        }

                        _connection.Dispose();

                        foreach (BE.Personal i in ListaClientes)
                        {
                            Insertar = false;
                        }



                    }
                    catch (Exception ex)
                    {
                        BitError = new BitacoraErrores();
                        BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
                    }


                }
            }

            return true;
        }



        public bool CargaPersonalParadox()
        {
            //AgenteClientes Agente = new AgenteClientes();
            bool Insertar = new bool();
            //bool Actualizar = new bool();
            Metodo = "CargaPersonalParadox";
            List<Archivos> Lista = new List<Archivos>();
            PersonalPX ClienteInformix = new PersonalPX();
            List<PersonalPX> ListaClientes = new List<PersonalPX>();
            OleDbConnection _connection = new OleDbConnection();
            StringBuilder ConnectionString = new StringBuilder("");
            ConnectionString.Append(@"Provider=Microsoft.Jet.OLEDB.4.0;");
            ConnectionString.Append(@"Extended Properties=Paradox 5.x;");
            ConnectionString.Append(@"Data Source=C:\Concretec\;");
            _connection.ConnectionString = ConnectionString.ToString();
            // ------------------------------------------------------------------------------
            Lista = ListaArchivos();
            foreach (Archivos ii in Lista)
            {
                _connection.Open();
                ClienteInformix = new PersonalPX();

                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        ClienteInformix = new PersonalPX();
                        OleDbCommand _Comando = new OleDbCommand("SELECT * FROM " + ii.Nombre.ToString() + ";", _connection);
                        OleDbDataReader DR = _Comando.ExecuteReader();
                        ListaClientes = new List<PersonalPX>();

                        if (DR.HasRows)
                        {
                            while (DR.Read())
                            {
                                ClienteInformix = new PersonalPX();
                                ClienteInformix.AP_MAT_     = DR["AP_MAT_"].ToString().Trim();
                                ClienteInformix.AP_PAT_     = DR["AP_PAT_"].ToString().Trim();
                                ClienteInformix.BANC_NOM    = DR["BANC_NOM"].ToString().Trim();
                                ClienteInformix.CALLE       = DR["CALLE"].ToString().Trim();
                                ClienteInformix.CAMB_SDI    = DR["CAMB_SDI"].ToString().Trim();
                                ClienteInformix.CD_POBLAC   = DR["CD_POBLAC"].ToString().Trim();
                                ClienteInformix.CLASIF      = DR["CLASIF"].ToString().Trim();
                                ClienteInformix.CLAVE       = DR["CLAVE"].ToString().Trim();
                                ClienteInformix.COD_POST    = DR["COD_POST"].ToString().Trim();
                                ClienteInformix.COLONIA     = DR["COLONIA"].ToString().Trim();
                                ClienteInformix.CONTRATO    = DR["CONTRATO"].ToString().Trim();
                                ClienteInformix.CTRL_NOM    = DR["CTRL_NOM"].ToString().Trim();
                                ClienteInformix.DEPTO       = DR["DEPTO"].ToString().Trim();
                                ClienteInformix.EDO_CIVIL   = DR["EDO_CIVIL"].ToString().Trim();
                                ClienteInformix.ENT_FED     = DR["ENT_FED"].ToString();
                                ClienteInformix.FECH_ALTA   = DR["FECH_ALTA"].ToString();
                                ClienteInformix.FECH_BAJA   = DR["FECH_BAJA"].ToString();
                                ClienteInformix.FECH_NACIM  = DR["FECH_NACIM"].ToString();
                                ClienteInformix.FECH_SAL    = DR["FECH_SAL"].ToString();
                                ClienteInformix.FORM_PAGO   = DR["FORM_PAGO"].ToString();
                                ClienteInformix.IMSS        = DR["IMSS"].ToString();
                                ClienteInformix.LOCALI_NOM  = DR["LOCALI_NOM"].ToString();
                                ClienteInformix.LUG_NACIM   = DR["LUG_NACIM"].ToString();
                                ClienteInformix.MUNICIPIO   = DR["MUNICIPIO"].ToString();
                                ClienteInformix.NOMBRE      = DR["NOMBRE"].ToString();
                                ClienteInformix.NUM_REG     = DR["NUM_REG"].ToString();
                                ClienteInformix.PUESTO      = DR["PUESTO"].ToString();
                                ClienteInformix.RFC         = DR["RFC"].ToString();
                                ClienteInformix.SAL_DIARIO  = DR["SAL_DIARIO"].ToString();
                                ClienteInformix.SDI         = DR["SDI"].ToString();
                                ClienteInformix.SDI_INFO    = DR["SDI_INFO"].ToString();
                                ClienteInformix.SEXO        = DR["SEXO"].ToString();
                                ClienteInformix.STATUS      = DR["STATUS"].ToString();
                                ClienteInformix.TELEFONO    = DR["TELEFONO"].ToString();
                                ClienteInformix.TIP_EMPL    = DR["TIP_EMPL"].ToString();
                                ClienteInformix.TIP_SAL     = DR["TIP_SAL"].ToString();
                                ClienteInformix.TURNO       = DR["TURNO"].ToString();
                              
                                ListaClientes.Add(ClienteInformix);
                            }
                        }

                        _connection.Close();

                        foreach (PersonalPX i in ListaClientes)
                        {
                            Insertar = new bool();
                            Insertar = InsertarPersonal(i.CLAVE, i.NOMBRE, i.AP_PAT_, i.AP_MAT_, i.CALLE, i.COLONIA, i.CD_POBLAC, i.MUNICIPIO, i.TELEFONO, "", i.TIP_EMPL, DateTime.Parse(i.FECH_ALTA), i.STATUS, "", "","MTY");
                        }

                        // Aqui hay que mandar llamar al metodo que inserta en la DB
                        //Actualizar = AjustarClientes();

                    }
                    catch (Exception ex)
                    {
                        BitError = new BitacoraErrores();
                        BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
                    }


                }
            }

            return true;
        }

        public string ObtenerPersonal(string TipoPersonal, string CveCiudad)
        {
            Metodo = "ObtenerPersonal";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("LeerPersonal", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TipoPersonal", TipoPersonal);
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
                if (conexion.State == ConnectionState.Open) conexion.Close();
                BitError = new BitacoraErrores();
                BitError.EscribirBitacora(Aplicacion, Servicio, Metodo, ex.Message.ToString());
            }

            return salida;
        }

        public bool InsertarPersonal(string CvePersonal, string Nombre, string APaterno, string AMaterno, string Calle,string Colonia,string Poblacion,string Municipio, string Telefono, string Avisar, string TipoPersonal, DateTime FechaRegistro, string Estatus, string NumLicencia, string Vigencia,string CveCiudad)
        {
            Metodo = "InsertarPersonal";
            SqlConnection conexion;
            conexion = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand("InsertarPersonal", conexion);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@IDPlanta", IDPlanta);
            //command.Parameters.AddWithValue("@Nombre", Nombre);
            //command.Parameters.AddWithValue("@CveDosificadora", CveDosificadora);
            //command.Parameters.AddWithValue("@Estatus", Estatus);
            //command.Parameters.AddWithValue("@Telefono", Telefono);
            //command.Parameters.AddWithValue("@Telefono2", Telefono2);
            //command.Parameters.AddWithValue("@IDCiudad", IDCiudad);
            //command.Parameters.AddWithValue("@Calle", Calle);
            //command.Parameters.AddWithValue("@NumInt", NumInt);
            //command.Parameters.AddWithValue("@NumExt", NumExt);
            //command.Parameters.AddWithValue("@ACCION", Accion);

            bool salida = false;

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

            return salida;
        }
    }
}
