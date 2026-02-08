using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using System.Web.Configuration;

public partial class Views_EditarCierrePedido : System.Web.UI.Page
{
    public int Horario_Diurno_Inicio_Hora       = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Inicio_Hora"].ToString());
    public int Horario_Diurno_Inicio_Minuto     = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Inicio_Minuto"].ToString());
    public int Horario_Diurno_Inicio_Segundo    = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Inicio_Segundo"].ToString());

    public int Horario_Diurno_Fin_Hora          = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Fin_Hora"].ToString());
    public int Horario_Diurno_Fin_Minuto        = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Fin_Minuto"].ToString());
    public int Horario_Diurno_Fin_Segundo       = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Fin_Segundo"].ToString());

    public int Horario_Nocturno_Inicio_Hora     = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Inicio_Hora"].ToString());
    public int Horario_Nocturno_Inicio_Minuto   = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Inicio_Minuto"].ToString());
    public int Horario_Nocturno_Inicio_Segundo  = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Inicio_Segundo"].ToString());

    public int Horario_Nocturno_Fin_Hora        = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Fin_Hora"].ToString());
    public int Horario_Nocturno_Fin_Minuto      = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Fin_Minuto"].ToString());
    public int Horario_Nocturno_Fin_Segundo     = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Fin_Segundo"].ToString());

    public int Intervalo_Minutos_Pedidos        = int.Parse(WebConfigurationManager.AppSettings["Intervalo_Minutos_Pedidos"].ToString());
    public int Intervalo_Viajes_Pedidos         = int.Parse(WebConfigurationManager.AppSettings["Intervalo_Viajes_Pedidos"].ToString());


    public int IDViaje
    {
        get
        {
            int salida = 0;
            if (Request.QueryString["IDViaje"] != null)
            {
                salida = int.Parse(Request.QueryString["IDViaje"]);
            }

            return salida;
        }
    }

    public int IDPedido
    {
        get
        {
            int salida = 0;
            if (Request.QueryString["IDpedido"] != null)
            {
                salida = int.Parse(Request.QueryString["IDpedido"]);
            }

            return salida;
        }
    }

    public int IDPlanta
    { get { return int.Parse(this.planta.SelectedValue.ToString()); } }

    public int IDUnidad
    { get { return int.Parse(this.cboUnidad.SelectedValue.ToString()); } }

    public int IDOperador
    { get { return int.Parse(this.cbooperador.SelectedValue.ToString()); } }

    public int CargaViaje
    { get { return 0; } }

    public string HoraInicio
    { get { return dtFechaSalida.SelectedDate.Value.ToShortTimeString(); } }

    public string HoraFin
    { get { return dtLlegadaPlanta.SelectedDate.Value.ToShortTimeString(); } }

    public string HoraLlegadaObra
    { get { return dtLlegadaObra.SelectedDate.Value.ToShortTimeString(); } }

    public string HoraSalidaObra
    { get { return dtSalidaObra.SelectedDate.Value.ToShortTimeString(); } }

    public string remision
    { get { return txtremision.Text; } }

    public string TicketCB2
    { get { return txtCB2.Text; } }

