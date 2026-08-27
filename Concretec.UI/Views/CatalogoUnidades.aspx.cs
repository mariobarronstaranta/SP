using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;


public partial class Views_CatalogoUnidades : System.Web.UI.Page
{
    AgenteUnidades Agente = new AgenteUnidades();

    private const string VS_CIUDAD_ORIGINAL = "CiudadOriginal";
    private const string VS_PLANTA_ORIGINAL = "PlantaOriginal";
    private const string VS_OPERADOR_ORIGINAL = "OperadorOriginal";
    private const string VS_TIPO_CAMBIO = "TipoCambioUbicacion";
    private const string VS_VALOR_PENDIENTE = "ValorCambioUbicacion";
    private const string VS_REDIRECCION_MENSAJE = "RedireccionMensaje";
    private const string CAMBIO_CIUDAD = "Ciudad";
    private const string CAMBIO_PLANTA = "Planta";

    private int IDUnidad
    {
        get
        {
            string pkunidad = this.PKUnidad.Text;
            int salida = 0;
            if (pkunidad.Trim() != "")
            {
                salida = int.Parse(pkunidad);
            }
            return salida;
        }
    }

    public string ciudad
    { get { return this.cboCiudad.SelectedValue.ToString(); } }

    private string ClaveUnidad
    { get { return this.claveUnidad.Text; } }

    private string CveAlterna
    { get { return this.cvealterna.Text; } }

    private int Marca
    { get { return int.Parse(marca.SelectedValue); } }

    private int Operador
    { get { return int.Parse(operador.SelectedValue); } }

    private int? Modelo
    {
        get
        {
            string modelo = this.modelo.Text;
            int? salida = null;
            if (modelo.Trim() != "")
            {
                salida = int.Parse(modelo);
            }
            return salida;
        }
    }

    private string NoSerie
    { get { return this.noserie.Text; } }

    private string Placas
    { get { return this.placas.Text; } }

    private string Poliza
    { get { return this.poliza.Text; } }

    private string Inciso
    { get { return this.inciso.Text; } }

    private string Propietario
    { get { return this.propietario.Text; } }

    private string Observaciones
    { get { return this.observaciones.Text; } }

    private int PlantaU
    { get { return int.Parse(planta.SelectedValue); } }

    private int Combustible
    { get { return int.Parse(combustible.SelectedValue); } }

    private int TipoPlaca
    { get { return int.Parse(this.tipoplacas.SelectedValue); } }

    private int CentroCostos
    { get { return int.Parse(this.centrocostos.SelectedValue); } }

    private int Aseguradora
    { get { return int.Parse(this.aseguradora.SelectedValue); } }

    public DateTime? VigenciaInicial
    {
        get
        {
            string fecha = vigenciainicial.DateInput.Text;
            DateTime? Salida = null;
            if (fecha.Length > 0)
            { Salida = DateTime.Parse(vigenciainicial.DateInput.Text.Substring(0, 10)); }
            return Salida;
        }
    }

    public DateTime? VigenciaFinal
    {
        get
        {
            string fecha = vigenciafinal.DateInput.Text;
            DateTime? Salida = null;
            if (fecha.Length > 0)
            { Salida = DateTime.Parse(vigenciafinal.DateInput.Text.Substring(0, 10)); }
            return Salida;
        }
    }

