using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_ListaPersonal : System.Web.UI.Page
{

    string CveCiudad = string.Empty;

    public string Personalfiltro
    {
        set { this.txtBuscar.Text = value; }
        get { return (txtBuscar.Text); }
    }


    private object personal;
    public object Personal
    {
        get { return personal; }
        set
        {
            personal = value;
            GridEmpleados.DataSource = personal;
            GridEmpleados.DataBind();
        }
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        List<Usuario> Login = new List<Usuario>();
        Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
        AgentePersonal ap = new AgentePersonal();
        List<Personal> Lista = new List<Personal>();
        if (Login == null)
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }
        
        CveCiudad = Login[0].Ciudad;
        if (!this.IsPostBack)
        {
            
            CargaPlantas(CveCiudad);
        }

        ap = new AgentePersonal();

        Lista = ap.ObtenerPersonalFiltro(
                    txtBuscar.Text,
                    cboTipo.SelectedValue,
                    CveCiudad,
                    int.Parse(cboPlanta.SelectedValue.ToString()),
                    cboEstatus.SelectedValue.ToString());

        
        GridEmpleados.DataSource = Lista;
        GridEmpleados.DataBind();
    }

    private void CargaPlantas(string CveCiudad)
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> planta = new List<Planta>();
        planta = au.ObtenerPlantas();

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboPlanta.Items.Add(item);

        var plantas = from pp in planta
                      where pp.Ciudad == CveCiudad
                      select new { pp.IDPlanta, pp.Nombre };

        foreach (var a in plantas)
        {
            item = new ListItem();
            item.Text = a.Nombre;
            item.Value = a.IDPlanta.ToString();
            this.cboPlanta.Items.Add(item);

        }

    }
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        AgentePersonal ap = new AgentePersonal();
        ap = new AgentePersonal();

        List<Personal> Lista = new List<Personal>();

        
            Lista = ap.ObtenerPersonalFiltro(
                    txtBuscar.Text,
                    cboTipo.SelectedValue, 
                    CveCiudad,
                    int.Parse(cboPlanta.SelectedValue.ToString()),
                    cboEstatus.SelectedValue.ToString());


            GridEmpleados.DataSource = Lista;
            GridEmpleados.DataBind();
    }
    protected void btnnuevo_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Views/CatalogoPersonal.aspx");
    }

    protected void GridEmpleados_ItemCommand(object source, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR:
                Response.Redirect("~/Views/CatalogoPersonal.aspx?idpersonal=" + e.Item.Cells[2].Text);
                break;
        }
    }

    protected void GridEmpleados_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {

    }
    protected void btnExportar_Click(object sender, ImageClickEventArgs e)
    {
        ConfigureExport();
        GridEmpleados.MasterTableView.ExportToExcel();
    }

    public void ConfigureExport()
    {
        GridEmpleados.ExportSettings.ExportOnlyData = true;
        GridEmpleados.ExportSettings.IgnorePaging = true;
        GridEmpleados.ExportSettings.FileName = "Personal";
        GridEmpleados.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;
    }
}