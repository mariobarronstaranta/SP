using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;


public partial class Views_LogIn : PageController
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
  
    protected void cmdAceptar_Click(object sender, EventArgs e)
    {
        string UserName = txtUserName.Text;
        string Password = txtPassword.Text;
        AgenteUsuarios Agente = new AgenteUsuarios();
        List<Usuario> DatosUsuario = new List<Usuario>();
        DatosUsuario = Agente.ValidaUsuario(UserName, Password);
        if (DatosUsuario.Count() == 0)
        {
            Response.Write("Usuario no encontrado");
        }
        else
        {
            Session["DatosUsuario"] = DatosUsuario;
            Response.Redirect("ListaClientes.aspx");
        }
    }
}