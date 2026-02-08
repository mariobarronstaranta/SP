using System;
using System.Collections.Generic;
using System.Web.UI;
using Telerik.Web.UI;
using Concretec.Pedidos.BE;
using Concretec.Agentes;

public partial class Views_Combustibles : System.Web.UI.Page
{

    #region Propiedades_Generales

    private DateTime startDate = DateTime.Today;
    public Usuario DatosUsuario
    {
        get
        {
            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
            return Login[0];
        }

    }

    AgenteUnidades agente = new AgenteUnidades();
    #endregion

    #region Propiedades_Lecturas

    public DateTime fechainiciolecturas
    {
        get
        {
            DateTime salida = DateTime.Now.AddDays(-1);
            if (dtiniciolectura.DateInput.Text != "")
            {
                salida = DateTime.Parse(dtiniciolectura.DateInput.Text.Substring(0, 10));
            }

            return salida;
        }
    }

    public DateTime fechafinlecturas
    {
        get
        {
            DateTime salida = DateTime.Now;
            if (dtfinlecturas.DateInput.Text != "")
            {
                salida = DateTime.Parse(dtfinlecturas.DateInput.Text.Substring(0, 10));
            }

            return salida;

        }
    }

    public int idtanquelecturasfiltro
    {
        get
        {
            string salida = "0";
            if ((cboTanquesLecturas.SelectedValue) == "")
            { salida = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE; }
            else
            { salida = cboTanquesLecturas.SelectedValue; }
            return int.Parse(salida);
        }
    }

    public string ciudadtanquelecturasfiltro
    { get { return cboCiudadLecturas.SelectedValue.ToString(); } }

    public int idtanquelecturasregistro
    {
        get
        {
            string salida = "0";
            if ((cboTanqueLecturaRegistro.SelectedValue) == "")
            { salida = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE; }
            else
            { salida = cboTanqueLecturaRegistro.SelectedValue; }
            return int.Parse(salida);
        }
    }

    public double lecturavalorreg
    { get { return double.Parse(this.lecturavalorr.Value.ToString()); } }

    public DateTime fechalecturareg
    {
        get
        {
            DateTime salida = DateTime.Now;
            if (dtfechalecturar.DateInput.Text != "")
            {
                salida = DateTime.Parse(dtfechalecturar.DateInput.Text.Substring(0, 10));
            }

            return salida;

        }
    }

    public string HoraLecturaR
    { get { return drLecturaHora.DateInput.Text; } }
    #endregion

    #region Propiedades_Tanques

    public string ciudadbusquedatanque
    { get { return cboCiudadFiltro.SelectedValue.ToString(); } }

    public string ciudadregistro
    { get { return CboCiudadRegistro.SelectedValue.ToString(); } }

    public int idplantaregistro
    { get { return int.Parse(CboPlantaRegistro.SelectedValue.ToString()); } }

    public int idcombustibleregistro
    { get { return int.Parse(CboTipoCombustible.SelectedValue.ToString()); } }

    public double? capacidadregistro
    { get { return txtCapacidadTRegistro.Value; } }

    public string nombretanqueregistro
    { get { return txtNombreTanqueRegistro.Text; } }

    public decimal Alturaregistro
    { get { return decimal.Parse(txtAltura_registro.Value.ToString()); } }

    public string Fromaregistro
    { get { return CboFormaCilindro.SelectedValue.ToString(); } }

    public decimal Diametro1registro
    { get { return decimal.Parse(txtDiametro1_registro.Value.ToString()); } }

    public decimal Diametro2registro
    { get { return decimal.Parse(txtDiametro2_registro.Value.ToString()); } }

    //Alturaregistro, Fromaregistro, Diametro1registro,Diametro2registro)

    #endregion

    #region CargaInicial

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


        //********************************************************
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

                CargaCiudades();
                CargaTanquesLecturasRegistro();

                //Tab Tanques
                CargaPlantas();
                CboPlantaRegistro.SelectedValue = DatosUsuario.Ciudad;
                llenagridtanques();

                //Seccion de Lecturas
                dtiniciolectura.SelectedDate = DateTime.Now.AddDays(-1);
                dtfinlecturas.SelectedDate = DateTime.Now;

                dtfechalecturar.SelectedDate = DateTime.Now;
                drLecturaHora.SelectedDate = DateTime.Now;

                cboCiudadLecturas.SelectedValue = DatosUsuario.Ciudad;
                CargaTanquesLecturas(ciudadtanquelecturasfiltro);
                llenagridlecturas();

                //Seccion de Entradas
                dtdesdein_sel.SelectedDate = DateTime.Now.AddDays(-1);
                dtdesdehasta_sel.SelectedDate = DateTime.Now;
                cbociudadin_sel.SelectedValue = DatosUsuario.Ciudad;
                CargaGridEntradas();

                //Seccion Salidas de combustible
                dtDesdeSalida.SelectedDate = DateTime.Now.AddDays(-3);
                dtHastaSalida.SelectedDate = DateTime.Now;
                CargaPlantasDefault();
                llenaOperadores();
                CargaUnidadesFull();
                cargagridsalidas();
                resetSalidas();

                //Seccion Consumos
                dtDesdeConsumos.SelectedDate = DateTime.Now.AddDays(-7);
                dtHastaConsumos.SelectedDate = DateTime.Now;
                cboCdConsumos.SelectedValue = DatosUsuario.Ciudad;
                CargaGridConsumos();

