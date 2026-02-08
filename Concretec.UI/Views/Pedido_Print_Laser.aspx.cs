using System;
using System.Collections.Generic;
using Concretec.Agentes;
using Concretec.Pedidos.BE;

public partial class Views_Pedido_Print_Laser : System.Web.UI.Page
{
    public int IDPedido
    { get { return int.Parse(Session["DatosUsuario"].ToString()); } }

    public Usuario DatosUsuario
    {
        get
        {

            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
            return Login[0];
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AgentePedidos _agente = new AgentePedidos();
        PedidoHeader _pedidoheader = new PedidoHeader();
        List<Comentario> listacomentarios = new List<Comentario>();

        _pedidoheader = _agente.rpt_headerpedido(int.Parse(Request.QueryString["IDPedido"]), DatosUsuario.Ciudad);
        numPedido.Text = _pedidoheader.IDPedido.ToString();
        FechaRemision.Text = _pedidoheader.FechaRemision;
        NombrePlanta.Text = _pedidoheader.NombrePlanta;
        FechaCompromiso.Text = _pedidoheader.FechaCompromiso;
        HoraPrometida.Text = _pedidoheader.HoraPrometida + " hrs";
        NombreCliente.Text = _pedidoheader.NombreCliente;
        DireccionCliente.Text = _pedidoheader.DireccionCliente;
        ColoniaCliente.Text = ", " + _pedidoheader.ColoniaCliente;
        Telefono.Text = _pedidoheader.Telefono;
        CPObra.Text = _pedidoheader.CPObra;
        PoblacionObra.Text = _pedidoheader.PoblacionObra;
        ClaveObra.Text = _pedidoheader.ClaveObra;
        ClaveCliente.Text = _pedidoheader.ClaveCliente;
        Vendedor.Text = _pedidoheader.Vendedor;

        NombreObra.Text = _pedidoheader.NombreObra;
        DireccionObra.Text = _pedidoheader.DireccionObra;
        EntreCallesObra.Text = _pedidoheader.EntreCallesObra;
        Solicito.Text = _pedidoheader.Solicito;
        Autorizo.Text = _pedidoheader.Autorizo;
        Recibe.Text = _pedidoheader.Recibe;

        Distancia.Text = _pedidoheader.Distancia;
        UsoObra.Text = _pedidoheader.Uso;
        Roji.Text = _pedidoheader.Roji;
        Hrs.Text = _pedidoheader.Hrs;
        Colado.Text = _pedidoheader.Colado;

        string ordencompra = _pedidoheader.OrdenCompra.ToString().Trim();


        if (ordencompra.Length > 0)
        {
            ordencompra = "Orden de compra " + ordencompra + "\n";
            LitComentarios.Text = LitComentarios.Text + ordencompra;
        }

        LitComentarios.Text = LitComentarios.Text + _pedidoheader.Comentarios + "\n";

        _agente = new AgentePedidos();
        listacomentarios = _agente.LeerComentariosPedido(int.Parse(Request.QueryString["IDPedido"]));
        if (listacomentarios.Count > 0)
        {
            foreach (Comentario coment in listacomentarios)
            {
                LitComentarios.Text = LitComentarios.Text + "," + coment.Descripcion;
            }
        }

    }
}