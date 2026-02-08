using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_ReasignaUnidad : System.Web.UI.Page
{
    private DateTime startDate = DateTime.Today;
    private DateTime endDate = DateTime.Today.AddDays(60);
    #region CargaPagina
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
    }

    public DateTime Fechacambio
    { get { return DateTime.Parse(DTFechaCambio.DateInput.Text.Substring(0, 10)); } }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            CargaCiudades();
            cargaplantas(string.Empty);
            List<ReasignaViajeCR> lista = new List<ReasignaViajeCR>();
            this.GridRemisiones.DataSource = lista;
            this.GridRemisiones.DataBind();
        }
    }
    #endregion

    #region Eventos
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        List<ReasignaViajeCR> lista = BuscaViajesUnidad();
        this.GridRemisiones.DataSource = lista;
        this.GridRemisiones.DataBind();
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

    protected void btnLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        List<ReasignaViajeCR>  lista = new List<ReasignaViajeCR>();
        this.GridRemisiones.DataSource = lista;
        this.GridRemisiones.DataBind();

        cboPlanta.SelectedValue = "-1";
        cargaunidad();
    }

    protected void btnProcesar_Click(object sender, ImageClickEventArgs e)
    {
        List<ReasignaViajeCR> listaviajes       = BuscaViajesUnidad();
        List<ConsultaUnidad> UnidadesLibres     = new List<ConsultaUnidad>();
        List<MovimientoCr> tmp_movimientos      = new List<MovimientoCr>();
        MovimientoCr tmp_movimiento             = new MovimientoCr();
        ConsultaUnidad tmp_unidad               = new ConsultaUnidad();
        AgenteViajes Agente                     = new AgenteViajes();

        bool ActualizaViaje                     = false;
        bool validaMovimiento                   = false;

        if (listaviajes.Count == 0)
        { Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_REASIGNA_VIAJES_NO_EXISTE); }
        else
        {
            foreach (ReasignaViajeCR viaje in listaviajes)
            {
                UnidadesLibres = BuscaUnidadesLibres(viaje.IdPlantaOrigen, viaje.DT_FechaViaje, viaje.HoraViaje, viaje.HoraViajeFin);

                if (UnidadesLibres.Count == 0)
                {
                    validaMovimiento = false;
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_REASIGNACION_UNIDAD_FALLO);
                    return;
                }
                else
                {
                    tmp_movimiento  = new MovimientoCr();
                    tmp_unidad      = new ConsultaUnidad();
                    tmp_unidad      = UnidadesLibres[0];
                    //===================================================================
                    tmp_movimiento.IdViaje              = viaje.IdViaje;
                    tmp_movimiento.IdPedido             = viaje.IdPedido;
                    tmp_movimiento.IdPlantaOrigen       = viaje.IdPlantaOrigen;
                    //===================================================================
                    tmp_movimiento.IdUnidadOriginal     = viaje.IdCROrigen;
                    tmp_movimiento.HoraInicioOriginal   = viaje.HoraViaje;
                    tmp_movimiento.HoraFinOriginal      = viaje.HoraViajeFin;
                    tmp_movimiento.IdOperadorOriginal   = 0;
                    //===================================================================
                    tmp_movimiento.IdUnidadDestino      = tmp_unidad.IDUnidad;
                    tmp_movimiento.HoraInicioCambio     = viaje.HoraViaje;
                    tmp_movimiento.HoraFinCambio        = viaje.HoraViajeFin;
                    tmp_movimiento.IdOperadorCambio     = tmp_unidad.IdOperador;
                    tmp_movimiento.IdPlantaDestino      = viaje.IdPlantaOrigen;
                    //===================================================================

                    //En caso de que existan viajes posibles
                    tmp_movimientos.Add(tmp_movimiento);
                    validaMovimiento = true;
                }
            }

            if (validaMovimiento)
            {
                //En este paso es necesario realizar la actualizacion de los viajes.
                foreach (MovimientoCr mov in tmp_movimientos)
                {
                    Agente = new AgenteViajes();
                    ActualizaViaje = Agente.ActualizaViajeCR(mov.IdViaje, mov.IdUnidadDestino, mov.IdPlantaDestino, mov.IdOperadorCambio, DatosUsuario.Id_Usuario, mov.HoraInicioCambio, mov.HoraFinCambio);
                }

                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_REASIGNACION_UNIDAD_EXITO);

            }
        }
    }


    protected void GridRemisiones_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {

    }
    #endregion

    #region CargaInformacion
    public Usuario DatosUsuario
    {
        get
        {
            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
            return Login[0];
        }
    }

    private void cargaplantas(string claveciudad)
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> planta_ = new List<Planta>();
        planta_ = au.ObtenerPlantas();

        var plantas = from pp in planta_
                      where pp.Ciudad == claveciudad && pp.CveDosificadora.Contains("PD")
                      select new { pp.IDPlanta, pp.Nombre };

        RadComboBoxItem item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboPlanta.Items.Add(item);

        foreach (var p in plantas)
        {
            item = new RadComboBoxItem();
            item.Text = p.Nombre;
            item.Value = p.IDPlanta.ToString();
            this.cboPlanta.Items.Add(item);
        }
    }

    private void cargaunidad()
    {
        AgenteUnidades au = new AgenteUnidades();
        List<ConsultaUnidad> lu = new List<ConsultaUnidad>();
        this.cboCR.Items.Clear();
        lu = au.ObtieneUnidad();
        RadComboBoxItem item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboCR.Items.Add(item);

        var camiones = from camion in lu
                       where camion.IDClaveUnidad.Contains("CR") && camion.Estatus == "ACTIVO" &&camion.IdPlanta == int.Parse(cboPlanta.SelectedValue.ToString())
                       select new { camion.IDUnidad, camion.IDClaveUnidad };

        foreach (var u in camiones)
        {
            item = new RadComboBoxItem();
            item.Text = u.IDClaveUnidad;
            item.Value = u.IDUnidad.ToString();
            this.cboCR.Items.Add(item);
        }
    }

    private List<ReasignaViajeCR> BuscaViajesUnidad()
    {
        Concretec.Agentes.AgenteViajes agente = new AgenteViajes();
        List<ReasignaViajeCR> lista = new List<ReasignaViajeCR>();
        lista = agente.BuscaViajesUnidad(int.Parse(cboCR.SelectedValue), DatosUsuario.Ciudad, Fechacambio);

        return lista;
    }
    #endregion

    private List<ConsultaUnidad> BuscaUnidadesLibres(int idPlanta,DateTime FechaViaje, string HoraInicio, string HoraFin)
    {
        List<ConsultaUnidad> salida = new List<ConsultaUnidad>();
        AgenteUnidades agente = new AgenteUnidades();
        int TipoViaje = 1;
        salida = agente.BuscaUnidadesLibres( idPlanta,  TipoViaje,  FechaViaje,  HoraInicio,  HoraFin);
        return salida;
    }

    protected void cboPlanta_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        cargaunidad();
    }

    protected void cboCiudad_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        cargaplantas(cboCiudad.SelectedValue);
    }

    private void CargaCiudades()
    {
        this.cboCiudad.Items.Clear();
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();

        lc = ac.ObtenerCiudades();
        RadComboBoxItem item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboCiudad.Items.Add(item);
        foreach (Ciudad c in lc)
        {
            item = new RadComboBoxItem();
            item.Text = c.Descripcion;
            item.Value = c.CveCiudad.ToString();
            cboCiudad.Items.Add(item);
        }

    }
}