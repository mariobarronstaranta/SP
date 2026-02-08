using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_LogOff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["DatosUsuario"] = null;
        Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
    }
}