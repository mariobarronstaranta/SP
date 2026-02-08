using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_ListaUsuarios : System.Web.UI.Page
{

    private object usuarios;
    public object Usuarios
    {
        get { return usuarios; }
        set
        {
            usuarios = value;
            this.grdUsuarios.DataSource = usuarios;
            grdUsuarios.DataBind();
        }
    }

    public string usuariosfiltro
    { get { return txtBuscar.Text; } }

    public int IdPerfil
    { get { return int.Parse(cboPerfil.SelectedValue.ToString()); } }

    public int IdCiudad
    { get { return int.Parse(cboCiudades.SelectedValue.ToString()); } }

    void LlenaGrid()
    {
        AgenteUsuarios ap = new AgenteUsuarios();
        ap = new AgenteUsuarios();

        List<Usuario> Lista = new List<Usuario>();

        Lista = ap.BuscaUsuario(usuariosfiltro,IdPerfil, IdCiudad);
        this.grdUsuarios.DataSource = Lista;
        this.grdUsuarios.DataBind();
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            CargaPerfiles();
            CargaCiudades();
        }
        LlenaGrid();
    }
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        LlenaGrid();
    }
    protected void buscar_Click(object sender, ImageClickEventArgs e)
    {
        LlenaGrid();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Views/RegistraUsuario.aspx");
    }

    protected void grdUsuarios_ItemCommand(object source, GridCommandEventArgs e)
    {
        if (((System.Web.UI.WebControls.LinkButton)(e.CommandSource)).Text == "Editar")
        {
            Usuario _p = new Usuario();
            
            cargaEntidad(_p, e);
            string strusuario = _p.Id_Usuario.ToString();
            Session.Add("EdicionUsuario", _p);
            Response.Redirect("~/Views/RegistraUsuario.aspx?IdUsuario=" + strusuario);

        }
    }

    protected void grdUsuarios_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }

    private void cargaEntidad(Usuario P, GridCommandEventArgs e)
    {
        P.Id_Usuario = int.Parse(e.Item.Cells[2].Text);
        P.Ciudad = e.Item.Cells[5].Text;
        P.Accion = Concretec.Pedidos.Constantes.Etiquetas.TAG_EDICION;

    }

    private void CargaCiudades()
    {
        cboCiudades.Items.Clear();
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();

        lc = ac.ObtenerCiudades();
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboCiudades.Items.Add(item);
        foreach (Ciudad c in lc)
        {
            item = new ListItem();
            item.Text = c.Descripcion;
            item.Value = c.IDCiudad.ToString();
            cboCiudades.Items.Add(item);
        }

    }

    private void CargaPerfiles()
    {
        cboPerfil.Items.Clear();
        AgenteUsuarios ac = new AgenteUsuarios();
        List<Perfil> lc = new List<Perfil>();

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboPerfil.Items.Add(item);


        lc = ac.ObtenerPerfiles();
        foreach (Perfil c in lc)
        {
            item = new ListItem();
            item.Text = c.Descripcion;
            item.Value = c.IDPerfil.ToString();
            cboPerfil.Items.Add(item);
        }
    }

    protected void btnExportar_Click(object sender, ImageClickEventArgs e)
    {
        ConfigureExport();
        grdUsuarios.MasterTableView.ExportToExcel();
    }

    public void ConfigureExport()
    {
        grdUsuarios.ExportSettings.ExportOnlyData = true;
        grdUsuarios.ExportSettings.IgnorePaging = true;
        grdUsuarios.ExportSettings.FileName = "Plantas";
        grdUsuarios.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;
    }
}