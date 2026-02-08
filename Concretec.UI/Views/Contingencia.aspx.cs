using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_Contingencia : System.Web.UI.Page
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

    public string filtro
    {
        set { this.txtFiltro.Text = value; }
        get { return (txtFiltro.Text); }
    }

    public int IdCategoria
    { get { return int.Parse(this.cboCategoria.SelectedValue.ToString()); } }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        List<Usuario> login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
        if (login == null)
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }
        else
        {

            if (!this.IsPostBack)
            {
                CargaCategorias();
                llenaGrid();

            }
        }
    }
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        llenaGrid();
    }

    protected void llenaGrid()
    {
        AgentePedidos Agente = new AgentePedidos();
        List<Contingencia> Lista = new List<Contingencia>();


        Lista = Agente.LeerContingencias(-1, filtro, -1, IdCategoria);
        GridContingencias.DataSource = Lista;
        GridContingencias.DataBind();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CatContingencia.aspx");
    }
    protected void GridContingencias_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    }
    protected void GridContingencias_ItemCommand(object sender, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR:
                Response.Redirect("~/Views/CatContingencia.aspx?ClaveContingencia=" + e.Item.Cells[2].Text);
                break;
        }
    }


    protected void btnExportar_Click(object sender, ImageClickEventArgs e)
    {
        ConfigureExport();
        GridContingencias.MasterTableView.ExportToExcel();
    }

    public void ConfigureExport()
    {
        GridContingencias.ExportSettings.ExportOnlyData = true;
        GridContingencias.ExportSettings.IgnorePaging = true;
        GridContingencias.ExportSettings.FileName =Concretec.Pedidos.Constantes.Etiquetas.TAG_FILE_CONTINGENCIAS;
        GridContingencias.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;
    }

    private void CargaCategorias()
    {
        //cboCategoria
        AgenteFiltros agente        = new AgenteFiltros();
        List<Categoria> Categorias  = agente.LeerCategorias(-1);
        cboCategoria.Items.Clear();

        ListItem item   = new ListItem();
        item.Text       = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value      = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboCategoria.Items.Add(item);


        foreach (var a in Categorias)
        {
            item = new ListItem();
            item.Text = a.Descripcion;
            item.Value = a.IdCategoria.ToString();
            this.cboCategoria.Items.Add(item);
        }
    }
}