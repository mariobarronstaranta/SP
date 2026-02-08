using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Pedidos.BE;
using Concretec.Agentes;

public partial class Views_Usuarios : System.Web.UI.Page
{
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
                cargaDatosEdicion();

            }
        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {

    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Views/ListaUsuarios.aspx");
    }

    private void cargaDatosEdicion()
    {
        if (Session["Usuarios"] != null)
        {
            Usuario u = new Usuario();

            u = (Usuario)Session["Usuarios"];
            nombre.Text = u.Nombre;
            if (u.Estatus.ToString() == "True")
            { estatus.Items[0].Selected = true; }
            else { estatus.Items[1].Selected = true; }
            this.password.Text = u.Password;
            perfil.SelectedValue = u.IDPerfil.ToString();


        }
    }



}
