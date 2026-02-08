using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_AutorizacionPedidos : System.Web.UI.Page
{
    AgentePedidos Agente = new AgentePedidos();
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
            if (IsPostBack != true)
            {
                DateTime Hoy = DateTime.Now.Date;
                inicio.SelectedDate = Hoy.AddDays(-3);
                fin.SelectedDate = Hoy.AddDays(7);

                cboEstatus.SelectedValue = "5";
            }

            CargaGrid();
        }

        
    }


    private void CargaGrid()
    {
        List<Autorizacion> Lista = new List<Autorizacion>();
        Agente = new AgentePedidos();
        int IDEstatus = int.Parse(cboEstatus.SelectedValue.ToString());
        DateTime desde = DateTime.Parse(inicio.DateInput.Text.ToString().Substring(0, 10));
        DateTime hasta = DateTime.Parse(fin.DateInput.Text.ToString().Substring(0, 10));
        Lista = Agente.BuscaAutorizaciones(DatosUsuario.Ciudad, null, IDEstatus, desde, hasta);
        grdClientes.DataSource = Lista;
        grdClientes.DataBind();
    }


    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void grdClientes_ItemCommand(object source, GridCommandEventArgs e)
    {

        if (e.CommandName == Concretec.Pedidos.Constantes.Etiquetas.TAG_DETALLE)
        {
            Pedido _p = new Pedido();
            Response.Redirect("~/Views/ConsultaPedidoAutorizar.aspx?IDPedido=" + e.Item.Cells[2].Text);
        }
    }

    protected void grdClientes_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }

    protected void grdClientes_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;

            if (e.Item.Cells[11].Text == Concretec.Pedidos.Constantes.Etiquetas.TAG_EN_AUTORIZACION)
            {
                //Pintar color de amarillo
                item.BackColor = System.Drawing.Color.Yellow;
            }
        }
    }
}