using Concretec.Agentes;
using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Views_PlaneacionUnidades : System.Web.UI.Page
{
    #region Propiedades_Generales

    private DateTime startDate = DateTime.Today;
    public Usuario DatosUsuario
    {
        get
        {
            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
            return Login[0];
        }

    }

    AgenteUnidades agente = new AgenteUnidades();
    #endregion

    #region Pagina
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // ApplyAppPathModifier will add the session ID if we're using Cookieless session.
        string urlWithSessionID = Response.ApplyAppPathModifier(Request.Url.PathAndQuery);
        RadTab tab = RadTabStrip1.FindTabByUrl(urlWithSessionID);

        List<Usuario> login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
        if (login == null)
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }
        else
        {

            if (!this.IsPostBack)
            {
                CargaPlantas();
                llenaOperadores();
                llenaMotivosUnidad();
                llenaMotivosOperador();

                //rowmotivo.Visible = false;
                //rowempleado.Visible = false;

                //AgenteUnidades Agente = new AgenteUnidades();
                List<ConsultaUnidad> Lista = new List<ConsultaUnidad>();
                Lista = LeerUnidadesMovs(string.Empty, string.Empty);

                this.rgdUnidades.DataSource = Lista;
                rgdUnidades.DataBind();

                RadMultiPage1.PageViews[1].Selected = true;
                RadTab tab1 = RadTabStrip1.Tabs.FindTabByText("Unidades");
                tab1.Selected = true;

                LimpiaEdicionUnidad();
            }

        }
    }

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

    #endregion

    #region Metodos
    private bool BuscaPlaneacionDia(DateTime FechaBusqueda)
    {
        bool salida = false;

        return salida;
    }

    private void CargaPlantas()
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> _planta = new List<Planta>();
        _planta = au.ObtenerPlantasObra(DatosUsuario.Ciudad);
        this.CboPlantaBusqueda.Items.Clear();
        this.cboPlantaEdicion.Items.Clear();

        RadComboBoxItem item = new RadComboBoxItem();
        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.CboPlantaBusqueda.Items.Add(item);

        RadComboBoxItem item_pta = new RadComboBoxItem();
        item_pta = new RadComboBoxItem();
        item_pta.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item_pta.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboPlantaEdicion.Items.Add(item_pta);

        foreach (Planta a in _planta)
        {
            item_pta = new RadComboBoxItem();
            item_pta.Text = a.CvePlanta;
            item_pta.Value = a.IDPlanta.ToString();
            this.cboPlantaEdicion.Items.Add(item_pta);

            item = new RadComboBoxItem();
            item.Text = a.CvePlanta;
            item.Value = a.IDPlanta.ToString();
            this.CboPlantaBusqueda.Items.Add(item);
        }


    }

    void llenaMotivosUnidad()
    {
        AgentePedidos ap = new AgentePedidos();
        List<Contingencia> contingencias = new List<Contingencia>();
        this.cboMotivoInactividad.Items.Clear();
        contingencias = ap.LeerContingencias(-1, string.Empty, -1, 10);

        RadComboBoxItem item = new RadComboBoxItem();
        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboMotivoInactividad.Items.Add(item);

        foreach (Contingencia a in contingencias)
        {

            item = new RadComboBoxItem();
            item.Text = a.Descripcion;
            item.Value = a.idContingencia.ToString();
            this.cboMotivoInactividad.Items.Add(item);
        }


    }

    void llenaMotivosOperador()
    {
        AgentePedidos ap = new AgentePedidos();
        List<Contingencia> contingencias = new List<Contingencia>();
        this.cboMotivoOperador.Items.Clear();
        contingencias = ap.LeerContingencias(-1, string.Empty, -1, 11);

        RadComboBoxItem item = new RadComboBoxItem();
        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboMotivoOperador.Items.Add(item);

        foreach (Contingencia a in contingencias)
        {

            item = new RadComboBoxItem();
            item.Text = a.Descripcion;
            item.Value = a.idContingencia.ToString();
            this.cboMotivoOperador.Items.Add(item);
        }


    }

    List<ConsultaUnidad> LeerUnidadesMovs(string Filtro, string planta)
    {
        List<ConsultaUnidad> salida = new List<ConsultaUnidad>();
        AgenteUnidades Agente = new AgenteUnidades();
        //string _planta = CboPlantaBusqueda.SelectedValue.ToString();
        salida = Agente.LeerUnidadesMovs(Filtro, planta);

        return salida;
    }

    public void llenaOperadores()
    {
        AgentePersonal ap = new AgentePersonal();
        List<Personal> lista = new List<Personal>();
        lista = ap.ObtenerChoferUnidad(-1, DatosUsuario.Ciudad);

        RadComboBoxItem item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboOperador.Items.Add(item);

        foreach (Personal chofer in lista)
        {
            item = new RadComboBoxItem();
            item.Text = chofer.Nombre + " " + chofer.APaterno + " " + chofer.AMaterno;
            item.Value = chofer.IDPersonal.ToString();
            this.cboOperador.Items.Add(item);
        }

    }

    void ActualizaUnidad()
    {
        ConsultaUnidad unidad_upd = new ConsultaUnidad();
        AgenteUnidades au = new AgenteUnidades();
        bool resultado = false;

        unidad_upd.IDUnidad = int.Parse(txtUnidadId.Text.ToString());
        unidad_upd.IDClaveUnidad = txtClave.Text.ToString();
        unidad_upd.CveAlterna = txtCveAlterna.Text.ToString();
        unidad_upd.IdPlanta = int.Parse(cboPlantaEdicion.SelectedValue.ToString());
        unidad_upd.IdOperador = int.Parse(cboOperador.SelectedValue.ToString());

        unidad_upd.EstatusPlaneacion = int.Parse(cboEstatus.SelectedValue.ToString());
        unidad_upd.MotivoInactividad = int.Parse(cboMotivoInactividad.SelectedValue.ToString()); 
        unidad_upd.MotivoCambioOperador = int.Parse(cboMotivoOperador.SelectedValue.ToString()); 

        resultado = au.InsertaPlaneacionUnidad(unidad_upd);

        if (resultado)
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);

            RadMultiPage1.PageViews[1].Selected = true;
            RadTab tab1 = RadTabStrip1.Tabs.FindTabByText("Unidades");
            tab1.Selected = true;

            //Ejecutar una busqueda en automatico con la planta de la unidad
            List<ConsultaUnidad> Lista = new List<ConsultaUnidad>();
            CboPlantaBusqueda.SelectedValue = unidad_upd.IdPlanta.ToString();
            Lista = LeerUnidadesMovs(string.Empty, CboPlantaBusqueda.SelectedValue.ToString());

            this.rgdUnidades.DataSource = Lista;
            rgdUnidades.DataBind();

            LimpiaEdicionUnidad();

        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
        }

    }

    void LimpiaEdicionUnidad()
    {
        
        txtUnidadId.Text                    = string.Empty;
        txtClave.Text                       = string.Empty;
        txtCveAlterna.Text                  = string.Empty;
        cboPlantaEdicion.SelectedValue      = "-1";
        cboOperador.SelectedValue           = "-1";
        cboEstatus.SelectedValue            = "-1";
        cboMotivoInactividad.SelectedValue  = "-1";
        cboMotivoOperador.SelectedValue     = "-1";
        
    }

    #endregion

    #region Eventos

    protected void cmdbuscar_Click(object sender, ImageClickEventArgs e)
    {
        //AgenteUnidades Agente = new AgenteUnidades();
        List<ConsultaUnidad> Lista = new List<ConsultaUnidad>();
        Lista = LeerUnidadesMovs(txtNombreUnidad.Text, CboPlantaBusqueda.SelectedValue.ToString());

        this.rgdUnidades.DataSource = Lista;
        rgdUnidades.DataBind();

        LimpiaEdicionUnidad();
    }

    protected void rgdUnidades_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    }
    protected void rgdUnidades_ItemCommand(object sender, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR:

                RadMultiPage1.PageViews[2].Selected = true;
                RadTab tab1 = RadTabStrip1.Tabs.FindTabByText("Configuracion");
                tab1.Selected = true;

                AgenteUnidades AU = new AgenteUnidades();
                if (AU.BuscaUnidadMovs(e.Item.Cells[2].Text) != null && AU.BuscaUnidadMovs(e.Item.Cells[2].Text).Count > 0)
                {
                    AU = new AgenteUnidades();
                    ConsultaUnidad consulta = AU.BuscaUnidadMovs(e.Item.Cells[2].Text)[0];

                    LimpiaEdicionUnidad();

                    txtUnidadId.Text                    = consulta.IDUnidad.ToString();
                    txtClave.Text                       = consulta.IDClaveUnidad.ToString();
                    txtCveAlterna.Text                  = consulta.CveAlterna.ToString();
                    cboPlantaEdicion.SelectedValue      = consulta.IdPlanta.ToString();
                    cboOperador.SelectedValue           = consulta.IdOperador.ToString();
                    cboEstatus.SelectedValue            = consulta.IDEstatus.ToString();
                    cboMotivoInactividad.SelectedValue  = consulta.MotivoInactividad.ToString();
                    cboMotivoOperador.SelectedValue     = consulta.MotivoCambioOperador.ToString();

                    lblOperadorAsignado.Text = cboOperador.SelectedItem.Text.ToString();

                }
                break;
        }
    }

    protected void cboOperador_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        rowempleado.Visible = true;
    }

    protected void cmdGuardarUnidad_Click(object sender, ImageClickEventArgs e)
    {

        if (txtUnidadId.Text.Length > 0)
        {
            if (cboPlantaEdicion.SelectedValue != "-1")
            {
                if (cboOperador.SelectedValue != "-1")
                {
                    if (cboEstatus.SelectedValue != "-1")
                    {
                        ActualizaUnidad();
                        cboMotivoInactividad.Enabled = false;
                    }
                    else
                    {
                        Alert.Show("Seleccione un Estatus para la unidad " + txtNombreUnidad.Text.ToString());
                    }

                }
                else
                {
                    Alert.Show("Seleccione un Operador para la unidad " + txtNombreUnidad.Text.ToString());
                }
            }
            else
            {
                Alert.Show("Seleccione una Planta Valida");
            }
        }
        else
        {
            Alert.Show("No existe registro a actualizar");
        }
        
    }

    protected void cboMotivoInactividad_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }

    protected void cboEstatus_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        

        if (e.OldValue != e.Value)
        {
            if (e.Value == "0")
            {
                cboMotivoInactividad.Enabled = true;
                cboMotivoInactividad.SelectedValue = "-1";
            }
            else
            {
                cboMotivoInactividad.Enabled = false;
                cboMotivoInactividad.SelectedValue = "-1";
            }
        }


        
    }

    #endregion


    protected void cboEstatusOperador_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (e.OldValue != e.Value)
        {
            if (e.Value == "0")
            {
                cboOperador.Enabled = true;
                //cboOperador.SelectedValue = "-1";

                cboMotivoOperador.Enabled = true;
                cboOperador.SelectedValue = "-1";
            }
            else
            {
                cboOperador.Enabled = false;
                //cboOperador.SelectedValue = "-1";

                cboMotivoOperador.Enabled = false;
                cboMotivoOperador.SelectedValue = "-1";
            }
        }
    }
}