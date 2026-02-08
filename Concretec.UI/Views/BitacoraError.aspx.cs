using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_BitacoraError : System.Web.UI.Page
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
                inicio.SelectedDate = Hoy;
                fin.SelectedDate = Hoy.AddDays(1);

                llenaGrid();

            }
            else
            {
                llenaGrid();
            }
            

        }
    }
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        llenaGrid();
    }

    public void llenaGrid()
    {
        AgenteBitacora agente = new AgenteBitacora();
        List<Bitacora> logerror = new List<Bitacora>();
        logerror = agente.HistorialLog(DateTime.Parse(inicio.DateInput.Text.ToString().Substring(0, 10)),
                                            DateTime.Parse(fin.DateInput.Text.ToString().Substring(0, 10)));
        rgBitacora.DataSource = logerror;
        rgBitacora.DataBind();
    }
    protected void btnExportar_Click(object sender, ImageClickEventArgs e)
    {
        ConfigureExport();
        rgBitacora.MasterTableView.ExportToExcel();
    }

    public void ConfigureExport()
    {
        rgBitacora.ExportSettings.ExportOnlyData = true;
        rgBitacora.ExportSettings.IgnorePaging = true;
        rgBitacora.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;


    }
}