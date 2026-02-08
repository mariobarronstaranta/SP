using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;

public partial class Views_ListaProductos : System.Web.UI.Page
{
    string CveCiudad = string.Empty;

    public string Productosfiltro
        { get { return txtBuscar.Text; } }

    public string Clasificacionfiltro
    { get {
        string valor = "-1";

        if (cboclasificacion.SelectedValue.ToString() != "")
        {
            valor = cboclasificacion.SelectedValue.ToString();
        }
        return valor; 
    } }

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


    private object productos;
    public object Productos
    {
        get { return productos; }
        set
        {
            productos = value;

            grdProductos.DataSource = productos;
            grdProductos.DataBind();
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
            CveCiudad = Login[0].Ciudad;

                AgenteProductos ap = new AgenteProductos();
                ap = new AgenteProductos();
                List<Producto> Lista = new List<Producto>();
                Lista = ap.ObtenerProductoFiltro(Productosfiltro, Clasificacionfiltro, DatosUsuario.Ciudad);

                if (IsPostBack != true)
                {
                    cargaclasificaciones(Lista);
                }
                grdProductos.DataSource = Lista;
                grdProductos.DataBind();

        }
    }

    void cargaclasificaciones(List<Producto> lista)
    {
        var Clasificaciones = from cla in lista
                              select new { cla.Clasificacion };

        Clasificaciones = Clasificaciones.Distinct();
        cboclasificacion.Items.Clear();

                ListItem item = new ListItem();
                item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
                item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
                cboclasificacion.Items.Add(item);

                foreach (var cla in Clasificaciones)
                {

                    item = new ListItem();
                    item.Text = cla.Clasificacion;
                    item.Value = cla.Clasificacion;
                    this.cboclasificacion.Items.Add(item);
                }
    
    }
 
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        AgenteProductos ap = new AgenteProductos();


        List<Producto> Lista = new List<Producto>();

        if (txtBuscar.Text != "")
        {
            Lista = ap.ObtenerProductoFiltro(Productosfiltro, Clasificacionfiltro, DatosUsuario.Ciudad);
        }
        else
        {
            Lista = ap.ObtenerProducto(0, CveCiudad);
        }


        grdProductos.DataSource = Lista;
        grdProductos.DataBind();
    }
    protected void btnActualizar_Click(object sender, ImageClickEventArgs e)
    {
        AgenteProductos agente = new AgenteProductos();
        bool resultado = false;
        resultado = agente.ActualizaProductosCiudad(DatosUsuario.Ciudad);

        if (resultado)
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_SYNC_EXITO);
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_SYNC_FALLA);
        }

    }
    protected void btnExportar_Click(object sender, ImageClickEventArgs e)
    {
        ConfigureExport();
        grdProductos.MasterTableView.ExportToExcel();
    }

    public void ConfigureExport()
    {
        grdProductos.ExportSettings.ExportOnlyData = true;
        grdProductos.ExportSettings.IgnorePaging = true;
        grdProductos.ExportSettings.FileName = "Productos";
        grdProductos.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;
    }

    protected void btnAgregarProducto_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CapturaProducto.aspx");
    }
}