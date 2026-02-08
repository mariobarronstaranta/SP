using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_PedidosDelDia : System.Web.UI.Page
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

    public string IdCiudad
    { get { return cboCiudades.SelectedValue.ToString(); } }


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

            if (IsPostBack != true)
            {
                DateTime Hoy = DateTime.Now.Date;
                inicio.SelectedDate = Hoy.AddDays(-1);
                CargaCiudades();
                cargaGrid(IdCiudad);
            }
        }
    }

    private void cargaGrid(string CveCiudad)
    {

    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void btnExportar_Click(object sender, ImageClickEventArgs e)
    {
        ConfigureExport();
        grdPedidos.MasterTableView.ExportToExcel();
    }

    public void ConfigureExport()
    {
        grdPedidos.ExportSettings.ExportOnlyData = true;
        grdPedidos.ExportSettings.IgnorePaging = true;
        grdPedidos.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;


    }
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {

    }

    private void CargaCiudades()
    {
        cboCiudades.Items.Clear();
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();

        lc = ac.ObtenerCiudades();
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = "-1";
        cboCiudades.Items.Add(item);
        foreach (Ciudad c in lc)
        {
            item = new ListItem();
            item.Text = c.Descripcion;
            item.Value = c.CveCiudad.ToString();
            cboCiudades.Items.Add(item);
        }

    }
}