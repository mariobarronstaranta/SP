using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class View_ListaUnidades : PageController
{
    //public event EventHandler ObtenerUnidades;
    //public event EventHandler ObtenerUnidadesFiltro;
    AgenteUnidades Agente = new AgenteUnidades();
    AgentePlantas ap = new AgentePlantas();

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

    private object unidades;
    public object Unidades
    {
        get { return unidades; }
        set
        {
            unidades = value;
        }
    }

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
        if (DatosUsuario.UserName == null)
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }

        if (!this.IsPostBack)
        {
            cargaplantas();
        }

        Agente = new AgenteUnidades();
        List<ConsultaUnidad> Lista = new List<ConsultaUnidad>();
        Lista = Agente.ObtenerUnidadesFiltro(txtBuscar.Text, cboPlanta.SelectedValue.ToString(),DatosUsuario.Ciudad,int.Parse(cboEstatus.SelectedValue.ToString()));

        this.rgdUnidades.DataSource = Lista;
        rgdUnidades.DataBind();
        if (DatosUsuario.Perfil == "Admon" || DatosUsuario.Perfil == "CP")
        {
            ImageButton1.Visible = true;
        }  
    }

    private void cargaplantas()
    {
        ap = new AgentePlantas();
        List<Planta> ListaPlantas = new List<Planta>();
        ListaPlantas = ap.ObtenerPlantas();

        var plantas = from pp in ListaPlantas
                      where pp.Ciudad == DatosUsuario.Ciudad
                      select new { pp.Nombre,pp.IDPlanta};

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboPlanta.Items.Add(item);

        foreach (var p in plantas)
        {
            item = new ListItem();
            item.Text = p.Nombre;
            item.Value = p.IDPlanta.ToString();
            this.cboPlanta.Items.Add(item);

        }
    }

    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        Agente = new AgenteUnidades();
        List<ConsultaUnidad> Lista = new List<ConsultaUnidad>();
        Lista = Agente.ObtenerUnidadesFiltro(txtBuscar.Text, cboPlanta.SelectedValue.ToString(), DatosUsuario.Ciudad,int.Parse(cboEstatus.SelectedValue.ToString()));
        rgdUnidades.DataSource = Lista;
        rgdUnidades.DataBind();

    }

    protected void rgdUnidades_ItemCommand(object source, GridCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {

            if (DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_VENDEDOR && DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_VENDEDOR)
            {
                Session.Add("UnidadEdicion", e.Item.Cells[2].Text);
                Response.Redirect("~/Views/CatalogoUnidades.aspx");
            }
            else
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PERMISOS_ERROR);
                Response.Redirect("~/Views/ListaUnidades.aspx");
            }

            
        }
    }


    protected void Nuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Views/CatalogoUnidades.aspx");
    }
    protected void rgdUnidades_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_VENDEDOR && DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_VENDEDOR)
        {
            Response.Redirect("~/Views/CatalogoUnidades.aspx");
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PERMISOS_ERROR);
            Response.Redirect("~/Views/ListaUnidades.aspx");
        }
        
    }
    protected void txtBuscar_TextChanged(object sender, EventArgs e)
    {

    }
    protected void RadGrid1_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {

    }
    protected void btnExportar_Click(object sender, ImageClickEventArgs e)
    {
        ConfigureExport();
        rgdUnidades.MasterTableView.ExportToExcel();
    }

    public void ConfigureExport()
    {
        rgdUnidades.ExportSettings.ExportOnlyData = true;
        rgdUnidades.ExportSettings.IgnorePaging = true;
        rgdUnidades.ExportSettings.FileName = "Unidades";
        rgdUnidades.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;
    }

   
}