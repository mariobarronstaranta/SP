using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_CierrePedido : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        llenaHeader();
        llenagrid();
    }

    public int IDPedido
    {
        get
        {
            int salida = 0;
            if (Request.QueryString["IDpedido"] != null)
            {
                salida = int.Parse(Request.QueryString["IDpedido"]);
            }

            return salida;
        }
    }

    
    public Usuario DatosUsuario
    {
        get
        {

            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
            return Login[0];
        }

    }

    void llenagrid()
    {
        AgentePedidos Agente = new AgentePedidos();
        List<PedidoViaje> ListaVP = new List<PedidoViaje>();
        Agente = new AgentePedidos();
        ListaVP = Agente.LeerCierreViajesPedido(int.Parse(Request.QueryString["IDpedido"]));

        GridViajes.DataSource = ListaVP;
        GridViajes.DataBind(); 
    }

    void llenaHeader()
    {
        Pedido DatosPedido = DatosHeader(DatosUsuario.Ciudad, IDPedido);
        LitCantidad.Text = DatosPedido.CargaTotal.ToString();
        litCliente.Text = DatosPedido.NombreCliente;
        litCvePedido.Text = DatosPedido.IDPedido.ToString();
        litDireccion.Text = DatosPedido.DireccionObra;
        LitFecha.Text = DatosPedido.FechaCompromiso.Day.ToString() + "-" + nombremes(DatosPedido.FechaCompromiso.Month) + "-" + DatosPedido.FechaCompromiso.Year.ToString();
        litObra.Text = DatosPedido.NombreObra;
        LitProducto.Text = DatosPedido.NombreProducto;
        LitViajes.Text = DatosPedido.Viajes.ToString();
    }

    Pedido DatosHeader(string CveCiudad, int IDPedido)
    {
        Pedido salida = new Pedido();
        AgentePedidos ap = new AgentePedidos();
        salida = ap.BuscaDatosPedido(IDPedido, CveCiudad);
        return salida;

    }
    protected void btnCierre_Click(object sender, ImageClickEventArgs e)
    {
        AgentePedidos agente = new AgentePedidos();
        bool salida = false;
        salida = agente.ActualizaEstatusPedido(IDPedido, 2);
        if(salida==true)
        {Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_PEDIDO_CERRADO);}
        else
        { Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO); }
    }
    protected void GridViajes_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }

    string nombremes(int imes)
    {
        string salida = string.Empty;

        switch (imes)
        {
            case 1:
                salida = Concretec.Pedidos.Constantes.Etiquetas.TAG_MES_ENERO;
                break;
            case 2:
                salida = Concretec.Pedidos.Constantes.Etiquetas.TAG_MES_FEBRERO;
                break;
            case 3:
                salida = Concretec.Pedidos.Constantes.Etiquetas.TAG_MES_MARZO;
                break;
            case 4:
                salida = Concretec.Pedidos.Constantes.Etiquetas.TAG_MES_ABRIL;
                break;
            case 5:
                salida = Concretec.Pedidos.Constantes.Etiquetas.TAG_MES_MAYO;
                break;
            case 6:
                salida = Concretec.Pedidos.Constantes.Etiquetas.TAG_MES_JUNIO;
                break;
            case 7:
                salida = Concretec.Pedidos.Constantes.Etiquetas.TAG_MES_JULIO;
                break;
            case 8:
                salida = Concretec.Pedidos.Constantes.Etiquetas.TAG_MES_AGOSTO;
                break;
            case 9:
                salida = Concretec.Pedidos.Constantes.Etiquetas.TAG_MES_SEPTIEMBRE;
                break;
            case 10:
                salida = Concretec.Pedidos.Constantes.Etiquetas.TAG_MES_OCTUBRE;
                break;
            case 11:
                salida = Concretec.Pedidos.Constantes.Etiquetas.TAG_MES_NOVIEMBRE;
                break;
            case 12:
                salida = Concretec.Pedidos.Constantes.Etiquetas.TAG_MES_DICIEMBRE;
                break;
            
        }

        return salida;
    }

    public bool PuedeRemisionar()
    {
        Pedido DatosPedido = new Pedido();
        double diasdiferencia = 0;
        DateTime fechapedido;
        bool salida = false;
        if (DatosUsuario.Perfil == Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_ADMON)
        {
            salida = true;
        }
        else
        {
            DatosPedido = DatosHeader(DatosUsuario.Ciudad, IDPedido);
            fechapedido = DatosPedido.FechaCompromiso;

            TimeSpan t = fechapedido.Date - DateTime.Now.Date;
            diasdiferencia = t.TotalDays;
            if (diasdiferencia == 0 || diasdiferencia == -1)
            {
                salida = true;
            }
            
        }
        return salida;
    }

    protected void GridViajes_ItemCommand(object source, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR:
                // Realizar validacion del dia mayor y el dia menor.
                if (PuedeRemisionar())
                {
                    Response.Redirect("~/Views/EditarCierrePedido.aspx?IDPedido=" + Request.QueryString["IDpedido"] + "&IDViaje=" + e.Item.Cells[2].Text);
                }
                else
                {
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_RESTR_REMISION);
                }
                
                break;
        }

    }
}