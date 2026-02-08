using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_AutorizacionClientes : System.Web.UI.Page
{
    public Usuario DatosUsuario
    {
        get
        {
            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
            return Login[0];
        }

    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AgenteClientes ac = new AgenteClientes();
        List<Cliente> Lista = new List<Cliente>();
        List<Usuario> Login = new List<Usuario>();
        Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
        if (Login == null)
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }
        if (IsPostBack != true)
        {
            Lista = ac.ObtenerClientesCartera("", DatosUsuario.Ciudad, Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE);
            cboEstatus.SelectedValue = "5";
            var informacion = from pp in Lista
                              where pp.EstatusAutorizacion == cboEstatus.SelectedItem.Text
                              select new { pp.ClaveCliente, pp.NombreCompleto, pp.IDVendedor, pp.Telefonos, pp.LimiteCredito, pp.Saldo, pp.CreditoDisponible, pp.EstatusAutorizacion, pp.IDCliente };

            RadGrid1.DataSource = informacion;
            RadGrid1.DataBind();
        }
    }
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        AgenteClientes ac = new AgenteClientes();
        List<Cliente> Lista = new List<Cliente>();
        List<Usuario> Login = new List<Usuario>();
        Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];

        Lista = ac.ObtenerClientesCartera(txtBuscar.Text.Trim(), DatosUsuario.Ciudad, Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE);
        if (cboEstatus.SelectedValue.ToString() == Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE)
        {
            var _informacion = from pp in Lista
                              select new { pp.ClaveCliente, pp.NombreCompleto, pp.IDVendedor, pp.Telefonos, pp.LimiteCredito, pp.Saldo, pp.CreditoDisponible, pp.EstatusAutorizacion, pp.IDCliente };

            RadGrid1.DataSource = _informacion;
        }
        else
        {
            var informacion = from pp in Lista
                              where pp.EstatusAutorizacion == cboEstatus.SelectedItem.Text
                              select new { pp.ClaveCliente, pp.NombreCompleto, pp.IDVendedor, pp.Telefonos, pp.LimiteCredito, pp.Saldo, pp.CreditoDisponible, pp.EstatusAutorizacion, pp.IDCliente };

            RadGrid1.DataSource = informacion;
        }
        
        RadGrid1.DataBind();

    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;

            if (e.Item.Cells[9].Text == Concretec.Pedidos.Constantes.Etiquetas.TAG_EN_AUTORIZACION)
            {
                item.BackColor = System.Drawing.Color.Yellow;
            }
        }
    }

    protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
    {
        AgenteClientes agente = new AgenteClientes();
        Cliente _cliente = new Cliente();
        _cliente = agente.BuscarClienteCve(e.Item.Cells[2].Text, DatosUsuario.Ciudad);

        bool salida = false;

        switch (e.CommandName)
        {
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_VER:
                Pedido _p = new Pedido();
                Response.Redirect("~/Views/ConsultaClienteAutorizar.aspx?IDCliente=" + _cliente.IDCliente.ToString());
                break;
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_HABILITAR:
                agente = new AgenteClientes();
                if (e.Item.Cells[9].Text == Concretec.Pedidos.Constantes.Etiquetas.TAG_AUTORIZADO)
                {
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.EL_CLIENTE + _cliente.IDCliente.ToString() + Concretec.Pedidos.Constantes.Mensajes.AUTORIZACION_PREVIA);
                }
                else
                {
                    salida = agente.ActualizaAutorizacionCliente(_cliente.IDCliente, DatosUsuario.UserName, 6, 0, 0);
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.EL_CLIENTE + e.Item.Cells[3].Text + Concretec.Pedidos.Constantes.Mensajes.AUTORIZACION_EXITO);
                    Response.AddHeader("REFRESH", "1;URL=AutorizacionClientes.aspx");
                }


                break;

        }
    }

    protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }
}