    public DateTime? VerificacionVehicular
    {
        get
        {
            string fecha = verificacionvehicular.DateInput.Text;
            DateTime? Salida = null;
            if (fecha.Length > 0)
            { Salida = DateTime.Parse(verificacionvehicular.DateInput.Text.Substring(0, 10)); }
            return Salida;
        }
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

    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
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

            if (!this.IsPostBack)
            {
                this.modelo.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
                llenacombos();
                cargaroperador();

                lblViajesProgramados.Text = "0";

                if (Session["UnidadEdicion"] != null)
                {
                    planta.Enabled = true;
                    string claveunidad = Session["UnidadEdicion"].ToString();
                    CargaEdicion(claveunidad);
                    GuardarUbicacionOriginal();
                }

            }
        }

    }

    public List<Unidad> ValidaExisteUnidad(string CveUnidad, int IdUnidad)
    {
        List<Unidad> salida = new List<Unidad>();
        string cveciudad = DatosUsuario.Ciudad.ToString();
        AgenteUnidades agente = new AgenteUnidades();
        salida = agente.ValidaExisteUnidad(CveUnidad, cveciudad, IdUnidad);

        return salida;
    }

    public void llenacombos()
    {

        cargaAseguradora();
        cargaCentrocostos();
        cargaCombustible();
        cargaMarcas();
        CargaCiudades();
        cargaplantas();
        cargaTipoplaca();


    }

    private List<ReasignaViajeCR> BuscaViajesUnidad(int IdUnidad , string CveCiudad , DateTime Desde)
    {
        Concretec.Agentes.AgenteViajes agente = new AgenteViajes();
        List<ReasignaViajeCR> lista = new List<ReasignaViajeCR>();
        lista = agente.BuscaViajesUnidad(IdUnidad, CveCiudad, Desde);

        return lista;
    }

    public void CargaEdicion(string claveunidad)
    {
        Agente = new AgenteUnidades();
        List<ConsultaUnidad> Consulta = new List<ConsultaUnidad>();
        Consulta = Agente.LeerUnidadClave(claveunidad);
        
        

        this.claveUnidad.Text = Consulta[0].IDClaveUnidad;
        this.cvealterna.Text = Consulta[0].CveAlterna;
        this.modelo.Text = Consulta[0].Modelo;
        this.noserie.Text = Consulta[0].NumSerie;
        this.placas.Text = Consulta[0].Placas;
        this.poliza.Text = Consulta[0].Poliza;
        this.inciso.Text = Consulta[0].Inciso;
        this.propietario.Text = Consulta[0].Propietario;
        this.observaciones.Text = "";
        combustible.SelectedValue = Consulta[0].IDTipoCombustible.ToString();
        this.tipoplacas.SelectedValue = Consulta[0].IDTipoPlacas.ToString();
        this.centrocostos.SelectedValue = Consulta[0].IDCentroCostos.ToString();
        aseguradora.SelectedValue = Consulta[0].IDAseguradora.ToString();
        PKUnidad.Text = Consulta[0].IDUnidad.ToString();
        this.marca.SelectedValue = Consulta[0].IDMarca.ToString();
        cboEstatus.SelectedValue = Consulta[0].IDEstatus.ToString();

        SeleccionarValor(this.cboCiudad, Consulta[0].CveCiudad.ToString());
        CargaPlantasCiudad(this.cboCiudad.SelectedValue);
        SeleccionarValor(this.planta, Consulta[0].IdPlanta.ToString());

        cargaroperador();

        SeleccionarValor(this.operador, Consulta[0].IdOperador.ToString());
        if (Consulta[0].InicioVigencia.Year > 1900) { vigenciainicial.SelectedDate = Consulta[0].InicioVigencia; }
        if (Consulta[0].FinVigencia.Year > 1900) { vigenciafinal.SelectedDate = Consulta[0].FinVigencia; }
        if (Consulta[0].VerificacionVehicular.Year > 1900) { verificacionvehicular.SelectedDate = Consulta[0].VerificacionVehicular; }


        List<ReasignaViajeCR> ListaViajes = new List<ReasignaViajeCR>();
        if (Consulta != null)
        {
            ListaViajes = BuscaViajesUnidad(Consulta[0].IDUnidad, this.cboCiudad.SelectedValue, DateTime.Now);
            lblViajesProgramados.Text = ListaViajes.Count.ToString();
        }

    }




    public ListItem Seleccione()
    {
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;

        return item;
    }

    private void cargaroperador()
    {
        AgentePersonal AP = new AgentePersonal();
        string cveCiudad = cboCiudad.SelectedValue;
        if (string.IsNullOrEmpty(cveCiudad) || cveCiudad == Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE)
        {
            cveCiudad = DatosUsuario.Ciudad;
        }

        List<Personal> Lista = AP.ObtenerPersonal("OP", cveCiudad);
        operador.Items.Clear();
        var operadores = from oo in Lista
                         where oo.Estatus == "Activo" && oo.IDPlanta == int.Parse(planta.SelectedValue.ToString())
                         select new { oo.IDPersonal, oo.Nombre };

        ListItem item = new ListItem();
        this.operador.Items.Add(Seleccione());

        foreach (var p in operadores)
        {
            item = new ListItem();
            item.Text = p.Nombre;
            item.Value = p.IDPersonal.ToString();
            this.operador.Items.Add(item);

        }
    }

    private void CargaCiudades()
    {
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();
        cboCiudad.Items.Clear();

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboCiudad.Items.Add(item);

        lc = ac.ObtenerCiudades();
        foreach (Ciudad c in lc)
        {
            item = new ListItem();
            item.Text = c.Descripcion;
            item.Value = c.CveCiudad;
            cboCiudad.Items.Add(item);

        }

        cboCiudad.SelectedValue = DatosUsuario.Ciudad;
    }

    private void CargaPlantasCiudad(string cveciudad)
    {
        planta.Items.Clear();

        AgentePlantas ap = new AgentePlantas();
        List<Planta> ListaPlantas = new List<Planta>();
        ListaPlantas = ap.ObtenerPlantasCiudad(cveciudad);
        ListItem item = new ListItem();
        this.planta.Items.Add(Seleccione());
        foreach (Planta p in ListaPlantas)
        {
            item = new ListItem();
            item.Text = p.Nombre;
            item.Value = p.IDPlanta.ToString();
            this.planta.Items.Add(item);
        }
    }

    private void cargaplantas()
    {
        AgentePlantas ap = new AgentePlantas();
        List<Planta> ListaPlantas = new List<Planta>();
        ListaPlantas = ap.ObtenerPlantas();

        var plantas = from pp in ListaPlantas
                      where pp.Ciudad == DatosUsuario.Ciudad //&& pp.CveDosificadora.Contains("PD")
                      select new { pp.Nombre, pp.IDPlanta };

        ListItem item = new ListItem();
        this.planta.Items.Add(Seleccione());

        foreach (var p in plantas)
        {
            item = new ListItem();
            item.Text = p.Nombre;
            item.Value = p.IDPlanta.ToString();
            this.planta.Items.Add(item);

        }

    }

    private void cargaMarcas()
    {
        Agente = new AgenteUnidades();
        List<MarcaCamion> Marcas = new List<MarcaCamion>();
        Marcas = Agente.ObtenerMarcaCamion();
        ListItem item = new ListItem();
        this.marca.Items.Add(Seleccione());

        foreach (MarcaCamion m in Marcas)
        {
            item = new ListItem();
            item.Text = m.Descripcion;
            item.Value = m.IDMarca.ToString();
            this.marca.Items.Add(item);

        }
    }

    private void cargaCombustible()
    {

        Agente = new AgenteUnidades();
        List<TipoCombustible> combustible = new List<TipoCombustible>();
        combustible = Agente.ObtenerTipoCombustible();

        ListItem item = new ListItem();
        this.combustible.Items.Add(Seleccione());

        foreach (TipoCombustible tp in combustible)
        {
            item = new ListItem();
            item.Text = tp.Descripcion;
            item.Value = tp.IDTipoCombustible.ToString();
            this.combustible.Items.Add(item);
        }
    }

    private void cargaTipoplaca()
    {
        Agente = new AgenteUnidades();
        List<TipoPlacas> ListaPlacas = new List<TipoPlacas>();
        ListaPlacas = Agente.ObtenerTipoPlaca();
        ListItem item = new ListItem();
        this.tipoplacas.Items.Add(Seleccione());

        foreach (TipoPlacas tp in ListaPlacas)
        {
            item = new ListItem();
            item.Text = tp.Descripcion;
            item.Value = tp.IDTipoPlacas.ToString();
            tipoplacas.Items.Add(item);
        }
    }
    private void cargaCentrocostos()
    {
        Agente = new AgenteUnidades();
        List<CentroCostos> centrocosto = new List<CentroCostos>();
        centrocosto = Agente.ObtenerCentroCostos();

        ListItem item = new ListItem();
        this.centrocostos.Items.Add(Seleccione());

        foreach (CentroCostos tp in centrocosto)
        {
            item = new ListItem();
            item.Text = tp.Descripcion;
            item.Value = tp.IDCentroCostos.ToString();
            this.centrocostos.Items.Add(item);

        }
    }

    private void cargaAseguradora()
    {
        Agente = new AgenteUnidades();
        List<Aseguradora> aseguradora = new List<Aseguradora>();
        aseguradora = Agente.ObtenerAseguradoras();

        ListItem item = new ListItem();
        this.aseguradora.Items.Add(Seleccione());

        foreach (Aseguradora a in aseguradora)
        {
            item = new ListItem();
            item.Text = a.Descripcion;
            item.Value = a.IDAseguradora.ToString();
            this.aseguradora.Items.Add(item);
        }
    }


    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Session["UnidadEdicion"] = null;
        Response.Redirect("~/Views/ListaUnidades.aspx");

    }
    protected void imgCancelar_Click(object sender, ImageClickEventArgs e)
    {
        Session["UnidadEdicion"] = null;
        Response.Redirect("~/Views/ListaUnidades.aspx");
    }
    protected void imgGuardar_Click(object sender, ImageClickEventArgs e)
    {
        Agente = new AgenteUnidades();
        bool response = false;
        int _validaunidad = 0;
        List<Unidad> Valida_ExisteUnidad = new List<Unidad>();

        if (PKUnidad.Text.Trim() != "")
        {
            Valida_ExisteUnidad = ValidaExisteUnidad(ClaveUnidad, IDUnidad);
        }
        else
        {
            Valida_ExisteUnidad = ValidaExisteUnidad(ClaveUnidad, -1);
        }

        _validaunidad = Valida_ExisteUnidad.Count();

        bool bEstatus = false;

        if (cboEstatus.SelectedValue == "1")
        {
            bEstatus = true;
        }

        if (PKUnidad.Text.Trim() != "")
        {
            if (_validaunidad == 0)
            {
                List<ConsultaUnidad> unidades = Agente.LeerUnidadClave(ClaveUnidad);
                ConsultaUnidad unidadOriginal = unidades.FirstOrDefault(unidad => unidad.IDUnidad == IDUnidad);

                if (unidadOriginal != null && unidadOriginal.IdPlanta != PlantaU)
                {
                    int viajesActivos = BuscaViajesUnidad(IDUnidad, unidadOriginal.CveCiudad, DateTime.Now).Count;
                    if (viajesActivos >= 1)
                    {
                        MostrarMensaje("No es posible el cambio de planta, aun existen viajes activos por reasignar");
                        return;
                    }
                }

                response = Agente.ActUnidad(IDUnidad, ClaveUnidad, CveAlterna, false, 0, 1, Operador, Aseguradora, PlantaU, Poliza, Inciso,
                VigenciaInicial, VigenciaFinal, Marca, Combustible, TipoPlaca, CentroCostos, bEstatus, Modelo, "", NoSerie, Placas,
                "", Propietario, VerificacionVehicular);
            }
            else
            {
                string mensaje = Concretec.Pedidos.Constantes.Mensajes.LA_UNIDAD + " " + Concretec.Pedidos.Constantes.Mensajes.YA_EXISTE;
                mensaje = mensaje + " en las siguientes plantas ";
                foreach (Unidad elemento in Valida_ExisteUnidad)
                {
                    mensaje = mensaje + elemento.IDClave + " (" + elemento.CvePlanta + "),";
                }
                MostrarMensaje(mensaje);
                response = false;
            }

        }
        else
        {
            if (_validaunidad == 0)
            {
                response = Agente.InsertarUnidad(
                   ClaveUnidad, CveAlterna, false, 0, 0, Operador, Aseguradora, PlantaU, Poliza, Inciso,
                   VigenciaInicial, VigenciaFinal, Marca, Combustible, TipoPlaca, CentroCostos, bEstatus, Modelo, "", NoSerie, Placas,
                   "", Propietario, VerificacionVehicular);

                if (response)
                {
                    MostrarMensaje(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO, "~/Views/ListaUnidades.aspx");
                }
                else
                {

                    MostrarMensaje(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
                }

            }
            else
            {
                string mensaje = Concretec.Pedidos.Constantes.Mensajes.LA_UNIDAD + " " + Concretec.Pedidos.Constantes.Mensajes.YA_EXISTE;
                mensaje = mensaje + " en las siguientes plantas ";
                foreach (Unidad elemento in Valida_ExisteUnidad)
                {
                    mensaje = mensaje + elemento.IDClave + " (" + elemento.CvePlanta + "),";
                }
                MostrarMensaje(mensaje);
                response = false;
            }

        }


        if (response && !pnlMensaje.Visible)
        {
            Session["UnidadEdicion"] = null;
            Response.Redirect("~/Views/ListaUnidades.aspx");
        }

    }
    protected void planta_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!EsEdicionUnidad() || planta.SelectedValue == ObtenerViewState(VS_PLANTA_ORIGINAL))
        {
            cargaroperador();
            return;
        }

        PrepararConfirmacionCambio(CAMBIO_PLANTA, planta.SelectedValue);
    }

    protected void cboCiudad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!EsEdicionUnidad() || cboCiudad.SelectedValue == ObtenerViewState(VS_CIUDAD_ORIGINAL))
        {
            CargaPlantasCiudad(cboCiudad.SelectedValue);
            cargaroperador();
            return;
        }

        PrepararConfirmacionCambio(CAMBIO_CIUDAD, cboCiudad.SelectedValue);
    }

    protected void btnCambiarUbicacion_Click(object sender, EventArgs e)
    {
        string tipoCambio = ObtenerViewState(VS_TIPO_CAMBIO);
        string nuevoValor = ObtenerViewState(VS_VALOR_PENDIENTE);

        if (tipoCambio == CAMBIO_CIUDAD)
        {
            SeleccionarValor(cboCiudad, nuevoValor);
            CargaPlantasCiudad(nuevoValor);
            cargaroperador();
        }
        else if (tipoCambio == CAMBIO_PLANTA)
        {
            SeleccionarValor(planta, nuevoValor);
            cargaroperador();
        }

        GuardarUbicacionOriginal();
        LimpiarCambioPendiente();
    }

    protected void btnCancelarUbicacion_Click(object sender, EventArgs e)
    {
        RestaurarUbicacionOriginal();
        LimpiarCambioPendiente();
    }

    private bool EsEdicionUnidad()
    {
        return Session["UnidadEdicion"] != null;
    }

    private void PrepararConfirmacionCambio(string tipoCambio, string nuevoValor)
    {
        ViewState[VS_TIPO_CAMBIO] = tipoCambio;
        ViewState[VS_VALOR_PENDIENTE] = nuevoValor;
        RestaurarUbicacionOriginal();
        pnlConfirmacionCambio.Visible = true;
    }

    private void GuardarUbicacionOriginal()
    {
        ViewState[VS_CIUDAD_ORIGINAL] = cboCiudad.SelectedValue;
        ViewState[VS_PLANTA_ORIGINAL] = planta.SelectedValue;
        ViewState[VS_OPERADOR_ORIGINAL] = operador.SelectedValue;
    }

    private void RestaurarUbicacionOriginal()
    {
        string ciudadOriginal = ObtenerViewState(VS_CIUDAD_ORIGINAL);
        string plantaOriginal = ObtenerViewState(VS_PLANTA_ORIGINAL);
        string operadorOriginal = ObtenerViewState(VS_OPERADOR_ORIGINAL);

        SeleccionarValor(cboCiudad, ciudadOriginal);
        CargaPlantasCiudad(ciudadOriginal);
        SeleccionarValor(planta, plantaOriginal);
        cargaroperador();
        SeleccionarValor(operador, operadorOriginal);
    }

    private string ObtenerViewState(string clave)
    {
        return ViewState[clave] == null ? string.Empty : ViewState[clave].ToString();
    }

    private void LimpiarCambioPendiente()
    {
        ViewState.Remove(VS_TIPO_CAMBIO);
        ViewState.Remove(VS_VALOR_PENDIENTE);
        pnlConfirmacionCambio.Visible = false;
    }

    private void MostrarMensaje(string mensaje)
    {
        MostrarMensaje(mensaje, null);
    }

    private void MostrarMensaje(string mensaje, string redireccion)
    {
        lblMensaje.Text = mensaje;
        ViewState[VS_REDIRECCION_MENSAJE] = redireccion;
        pnlMensaje.Visible = true;
    }

    protected void btnAceptarMensaje_Click(object sender, EventArgs e)
    {
        string redireccion = ObtenerViewState(VS_REDIRECCION_MENSAJE);
        pnlMensaje.Visible = false;
        ViewState.Remove(VS_REDIRECCION_MENSAJE);

        if (!string.IsNullOrEmpty(redireccion))
        {
            Session["UnidadEdicion"] = null;
            Response.Redirect(redireccion);
        }
    }

    private void SeleccionarValor(ListControl control, string valor)
    {
        ListItem item = control.Items.FindByValue(valor);
        if (item != null)
        {
            control.ClearSelection();
            item.Selected = true;
        }
        else if (control.Items.Count > 0)
        {
            control.SelectedIndex = 0;
        }
    }

    private List<ConsultaUnidad> BuscaUnidadesLibres(int idPlanta, DateTime FechaViaje, string HoraInicio, string HoraFin)
    {
        List<ConsultaUnidad> salida = new List<ConsultaUnidad>();
        AgenteUnidades agente = new AgenteUnidades();
        int TipoViaje = 1;
        salida = agente.BuscaUnidadesLibres(idPlanta, TipoViaje, FechaViaje, HoraInicio, HoraFin);
        return salida;
    }

    private void ReasignaUnidadViajes()
    {

        List<ReasignaViajeCR> listaviajes = BuscaViajesUnidad(IDUnidad, DatosUsuario.Ciudad, DateTime.Now);
        List<ConsultaUnidad> UnidadesLibres = new List<ConsultaUnidad>();
        List<MovimientoCr> tmp_movimientos = new List<MovimientoCr>();
        MovimientoCr tmp_movimiento = new MovimientoCr();
        ConsultaUnidad tmp_unidad = new ConsultaUnidad();
        AgenteViajes Agente = new AgenteViajes();

        bool ActualizaViaje = false;
        bool validaMovimiento = false;

        if (listaviajes.Count == 0)
        { MostrarMensaje(Concretec.Pedidos.Constantes.Mensajes.MSG_REASIGNA_VIAJES_NO_EXISTE); }
        else
        {
            foreach (ReasignaViajeCR viaje in listaviajes)
            {
                UnidadesLibres = BuscaUnidadesLibres(viaje.IdPlantaOrigen, viaje.DT_FechaViaje, viaje.HoraViaje, viaje.HoraViajeFin);

                if (UnidadesLibres.Count == 0)
                {
                    validaMovimiento = false;
                    MostrarMensaje(Concretec.Pedidos.Constantes.Mensajes.MSG_REASIGNACION_UNIDAD_FALLO);
                    return;
                }
                else
                {
                    tmp_movimiento = new MovimientoCr();
                    tmp_unidad = new ConsultaUnidad();
                    tmp_unidad = UnidadesLibres[0];
                    //===================================================================
                    tmp_movimiento.IdViaje = viaje.IdViaje;
                    tmp_movimiento.IdPedido = viaje.IdPedido;
                    tmp_movimiento.IdPlantaOrigen = viaje.IdPlantaOrigen;
                    //===================================================================
                    tmp_movimiento.IdUnidadOriginal = viaje.IdCROrigen;
                    tmp_movimiento.HoraInicioOriginal = viaje.HoraViaje;
                    tmp_movimiento.HoraFinOriginal = viaje.HoraViajeFin;
                    tmp_movimiento.IdOperadorOriginal = 0;
                    //===================================================================
                    tmp_movimiento.IdUnidadDestino = tmp_unidad.IDUnidad;
                    tmp_movimiento.HoraInicioCambio = viaje.HoraViaje;
                    tmp_movimiento.HoraFinCambio = viaje.HoraViajeFin;
                    tmp_movimiento.IdOperadorCambio = tmp_unidad.IdOperador;
                    tmp_movimiento.IdPlantaDestino = viaje.IdPlantaOrigen;
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

                MostrarMensaje(Concretec.Pedidos.Constantes.Mensajes.MSG_REASIGNACION_UNIDAD_EXITO);

            }
        }
    }



    protected void imgReasigna_Click(object sender, ImageClickEventArgs e)
    {
        if (lblViajesProgramados.Text.Trim() == "0")
        {
            MostrarMensaje("No existen Viajes a Reasignar");
            return;
        }
        else
        {
            ReasignaUnidadViajes();
        }
        
    }
}
