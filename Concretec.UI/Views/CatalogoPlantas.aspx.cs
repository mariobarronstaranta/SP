using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Pedidos.BE;
using Concretec.Agentes;
using System.Xml;


public partial class Views_CatalogoPlantas : System.Web.UI.Page
{

    private List<Usuario> LoginSesion
    {
        get
        { return (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO]; }
    }

    /*string Colonia, string Municipio, int IDJefePlanta, string CvePlanta*/

    private string CiudadPlanta
    {
        get
        { return this.ciudad.SelectedValue; }
    }

    private int IDJefePlanta
    {
        get
        { return int.Parse(this.jefeplanta.SelectedValue); }
    }

    private string CvePlanta
    {
        get
        { return this.cveplanta.Text; }
    }

    private string Municipio
    {
        get
        { return this.municipio.Text; }
    }

    private string Colonia
    {
        get
        { return this.colonia.Text; }
    }

    private string NombrePlanta
    {
        get
        { return this.nombre.Text; }
    }

    private string ClaveDosificadora
    {
        get
        { return this.cveDosificadora.Text; }
    }

    private bool EstatusDosificadora
    {
        get
        { return bool.Parse(estatus.SelectedValue); }
    }

    private int ClavePlanta
    {
        get
        { return int.Parse(IdPlanta.Value); }
    }

    private string Telefono_1
    {
        get
        { return this.Telefono.Text; }
    }

    private string Telefono_2
    {
        get
        { return this.Telefono2.Text; }
    }

    private string Calle
    {
        get
        { return calle.Text; }
    }

    private string NumeroInterior
    {
        get
        { return NumInt.Text; }
    }

    private int IDPlantaAlterna1
    { get { return -1; } }

    private int IDPlantaAlterna2
    { get { return -1; } }

    private string NumeroExterior
    {
        get
        { return NumExt.Text; }
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
                CargaCiudades();
                CargaJefePlanta(LoginSesion[0].Ciudad.ToString());
                cargaDatosEdicion();
            }
        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
    }

    private void cargaDatosEdicion()
    {
        if (Session["Planta"] != null)
        {
            AgentePlantas AP = new AgentePlantas();
            Planta p = new Planta();
            int IDPlanta = int.Parse(Session["Planta"].ToString());
            List<Planta> Lista = new List<Planta>();
            Lista = AP.ConsultaPlanta(IDPlanta);
            p = Lista[0];


            cveplanta.Text = p.CvePlanta;
            nombre.Text = p.Nombre;
            cveDosificadora.Text = p.CveDosificadora;
            Telefono.Text = p.Telefono;
            Telefono2.Text = p.Telefono2;
            ciudad.SelectedValue = p.Ciudad;
            municipio.Text = p.Municipio;
            calle.Text = p.Calle;
            colonia.Text = p.Colonia;
            NumInt.Text = p.NumInt;
            NumExt.Text = p.NumExt;
            ciudad.SelectedValue = p.Ciudad;
            jefeplanta.SelectedValue = p.JefePlanta.ToString();
            IdPlanta.Value = p.IDPlanta.ToString();
            CargaPlantas();

            PA1.SelectedValue = p.IDPlantaAlterna1.ToString();
            PA2.SelectedValue = p.IDPlantaAlterna2.ToString();

            if (p.Estatus.ToString() == "True")
            { estatus.Items[0].Selected = true; }
            else
            { estatus.Items[1].Selected = true; }


        }
    }

    private void CargaJefePlanta(string ciudad)
    {
        AgentePersonal ap = new AgentePersonal();
        List<Personal> vendedores = new List<Personal>();
        vendedores = ap.ObtenerPersonal("JEP", ciudad);

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.jefeplanta.Items.Add(item);

        foreach (Personal v in vendedores)
        {
            item = new ListItem();
            item.Text = v.Nombre;
            item.Value = v.IDPersonal.ToString();
            this.jefeplanta.Items.Add(item);

        }

    }

    private void CargaCiudades()
    {
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        ciudad.Items.Add(item);

        lc = ac.ObtenerCiudades();
        foreach (Ciudad c in lc)
        {
            item = new ListItem();
            item.Text = c.Descripcion;
            item.Value = c.CveCiudad;
            ciudad.Items.Add(item);
        }

        ciudad.SelectedValue = DatosUsuario.Ciudad;
        ciudad.Enabled = false;

    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Views/ListaPlantas.aspx");
    }
    protected void imgGuardar_Click(object sender, ImageClickEventArgs e)
    {
        AgentePlantas ap = new AgentePlantas();
        bool respuesta;


        if (IdPlanta.Value != "")
        {
            respuesta = ap.ActPlanta(ClavePlanta, NombrePlanta, ClaveDosificadora, EstatusDosificadora, Telefono_1, Telefono_2, CiudadPlanta, Calle, NumeroInterior, NumeroExterior, 0, Colonia, Municipio, IDJefePlanta, CvePlanta,IDPlantaAlterna1,IDPlantaAlterna2);
        }
        else
        {
            IdPlanta.Value = "0";
            respuesta = ap.InsertarPlanta(ClavePlanta, NombrePlanta, ClaveDosificadora, EstatusDosificadora, Telefono_1, Telefono_2, CiudadPlanta, Calle, NumeroInterior, NumeroExterior, 0, Colonia, Municipio, IDJefePlanta, CvePlanta, IDPlantaAlterna1, IDPlantaAlterna2);
        }

        if (respuesta == true)
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
            Response.Redirect("~/Views/ListaPlantas.aspx");
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
        }
    }
    protected void imgCancelar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Views/ListaPlantas.aspx");
    }

    private void CargaPlantas()
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> planta = new List<Planta>();
        PA1.Items.Clear();
        PA2.Items.Clear();

        planta = au.ObtenerPlantas();
        var plantas = from pp in planta
                      where pp.Ciudad == CiudadPlanta
                      select new { pp.IDPlanta, pp.Nombre };

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.PA1.Items.Add(item);

        foreach (var a in plantas)
        {
            item = new ListItem();
            item.Text = a.Nombre;
            item.Value = a.IDPlanta.ToString().Trim();
            this.PA1.Items.Add(item);

        }

        item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = "-1";
        this.PA2.Items.Add(item);
        foreach (var a in plantas)
        {
            item = new ListItem();
            item.Text = a.Nombre;
            item.Value = a.IDPlanta.ToString().Trim();
            this.PA2.Items.Add(item);

        }

    }


    bool ValidaCaptura()
    { return true; }

    void LimpiaForma()
    {
        nombre.Text = string.Empty;
        cveDosificadora.Text = string.Empty;
        Telefono.Text = string.Empty;
        Telefono2.Text = string.Empty;
        calle.Text = string.Empty;
        NumInt.Text = string.Empty;
        NumExt.Text = string.Empty;
        ciudad.SelectedIndex = 0;
        estatus.SelectedValue = "true";
    }

    protected void imgLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        LimpiaForma();
    }
    protected void ciudad_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargaPlantas();
    }
}