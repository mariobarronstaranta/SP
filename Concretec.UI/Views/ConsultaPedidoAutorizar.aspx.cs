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

public partial class Views_ConsultaPedidoAutorizar : System.Web.UI.Page
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

    public int IDPedido
    { get { return int.Parse(Request.QueryString["IDPedido"]); } }

    public Pedido DatosPedido
    {
        get
        {
            List<Pedido> _datospedidoa = new List<Pedido>();
            Pedido _datospedido = new Pedido();
            AgentePedidos agente = new AgentePedidos();
            _datospedidoa = agente.ConsultaPedido(IDPedido);
            _datospedido = _datospedidoa[0];
            return _datospedido;
        }
    }

    public Autorizacion DatosAutorizar
    {
        get 
        {
            List<Autorizacion> pedidos = new List<Autorizacion>();
            AgentePedidos agente = new AgentePedidos();
            pedidos = agente.BuscaAutorizaciones(DatosUsuario.Ciudad, IDPedido,null,null,null);
            return pedidos[0];
        }
    }

    public int IdPedido
    { get { return int.Parse(numPedido.Text); } }

    public float LimiteCredito
    { get { return float.Parse(limcredito.Text); } }

    public float Saldo
    { get { return float.Parse(saldoactual.Text); } }

    public float CreditoSolicitado
    { get { return float.Parse(Solicitado.Text); } }

    public string UserName
    { get { return DatosUsuario.UserName; } }

    //int IDPedido, float LimiteCredito, float Saldo, float Solicitado, string UserName

    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        numPedido.Text = IDPedido.ToString();
        FechaCompromiso.Text = DatosPedido.FechaCompromiso.ToShortDateString();
        datoscliente.Text = DatosPedido.NombreCliente;
        dircliente.Text = DatosPedido.DireccionCliente;
        datosobra.Text = DatosPedido.NombreObra;
        dirobra.Text = DatosPedido.DireccionObra;
        ColCliente.Text = DatosPedido.ColoniaCliente;
        CdCliente.Text = DatosPedido.CiudadCliente;
        CdObra.Text = DatosPedido.CiudadObra;

        saldoactual.Text = DatosAutorizar.SaldoActual.ToString("N");
        Solicitado.Text = DatosAutorizar.CreditoSolicitado.ToString("N");
        limcredito.Text = DatosAutorizar.LimiteCredito.ToString("N");
    }
    protected void imgcancelar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AutorizacionPedidos.aspx");
    }

    bool AutorizaPedido(int IDPedido, float LimiteCredito, float Saldo, float Solicitado, string UserName, int Estatus)
    {
        AgentePedidos Agente = new AgentePedidos();
        bool salida = false;
        salida = Agente.AutorizacionPedido(IDPedido, LimiteCredito, Saldo, Solicitado, UserName, Estatus);
        return salida;
    }

    protected void imgAutorizar_Click(object sender, ImageClickEventArgs e)
    {
        bool status = false;
        status = AutorizaPedido(IdPedido, LimiteCredito, Saldo, CreditoSolicitado, UserName, 6);
        if (status == true) 
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.EL_PEDIDO + Concretec.Pedidos.Constantes.Mensajes.AUTORIZACION_EXITO);
            imgDenegar.Visible = false;
            imgAutorizar.Visible = true;
            //Response.Redirect("AutorizacionPedidos.aspx"); 
        }
        else 
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO); 
        }
    }
    protected void imgDenegar_Click(object sender, ImageClickEventArgs e)
    {
        bool status = false;
        status = AutorizaPedido(IdPedido, LimiteCredito, Saldo, CreditoSolicitado, UserName, 7);
        if (status == true) 
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_PEDIDO_DENEGADO);
            imgDenegar.Visible = false;
            imgAutorizar.Visible = true;
        }
        else 
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO); 
        }
    }
}