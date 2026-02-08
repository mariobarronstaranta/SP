using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;
using System.Web.Configuration;

public partial class Views_CapturaViajes : System.Web.UI.Page
{
    private DateTime startDate = DateTime.Today;
    private DateTime endDate = DateTime.Today.AddDays(60);

    public int Horario_Diurno_Inicio_Hora = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Inicio_Hora"].ToString());
    public int Horario_Diurno_Inicio_Minuto = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Inicio_Minuto"].ToString());
    public int Horario_Diurno_Inicio_Segundo = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Inicio_Segundo"].ToString());

    public int Horario_Diurno_Fin_Hora = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Fin_Hora"].ToString());
    public int Horario_Diurno_Fin_Minuto = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Fin_Minuto"].ToString());
    public int Horario_Diurno_Fin_Segundo = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Fin_Segundo"].ToString());

    public int Horario_Nocturno_Inicio_Hora = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Inicio_Hora"].ToString());
    public int Horario_Nocturno_Inicio_Minuto = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Inicio_Minuto"].ToString());
    public int Horario_Nocturno_Inicio_Segundo = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Inicio_Segundo"].ToString());

    public int Horario_Nocturno_Fin_Hora = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Fin_Hora"].ToString());
    public int Horario_Nocturno_Fin_Minuto = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Fin_Minuto"].ToString());
    public int Horario_Nocturno_Fin_Segundo = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Fin_Segundo"].ToString());

    public int Intervalo_Minutos_Pedidos = int.Parse(WebConfigurationManager.AppSettings["Intervalo_Minutos_Pedidos"].ToString());
    public int Intervalo_Viajes_Pedidos = int.Parse(WebConfigurationManager.AppSettings["Intervalo_Viajes_Pedidos"].ToString());


    List<Pedido> ListaPedidoHeader = new List<Pedido>();
    Pedido PedidoHeader = new Pedido();
    public List<Viaje> AlmacenaPedidos;

    public int SizeViaje
    {
        // Esta variable hay que modificarla en base al numero de pedidos
        get { return 7; }
    }
    public Usuario DatosUsuario
    {
        get
        {

            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
            return Login[0];
        }

    }

    public int Desfase { get { return int.Parse(this.lblDesfase.Text.ToString()); } }
    public int IDViaje { get { return int.Parse(consecutivoviaje.Text.ToString()); } }
    public int IDPedido { get { return int.Parse(lblPedido.Text.ToString()); } }
    public int IDPlanta { get { return int.Parse(plantas.SelectedValue.ToString()); } }
    public int IDTipoViaje { get { return int.Parse(tiposviaje.SelectedValue.ToString()); } }
    public int IDUnidad { get { return int.Parse(unidades.SelectedValue.ToString()); } }
    public int IDMotivoCambio { set; get; }
    public int IDEstatusViaje { get { return int.Parse(estatusviaje.SelectedValue.ToString()); } }
    public float CargaViaje { get { return float.Parse(carga.Text.ToString()); } }
    public DateTime? FechaInicio { get { return fechainicio.SelectedDate; } }
    public string HoraInicio { get { return horainicio.DateInput.Text.Substring(11, 5).Replace("-", ":"); } }
    public string HoraFin { get { return horafin.DateInput.Text.Substring(11, 5).Replace("-", ":"); } }
    public int IDOperador
    {
        get
        {
            int salida = -1;
            if (operadores.SelectedValue.ToString() != "")
            { salida = int.Parse(operadores.SelectedValue.ToString()); }
            return salida;
        }
    }
    public string Remision { get { return remision.Text.ToString(); } }
    public float Distancia { get { return float.Parse(distancia.Text.ToString()); } }
    public string Observaciones { get { return observaciones.Text.ToString(); } }

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
            //INSTRUCCIONES PARA ACTIVAR HORARIO DIURNO
            horainicio.TimeView.StartTime = new TimeSpan(06, 00, 00);
            horainicio.TimeView.EndTime = new TimeSpan(20, 30, 00);
            horainicio.TimeView.Columns = 6;
            horainicio.TimeView.Interval = new TimeSpan(0, 10, 0);

            horafin.TimeView.StartTime = new TimeSpan(06, 00, 00);
            horafin.TimeView.EndTime = new TimeSpan(20, 30, 00);
            horafin.TimeView.Columns = 6;
            horafin.TimeView.Interval = new TimeSpan(0, 10, 0);

            AlmacenaPedidos = new List<Viaje>();
            AgentePedidos ap = new AgentePedidos();
            List<Viaje> viajes = new List<Viaje>();

            PedidoHeader = new Pedido();
            ListaPedidoHeader = new List<Pedido>();
            ListaPedidoHeader = (List<Pedido>)(Session["PedidoPadre"]);
            PedidoHeader = ListaPedidoHeader[0];

