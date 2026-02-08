using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;


public partial class Views_CatContingencia : System.Web.UI.Page
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

    public string ClaveContingencia
    {
        get
        {
            string salida = string.Empty;
            if (Request.QueryString["ClaveContingencia"] != null)
            {
                salida = Request.QueryString["ClaveContingencia"].ToString();
            }
            else
            {
                salida = txtclave.Text.ToString();
            }
            return salida;
        }
    }

    public string Nombre
    { get { return this.txtdescripcion.Text.ToString(); } }

    public int idCategoria
    { 
    get { return int.Parse(this.cboCategoria.SelectedValue.ToString()); } 
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //********************************************************
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
                CargaCategorias();
                cboCategoria.Enabled = true;

                if (ClaveContingencia != string.Empty)
                {
                    CargaDatosEdicion();
                }

            }
        }
        //********************************************************
    }

    public void CargaDatosEdicion()
    {
        AgentePedidos Agente = new AgentePedidos();
        List<Contingencia> Lista = new List<Contingencia>();
        Contingencia elemento = new Contingencia();
        string clave = Request.QueryString["ClaveContingencia"].ToString();

        try
        {
            Lista = Agente.LeerContingencias(int.Parse(clave.ToString()), "", -1,-1);
            if (Lista.Count > 0)
            {
                elemento = Lista[0];
                txtclave.Text = elemento.idContingencia.ToString();
                txtdescripcion.Text = elemento.Descripcion.ToString();
                cboCategoria.SelectedValue = elemento.IdCategoriaObservaciones.ToString();
                cboCategoria.Enabled = false;
            }
        }
        catch
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.ERROR_CONSULTA);
        }
        
    }

    protected void imgCancelar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Contingencia.aspx");
    }
    protected void imgLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        txtdescripcion.Text = "";
    }
    protected void imgGuardar_Click(object sender, ImageClickEventArgs e)
    {
        AgentePedidos AP = new AgentePedidos();
        bool salida = false;
        if (this.txtclave.Text.Length == 0)
        {
            txtclave.Text = "-1";
        }
        salida = AP.InsertaContingencia(int.Parse(ClaveContingencia), Nombre, 1, idCategoria);

        if (salida == true)
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
            }
        else
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
            }
        
        Response.Redirect("Contingencia.aspx");
    }

    private void CargaCategorias()
    {
        //cboCategoria
        AgenteFiltros agente = new AgenteFiltros();
        List<Categoria> Categorias = agente.LeerCategorias(-1);
        cboCategoria.Items.Clear();

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = "-1";
        this.cboCategoria.Items.Add(item);


        foreach (var a in Categorias)
        {
            item = new ListItem();
            item.Text = a.Descripcion;
            item.Value = a.IdCategoria.ToString();
            this.cboCategoria.Items.Add(item);
        }
    }
}