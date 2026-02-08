using System;
using System.Collections.Generic;
using Concretec.Agentes;
using Concretec.Pedidos.BE;

public partial class Views_Remision_Print_Laser : System.Web.UI.Page
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

        _pedidoheader = _agente.rpt_headerremision(Request.QueryString["IDRemision"].ToString(), int.Parse(Request.QueryString["IDPedido"]), DatosUsuario.Ciudad);
        numPedido.Text = _pedidoheader.IDRemision.ToString();
        FechaRemision.Text = _pedidoheader.FechaRemision.ToString();
        NombrePlanta.Text = _pedidoheader.NombrePlanta;
        lituso.Text = _pedidoheader.Uso;
        litPedido.Text = _pedidoheader.IDPedido.ToString();
        litPdo.Text = _pedidoheader.ClaveProducto;
        litMPedidos.Text = _pedidoheader.CargaTotal.ToString();
        litMSurt.Text = _pedidoheader.MSurtido.ToString();
        LitXSurt.Text = _pedidoheader.MXSurtir.ToString();

        NombreCliente.Text = _pedidoheader.NombreCliente;
        DireccionCliente.Text = _pedidoheader.DireccionCliente;
        ColoniaCliente.Text = ", " + _pedidoheader.ColoniaCliente;
        Telefono.Text = _pedidoheader.Telefono;
        CPObra.Text = _pedidoheader.CPObra;

        NombreObra.Text = _pedidoheader.NombreObra + " " + _pedidoheader.Contrato; // Aqui hay que concatenarle el num contrato
        DireccionObra.Text = _pedidoheader.DireccionObra;
        string entrecalles = "";
        string roji = "";

        entrecalles = _pedidoheader.EntreCallesObra;
        roji = _pedidoheader.Roji.ToString();

        if (_pedidoheader.EntreCallesObra.Length > 0)
        {
            entrecalles = "Entrecalles : " + entrecalles;
        }

        if (_pedidoheader.Roji.Length > 0)
        {
            roji = ",Roji: " + roji;
        }


        EntreCallesObra.Text = entrecalles + ' ' + roji;
        LitComentarios.Text = _pedidoheader.Comentarios;

        litUnidad.Text = _pedidoheader.CveUnidad;
        litOperador.Text = _pedidoheader.Operador;
        //litJefe.Text = _pedidoheader.JefePlanta;
        litsalida.Text = _pedidoheader.HoraSalida;
        litConformidad.Text = _pedidoheader.Firma;

        string ordencompra = _pedidoheader.OrdenCompra.ToString().Trim();
        if (ordencompra.Length > 0)
        {
            ordencompra = "Orden de compra " + ordencompra + "\n";
            LitComentarios.Text = LitComentarios.Text + ordencompra;
        }

        _agente = new AgentePedidos();
        listacomentarios = _agente.LeerComentariosRemision(Request.QueryString["IDRemision"]);
        if (listacomentarios.Count > 0)
        {
            foreach (Comentario coment in listacomentarios)
            {
                LitComentarios.Text = LitComentarios.Text + "," + coment.Descripcion;
            }
        }
    }
}