            viajes = ap.LeerViajesPedido(PedidoHeader.IDPedido);
            if (viajes.Count == 0)
            {
                RadGrid1.Columns[9].Visible = false;
                imgProgAuto.Visible = true;
                //imgGuardar.Visible = true;
            }
            else
            {
                imgProgAuto.Visible = false;
                //imgGuardar.Visible = false;
            }
            cargaplantas();
            cargatipoviaje();
            cargaestatusviaje();
            CargaInicio();
            cargaunidad("CR");

            cargaoperador();
            CargaTiempos(null, null);
            foreach (Viaje viaje in viajes)
            { AlmacenaPedidos.Add(viaje); }

            ViewState["AlmacenaPedidos"] = AlmacenaPedidos;

            if (AlmacenaPedidos != null && AlmacenaPedidos.Count > 0)
            {
                float Viajes_Programados = AlmacenaPedidos.Sum(c => c.CargaViaje);

                if (Viajes_Programados < float.Parse(lblCarga.Text.ToString()))
                {
                    float faltante = float.Parse(lblCarga.Text.ToString()) - Viajes_Programados;
                    lblMensajes.Visible = true;
                    lblMensajes.ForeColor = System.Drawing.Color.Red;
                    lblMensajes.Text = "ES NECESARIO PROGRAMAR DE MANERA MANUAL " + faltante.ToString() + " M3";
                }
            }

