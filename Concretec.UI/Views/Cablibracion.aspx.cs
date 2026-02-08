using System;
using System.Collections.Generic;
using System.Web.UI;
using Telerik.Web.UI;
using Concretec.Pedidos.BE;
using Concretec.Agentes;
using System.Text;

public partial class Views_Cablibracion : System.Web.UI.Page
{
    public Usuario DatosUsuario
    {
        get
        {

            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
            return Login[0];
        }

    }

    public DateTime fechainiciolecturas
    {
        get
        {
            DateTime salida = DateTime.Now.AddDays(-1);
            if (dtDesde.DateInput.Text != "")
            {
                salida = DateTime.Parse(dtDesde.DateInput.Text.Substring(0, 10));
            }

            return salida;
        }
    }

    public DateTime fechafinlecturas
    {
        get
        {
            DateTime salida = DateTime.Now;
            if (dthasta.DateInput.Text != "")
            {
                salida = DateTime.Parse(dthasta.DateInput.Text.Substring(0, 10));
            }

            return salida;

        }
    }

    public DateTime fechadeRegistro
    {
        get
        {
            DateTime salida = DateTime.Now;
            if (dtfechaRegistro.DateInput.Text != "")
            {
                salida = DateTime.Parse(dtfechaRegistro.DateInput.Text.Substring(0, 10));
            }

            return salida;

        }
    }

    public string ciudadRegistro
    { get { return CboCiudadRegistro.SelectedValue.ToString(); } }

    public string ciudadFiltro
    { get { return cboCiudadFiltro.SelectedValue.ToString(); } }

