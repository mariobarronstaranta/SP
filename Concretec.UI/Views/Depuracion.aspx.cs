using Concretec.Agentes;
using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Views_Depuracion : System.Web.UI.Page
{
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
                DateTime Hoy = DateTime.Now.Date;
                inicio.SelectedDate = Hoy.AddDays(-60);
                fin.SelectedDate = Hoy.AddDays(-30);

                CargaCiudades();
                llenaCliente();
                llenagridFake();
            }
            
        }
    }

    private bool validafechas()
    {
        bool result = true;
        if (DateTime.Parse(inicio.DateInput.Text.Substring(0, 10)) > DateTime.Parse(fin.DateInput.Text.Substring(0, 10)))
        {
            result = false;  
        }
        return result;
    }

    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        if (!validafechas())
        {
            Response.Write("<script>alert('La Fecha Inicio debe de ser menor a la Final')</script>");
        }
        else if(cbociudad.SelectedValue.Trim().ToString()==Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE)
        {
            Response.Write("<script>alert('Seleccione una ciudad')</script>");
        }
        else
        {
            llenagrid();
        }
        
    }

    protected void btnLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        cboCliente.SelectedValue = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
    }

    protected void btnProcesar_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btnnuevo_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btnPlaneacion_Click(object sender, ImageClickEventArgs e)
    {
        List<Usuario>  Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];

        bool result = false;

        string      CveCiudad = cbociudad.SelectedValue.ToString();
        DateTime    Desde = DateTime.Parse(inicio.DateInput.Text.Substring(0, 10));
        DateTime    Hasta = DateTime.Parse(fin.DateInput.Text.Substring(0, 10));
        int         IdCliente = int.Parse(cboCliente.SelectedValue.ToString());
        int         IdUsuario = Login[0].Id_Usuario;

        result = InsertaCalendarioDepuracion(Desde, Hasta, CveCiudad, IdCliente, IdUsuario);

        if (result)
        { Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PEDIDOS_CLIENTE + cboCliente.Text + Concretec.Pedidos.Constantes.Mensajes.MSG_CALENDARIZADOS);}
        else
        { Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PEDIDOS_CLIENTE + cboCliente.Text + Concretec.Pedidos.Constantes.Mensajes.MSG_NO_CALENDARIZADOS);}
    }

    protected void btnExportar_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void grdPedidos_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {

    }
    protected void grdPedidos_ItemCommand(object source, GridCommandEventArgs e)
    {
        Pedido _p = new Pedido();

        switch (e.CommandName)
        {

            case Concretec.Pedidos.Constantes.Etiquetas.TAG_CANCELAR:
                AgentePedidos agentep = new AgentePedidos();
                _p = new Pedido();
                cargaEntidad(_p, e);
                bool salida = false;

                //salida = agentep.CancelaPedido(_p.IDPedido, DatosUsuario.Id_Usuario);
                if (_p.FechaCompromiso.Date <= DateTime.Now.Date)
                {
                    agentep = new AgentePedidos();
                    salida = agentep.EliminaPedido(_p.IDPedido);

                    if (salida)
                    {
                        Alert.Show(Concretec.Pedidos.Constantes.Mensajes.EL_PEDIDO + _p.IDPedido.ToString() + Concretec.Pedidos.Constantes.Mensajes.MSG_ELIMINADOS_EXITO);
                        llenagrid();
                    }
                    else
                    { Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_ERROR_ELIMINAR_PEDIDO + _p.IDPedido.ToString()); }
                }
                else
                {
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_ERROR_FECHA_PEDIDO);
                }

                break;
        }
    }

    private void cargaEntidad(Pedido p, GridCommandEventArgs e)
    {
        if (e.Item.Cells[2].Text != "&nbsp;")
        { p.IDPedido = int.Parse(e.Item.Cells[2].Text); }
        else
        { p.IDPedido = 0; }

        if (e.Item.Cells[1].Text != "&nbsp;")
        { p.IDCliente = int.Parse(e.Item.Cells[1].Text); }
        else
        { p.IDCliente = 0; }

        if (e.Item.Cells[2].Text != "&nbsp;")
        { p.IDObra = int.Parse(e.Item.Cells[2].Text); }
        else
        { p.IDObra = 0; }

        if (e.Item.Cells[3].Text != "&nbsp;")
        { p.NombreCliente = e.Item.Cells[3].Text; }
        else
        { p.NombreCliente = ""; }

        if (e.Item.Cells[4].Text != "&nbsp;")
        { p.NombreObra = e.Item.Cells[4].Text; }
        else
        { p.NombreObra = ""; }

        if (e.Item.Cells[8].Text != "&nbsp;")
        { p.FechaCompromiso = DateTime.Parse(e.Item.Cells[8].Text); }

    }

    protected void grdPedidos_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            LinkButton link = (LinkButton)item["column3"].Controls[0];
            link.Attributes.Add("onclick", "Confirm();");
        }
    }
    protected void grdPedidos_DeleteCommand(object source, GridCommandEventArgs e)
    { }

    protected void cbociudad_SelectedIndexChanged(object sender, EventArgs e)
    {
        llenaCliente();
    }

    private List<Pedido> BuscaPedido(string CveCiudad, DateTime Desde, DateTime Hasta, int IDCliente)
    {
        List<Pedido> result = new List<Pedido>();
        Pedido elem = new Pedido();
        AgentePedidos agente = new AgentePedidos();
        result = agente.BuscaPedido(CveCiudad, Desde, Hasta, IDCliente, -1,-1);

        if (IDCliente > 0)
        {
            var filtroCliente = from clie in result
                                        where clie.IDCliente == IDCliente
                                        select new
                                        {
                                            clie.IDPedido,
                                            clie.IDCliente,
                                            clie.NombreObra,
                                            clie.NombreCliente,
                                            clie.FechaCompromiso,
                                            clie.FechaHoraCompromiso,
                                            clie.Estatus,
                                            clie.CargaProgramada,
                                            clie.CargaViajes
                                        };

            result = new List<Pedido>();
            elem = new Pedido();

            foreach (var fc in filtroCliente)
            {
                elem = new Pedido();

                elem.IDPedido = fc.IDPedido;
                elem.IDCliente = fc.IDCliente;
                elem.NombreObra = fc.NombreObra.ToString();
                elem.NombreCliente = fc.NombreCliente;
                elem.FechaCompromiso = fc.FechaCompromiso;
                elem.FechaHoraCompromiso = fc.FechaHoraCompromiso;
                elem.Estatus = fc.Estatus;
                elem.CargaProgramada = fc.CargaProgramada;
                elem.CargaViajes = fc.CargaViajes;

                result.Add(elem);
            }

        }
        



        return result;
    }

    private void llenagridFake()
    {
        List<Pedido> lista = new List<Pedido>();
        grdPedidos.DataSource = lista;
        grdPedidos.DataBind();
    }

    private void llenagrid()
    {
        string      CveCiudad   = cbociudad.SelectedValue.ToString();
        DateTime    Desde       = DateTime.Parse(inicio.DateInput.Text.Substring(0, 10));
        DateTime    Hasta       = DateTime.Parse(fin.DateInput.Text.Substring(0, 10));
        int         IDCliente   = int.Parse(cboCliente.SelectedValue.ToString());

        List<Pedido> lista = BuscaPedido(CveCiudad, Desde, Hasta, IDCliente);
        grdPedidos.DataSource = lista;
        grdPedidos.DataBind();
    }

    private List<Cliente> ObtenerClientesConPedido(DateTime Desde, DateTime Hasta, string CveCiudad)
    {
        List<Cliente> result = new List<Cliente>();
        AgenteClientes agente = new AgenteClientes();
        result = agente.BuscaClientePedido(Desde, Hasta, CveCiudad);

        return result;
    }

    private void llenaCliente()
    {
        this.cboCliente.Items.Clear();
        string CveCiudad = cbociudad.SelectedValue.ToString();
        DateTime Desde = DateTime.Parse(inicio.DateInput.Text.Substring(0, 10));
        DateTime Hasta = DateTime.Parse(fin.DateInput.Text.Substring(0, 10));
        List<Cliente> result = ObtenerClientesConPedido( Desde,  Hasta, CveCiudad);

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboCliente.Items.Add(item);
        foreach (Cliente c in result)
        {
            item = new ListItem();
            item.Text = c.NombreCompleto;
            item.Value = c.IDCliente.ToString();
            cboCliente.Items.Add(item);
        }
    }

    private void CargaCiudades()
    {
        cbociudad.Items.Clear();
        List<Ciudad> lc = obtener_Ciudades();
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cbociudad.Items.Add(item);
        foreach (Ciudad c in lc)
        {
            item = new ListItem();
            item.Text = c.Descripcion;
            item.Value = c.CveCiudad;
            cbociudad.Items.Add(item);
        }
    }

    private List<Ciudad> obtener_Ciudades()
    {
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();
        lc = ac.ObtenerCiudades();
        return lc;
    }

    public void OnConfirm(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "SI")
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Tu ckiqueaste SI')", true);
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
        }
    }

    protected void btnCalendarizacion_Click(object sender, ImageClickEventArgs e)
    {
        

        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
            Response.Redirect("ProgramaDepuracion.aspx");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
        }
    }

    protected bool InsertaCalendarioDepuracion(DateTime Desde, DateTime Hasta, string CveCiudad, int IdCliente, int IdUsuario)
    {
        AgentePedidos ap = new AgentePedidos();
        bool result = false;
        result = ap.InsertaCalendarioDepuracion(Desde,Hasta,CveCiudad,IdCliente,IdUsuario);

        return result;
    }
}