using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;
using Concretec.Pedidos.Constantes;


public partial class Views_CambioCR : System.Web.UI.Page
{
    private DateTime startDate  = DateTime.Today;
    private DateTime endDate    = DateTime.Today.AddDays(60);


    public DateTime Fechacambio
    { get { return DateTime.Parse(DTFechaCambio.DateInput.Text.Substring(0, 10)); } }

    #region CargaPagina
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            CargaCiudades();
            //CargaUnidades(String.Empty);
            cargaplantas(cboCiudadOrigen.SelectedValue);
            CboPlanta.Enabled = false;

            List<MovimientoCr> datosinicial = new List<MovimientoCr>();
            GridRemisiones.DataSource = datosinicial;
            GridRemisiones.DataBind();

            llenaComboComentarios();
        }
    }
    #endregion
    protected void cboCR_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        cargaplantas(cboCiudadOrigen.SelectedValue);

        List<ConsultaUnidad> _listaunidades = new List<ConsultaUnidad>();
        _listaunidades = ListaUnidades(cboCiudadOrigen.SelectedValue);

        var camiones = from camion in _listaunidades
                       where camion.IDClaveUnidad.Contains("CR") && camion.IDUnidad.ToString() == cboCR.SelectedValue
                       select new { camion.IDUnidad, camion.IDClaveUnidad, camion.CveAlterna , camion.IdPlanta};
        foreach (var u in camiones)
        {
            CboPlanta.SelectedValue = u.IdPlanta.ToString();   
        }

        CargaGrid();

    }

    protected void GridRemisiones_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
       
    }

    protected void btnAplicar_Click(object sender, ImageClickEventArgs e)
    {
        bool valida = true;
        string Mensaje = string.Empty;

        if (CboPlanta.SelectedValue == CboPlantaDestino.SelectedValue)
        {
            valida = false;
            Mensaje = Concretec.Pedidos.Constantes.Mensajes.MSG_ERROR_PLANTAS_IGUALES;
        }

        if (CboPlantaDestino.SelectedValue == Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE)
        {
            valida = false;
            Mensaje = Mensaje + Concretec.Pedidos.Constantes.Mensajes.MSG_PLANTA_DESTINO;
        }

        if (CboPlanta.SelectedValue == Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE)
        {
            valida = false;
            Mensaje = Mensaje + Concretec.Pedidos.Constantes.Mensajes.MSG_SEL_PLANTA;
        }

        if (this.cboComentario.SelectedValue == Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE)
        {
            valida = false;
            Mensaje = Mensaje + Concretec.Pedidos.Constantes.Mensajes.MSG_SEL_COMENTARIO_CAMBIO;
        }

        int viajespendientes = ViajesPendientes();

        if (valida && viajespendientes > 0)
        {
            valida = false;
            Mensaje = Mensaje + Concretec.Pedidos.Constantes.Mensajes.LA_UNIDAD + cboCR.Text + Concretec.Pedidos.Constantes.Mensajes.MSG_CUENTA_CON + viajespendientes.ToString() + cboCR.Text + Concretec.Pedidos.Constantes.Mensajes.MSG_REASINGE_VIAJES;
        }

        if (valida)
        {
            AgenteUnidades agente = new AgenteUnidades();
            try
            {
                bool resultado = agente.InsertarMovCR(int.Parse(cboCR.SelectedValue), int.Parse(CboPlanta.SelectedValue), int.Parse(this.CboPlantaDestino.SelectedValue), Fechacambio, null, DatosUsuario.Id_Usuario,this.cboComentario.Text);
                if (resultado)
                {
                    CargaGrid();
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.LA_UNIDAD + cboCR.Text + ", " + Concretec.Pedidos.Constantes.Mensajes.AUTORIZACION_EXITO);
                }
                else
                {
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO + " " + cboCR.Text);
                }
            }
            catch (Exception ex)
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO + " " + ex.Message);
            }

            
        }
        else
        {
            Alert.Show(Mensaje);
        }

    }

    #region CargaDatos

    public Usuario DatosUsuario
    {
        get
        {
            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
            return Login[0];
        }
    }

    public List<ConsultaUnidad> ListaUnidades(string cveciudad)
    {

            AgenteUnidades agente = new AgenteUnidades();
            List<ConsultaUnidad> lista_unidades = agente.ObtenerUnidadesFiltro(string.Empty, Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE, cveciudad, -1);
            return lista_unidades;
    }

    public void CargaUnidades(string cveciudad)
    {
        AgenteUnidades agente = new AgenteUnidades();
        List<ConsultaUnidad> listaunidades = ListaUnidades(cboCiudadOrigen.SelectedValue);//agente.ObtenerUnidadesFiltro(string.Empty, "-1", DatosUsuario.Ciudad);

        var camiones = from camion in listaunidades
                       where camion.IDClaveUnidad.Contains("CR")
                       select new { camion.IDUnidad, camion.IDClaveUnidad,camion.CveAlterna };

        this.cboCR.Items.Clear();
        RadComboBoxItem item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = "-1";
        this.cboCR.Items.Add(item);


        foreach (var u in camiones)
        {
            if (u.IDClaveUnidad.Trim().Length > 1)
            {
                item = new RadComboBoxItem();
                item.Text = u.IDClaveUnidad + " [" + u.CveAlterna + "]";
                item.Value = u.IDUnidad.ToString();
                this.cboCR.Items.Add(item);
            }
            
        }

    }

    private void cargaplantas(string cveciudad)
    {
        AgentePlantas au        = new AgentePlantas();
        List<Planta> planta_    = new List<Planta>();
        planta_                 = au.ObtenerPlantas();

        var plantas = from pp in planta_
                      where pp.Ciudad == cveciudad
                      select new { pp.IDPlanta, pp.Nombre };

        RadComboBoxItem item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.CboPlanta.Items.Add(item);

        foreach (var p in plantas)
        {
            item = new RadComboBoxItem();
            item.Text = p.Nombre;
            item.Value = p.IDPlanta.ToString();
            this.CboPlanta.Items.Add(item);
        }

    }

    private void cargaPlantasDestino(string cveciudad)
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> planta_ = new List<Planta>();
        planta_ = au.ObtenerPlantas();

        var plantas = from pp in planta_
                      where pp.Ciudad == cveciudad
                      select new { pp.IDPlanta, pp.Nombre };

        RadComboBoxItem item_2 = new RadComboBoxItem();
        item_2.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item_2.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.CboPlantaDestino.Items.Add(item_2);

        foreach (var p in plantas)
        {
            item_2 = new RadComboBoxItem();
            item_2.Text = p.Nombre;
            item_2.Value = p.IDPlanta.ToString();
            this.CboPlantaDestino.Items.Add(item_2);
        }


    }

    protected void CustomizeDay(object sender, Telerik.Web.UI.Calendar.DayRenderEventArgs e)
    {
        DateTime CurrentDate = e.Day.Date;
        if (startDate <= CurrentDate && CurrentDate <= DateTime.Today.AddDays(60))
        {
            return;
        }
        e.Day.IsDisabled = true;
        e.Day.IsSelectable = false;
        (sender as RadCalendar).SpecialDays.Add(e.Day);
    }

    bool ValidaFechaHoraEntrega()
    {
        bool salida = false;
        if (this.DTFechaCambio.DateInput.Text == "" )
        { salida = false; }
        else
        { salida = true; }

        return salida;
    }

    private List<MovimientoCr> BuscaMovimientoCR(int IdUnidad)
    {
        List<MovimientoCr> salida = new List<MovimientoCr>();
        AgenteUnidades agente = new AgenteUnidades();
        salida = agente.BuscaMovimientoCR(IdUnidad);
        return salida;
    }

    private void CargaGrid()
    {
        List<MovimientoCr> salida = new List<MovimientoCr>();
        salida = BuscaMovimientoCR(int.Parse(this.cboCR.SelectedValue));

        GridRemisiones.DataSource = salida;
        GridRemisiones.DataBind();
    }

    private List<Contingencia> LeerContingencias()
    {
        List<Contingencia> salida = new List<Contingencia>();
        AgentePedidos agente = new AgentePedidos();
        salida = agente.LeerContingencias(-1, string.Empty, 1, 3);

        return salida;
    }

    private void llenaComboComentarios()
    {
        List<Contingencia> salida = new List<Contingencia>();
        salida = LeerContingencias();

        RadComboBoxItem item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboComentario.Items.Add(item);

        foreach (Contingencia p in salida)
        {
            item = new RadComboBoxItem();
            item.Text = p.Descripcion;
            item.Value = p.idContingencia.ToString();
            this.cboComentario.Items.Add(item);
        }
    }

    protected void btnLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        cargaplantas(string.Empty);

        this.cboCR.SelectedValue            = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboComentario.SelectedValue    = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.CboPlanta.SelectedValue        = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.CboPlantaDestino.SelectedValue = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;

        List<MovimientoCr> datosinicial = new List<MovimientoCr>();
        GridRemisiones.DataSource = datosinicial;
        GridRemisiones.DataBind();
    }

    private int ViajesPendientes()
    {
        AgenteViajes agente = new AgenteViajes();
        int salida = 0;
        List<ReasignaViajeCR> viajes = agente.BuscaViajesUnidad(int.Parse(cboCR.SelectedValue), DatosUsuario.Ciudad, Fechacambio);

        if (viajes != null)
        {
            salida = viajes.Count();
        }

        return salida;
    }
    #endregion

    private void CargaCiudades()
    {
        this.cboCiudadOrigen.Items.Clear();
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();

        lc = ac.ObtenerCiudades();
        RadComboBoxItem item = new RadComboBoxItem();
        RadComboBoxItem item_destino = new RadComboBoxItem();

        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;

        item_destino.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item_destino.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;

        cboCiudadOrigen.Items.Add(item);
        cboCiudadDestino.Items.Add(item_destino);

        foreach (Ciudad c in lc)
        {
            item = new RadComboBoxItem();
            item_destino = new RadComboBoxItem();

            item.Text = c.Descripcion;
            item.Value = c.CveCiudad.ToString();

            item_destino.Text = c.Descripcion;
            item_destino.Value = c.CveCiudad.ToString();

            cboCiudadOrigen.Items.Add(item);
            cboCiudadDestino.Items.Add(item_destino);
        }

    }

    protected void cboCiudadOrigen_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        CargaUnidades(cboCiudadOrigen.SelectedValue);
    }

    protected void cboCiudadDestino_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        cargaPlantasDestino(cboCiudadDestino.SelectedValue);
    }
}