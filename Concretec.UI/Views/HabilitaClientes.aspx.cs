using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_HabilitaClientes : System.Web.UI.Page
{
    string CveCiudad = string.Empty;

    public string Clientesfiltro
    {
        set { this.txtBuscar.Text = value; }
        get { return (txtBuscar.Text); }
    }

    protected void btnActualizar_Click(object sender, ImageClickEventArgs e)
    {
        AgenteClientes agente = new AgenteClientes();
        bool salida = agente.SincronizaClientes(DatosUsuario.Ciudad);

        switch (salida)
        {
            case true:
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_SYNC_EXITO);
                break;
            case false:
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_SYNC_FALLA);
                break;
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

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_Init(object sender, System.EventArgs e)
    {
        llenaGrid();
    }


    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (this.Page.MasterPageFile != Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString())
        {
            this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
        }
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
            CveCiudad = Login[0].Ciudad;
            if (!this.IsPostBack)
            {
                CargaPlantas();
                llenaGrid();
            }
            else
            {
                llenaGrid();
            }
        }



    }




    private void CargaPlantas()
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> planta = new List<Planta>();
        planta = au.ObtenerPlantasObra(DatosUsuario.Ciudad);

        Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem();
        item = new Telerik.Web.UI.RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        this.cboplantas.Items.Add(item);

        foreach (Planta a in planta)
        {
            item = new Telerik.Web.UI.RadComboBoxItem();
            item.Text = a.CvePlanta;
            item.Value = a.Nombre;
            this.cboplantas.Items.Add(item);
        }
    }

    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        AgenteClientes ac = new AgenteClientes();
        List<Cliente> Lista = new List<Cliente>();
        Lista = ac.ObtenerClientesCartera(txtBuscar.Text, CveCiudad, this.cboplantas.SelectedValue.ToString());

        gridClientes.DataSource = Lista;
        gridClientes.DataBind();
    }
    protected void grdClientes_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gridClientes_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        AgenteClientes ac = new AgenteClientes();
        List<Cliente> Lista = new List<Cliente>();
        Lista = ac.ObtenerClientesCartera(txtBuscar.Text, CveCiudad, this.cboplantas.SelectedValue.ToString());

        gridClientes.VirtualItemCount = Lista.Count;
        gridClientes.DataSource = Lista;
    }

    protected void gridClientes_ItemCommand(object source, GridCommandEventArgs e)
    {
        AgenteClientes agente = new AgenteClientes();
        Cliente _cliente = new Cliente();

        bool Estatus = false;

        if (e.CommandName == Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR)
        {
            Session.Add("IDCliente", e.Item.Cells[4].Text);
            Response.Redirect("~/Views/CapturaPedidos.aspx");
        }

        if (e.CommandName == Concretec.Pedidos.Constantes.Etiquetas.TAG_PROGRAMACION)
        {
            agente = new AgenteClientes();
            _cliente = new Cliente();
            _cliente = agente.BuscarClienteCve(e.Item.Cells[4].Text, DatosUsuario.Ciudad);
            switch (e.Item.Cells[12].Text)
            {
                case Concretec.Pedidos.Constantes.Etiquetas.TAG_EN_AUTORIZACION:
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.EL_CLIENTE + e.Item.Cells[7].Text + Concretec.Pedidos.Constantes.Mensajes.MSG_ENVIADO_CONTA);
                    break;
                case Concretec.Pedidos.Constantes.Etiquetas.TAG_AUTORIZADO:
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.EL_CLIENTE + e.Item.Cells[7].Text + Concretec.Pedidos.Constantes.Mensajes.MSG_YA_AUTORIZADO);
                    break;
                case Concretec.Pedidos.Constantes.Etiquetas.TAG_RECHAZADO:
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.EL_CLIENTE + e.Item.Cells[7].Text + Concretec.Pedidos.Constantes.Mensajes.MSG_RECHAZADO);
                    break;
                default:
                    agente = new AgenteClientes();
                    Estatus = agente.HabilitarCliente(_cliente.IDCliente, DatosUsuario.UserName, 5);
                    if (Estatus)
                    {
                        Alert.Show(Concretec.Pedidos.Constantes.Mensajes.EL_CLIENTE + e.Item.Cells[7].Text + Concretec.Pedidos.Constantes.Mensajes.MSG_ENVIADO_CONTA);
                        Response.AddHeader("REFRESH", "1;URL=HabilitaClientes.aspx");
                    }
                    else
                    {
                        Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
                    }
                    break;
            }
        }
    }

    protected void btnAutorizaciones_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("HabilitaClientes.aspx");
    }

    protected void llenaGrid()
    {
        AgenteClientes ac = new AgenteClientes();
        List<Cliente> Lista = new List<Cliente>();
        Lista = ac.ObtenerClientesCartera(txtBuscar.Text, CveCiudad, this.cboplantas.SelectedValue.ToString());

        gridClientes.DataSource = Lista;
        gridClientes.DataBind();
    }


    protected void gridClientes_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;

            if (e.Item.Cells[12].Text == Concretec.Pedidos.Constantes.Etiquetas.TAG_EN_AUTORIZACION)
            {
                item.BackColor = System.Drawing.Color.Yellow;
            }
        }
    }
}