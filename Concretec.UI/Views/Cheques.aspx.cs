using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;

public partial class Views_Cheques : System.Web.UI.Page
{
    private DateTime startDate = DateTime.Today;
    private DateTime endDate = DateTime.Today.AddDays(60);
    private AgenteCheques agente = new AgenteCheques();

    Concretec.Pedidos.Utils.BitacoraErrores BitError = new Concretec.Pedidos.Utils.BitacoraErrores();
    readonly string Aplicacion = "Programacion de Pedidos V 2.5";
    readonly string Modulo = "Views_Cheques.cs";
    string Metodo = string.Empty;


    public string ClienteId_Buscar
    {
        set { this.cboClienteBuscar.SelectedValue = value; }
        get { return (this.cboClienteBuscar.SelectedValue); }
    }

    public Usuario DatosUsuario
    {
        get
        {
            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session["DatosUsuario"];
            return Login[0];
        }
    }

    public int IdCheque
    { get; set; }

    private object cheques;
    public object Cheques
    {
        get { return cheques; }
        set
        {
            cheques = value;
            gridCheques.DataSource = cheques;
            gridCheques.DataBind();
        }
    }

    private object chequesSeguimientos;
    public object ChequesSeguimientos
    {
        get { return chequesSeguimientos; }
        set
        {
            chequesSeguimientos = value;
            gridChequesSeguimientos.DataSource = chequesSeguimientos;
            gridChequesSeguimientos.DataBind();
        }
    }