            BuscaUnidadesLibres_Sin_Planta();

        }
        else
        {
            AlmacenaPedidos = (List<Viaje>)ViewState["AlmacenaPedidos"];
            CargaDatos_Horas();
        }

        RadGrid1.DataSource = AlmacenaPedidos;
        RadGrid1.DataBind();
    }

    private void CargaDatos_Horas()
    {
        if (lblColadoNocturno.Text == "SI")
        {
            //INSTRUCCIONES PARA ACTIVAR HORARIO NOCTURNO
            horainicio.TimeView.StartTime = new TimeSpan(Horario_Nocturno_Inicio_Hora, Horario_Nocturno_Inicio_Minuto, Horario_Nocturno_Inicio_Segundo);
            horainicio.TimeView.EndTime = new TimeSpan(Horario_Nocturno_Fin_Hora, Horario_Nocturno_Fin_Minuto, Horario_Nocturno_Fin_Segundo);
            horainicio.TimeView.Columns = 12;
            horainicio.TimeView.Interval = new TimeSpan(0, Intervalo_Minutos_Pedidos, 0);

            horafin.TimeView.StartTime = new TimeSpan(Horario_Nocturno_Inicio_Hora, Horario_Nocturno_Inicio_Minuto, Horario_Nocturno_Inicio_Segundo);
            horafin.TimeView.EndTime = new TimeSpan(Horario_Nocturno_Fin_Hora, Horario_Nocturno_Fin_Minuto, Horario_Nocturno_Fin_Segundo);
            horafin.TimeView.Columns = 12;
            horafin.TimeView.Interval = new TimeSpan(0, Intervalo_Minutos_Pedidos, 0);
        }
        else
        {
            //INSTRUCCIONES PARA ACTIVAR HORARIO DIURNO
            horainicio.TimeView.StartTime = new TimeSpan(Horario_Diurno_Inicio_Hora, Horario_Diurno_Inicio_Minuto, Horario_Diurno_Inicio_Segundo);
            horainicio.TimeView.EndTime = new TimeSpan(Horario_Diurno_Fin_Hora, Horario_Diurno_Fin_Minuto, Horario_Diurno_Fin_Segundo);
            horainicio.TimeView.Columns = 12;
            horainicio.TimeView.Interval = new TimeSpan(0, Intervalo_Minutos_Pedidos, 0);

            horafin.TimeView.StartTime = new TimeSpan(Horario_Diurno_Inicio_Hora, Horario_Diurno_Inicio_Minuto, Horario_Diurno_Inicio_Segundo);
            horafin.TimeView.EndTime = new TimeSpan(Horario_Diurno_Fin_Hora, Horario_Diurno_Fin_Minuto, Horario_Diurno_Fin_Segundo);
            horafin.TimeView.Columns = 12;
            horafin.TimeView.Interval = new TimeSpan(0, Intervalo_Minutos_Pedidos, 0);
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

    private void CargaInicio()
    {
        PedidoHeader = new Pedido();
        ListaPedidoHeader = new List<Pedido>();
        ListaPedidoHeader = (List<Pedido>)(Session["PedidoPadre"]);
        PedidoHeader = ListaPedidoHeader[0];
        string _lblColadoNocturno = string.Empty;

        if (PedidoHeader.ColadoNocturno == 1)
        {
            _lblColadoNocturno = Concretec.Pedidos.Constantes.Etiquetas.TAG_SI;
        }
        else
        {
            _lblColadoNocturno = Concretec.Pedidos.Constantes.Etiquetas.TAG_NO;
        }

        lblPedido.Text          = PedidoHeader.IDPedido.ToString();
        lblCarga.Text           = PedidoHeader.CargaTotal.ToString();
        carga.Text              = SizeViaje.ToString();
        lblCliente.Text         = PedidoHeader.NombreCliente;
        lblDescripcion.Text     = PedidoHeader.Observaciones;
        lblDesfase.Text         = PedidoHeader.Desfase.ToString();
        lblColadoNocturno.Text  = _lblColadoNocturno;
        lblProducto.Text        = PedidoHeader.NombreProducto;
        lblviajes.Text          = PedidoHeader.Viajes.ToString();
        distancia.Text          = PedidoHeader.Distancia.ToString();
        if (PedidoHeader.FechaCompromiso.Day < 10)
        {
            if (PedidoHeader.FechaCompromiso.Month < 10)
            {
                lblFecha.Text = PedidoHeader.FechaCompromiso.ToString().Substring(0, 8) + " " + PedidoHeader.HoraCompromiso.ToString().Substring(11, 5).Replace("-", ":");
            }
            else
            {
                lblFecha.Text = PedidoHeader.FechaCompromiso.ToString().Substring(0, 9) + " " + PedidoHeader.HoraCompromiso.ToString().Substring(11, 5).Replace("-", ":");
            }

        }
        else
        {
            if (PedidoHeader.FechaCompromiso.Month < 10)
            {
                lblFecha.Text = PedidoHeader.FechaCompromiso.ToString().Substring(0, 9) + " " + PedidoHeader.HoraCompromiso.ToString().Substring(11, 5).Replace("-", ":");
            }
            else
            {
                lblFecha.Text = PedidoHeader.FechaCompromiso.ToString().Substring(0, 10) + " " + PedidoHeader.HoraCompromiso.ToString().Substring(11, 5).Replace("-", ":");
            }
        }

        lblObra.Text = PedidoHeader.NombreObra.ToString();
        lblPlanta.Text = PedidoHeader.NombrePlanta;
        lblUso.Text = PedidoHeader.NombreUso;
        lblVendedor.Text = PedidoHeader.NombreVendedor;
        plantas.SelectedValue = PedidoHeader.IDPlanta.ToString();
        distancia.Text = PedidoHeader.Distancia.ToString();
        fechainicio.SelectedDate = PedidoHeader.FechaCompromiso;

        CargaDatos_Horas();
    }

    private void obtieneentidad()
    {

    }
    private void cargaplantas()
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> planta_ = new List<Planta>();
        planta_ = au.ObtenerPlantas();

        var plantas = from pp in planta_
                      where pp.Ciudad == DatosUsuario.Ciudad && pp.CveDosificadora.Contains("PD")
                      select new { pp.IDPlanta, pp.Nombre };

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.plantas.Items.Add(item);

        foreach (var p in plantas)
        {
            item = new ListItem();
            item.Text = p.Nombre;
            item.Value = p.IDPlanta.ToString();
            this.plantas.Items.Add(item);
        }
    }

    public void BuscaUnidadesLibres_Sin_Planta()
    {
        List<ConsultaUnidad> salida = new List<ConsultaUnidad>();
        AgenteUnidades agente = new AgenteUnidades();
        salida = agente.BuscaUnidadesLibres(-1, IDTipoViaje, DateTime.Parse(FechaInicio.ToString()), HoraInicio, HoraFin);



        this.unidades.Items.Clear();
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.unidades.Items.Add(item);


        foreach (ConsultaUnidad u in salida)
        {
            item = new ListItem();
            item.Text = u.IDClaveUnidad;
            item.Value = u.IDUnidad.ToString();
            this.unidades.Items.Add(item);
        }
    }

    public void Busca_Unidades_Libres()
    {
        List<ConsultaUnidad> salida = new List<ConsultaUnidad>();
        AgenteUnidades agente = new AgenteUnidades();
        salida = agente.BuscaUnidadesLibres(IDPlanta, IDTipoViaje, DateTime.Parse(FechaInicio.ToString()), HoraInicio, HoraFin);



        this.unidades.Items.Clear();
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.unidades.Items.Add(item);


        foreach (ConsultaUnidad u in salida)
        {
            item = new ListItem();
            item.Text = u.IDClaveUnidad;
            item.Value = u.IDUnidad.ToString();
            this.unidades.Items.Add(item);
        }


    }


    private void cargatipoviaje()
    {
        AgentePedidos ap = new AgentePedidos();
        List<TipoViaje> ltv = new List<TipoViaje>();

        tiposviaje.Items.Clear();
        ltv = ap.LeerTipoViajes();
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.tiposviaje.Items.Add(item);

        foreach (TipoViaje tv in ltv)
        {
            item = new ListItem();
            item.Text = tv.Descripcion;
            item.Value = tv.IDTipoViaje.ToString();
            this.tiposviaje.Items.Add(item);

        }

        tiposviaje.SelectedValue = "1";
    }


    private void cargaunidad(string TipoUnidad)
    {
        AgenteUnidades au = new AgenteUnidades();
        List<ConsultaUnidad> lu = new List<ConsultaUnidad>();
        this.unidades.Items.Clear();
        lu = au.ObtieneUnidad();
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.unidades.Items.Add(item);

        var camiones = from camion in lu
                       where camion.IDClaveUnidad.Contains(TipoUnidad) 
                            && camion.IdPlanta == int.Parse(plantas.SelectedValue.ToString())
                            && camion.Estatus == "ACTIVO"
                       select new { camion.IDUnidad, camion.IDClaveUnidad };


        foreach (var u in camiones)
        {
            item = new ListItem();
            item.Text = u.IDClaveUnidad;
            item.Value = u.IDUnidad.ToString();
            this.unidades.Items.Add(item);
        }
    }
    private void cargaoperador()
    {
        this.operadores.Items.Clear();
        AgentePersonal ap = new AgentePersonal();
        List<Personal> lp = new List<Personal>();
        lp = ap.ObtenerChoferUnidad(int.Parse(this.unidades.SelectedValue), DatosUsuario.Ciudad);
        ListItem item = new ListItem();
        if (lp.Count > 0)
        {
            foreach (Personal p in lp)
            {
                item = new ListItem();
                item.Text = p.ClavePersonal + " " + p.Nombre + " " + p.APaterno + " " + p.AMaterno;
                item.Value = p.IDPersonal.ToString();
                this.operadores.Items.Add(item);
            }
        }
        else
        {
            item = new ListItem();
            item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
            item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
            this.operadores.Items.Add(item);
        }
    }
    private void cargamotivocambio()
    {
        AgentePedidos ap = new AgentePedidos();
        List<MotivoCambio> mc = new List<MotivoCambio>();

        mc = ap.MotivosDeCambio();
        foreach (MotivoCambio m in mc)
        {
            ListItem item = new ListItem();
            item.Text = m.Descripcion;
            item.Value = m.IDMotivoCambio.ToString();
        }
    }
    private void cargaestatusviaje()
    {
        AgentePedidos ap = new AgentePedidos();
        List<EstatusViaje> estatus = new List<EstatusViaje>();
        estatus = ap.LeerEstatusViaje();

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.estatusviaje.Items.Add(item);

        foreach (EstatusViaje ev in estatus)
        {
            item = new ListItem();
            item.Text = ev.Descripcion;
            item.Value = ev.IDEstatusViaje.ToString();
            this.estatusviaje.Items.Add(item);
        }

        estatusviaje.SelectedValue = "3";
    }

    public bool ExisteViaje(Viaje V)
    {
        AgenteViajes agente = new AgenteViajes();
        bool salida = false;
        DateTime fechainicio = DateTime.Parse(V.FechaInicio.ToString());
        salida = agente.BuscaViaje(V.IDViaje, V.IDPlanta, V.IDUnidad, fechainicio, V.HoraInicio);
        return salida;
    }

    public bool GuardaViajes()
    {
        AgenteViajes agente = new AgenteViajes();
        bool res = false;
        int i = 1;

        foreach (Viaje v in AlmacenaPedidos)
        {
            agente = new AgenteViajes();
            if (ExisteViaje(v) == false)
            {
                res = agente.InsertaViajes(v, i);
            }
            else
            {
                res = true;
            }
            i++;
        }
        if (res == true)
        {
            llenaGrid();
        }

        return res;
    }

    protected void imgGuardar_Click(object sender, ImageClickEventArgs e)
    {
        GuardarGrid();
        BuscaUnidadesLibres_Sin_Planta();
    }


    private void GuardarGrid()
    {
        if (RadGrid1.Items.Count > 0)
        {
            if (GuardaViajes())
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.VIAJES_EXITO);
                //imgGuardar.Visible = false;
            }
            else
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.ERROR_GUARDAR_VIAJES);
            }
        }

        
    }

    protected void imgCancelar_Click(object sender, ImageClickEventArgs e)
    {
        Session["idPedido"] = IDPedido.ToString();
        Response.Redirect("~/views/CapturaPedidos.aspx");
    }

    void ImprimirPedido()
    { 
    
    }

    void LimpiarCamptura()
    {
        carga.Text = "";
        fechainicio.DateInput.Text = "";
        horainicio.DateInput.Text = "";
        horafin.DateInput.Text = "";
        distancia.Text = lblColadoNocturno.Text;
        remision.Text = "";
        observaciones.Text = "";
    }

    protected void imgLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarCamptura();

    }
    protected void fechainicio_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {

    }
    protected void unidades_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargaoperador();
        enciende();
    }
    protected void imgAgregar_Click(object sender, ImageClickEventArgs e)
    {
        Viaje viaje = new Viaje();
        var _cargatotal = (from g in AlmacenaPedidos select g.CargaViaje).Sum();
        float cargatotal = float.Parse(_cargatotal.ToString()) + float.Parse(carga.Text);

        int _hora = int.Parse(HoraInicio.Substring(0, 2));
        int _minutos = int.Parse(HoraInicio.Substring(3, 2));
        TimeSpan horaviaje = new TimeSpan((_hora + 1), _minutos, 0);
        DateTime fechahoraPedido = FechaInicio.Value.Add(horaviaje);
        bool DosificadoraDisponible = false;

        // Cuando sea un servicio de bombeo no se valida la Dosificadora
        if (IDTipoViaje == 1)
        {
            DosificadoraDisponible = ValidaDosificadora(DatosUsuario.Ciudad, fechahoraPedido, fechahoraPedido, IDPlanta, 1);
        }
        else
        {
            DosificadoraDisponible = true;
        }


        if (DosificadoraDisponible == true)
        {
            viaje                   = new Viaje();
            viaje.IDViaje           = AlmacenaPedidos.Count() + 1;
            viaje.CargaViaje        = float.Parse(carga.Text.ToString());
            viaje.Distancia         = Distancia;
            viaje.FechaInicio       = FechaInicio;
            viaje.HoraFin           = HoraFin;
            viaje.HoraInicio        = HoraInicio;
            viaje.IDEstatusViaje    = IDEstatusViaje;
            viaje.IDMotivoCambio    = IDMotivoCambio;
            viaje.IDOperador        = IDOperador;
            viaje.IDPedido          = IDPedido;
            viaje.IDPlanta          = IDPlanta;
            viaje.IDTipoViaje       = IDTipoViaje;
            viaje.IDUnidad          = IDUnidad;
            viaje.Observaciones     = Observaciones;
            viaje.Remision          = Remision;

            viaje.NombreOperador = operadores.SelectedItem.Text;
            viaje.DescripcionUnidad = unidades.SelectedItem.Text;
            viaje.CvePlanta = plantas.SelectedItem.Text.Substring(0, 2);

            consecutivoviaje.Text = viaje.IDViaje.ToString();

            if (float.Parse(lblCarga.Text) < cargatotal) //
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.ERROR_CARGA_PEDIDO);
            }
            else if (float.Parse(carga.Text) < 0.5 && this.tiposviaje.SelectedValue == "1" ) // No es posible cargas menores a medio metro cubico de cemento
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.ERROR_CARGA_MIN);
            }
            else
            {
                TimeSpan ts = new TimeSpan(0, 30, 0);

                if (horainicio.SelectedDate.Value.Add(ts).TimeOfDay > horafin.SelectedDate.Value.TimeOfDay)
                {
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.VAL_TIEMPO_VIAJE);
                }
                else
                {
                    AlmacenaPedidos.Add(viaje);
                    ViewState["AlmacenaPedidos"] = AlmacenaPedidos;
                    RadGrid1.DataBind();
                    CargaTiempos(horainicio.SelectedDate, horafin.SelectedDate);


                    if (RadGrid1.Items.Count > 0)
                    {
                        if (GuardaViajes())
                        {
                            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.VIAJE_GUARDAR_EXITO);


                            if (AlmacenaPedidos != null && AlmacenaPedidos.Count > 0)
                            {
                                float Viajes_Programados = AlmacenaPedidos.Sum(c => c.CargaViaje);

                                if (Viajes_Programados < float.Parse(lblCarga.Text.ToString()))
                                {
                                    float faltante = float.Parse(lblCarga.Text.ToString()) - Viajes_Programados;
                                    lblMensajes.Visible = true;
                                    lblMensajes.ForeColor = System.Drawing.Color.Red;
                                    lblMensajes.Text = Concretec.Pedidos.Constantes.Mensajes.MSG_MANERA_MANUAL + faltante.ToString() + Concretec.Pedidos.Constantes.Etiquetas.TAG_M3;
                                }
                            }

                        }
                        else
                        {
                            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
                        }
                    }
                    BuscaUnidadesLibres_Sin_Planta();
                }


            }
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.DOSIF_OCUPADA);
        }


        //}

    }

    void enciende()
    {
        int elemtos = RadGrid1.Items.Count;
        if (elemtos == 0)
        { 
            imgProgAuto.Visible = true;
            //imgGuardar.Visible = true;
        }
        else
        { 
            imgProgAuto.Visible = false;
            //imgGuardar.Visible = false;
        }

    }

    protected void plantas_SelectedIndexChanged(object sender, EventArgs e)
    {
        BuscaUnidadesLibres_Sin_Planta();

        switch (IDTipoViaje)
        {
            case 1:
                carga.Text = "7";
                break;
            case 2:
                carga.Text = "0";
                break;
            default:
                carga.Text = "7";
                break;
        }
        enciende();
    }


    float CalculaCarga()
    {
        float carga = 0;
        int CargaTotal = Convert.ToInt32(float.Parse(lblCarga.Text));
        int numviajes = int.Parse(lblviajes.Text);
        if (CargaTotal <= 7)
        { carga = CargaTotal; }
        else
        { carga = (((CargaTotal - 1) / numviajes) + 1); }



        return carga;
    }

    int CalculaViajes()
    {
        int numviajes = 1;
        if (lblviajes.Text != "")
        {
            numviajes = int.Parse(lblviajes.Text);
        }
        else
        {
            float CargaTotal = int.Parse(lblCarga.Text);
            float iViajes = 0;
            float Diferencial = 0;
            float totalViajes = 0;

            iViajes = CargaTotal / SizeViaje;
            Diferencial = CargaTotal % SizeViaje;
            totalViajes = iViajes;
            if (Diferencial > 0)
            {
                totalViajes = totalViajes + 1;
            }
            numviajes = int.Parse(totalViajes.ToString());
        }


        return numviajes;
    }

    void CargaTiempos(DateTime? HoraInicialAnterior, DateTime? HoraFinalAnterior)
    {
        DateTime HoraCompromiso = DateTime.Parse(lblFecha.Text.ToString());
        TimeSpan TiempoDesfase = new TimeSpan(0, Desfase, 0);
        TimeSpan TiempoCiclo = new TimeSpan(2, 0, 0);
        TimeSpan TiempoInicio = new TimeSpan(1, 0, 0);
        DateTime _horainicio = HoraCompromiso.Subtract(TiempoInicio);
        DateTime _horainicio_cambio = _horainicio;

        if (HoraFinalAnterior == null)
        {
            horainicio.SelectedDate = _horainicio_cambio;
            horafin.SelectedDate = _horainicio_cambio.Add(TiempoCiclo);
        }
        else
        {
            horainicio.SelectedDate = HoraInicialAnterior.Value.Add(TiempoDesfase);
            horafin.SelectedDate = horainicio.SelectedDate.Value.Add(TiempoCiclo);
        }


    }

    public bool ValidaDosificadora(string CveCiudad, DateTime FechaCompromiso, DateTime FechaHoraInicio, int IDPlanta, int Viajes)
    {
        AgenteViajes _agente = new AgenteViajes();
        bool salida = false;
        salida = _agente.ValidaDosificadora(FechaCompromiso, FechaHoraInicio, IDPlanta, Viajes);

        return salida;
    }

    List<ConsultaUnidad> ObtenerUnidadesLibres(string CveCiudad, DateTime FechaCompromiso, DateTime FechaHoraInicio, int IDPlantaPadre)
    {
        List<ConsultaUnidad> UnidadesLibres = new List<ConsultaUnidad>();
        AgenteUnidades AU = new AgenteUnidades();
        UnidadesLibres = AU.ObtenerUnidadesLibres(DatosUsuario.Ciudad, FechaCompromiso, FechaHoraInicio, IDPlantaPadre);

        //UnidadesLibres = AU.BuscaUnidadesLibres(IDPlantaPadre, IDTipoViaje, FechaCompromiso, HoraInicio, HoraFin);
        


        return UnidadesLibres;
    }

    bool ValidaUnidad()
    {
        List<Unidad> UnidadesLibres = new List<Unidad>();
        AgenteUnidades agente = new AgenteUnidades();
        bool salida = false;
        DateTime FechaCompromiso = DateTime.Parse(fechainicio.SelectedDate.ToString());
        DateTime FechaHoraInicio = DateTime.Parse(horainicio.SelectedDate.ToString());
        string HoradeInicio = FechaHoraInicio.Hour.ToString();
        string MinutoDeInicio = FechaHoraInicio.Minute.ToString();

        if (HoradeInicio.Length == 1)
        { HoradeInicio = HoradeInicio + "0"; }

        if (MinutoDeInicio.Length == 1)
        { MinutoDeInicio = MinutoDeInicio + "0"; }


        UnidadesLibres = agente.ValidaUnidadLibre(FechaCompromiso.ToShortDateString(), HoradeInicio + ":" + MinutoDeInicio, IDPlanta);

        var _unidades = from _unidad in UnidadesLibres
                        where _unidad.IDUnidad == int.Parse(unidades.SelectedValue.ToString())
                        select new { _unidad.IDUnidad, _unidad.IDPlanta };

        if (_unidades.Count() > 0) { salida = true; }

        var _unidadeslista = from _pedido in AlmacenaPedidos
                             where _pedido.IDUnidad == int.Parse(unidades.SelectedValue)
                             select new { _pedido.IDUnidad };

        if (_unidadeslista.Count() > 0) { salida = false; }

        return salida;
    }

    protected void imgProgAuto_Click(object sender, ImageClickEventArgs e)
    {
        DateTime FechaCompromiso = DateTime.Now;
        DateTime FechaHoraInicio = DateTime.Now;
        DateTime HoraCompromiso = DateTime.Parse(lblFecha.Text.ToString());
        TimeSpan TiempoDesfase = new TimeSpan(0, Desfase, 0);
        TimeSpan TiempoCiclo = new TimeSpan(2, 0, 0);
        TimeSpan TiempoInicio = new TimeSpan(1, 0, 0);
        DateTime _horainicio = HoraCompromiso.Subtract(TiempoInicio);
        DateTime _horainicio_cambio = _horainicio;
        List<ConsultaUnidad> UnidadesLibres = new List<ConsultaUnidad>();
        ConsultaUnidad UnidadSeleccionada = new ConsultaUnidad();
        DateTimeOffset centralTime2 = HoraCompromiso.Add(TiempoDesfase);
        bool valida = false;


        AlmacenaPedidos = new List<Viaje>();
        ViewState["AlmacenaPedidos"] = null;
        Viaje viaje = new Viaje();
        float CargaTotal = float.Parse(lblCarga.Text);
        int NumViajes = CalculaViajes();

        DateTime NuevaHoraCompromiso = HoraCompromiso;
        TimeSpan NuevoTiempoInicio = new TimeSpan(0, 0, 0);
        valida = this.ValidaDosificadora("", HoraCompromiso, HoraCompromiso, IDPlanta, NumViajes);
        if (valida == false)
        {
            int j = 40;
            NuevoTiempoInicio = new TimeSpan(0, j, 0);
            NuevaHoraCompromiso = NuevaHoraCompromiso.Subtract(NuevoTiempoInicio);
            NuevoTiempoInicio = new TimeSpan(0, 10, 0);
            for (int i = 1; i <= 6; i++)
            {
                j = i * 10;
                NuevoTiempoInicio = new TimeSpan(0, 10, 0);
                NuevaHoraCompromiso = NuevaHoraCompromiso.Add(NuevoTiempoInicio);
                valida = this.ValidaDosificadora("", NuevaHoraCompromiso, NuevaHoraCompromiso, IDPlanta, NumViajes);
                if (valida == true)
                {
                    // Aqui hay que darle de nuevo valor a las variables que se usan abajo y arriba
                    FechaHoraInicio = NuevaHoraCompromiso.Subtract(TiempoInicio);
                    HoraCompromiso = NuevaHoraCompromiso.Subtract(TiempoInicio);
                    _horainicio = NuevaHoraCompromiso.Subtract(TiempoInicio);
                    _horainicio_cambio = _horainicio;
                    break;
                }
            }
        }

        if (valida == false)
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.DOSIF_OCUPADA);
        }
        else
        {
            for (int i = 1; i <= NumViajes; i++)
            {
                if (i > 1) { _horainicio_cambio = _horainicio_cambio.Add(TiempoDesfase); }
                viaje = new Viaje();
                viaje.IDViaje = AlmacenaPedidos.Count() + 1;
                viaje.CargaViaje = CalculaCarga();
                if (i == NumViajes)
                {
                    //en esta linea hay que ajustar el tamaño de la carga del viaje
                    viaje.CargaViaje = CalculaCarga() - ((CalculaCarga() * i) - CargaTotal);
                }
                consecutivoviaje.Text = viaje.IDViaje.ToString();
                //==========================================================================

                //viaje.Distancia = Distancia;
                viaje.FechaInicio = FechaInicio;
                viaje.HoraFin = _horainicio_cambio.Add(TiempoCiclo).TimeOfDay.ToString().Substring(0, 5);
                viaje.HoraInicio = _horainicio_cambio.TimeOfDay.ToString().Substring(0, 5);
                viaje.IDEstatusViaje = IDEstatusViaje;
                viaje.IDMotivoCambio = IDMotivoCambio;

                viaje.IDPedido = IDPedido;
                viaje.IDTipoViaje = IDTipoViaje;
                viaje.Observaciones = Observaciones;
                viaje.Remision = Remision;
                //=========================================================================
                FechaCompromiso = HoraCompromiso;
                FechaHoraInicio = _horainicio_cambio.Add(TiempoCiclo);
                UnidadesLibres = new List<ConsultaUnidad>();
                UnidadesLibres = ObtenerUnidadesLibres(DatosUsuario.Ciudad, FechaCompromiso, FechaHoraInicio, IDPlanta);

                var camiones = from camion in UnidadesLibres
                               where camion.IDClaveUnidad.Contains("CR")
                               select new
                               {
                                   camion.IDUnidad,
                                   camion.IdPlanta,
                                   camion.IdOperador,
                                   camion.Planta,
                                   camion.NombreOperador,
                                   camion.IDClaveUnidad
                               };

                int NumCamiones = camiones.Count();

                foreach (var unidades in camiones)
                {
                    // Hay que validar si ese valor no existe, en caso de que no exista pues lo ponemos en el grid
                    var _unidadeslista = from _pedido in AlmacenaPedidos
                                         where _pedido.IDUnidad == unidades.IDUnidad
                                         select new { _pedido.IDUnidad };
                    if (_unidadeslista.Count() == 0)
                    {
                        //UnidadSeleccionada = unidades;
                        viaje.IDUnidad = unidades.IDUnidad;
                        viaje.IDPlanta = unidades.IdPlanta;
                        viaje.IDOperador = unidades.IdOperador;
                        viaje.CvePlanta = unidades.Planta;
                        viaje.NombreOperador = unidades.NombreOperador;
                        viaje.DescripcionUnidad = unidades.IDClaveUnidad;
                        break;
                    }
                }

                //Solo hay que insertar viajes en caso de que existan unidades disponibles
                if (NumCamiones >= i)
                {
                    AlmacenaPedidos.Add(viaje);
                    // En este punto hay que validar que el viaje se pueda acomodar , en caso de que no se pueda 
                    // Almacenar entonces hay que volver a buscar el acomodo.
                    //En caso de que exista algun viaje que no pueda ser acomodado se debe enviar un mensaje al sistema.
                }


            }



            ViewState["AlmacenaPedidos"] = AlmacenaPedidos;
            RadGrid1.DataSource = AlmacenaPedidos;
            RadGrid1.DataBind();
            LimpiarCamptura();

            GuardarGrid();

            if (AlmacenaPedidos != null && AlmacenaPedidos.Count > 0)
            {
                float Viajes_Programados = AlmacenaPedidos.Sum(c => c.CargaViaje);

                if (Viajes_Programados < float.Parse(lblCarga.Text.ToString()))
                {
                    float faltante = float.Parse(lblCarga.Text.ToString()) - Viajes_Programados;
                    lblMensajes.Visible = true;
                    lblMensajes.ForeColor = System.Drawing.Color.Red;
                    lblMensajes.Text =Concretec.Pedidos.Constantes.Mensajes.MSG_MANERA_MANUAL_FULL + faltante.ToString() + Concretec.Pedidos.Constantes.Etiquetas.TAG_M3;
                }
            }
        }
    }
    protected void imgBorrar_Click(object sender, ImageClickEventArgs e)
    {
        AgenteViajes _agente = new AgenteViajes();
        bool salida = false;
        salida = _agente.LimpiaViajesPedido(IDPedido);
        if (salida)
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_VIAJES_PEDIDO + IDPedido.ToString() + Concretec.Pedidos.Constantes.Mensajes.MSG_ELIMINADOS_EXITO);
            llenaGrid();
            imgProgAuto.Visible = true;
            //imgGuardar.Visible = true;
            BuscaUnidadesLibres_Sin_Planta();
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.ERROR_DEL_VIAJE);
        }
    }
    protected void tiposviaje_SelectedIndexChanged(object sender, EventArgs e)
    {
        BuscaUnidadesLibres_Sin_Planta();
        switch (IDTipoViaje)
        {
            case 1:
                carga.Text = "7";
                break;
            case 2:
                carga.Text = "0";
                break;
            default:
                carga.Text = "7";
                break;
        }
        cargaoperador();
        enciende();
    }


    protected void RadGrid1_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {

    }

    protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
    {
        Viaje _p = new Viaje();
        switch (e.CommandName)
        {
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_CANCELAR:
                _p = new Viaje();
                cargaEntidad(_p, e);
                AgenteViajes agente = new AgenteViajes();
                bool salida = false;

                salida = agente.EliminaViaje(_p.IDPedido, _p.IDViaje, DatosUsuario.Id_Usuario);
                if (salida)
                {
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.EXITO_DEL_VIAJE);
                    llenaGrid();
                }
                else
                {
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.ERROR_DEL_VIAJE);
                }
                break;
        }
    }

    private void cargaEntidad(Viaje p, GridCommandEventArgs e)
    {
        p.IDPedido = IDPedido;


        if (e.Item.Cells[2].Text != "&nbsp;")
        { p.IDViaje = int.Parse(e.Item.Cells[2].Text); }
        else
        { p.IDViaje = 0; }
    }

    private void llenaGrid()
    {
        ViewState["AlmacenaPedidos"] = null;


        AgentePedidos ap = new AgentePedidos();
        List<Viaje> viajes = new List<Viaje>();
        viajes = ap.LeerViajesPedido(IDPedido);
        if (viajes.Count == 0)
        {
            RadGrid1.Columns[9].Visible = false;
        }

        ViewState["AlmacenaPedidos"] = viajes;

        RadGrid1.DataSource = viajes;
        RadGrid1.DataBind();
    }
    protected void operadores_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void estatusviaje_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void horainicio_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        DateTime HoraCompromiso = DateTime.Parse(lblFecha.Text.ToString());
        TimeSpan TiempoDesfase = new TimeSpan(0, Desfase, 0);
        TimeSpan TiempoCiclo = new TimeSpan(2, 0, 0);
        TimeSpan TiempoInicio = new TimeSpan(1, 0, 0);
        DateTime _horainicio = HoraCompromiso.Subtract(TiempoInicio);
        DateTime _horainicio_cambio = _horainicio;

        horafin.SelectedDate = horainicio.SelectedDate.Value.Add(TiempoCiclo);

        BuscaUnidadesLibres_Sin_Planta();
        enciende();

    }
    protected void fechainicio_SelectedDateChanged1(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        BuscaUnidadesLibres_Sin_Planta();
    }
    protected void horafin_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        BuscaUnidadesLibres_Sin_Planta();
    }
    protected void imgImprimir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Pedido_Print_FF.aspx?IDPedido=" + IDPedido.ToString(), "_new", "width=800,height=700");
    }
}