using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Pedidos.BE;
using Concretec.Agentes;
public partial class Views_RegistraUsuario : System.Web.UI.Page
{
    public string IDUsuario
    {
        get
        {
            string _IDUsuario = "";
            if (Request.QueryString["IdUsuario"] != null)
            {
                _IDUsuario = Request.QueryString["IdUsuario"].ToString();
            }
            return _IDUsuario;
        }
    }

    private string ApellidoMaterno
    {  get { return this.txtAM.Text; } }

    private string ApellidoPaterno
    {  get { return this.txtAP.Text; }  }

    private string UserName
    { get { return txtusername.Text; } }

    private string Password
    { get { return txtpassword.Text; } }

    private string Password2
    { get { return txtpassword2.Text; } }

    private string Nombre
    { get { return txtNombre.Text; } }

    private int Ciudad
    {  get { return int.Parse(cboCiudades.SelectedValue); } }

    private int Perfil
    { get { return int.Parse(this.cboPerfil.SelectedValue); } }

    private int idplanta
    { get { return int.Parse(this.cboPlanta.SelectedValue); } }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!this.IsPostBack)
        {
            CargaCiudades();
            CargaPerfiles();
            if (Request.QueryString["IdUsuario"] != null && Request.QueryString["IdUsuario"] != "")
            { 
                CargaEdicion();
            }
            

        }
    }

    void CargaEdicion()
    {
        AgenteUsuarios ap = new AgenteUsuarios();
        ap = new AgenteUsuarios();
        Usuario EUE = new Usuario();
        List<Usuario> Lista = new List<Usuario>();
        Lista = ap.BuscaUsuarioEdicion(int.Parse(IDUsuario));
        imgLimpiar.Enabled = false;
        EUE = Lista[0];
        

        this.txtAM.Text = EUE.AMaterno;
        this.txtAP.Text = EUE.APaterno;
        this.txtNombre.Text = EUE.Nombre;
        this.txtpassword.Attributes.Add("value",EUE.Password);
        this.txtpassword2.Attributes.Add("value", EUE.Password);
        this.txtpassword2.Text = EUE.Password;
        this.txtusername.Text = EUE.UserName;
        cboCiudades.SelectedValue = EUE.IDCiudad.ToString();
        CargaPlantas(cboCiudades.SelectedItem.ToString());
        this.cboPerfil.SelectedValue = EUE.IDPerfil.ToString();
        this.txtIDUsuario.Text = EUE.IDUsuario.ToString();
        this.cboPlanta.SelectedValue = EUE.IDPlanta.ToString();
        imgGuardar.ImageUrl = "~/Imagenes/Actualizar.png";
    }


    protected void imgCancelar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Views/ListaUsuarios.aspx");

    }
    protected void imgLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        LimpiaForma();
    }
    protected void imgGuardar_Click(object sender, ImageClickEventArgs e)
    {
        AgenteUsuarios Agente = new AgenteUsuarios();
        bool Respuesta = false;
        Guid ClaveUsuario = new Guid();
        ClaveUsuario = Guid.NewGuid();

        if (this.txtIDUsuario.Text == "")
        {
            Respuesta = Agente.InsertaUsuario(ClaveUsuario, UserName, Password, Nombre, ApellidoPaterno, ApellidoMaterno, "", this.Ciudad, this.Perfil,idplanta);
            if (Respuesta == true)
            { Response.Redirect("~/Views/ListaUsuarios.aspx"); ; }
        }
        else
        {
            ClaveUsuario = Guid.Parse(this.txtIDUsuario.Text);
            Respuesta = Agente.ActualizaUsuario(ClaveUsuario, UserName, Password, Nombre, ApellidoPaterno, ApellidoMaterno, "", this.Ciudad, this.Perfil, idplanta);
            if (Respuesta == true)
            { Response.Redirect("~/Views/ListaUsuarios.aspx"); ; }
        }

    }

    private void CargaPerfiles()
    {
        cboPerfil.Items.Clear();
        AgenteUsuarios ac = new AgenteUsuarios();
        List<Perfil> lc = new List<Perfil>();

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboPerfil.Items.Add(item);


        lc = ac.ObtenerPerfiles();
        foreach (Perfil c in lc)
        {
            item = new ListItem();
            item.Text = c.Descripcion;
            item.Value = c.IDPerfil.ToString();
            cboPerfil.Items.Add(item);
        }
    }


    private void LimpiaForma()
    {
        txtAM.Text = string.Empty;
        txtAP.Text = string.Empty;
        txtNombre.Text = string.Empty;
        txtpassword.Text = string.Empty;
        txtpassword2.Text = string.Empty;
        txtusername.Text = string.Empty;
        cboPerfil.SelectedIndex = 0;
        cboCiudades.SelectedIndex = 0;
    }

    private void CargaPlantas(string sCiudad)
    {
        cboPlanta.Items.Clear();
        AgentePlantas agente = new AgentePlantas();
        List<Planta> lista = new List<Planta>();
        string strCiudad = sCiudad;
        string cveCiudad = "";

        switch (strCiudad)
        {
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_MONTERREY:
                cveCiudad = Concretec.Pedidos.Constantes.Etiquetas.TAG_MONTERREY_SH;
                break;
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_AGUASCALIENTES:
                cveCiudad = Concretec.Pedidos.Constantes.Etiquetas.TAG_AGUASCALIENTES_SH;
                break;
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_GUADALAJARA:
                cveCiudad = Concretec.Pedidos.Constantes.Etiquetas.TAG_GUADALAJARA_SH;
                break;
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_LEON:
                cveCiudad = Concretec.Pedidos.Constantes.Etiquetas.TAG_LEON_SH;
                break;
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_PUEBLA:
                cveCiudad = Concretec.Pedidos.Constantes.Etiquetas.TAG_PUEBLA_SH;
                break;
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_QUERETARO:
                cveCiudad = Concretec.Pedidos.Constantes.Etiquetas.TAG_QUERETARO_SH;
                break;
            default:
                cveCiudad = cveCiudad = Concretec.Pedidos.Constantes.Etiquetas.TAG_MONTERREY_SH;
                break;
        }

        lista = agente.ObtenerPlantasCiudad(cveCiudad);
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboPlanta.Items.Add(item);
        foreach (Planta c in lista)
        {
            item = new ListItem();
            item.Text = c.Nombre;
            item.Value = c.IDPlanta.ToString();
            cboPlanta.Items.Add(item);
        }
    }

    private void CargaCiudades()
    {
        cboCiudades.Items.Clear();
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();

        lc = ac.ObtenerCiudades();
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboCiudades.Items.Add(item);
        foreach (Ciudad c in lc)
        {
            item = new ListItem();
            item.Text = c.Descripcion;
            item.Value = c.IDCiudad.ToString();
            cboCiudades.Items.Add(item);
        }

    }
    protected void cboCiudades_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargaPlantas(cboCiudades.SelectedItem.ToString());
    }
}