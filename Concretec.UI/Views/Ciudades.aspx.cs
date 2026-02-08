using Concretec.Agentes;
using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Ciudades : System.Web.UI.Page
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
                llenaGrid();

            }
        }
    }

    public List<Ciudad> BuscaCiudades()
    {
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lista = new List<Ciudad>();
        lista = ac.ObtenerCiudades();
        return lista;
    }

    public void llenaGrid()
    {
        List<Ciudad> lista = BuscaCiudades();
        GridCiudades.DataSource = lista;
        GridCiudades.DataBind();
    }

    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        HabilitaBusqueda();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        HabilitaEdicion();
    }

    private void HabilitaEdicion()
    {
        frmCiudad.Visible = true;
        tblbusqueda.Visible = false;
    }

    private void HabilitaBusqueda()
    {
        frmCiudad.Visible = false;
        tblbusqueda.Visible = true;
    }

    protected void GridCiudades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }

    private void limpiarEdicion()
    {
        txtNombreCiudad.Text = string.Empty;
        txtCveCiudad.Text = string.Empty;
    }

    protected void GridCiudades_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR:
                List<Ciudad> lista = BuscaCiudades();
                Ciudad elemento = new Ciudad();
                int idCiudad = int.Parse(e.Item.Cells[2].Text);

                var ciudades =  (from pp in lista
                                where pp.IDCiudad == idCiudad
                                select new { pp.IDCiudad, pp.Descripcion,pp.CveCiudad }).ToList();

                if (ciudades.Count > 0)
                {
                    elemento.IDCiudad = ciudades[0].IDCiudad;
                    elemento.CveCiudad = ciudades[0].CveCiudad;
                    elemento.Descripcion = ciudades[0].Descripcion;
                }

                HabilitaEdicion();
                limpiarEdicion();

                txtNombreCiudad.Text    = elemento.Descripcion;
                txtCveCiudad.Text       = elemento.CveCiudad;

                break;
        }
    }
}