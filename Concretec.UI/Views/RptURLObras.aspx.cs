using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_RptURLObras : System.Web.UI.Page
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
        try
        { this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString(); }
        catch
        { Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT); }

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
            if (!this.IsPostBack)
            {
                limpiadatos();
            }

        }
    }

    private void limpiadatos()
    {
        DateTime Hoy            = DateTime.Now.Date;
        inicio.SelectedDate     = Hoy.AddDays(-15);
        dtHasta.SelectedDate    = Hoy.AddDays(-1);

        CargaCiudades();
        llenagridFake();
    }

    private void llenagridFake()
    {
        List<Obra> lista = new List<Obra>();
        grdPedidos.DataSource = lista;
        grdPedidos.DataBind();
    }

    protected void llenagrid()
    {
        AgenteObras agente = new AgenteObras();
        List<Concretec.Pedidos.BE.Obra> lista = new List<Obra>();
        string IdCiudad = cboCiudades.SelectedValue.ToString();
        DateTime Desde = DateTime.Parse(inicio.DateInput.Text.Substring(0, 10));
        DateTime Hasta = DateTime.Parse(dtHasta.DateInput.Text.Substring(0, 10));

        lista = agente.BuscaObrasAlitudLatitud(IdCiudad, Desde, Hasta);

        grdPedidos.DataSource = lista;
        grdPedidos.DataBind();
    }

    private List<Ciudad> obtener_Ciudades()
    {
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();
        lc = ac.ObtenerCiudades();
        return lc;
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
        llenagrid();
    }
}