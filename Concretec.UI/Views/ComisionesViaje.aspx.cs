using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Pedidos.BE;
using Concretec.Agentes;
using Telerik.Web.UI;

public partial class Views_ComisionesViaje : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    public int IdCiudad_Filtro
    { get { return int.Parse(this.cboCiudadFiltro.SelectedValue.ToString()); } }

    public int idTipoUnidad_Filtro
    { get { return int.Parse(this.cboUnidadFiltro.SelectedValue.ToString()); } }

    public string CveTipoPersonal_Filtro
    { get { return this.cboPersonalFiltro.SelectedValue.ToString(); } }

    public int IdCiudad
    { get { return int.Parse(this.cboCiudades.SelectedValue.ToString()); } }

    public int idTipoUnidad
    { get { return int.Parse(this.cboUnidades.SelectedValue.ToString()); } }

    public string CveTipoPersonal
    { get { return this.cboPersonal.SelectedValue.ToString(); } }

    public int valinicio
    { get { return int.Parse(txtinicio.Text); } }

    public int valfinal
    { get { return int.Parse(txtfin.Text); } }

    public decimal comisionval
    { get { return decimal.Parse(txtcomision.Value.ToString()); } }

    public Usuario DatosUsuario
    {
        get
        {
            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
            return Login[0];
        }
    }

    private void CargaCiudades(List<Ciudad> lc)
    {
        //cboCiudadFiltro.Items.Clear();
        cboCiudades.Items.Clear();

        Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        //cboCiudadFiltro.Items.Add(item);
        cboCiudades.Items.Add(item);
        foreach (Ciudad c in lc)
        {
            item = new Telerik.Web.UI.RadComboBoxItem();
            item.Text = c.Descripcion;
            item.Value = c.IDCiudad.ToString();
            //cboCiudadFiltro.Items.Add(item);
            cboCiudades.Items.Add(item);
        }
    }

    private void CargaGrid()
    {
        List<ComisionViaje> lista = new List<ComisionViaje>();
        AgenteViajes agente = new AgenteViajes();
        lista = agente.LeerViajesComision(IdCiudad_Filtro, CveTipoPersonal_Filtro, idTipoUnidad_Filtro,0);
        gridComisiones.DataSource = lista;
        gridComisiones.DataBind();
    }

    private void CargaCiudadesFiltro(List<Ciudad> lc)
    {
        cboCiudadFiltro.Items.Clear();
        //cboCiudades.Items.Clear();

        Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboCiudadFiltro.Items.Add(item);
        //cboCiudades.Items.Add(item);
        foreach (Ciudad c in lc)
        {
            item = new Telerik.Web.UI.RadComboBoxItem();
            item.Text = c.Descripcion;
            item.Value = c.IDCiudad.ToString();
            cboCiudadFiltro.Items.Add(item);
            //cboCiudades.Items.Add(item);
        }
    }

    private void CargaCiudades()
    {


        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();

        lc = ac.ObtenerCiudades();
        CargaCiudadesFiltro(lc);
        CargaCiudades(lc);

        
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        List<Usuario> login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
        string a;

        if (login == null)
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }
        else
        {
            if (!this.IsPostBack)
            {
                CargaCiudades();
                CargaGrid();
            }
            else
            {
                CargaGrid();
            }
        }


    }
    protected void cmdnuevo_Click(object sender, ImageClickEventArgs e)
    {
        tbl.Visible = true;
        tblfiltros.Visible = false;
    }
    protected void cmdbuscar_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void cmdguardar_Click(object sender, ImageClickEventArgs e)
    {
        AgenteViajes agente = new AgenteViajes();
        bool salida = false;
        if (lblidcomision.Text.Length == 0)
        {
            salida = agente.AgregaComisionViaje("INS", 0, IdCiudad, valinicio, valfinal, CveTipoPersonal, idTipoUnidad, comisionval, DatosUsuario.Id_Usuario);
        }
        else
        {
            salida = agente.AgregaComisionViaje("UPD", int.Parse(lblidcomision.Text), IdCiudad, valinicio, valfinal, CveTipoPersonal, idTipoUnidad, comisionval, DatosUsuario.Id_Usuario);
        }
        
        if (salida)
        {
            limpiarDatos();
            tbl.Visible = false;
            tblfiltros.Visible = true;
            CargaGrid();
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
        }
        else
        { Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO); }
    }
    protected void cmdcancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarDatos();
        tbl.Visible = false;
        tblfiltros.Visible = true;
    }
    protected void cmdborrar_Click(object sender, ImageClickEventArgs e)
    {
        AgenteViajes agente = new AgenteViajes();
        bool salida = false;
        if (lblidcomision.Text.Length > 0)
        { salida = agente.AgregaComisionViaje("DEL", int.Parse(lblidcomision.Text), IdCiudad, valinicio, valfinal, CveTipoPersonal, idTipoUnidad, comisionval, DatosUsuario.Id_Usuario);}

        if (salida)
        {
            limpiarDatos();
            tbl.Visible = false;
            tblfiltros.Visible = true;
            CargaGrid();
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
        }
        else
        { Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO); }

    }

    public void limpiarDatos()
    {
        txtinicio.Text              = "0";
        txtfin.Text                 = "0";
        txtcomision.Text            = "0";
        cboUnidades.SelectedValue   = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboPersonal.SelectedValue   = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboCiudades.SelectedValue   = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        lblidcomision.Text          = string.Empty;
    }

    protected void gridComisiones_ItemCommand(object sender, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR:
                tbl.Visible = true;
                tblfiltros.Visible = false;
                cmdborrar.Visible = true;
                EdicionDatosEntrada(int.Parse(e.Item.Cells[2].Text));
                break;
        }
    }

    private void EdicionDatosEntrada(int idviajescomision)
    {
        List<ComisionViaje> lista = new List<ComisionViaje>();
        ComisionViaje elemento = new ComisionViaje(); 
        AgenteViajes agente = new AgenteViajes();
        lista = agente.LeerViajesComision(IdCiudad_Filtro, CveTipoPersonal_Filtro, idTipoUnidad_Filtro, idviajescomision);
        if (lista != null && lista.Count > 0)
        {
            elemento = lista[0];

            txtinicio.Text = elemento.Inicio.ToString();
            txtfin.Text = elemento.Fin.ToString();
            cboPersonal.SelectedValue = elemento.CveTipoPersonal;
            cboCiudades.SelectedValue = elemento.idCiudad.ToString();
            txtcomision.Text = elemento.Comision.ToString();
            cboUnidades.SelectedValue = elemento.idUnidadtipo.ToString();
            lblidcomision.Text = elemento.idComisionViaje.ToString();
        }

    }
}