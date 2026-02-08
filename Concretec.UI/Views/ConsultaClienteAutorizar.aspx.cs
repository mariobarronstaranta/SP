using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_ConsultaClienteAutorizar : System.Web.UI.Page
{
    public float LimiteCredito
    { get { return float.Parse(limcredito.Text); } }

    public float Saldo
    { get { return float.Parse(saldoactual.Text); } }

    public float CreditoSolicitado
    { get { return float.Parse(Solicitado.Text); } }

    public string UserName
    { get { return DatosUsuario.UserName; } }

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
        this.txtLimCredito.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
        this.txtSaldoNuevo.Attributes.Add("OnKeyPress", "return AcceptNum(event)");

        if (!this.IsPostBack)
        {
            AgenteClientes agente = new AgenteClientes();
            Cliente entidad = new Cliente();
            entidad = agente.BuscarCliente(int.Parse(Request.QueryString[0]), DatosUsuario.Ciudad);

            txtColonia.Text = entidad.Colonia;
            txtCorreo.Text = entidad.Email;
            txtCP.Text = entidad.CP;
            txtDescuento.Text = entidad.Descuento;
            txtDireccion.Text = entidad.Direccion;
            txtFax.Text = entidad.Fax;
            txtNombre.Text = entidad.NombreCompleto;
            txtPoblacion.Text = entidad.Poblacion;
            txtRFC.Text = entidad.RFC;
            txtTelefono.Text = entidad.Telefonos;
            txtUltima.Text = entidad.UltimaCompra;
            LitEstatus.Text = entidad.Estatus;

            limcredito.Text = entidad.LimiteCredito.ToString();
            saldoactual.Text = entidad.Saldo.ToString();

            txtLimCredito.Text = entidad.LimiteCreditoAut.ToString();
            txtSaldoNuevo.Text = entidad.SaldoAut.ToString();

            switch (entidad.Estatus)
            {
                case (Concretec.Pedidos.Constantes.Etiquetas.TAG_EN_AUTORIZACION):
                    imgDenegar.Visible = true;
                    imgAutorizar.Visible = true;
                    break;

                case (Concretec.Pedidos.Constantes.Etiquetas.TAG_AUTORIZADO):
                    imgDenegar.Visible = true;
                    imgAutorizar.Visible = false;
                    break;

                case (Concretec.Pedidos.Constantes.Etiquetas.TAG_RECHAZADO):
                    imgDenegar.Visible = false;
                    imgAutorizar.Visible = true;
                    break;

                default:
                    imgDenegar.Visible = false;
                    imgAutorizar.Visible = false;
                    break;
            }
        }



    }
    protected void imgAutorizar_Click(object sender, ImageClickEventArgs e)
    {
        AgenteClientes agente = new AgenteClientes();
        bool salida = false;
        salida = agente.ActualizaAutorizacionCliente(int.Parse(Request.QueryString[0]), DatosUsuario.UserName, 6, float.Parse(txtSaldoNuevo.Text), float.Parse(txtLimCredito.Text));
        Alert.Show(Concretec.Pedidos.Constantes.Mensajes.EL_CLIENTE + Request.QueryString[0] + Concretec.Pedidos.Constantes.Mensajes.AUTORIZACION_EXITO);
        Response.AddHeader("REFRESH", "1;URL=AutorizacionClientes.aspx");
    }
    protected void imgDenegar_Click(object sender, ImageClickEventArgs e)
    {
        AgenteClientes agente = new AgenteClientes();
        bool salida = false;
        salida = agente.ActualizaAutorizacionCliente(int.Parse(Request.QueryString[0]), DatosUsuario.UserName, 7, float.Parse(txtSaldoNuevo.Text), float.Parse(txtLimCredito.Text));
        Alert.Show(Concretec.Pedidos.Constantes.Mensajes.EL_CLIENTE + Request.QueryString[0] + Concretec.Pedidos.Constantes.Mensajes.MSG_AUTORIZACION_FALLO);
        Response.AddHeader("REFRESH", "1;URL=AutorizacionClientes.aspx");
    }
    protected void imgcancelar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AutorizacionClientes.aspx");
    }
}