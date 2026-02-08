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

                if (Session["UnidadEdicion"] != null)
                {
                    planta.Enabled = false;
                    string claveunidad = Session["UnidadEdicion"].ToString();
                    CargaEdicion(claveunidad);
                    Session["UnidadEdicion"] = null;
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
        cargaplantas();
        cargaTipoplaca();


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
        planta.SelectedValue = Consulta[0].IdPlanta.ToString();
        combustible.SelectedValue = Consulta[0].IDTipoCombustible.ToString();
        this.tipoplacas.SelectedValue = Consulta[0].IDTipoPlacas.ToString();
        this.centrocostos.SelectedValue = Consulta[0].IDCentroCostos.ToString();
        aseguradora.SelectedValue = Consulta[0].IDAseguradora.ToString();
        PKUnidad.Text = Consulta[0].IDUnidad.ToString();
        this.marca.SelectedValue = Consulta[0].IDMarca.ToString();
        cboEstatus.SelectedValue = Consulta[0].IDEstatus.ToString();

        cargaroperador();

        this.operador.SelectedValue = Consulta[0].IdOperador.ToString();
        if (Consulta[0].InicioVigencia.Year > 1900) { vigenciainicial.SelectedDate = Consulta[0].InicioVigencia; }
        if (Consulta[0].FinVigencia.Year > 1900) { vigenciafinal.SelectedDate = Consulta[0].FinVigencia; }
        if (Consulta[0].VerificacionVehicular.Year > 1900) { verificacionvehicular.SelectedDate = Consulta[0].VerificacionVehicular; }


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
        List<Personal> Lista = AP.ObtenerPersonal("OP", DatosUsuario.Ciudad);
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
        Response.Redirect("~/Views/ListaUnidades.aspx");

    }
    protected void imgCancelar_Click(object sender, ImageClickEventArgs e)
    {
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
                Alert.Show(mensaje);
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
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
                }
                else
                {

                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
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
                Alert.Show(mensaje);
                response = false;
            }

        }


        if (response)
        {
            Response.Redirect("~/Views/ListaUnidades.aspx");
        }

    }
    protected void planta_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargaroperador();
    }
}