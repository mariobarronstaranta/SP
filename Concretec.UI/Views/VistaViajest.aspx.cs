using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;

public partial class Views_VistaViajest : System.Web.UI.Page
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
            consultaViajes(Login[0].Ciudad);
        }
    }

    private void consultaViajes(string ciudad)
    {
        List<Viaje> LPV = new List<Viaje>();
        AgentePedidos ap = new AgentePedidos();
        int pedidohijo =0;
        //pedidohijo = (int)Session["idpedidohijo"];

        LPV= ap.LeerViajes(pedidohijo, ciudad);
        if (LPV != null)
        {
            grdViajes.DataSource = LPV;
            grdViajes.DataBind();

        }
        else
        {
            Response.Write("<script language='javascript'>alert('Ha ocurrido un error al consultar viajes del pedido ' " + pedidohijo + ");</script>");
            Response.Write("<script language='javascript'>location.href('~/Views/ListaPedidos.aspx');</script>");
        }


            
    }

   
}