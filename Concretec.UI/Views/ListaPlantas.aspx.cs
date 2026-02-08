using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;
using System.Text;



public partial class ListaPlantas : System.Web.UI.Page
{

    public string nombrePlanta
    {
        set { txtnombrePlanta.Text = value; }
        get { return (txtnombrePlanta.Text); }
    }

    private object plantas;
    public object Plantas
    {
        get { return plantas; }
        set
        {
            plantas = value;

            ViewState["grdPlantas"] = null;
          
            this.gridPlantas.DataSource = plantas;
            gridPlantas.DataBind();
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
      

    }

    

    void cargaGrid(string Ciudad)
    {
        AgentePlantas ap = new AgentePlantas();
        List<Planta> Lista = new List<Planta>();
        Lista = ap.ObtenerPlantasFiltro(nombrePlanta, nombrePlanta, DatosUsuario.Ciudad);

        gridPlantas.DataSource = Lista;
        gridPlantas.DataBind();

    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        List<Usuario> Login = new List<Usuario>();
        Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
        if (Login == null)
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }
        

        cargaGrid(Login[0].Ciudad);

    }

    protected void buscar_Click(object sender, ImageClickEventArgs e)
    {
        List<Usuario> Login = new List<Usuario>();
        Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
        cargaGrid(Login[0].Ciudad);
    }


    protected void rgdUnidades_ItemCommand(object source, GridCommandEventArgs e)
    {
        if (DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_CONSULTA && DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_VENDEDOR)
        {
            if (e.CommandName == "Edit")
            {
                Session.Add("Planta", int.Parse(e.Item.Cells[2].Text));
                Response.Redirect("~/Views/CatalogoPlantas.aspx");
            }
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PERMISOS_ERROR);
            Response.Redirect("~/Views/ListaPlantas.aspx");
        }
        


    }

    protected void Nuevo_Click(object sender, EventArgs e)
    {
        Session["Planta"] = null;
        if (DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_CONSULTA && DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_VENDEDOR)
        {
            Response.Redirect("~/Views/CatalogoPlantas.aspx");
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PERMISOS_ERROR);
        }
    }
    protected void rgdUnidades_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Session["Planta"] = null;
        if (DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_CONSULTA && DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_VENDEDOR)
        {
            Response.Redirect("~/Views/CatalogoPlantas.aspx");
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PERMISOS_ERROR);
        }
    }
    protected void btnExportar_Click(object sender, ImageClickEventArgs e)
    {
        ConfigureExport();
        gridPlantas.MasterTableView.ExportToExcel();
    }

    public void ConfigureExport()
    {
        gridPlantas.ExportSettings.ExportOnlyData = true;
        gridPlantas.ExportSettings.IgnorePaging = true;
        gridPlantas.ExportSettings.FileName = "Plantas";
        gridPlantas.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;
    }
}

