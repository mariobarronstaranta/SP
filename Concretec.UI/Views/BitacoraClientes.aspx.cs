using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;

public partial class Views_BitacoraClientes : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int Modulo = int.Parse(Request["ID"].ToString());
        AgenteBitacora Agente = new AgenteBitacora();
        List<Bitacora> Lista = new List<Bitacora>();
        List<Usuario> Login = new List<Usuario>();
        Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
        if (Login == null)
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }
        else
        {
            //Lista = Agente.ObtenerHistorialBitacora(Modulo);
            this.RadGrid1.DataSource = Lista;
        }
    }
}