using Concretec.Agentes;
using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Views_rptProgramadores : System.Web.UI.Page
{
    #region Page Events
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

    
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        llenagrid();
    }


    protected void btnnuevo_Click(object sender, ImageClickEventArgs e)
    {
        limpiadatos();

    }


    protected void cbociudad_SelectedIndexChanged(object sender, EventArgs e)
    {
        string CveCiudad = cbociudad.SelectedValue.ToString();
        DateTime Desde = DateTime.Parse(inicio.DateInput.Text.Substring(0, 10));
        DateTime Hasta = DateTime.Parse(fin.DateInput.Text.Substring(0, 10));

        CargaClientes(Desde,Hasta, CveCiudad);
        llenaProgramadores();
    }

    #endregion

    #region DataGrid Events
    protected void grdPedidos_DeleteCommand(object source, GridCommandEventArgs e)
    { }

    protected void grdPedidos_ItemCommand(object source, GridCommandEventArgs e)
    {
        Alert.Show("Funcionalidad no disponible");

    }

    protected void grdPedidos_ItemDataBound(object sender, GridItemEventArgs e)
    { }

    protected void grdPedidos_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {

    }

    #endregion

    #region private Methods
    private void llenaProgramadores()
    {
        List<Usuario> lista = ListaUsuario();



        this.cboprogramador.Items.Clear();
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = "-1";
        cboprogramador.Items.Add(item);
        foreach (Usuario c in lista)
        {
            item = new ListItem();
            item.Text = c.Nombre + " " + c.APaterno;
            item.Value = c.Id_Usuario.ToString();
            cboprogramador.Items.Add(item);
        }
    }

    private List<Usuario> ListaUsuario()
    {
        List<Usuario> result = new List<Usuario>();
        AgenteUsuarios agente = new AgenteUsuarios();

        string CveCiudad    = cbociudad.SelectedValue.ToString();
        DateTime Desde      = DateTime.Parse(inicio.DateInput.Text.Substring(0, 10));
        DateTime Hasta      = DateTime.Parse(fin.DateInput.Text.Substring(0, 10));
        int IdCliente       = int.Parse(cbocliente.SelectedValue.ToString());

        result = agente.BuscarProgramadorPedido(CveCiudad, Desde, Hasta, IdCliente);
        return result;
    }

    private void limpiadatos()
    {
        DateTime Hoy = DateTime.Now.Date;
        inicio.SelectedDate = Hoy.AddDays(-15);
        fin.SelectedDate = Hoy.AddDays(-1);

        cbocliente.Items.Clear();
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = "-1";
        cbocliente.Items.Add(item);

        CargaCiudades();
        llenaProgramadores();
        llenagridFake();
    }

    private void llenagridFake()
    {
        List<Consumo> lista = new List<Consumo>();
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
        cbociudad.Items.Clear();
        List<Ciudad> lc = obtener_Ciudades();
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = "-1";
        cbociudad.Items.Add(item);
        foreach (Ciudad c in lc)
        {
            item = new ListItem();
            item.Text = c.Descripcion;
            item.Value = c.CveCiudad;
            cbociudad.Items.Add(item);
        }
    }

    private void CargaClientes(DateTime desde, DateTime hasta, string CveCiudad)
    {
        AgenteClientes ac = new AgenteClientes();
        List<Cliente> clientes = ac.BuscaClientePedido(desde, hasta, CveCiudad);

        cbocliente.Items.Clear();
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = "-1";
        cbocliente.Items.Add(item);
        foreach (Cliente c in clientes)
        {
            item = new ListItem();
            item.Text = c.NombreCompleto;
            item.Value = c.ClaveCliente;
            cbocliente.Items.Add(item);
        }
    }

    protected void llenagrid()
    {
        AgentePedidos agente = new AgentePedidos();
        List<Consumo> lista = new List<Consumo>();
        string IdCiudad = cbociudad.SelectedValue.ToString();
        DateTime Desde = DateTime.Parse(inicio.DateInput.Text.Substring(0, 10));
        DateTime Hasta = DateTime.Parse(fin.DateInput.Text.Substring(0, 10));
        int idprogramador = int.Parse(cboprogramador.SelectedValue.ToString());
        int IdCliente = int.Parse(cbocliente.SelectedValue.ToString());
        lista = agente.rptConsumoProgramadores(IdCiudad, Desde, Hasta, idprogramador, IdCliente);

        grdPedidos.DataSource = lista;
        grdPedidos.DataBind();
    }
    #endregion

    protected void cbocliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        llenaProgramadores();
    }
}