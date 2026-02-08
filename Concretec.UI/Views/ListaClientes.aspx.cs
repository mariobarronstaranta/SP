using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_ListaClientes : System.Web.UI.Page
{


    string CveCiudad = string.Empty;

    public string Clientesfiltro
    {
        set { this.txtBuscar.Text = value; }
        get { return (txtBuscar.Text); }
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
        llenaGrid("Inicio");
    }


    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Page.MasterPageFile != Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString())
        {
            Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
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
                llenaGrid("Consulta");
            }
            else
            {
                llenaGrid("Consulta");
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
        List<Cliente> Lista = new List<Cliente>();
        Lista = ObtenerClientesFiltro();

        gridClientes.DataSource = Lista;
        gridClientes.DataBind();
    }
    protected void grdClientes_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gridClientes_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        llenaGridCount();
    }

    protected void gridClientes_ItemCommand(object source, GridCommandEventArgs e)
    {
        if (e.CommandName == Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR)
        {
            Session.Add("IDCliente", e.Item.Cells[4].Text);
            Response.Redirect("~/Views/CapturaPedidos.aspx");
        }

        if (e.CommandName == Concretec.Pedidos.Constantes.Etiquetas.TAG_PROGRAMACION)
        {
            if (DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_CONSULTA && DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_VENDEDOR)
            {
                Session.Add("IDCliente", e.CommandArgument);
                Response.Redirect("~/Views/CapturaPedidos.aspx");
            }
            else
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PERMISOS_ERROR);
            }
            
        }
    }

    protected void btnAutorizaciones_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("HabilitaClientes.aspx");
    }

    private List<Cliente> ObtenerClientesFiltro()
    {
        AgenteClientes ac = new AgenteClientes();
        List<Cliente> Lista = new List<Cliente>();
        Lista = ac.ObtenerClientesFiltro(txtBuscar.Text, CveCiudad, this.cboplantas.SelectedValue.ToString());

        return Lista;
    }

    private void llenaGridCount()
    {
        List<Cliente> Lista = new List<Cliente>();
        Lista = ObtenerClientesFiltro();

        gridClientes.VirtualItemCount = Lista.Count;
        gridClientes.DataSource = Lista;
    }

    private void llenaGrid(string Accion)
    {
        List<Cliente> Lista = new List<Cliente>();
        Lista = ObtenerClientesFiltro();

        gridClientes.DataSource = Lista;
        gridClientes.DataBind();
    }

    protected void btnExportar_Click(object sender, ImageClickEventArgs e)
    {
        ConfigureExport();
        gridClientes.MasterTableView.ExportToExcel();
    }

    public void ConfigureExport()
    {
        gridClientes.ExportSettings.ExportOnlyData = true;
        gridClientes.ExportSettings.IgnorePaging = true;
        gridClientes.ExportSettings.FileName = "Clientes";
        gridClientes.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;


    }
}