using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;
using System.Text;

public partial class Views_ConsultaPedido : System.Web.UI.Page
{
    public int IDPedido
    { get { return int.Parse(Request.QueryString["IDPedido"]); } }
    
    public Pedido DatosPedido
    {    
        get {
            List<Pedido> _datospedidoa = new List<Pedido>();
            Pedido _datospedido = new Pedido();
            AgentePedidos agente = new AgentePedidos();
            _datospedidoa = agente.ConsultaPedido(IDPedido);
            _datospedido = _datospedidoa[0];
            return _datospedido; 
        } 
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        numPedido.Text = IDPedido.ToString();
        FechaCompromiso.Text = DatosPedido.FechaCompromiso.ToShortDateString();
        datoscliente.Text = DatosPedido.NombreCliente;
        dircliente.Text =  DatosPedido.DireccionCliente;
        datosobra.Text = DatosPedido.NombreObra ;
        dirobra.Text = DatosPedido.DireccionObra;
        ColCliente.Text = DatosPedido.ColoniaCliente;
        CdCliente.Text = DatosPedido.CiudadCliente;
        CdObra.Text = DatosPedido.CiudadObra;
        lit_nombreusuario.Text = DatosPedido.NombreUsuario;
        lit_fechacreado.Text = DatosPedido.FechaCreacion;//NombreUsuario
        lit_HoraCompromiso.Text = DatosPedido.HoraPrometida.ToShortTimeString();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("pedidos_remision_Print.aspx?IDPedido=" + Request.QueryString["IDPedido"],"_new","width=800,height=700");
           
    }
    protected void ImprimirFF_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Pedido_Print_FF.aspx?IDPedido=" + Request.QueryString["IDPedido"], "_new", "width=800,height=700");
    }
}