                //Seccion Ajustes
                dtDesdeAjuste.SelectedDate = DateTime.Now.AddDays(-7);
                dtHastaAjuste.SelectedDate = DateTime.Now;
                dtAjuste.SelectedDate = DateTime.Now;
                llenagridAjustes();

                //Seccion Reporte Estadisticas
                llenagridResumen();

            }


            if (tab != null)
            {
                tab.SelectParents();
                tab.PageView.Selected = true;
            }

        }
        //********************************************************

    }
    #endregion

    #region SeccionTanques

    public bool validaCaptura_TanquesRegistro()
    {
        string _ciudad = CboCiudadRegistro.SelectedValue.ToString();
        string _planta = CboPlantaRegistro.SelectedValue.ToString();
        string _nombre = txtNombreTanqueRegistro.Text.Trim();
        string _capacidad = txtCapacidadTRegistro.Text.Trim();
        string _combustible = CboTipoCombustible.SelectedValue.ToString();
        bool salida = false;

        if (_capacidad.Length > 0 && _nombre.Length > 0 && _ciudad != Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE && _planta != Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE && _combustible != Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE)
        {
            salida = true;
        }

        return salida;
    }

    private void LimpiaCapturaTanque()
    {
        CargaCiudades();
        CargaPlantas();
        CboPlantaRegistro.SelectedValue = DatosUsuario.Ciudad;
        txtNombreTanqueRegistro.Text = string.Empty;
        txtCapacidadTRegistro.Text = "0";
        CboTipoCombustible.SelectedValue = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        txtidtanqueregistro.Text = string.Empty;
        llenagridtanques();
    }

    private void CargaTanquesLecturasRegistro()
    {
        agente = new AgenteUnidades();
        List<Tanque> _planta = new List<Tanque>();
        _planta = agente.BuscaTanquesCombo(-1);
        cboTanqueLecturaRegistro.Items.Clear();
        cbotanquein_sel.Items.Clear();
        cbotanquereg_in.Items.Clear();
        cbotanque_salida_reg.Items.Clear();
        cboTanqueFiltroSalida.Items.Clear();
        cboTanqueConsumos.Items.Clear();
        cboTanqueAjustesR.Items.Clear();
        cboTanqueAjustesFil.Items.Clear();

        RadComboBoxItem item = new RadComboBoxItem();
        RadComboBoxItem item_in = new RadComboBoxItem();
        RadComboBoxItem item_in_reg = new RadComboBoxItem();
        RadComboBoxItem item_salida_reg = new RadComboBoxItem();
        RadComboBoxItem item_salidas_fil = new RadComboBoxItem();
        RadComboBoxItem item_CN_fil = new RadComboBoxItem();
        RadComboBoxItem item_Ajuste_reg = new RadComboBoxItem();
        RadComboBoxItem item_Ajuste_Fil = new RadComboBoxItem();

        item_Ajuste_Fil = new RadComboBoxItem();
        item_Ajuste_Fil.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item_Ajuste_Fil.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboTanqueAjustesFil.Items.Add(item_Ajuste_Fil);

        item_Ajuste_reg = new RadComboBoxItem();
        item_Ajuste_reg.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item_Ajuste_reg.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboTanqueAjustesR.Items.Add(item_Ajuste_reg);

        item_CN_fil = new RadComboBoxItem();
        item_CN_fil.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item_CN_fil.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboTanqueConsumos.Items.Add(item_CN_fil);

        item_salida_reg = new RadComboBoxItem();
        item_salida_reg.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item_salida_reg.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cbotanque_salida_reg.Items.Add(item_salida_reg);

        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboTanqueLecturaRegistro.Items.Add(item);

        item_in = new RadComboBoxItem();
        item_in.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item_in.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cbotanquein_sel.Items.Add(item_in);

        item_in_reg = new RadComboBoxItem();
        item_in_reg.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item_in_reg.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cbotanquereg_in.Items.Add(item_in_reg);

        item_salidas_fil = new RadComboBoxItem();
        item_salidas_fil.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item_salidas_fil.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboTanqueFiltroSalida.Items.Add(item_salidas_fil);

        foreach (Tanque a in _planta)
        {
            item = new RadComboBoxItem();
            item.Text = a.Nombre;
            item.Value = a.IdTanque.ToString();
            this.cboTanqueLecturaRegistro.Items.Add(item);

            item_in = new RadComboBoxItem();
            item_in.Text = a.Nombre;
            item_in.Value = a.IdTanque.ToString();
            cbotanquein_sel.Items.Add(item_in);

            item_in_reg = new RadComboBoxItem();
            item_in_reg.Text = a.Nombre;
            item_in_reg.Value = a.IdTanque.ToString();
            cbotanquereg_in.Items.Add(item_in_reg);

            item_salida_reg = new RadComboBoxItem();
            item_salida_reg.Text = a.Nombre;
            item_salida_reg.Value = a.IdTanque.ToString();
            cbotanque_salida_reg.Items.Add(item_salida_reg);

            item_salidas_fil = new RadComboBoxItem();
            item_salidas_fil.Text = a.Nombre; 
            item_salidas_fil.Value = a.IdTanque.ToString();
            cboTanqueFiltroSalida.Items.Add(item_salidas_fil);

            item_CN_fil = new RadComboBoxItem();
            item_CN_fil.Text = a.Nombre;
            item_CN_fil.Value = a.IdTanque.ToString();
            cboTanqueConsumos.Items.Add(item_CN_fil);

            item_Ajuste_reg = new RadComboBoxItem();
            item_Ajuste_reg.Text = a.Nombre;
            item_Ajuste_reg.Value = a.IdTanque.ToString();
            cboTanqueAjustesR.Items.Add(item_Ajuste_reg);

            item_Ajuste_Fil = new RadComboBoxItem();
            item_Ajuste_Fil.Text = a.Nombre;
            item_Ajuste_Fil.Value = a.IdTanque.ToString();
            cboTanqueAjustesFil.Items.Add(item_Ajuste_Fil);
        }
    }

    private void CargaTanquesLecturas(string idCiudad)
    {
        agente = new AgenteUnidades();
        List<Tanque> _planta = new List<Tanque>();
        _planta = agente.BuscaTanquesCombo(-1);
        cboTanquesLecturas.Items.Clear();

        RadComboBoxItem item = new RadComboBoxItem();
        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboTanquesLecturas.Items.Add(item);

        foreach (Tanque a in _planta)
        {
            item = new RadComboBoxItem();
            item.Text = a.Nombre;
            item.Value = a.IdTanque.ToString();
            this.cboTanquesLecturas.Items.Add(item);
        }
    }

    private void CargaPlantasDefault()
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> _planta = new List<Planta>();
        _planta = au.ObtenerPlantasObra(DatosUsuario.Ciudad);
        cboplanta_salida_reg.Items.Clear();
        cboplantaE.Items.Clear();

        RadComboBoxItem item = new RadComboBoxItem();
        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboplanta_salida_reg.Items.Add(item);

        RadComboBoxItem itemE = new RadComboBoxItem();
        itemE = new RadComboBoxItem();
        itemE.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        itemE.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboplantaE.Items.Add(itemE);

        foreach (Planta a in _planta)
        {
            item = new RadComboBoxItem();
            item.Text = a.Nombre;
            item.Value = a.IDPlanta.ToString();
            this.cboplanta_salida_reg.Items.Add(item);

            itemE = new RadComboBoxItem();
            itemE.Text = a.Nombre;
            itemE.Value = a.IDPlanta.ToString();
            this.cboplantaE.Items.Add(itemE);
        }
    }

    private void CargaPlantas()
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> _planta = new List<Planta>();
        _planta = au.ObtenerPlantasObra(ciudadregistro);
        CboPlantaRegistro.Items.Clear();

        RadComboBoxItem item = new RadComboBoxItem();
        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.CboPlantaRegistro.Items.Add(item);

        foreach (Planta a in _planta)
        {
            item = new RadComboBoxItem();
            item.Text = a.Nombre;
            item.Value = a.IDPlanta.ToString();
            this.CboPlantaRegistro.Items.Add(item);
        }
    }

    private void CargaCiudades()
    {
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();
        cboCiudadFiltro.Items.Clear();
        CboCiudadRegistro.Items.Clear();
        cboCiudadLecturas.Items.Clear();
        cbociudadin_sel.Items.Clear();
        cboCdConsumos.Items.Clear();

        RadComboBoxItem item = new RadComboBoxItem();
        RadComboBoxItem itemr = new RadComboBoxItem();
        RadComboBoxItem iteml = new RadComboBoxItem();
        RadComboBoxItem itemIN = new RadComboBoxItem();
        RadComboBoxItem itemCN = new RadComboBoxItem();

        itemCN = new RadComboBoxItem();
        itemCN.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        itemCN.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboCdConsumos.Items.Add(itemCN);

        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboCiudadFiltro.Items.Add(item);

        itemr = new RadComboBoxItem();
        itemr.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        itemr.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        CboCiudadRegistro.Items.Add(itemr);

        iteml = new RadComboBoxItem();
        iteml.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        iteml.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboCiudadLecturas.Items.Add(iteml);

        itemIN = new RadComboBoxItem();
        itemIN.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        itemIN.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cbociudadin_sel.Items.Add(itemIN);

        lc = ac.ObtenerCiudades();
        foreach (Ciudad c in lc)
        {
            item = new RadComboBoxItem();
            item.Text = c.Descripcion;
            item.Value = c.CveCiudad;
            cboCiudadFiltro.Items.Add(item);

            itemr = new RadComboBoxItem();
            itemr.Text = c.Descripcion;
            itemr.Value = c.CveCiudad;
            CboCiudadRegistro.Items.Add(itemr);

            iteml = new RadComboBoxItem();
            iteml.Text = c.Descripcion;
            iteml.Value = c.CveCiudad;
            cboCiudadLecturas.Items.Add(iteml);

            itemIN = new RadComboBoxItem();
            itemIN.Text = c.Descripcion;
            itemIN.Value = c.CveCiudad;
            cbociudadin_sel.Items.Add(itemIN);

            itemCN = new RadComboBoxItem();
            itemCN.Text = c.Descripcion;
            itemCN.Value = c.CveCiudad;
            cboCdConsumos.Items.Add(itemCN);
        }

    }

    public void CargaDatosEdicion_Tanque(int idtanque)
    {
        AgenteCombustibles  agenteC = new AgenteCombustibles();
        List<Tanque> lista = new List<Tanque>();
        Tanque elemento = new Tanque();
        lista = agenteC.Busca_Resumen_Tanque(ciudadbusquedatanque,idtanque);

        if (lista.Count > 0)
        {
            tblRegistro.Visible                 = true;
            tblfiltros.Visible                  = false;
            elemento                            = lista[0];

            CboCiudadRegistro.SelectedValue     = elemento.ciudad;
            CargaPlantas();
            CboPlantaRegistro.SelectedValue     = elemento.IdPlanta.ToString();
            txtNombreTanqueRegistro.Text        = elemento.Nombre;
            txtCapacidadTRegistro.Text          = elemento.capacidad.ToString();
            CboTipoCombustible.SelectedValue    = elemento.IdTipoCombustible.ToString();
            txtidtanqueregistro.Text            = elemento.IdTanque.ToString();
            //Nuevos Valores
            txtAltura_registro.Text             = elemento.Altura.ToString();
            CboFormaCilindro.SelectedValue      = elemento.Forma.ToString();
            txtDiametro1_registro.Text          = elemento.DiametroA.ToString();
            txtDiametro2_registro.Text          = elemento.DiametroB.ToString();

            if (CboFormaCilindro.SelectedValue.ToString().ToUpper() == "E")
            {
                lbldiametro2.Visible = true;
                txtDiametro2_registro.Visible = true;
            }
            else
            {
                lbldiametro2.Visible = false;
                txtDiametro2_registro.Visible = false;
            }
        }
        else
        {
            tblRegistro.Visible = false;
            tblfiltros.Visible = true;
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_SIN_RESULTADOS);
        }

    }

    public void llenagridtanques()
    {
        List<Tanque> lista = new List<Tanque>();
        lista = ListaTanques();

        gridTanques.DataSource = lista;
        gridTanques.DataBind();

    }

    public List<Tanque> ListaTanques()
    {
        List<Tanque> salida = new List<Tanque>();
        AgenteCombustibles  agenteC = new AgenteCombustibles();
        salida = agenteC.Busca_Resumen_Tanque(cboCiudadFiltro.SelectedValue,-1);

        return salida;
    }

    protected void cmdbuscar_Click(object sender, ImageClickEventArgs e)
    {
        llenagridtanques();
    }
    protected void cmdnuevo_Click(object sender, ImageClickEventArgs e)
    {
        tblRegistro.Visible = true;
        tblfiltros.Visible = false;
    }

    void ResetPanelRegistroTanque()
    {
        CboCiudadRegistro.SelectedValue = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        CargaPlantas();
        txtNombreTanqueRegistro.Text = string.Empty;
        txtCapacidadTRegistro.Value = 0;
        CboTipoCombustible.SelectedValue = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        txtidtanqueregistro.Text = string.Empty;
    }
    protected void cmdGuardarTanque_Click(object sender, ImageClickEventArgs e)
    {
        bool salida = false;
        string accion = "SET";
        int _idtanque = 0;
        int _tipocombustible = -1;
        _tipocombustible = int.Parse(CboTipoCombustible.SelectedValue.ToString());

        if (validaCaptura_TanquesRegistro())
        {
            if (txtidtanqueregistro.Text.Length > 0)
            {
                accion = "UPD";
                _idtanque = int.Parse(txtidtanqueregistro.Text);
            }

            try
            {
                agente = new AgenteUnidades();
                decimal d2 = 0;
                if (Fromaregistro == "E")
                {
                    d2 = Diametro2registro;
                }


                salida = agente.InsertaTanque(accion, _idtanque, ciudadregistro, idplantaregistro, _tipocombustible, nombretanqueregistro, double.Parse(capacidadregistro.ToString()), DatosUsuario.Id_Usuario,
                     Alturaregistro, Fromaregistro, Diametro1registro, d2);
                if (salida)
                {
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
                    tblRegistro.Visible = false;
                    tblfiltros.Visible = true;
                    ResetPanelRegistroTanque();
                    llenagridtanques();
                }
                else
                {
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
                }
            }
            catch
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
            }
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.CAPTURAR_CAMPOS_REQ);
        }
    }

    protected void CustomizeDay(object sender, Telerik.Web.UI.Calendar.DayRenderEventArgs e)
    {
        DateTime CurrentDate = e.Day.Date;
        if (startDate <= CurrentDate && CurrentDate >= DateTime.Today.AddDays(-1))
        {
            return;
        }
        e.Day.IsDisabled = true;
        e.Day.IsSelectable = false;
        (sender as RadCalendar).SpecialDays.Add(e.Day);
    }

    protected void CboCiudadRegistro_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        CargaPlantas();
    }

    protected void cmdbacktanque_Click(object sender, ImageClickEventArgs e)
    {
        ResetPanelRegistroTanque();
        tblRegistro.Visible = false;
        tblfiltros.Visible = true;
    }
    #endregion

    #region SeccionLecturas

    public bool valida_captura_lecturas()
    {
        bool salida = false;
        string _tanque = cboTanqueLecturaRegistro.SelectedValue.ToString();
        int _lectura = lecturavalorr.Text.Length;
        int _hora = drLecturaHora.SelectedDate.ToString().Length;

        if (_tanque != Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE && _lectura > 0 && _hora > 0)
        {
            salida = true;
        }

        return salida;
    }

    protected void gridlecturas_ItemCommand(object sender, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR:
                CargaDatosEdicion_Lectura(int.Parse(e.Item.Cells[2].Text));
                break;
        }
    }

    void CargaDatosEdicion_Lectura(int idlectura)
    {
        //primero limpiamos la pantalla de captura antes de cargar datos
        limpiacampturalectura();
        //Cambiamos los paneles para colocarlos activos
        tblregistrolecturas.Visible = true;
        tbllecturasfiltro.Visible = false;

        lblidlectura.Visible = true;
        txtidlectura.Visible = true;
        //instanciamos los agentes
        agente = new AgenteUnidades();
        Lectura _editables = new Lectura();
        _editables = agente.BuscaLecturaEdicion(idlectura);

        cboTanqueLecturaRegistro.SelectedValue = _editables.idtanque.ToString();
        lecturavalorr.Text = _editables.valor.ToString();
        dtfechalecturar.SelectedDate = DateTime.Parse(_editables.fecha);
        drLecturaHora.SelectedDate = DateTime.Parse(_editables.hora);
        txtidlectura.Text = _editables.idlectura.ToString();

        //Cambios Junio 2019
        LecturaValor_cms.Text = _editables.Lectura_cms.ToString();
        LectValorTemp.Text = _editables.Temperatura.ToString();
    }

    public void llenagridlecturas()
    {
        List<Lectura> lista = new List<Lectura>();
        agente = new AgenteUnidades();
        lista = agente.BuscaLecturas(DatosUsuario.Ciudad, idtanquelecturasfiltro, fechainiciolecturas, fechafinlecturas);

        gridlecturas.DataSource = lista;
        gridlecturas.DataBind();

    }

    protected void btnbuscarlecturas_Click(object sender, ImageClickEventArgs e)
    {
        llenagridlecturas();
    }
    protected void btnnuevalectura_Click(object sender, ImageClickEventArgs e)
    {
        agente = new AgenteUnidades();
        try
        {
            tblregistrolecturas.Visible = true;
            tbllecturasfiltro.Visible = false;

            dtfechalecturar.SelectedDate = DateTime.Now;
            drLecturaHora.SelectedDate = DateTime.Now;
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }

    protected void cmdGuardarLectura_Click(object sender, ImageClickEventArgs e)
    {
        bool salida = false;


        if (valida_captura_lecturas())
        {
            try
            {
                /**
                tblregistrolecturas.Visible = true;
                tbllecturasfiltro.Visible = false;
                lblidlectura.Visible = true;
                txtidlectura.Visible = true;
                **/
                DateTime hora = DateTime.Parse(drLecturaHora.SelectedDate.ToString());
                if (txtidlectura.Text.Length == 0)
                {
                    salida = agente.RegistraLectura(idtanquelecturasregistro, fechalecturareg, hora, float.Parse(lecturavalorreg.ToString()), DatosUsuario.Id_Usuario, int.Parse(this.LectValorTemp.Text),int.Parse(this.LecturaValor_cms.Text));
                }
                else
                {
                    salida = agente.ActualizaLectura(int.Parse(txtidlectura.Text), idtanquelecturasregistro, fechalecturareg, hora, float.Parse(lecturavalorreg.ToString()), DatosUsuario.Id_Usuario, int.Parse(this.LectValorTemp.Text),int.Parse(this.LecturaValor_cms.Text));
                }


                if (salida)
                {
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
                    tblregistrolecturas.Visible = false;
                    tbllecturasfiltro.Visible = true;
                    limpiacampturalectura();
                    llenagridlecturas();
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


    protected void cboCiudadLecturas_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        CargaTanquesLecturas(ciudadtanquelecturasfiltro);
    }

    protected void cmdBackLecturas_Click(object sender, ImageClickEventArgs e)
    {
        tblregistrolecturas.Visible = false;
        tbllecturasfiltro.Visible = true;
        limpiacampturalectura();
    }

    void limpiacampturalectura()
    {
        cboTanqueLecturaRegistro.SelectedValue = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        dtfechalecturar.SelectedDate = DateTime.Now;
        lecturavalorr.Text = "0";
        txtidlectura.Text = "";

        lblidlectura.Visible = false;
        txtidlectura.Visible = false;
    }

    #endregion


    protected void gridTanques_ItemCommand(object sender, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR:
                CargaDatosEdicion_Tanque(int.Parse(e.Item.Cells[2].Text));
                break;
        }
    }
    protected void cbociudadin_sel_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    protected void btnbuscain_Click(object sender, ImageClickEventArgs e)
    {
        //Hello
        CargaGridEntradas();
    }
    protected void btnagregain_Click(object sender, ImageClickEventArgs e)
    {
        tblFiltrosEntrada.Visible = false;
        tblEntradaRegistro.Visible = true;
        dtregistroin.SelectedDate = DateTime.Now;
    }

    bool validacapturaentradas()
    {
        bool salida = false;
        string _tanque = cbotanquereg_in.SelectedValue.ToString();
        int _proveedor = txtproveedor.Text.Trim().Length;
        int _valor = txtlitrosin.Text.Trim().Length;
        int _fecha = dtregistroin.DateInput.Text.Trim().Length;

        if (_tanque != Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE && _proveedor > 0 && _valor > 0 && _fecha > 0)
        {
            salida = true;
        }

        return salida;
    }

    protected void btngrabarin_Click(object sender, ImageClickEventArgs e)
    {
        agente = new AgenteUnidades();
        bool salida = false;
        int _idtanque = 0;
        int _idtipomovimiento = 1; //1 = Entrada
        float _valor = float.Parse(txtlitrosin.Value.ToString());
        DateTime fechamov = DateTime.Parse(dtregistroin.DateInput.Text.Substring(0, 10));
        _idtanque = int.Parse((cbotanquereg_in.SelectedValue));

        if (validacapturaentradas())
        {
            if (txtClaveEntrada.Text.Length > 0)
            {
                salida = agente.ActualizaMovimientoIN(int.Parse(txtClaveEntrada.Text), _idtanque, _idtipomovimiento, _valor, DatosUsuario.Id_Usuario, fechamov, txtproveedor.Text, txtReferencia.Text);
            }
            else
            {
                salida = agente.RegistraMovimientoIN(_idtanque, _idtipomovimiento, _valor, DatosUsuario.Id_Usuario, fechamov, txtproveedor.Text, txtReferencia.Text);
            }


            if (salida)
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
                limpiaregistroentradas();
                CargaGridEntradas();
            }
            else
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
            }
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.CAPTURAR_CAMPOS_REQ);
        }


    }

    void limpiaregistroentradas()
    {
        tblFiltrosEntrada.Visible = true;
        tblEntradaRegistro.Visible = false;
        ClaveEntrada.Visible = false;
        txtClaveEntrada.Visible = false;
        txtClaveEntrada.Text = "";

        cbotanquereg_in.SelectedValue = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        txtproveedor.Text = "";
        txtlitrosin.Text = "0";
        dtregistroin.SelectedDate = DateTime.Now;
    }

    protected void btnregresarin_Click(object sender, ImageClickEventArgs e)
    {
        limpiaregistroentradas();
    }

    void CargaGridEntradas()
    {
        List<TanqueMovimiento> lista = new List<TanqueMovimiento>();
        agente = new AgenteUnidades();
        int _idtanque = int.Parse(cbotanquein_sel.SelectedValue.ToString());
        string _ciudad = cbociudadin_sel.SelectedValue;
        DateTime _desde = DateTime.Parse(dtdesdein_sel.DateInput.Text.Substring(0, 10));
        DateTime _hasta = DateTime.Parse(dtdesdehasta_sel.DateInput.Text.Substring(0, 10));

        lista = agente.BuscaEntradaCombustibles(_idtanque, _desde, _hasta, _ciudad, 0);

        gridEntradas.DataSource = lista;
        gridEntradas.DataBind();
    }

    void CargaUnidadesPlantas()
    {
        agente = new AgenteUnidades();
        List<ConsultaUnidad> lista = new List<ConsultaUnidad>();

        lista = agente.ObtenerUnidadesFiltro("", cboplanta_salida_reg.SelectedValue.ToString(), DatosUsuario.Ciudad,1);
        cbounidad_red_salida.Items.Clear();

        RadComboBoxItem item = new RadComboBoxItem();
        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cbounidad_red_salida.Items.Add(item);

        foreach (ConsultaUnidad a in lista)
        {
            item = new RadComboBoxItem();
            item.Text = a.IDClaveUnidad;
            item.Value = a.IDUnidad.ToString();
            this.cbounidad_red_salida.Items.Add(item);
        }
    }

    void CargaUnidadesFull()
    {
        agente = new AgenteUnidades();
        List<ConsultaUnidad> lista = new List<ConsultaUnidad>();

        lista = agente.ObtenerUnidadesFiltro("", Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE, DatosUsuario.Ciudad,1);
        cboUnidadSalidaFiltro.Items.Clear();

        RadComboBoxItem item = new RadComboBoxItem();
        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboUnidadSalidaFiltro.Items.Add(item);

        foreach (ConsultaUnidad a in lista)
        {
            item = new RadComboBoxItem();
            item.Text = a.IDClaveUnidad;
            item.Value = a.IDUnidad.ToString();
            this.cboUnidadSalidaFiltro.Items.Add(item);
        }
    }

    protected void cboplanta_salida_reg_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        CargaUnidadesPlantas();
    }

    public void llenaOperadores()
    {
        AgentePersonal ap = new AgentePersonal();
        List<Personal> lista = new List<Personal>();
        lista = ap.ObtenerChoferUnidad(-1, DatosUsuario.Ciudad);

        RadComboBoxItem item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cbooperadores_salida.Items.Add(item);

        foreach (Personal chofer in lista)
        {
            item = new RadComboBoxItem();
            item.Text = chofer.Nombre + " " + chofer.APaterno;
            item.Value = chofer.IDPersonal.ToString();
            this.cbooperadores_salida.Items.Add(item);
        }

    }
    protected void btnGrabarSalida_Click(object sender, ImageClickEventArgs e)
    {
        agente = new AgenteUnidades();
        bool salida = false;
        int _IdTanque = int.Parse(cbotanque_salida_reg.SelectedValue.ToString());
        int _IdTipoMovimiento = 2;
        float _valor = float.Parse(txtltsdespachados.Value.ToString());
        int _IdUsuarioActualizacion = DatosUsuario.Id_Usuario;
        DateTime _FechaMovimiento = DateTime.Parse(dtfechasurtido.DateInput.Text.Substring(0, 10));
        DateTime _HoraMovimiento = DateTime.Parse(dthorasurtido.SelectedDate.ToString());
        int _IdUnidad = int.Parse(cbounidad_red_salida.SelectedValue.ToString());
        int _IdOperador = int.Parse(cbooperadores_salida.SelectedValue.ToString());
        float _horimetro = float.Parse(txthorimetro.Value.ToString());
        float _odometro = float.Parse(txtodometro.Value.ToString());
        float _temperatura = float.Parse(txtTempSalida.Value.ToString());
        try
        {
            salida = agente.RegistraMovimientoOUT(_IdTanque, _IdTipoMovimiento, _valor, _IdUsuarioActualizacion, _FechaMovimiento, _HoraMovimiento, "", _IdUnidad, _IdOperador, _horimetro, _odometro, _temperatura);

            if (salida)
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
                cargagridsalidas();
                resetSalidas();
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

    public void resetSalidas()
    {
        EntradasRegistro.Visible = false;
        EntradasFiltro.Visible = true;

        txtCveSalida.Text = "";
        cboplanta_salida_reg.SelectedValue = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cbounidad_red_salida.SelectedValue = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cbooperadores_salida.SelectedValue = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        txtodometro.Text = "0";
        txthorimetro.Text = "0";
        txtltsdespachados.Text = "0";
        dtfechasurtido.SelectedDate = DateTime.Now;
        dthorasurtido.SelectedDate = DateTime.Now;
    }

    protected void btnRegresarSalida_Click(object sender, ImageClickEventArgs e)
    {
        EntradasRegistro.Visible = false;
        EntradasFiltro.Visible = true;
    }

    void cargagridsalidas()
    {
        agente = new AgenteUnidades();
        List<TanqueMovimiento> lista = new List<TanqueMovimiento>();
        DateTime _desde = DateTime.Parse(dtDesdeSalida.SelectedDate.ToString());
        DateTime _hasta = DateTime.Parse(dtHastaSalida.SelectedDate.ToString());
        int _tanque = int.Parse(cboTanqueFiltroSalida.SelectedValue);
        int _idmovimiento = 0;
        string _cveciduad = DatosUsuario.Ciudad;
        int _idunidad = int.Parse(cboUnidadSalidaFiltro.SelectedValue);
        int _idplanta = -1;
        lista = agente.BuscaSalidaEntradaCombustibles(_idmovimiento, _tanque, _desde, _hasta, _cveciduad, _idunidad, _idplanta);
        gridSalidas.DataSource = lista;
        gridSalidas.DataBind();
    }
    protected void btnbuscaout_Click(object sender, ImageClickEventArgs e)
    {
        cargagridsalidas();
    }
    protected void btnagregainout_Click(object sender, ImageClickEventArgs e)
    {
        EntradasRegistro.Visible = true;
        EntradasFiltro.Visible = false;
    }

    protected void gridEntradas_ItemCommand(object sender, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR:
                EdicionDatosEntrada(int.Parse(e.Item.Cells[2].Text));
                break;
        }
    }

    public void EdicionDatosEntrada(int idmovimiento)
    {
        List<TanqueMovimiento> lista = new List<TanqueMovimiento>();
        TanqueMovimiento elemento = new TanqueMovimiento();
        agente = new AgenteUnidades();
        int _idtanque = int.Parse(cbotanquein_sel.SelectedValue.ToString());
        string _ciudad = cbociudadin_sel.SelectedValue;
        DateTime _desde = DateTime.Now;
        DateTime _hasta = DateTime.Now;

        tblFiltrosEntrada.Visible = false;
        tblEntradaRegistro.Visible = true;

        ClaveEntrada.Visible = true;
        txtClaveEntrada.Visible = true;

        lista = agente.BuscaEntradaCombustibles(_idtanque, _desde, _hasta, _ciudad, idmovimiento);
        if (lista.Count > 0)
        {
            elemento = lista[0];
            cbotanquereg_in.SelectedValue = elemento.idtanque.ToString();
            dtregistroin.SelectedDate = elemento.FechaMovimiento;
            txtproveedor.Text = elemento.nombreproveedor;
            txtlitrosin.Text = elemento.valor.ToString();
            txtClaveEntrada.Text = elemento.IdMovimiento.ToString();
            txtReferencia.Text = elemento.referencia.ToString();
        }
    }
    protected void gridSalidas_ItemCommand(object sender, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case Concretec.Pedidos.Constantes.Etiquetas.TAG_EDITAR:
                EdicionDatosSalida(int.Parse(e.Item.Cells[2].Text));
                break;
        }
    }

    public void EdicionDatosSalida(int idmoviemiento)
    {
        resetSalidas();
        lblClaveSalida.Visible = true;
        txtCveSalida.Visible = true;

        EntradasRegistro.Visible = true;
        EntradasFiltro.Visible = false;

        agente = new AgenteUnidades();
        List<TanqueMovimiento> lista = new List<TanqueMovimiento>();
        DateTime _desde = DateTime.Now;
        DateTime _hasta = DateTime.Now;
        int _tanque = -1;
        int _idmovimiento = idmoviemiento;
        string _cveciduad = DatosUsuario.Ciudad;
        int _idunidad = -1;
        int _idplanta = -1;
        lista = agente.BuscaSalidaEntradaCombustibles(_idmovimiento, _tanque, _desde, _hasta, _cveciduad, _idunidad, _idplanta);

        if (lista.Count > 0)
        {
            txtCveSalida.Text = lista[0].IdMovimiento.ToString();
            cbooperadores_salida.SelectedValue = lista[0].idoperador.ToString();
            cbotanque_salida_reg.SelectedValue = lista[0].idtanque.ToString();
            txtodometro.Text = lista[0].odometro.ToString();
            txthorimetro.Text = lista[0].horimetro.ToString();
            txtltsdespachados.Text = lista[0].valor.ToString();
            dtfechasurtido.SelectedDate = lista[0].FechaMovimiento;
            dthorasurtido.SelectedDate = lista[0].FechaMovimiento;
            // Hay que revisar como llenar la planta ya que esta depende de la unidad 
        }


    }
    protected void cboCdConsumos_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    protected void btnBuscarConsumos_Click(object sender, ImageClickEventArgs e)
    {
        CargaGridConsumos();
    }

    public void CargaGridConsumos()
    {
        List<Tanque> lista = new List<Tanque>();
        agente = new AgenteUnidades();
        int _idtanque = int.Parse(cboTanqueConsumos.SelectedValue);
        DateTime _desde = DateTime.Parse(dtDesdeConsumos.SelectedDate.ToString());
        DateTime _hasta = DateTime.Parse(dtHastaConsumos.SelectedDate.ToString());
        lista = agente.BuscaConsumos(_idtanque, _desde, _hasta);
        gridConsumos.DataSource = lista;
        gridConsumos.DataBind();
    }
    protected void btnBuscarAjustes_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnAgregaAjuste_Click(object sender, ImageClickEventArgs e)
    {
        tblAjustesFiltro.Visible = false;
        tblAjustesRegistro.Visible = true;
    }
    protected void btnGrabarAjuste_Click(object sender, ImageClickEventArgs e)
    {
        agente = new AgenteUnidades();
        bool salida = false;
        int _idtanque = int.Parse(cboTanqueAjustesR.SelectedValue.ToString());
        int _idtipomovimiento = int.Parse(cboTipoMov.SelectedValue.ToString());
        float _lectura = float.Parse(txtvalorajuste.Value.ToString());
        DateTime _fmovimiento = DateTime.Parse(dtAjuste.SelectedDate.ToString());
        string _observaciones = txtObservaciones.Text;

        salida = agente.RegistraAjuste(_idtanque, _idtipomovimiento, _lectura, DatosUsuario.Id_Usuario, _fmovimiento, _observaciones);
        if (salida)
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
            resetPanelAjustes();
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
        }
    }

    public void resetPanelAjustes()
    {
        cboTanqueAjustesR.SelectedValue = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboTipoMov.SelectedValue = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        txtvalorajuste.Text = "0";
        dtAjuste.SelectedDate = DateTime.Now;
        txtObservaciones.Text = string.Empty;

        tblAjustesFiltro.Visible = true;
        tblAjustesRegistro.Visible = false;

        llenagridAjustes();
    }

    void llenagridAjustes()
    {
        List<Tanque> listaajustes = new List<Tanque>();
        agente = new AgenteUnidades();
        DateTime _desde = DateTime.Parse(dtDesdeAjuste.SelectedDate.ToString());
        DateTime _hasta = DateTime.Parse(dtHastaAjuste.SelectedDate.ToString());
        int _idtanque = int.Parse(cboTanqueAjustesFil.SelectedValue.ToString());

        listaajustes = agente.BuscaAjustes(_idtanque, _desde, _hasta);
        gridAjustes.DataSource = listaajustes;
        gridAjustes.DataBind();
    }

    protected void btnRegresarAjuste_Click(object sender, ImageClickEventArgs e)
    {
        resetPanelAjustes();
    }
    void llenagridResumen()
    {
        List<Tanque> lista = new List<Tanque>();
        gridResumen.DataSource = lista;
        gridResumen.DataBind();
    }

    protected void cboplantaE_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        agente = new AgenteUnidades();
        List<ConsultaUnidad> lista = new List<ConsultaUnidad>();

        lista = agente.ObtenerUnidadesFiltro("", cboplanta_salida_reg.SelectedValue.ToString(), DatosUsuario.Ciudad,1);
        cboUnidadE.Items.Clear();

        RadComboBoxItem item = new RadComboBoxItem();
        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboUnidadE.Items.Add(item);

        foreach (ConsultaUnidad a in lista)
        {
            item = new RadComboBoxItem();
            item.Text = a.IDClaveUnidad;
            item.Value = a.IDUnidad.ToString();
            this.cboUnidadE.Items.Add(item);
        }
    }

    protected void CboFormaCilindro_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (e.Value.ToString().ToUpper() == "E")
        {
            lbldiametro2.Visible = true;
            txtDiametro2_registro.Visible = true;
        }
        else
        {
            lbldiametro2.Visible = false;
            txtDiametro2_registro.Visible = false;
        }
    }
}