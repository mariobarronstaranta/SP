using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;


public partial class Views_ListaObras : System.Web.UI.Page
{
    string CveCiudad = string.Empty;

    public Usuario DatosUsuario
    {
        get
        {
            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
            return Login[0];
        }

    }

    public string Clientesfiltro
    {
        set { this.txtBuscar.Text = value; }
        get { return (txtBuscar.Text); }
    }

    public int IDCliente
    { 
    get
        {
            int salida = -1;
            if (cboCliente.SelectedValue.ToString() != "")
            { salida = int.Parse(cboCliente.SelectedValue.ToString()); }
            return salida;
        }
    }

    public int Estatus
    {
        get
        {
            int salida = -1;
            if (this.cboEstatus.SelectedValue.ToString() != "")
            { salida = int.Parse(this.cboEstatus.SelectedValue.ToString()); }
            return salida;
        }
    }

    public string IDPlanta
    { 
    get
        {
            string salida = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
            if (cboPlanta.SelectedValue.ToString() != "")
            { salida = cboPlanta.SelectedValue.ToString(); }
            return salida;
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
        List<Usuario>  login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
        string a;

        if (login == null)
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }
        else
        {
            CveCiudad = login[0].Ciudad;
            if (!this.IsPostBack)
            {
                CargaPlantas();
                CargaClientes(DatosUsuario.Ciudad);
                llenaGrid();
            }
            else
            {
                a = e.GetType().Name;
                llenaGrid();
            }
        }

    }

    private void CargaClientes(string ciudad)
    {
        AgenteClientes au = new AgenteClientes();
        List<Cliente> cliente_ = new List<Cliente>();
        cliente_ = au.ObtenerClientesConObra(ciudad);
        cboCliente.Items.Clear();
        string strplanta = cboPlanta.SelectedValue.ToString();

        var query = from cc in cliente_
                    select new { cc.NombreCompleto, cc.ClaveCliente };

        if (strplanta != Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE)
        {
            query = from cc in cliente_
                    where cc.Planta == strplanta
                    select new { cc.NombreCompleto, cc.ClaveCliente };
        }
        else
        {
            query = from cc in cliente_
                        select new { cc.NombreCompleto, cc.ClaveCliente };
        }

        Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboCliente.Items.Add(item);
        var cientesfiltrados = query.Distinct();

        foreach (var a in cientesfiltrados)
        {
            item = new Telerik.Web.UI.RadComboBoxItem();
            item.Text = a.NombreCompleto;
            item.Value = a.ClaveCliente;
            this.cboCliente.Items.Add(item);

        }

    }

    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        AgenteObras Agente = new AgenteObras();
        List<Obra> Lista = new List<Obra>();
        Lista = Agente.ObtenerObrasFiltro(txtBuscar.Text, cboPlanta.SelectedValue.ToString(), int.Parse(cboCliente.SelectedValue.ToString()), DatosUsuario.Ciudad, Estatus);

        GridObras.DataSource = Lista;
        GridObras.DataBind();
    }

    private void CargaPlantas()
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> planta = new List<Planta>();
        planta = au.ObtenerPlantasObra(DatosUsuario.Ciudad);
        cboPlanta.Items.Clear();

        Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem();
        item = new Telerik.Web.UI.RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboPlanta.Items.Add(item);

        foreach (Planta a in planta)
        {
            item = new Telerik.Web.UI.RadComboBoxItem();
            item.Text = a.CvePlanta;
            item.Value = a.Nombre;
            this.cboPlanta.Items.Add(item);
        }
    }

    protected void btnRegresar_Click(object sender, ImageClickEventArgs e)
    {

    }
    
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        if (DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_CONSULTA && DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_VENDEDOR)
        {
            Response.Redirect("~/Views/CatalogoObra.aspx");
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PERMISOS_ERROR);
        }
    }
    

    protected void GridObras_ItemCommand(object source, GridCommandEventArgs e)
    {
        if (DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_CONSULTA && DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_VENDEDOR)
            {
                switch (e.CommandName)
                {

                    case Concretec.Pedidos.Constantes.Etiquetas.TAG_DETALLE:
                        Response.Redirect("~/Views/DetalleObra.aspx?IDObra=" + e.Item.Cells[2].Text);
                        break;
                    case Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR:
                        Response.Redirect("~/Views/CatalogoObra.aspx?IDObra=" + e.Item.Cells[2].Text);
                        break;
                    case Concretec.Pedidos.Constantes.Etiquetas.TAG_PROG:
                        if (e.Item.Cells[12].Text.ToUpper() == "ACTIVO")
                        {
                            Session.Add("IDObra", e.Item.Cells[3].Text);
                            Session.Add("IDObraSQL", e.Item.Cells[2].Text);
                            Session.Add("IDCliente", e.Item.Cells[4].Text);
                            Session.Add("IDVendedor", e.Item.Cells[5].Text);
                            Response.Redirect("~/Views/CapturaPedidos.aspx");
                        }
                        else
                        {
                            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_ERROR_OBRAS_ACT);
                        }
                        break;
                    case Concretec.Pedidos.Constantes.Etiquetas.TAG_EDICION:
                        Response.Redirect("~/Views/CatalogoObra.aspx?IDObra=" + e.CommandArgument.ToString());
                        break;
                    case Concretec.Pedidos.Constantes.Etiquetas.TAG_PROGRAMACION:
                        AgenteObras Agente = new AgenteObras();
                        Obra lobras = new Obra();
                        bool estatus = false;
                        lobras = Agente.BuscarObra(int.Parse(e.CommandArgument.ToString()), DatosUsuario.Ciudad);
                        estatus = lobras.Estatus;
                        Session.Add("IDObra", lobras.ClaveObra.ToString());
                        Session.Add("IDObraSQL", lobras.IDObra.ToString());
                        Session.Add("IDCliente", lobras.ClaveCliente.ToString());
                        Session.Add("IDVendedor", lobras.IdVendedor);
                        if (estatus == true)
                        {
                            Response.Redirect("~/Views/CapturaPedidos.aspx");
                        }
                        else
                        {
                            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_ERROR_OBRAS_ACT);
                        }

                        break;

                }
            }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PERMISOS_ERROR);
        }
        

    }


    protected void llenaGrid()
    {
        AgenteObras Agente = new AgenteObras();
        List<Obra> Lista = new List<Obra>();

        string strplanta = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        if (cboPlanta.SelectedValue.ToString() != "")
        { strplanta = cboPlanta.SelectedValue.ToString(); }

        int icliente = -1;
        if (cboCliente.SelectedValue.ToString() != "")
        { icliente = int.Parse(cboCliente.SelectedValue.ToString()); }


        Lista = Agente.ObtenerObrasFiltro(txtBuscar.Text, strplanta, icliente, DatosUsuario.Ciudad, Estatus);
        GridObras.DataSource = Lista;
        GridObras.DataBind();
    }
    protected void cboPlanta_SelectedIndexChanged1(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        
        CargaClientes(DatosUsuario.Ciudad);
    }
    protected void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnExportar_Click(object sender, ImageClickEventArgs e)
    {
        ConfigureExport();
        GridObras.MasterTableView.ExportToExcel();
    }

    public void ConfigureExport()
    {
        GridObras.ExportSettings.ExportOnlyData = true;
        GridObras.ExportSettings.IgnorePaging = true;
        GridObras.ExportSettings.FileName = "Obras";
        GridObras.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;
    }
}