    protected void Page_PreInit(object sender, EventArgs e)
    {
        try
        {
            this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
        }
        catch
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        // ApplyAppPathModifier will add the session ID if we're using Cookieless session.
        string urlWithSessionID = Response.ApplyAppPathModifier(Request.Url.PathAndQuery);
        RadTab tab = RadTabStrip1.FindTabByUrl(urlWithSessionID);
        
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
                //Tab Cheques
                DateTime Hoy = DateTime.Now.Date;
                dtRecepcion.SelectedDate = Hoy;
                dtFechaCobro.SelectedDate = Hoy.AddDays(30);      
                inicio.SelectedDate = DateTime.Now.AddDays(-7);
                fin.SelectedDate = DateTime.Now.AddDays(7);
                CargaClientes(Login[0].Ciudad);

                //Tab Registro
                CargaCiudades();
                CargaClientesRegistro(DatosUsuario.Ciudad);
                CargaBancos();
                CargaEstatusCheque();
                CargaProtectoras();
                txtMonto.Text = "";
                dtFechaCobro.SelectedDate = DateTime.Now;
                cboProtectora.SelectedIndex = 0;
                txtObservaciones.Text = "";
                cbociudad.SelectedValue = DatosUsuario.Ciudad;


                cargaGrid_Cheques();

                if (tab != null)
                {
                    tab.SelectParents();
                    tab.PageView.Selected = true;
                }

            }


            
        }

        

    }

    private void CargaEstatusCheque()
    {
        AgenteCatalogos au = new AgenteCatalogos();
        List<Categoria> categoria = new List<Categoria>();
        categoria = au.LeerCatalogos(4);

        this.cboEstatus.Items.Clear();
        this.cboEstatusEdit.Items.Clear();

        ListItem item = new ListItem();
        item.Text = "(Seleccione)";
        item.Value = "-1";
        this.cboEstatus.Items.Add(item);

        ListItem item2 = new ListItem();
        item2.Text = "(Seleccione)";
        item2.Value = "-1";
        this.cboEstatusEdit.Items.Add(item);

        foreach (Categoria a in categoria)
        {
            item = new ListItem();
            item.Text = a.Descripcion;
            item.Value = a.IdCategoria.ToString();
            this.cboEstatus.Items.Add(item);
            this.cboEstatusEdit.Items.Add(item);
        }
    }


    private void CargaProtectoras()
    {
        AgenteCatalogos au = new AgenteCatalogos();
        List<Categoria> categoria = new List<Categoria>();
        categoria = au.LeerCatalogos(3);

        this.cboProtectora.Items.Clear();
        this.cboProtegidoPorEdit.Items.Clear();

        ListItem item = new ListItem();
        item.Text = "(Seleccione)";
        item.Value = "-1";

        this.cboProtectora.Items.Add(item);
        this.cboProtegidoPorEdit.Items.Add(item);

        foreach (Categoria a in categoria)
        {
            item = new ListItem();
            item.Text = a.Descripcion;
            item.Value = a.IdCategoria.ToString();

            this.cboProtectora.Items.Add(item);
            this.cboProtegidoPorEdit.Items.Add(item);
        }
    }


    private void CargaClientes(string ciudad)
    {
        AgenteCatalogos au = new AgenteCatalogos();
        List<Categoria> categoria = new List<Categoria>();
        categoria = au.LeerCatalogos(5);

        this.cboClienteBuscar.Items.Clear();

        ListItem item = new ListItem();
        item.Text = "(Seleccione)";
        item.Value = "-1";
        this.cboClienteBuscar.Items.Add(item);

        foreach (Categoria a in categoria)
        {
            item = new ListItem();
            item.Text = a.Descripcion;
            item.Value = a.IdCategoria.ToString();
            this.cboClienteBuscar.Items.Add(item);
        }
    }

    private void CargaClientesRegistro(string ciudad)
    {
        AgenteClientes au = new AgenteClientes();
        List<Cliente> cliente_ = new List<Cliente>();
        cliente_ = au.ObtenerClientesConObra(ciudad);
        var _cliente = from cl in cliente_
                       select new { cl.NombreCompleto, cl.ClaveCliente };

        cboCliente.Items.Clear();

        ListItem item = new ListItem();
        item.Text = "(Seleccione)";
        item.Value = "-1";
        this.cboCliente.Items.Add(item);

        foreach (var a in _cliente.Distinct())
        {
            item = new ListItem();
            item.Text = a.NombreCompleto;
            item.Value = a.ClaveCliente;
            this.cboCliente.Items.Add(item);
        }
    }
    public void CargaBancos()
    {
        AgenteCheques au = new AgenteCheques();
        List<Banco> bancos = new List<Banco>();
        bancos = au.LeerBancos();
        

        cboBanco.Items.Clear();

        ListItem item = new ListItem();
        item.Text = "(Seleccione)";
        item.Value = "-1";
        this.cboBanco.Items.Add(item);

        foreach (var a in bancos.Distinct())
        {
            item = new ListItem();
            item.Text = a.NombreCorto;
            item.Value = a.Bancoid.ToString();
            this.cboBanco.Items.Add(item);
        }
    }

    public void CargaEstatusChequesSeguimiento()
    {
        AgenteCatalogos au = new AgenteCatalogos();
        List<Categoria> categoria = new List<Categoria>();
        categoria = au.LeerCatalogos(4);

        this.cboEstatusEdit.Items.Clear();

        ListItem item = new ListItem();
        item.Text = "(Seleccione)";
        item.Value = "-1";
        this.cboEstatusEdit.Items.Add(item);

        foreach (Categoria a in categoria)
        {
            item = new ListItem();
            item.Text = a.Descripcion;
            item.Value = a.IdCategoria.ToString();
            this.cboEstatusEdit.Items.Add(item);
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
            cargaGrid_Cheques();
        }
    }

    protected void gridCheques_ItemDataBound(object sender, GridItemEventArgs e)
    {
    }

    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Cheques.aspx?page=Registro");
    }

    protected void gridCheques_DeleteCommand(object source, GridCommandEventArgs e)
    {
    }
    private void cargaGrid_Cheques()
    {
        List<Concretec.Pedidos.BE.Cheques> cheques = new List<Concretec.Pedidos.BE.Cheques>();
        DateTime desde = DateTime.Parse(inicio.DateInput.Text.Substring(0, 10));
        DateTime hasta = DateTime.Parse(fin.DateInput.Text.Substring(0, 10));
        cheques = agente.BuscaCheques(int.Parse(ClienteId_Buscar), desde, hasta, int.Parse(cboEstatus.SelectedValue.ToString()));
        gridCheques.DataSource = cheques;
        gridCheques.DataBind();
    }


    protected void gridCheques_ItemCommand(object source, GridCommandEventArgs e)
    {
    }

    private void cargaEntidad(Pedido p, GridCommandEventArgs e)//INQx: Cambiar entidad
    {
    }

    public void Exportar()
    {
        gridCheques.ExportSettings.ExportOnlyData = true;
        gridCheques.ExportSettings.IgnorePaging = true;
        gridCheques.ExportSettings.OpenInNewWindow = false;
        gridCheques.ExportSettings.UseItemStyles = false;
        gridCheques.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;
        gridCheques.MasterTableView.ExportToExcel();
    }

    protected void btnExportar_Click(object sender, ImageClickEventArgs e)
    {
        ConfigureExport();
        gridCheques.MasterTableView.ExportToExcel();
    }

    protected void gridCheques_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {

    }

    public void ConfigureExport()
    {
        gridCheques.ExportSettings.ExportOnlyData = true;
        gridCheques.ExportSettings.IgnorePaging = true;
        gridCheques.ExportSettings.FileName = "Cheques";
        gridCheques.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;
    }

    protected void cmdGuardarCheque_Click(object sender, ImageClickEventArgs e)
    {
        bool salida = false;


        if (valida_captura_cheque())
        {
            try
            {
                var cheque = new Cheques();

                cheque.CveCiudad        = cbociudad.SelectedValue;
                cheque.FechaCobro       = DateTime.Parse(dtFechaCobro.SelectedDate.ToString());
                cheque.IdBanco          = int.Parse(cboBanco.SelectedValue.ToString());
                cheque.IdCliente        = int.Parse(cboCliente.SelectedValue.ToString());
                cheque.IdProCheque      = int.Parse(cboProtectora.SelectedValue.ToString());
                cheque.Monto            = decimal.Parse(txtMonto.Text);
                cheque.IdUsuario        = DatosUsuario.Id_Usuario;
                cheque.FechaRecepcion   = DateTime.Parse(dtRecepcion.SelectedDate.ToString());
                cheque.ReferenciaPro    = txtReferencia.Text;
                cheque.Observaciones    = txtObservaciones.Text;

                agente = new AgenteCheques();
                bool resultado = false;

                if (txtIdCheque_Edicion.Text.ToString().Trim().Length == 0)
                {
                    resultado = agente.InsertaCheque(cheque);
                }
                else
                {
                    cheque.IdCheque = int.Parse(txtIdCheque_Edicion.Text.ToString().Trim());
                    resultado = agente.ActualizaCheque(cheque);
                }
                

                   if(resultado)
                   {
                        Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
                        limpiaRegistroCheque();
                   }
                    else
                   {
                       Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
                   }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.CAPTURAR_CAMPOS_REQ);
        }
    }

    protected void cmdGuardarSeguimiento_Click(object sender, ImageClickEventArgs e)
    {
        bool salida = false;


        if (valida_captura_seguimiento())
        {
            try
            {
                AgenteCheques ach                   = new AgenteCheques();
                Cheques cheque_info                 = new Cheques();
                ChequeSeguimiento seguimiento_info  = new ChequeSeguimiento();
                List<ChequeSeguimiento> lista_seguimientos_info = new List<ChequeSeguimiento>();

                DateTime fechaCobro = DateTime.Now;
                if (dtFechaCobroEdit.SelectedDate != null)
                {
                    fechaCobro= DateTime.Parse(dtFechaCobroEdit.SelectedDate.ToString());
                }

                seguimiento_info.IdCheque           = int.Parse(lblIdCheque.Text);
                seguimiento_info.IdChequeEstatus    = int.Parse(cboEstatusEdit.SelectedValue.ToString());
                seguimiento_info.IdProCheque        = int.Parse(cboProtegidoPorEdit.SelectedValue.ToString());
                seguimiento_info.IdUsuario          = DatosUsuario.Id_Usuario;
                seguimiento_info.Observaciones      = txtObservacionesSeguimiento.Text.Trim().ToString();
                seguimiento_info.ReferenciaPro      = txtreferenciaedit.Text.ToString();
                seguimiento_info.FechaCobro         = fechaCobro;

                lista_seguimientos_info.Add(seguimiento_info);
                cheque_info.Seguimientos = lista_seguimientos_info;
                salida = ach.InsertaSeguimiento(cheque_info);

                if(salida)
                {
                    LimpiarSeguimiento();
                    ach = new AgenteCheques();
                    Cheques InfoCheque = ach.InformacionCheque(int.Parse(lblIdCheque.Text.ToString()));
                    CargaSeguimientos(InfoCheque.Seguimientos);
                    CargaEstatusCheque();
                    pnlSeguimientoAgregar.Visible = false;
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
                }
            }
            catch (Exception ex)
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
            }
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.CAPTURAR_CAMPOS_REQ);
        }
    }

    void LimpiarSeguimiento()
    {
        cboEstatusEdit.SelectedValue        = "-1";
        cboProtegidoPorEdit.SelectedValue   = "-1";
        txtreferenciaedit.Text              = string.Empty;
        txtObservacionesSeguimiento.Text    = string.Empty;
        cboProtegidoPorEdit.Enabled         = false;
        txtreferenciaedit.Enabled           = false;
    }

    protected void cmdBackCheque_Click(object sender, ImageClickEventArgs e)
    {

    }
    
    protected void cmdBackSeguimiento_Click(object sender, ImageClickEventArgs e)
    {

    }

    public bool valida_captura_cheque()
    {
        bool salida = false;
        string _cliente = cboCliente.SelectedValue.ToString();
        string _banco = cboBanco.SelectedValue.ToString();
        int _monto = txtMonto.Text.Length;
        int _fecha = dtFechaCobro.SelectedDate.ToString().Length;

        if (_cliente != Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE 
            && _banco != Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE 
            && _monto > 0 && _fecha > 0)
        {
            salida = true;
        }

        return salida;
    }

    public bool valida_captura_seguimiento()
    {
        bool salida = false;
        string _estatus = cboEstatusEdit.SelectedValue.ToString();
        
        
        if (_estatus != Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE)
        {
            salida = true;
        }

        return salida;
    }

    protected void cmdNuevoSeguimiento_Click(object sender, ImageClickEventArgs e)
    {
        RadTabStrip1.Tabs[2].Selected = true;
        RadMultiPage1.SelectedIndex = 2;
        pnlSeguimientoAgregar.Visible = true;
        
    }

    protected void cboEstatusEdit_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool estado = false;
        if (cboEstatusEdit.SelectedItem.Text == "Reprogramado")
        {
            estado = true;
        }
        else
        {
            cboProtegidoPorEdit.SelectedValue = "-1";
            txtreferenciaedit.Text = string.Empty;
        }

        cboProtegidoPorEdit.Enabled     = estado;
        dtFechaCobroEdit.Enabled        = estado;
        txtreferenciaedit.Enabled       = estado;
    }

    void limpiaRegistroCheque()
    {
        cbociudad.SelectedValue         = "-1";
        cboCliente.SelectedValue        = "-1";
        cboBanco.SelectedValue          = "-1";
        txtMonto.Text                   = "0";
        dtRecepcion.SelectedDate        = DateTime.Now;
        dtFechaCobro.SelectedDate       = DateTime.Now.AddDays(30);
        cboProtectora.SelectedValue     = "-1";
        txtReferencia.Text              = string.Empty;
        txtObservaciones.Text           = string.Empty;
        txtIdCheque_Edicion.Text        = string.Empty;

        cbociudad.Enabled               = true;
        cboCliente.Enabled              = true;
    }



    private void CargaCiudades()
    {
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();
        this.cbociudad.Items.Clear();

        ListItem item = new ListItem();
        item.Text = "(Seleccione)";
        item.Value = "-1";
        this.cbociudad.Items.Add(item);

        lc = ac.ObtenerCiudades();
        foreach (Ciudad c in lc)
        {
            item = new ListItem();
            item.Text = c.Descripcion;
            item.Value = c.CveCiudad;
            cbociudad.Items.Add(item);
        }

    }

    public void CargaSeguimientos(List<ChequeSeguimiento> seguimientos)
    {
        gridChequesSeguimientos.DataSource = seguimientos;
        gridChequesSeguimientos.DataBind();
    }

    protected void gridCheques_ItemCommand1(object sender, GridCommandEventArgs e)
    {
        Cheques salida      = new Cheques();
        AgenteCheques ach   = new AgenteCheques();
        int idcheque        = 0;
        idcheque            = int.Parse(e.Item.Cells[2].Text);
        IdCheque            = idcheque;
        salida              = ach.InformacionCheque(idcheque);

        switch (e.CommandName)
        {
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR:
                RadTabStrip1.Tabs[1].Selected = true;
                RadMultiPage1.SelectedIndex = 1;
                CargaDatosEdicion(salida);
                break;
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_SEGUIMIENTO:
                RadTabStrip1.Tabs[2].Selected = true;
                RadMultiPage1.SelectedIndex = 2;
                CargaDatosSeguimiento(salida);
                break;
        }

        
    }

    protected void cbociudad_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargaClientesRegistro(cbociudad.SelectedValue);
    }

    protected void CargaDatosSeguimiento(Cheques cheque)
    {
        lblClienteHeader.Text = cheque.NombreCliente;
        lblBancoHeader.Text = cheque.NombreBanco;
        lblMontoHeader.Text = cheque.Monto.ToString();
        lblProtectoraHeader.Text = cheque.NombreProtectora;
        lblIdCheque.Text = cheque.IdCheque.ToString();

        CargaSeguimientos(cheque.Seguimientos);
        CargaEstatusCheque();
    }

    protected void CargaDatosEdicion(Cheques cheque)
    {
        txtIdCheque_Edicion.Text        = cheque.IdCheque.ToString();
        txtIdCheque_Edicion.Text        = cheque.IdCheque.ToString();
        cbociudad.SelectedValue         = cheque.CveCiudad;
        CargaClientesRegistro(cheque.CveCiudad);
        cboCliente.SelectedValue        = cheque.IdCliente.ToString();
        cboBanco.SelectedValue          = cheque.IdBanco.ToString();
        txtMonto.Text                   = cheque.Monto.ToString();
        txtMonto.Value                  = double.Parse(cheque.Monto.ToString());
        cboProtectora.SelectedValue     = cheque.IdProCheque.ToString();
        if (cheque.ReferenciaPro != null)
        {
            txtReferencia.Text = cheque.ReferenciaPro.ToString();
        }     
        dtRecepcion.SelectedDate        = cheque.FechaRecepcion;
        dtFechaCobro.SelectedDate       = cheque.FechaCobro;
        txtObservaciones.Text           = cheque.Observaciones;

        cbociudad.Enabled               = false;
        cboCliente.Enabled              = false;
    }
}