using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using System.Xml;


public partial class Views_CatalogoParametros : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        List<Usuario> Login = new List<Usuario>();
        Login =   (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
        if (Login == null)
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }
        else
        {
            if (!this.IsPostBack)
            { cargaDatosEdicion(); }
        }
        
    }

    private void cargaDatosEdicion()
    {
        if (Session["Parametros"] != null)
        {
            Parametros p = new Parametros();

            p = (Parametros)Session["Parametros"];
            valor.Text = p.Valor;
            descripcion.Text = p.Descripcion;
            clave.Text = p.IDParametro;

        }
        else
        {
            Response.Write("<script>alert('Ha ocurrido un error, favor de revisar la bitacora');</script>");
        }
    }

 
    protected void imgLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        valor.Text = "";
        descripcion.Text = "";

    }

    protected void btnAceptar_Click(object sender, ImageClickEventArgs e)
    {
        
            bool resp;
            resp = false;   

            AgenteParametros ap = new AgenteParametros();
            resp=ap.ActualizaParametro(int.Parse(clave.Text), valor.Text.ToString(), descripcion.Text.ToString());
            if (resp == true)
            { Response.Redirect("~/Views/Parametros.aspx"); }
            else
            { Response.Write("<script>alert('Registro Grabado');</script>"); }
           
       
    }
    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Views/Parametros.aspx");
    }
}
