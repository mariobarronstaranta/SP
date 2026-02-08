using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Config : System.Web.UI.Page
{
    public Usuario DatosUsuario
    {
        get
        {
            Usuario _usuario = new Usuario();
            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
            if (Login != null) { _usuario = Login[0]; }
            return _usuario;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //trhidden
        if (DatosUsuario.UserName == null)
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }
        else
        {
            if (DatosUsuario.UserName.ToUpper() == "VICTORIANO" || DatosUsuario.UserName.ToUpper() == "MBARRON")
            {
                trhidden.Visible = true;
            }
            else
            {
                trhidden.Visible = false;
            }
        }
    }
}