    public int plantaFiltro
    { get { return int.Parse(cboPlantaFiltro.SelectedValue.ToString()); } }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        try
        {
            this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
        }
        catch
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Usuario> Login = new List<Usuario>();
        Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
        if (Login == null)
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }
        else
        {

            if (IsPostBack != true)
            {
                CargaCiudades();
                CargaPlantas(ciudadFiltro, "Filtro");
                CargaPlantas(ciudadRegistro, "Registro");
                llenaGridLecturas();
                DateTime Hoy = DateTime.Now.Date;

                //Seccion de Lecturas
                dtDesde.SelectedDate = DateTime.Now.AddDays(-3);
                dthasta.SelectedDate = DateTime.Now;

                cmdGuardarTanque.Enabled = true;
                ImageButton1.Enabled = true;

            }
        }
    }

    protected void cboCiudadFiltro_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        CargaPlantas(ciudadFiltro, "Filtro");
    }

    protected void CboCiudadRegistro_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        CargaPlantas(ciudadRegistro, "Registro");
    }

    protected void cmdbuscar_Click(object sender, ImageClickEventArgs e)
    {
        llenaGridLecturas();
    }

    protected void cmdnuevo_Click(object sender, ImageClickEventArgs e)
    {
        tblRegistroCalibracion.Visible = true;
        tblRegistro.Visible = true;
        //-------- Desactivar la otra tabla
        tblFiltros.Visible = false;
        tblresultados.Visible = false;

        this.dtfechaRegistro.SelectedDate = DateTime.Now;
        drLecturaHora.SelectedDate = DateTime.Now;

        LimpiaCaptura();
        habilitacaptura();

        cmdGuardarTanque.Enabled = true;
        ImageButton1.Enabled = true;
    }



    private string Validacaptura()
    {


        StringBuilder sb = new StringBuilder();

        if (CboCiudadRegistro.SelectedValue == "-1")
        {
            sb.Append("Es necesario seleccionar una ciudad");
            sb.Append("<br />");
        }

        if (CboPlantaRegistro.SelectedValue == "-1")
        {
            sb.Append("Es necesario seleccionar una planta");
            sb.Append("<br />");
        }

        Concretec.Pedidos.BE.Calibracion entidad = CalculaEntidadLectura();

        //Datos de Bloque Cemento
        #region Bloque_Cemento

        if ((entidad.CEM_CB2_Bajo == 0 || entidad.CEM_TEO_Bajo == 0 || entidad.CEM_CB2_Alto == 0 || entidad.CEM_TEO_Alto == 0) && (Math.Abs(entidad.CEM_CB2_Bajo) + Math.Abs(entidad.CEM_TEO_Bajo) + Math.Abs(entidad.CEM_CB2_Alto) + Math.Abs(entidad.CEM_TEO_Alto) > 0))
        {
            sb.Append("Es necesario que todos los valores del Cemento sean capturados");
            sb.Append("<br />");
        }
        #endregion

        //Datos de Bloque Agregados
        #region Bloque_Agregados

        if (
            (entidad.AGR_CB2_Bajo == 0 || entidad.AGR_TEO_Bajo == 0 || entidad.AGR_CB2_Alto == 0 || entidad.AGR_TEO_Alto == 0) &&
            (Math.Abs(entidad.AGR_CB2_Bajo) + Math.Abs(entidad.AGR_TEO_Bajo) + Math.Abs(entidad.AGR_CB2_Alto) + Math.Abs(entidad.AGR_TEO_Alto) > 0)
            )
        {
            sb.Append("Es necesario que todos los valores del Agregados sean capturados");
            sb.Append("<br />");
        }

        #endregion

        //Datos de Bloque Agua
        #region Bloque_Agua

        // if ((entidad.AGU_CB2_Bajo == 0 || entidad.AGU_TEO_Bajo == 0 || entidad.AGU_CB2_Alto == 0 || entidad.AGU_TEO_Alto == 0) && (Math.Abs(entidad.AGU_CB2_Bajo) + Math.Abs(entidad.AGU_TEO_Bajo) + Math.Abs(entidad.AGU_CB2_Alto) + Math.Abs(entidad.AGU_TEO_Alto) > 0))
        if ((entidad.AGU_CB2_Alto == 0 || entidad.AGU_TEO_Alto == 0) && (Math.Abs(entidad.AGU_CB2_Alto) + Math.Abs(entidad.AGU_TEO_Alto) > 0))
        {
            sb.Append("Es necesario que todos los valores Altos del Agua sean capturados");
            sb.Append("<br />");
        }

        #endregion

        //Datos de Aditivo 1
        #region Aditivo_1

        if (
            (entidad.AD1_CB2_Bajo == 0 || entidad.AD1_TEO_Bajo == 0 || entidad.AD1_CB2_Alto == 0 || entidad.AD1_TEO_Alto == 0) &&
            (Math.Abs(entidad.AD1_CB2_Bajo) + Math.Abs(entidad.AD1_TEO_Bajo) + Math.Abs(entidad.AD1_CB2_Alto) + Math.Abs(entidad.AD1_TEO_Alto) > 0)
           )
        {
            sb.Append("Es necesario que todos los valores del Aditivo 1 sean capturados");
            sb.Append("<br />");
        }
        #endregion

        //Datos de Aditivo 2
        #region Aditivo_2
        if (
            (Math.Abs(entidad.AD2_CB2_Bajo) + Math.Abs(entidad.AD2_TEO_Bajo) + Math.Abs(entidad.AD2_CB2_Alto) + Math.Abs(entidad.AD2_TEO_Alto) > 0) &&
            (entidad.AD2_CB2_Bajo == 0 || entidad.AD2_TEO_Bajo == 0 || entidad.AD2_CB2_Alto == 0 || entidad.AD2_TEO_Alto == 0)
            )
        {
            sb.Append("Es necesario que todos los valores del Aditivo 2 sean capturados");
            sb.Append("<br />");
        }
        #endregion

        //Datos de Aditivo 3
        #region Aditivo_3

        if (
              (Math.Abs(entidad.AD3_CB2_Bajo) + Math.Abs(entidad.AD3_TEO_Bajo) + Math.Abs(entidad.AD3_CB2_Alto) + Math.Abs(entidad.AD3_TEO_Alto) > 0) &&
              (entidad.AD3_CB2_Bajo == 0 || entidad.AD3_TEO_Bajo == 0 || entidad.AD3_CB2_Alto == 0 || entidad.AD3_TEO_Alto == 0)
           )
        {
            sb.Append("Es necesario que todos los valores del Aditivo 3 sean capturados");
            sb.Append("<br />");
        }
        #endregion

        //Datos de Aditivo 4
        #region Aditivo_4

        if ((entidad.AD4_CB2_Bajo == 0 || entidad.AD4_TEO_Bajo == 0 || entidad.AD4_CB2_Alto == 0 || entidad.AD4_TEO_Alto == 0) &&

         (Math.Abs(entidad.AD4_CB2_Bajo) + Math.Abs(entidad.AD4_TEO_Bajo) + Math.Abs(entidad.AD4_CB2_Alto) + Math.Abs(entidad.AD4_TEO_Alto) > 0)
        )
        {
            sb.Append("Es necesario que todos los valores del Aditivo 4 sean capturados");
            sb.Append("<br />");
        }
        #endregion

        //Datos de Aditivo 5
        #region Aditivo_5
        if (
                (entidad.AD5_CB2_Bajo == 0 || entidad.AD5_TEO_Bajo == 0 || entidad.AD5_CB2_Alto == 0 || entidad.AD5_TEO_Alto == 0) &&
                (Math.Abs(entidad.AD5_CB2_Bajo) + Math.Abs(entidad.AD5_TEO_Bajo) + Math.Abs(entidad.AD5_CB2_Alto) + Math.Abs(entidad.AD5_TEO_Alto) > 0)
            )
        {
            sb.Append("Es necesario que todos los valores del Aditivo 5 sean capturados");
            sb.Append("<br />");
        }
        #endregion


        if (
            Math.Abs(entidad.CEM_CB2_Bajo) + Math.Abs(entidad.CEM_TEO_Bajo) + Math.Abs(entidad.CEM_CB2_Alto) + Math.Abs(entidad.CEM_TEO_Alto) +
            Math.Abs(entidad.AGR_CB2_Bajo) + Math.Abs(entidad.AGR_TEO_Bajo) + Math.Abs(entidad.AGR_CB2_Alto) + Math.Abs(entidad.AGR_TEO_Alto) +
            Math.Abs(entidad.AGU_CB2_Bajo) + Math.Abs(entidad.AGU_TEO_Bajo) + Math.Abs(entidad.AGU_CB2_Alto) + Math.Abs(entidad.AGU_TEO_Alto) +
            Math.Abs(entidad.AD1_CB2_Bajo) + Math.Abs(entidad.AD1_TEO_Bajo) + Math.Abs(entidad.AD1_CB2_Alto) + Math.Abs(entidad.AD1_TEO_Alto) +
            Math.Abs(entidad.AD2_CB2_Bajo) + Math.Abs(entidad.AD2_TEO_Bajo) + Math.Abs(entidad.AD2_CB2_Alto) + Math.Abs(entidad.AD2_TEO_Alto) +
            Math.Abs(entidad.AD3_CB2_Bajo) + Math.Abs(entidad.AD3_TEO_Bajo) + Math.Abs(entidad.AD3_CB2_Alto) + Math.Abs(entidad.AD3_TEO_Alto) +
            Math.Abs(entidad.AD4_CB2_Bajo) + Math.Abs(entidad.AD4_TEO_Bajo) + Math.Abs(entidad.AD4_CB2_Alto) + Math.Abs(entidad.AD4_TEO_Alto) +
            Math.Abs(entidad.AD5_CB2_Bajo) + Math.Abs(entidad.AD5_TEO_Bajo) + Math.Abs(entidad.AD5_CB2_Alto) + Math.Abs(entidad.AD5_TEO_Alto) == 0
            )
        {
            sb.Append("Es necesario capturar algun valor de captura");
            sb.Append("<br />");
        }

        return sb.ToString();
    }

    public Concretec.Pedidos.BE.Calibracion CalculaEntidadLectura()
    {
        Concretec.Pedidos.BE.Calibracion entidad = new Concretec.Pedidos.BE.Calibracion();

        entidad.CveCiudad = ciudadRegistro;
        entidad.PlantaId = int.Parse(CboPlantaRegistro.SelectedValue);
        entidad.Fecha = fechadeRegistro;
        entidad.Hora = DateTime.Parse(drLecturaHora.SelectedDate.ToString()); ;
        entidad.FechaRegistro = DateTime.Now;
        entidad.UsuarioId = DatosUsuario.Id_Usuario;


        #region Bloque_Cemento
        if (TXT_CEM_CB2_ALTO.Text != string.Empty && TXT_CEM_CB2_ALTO.Text != null)
        {
            entidad.CEM_CB2_Alto = float.Parse(TXT_CEM_CB2_ALTO.Text);
        }
        else
        {
            entidad.CEM_CB2_Alto = 0;
        }

        if (TXT_CEM_CB2_BAJO.Text != string.Empty && TXT_CEM_CB2_BAJO.Text != null)
        {
            entidad.CEM_CB2_Bajo = float.Parse(TXT_CEM_CB2_BAJO.Text);
        }
        else
        {
            entidad.CEM_CB2_Bajo = 0;
        }

        if (TXT_CEM_TEO_ALTO.Text != string.Empty && TXT_CEM_TEO_ALTO.Text != null)
        {
            entidad.CEM_TEO_Alto = float.Parse(TXT_CEM_TEO_ALTO.Text);
        }
        else
        {
            entidad.CEM_TEO_Alto = 0;
        }

        if (TXT_CEM_TEO_BAJO.Text != string.Empty && TXT_CEM_TEO_BAJO.Text != null)
        {
            entidad.CEM_TEO_Bajo = float.Parse(TXT_CEM_TEO_BAJO.Text);
        }
        else
        {
            entidad.CEM_TEO_Bajo = 0;
        }

        #endregion

        #region Agregados
        if (TXT_AGR_CB2_ALTO.Text != string.Empty && TXT_AGR_CB2_ALTO.Text != null)
        {
            entidad.AGR_CB2_Alto = float.Parse(TXT_AGR_CB2_ALTO.Text);
        }
        else
        {
            entidad.AGR_CB2_Alto = 0;
        }

        if (TXT_AGR_CB2_BAJO.Text != string.Empty && TXT_AGR_CB2_BAJO.Text != null)
        {
            entidad.AGR_CB2_Bajo = float.Parse(TXT_AGR_CB2_BAJO.Text);
        }
        else
        {
            entidad.AGR_CB2_Bajo = 0;
        }

        if (TXT_AGR_TEO_ALTO.Text != string.Empty && TXT_AGR_TEO_ALTO.Text != null)
        {
            entidad.AGR_TEO_Alto = float.Parse(TXT_AGR_TEO_ALTO.Text);
        }
        else
        {
            entidad.AGR_TEO_Alto = 0;
        }

        if (TXT_AGR_TEO_BAJO.Text != string.Empty && TXT_AGR_TEO_BAJO.Text != null)
        {
            entidad.AGR_TEO_Bajo = float.Parse(TXT_AGR_TEO_BAJO.Text);
        }
        else
        {
            entidad.AGR_TEO_Bajo = 0;
        }
        #endregion

        #region Bloque_Agua
        if (TXT_AGU_CB2_ALTO.Text != string.Empty && TXT_AGU_CB2_ALTO.Text != null)
        {
            entidad.AGU_CB2_Alto = float.Parse(TXT_AGU_CB2_ALTO.Text);
        }
        else
        {
            entidad.AGU_CB2_Alto = 0;
        }

        if (TXT_AGU_CB2_BAJO.Text != string.Empty && TXT_AGU_CB2_BAJO.Text != null)
        {
            entidad.AGU_CB2_Bajo = float.Parse(TXT_AGU_CB2_BAJO.Text);
        }
        else
        {
            entidad.AGU_CB2_Bajo = 0;
        }

        if (TXT_AGU_TEO_ALTO.Text != string.Empty && TXT_AGU_TEO_ALTO.Text != null)
        {
            entidad.AGU_TEO_Alto = float.Parse(TXT_AGU_TEO_ALTO.Text);
        }
        else
        {
            entidad.AGU_TEO_Alto = 0;
        }

        if (TXT_AGU_TEO_BAJO.Text != string.Empty && TXT_AGU_TEO_BAJO.Text != null)
        {
            entidad.AGU_TEO_Bajo = float.Parse(TXT_AGU_TEO_BAJO.Text);
        }
        else
        {
            entidad.AGU_TEO_Bajo = 0;
        }

        #endregion

        #region Aditivo_1

        if (TXT_AD1_CB2_ALTO.Text != string.Empty && TXT_AD1_CB2_ALTO.Text != null)
        {
            entidad.AD1_CB2_Alto = float.Parse(TXT_AD1_CB2_ALTO.Text);
        }
        else
        {
            entidad.AD1_CB2_Alto = 0;
        }

        if (TXT_AD1_CB2_BAJO.Text != string.Empty && TXT_AD1_CB2_BAJO.Text != null)
        {
            entidad.AD1_CB2_Bajo = float.Parse(TXT_AD1_CB2_BAJO.Text);
        }
        else
        {
            entidad.AD1_CB2_Bajo = 0;
        }

        if (TXT_AD1_TEO_ALTO.Text != string.Empty && TXT_AD1_TEO_ALTO.Text != null)
        {
            entidad.AD1_TEO_Alto = float.Parse(TXT_AD1_TEO_ALTO.Text);
        }
        else
        {
            entidad.AD1_TEO_Alto = 0;
        }

        if (TXT_AD1_TEO_BAJO.Text != string.Empty && TXT_AD1_TEO_BAJO.Text != null)
        {
            entidad.AD1_TEO_Bajo = float.Parse(TXT_AD1_TEO_BAJO.Text);
        }
        else
        {
            entidad.AD1_TEO_Bajo = 0;
        }

        #endregion

        #region Aditivo_2
        if (TXT_AD2_CB2_ALTO.Text != string.Empty && TXT_AD2_CB2_ALTO.Text != null)
        {
            entidad.AD2_CB2_Alto = float.Parse(TXT_AD2_CB2_ALTO.Text);
        }
        else
        {
            entidad.AD2_CB2_Alto = 0;
        }

        if (TXT_AD2_CB2_BAJO.Text != string.Empty && TXT_AD2_CB2_BAJO.Text != null)
        {
            entidad.AD2_CB2_Bajo = float.Parse(TXT_AD2_CB2_BAJO.Text);
        }
        else
        {
            entidad.AD2_CB2_Bajo = 0;
        }

        if (TXT_AD2_TEO_ALTO.Text != string.Empty && TXT_AD2_TEO_ALTO.Text != null)
        {
            entidad.AD2_TEO_Alto = float.Parse(TXT_AD2_TEO_ALTO.Text);
        }
        else
        {
            entidad.AD2_TEO_Alto = 0;
        }

        if (TXT_AD2_TEO_BAJO.Text != string.Empty && TXT_AD2_TEO_BAJO.Text != null)
        {
            entidad.AD2_TEO_Bajo = float.Parse(TXT_AD2_TEO_BAJO.Text);
        }
        else
        {
            entidad.AD2_TEO_Bajo = 0;
        }

        #endregion

        #region Aditivo_3
        if (TXT_AD3_CB2_ALTO.Text != string.Empty && TXT_AD3_CB2_ALTO.Text != null)
        {
            entidad.AD3_CB2_Alto = float.Parse(TXT_AD3_CB2_ALTO.Text);
        }
        else
        {
            entidad.AD3_CB2_Alto = 0;
        }

        if (TXT_AD3_CB2_BAJO.Text != string.Empty && TXT_AD3_CB2_BAJO.Text != null)
        {
            entidad.AD3_CB2_Bajo = float.Parse(TXT_AD3_CB2_BAJO.Text);
        }
        else
        {
            entidad.AD3_CB2_Bajo = 0;
        }

        if (TXT_AD3_TEO_ALTO.Text != string.Empty && TXT_AD3_TEO_ALTO.Text != null)
        {
            entidad.AD3_TEO_Alto = float.Parse(TXT_AD3_TEO_ALTO.Text);
        }
        else
        {
            entidad.AD3_TEO_Alto = 0;
        }

        if (TXT_AD3_TEO_BAJO.Text != string.Empty && TXT_AD3_TEO_BAJO.Text != null)
        {
            entidad.AD3_TEO_Bajo = float.Parse(TXT_AD3_TEO_BAJO.Text);
        }
        else
        {
            entidad.AD3_TEO_Bajo = 0;
        }

        #endregion

        #region Aditivo_4
        if (TXT_AD4_CB2_ALTO.Text != string.Empty && TXT_AD4_CB2_ALTO.Text != null)
        {
            entidad.AD4_CB2_Alto = float.Parse(TXT_AD4_CB2_ALTO.Text);
        }
        else
        {
            entidad.AD4_CB2_Alto = 0;
        }

        if (TXT_AD4_CB2_BAJO.Text != string.Empty && TXT_AD4_CB2_BAJO.Text != null)
        {
            entidad.AD4_CB2_Bajo = float.Parse(TXT_AD4_CB2_BAJO.Text);
        }
        else
        {
            entidad.AD4_CB2_Bajo = 0;
        }

        if (TXT_AD4_TEO_ALTO.Text != string.Empty && TXT_AD4_TEO_ALTO.Text != null)
        {
            entidad.AD4_TEO_Alto = float.Parse(TXT_AD4_TEO_ALTO.Text);
        }
        else
        {
            entidad.AD4_TEO_Alto = 0;
        }

        if (TXT_AD4_TEO_BAJO.Text != string.Empty && TXT_AD4_TEO_BAJO.Text != null)
        {
            entidad.AD4_TEO_Bajo = float.Parse(TXT_AD4_TEO_BAJO.Text);
        }
        else
        {
            entidad.AD4_TEO_Bajo = 0;
        }

        #endregion

        #region Aditivo_5
        if (TXT_AD5_CB2_ALTO.Text != string.Empty && TXT_AD5_CB2_ALTO.Text != null)
        {
            entidad.AD5_CB2_Alto = float.Parse(TXT_AD5_CB2_ALTO.Text);
        }
        else
        {
            entidad.AD5_CB2_Alto = 0;
        }

        if (TXT_AD5_CB2_BAJO.Text != string.Empty && TXT_AD5_CB2_BAJO.Text != null)
        {
            entidad.AD5_CB2_Bajo = float.Parse(TXT_AD5_CB2_BAJO.Text);
        }
        else
        {
            entidad.AD5_CB2_Bajo = 0;
        }

        if (TXT_AD5_TEO_ALTO.Text != string.Empty && TXT_AD5_TEO_ALTO.Text != null)
        {
            entidad.AD5_TEO_Alto = float.Parse(TXT_AD5_TEO_ALTO.Text);
        }
        else
        {
            entidad.AD5_TEO_Alto = 0;
        }

        if (TXT_AD5_TEO_BAJO.Text != string.Empty && TXT_AD5_TEO_BAJO.Text != null)
        {
            entidad.AD5_TEO_Bajo = float.Parse(TXT_AD5_TEO_BAJO.Text);
        }
        else
        {
            entidad.AD5_TEO_Bajo = 0;
        }

        #endregion

        return entidad;
    }

    protected void cmdGuardarTanque_Click(object sender, ImageClickEventArgs e)
    {
        Concretec.Pedidos.BE.Calibracion entidad = new Concretec.Pedidos.BE.Calibracion();
        string mensajes = Validacaptura();
        string mensajes_descalibra = "Equipo Descalibrado, avisar a su jefe inmediato";
        bool descalibrado = false;
        if (mensajes.Trim().Length == 0)
        {
            
            entidad = CalculaEntidadLectura();

            AgenteCalibracion Agente = new AgenteCalibracion();
            bool resultado = true;
            resultado = Agente.InsertaCalibracion(entidad);
            if (resultado)
            {
                mensajes = string.Empty;
                mensajes = "La lectura ha sido guardada con éxito.Proceda a enviar las imágenes de forma electrónica al Departamento de Operaciones Nacional.";
                ValoresRangoError(entidad);
                bloqueaCaptura();
                // Aqui hay que validar lo del mensajito ese para cuando hay una descalibracion

                #region Etiquetas_Cemento
                if (entidad.CEM_CB2_Bajo != 0 && entidad.CEM_TEO_Bajo != 0 && entidad.CEM_CB2_Alto != 0 && entidad.CEM_TEO_Alto != 0)
                {
                    entidad.CEM_ERR_Bajo = ((entidad.CEM_CB2_Bajo - entidad.CEM_TEO_Bajo) / entidad.CEM_TEO_Bajo) * 100;
                    entidad.CEM_ERR_Alto = ((entidad.CEM_CB2_Alto - entidad.CEM_TEO_Alto) / entidad.CEM_TEO_Alto) * 100;

                    if (entidad.CEM_ERR_Bajo > 3 || entidad.CEM_ERR_Bajo < -3)
                    {
                        descalibrado = true;
                    }
                    else if (entidad.CEM_ERR_Alto > 3 || entidad.CEM_ERR_Alto < -3)
                    {
                        descalibrado = true;
                    }
                    
                }
                #endregion

                #region Etiquetas_Agregados
                if (entidad.AGR_CB2_Bajo != 0 && entidad.AGR_TEO_Bajo != 0 && entidad.AGR_CB2_Alto != 0 && entidad.AGR_TEO_Alto != 0)
                {
                    entidad.AGR_ERR_Bajo = ((entidad.AGR_CB2_Bajo - entidad.AGR_TEO_Bajo) / entidad.AGR_TEO_Bajo) * 100;
                    entidad.AGR_ERR_Alto = ((entidad.AGR_CB2_Alto - entidad.AGR_TEO_Alto) / entidad.AGR_TEO_Alto) * 100;

                    if (entidad.AGR_ERR_Bajo > 1 || entidad.AGR_ERR_Bajo < -1)
                    {
                        descalibrado = true;
                    }
                    else if (entidad.AGR_ERR_Alto > 3 || entidad.AGR_ERR_Alto < -3)
                    {
                        descalibrado = true;
                    }

                }
                #endregion

                #region Etiquetas_Agua
                if (entidad.AGU_CB2_Bajo != 0 && entidad.AGU_TEO_Bajo != 0)
                {
                    entidad.AGU_ERR_Bajo = ((entidad.AGU_CB2_Bajo - entidad.AGU_TEO_Bajo) / entidad.AGU_TEO_Bajo) * 100;

                    if (entidad.AGU_ERR_Bajo > 1 || entidad.AGU_ERR_Bajo < -1)
                    {
                        descalibrado = true;
                    }
                    
                }

                if (entidad.AGU_CB2_Alto != 0 && entidad.AGU_TEO_Alto != 0)
                {
                    entidad.AGU_ERR_Alto = ((entidad.AGU_CB2_Alto - entidad.AGU_TEO_Alto) / entidad.AGU_TEO_Alto) * 100;

                    if (entidad.CEM_ERR_Alto > 3 || entidad.CEM_ERR_Alto < -3)
                    {
                        descalibrado = true;
                    }

                }
                #endregion

                #region Etiquetas_AD1
                if (entidad.AD1_CB2_Bajo != 0 && entidad.AD1_TEO_Bajo != 0 && entidad.AD1_CB2_Alto != 0 && entidad.AD1_TEO_Alto != 0)
                {
                    entidad.AD1_ERR_Bajo = ((entidad.AD1_CB2_Bajo - entidad.AD1_TEO_Bajo) / entidad.AD1_TEO_Bajo) * 100;
                    entidad.AD1_ERR_Alto = ((entidad.AD1_CB2_Alto - entidad.AD1_TEO_Alto) / entidad.AD1_TEO_Alto) * 100;


                    if (entidad.AD1_ERR_Bajo > 3 || entidad.AD1_ERR_Bajo < -3)
                    {
                        descalibrado = true;
                    }
                    else if (entidad.AD1_ERR_Alto > 3 || entidad.AD1_ERR_Alto < -3)
                    {
                        descalibrado = true;
                    }

                }
                #endregion

                #region Etiquetas_AD2
                if (entidad.AD2_CB2_Bajo != 0 && entidad.AD2_TEO_Bajo != 0 && entidad.AD2_CB2_Alto != 0 && entidad.AD2_TEO_Alto != 0)
                {
                    entidad.AD2_ERR_Bajo = ((entidad.AD2_CB2_Bajo - entidad.AD2_TEO_Bajo) / entidad.AD2_TEO_Bajo) * 100;
                    entidad.AD2_ERR_Alto = ((entidad.AD2_CB2_Alto - entidad.AD2_TEO_Alto) / entidad.AD2_TEO_Alto) * 100;

                    if (entidad.AD2_ERR_Bajo > 3 || entidad.AD2_ERR_Bajo < -3)
                    {
                        descalibrado = true;
                    }
                    else if (entidad.AD2_ERR_Alto > 3 || entidad.AD2_ERR_Alto < -3)
                    {
                        descalibrado = true;
                    }
                    
                }
                #endregion

                #region Etiquetas_AD3
                if (entidad.AD3_CB2_Bajo != 0 && entidad.AD3_TEO_Bajo != 0 && entidad.AD3_CB2_Alto != 0 && entidad.AD3_TEO_Alto != 0)
                {
                    entidad.AD3_ERR_Bajo = ((entidad.AD3_CB2_Bajo - entidad.AD3_TEO_Bajo) / entidad.AD3_TEO_Bajo) * 100;
                    entidad.AD3_ERR_Alto = ((entidad.AD3_CB2_Alto - entidad.AD3_TEO_Alto) / entidad.AD3_TEO_Alto) * 100;

                    if (entidad.AD3_ERR_Bajo > 3 || entidad.AD3_ERR_Bajo < -3)
                    {
                        descalibrado = true;
                    }
                    else if (entidad.AD3_ERR_Alto > 3 || entidad.AD3_ERR_Alto < -3)
                    {
                        descalibrado = true;
                    }
                }
                #endregion

                #region Etiquetas_AD4
                if (entidad.AD4_CB2_Bajo != 0 && entidad.AD4_TEO_Bajo != 0 && entidad.AD4_CB2_Alto != 0 && entidad.AD4_TEO_Alto != 0)
                {
                    entidad.AD4_ERR_Bajo = ((entidad.AD4_CB2_Bajo - entidad.AD4_TEO_Bajo) / entidad.AD4_TEO_Bajo) * 100;
                    entidad.AD4_ERR_Alto = ((entidad.AD4_CB2_Alto - entidad.AD4_TEO_Alto) / entidad.AD4_TEO_Alto) * 100;

                    if (entidad.AD4_ERR_Bajo > 3 || entidad.AD4_ERR_Bajo < -3)
                    {
                        descalibrado = true;
                    }
                    else if (entidad.AD4_ERR_Alto > 3 || entidad.AD4_ERR_Alto < -3)
                    {
                        descalibrado = true;
                    }
                }
                #endregion

                #region Etiquetas_AD5
                if (entidad.AD5_CB2_Bajo != 0 && entidad.AD5_TEO_Bajo != 0 && entidad.AD5_CB2_Alto != 0 && entidad.AD5_TEO_Alto != 0)
                {
                    entidad.AD5_ERR_Bajo = ((entidad.AD5_CB2_Bajo - entidad.AD5_TEO_Bajo) / entidad.AD5_TEO_Bajo) * 100;
                    entidad.AD5_ERR_Alto = ((entidad.AD5_CB2_Alto - entidad.AD5_TEO_Alto) / entidad.AD5_TEO_Alto) * 100;

                    if (entidad.AD5_ERR_Bajo > 3 || entidad.AD5_ERR_Bajo < -3)
                    {
                        descalibrado = true;
                    }
                    else if (entidad.AD5_ERR_Alto > 3 || entidad.AD5_ERR_Alto < -3)
                    {
                        descalibrado = true;
                    }
                    
                }
                #endregion

                if (descalibrado)
                {
                    mensajes = mensajes + mensajes_descalibra;
                }

                // Aqui termina el mensaje
                Alert.Show(mensajes);
            }
            else
            {
                Alert.Show("Ocurrio un error al registrar la lectura, contacte a su administrador");
            }

            
        }
        else
        {
            lblMensajes.Text = mensajes.ToString().Trim();
        }
    }

    protected void cmdbacktanque_Click(object sender, ImageClickEventArgs e)
    {

        LimpiaCaptura();

        tblRegistroCalibracion.Visible = false;
        tblRegistro.Visible = false;
        //-------- Desactivar la otra tabla
        tblFiltros.Visible = true;
        tblresultados.Visible = true;


    }

    private void ValoresRangoError(Concretec.Pedidos.BE.Calibracion entidad)
    {
        #region Etiquetas_Cemento
        if (entidad.CEM_CB2_Bajo != 0 && entidad.CEM_TEO_Bajo != 0 && entidad.CEM_CB2_Alto != 0 && entidad.CEM_TEO_Alto != 0)
        {
            entidad.CEM_ERR_Bajo = ((entidad.CEM_CB2_Bajo - entidad.CEM_TEO_Bajo) / entidad.CEM_TEO_Bajo) * 100;
            entidad.CEM_ERR_Alto = ((entidad.CEM_CB2_Alto - entidad.CEM_TEO_Alto) / entidad.CEM_TEO_Alto) * 100;

            LBL_CEM_ERR_BAJO.Text = entidad.CEM_ERR_Bajo.ToString("####0.00") + " %";
            LBL_CEM_ERR_ALTO.Text = entidad.CEM_ERR_Alto.ToString("####0.00") + " %";

            if (entidad.CEM_ERR_Bajo > 3 || entidad.CEM_ERR_Bajo < -3)
            {
                LBL_CEM_ERR_BAJO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_CEM_ERR_BAJO.ForeColor = System.Drawing.Color.Black;
            }

            if (entidad.CEM_ERR_Alto > 3 || entidad.CEM_ERR_Alto < -3)
            {
                LBL_CEM_ERR_ALTO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_CEM_ERR_ALTO.ForeColor = System.Drawing.Color.Black;
            }
        }
        #endregion

        #region Etiquetas_Agregados
        if (entidad.AGR_CB2_Bajo != 0 && entidad.AGR_TEO_Bajo != 0 && entidad.AGR_CB2_Alto != 0 && entidad.AGR_TEO_Alto != 0)
        {
            entidad.AGR_ERR_Bajo = ((entidad.AGR_CB2_Bajo - entidad.AGR_TEO_Bajo) / entidad.AGR_TEO_Bajo) * 100;
            entidad.AGR_ERR_Alto = ((entidad.AGR_CB2_Alto - entidad.AGR_TEO_Alto) / entidad.AGR_TEO_Alto) * 100;

            LBL_AGR_ERR_BAJO.Text = entidad.AGR_ERR_Bajo.ToString("####0.00") + " %";
            LBL_AGR_ERR_ALTO.Text = entidad.AGR_ERR_Alto.ToString("####0.00") + " %";

            if (entidad.AGR_ERR_Bajo > 1 || entidad.AGR_ERR_Bajo < -1)
            {
                LBL_AGR_ERR_BAJO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_AGR_ERR_BAJO.ForeColor = System.Drawing.Color.Black;
            }

            if (entidad.AGR_ERR_Alto > 3 || entidad.AGR_ERR_Alto < -3)
            {
                LBL_AGR_ERR_ALTO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_AGR_ERR_ALTO.ForeColor = System.Drawing.Color.Black;
            }
        }
        #endregion

        #region Etiquetas_Agua
        if (entidad.AGU_CB2_Bajo != 0 && entidad.AGU_TEO_Bajo != 0)
        {
            entidad.AGU_ERR_Bajo = ((entidad.AGU_CB2_Bajo - entidad.AGU_TEO_Bajo) / entidad.AGU_TEO_Bajo) * 100;
            LBL_AGU_ERR_BAJO.Text = entidad.AGU_ERR_Bajo.ToString("####0.00") + " %";

            if (entidad.AGU_ERR_Bajo > 1 || entidad.AGU_ERR_Bajo < -1)
            {
                LBL_AGU_ERR_BAJO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_AGU_ERR_BAJO.ForeColor = System.Drawing.Color.Black;
            }
        }

        if (entidad.AGU_CB2_Alto != 0 && entidad.AGU_TEO_Alto != 0)
        {
            entidad.AGU_ERR_Alto = ((entidad.AGU_CB2_Alto - entidad.AGU_TEO_Alto) / entidad.AGU_TEO_Alto) * 100;
            LBL_AGU_ERR_ALTO.Text = entidad.AGU_ERR_Alto.ToString("####0.00") + " %";

            if (entidad.CEM_ERR_Alto > 3 || entidad.CEM_ERR_Alto < -3)
            {
                LBL_AGU_ERR_ALTO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_AGU_ERR_ALTO.ForeColor = System.Drawing.Color.Black;
            }
        }
        #endregion

        #region Etiquetas_AD1
        if (entidad.AD1_CB2_Bajo != 0 && entidad.AD1_TEO_Bajo != 0 && entidad.AD1_CB2_Alto != 0 && entidad.AD1_TEO_Alto != 0)
        {
            entidad.AD1_ERR_Bajo = ((entidad.AD1_CB2_Bajo - entidad.AD1_TEO_Bajo) / entidad.AD1_TEO_Bajo) * 100;
            entidad.AD1_ERR_Alto = ((entidad.AD1_CB2_Alto - entidad.AD1_TEO_Alto) / entidad.AD1_TEO_Alto) * 100;

            LBL_AD1_ERR_BAJO.Text = entidad.AD1_ERR_Bajo.ToString("####0.00") + " %";
            LBL_AD1_ERR_ALTO.Text = entidad.AD1_ERR_Alto.ToString("####0.00") + " %";

            if (entidad.AD1_ERR_Bajo > 3 || entidad.AD1_ERR_Bajo < -3)
            {
                LBL_AD1_ERR_BAJO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_AD1_ERR_BAJO.ForeColor = System.Drawing.Color.Black;
            }

            if (entidad.AD1_ERR_Alto > 3 || entidad.AD1_ERR_Alto < -3)
            {
                LBL_AD1_ERR_ALTO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_AD1_ERR_ALTO.ForeColor = System.Drawing.Color.Black;
            }
        }
        #endregion

        #region Etiquetas_AD2
        if (entidad.AD2_CB2_Bajo != 0 && entidad.AD2_TEO_Bajo != 0 && entidad.AD2_CB2_Alto != 0 && entidad.AD2_TEO_Alto != 0)
        {
            entidad.AD2_ERR_Bajo = ((entidad.AD2_CB2_Bajo - entidad.AD2_TEO_Bajo) / entidad.AD2_TEO_Bajo) * 100;
            entidad.AD2_ERR_Alto = ((entidad.AD2_CB2_Alto - entidad.AD2_TEO_Alto) / entidad.AD2_TEO_Alto) * 100;

            LBL_AD2_ERR_BAJO.Text = entidad.AD2_ERR_Bajo.ToString("####0.00") + " %";
            LBL_AD2_ERR_ALTO.Text = entidad.AD2_ERR_Alto.ToString("####0.00") + " %";

            if (entidad.AD2_ERR_Bajo > 3 || entidad.AD2_ERR_Bajo < -3)
            {
                LBL_AD2_ERR_BAJO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_AD2_ERR_BAJO.ForeColor = System.Drawing.Color.Black;
            }

            if (entidad.AD2_ERR_Alto > 3 || entidad.AD2_ERR_Alto < -3)
            {
                LBL_AD2_ERR_ALTO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_AD2_ERR_ALTO.ForeColor = System.Drawing.Color.Black;
            }
        }
        #endregion

        #region Etiquetas_AD3
        if (entidad.AD3_CB2_Bajo != 0 && entidad.AD3_TEO_Bajo != 0 && entidad.AD3_CB2_Alto != 0 && entidad.AD3_TEO_Alto != 0)
        {
            entidad.AD3_ERR_Bajo = ((entidad.AD3_CB2_Bajo - entidad.AD3_TEO_Bajo) / entidad.AD3_TEO_Bajo) * 100;
            entidad.AD3_ERR_Alto = ((entidad.AD3_CB2_Alto - entidad.AD3_TEO_Alto) / entidad.AD3_TEO_Alto) * 100;

            LBL_AD3_ERR_BAJO.Text = entidad.AD3_ERR_Bajo.ToString("####0.00") + " %";
            LBL_AD3_ERR_ALTO.Text = entidad.AD3_ERR_Alto.ToString("####0.00") + " %";

            if (entidad.AD3_ERR_Bajo > 3 || entidad.AD3_ERR_Bajo < -3)
            {
                LBL_AD3_ERR_BAJO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_AD3_ERR_BAJO.ForeColor = System.Drawing.Color.Black;
            }

            if (entidad.AD3_ERR_Alto > 3 || entidad.AD3_ERR_Alto < -3)
            {
                LBL_AD3_ERR_ALTO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_AD3_ERR_ALTO.ForeColor = System.Drawing.Color.Black;
            }
        }
        #endregion

        #region Etiquetas_AD4
        if (entidad.AD4_CB2_Bajo != 0 && entidad.AD4_TEO_Bajo != 0 && entidad.AD4_CB2_Alto != 0 && entidad.AD4_TEO_Alto != 0)
        {
            entidad.AD4_ERR_Bajo = ((entidad.AD4_CB2_Bajo - entidad.AD4_TEO_Bajo) / entidad.AD4_TEO_Bajo) * 100;
            entidad.AD4_ERR_Alto = ((entidad.AD4_CB2_Alto - entidad.AD4_TEO_Alto) / entidad.AD4_TEO_Alto) * 100;

            LBL_AD4_ERR_BAJO.Text = entidad.AD4_ERR_Bajo.ToString("####0.00") + " %";
            LBL_AD4_ERR_ALTO.Text = entidad.AD4_ERR_Alto.ToString("####0.00") + " %";

            if (entidad.AD4_ERR_Bajo > 3 || entidad.AD4_ERR_Bajo < -3)
            {
                LBL_AD4_ERR_BAJO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_AD4_ERR_BAJO.ForeColor = System.Drawing.Color.Black;
            }

            if (entidad.AD4_ERR_Alto > 3 || entidad.AD4_ERR_Alto < -3)
            {
                LBL_AD4_ERR_ALTO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_AD4_ERR_ALTO.ForeColor = System.Drawing.Color.Black;
            }
        }
        #endregion

        #region Etiquetas_AD5
        if (entidad.AD5_CB2_Bajo != 0 && entidad.AD5_TEO_Bajo != 0 && entidad.AD5_CB2_Alto != 0 && entidad.AD5_TEO_Alto != 0)
        {
            entidad.AD5_ERR_Bajo = ((entidad.AD5_CB2_Bajo - entidad.AD5_TEO_Bajo) / entidad.AD5_TEO_Bajo) * 100;
            entidad.AD5_ERR_Alto = ((entidad.AD5_CB2_Alto - entidad.AD5_TEO_Alto) / entidad.AD5_TEO_Alto) * 100;

            LBL_AD5_ERR_BAJO.Text = entidad.AD5_ERR_Bajo.ToString("####0.00") + " %";
            LBL_AD5_ERR_ALTO.Text = entidad.AD5_ERR_Alto.ToString("####0.00") + " %";

            if (entidad.AD5_ERR_Bajo > 3 || entidad.AD5_ERR_Bajo < -3)
            {
                LBL_AD5_ERR_BAJO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_AD5_ERR_BAJO.ForeColor = System.Drawing.Color.Black;
            }

            if (entidad.AD5_ERR_Alto > 3 || entidad.AD5_ERR_Alto < -3)
            {
                LBL_AD5_ERR_ALTO.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LBL_AD5_ERR_ALTO.ForeColor = System.Drawing.Color.Black;
            }
        }
        #endregion
    }

    private void LimpiaCaptura()
    {
        lblMensajes.Text = string.Empty;

        this.TXT_CEM_CB2_ALTO.Text = string.Empty;
        this.TXT_CEM_CB2_ALTO.Text = string.Empty;
        this.TXT_CEM_CB2_BAJO.Text = string.Empty;
        this.TXT_CEM_TEO_ALTO.Text = string.Empty;
        this.TXT_CEM_TEO_BAJO.Text = string.Empty;

        this.TXT_AGR_CB2_ALTO.Text = string.Empty;
        this.TXT_AGR_CB2_BAJO.Text = string.Empty;
        this.TXT_AGR_TEO_ALTO.Text = string.Empty;
        this.TXT_AGR_TEO_BAJO.Text = string.Empty;

        this.TXT_AGU_CB2_ALTO.Text = string.Empty;
        this.TXT_AGU_CB2_BAJO.Text = string.Empty;
        this.TXT_AGU_TEO_ALTO.Text = string.Empty;
        this.TXT_AGU_TEO_BAJO.Text = string.Empty;

        this.TXT_AD1_CB2_ALTO.Text = string.Empty;
        this.TXT_AD1_CB2_BAJO.Text = string.Empty;
        this.TXT_AD1_TEO_ALTO.Text = string.Empty;
        this.TXT_AD1_TEO_BAJO.Text = string.Empty;

        this.TXT_AD2_CB2_ALTO.Text = string.Empty;
        this.TXT_AD2_CB2_BAJO.Text = string.Empty;
        this.TXT_AD2_TEO_ALTO.Text = string.Empty;
        this.TXT_AD2_TEO_BAJO.Text = string.Empty;

        this.TXT_AD3_CB2_ALTO.Text = string.Empty;
        this.TXT_AD3_CB2_BAJO.Text = string.Empty;
        this.TXT_AD3_TEO_ALTO.Text = string.Empty;
        this.TXT_AD3_TEO_BAJO.Text = string.Empty;

        this.TXT_AD4_CB2_ALTO.Text = string.Empty;
        this.TXT_AD4_CB2_BAJO.Text = string.Empty;
        this.TXT_AD4_TEO_ALTO.Text = string.Empty;
        this.TXT_AD4_TEO_BAJO.Text = string.Empty;

        this.TXT_AD5_CB2_ALTO.Text = string.Empty;
        this.TXT_AD5_CB2_BAJO.Text = string.Empty;
        this.TXT_AD5_TEO_ALTO.Text = string.Empty;
        this.TXT_AD5_TEO_BAJO.Text = string.Empty;

        this.LBL_AD1_ERR_ALTO.Text = string.Empty;
        this.LBL_AD1_ERR_BAJO.Text = string.Empty;
        this.LBL_AD2_ERR_ALTO.Text = string.Empty;
        this.LBL_AD2_ERR_BAJO.Text = string.Empty;
        this.LBL_AD3_ERR_ALTO.Text = string.Empty;
        this.LBL_AD3_ERR_BAJO.Text = string.Empty;
        this.LBL_AD4_ERR_ALTO.Text = string.Empty;
        this.LBL_AD4_ERR_BAJO.Text = string.Empty;
        this.LBL_AD5_ERR_ALTO.Text = string.Empty;
        this.LBL_AD5_ERR_BAJO.Text = string.Empty;
        this.LBL_AGR_ERR_ALTO.Text = string.Empty;
        this.LBL_AGR_ERR_BAJO.Text = string.Empty;
        this.LBL_AGU_ERR_ALTO.Text = string.Empty;
        this.LBL_AGU_ERR_BAJO.Text = string.Empty;
        this.LBL_CEM_ERR_ALTO.Text = string.Empty;
        this.LBL_CEM_ERR_BAJO.Text = string.Empty;
    }

    private void habilitacaptura()
    {
        this.TXT_CEM_CB2_ALTO.Enabled = true;
        this.TXT_CEM_CB2_BAJO.Enabled = true;
        this.TXT_CEM_TEO_ALTO.Enabled = true;
        this.TXT_CEM_TEO_BAJO.Enabled = true;

        this.TXT_AGR_CB2_ALTO.Enabled = true;
        this.TXT_AGR_CB2_BAJO.Enabled = true;
        this.TXT_AGR_TEO_ALTO.Enabled = true;
        this.TXT_AGR_TEO_BAJO.Enabled = true;

        this.TXT_AGU_CB2_ALTO.Enabled = true;
        this.TXT_AGU_CB2_BAJO.Enabled = true;
        this.TXT_AGU_TEO_ALTO.Enabled = true;
        this.TXT_AGU_TEO_BAJO.Enabled = true;

        this.TXT_AD1_CB2_ALTO.Enabled = true;
        this.TXT_AD1_CB2_BAJO.Enabled = true;
        this.TXT_AD1_TEO_ALTO.Enabled = true;
        this.TXT_AD1_TEO_BAJO.Enabled = true;

        this.TXT_AD2_CB2_ALTO.Enabled = true;
        this.TXT_AD2_CB2_BAJO.Enabled = true;
        this.TXT_AD2_TEO_ALTO.Enabled = true;
        this.TXT_AD2_TEO_BAJO.Enabled = true;

        this.TXT_AD3_CB2_ALTO.Enabled = true;
        this.TXT_AD3_CB2_BAJO.Enabled = true;
        this.TXT_AD3_TEO_ALTO.Enabled = true;
        this.TXT_AD3_TEO_BAJO.Enabled = true;

        this.TXT_AD4_CB2_ALTO.Enabled = true;
        this.TXT_AD4_CB2_BAJO.Enabled = true;
        this.TXT_AD4_TEO_ALTO.Enabled = true;
        this.TXT_AD4_TEO_BAJO.Enabled = true;

        this.TXT_AD5_CB2_ALTO.Enabled = true;
        this.TXT_AD5_CB2_BAJO.Enabled = true;
        this.TXT_AD5_TEO_ALTO.Enabled = true;
        this.TXT_AD5_TEO_BAJO.Enabled = true;
    }

    private void bloqueaCaptura()
    {
        this.TXT_CEM_CB2_ALTO.Enabled = false;
        this.TXT_CEM_CB2_BAJO.Enabled = false;
        this.TXT_CEM_TEO_ALTO.Enabled = false;
        this.TXT_CEM_TEO_BAJO.Enabled = false;

        this.TXT_AGR_CB2_ALTO.Enabled = false;
        this.TXT_AGR_CB2_BAJO.Enabled = false;
        this.TXT_AGR_TEO_ALTO.Enabled = false;
        this.TXT_AGR_TEO_BAJO.Enabled = false;

        this.TXT_AGU_CB2_ALTO.Enabled = false;
        this.TXT_AGU_CB2_BAJO.Enabled = false;
        this.TXT_AGU_TEO_ALTO.Enabled = false;
        this.TXT_AGU_TEO_BAJO.Enabled = false;

        this.TXT_AD1_CB2_ALTO.Enabled = false;
        this.TXT_AD1_CB2_BAJO.Enabled = false;
        this.TXT_AD1_TEO_ALTO.Enabled = false;
        this.TXT_AD1_TEO_BAJO.Enabled = false;

        this.TXT_AD2_CB2_ALTO.Enabled = false;
        this.TXT_AD2_CB2_BAJO.Enabled = false;
        this.TXT_AD2_TEO_ALTO.Enabled = false;
        this.TXT_AD2_TEO_BAJO.Enabled = false;

        this.TXT_AD3_CB2_ALTO.Enabled = false;
        this.TXT_AD3_CB2_BAJO.Enabled = false;
        this.TXT_AD3_TEO_ALTO.Enabled = false;
        this.TXT_AD3_TEO_BAJO.Enabled = false;

        this.TXT_AD4_CB2_ALTO.Enabled = false;
        this.TXT_AD4_CB2_BAJO.Enabled = false;
        this.TXT_AD4_TEO_ALTO.Enabled = false;
        this.TXT_AD4_TEO_BAJO.Enabled = false;

        this.TXT_AD5_CB2_ALTO.Enabled = false;
        this.TXT_AD5_CB2_BAJO.Enabled = false;
        this.TXT_AD5_TEO_ALTO.Enabled = false;
        this.TXT_AD5_TEO_BAJO.Enabled = false;

        cmdGuardarTanque.Enabled = false;
        ImageButton1.Enabled = false;
    }



    private void CargaCiudades()
    {
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();
        cboCiudadFiltro.Items.Clear();
        CboCiudadRegistro.Items.Clear();

        RadComboBoxItem item = new RadComboBoxItem();
        RadComboBoxItem itemr = new RadComboBoxItem();
        RadComboBoxItem iteml = new RadComboBoxItem();
        RadComboBoxItem itemIN = new RadComboBoxItem();
        RadComboBoxItem itemCN = new RadComboBoxItem();

        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboCiudadFiltro.Items.Add(item);

        itemr = new RadComboBoxItem();
        itemr.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        itemr.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        CboCiudadRegistro.Items.Add(itemr);

        lc = ac.ObtenerCiudades();
        foreach (Ciudad c in lc)
        {
            item = new RadComboBoxItem();
            item.Text = c.Descripcion;
            item.Value = c.CveCiudad;
            cboCiudadFiltro.Items.Add(item);

            itemr = new RadComboBoxItem();
            itemr.Text = c.Descripcion;
            itemr.Value = c.CveCiudad;
            CboCiudadRegistro.Items.Add(itemr);
        }

        cboCiudadFiltro.SelectedValue = DatosUsuario.Ciudad;
        CboCiudadRegistro.SelectedValue = DatosUsuario.Ciudad;

    }

    private void CargaPlantas(string CveCiudad, string cbo_planta)
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> _planta = new List<Planta>();
        _planta = au.ObtenerPlantasObra(CveCiudad);

        if (cbo_planta == "Filtro")
        {
            cboPlantaFiltro.Items.Clear();
        }
        else
        {
            CboPlantaRegistro.Items.Clear();
        }

        RadComboBoxItem item = new RadComboBoxItem();
        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        if (cbo_planta == "Filtro")
        {
            this.cboPlantaFiltro.Items.Add(item);
        }
        else
        {
            this.CboPlantaRegistro.Items.Add(item);
        }



        foreach (Planta a in _planta)
        {
            item = new RadComboBoxItem();
            item.Text = a.Nombre;
            item.Value = a.IDPlanta.ToString();

            if (cbo_planta == "Filtro")
            {
                this.cboPlantaFiltro.Items.Add(item);
            }
            else
            {
                this.CboPlantaRegistro.Items.Add(item);
            }
        }
    }

    private void llenaGridLecturas()
    {
        gridResultados.DataSource = BuscaLecturas(); ;
        gridResultados.DataBind();
    }

    private List<Calibracion> BuscaLecturas()
    {
        List<Calibracion> salida = new List<Calibracion>();
        AgenteCalibracion ac = new AgenteCalibracion();
        salida = ac.ListaCalibraciones(fechainiciolecturas, fechafinlecturas, ciudadFiltro, plantaFiltro, -1);

        return salida;
    }


    protected void gridResultados_ItemCommand(object sender, GridCommandEventArgs e)
    {

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LimpiaCaptura();
    }

    public void Exportar()
    {
        gridResultados.ExportSettings.ExportOnlyData = true;
        gridResultados.ExportSettings.IgnorePaging = true;
        gridResultados.ExportSettings.OpenInNewWindow = false;
        gridResultados.ExportSettings.UseItemStyles = false;
        gridResultados.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;
        gridResultados.MasterTableView.ExportToExcel();
    }

    public void ConfigureExport()
    {
        gridResultados.ExportSettings.ExportOnlyData = true;
        gridResultados.ExportSettings.IgnorePaging = true;
        gridResultados.ExportSettings.FileName = "Calibracion";
        gridResultados.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;
    }


    protected void gridResultados_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    }

    protected void gridResultados_ItemCommand1(object sender, GridCommandEventArgs e)
    {

    }

    protected void gridResultados_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                string material = (e.Item.Cells[7].Text).ToUpper();
                float eAlto = float.Parse((e.Item.Cells[13].Text));
                float eBajo = float.Parse((e.Item.Cells[10].Text));

                switch (material)
                {
                    case "CEMENTO":
                        if ((eBajo > 3 || eBajo < -3) || (eAlto > 3 || eAlto < -3))
                        {
                            item.BackColor = System.Drawing.Color.Salmon;
                        }                       
                        break;
                    case "AGREGADOS":
                        if ((eBajo > 1 || eBajo < -1) || (eAlto > 1 || eAlto < -1))
                        {
                            item.BackColor = System.Drawing.Color.Salmon;
                        }
                        break;
                    case "AGUA":
                        if ((eBajo > 1 || eBajo < -1) || (eAlto > 1 || eAlto < -1))
                        {
                            item.BackColor = System.Drawing.Color.Salmon;
                        }
                        break;
                    case "ADITIVO 1":
                        if ((eBajo > 3 || eBajo < -3) || (eAlto > 3 || eAlto < -3))
                        {
                            item.BackColor = System.Drawing.Color.Salmon;
                        }
                        break;
                    case "ADITIVO 2":
                        if ((eBajo > 3 || eBajo < -3) || (eAlto > 3 || eAlto < -3))
                        {
                            item.BackColor = System.Drawing.Color.Salmon;
                        }
                        break;
                    case "ADITIVO 3":
                        if ((eBajo > 3 || eBajo < -3) || (eAlto > 3 || eAlto < -3))
                        {
                            item.BackColor = System.Drawing.Color.Salmon;
                        }
                        break;
                    case "ADITIVO 4":
                        if ((eBajo > 3 || eBajo < -3) || (eAlto > 3 || eAlto < -3))
                        {
                            item.BackColor = System.Drawing.Color.Salmon;
                        }
                        break;
                    case "ADITIVO 5":
                        if ((eBajo > 3 || eBajo < -3) || (eAlto > 3 || eAlto < -3))
                        {
                            item.BackColor = System.Drawing.Color.Salmon;
                        }
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }

    }

    protected void cmdExportar_Click1(object sender, ImageClickEventArgs e)
    {
        ConfigureExport();
        gridResultados.MasterTableView.ExportToExcel();
    }

    protected void CboPlantaRegistro_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        string planta = CboPlantaRegistro.SelectedItem.Text.ToUpper();
        switch (planta)
        {
            case "AGS1":
                TXT_AGU_TEO_ALTO.Text = "1720";
                break;
            case "AGS2":
                TXT_AGU_TEO_ALTO.Text = "1839";
                break;
            case "LEON1":
                TXT_AGU_TEO_ALTO.Text = "1720";
                break;
            case "LEON2":
                TXT_AGU_TEO_ALTO.Text = "1788";
                break;
            case "GDL1":
                TXT_AGU_TEO_ALTO.Text = "1770";
                break;
            case "GDL2":
                TXT_AGU_TEO_ALTO.Text = "1720";
                break;
            case "GDL3":
                TXT_AGU_TEO_ALTO.Text = "1828";
                break;
            case "QRO1":
                TXT_AGU_TEO_ALTO.Text = "1823";
                break;
            case "M1":
                TXT_AGU_TEO_ALTO.Text = "1630";
                break;
            case "M2":
                TXT_AGU_TEO_ALTO.Text = "1630";
                break;
            case "M3":
                TXT_AGU_TEO_ALTO.Text = "1625";
                break;
            case "M4":
                TXT_AGU_TEO_ALTO.Text = "1630";
                break;
            case "M5":
                TXT_AGU_TEO_ALTO.Text = "1694";
                break;
            case "M6":
                TXT_AGU_TEO_ALTO.Text = "1620";
                break;
            case "M7":
                TXT_AGU_TEO_ALTO.Text = "1620";
                break;
            case "M8":
                TXT_AGU_TEO_ALTO.Text = "1720";
                break;
            case "M9":
                TXT_AGU_TEO_ALTO.Text = "1630";
                break;
        }
    }
}
