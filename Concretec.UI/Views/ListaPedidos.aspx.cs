using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_ListaPedidos : System.Web.UI.Page
{
    private object pedidos;
    public object Pedidos
    {
        get { return pedidos; }
        set
        {
            pedidos = value;
            grdPedidos.DataSource = pedidos;
            grdPedidos.DataBind();
        }
    }

    public int IDPlanta
    { get { return int.Parse(cboPlanta.SelectedValue.ToString()); } }

    public int IDEstatus
    { get { return int.Parse(this.cboEstatus.SelectedValue.ToString()); } }

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
                CargaCombos(Login[0].Ciudad); // Migrado a BC
                cboEstatus.SelectedValue = "3";
                cboPlanta.SelectedValue = DatosUsuario.IDPlanta.ToString();

            }

            cargaGrid(Login[0].Ciudad);

        }



    }

    private void CargaPlantas(string CveCiudad)
    {
        cboPlanta.Items.Clear();
        AgentePlantas au = new AgentePlantas();
        List<Planta> _planta = new List<Planta>();

        _planta = au.ObtenerPlantas();
        var plantas = from pp in _planta
                      where pp.Ciudad == CveCiudad && pp.CveDosificadora.Contains(Concretec.Pedidos.Constantes.Etiquetas.TAG_PREFIJO_DOSIFICADORA)
                      select new { pp.IDPlanta, pp.Nombre };
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboPlanta.Items.Add(item);


        foreach (var a in plantas)
        {
            item = new ListItem();
            item.Text = a.Nombre;
            item.Value = a.IDPlanta.ToString().Trim();
            this.cboPlanta.Items.Add(item);

        }

    }

    private void CargaCombos(string ciudad)
    {
        AgenteClientes ao = new AgenteClientes();
        List<Cliente> ListaClientes = new List<Cliente>();
        ListaClientes = ao.ObtenerClientesConPedido(ciudad);

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Etiquetas.TAG_TODOS_PAR;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cliente.Items.Add(item);

        foreach (Cliente p in ListaClientes)
        {
            item = new ListItem();
            item.Text = p.NombreCompleto;
            item.Value = p.IDCliente.ToString();
            this.cliente.Items.Add(item);

        }

        cargaestatusviaje();
        CargaPlantas(DatosUsuario.Ciudad);


    }
    protected void Nuevo_Click(object sender, EventArgs e)
    {
        if (DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_CONSULTA && DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_VENDEDOR)
        {
            Session["Pedidos"] = null;
            Response.Redirect("~/Views/CapturaPedidos.aspx");
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PERMISOS_ERROR);
        }
    }

    private void cargaestatusviaje()
    {

        AgentePedidos ap = new AgentePedidos();
        List<EstatusViaje> estatus = new List<EstatusViaje>();
        estatus = ap.LeerEstatusViaje();

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.estatus.Items.Add(item);

        foreach (EstatusViaje ev in estatus)
        {
            item = new ListItem();
            item.Text = ev.Descripcion;
            item.Value = ev.IDEstatusViaje.ToString();
            this.estatus.Items.Add(item);
        }

    }

    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        List<Usuario> Login = new List<Usuario>();
        Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];

        if (DateTime.Parse(inicio.DateInput.Text.Substring(0, 10)) > DateTime.Parse(fin.DateInput.Text.Substring(0, 10)))
        {
            Response.Write("<script>alert('La Fecha Inicio debe de ser menor a la Final')</script>");
        }
        else
        {
            if (Login == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                cargaGrid(Login[0].Ciudad);
            }

        }

       
    }

    private void cargaGrid(string CveCiudad)
    {
        AgentePedidos ap = new AgentePedidos();
        List<Pedido> listaPedidos = new List<Pedido>();
        grdPedidos.DataSource = null;
        decimal total_pedido = 0;
        decimal total_programado = 0;
        decimal total_remisionado = 0;

        if (inicio.DateInput.Text.ToString() != "")
        {

            listaPedidos = ap.BuscaPedido(CveCiudad,
                                            DateTime.Parse(inicio.DateInput.Text.ToString().Substring(0, 10)),
                                            DateTime.Parse(fin.DateInput.Text.ToString().Substring(0, 10)),
                                            -1, IDPlanta, IDEstatus);
        }
        else
        {
            listaPedidos = ap.BuscaPedido(CveCiudad, DateTime.Parse("2016-01-01"), DateTime.Today, 1, IDPlanta, IDEstatus);

        }

        total_pedido = listaPedidos.Sum(x => Convert.ToDecimal(x.CargaProgramada));
        total_programado = listaPedidos.Sum(x => Convert.ToDecimal(x.CargaViajes));
        total_remisionado = listaPedidos.Sum(x => Convert.ToDecimal(x.CargaRemisiones));

        LblTotalPedidos.Text = total_pedido.ToString();
        LblTotalRemision.Text = total_programado.ToString();
        LblTotalRemision2.Text = total_remisionado.ToString();

        grdPedidos.DataSource = listaPedidos;
        grdPedidos.DataBind();
        Session.Add("pedido", listaPedidos);
    }

    protected void grdPedidos_DeleteCommand(object source, GridCommandEventArgs e)
    {
        {
            GridDataItem item = (GridDataItem)e.Item;
            string MemberFamilyId1 = item.GetDataKeyValue("MemberFamilyID").ToString();


        }
    }

    protected void grdPedidos_ItemCommand(object source, GridCommandEventArgs e)
    {
        Pedido _p = new Pedido();

        if (DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_CONSULTA && DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_VENDEDOR)
        {
            switch (e.CommandName)
            {
                case Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR:
                    _p = new Pedido();
                    cargaEntidad(_p, e);
                    Session.Add("idPedido", _p.IDPedido);
                    Response.Redirect("~/Views/CapturaPedidos.aspx");
                    break;
                case Concretec.Pedidos.Constantes.Etiquetas.TAG_DETALLE:
                    _p = new Pedido();
                    cargaEntidad(_p, e);
                    Response.Redirect("~/Views/ConsultaPedido.aspx?IDPedido=" + _p.IDPedido.ToString());
                    break;
                case Concretec.Pedidos.Constantes.Etiquetas.TAG_CERRAR:
                    _p = new Pedido();
                    cargaEntidad(_p, e);
                    Response.Redirect("~/Views/CierrePedido.aspx?IDPedido=" + _p.IDPedido.ToString());
                    break;
                case Concretec.Pedidos.Constantes.Etiquetas.TAG_CANCELAR:
                    AgentePedidos agentep = new AgentePedidos();
                    _p = new Pedido();
                    cargaEntidad(_p, e);
                    bool salida = false;

                    salida = agentep.CancelaPedido(_p.IDPedido, DatosUsuario.Id_Usuario);
                    if (_p.FechaCompromiso.Date > DateTime.Today.Date)
                    {
                        if (salida)
                        {
                            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_CANCELA_PEDIDO);
                            cargaGrid(DatosUsuario.Ciudad);
                        }
                        else
                        { Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_ERROR_CANCELA_PEDIDO); }
                    }
                    else
                    {
                        Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_ERROR_FECHA_PEDIDO);
                    }

                    break;
            }
        }
        else
        {
            switch (e.CommandName)
            {
                case Concretec.Pedidos.Constantes.Etiquetas.TAG_DETALLE:
                    _p = new Pedido();
                    cargaEntidad(_p, e);
                    Response.Redirect("~/Views/ConsultaPedido.aspx?IDPedido=" + _p.IDPedido.ToString());
                    break;
                case Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR:
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PERMISOS_ERROR);
                    break;
                case Concretec.Pedidos.Constantes.Etiquetas.TAG_CERRAR:
                     Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PERMISOS_ERROR);
                    break;
                case Concretec.Pedidos.Constantes.Etiquetas.TAG_CANCELAR:
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PERMISOS_ERROR);
                    break;
            }
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


    protected void btnnuevo_Click(object sender, ImageClickEventArgs e)
    {
        if (DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_CONSULTA && DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_VENDEDOR)
        {
            Session.Add("pedido", "");
            Response.Redirect("~/Views/CapturaPedidos.aspx");
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PERMISOS_ERROR);
        }
    }
    protected void grdPedidos_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {

    }
    protected void btnPlaneacion_Click(object sender, ImageClickEventArgs e)
    {
        ResponseHelper.Redirect("Planeacion.aspx?Fecha=" + DateTime.Now.ToShortDateString(), "_blank", "menubar=0,width=1366,height=700");

        //Response.Redirect("Planeacion.aspx?Fecha=" + FechaCompromiso.Date.ToShortDateString() + "&HoraInicio=" + HoraInicio + "&HoraFin=" + HoraFin + "&Plantas=" + Listaads);
    }
    protected void grdPedidos_ItemDataBound(object sender, GridItemEventArgs e)
    {
        try {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;

                if (e.Item.Cells[7].Text == Concretec.Pedidos.Constantes.Etiquetas.TAG_EN_AUTORIZACION_SH)
                {
                    item.BackColor = System.Drawing.Color.Yellow;
                }

                if (e.Item.Cells[7].Text == Concretec.Pedidos.Constantes.Etiquetas.TAG_AUTORIZADO_SH)
                {
                    item.BackColor = System.Drawing.Color.LawnGreen;
                }

                if (e.Item.Cells[7].Text == Concretec.Pedidos.Constantes.Etiquetas.TAG_CANCELAR_SH)
                {
                    item.BackColor = System.Drawing.Color.LightGray;
                }

                if (e.Item.Cells[7].Text == Concretec.Pedidos.Constantes.Etiquetas.TAG_RECHAZADO_SH)
                {
                    item.BackColor = System.Drawing.Color.Red;
                }

                //Validaciones para los valores de las cargas
                float valorpro = float.Parse(e.Item.Cells[9].Text);
                float valorvia = float.Parse(e.Item.Cells[10].Text);

                if (valorpro > valorvia && valorvia != 0 && (
                    e.Item.Cells[7].Text != Concretec.Pedidos.Constantes.Etiquetas.TAG_EN_AUTORIZACION_SH && e.Item.Cells[7].Text != Concretec.Pedidos.Constantes.Etiquetas.TAG_RECHAZADO_SH &&
                    e.Item.Cells[7].Text != Concretec.Pedidos.Constantes.Etiquetas.TAG_CANCELAR_SH && e.Item.Cells[7].Text != Concretec.Pedidos.Constantes.Etiquetas.TAG_AUTORIZADO_SH
                    ))
                {
                    item.BackColor = System.Drawing.Color.LightSteelBlue;
                }

                if (valorpro > valorvia && valorvia == 0 && (
                    e.Item.Cells[7].Text != Concretec.Pedidos.Constantes.Etiquetas.TAG_EN_AUTORIZACION_SH && e.Item.Cells[7].Text != Concretec.Pedidos.Constantes.Etiquetas.TAG_RECHAZADO_SH &&
                    e.Item.Cells[7].Text != Concretec.Pedidos.Constantes.Etiquetas.TAG_CANCELAR_SH && e.Item.Cells[7].Text != Concretec.Pedidos.Constantes.Etiquetas.TAG_AUTORIZADO_SH
                    ))
                {
                    item.BackColor = System.Drawing.Color.LightSalmon;
                }
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }

    public void Exportar()
    {
        grdPedidos.ExportSettings.ExportOnlyData = true;
        grdPedidos.ExportSettings.IgnorePaging = true;
        grdPedidos.ExportSettings.OpenInNewWindow = false;
        grdPedidos.ExportSettings.UseItemStyles = false;
        grdPedidos.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;
        grdPedidos.MasterTableView.ExportToExcel();
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
        grdPedidos.ExportSettings.FileName = "Pedidos";
        grdPedidos.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;
    }

    protected void btnHelp_Click(object sender, ImageClickEventArgs e)
    {

    }
}