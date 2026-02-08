using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_LClientes : System.Web.UI.Page
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

    protected void Page_Init(object sender, System.EventArgs e)
    {
        llenaGrid();
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void llenaGrid()
    {
        AgenteClientes ac = new AgenteClientes();
        List<Cliente> Lista = new List<Cliente>();
        Lista = ac.ObtenerClientesFiltro(txtBuscar.Text, CveCiudad, this.cboplantas.SelectedValue.ToString());

        RadGrid1.DataSource = Lista;
        RadGrid1.DataBind();
    }


    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    private void CargaPlantas()
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> planta = new List<Planta>();
        planta = au.ObtenerPlantasObra(DatosUsuario.Ciudad);

        ListItem item = new ListItem();
        item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        this.cboplantas.Items.Add(item);

        foreach (Planta a in planta)
        {
            item = new ListItem();
            item.Text = a.CvePlanta;
            item.Value = a.Nombre;
            this.cboplantas.Items.Add(item);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AgenteClientes ac = new AgenteClientes();
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
    protected void btnActualizar_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnAutorizaciones_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {

    }



    protected void Radgrid1_ItemCommand(object source, GridCommandEventArgs e)
    {
        if (e.CommandName == "SendMail")
        {
            Session.Add("IDCliente", e.CommandArgument);
            Response.Redirect("~/Views/CapturaPedidos.aspx");
        }
    }
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        AgenteClientes ac = new AgenteClientes();
        List<Cliente> Lista = new List<Cliente>();
        Lista = ac.ObtenerClientesFiltro(txtBuscar.Text, CveCiudad, this.cboplantas.SelectedValue.ToString());

        RadGrid1.VirtualItemCount = Lista.Count;
        RadGrid1.DataSource = Lista;
    }
}