    public string Observaciones
    { get { return txtObservaciones.Text; } }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            llenaHeader();
            CargaPlantas(DatosUsuario.Ciudad);
            Llena_Operadores_Planta();
            CargaContingencias();
            CargaComentarios();
            llenaEdicion();
        }
    }

    void llenaEdicion()
    {
        PedidoViaje salida = new PedidoViaje();
        AgentePedidos ap = new AgentePedidos();
        string _litColadoNocturno = string.Empty;

        salida = ap.EditarCierreViajesPedido(IDPedido, IDViaje);

        if (salida.ColadoNocturno == 1)
        {
            _litColadoNocturno = "SI";
        }
        else
        {
            _litColadoNocturno = "NO";
        }

        txtCarga.Text = salida.CargaViaje.ToString();
        planta.SelectedValue = salida.IDPlanta.ToString();
        txtremision.Text = salida.Remision;
        txtObservaciones.Text = salida.Observaciones;
        dtFechaSalida.SelectedDate = salida.dt_HoraInicio;
        dtLlegadaObra.SelectedDate = salida.dt_HoraLlegadaObra;
        dtSalidaObra.SelectedDate = salida.dt_HoraSalidaObra;
        dtLlegadaPlanta.SelectedDate = salida.dt_HoraFin;
        txtCompromiso.Text = salida.HoraCompromiso;
        cargaunidad();
        cboUnidad.SelectedValue = salida.IDUnidad.ToString();
        litColadoNocturno.Text = _litColadoNocturno;

        //llenaOperadores();
        Llena_Operadores_Planta();

        cbooperador.SelectedValue           = salida.IDOperador.ToString();

        txtCB2.Text = salida.TicketCB2;
        cboContingencias.SelectedValue      = salida.idContingencia.ToString();
        cboObservaciones.SelectedValue      = salida.idComentario.ToString();

        dtFechaSalida.TimeView.TimeFormat   = "HH:mm tt";
        dtLlegadaObra.TimeView.TimeFormat   = "HH:mm tt";
        dtSalidaObra.TimeView.TimeFormat    = "HH:mm tt";
        dtLlegadaPlanta.TimeView.TimeFormat = "HH:mm tt";
       // dtCompromiso.TimeView.TimeFormat    = "HH:mm tt";

        txtfactura.Text                     = salida.factura;
        txtreasignado.Text                  = salida.Reasignacion;
        chkmerma.Checked                    = salida.Merma;

        CargaDatos_Horas(litColadoNocturno.Text);

    }


    private void CargaDatos_Horas(string BanderaColadoNocturno)
    {
        if (BanderaColadoNocturno == "SI")
        {
            //INSTRUCCIONES PARA ACTIVAR HORARIO NOCTURNO
            dtFechaSalida.TimeView.StartTime = new TimeSpan(Horario_Nocturno_Inicio_Hora, Horario_Nocturno_Inicio_Minuto, Horario_Nocturno_Inicio_Segundo);
            dtFechaSalida.TimeView.EndTime = new TimeSpan(Horario_Nocturno_Fin_Hora, Horario_Nocturno_Fin_Minuto, Horario_Nocturno_Fin_Segundo);
            dtFechaSalida.TimeView.Columns = 12;
            dtFechaSalida.TimeView.Interval = new TimeSpan(0, Intervalo_Minutos_Pedidos, 0);

            dtLlegadaObra.TimeView.StartTime = new TimeSpan(Horario_Nocturno_Inicio_Hora, Horario_Nocturno_Inicio_Minuto, Horario_Nocturno_Inicio_Segundo);
            dtLlegadaObra.TimeView.EndTime = new TimeSpan(Horario_Nocturno_Fin_Hora, Horario_Nocturno_Fin_Minuto, Horario_Nocturno_Fin_Segundo);
            dtLlegadaObra.TimeView.Columns = 12;
            dtLlegadaObra.TimeView.Interval = new TimeSpan(0, Intervalo_Minutos_Pedidos, 0);

            dtSalidaObra.TimeView.StartTime = new TimeSpan(Horario_Nocturno_Inicio_Hora, Horario_Nocturno_Inicio_Minuto, Horario_Nocturno_Inicio_Segundo);
            dtSalidaObra.TimeView.EndTime = new TimeSpan(Horario_Nocturno_Fin_Hora, Horario_Nocturno_Fin_Minuto, Horario_Nocturno_Fin_Segundo);
            dtSalidaObra.TimeView.Columns = 12;
            dtSalidaObra.TimeView.Interval = new TimeSpan(0, Intervalo_Minutos_Pedidos, 0);

            dtLlegadaPlanta.TimeView.StartTime = new TimeSpan(Horario_Nocturno_Inicio_Hora, Horario_Nocturno_Inicio_Minuto, Horario_Nocturno_Inicio_Segundo);
            dtLlegadaPlanta.TimeView.EndTime = new TimeSpan(Horario_Nocturno_Fin_Hora, Horario_Nocturno_Fin_Minuto, Horario_Nocturno_Fin_Segundo);
            dtLlegadaPlanta.TimeView.Columns = 12;
            dtLlegadaPlanta.TimeView.Interval = new TimeSpan(0, Intervalo_Minutos_Pedidos, 0);
        }
        else
        {
            //INSTRUCCIONES PARA ACTIVAR HORARIO DIURNO
            dtFechaSalida.TimeView.StartTime = new TimeSpan(Horario_Diurno_Inicio_Hora, Horario_Diurno_Inicio_Minuto, Horario_Diurno_Inicio_Segundo);
            dtFechaSalida.TimeView.EndTime = new TimeSpan(Horario_Diurno_Fin_Hora, Horario_Diurno_Fin_Minuto, Horario_Diurno_Fin_Segundo);
            dtFechaSalida.TimeView.Columns = 12;
            dtFechaSalida.TimeView.Interval = new TimeSpan(0, Intervalo_Minutos_Pedidos, 0);

            dtLlegadaObra.TimeView.StartTime = new TimeSpan(Horario_Diurno_Inicio_Hora, Horario_Diurno_Inicio_Minuto, Horario_Diurno_Inicio_Segundo);
            dtLlegadaObra.TimeView.EndTime = new TimeSpan(Horario_Diurno_Fin_Hora, Horario_Diurno_Fin_Minuto, Horario_Diurno_Fin_Segundo);
            dtLlegadaObra.TimeView.Columns = 12;
            dtLlegadaObra.TimeView.Interval = new TimeSpan(0, Intervalo_Minutos_Pedidos, 0);

            dtSalidaObra.TimeView.StartTime = new TimeSpan(Horario_Diurno_Inicio_Hora, Horario_Diurno_Inicio_Minuto, Horario_Diurno_Inicio_Segundo);
            dtSalidaObra.TimeView.EndTime = new TimeSpan(Horario_Diurno_Fin_Hora, Horario_Diurno_Fin_Minuto, Horario_Diurno_Fin_Segundo);
            dtSalidaObra.TimeView.Columns = 12;
            dtSalidaObra.TimeView.Interval = new TimeSpan(0, Intervalo_Minutos_Pedidos, 0);

            dtLlegadaPlanta.TimeView.StartTime = new TimeSpan(Horario_Diurno_Inicio_Hora, Horario_Diurno_Inicio_Minuto, Horario_Diurno_Inicio_Segundo);
            dtLlegadaPlanta.TimeView.EndTime = new TimeSpan(Horario_Diurno_Fin_Hora, Horario_Diurno_Fin_Minuto, Horario_Diurno_Fin_Segundo);
            dtLlegadaPlanta.TimeView.Columns = 12;
            dtLlegadaPlanta.TimeView.Interval = new TimeSpan(0, Intervalo_Minutos_Pedidos, 0);
        }
    }
        void llenaHeader()
    {
        Pedido DatosPedido = DatosHeader(DatosUsuario.Ciudad, IDPedido);
        LitCantidad.Text = DatosPedido.CargaTotal.ToString();
        litCliente.Text = DatosPedido.NombreCliente;
        litCvePedido.Text = DatosPedido.IDPedido.ToString();
        litDireccion.Text = DatosPedido.DireccionObra;
        LitFecha.Text = DatosPedido.FechaCompromiso.ToLongDateString();
        litObra.Text = DatosPedido.NombreObra;
        LitProducto.Text = DatosPedido.NombreProducto;
        LitViajes.Text = DatosPedido.Viajes.ToString();
    }

    public DateTime FechaViaje
    { get { return DateTime.Now; } }

    private void CargaContingencias()
    {
        cboContingencias.Items.Clear();
        AgentePedidos agente = new AgentePedidos();
        List<Contingencia> lista = new List<Contingencia>();
        lista = agente.LeerContingencias(-1, "", 1, 1);
        ListItem item = new ListItem();

        item = new ListItem();
        item.Text = "(Sin Contingencia)";
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboContingencias.Items.Add(item);

        foreach (Contingencia a in lista)
        {
            item = new ListItem();
            item.Text = a.Descripcion;
            item.Value = a.idContingencia.ToString();
            this.cboContingencias.Items.Add(item);
        }
    }

    private void CargaComentarios()
    {
        cboObservaciones.Items.Clear();
        AgentePedidos agente = new AgentePedidos();
        List<Contingencia> lista = new List<Contingencia>();
        lista = agente.LeerContingencias(-1, "", 1, 2);
        ListItem item = new ListItem();

        item = new ListItem();
        item.Text = "(Sin Observaciones)";
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboObservaciones.Items.Add(item);

        foreach (Contingencia a in lista)
        {
            item = new ListItem();
            item.Text = a.Descripcion;
            item.Value = a.idContingencia.ToString();
            this.cboObservaciones.Items.Add(item);
        }
    }

    private void CargaPlantas(string CveCiudad)
    {
        planta.Items.Clear();
        AgentePlantas au = new AgentePlantas();
        List<Planta> _planta = new List<Planta>();

        _planta = au.ObtenerPlantas();
        var plantas = from pp in _planta
                      where pp.Ciudad == CveCiudad && pp.CveDosificadora.Contains("PD")
                      select new { pp.IDPlanta, pp.Nombre };
        ListItem item = new ListItem();

        foreach (var a in plantas)
        {
            item = new ListItem();
            item.Text = a.Nombre;
            item.Value = a.IDPlanta.ToString().Trim();
            this.planta.Items.Add(item);

        }

    }

    Pedido DatosHeader(string CveCiudad, int IDPedido)
    {
        Pedido salida = new Pedido();
        AgentePedidos ap = new AgentePedidos();
        salida = ap.BuscaDatosPedido(IDPedido, CveCiudad);
        return salida;

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
    protected void imgCancelar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CierrePedido.aspx?IDPedido=" + IDPedido.ToString());
    }

    public string calculaNumRemision()
    {
        AgenteViajes agente = new AgenteViajes();
        string salida = "";
        salida = agente.CalculaNumRemision(IDPedido, IDViaje);
        return salida;
    }

    public PedidoViaje GrabarViajeCierre()
    {
        List<FACT0X> HeadePedido = new List<FACT0X>();
        AgenteViajes agente = new AgenteViajes();
        PedidoViaje salida = new PedidoViaje();

        bool salidaTransaccion = false;
        string NumRemision = "";
        if (txtremision.Text.Length > 0)
        {
            NumRemision = txtremision.Text;
        }
        else
        {
            NumRemision = calculaNumRemision();
        }

        txtremision.Text = NumRemision;

        salidaTransaccion = agente.ActualizaViajeCierrePedido
            (
             IDPedido,
             IDViaje,
             int.Parse(this.planta.SelectedValue.ToString()),
             int.Parse(this.cboUnidad.SelectedValue.ToString()),
             int.Parse(this.cbooperador.SelectedValue.ToString()),
             float.Parse(txtCarga.Text),
             FechaViaje,
             dtFechaSalida.SelectedDate.Value.ToShortTimeString(),
             dtLlegadaPlanta.SelectedDate.Value.ToShortTimeString(),
             dtLlegadaObra.SelectedDate.Value.ToShortTimeString(),
             dtSalidaObra.SelectedDate.Value.ToShortTimeString(),
             txtObservaciones.Text,
             NumRemision,
             TicketCB2,
             txtCompromiso.Text.ToString(),
             int.Parse(cboContingencias.SelectedValue.ToString()),
             int.Parse(this.cboObservaciones.SelectedValue.ToString()),
             this.txtfactura.Text.ToString().Trim(),
             this.chkmerma.Checked,
             this.txtreasignado.Text
             );

        salida.RemisionStr      = NumRemision;
        salida.resultado        = salidaTransaccion;
        salida.IDPedido         = IDPedido;

        return salida;
    }

    protected void imgGuardar_Click(object sender, ImageClickEventArgs e)
    {
        List<FACT0X> Busca_Pedido_Sync                  = new List<FACT0X>();
        List<PARFACT0X> Busca_Remisiones_Sync_Pedido    = new List<PARFACT0X>();
        PARFACT0X elemento_busqueda_sync                = new PARFACT0X();
        AgentePedidos agente                            = new AgentePedidos();
        // Bueno Aqui comienza el desmadrito para mandar  la DB de sincronizacion 

        bool insertadetalle = false;
        agente = new AgentePedidos();

        if (validacaptura())
        {
            // Hay que preparar los datos que se van a transmmitir al SP de insertar el 
            // los datos del pedido
            //Todo: Hacer el Connection String para el nuevo servidor

            PedidoViaje salida = GrabarViajeCierre();
            List<FACT0X> Busca_Pedido_Sync_copy = new List<FACT0X>();

            if (salida.resultado)
            {
                //List<FACT0X> BuscaPedidoSync(int IDPedido)
                Busca_Pedido_Sync = agente.BuscaPedidoSync(IDPedido,salida.RemisionStr);
                agente = new AgentePedidos();

                foreach (FACT0X _elemento in Busca_Pedido_Sync)
                {
                    _elemento.REMISION = salida.RemisionStr;
                    Busca_Pedido_Sync_copy.Add(_elemento);
                }

                insertadetalle = agente.InsertaHeaderSyncPedidoSAE(Busca_Pedido_Sync_copy);
                // Ya que insertamos el header del pedido ahora hay que hacerlo con el destalle
                //1- Buscar todas las remisiones que existen relacionadas al pedido
                // En el SP tiene que discriminar cuales ya existen y no insertarlas
                //List<PARFACT0X> BuscaRemisionesSyncPedido(int IDPedido);
                agente = new AgentePedidos();
                Busca_Remisiones_Sync_Pedido = agente.BuscaRemisionesSyncPedido(IDPedido, salida.RemisionStr);
                // Ahora hay que barrer la coleccion e insertar los valores en la DB Remota
                if (Busca_Remisiones_Sync_Pedido != null && Busca_Remisiones_Sync_Pedido.Count > 0)
                {
                    elemento_busqueda_sync = new PARFACT0X();
                    foreach (PARFACT0X elemento in Busca_Remisiones_Sync_Pedido)
                    {
                        //InsertaDetalleSyncPedidoSAE(PARFACT0X elemento);
                        agente = new AgentePedidos();
                        insertadetalle = false;
                        insertadetalle = agente.InsertaDetalleSyncPedidoSAE(elemento);
                    }
                }

            }

            if (salida.resultado == true)
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
                Response.Redirect("CierrePedido.aspx?IDPedido=" + IDPedido.ToString());
            }
            else
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
            }
        }
    }

    private void cargaunidad()
    {
        AgenteUnidades au = new AgenteUnidades();
        List<ConsultaUnidad> lu = new List<ConsultaUnidad>();
        this.cboUnidad.Items.Clear();
        lu = au.ObtieneUnidad();
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboUnidad.Items.Add(item);

        var camiones = from camion in lu
                       //where (camion.IDClaveUnidad.Contains("CR") || camion.IDClaveUnidad.Contains("BP")) && camion.IdPlanta == IDPlanta && camion.Estatus == "ACTIVO"
                       where (camion.IDClaveUnidad.Contains("CR") || camion.IDClaveUnidad.Contains("BP"))  && camion.Estatus == "ACTIVO" && camion.CveCiudad == DatosUsuario.Ciudad
                       select new { camion.IDUnidad, camion.IDClaveUnidad };

        foreach (var u in camiones)
        {
            item = new ListItem();
            item.Text = u.IDClaveUnidad;
            item.Value = u.IDUnidad.ToString();
            this.cboUnidad.Items.Add(item);
        }
    }

    

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        List<FACT0X> Busca_Pedido_Sync = new List<FACT0X>();
        List<PARFACT0X> Busca_Remisiones_Sync_Pedido = new List<PARFACT0X>();
        PARFACT0X elemento_busqueda_sync = new PARFACT0X();
        AgentePedidos agente = new AgentePedidos();

        bool insertadetalle = false;
        agente = new AgentePedidos();
        string url = "";
        List<FACT0X> Busca_Pedido_Sync_copy = new List<FACT0X>();

        if (validacaptura())
        {
            Busca_Pedido_Sync_copy = new List<FACT0X>();
            bool salidatransaccion = false;
            PedidoViaje salida = GrabarViajeCierre();
            salidatransaccion = salida.resultado;
            url = "Remision_Print_FF.aspx?IDRemision=" + remision.ToString() + "&IDPedido=" + IDPedido.ToString();
            url = url + "&IDViaje=" + IDViaje.ToString() + "&Unidad=" + cboUnidad.SelectedItem.Text;

            // Inicia proceso para sincronizar remisiones SAE
            //List<FACT0X> BuscaPedidoSync(int IDPedido)
            Busca_Pedido_Sync = agente.BuscaPedidoSync(IDPedido, salida.RemisionStr);
            agente = new AgentePedidos();

            foreach (FACT0X _elemento in Busca_Pedido_Sync)
            {
                _elemento.REMISION = salida.RemisionStr;
                Busca_Pedido_Sync_copy.Add(_elemento);
            }

            insertadetalle = agente.InsertaHeaderSyncPedidoSAE(Busca_Pedido_Sync_copy);
            // Ya que insertamos el header del pedido ahora hay que hacerlo con el destalle
            //1- Buscar todas las remisiones que existen relacionadas al pedido
            // En el SP tiene que discriminar cuales ya existen y no insertarlas
            //List<PARFACT0X> BuscaRemisionesSyncPedido(int IDPedido);
            agente = new AgentePedidos();
            Busca_Remisiones_Sync_Pedido = agente.BuscaRemisionesSyncPedido(IDPedido, salida.RemisionStr);
            // Ahora hay que barrer la coleccion e insertar los valores en la DB Remota
            if (Busca_Remisiones_Sync_Pedido != null && Busca_Remisiones_Sync_Pedido.Count > 0)
            {
                elemento_busqueda_sync = new PARFACT0X();
                foreach (PARFACT0X elemento in Busca_Remisiones_Sync_Pedido)
                {
                    //InsertaDetalleSyncPedidoSAE(PARFACT0X elemento);
                    agente = new AgentePedidos();
                    insertadetalle = false;
                    insertadetalle = agente.InsertaDetalleSyncPedidoSAE(elemento);
                }
            }

            //Termina proceso para sincronizar remisiones SAE


            if (salidatransaccion)
            {
                Response.Redirect(url, "_new", "width=800,height=700");
            }
            else
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.USUARIO_FALLIDO + Concretec.Pedidos.Constantes.Mensajes.ERROR_IMPRIMIR);
            }
        }



    }
    protected void planta_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargaunidad();
        Llena_Operadores_Planta();
    }
    protected void imgPrintFF_Click(object sender, ImageClickEventArgs e)
    {
        List<FACT0X>    Busca_Pedido_Sync               = new List<FACT0X>();
        List<PARFACT0X> Busca_Remisiones_Sync_Pedido    = new List<PARFACT0X>();
        PARFACT0X       elemento_busqueda_sync          = new PARFACT0X();
        AgentePedidos   agente                          = new AgentePedidos();
        PedidoViaje salida = new PedidoViaje();
        bool salidaremision = false;
        bool            insertadetalle                  = false;
        agente                                          = new AgentePedidos();
        string url = "";

        List<FACT0X> Busca_Pedido_Sync_copy = new List<FACT0X>();

        if (validacaptura())
        {
            Busca_Pedido_Sync_copy = new List<FACT0X>();
            salida = GrabarViajeCierre();
            salidaremision = salida.resultado;
            url = "Remision_Print_FF.aspx?IDRemision=" + remision.ToString() + "&IDPedido=" + IDPedido.ToString();
            url = url + "&IDViaje=" + IDViaje.ToString() + "&Unidad=" + cboUnidad.SelectedItem.Text;

            // Inicia proceso para sincronizar remisiones SAE
            //List<FACT0X> BuscaPedidoSync(int IDPedido)
            Busca_Pedido_Sync = agente.BuscaPedidoSync(IDPedido, salida.RemisionStr);
            agente = new AgentePedidos();

            foreach (FACT0X _elemento in Busca_Pedido_Sync)
            {
                _elemento.REMISION = salida.RemisionStr;
                Busca_Pedido_Sync_copy.Add(_elemento);
            }


            insertadetalle = agente.InsertaHeaderSyncPedidoSAE(Busca_Pedido_Sync_copy);
            // Ya que insertamos el header del pedido ahora hay que hacerlo con el destalle
            //1- Buscar todas las remisiones que existen relacionadas al pedido
            // En el SP tiene que discriminar cuales ya existen y no insertarlas
            //List<PARFACT0X> BuscaRemisionesSyncPedido(int IDPedido);
            agente = new AgentePedidos();
            Busca_Remisiones_Sync_Pedido = agente.BuscaRemisionesSyncPedido(IDPedido, salida.RemisionStr);
            // Ahora hay que barrer la coleccion e insertar los valores en la DB Remota
            if (Busca_Remisiones_Sync_Pedido != null && Busca_Remisiones_Sync_Pedido.Count > 0)
            {
                elemento_busqueda_sync = new PARFACT0X();
                foreach (PARFACT0X elemento in Busca_Remisiones_Sync_Pedido)
                {
                    //InsertaDetalleSyncPedidoSAE(PARFACT0X elemento);
                    agente = new AgentePedidos();
                    insertadetalle = false;
                    insertadetalle = agente.InsertaDetalleSyncPedidoSAE(elemento);
                }
            }

            //Termina proceso para sincronizar remisiones SAE


            if (salidaremision)
            {
                Response.Redirect(url, "_new", "width=800,height=700");
            }
            else
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.USUARIO_FALLIDO + Concretec.Pedidos.Constantes.Mensajes.ERROR_IMPRIMIR);
            }
        }
        

    }

    public ListItem Seleccione()
    {
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;

        return item;
    }

    private void Llena_Operadores_Planta()
    {
        AgentePersonal AP = new AgentePersonal();
        List<Personal> Lista = AP.ObtenerPersonal("OP", DatosUsuario.Ciudad);
        cbooperador.Items.Clear();
        var operadores = from oo in Lista
                         where oo.Estatus == "Activo" && oo.IDPlanta == int.Parse(planta.SelectedValue.ToString())
                         select new { oo.IDPersonal, oo.Nombre };

        ListItem item = new ListItem();
        this.cbooperador.Items.Add(Seleccione());

        foreach (var p in operadores)
        {
            item = new ListItem();
            item.Text = p.Nombre;
            item.Value = p.IDPersonal.ToString();
            this.cbooperador.Items.Add(item);

        }
    }

    #region Operadores
    public void llena_Operadores()
    {
        AgentePersonal ap = new AgentePersonal();
        List<Personal> lista = new List<Personal>();
        lista = ap.ObtenerChoferUnidad(-1, DatosUsuario.Ciudad);

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cbooperador.Items.Add(item);

        foreach (Personal chofer in lista)
        {
            item = new ListItem();
            item.Text = chofer.Nombre + " " + chofer.APaterno;
            item.Value = chofer.IDPersonal.ToString();
            this.cbooperador.Items.Add(item);
        }

    }

    #endregion

    protected void cboContingencias_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkmerma.Enabled = true;
    }

    protected void chkmerma_CheckedChanged(object sender, EventArgs e)
    {
        if (chkmerma.Checked)
        {
            txtreasignado.Enabled = true;
            if (txtreasignado.Text.Trim().ToString().Length > 0)
            {
                txtreasignado.Text = txtreasignado.Text.Trim().ToString();
            }
            else
            {
                txtreasignado.Text = string.Empty;
            }

        }
        else
        {
            txtreasignado.Text = string.Empty;
            txtreasignado.Enabled = false;
        }
    }

    private bool validacaptura()
    {
        /*
             dtFechaSalida.SelectedDate.Value.ToShortTimeString(),
             dtLlegadaPlanta.SelectedDate.Value.ToShortTimeString(),
             dtLlegadaObra.SelectedDate.Value.ToShortTimeString(),
             dtSalidaObra.SelectedDate.Value.ToShortTimeString(),
        */

        return true;
    }

    protected void dtFechaSalida_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        TimeSpan DifPlantaObra = new TimeSpan(0, 45, 0);
        TimeSpan DifSalidaObra = new TimeSpan(0, 70, 0);
        TimeSpan DifllegadaPlanta = new TimeSpan(1, 55, 0);

        dtLlegadaObra.SelectedDate = dtFechaSalida.SelectedDate.Value.Add(DifPlantaObra);
        dtSalidaObra.SelectedDate = dtFechaSalida.SelectedDate.Value.Add(DifSalidaObra);
        dtLlegadaPlanta.SelectedDate = dtFechaSalida.SelectedDate.Value.Add(DifllegadaPlanta);

    }

    protected void imgPrint_Laser_Click(object sender, ImageClickEventArgs e)
    {
        List<FACT0X> Busca_Pedido_Sync = new List<FACT0X>();
        List<PARFACT0X> Busca_Remisiones_Sync_Pedido = new List<PARFACT0X>();
        PARFACT0X elemento_busqueda_sync = new PARFACT0X();
        AgentePedidos agente = new AgentePedidos();
        PedidoViaje salida = new PedidoViaje();
        bool salidaremision = false;
        bool insertadetalle = false;
        agente = new AgentePedidos();
        string url = "";

        List<FACT0X> Busca_Pedido_Sync_copy = new List<FACT0X>();

        if (validacaptura())
        {
            Busca_Pedido_Sync_copy = new List<FACT0X>();
            salida = GrabarViajeCierre();
            salidaremision = salida.resultado;
            url = "Remision_Print_Laser.aspx?IDRemision=" + remision.ToString() + "&IDPedido=" + IDPedido.ToString();
            url = url + "&IDViaje=" + IDViaje.ToString() + "&Unidad=" + cboUnidad.SelectedItem.Text;

            // Inicia proceso para sincronizar remisiones SAE
            //List<FACT0X> BuscaPedidoSync(int IDPedido)
            Busca_Pedido_Sync = agente.BuscaPedidoSync(IDPedido, salida.RemisionStr);
            agente = new AgentePedidos();

            foreach (FACT0X _elemento in Busca_Pedido_Sync)
            {
                _elemento.REMISION = salida.RemisionStr;
                Busca_Pedido_Sync_copy.Add(_elemento);
            }


            insertadetalle = agente.InsertaHeaderSyncPedidoSAE(Busca_Pedido_Sync_copy);
            // Ya que insertamos el header del pedido ahora hay que hacerlo con el destalle
            //1- Buscar todas las remisiones que existen relacionadas al pedido
            // En el SP tiene que discriminar cuales ya existen y no insertarlas
            //List<PARFACT0X> BuscaRemisionesSyncPedido(int IDPedido);
            agente = new AgentePedidos();
            Busca_Remisiones_Sync_Pedido = agente.BuscaRemisionesSyncPedido(IDPedido, salida.RemisionStr);
            // Ahora hay que barrer la coleccion e insertar los valores en la DB Remota
            if (Busca_Remisiones_Sync_Pedido != null && Busca_Remisiones_Sync_Pedido.Count > 0)
            {
                elemento_busqueda_sync = new PARFACT0X();
                foreach (PARFACT0X elemento in Busca_Remisiones_Sync_Pedido)
                {
                    //InsertaDetalleSyncPedidoSAE(PARFACT0X elemento);
                    agente = new AgentePedidos();
                    insertadetalle = false;
                    insertadetalle = agente.InsertaDetalleSyncPedidoSAE(elemento);
                }
            }

            //Termina proceso para sincronizar remisiones SAE


            if (salidaremision)
            {
                Response.Redirect(url, "_new", "width=800,height=700");
            }
            else
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.USUARIO_FALLIDO + Concretec.Pedidos.Constantes.Mensajes.ERROR_IMPRIMIR);
            }
        }
    }
}