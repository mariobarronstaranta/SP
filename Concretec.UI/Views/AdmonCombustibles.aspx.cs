using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Telerik.Web.UI;
using Concretec.Pedidos.BE;
using Concretec.Agentes;
using System.Web.UI.WebControls;

public partial class Views_AdmonCombustibles : System.Web.UI.Page
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

    AgenteCombustibles agenteC = new AgenteCombustibles();
    AgenteUnidades agente = new AgenteUnidades();
    #endregion
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
                tblSalidas.Visible = false;
                tblEntradas.Visible = false;
                tblAjustes.Visible = false;
                CargaCiudades();

                dtfechalecturar.SelectedDate    = DateTime.Now;
                drLecturaHora.SelectedDate      = DateTime.Now;

                llenarObservaciones_Salida();
                llenarObservaciones_Entrada();

                ErroresEntrada.Text = string.Empty;
                ErroresSalidas.Text = string.Empty;

                btngrabarin.Visible = true;
            }
        }
    }

    protected void CboTipoMovimiento_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (CboTipoMovimiento.SelectedValue == "-1")
        {
            tblSalidas.Visible = false;
            tblEntradas.Visible = false;
            tblAjustes.Visible = false;
        }

        if (CboTipoMovimiento.SelectedValue == "1")
        {
            tblSalidas.Visible = false;
            tblEntradas.Visible = true;
            tblAjustes.Visible = false;

            llenarObservaciones_Salida();
        }

        if (CboTipoMovimiento.SelectedValue == "2")
        {
            tblSalidas.Visible = true;
            tblEntradas.Visible = false;
            tblAjustes.Visible = false;


            llenarObservaciones_Salida();
        }

        if (CboTipoMovimiento.SelectedValue == "3")
        {
            tblSalidas.Visible = false;
            tblEntradas.Visible = false;
            tblAjustes.Visible = true;


            llenarObservaciones_Salida();
        }
    }

    private void CargaTanquesLecturas(int plantaid)
    {
        agente = new AgenteUnidades();
        List<Tanque> _planta = new List<Tanque>();
        _planta = agente.BuscaTanquesCombo(plantaid);
        CboTanque.Items.Clear();

        RadComboBoxItem item = new RadComboBoxItem();
        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.CboTanque.Items.Add(item);

        foreach (Tanque a in _planta)
        {
            item = new RadComboBoxItem();
            item.Text = a.Nombre;
            item.Value = a.IdTanque.ToString();
            this.CboTanque.Items.Add(item);
        }
    }

    private void CargaPlantas(string ciudadregistro)
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> _planta = new List<Planta>();
        _planta = au.ObtenerPlantasObra(ciudadregistro);

        CboPlanta.Items.Clear();
        CboPlantaUnidad.Items.Clear();

        RadComboBoxItem item = new RadComboBoxItem();
        RadComboBoxItem item_planta = new RadComboBoxItem();

        item = new RadComboBoxItem();
        item_planta = new RadComboBoxItem();

        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;

        item_planta.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item_planta.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;

        this.CboPlanta.Items.Add(item);
        this.CboPlantaUnidad.Items.Add(item_planta);

        foreach (Planta a in _planta)
        {
            item = new RadComboBoxItem();
            item_planta = new RadComboBoxItem();

            item.Text = a.Nombre;
            item_planta.Text = a.Nombre;

            item.Value = a.IDPlanta.ToString();
            item_planta.Value = a.IDPlanta.ToString();

            this.CboPlanta.Items.Add(item);
            this.CboPlantaUnidad.Items.Add(item_planta);
        }
    }

    private void CargaCiudades()
    {
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();
        CboCiudad.Items.Clear();


        RadComboBoxItem item = new RadComboBoxItem();

        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        CboCiudad.Items.Add(item);


        lc = ac.ObtenerCiudades();
        foreach (Ciudad c in lc)
        {
            item = new RadComboBoxItem();
            item.Text = c.Descripcion;
            item.Value = c.CveCiudad;
            CboCiudad.Items.Add(item);

        }

    }



    protected void CboCiudad_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        string ciudadregistro = string.Empty;
        ciudadregistro = CboCiudad.SelectedValue;
        CargaPlantas(ciudadregistro);
        
    }

    protected void CboPlanta_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        int plantaid = int.Parse(CboPlanta.SelectedValue);
        CargaTanquesLecturas(plantaid);
    }

    protected void CboTanque_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        AgenteCombustibles agente = new AgenteCombustibles();
        List<Tanque> lista = new List<Tanque>();
        int tanqueid = int.Parse(CboTanque.SelectedValue);
        lista = agente.BuscaInfoTanque(tanqueid);
        Tanque elemento = new Tanque();

        if (lista != null && lista.Count > 0)
        {
            elemento = lista[0];

            txtInvActualCms.Text    = elemento.LecturaCms.ToString();
            txtInvActual.Text       = elemento.VolActualTA.ToString();
            txtInv15Grados.Text     = elemento.VolActual15C.ToString();
            txtTemperauraUltimaCarga.Text = elemento.Temperatura.ToString();
        }
    }

    protected void btngrabarin_Click(object sender, ImageClickEventArgs e)
    {
        ErroresEntrada.Text = string.Empty;
        agenteC         = new AgenteCombustibles();
        Tanque entidad  = new Tanque();
        bool resultado  = false;

        entidad.IdTanque            = int.Parse(CboTanque.SelectedValue.ToString());
        entidad.TipoMovimientoId    = int.Parse(CboTipoMovimiento.SelectedValue.ToString());
        entidad.InvActualCms        = double.Parse(txtInvActualCms.Text);
        entidad.FechaMovimiento     = DateTime.Parse(dtfechalecturar.DateInput.Text.Substring(0, 10));
        entidad.HoraMovimiento      = DateTime.Parse(drLecturaHora.SelectedDate.ToString());
        entidad.TempActual          = double.Parse(txtTemperatura.Text.ToString());
        entidad.InvActualLts        = double.Parse(txtInvActual.Text.ToString());
        entidad.InvActual15CLts     = double.Parse(txtInv15Grados.Text.ToString());
        entidad.UsuarioIdRegistro   = DatosUsuario.Id_Usuario;

        //Seccion de los datos
        entidad.ProveedorId         = int.Parse(cboProveedor_Entrada.SelectedValue);
        entidad.Remision            = txtRemision_Entrada.Text;
        entidad.LtsTempAmbiente     = double.Parse(txtLitros_Entrada.Text);
        entidad.NInvExistente15C    = double.Parse(txtInvN15C_Entrada.Text);
        entidad.NInvTAmbiente       = double.Parse(txtInvNAmbiente_Entrada.Text);
        entidad.NInvCms             = double.Parse(txtInvNuevoCms_Entrada.Text);
        entidad.ObservacionesIn     = CboObservaciones_Entradas.SelectedValue;

        resultado                   = agenteC.RegistraEntradaCombustible(entidad);
        try
        {
            if (resultado)
            {
                LimpiaCamposEntradas();
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
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

    void LimpiaCamposEntradas()
    {
        CboTipoMovimiento.SelectedValue     = "-1";
        CboCiudad.SelectedValue             = "-1";
        
        txtInvActualCms.Text                = string.Empty;
        txtTemperatura.Text                 = string.Empty;
        txtInvActual.Text                   = string.Empty;
        txtInv15Grados.Text                 = string.Empty;

        dtfechalecturar.SelectedDate        = DateTime.Now;
        drLecturaHora.SelectedDate          = DateTime.Now;

        cboProveedor_Entrada.SelectedValue  = "-1";
        txtRemision_Entrada.Text            = string.Empty;
        txtLitros_Entrada.Text              = string.Empty;
        txtInvN15C_Entrada.Text             = string.Empty;
        txtInvNAmbiente_Entrada.Text        = string.Empty;
        txtInvNuevoCms_Entrada.Text         = string.Empty;

        tblSalidas.Visible                  = false;
        tblEntradas.Visible                 = false;
        tblAjustes.Visible                  = false;

        CboObservaciones_Entradas.SelectedValue = "-1";
        btngrabarin.Visible = false;
    }

    string ValidaValoresEntrada()
    {
        string mensaje = string.Empty;
        if (CboCiudad.SelectedValue == "-1")
        {
            mensaje += "Seleccione una ciudad , ";
        }

        if (CboPlanta.SelectedValue == "-1")
        {
            mensaje += "Seleccione una Planta , ";
        }

        if (CboTanque.SelectedValue == "-1")
        {
            mensaje += "Seleccione un Tanque , ";
        }

        if (txtTemperatura.Text.Trim().Length == 0)
        {
            mensaje += "Capture Temp. Actual , ";
        }

        if (cboProveedor_Entrada.SelectedValue == "-1")
        {
            mensaje += "Seleccione un Proveedor , ";
        }

        if (txtRemision_Entrada.Text.Trim().Length == 0)
        {
            mensaje += "Capture la remision , ";
        }

        //Aqui hay que validar que el numero de remision no se encuentre duplicado
        List<Tanque> RemisionesTanque = new List<Tanque>();
        AgenteCombustibles _agente = new AgenteCombustibles();
        RemisionesTanque = _agente.Busca_Remision_Tanque(txtRemision_Entrada.Text.Trim());

        if (RemisionesTanque != null && RemisionesTanque.Count > 0)
        {
            mensaje += "La remision " + txtRemision_Entrada.Text.Trim() + " ya se encuentra registrada, ";
        }

        if (txtLitros_Entrada.Text.Trim().Length == 0)
        {
            mensaje += "Capture los litros a Cargar.";
        }

        return mensaje;
    }

    void CalculoValores()
    {
        List<Tanque> valores = new List<Tanque>();

        Tanque valor = new Tanque();
        Tanque valor_vol_ajuste = new Tanque();
        AgenteCombustibles agente = new AgenteCombustibles();

        int tanqueid = int.Parse(CboTanque.SelectedValue);

        float temperatura = float.Parse(txtTemperatura.Text);
        float volumen_ajustado = 0;
        // Nueva forma de calcular el total
        //1- El nuevo inventario a temperatura ambiente (Inv. Nuevo Temp Ambiente) es la suma directa de los litros cargados + inventario actual
        txtInvNAmbiente_Entrada.Text = (int.Parse(txtInvActual.Text) + int.Parse(txtLitros_Entrada.Text)).ToString();

        //2- Para el inventario a Temp 15C , hay que convertir los litros cargados a temperatura estandard y colocarlos en el campo "Carga Lts Temp. 15C"
        List<Tanque> valores_vol_ajuste = new List<Tanque>();
        valores_vol_ajuste = agente.Busca_Volumen_Temperatura(tanqueid, temperatura, float.Parse(txtLitros_Entrada.Text));
        if (valores_vol_ajuste != null && valores_vol_ajuste.Count > 0)
        {
            valor = valores_vol_ajuste[0];
            volumen_ajustado = valor.VolumenAjustado;
        }
        txtLitros_15C_Entrada.Text = volumen_ajustado.ToString();
        txtInvN15C_Entrada.Text = (float.Parse(txtLitros_15C_Entrada.Text) + float.Parse(txtInv15Grados.Text)).ToString();

        //3-La altura hay que calcularla en base al total de litros a temp 15C convertida a temp Actual
        agente = new AgenteCombustibles();
        valores = agente.Busca_Altura_Volumen_Tanque(int.Parse(temperatura.ToString()), float.Parse(txtInvN15C_Entrada.Text), tanqueid);

        if (valores != null && valores.Count > 0)
        {
            valor_vol_ajuste = valores[0];
            txtInvNuevoCms_Entrada.Text = valor_vol_ajuste.Altura.ToString();
        }

        
    }

    protected void btnCalcularIn_Click(object sender, ImageClickEventArgs e)
    {
        ErroresEntrada.Text             = string.Empty;
        List<Tanque> BuscaInfoTanque    = new List<Tanque>();
        AgenteCombustibles _agente      = new AgenteCombustibles();
        Tanque InfoTanque               = new Tanque();
        float capacidad                 = 0;

        if (ValidaValoresEntrada().Length == 0)
        {
            CalculoValores();
            int tanqueid = int.Parse(CboTanque.SelectedValue);
            BuscaInfoTanque = _agente.BuscaInfoTanque(tanqueid);
            btngrabarin.Visible = true;

            if (BuscaInfoTanque != null && BuscaInfoTanque.Count > 0)
            {
                InfoTanque = BuscaInfoTanque[0];
                capacidad = float.Parse(InfoTanque.capacidad);

                if (capacidad < float.Parse(txtLitros_15C_Entrada.Text))
                {
                    ErroresEntrada.Text += " La capacidad de almacenamiento del taque ha sido excedida ";
                    btngrabarin.Visible = false;
                }

            }

        }
        else
        {
            ErroresEntrada.Text = ValidaValoresEntrada();
            btngrabarin.Visible = false;
        }



    }

    private void cargaunidad(int planta_unidad_id)
    {
        AgenteUnidades au = new AgenteUnidades();
        List<ConsultaUnidad> lu = new List<ConsultaUnidad>();
        this.CboUnidad_Salida.Items.Clear();
        lu = au.ObtieneUnidad();

        RadComboBoxItem item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.CboUnidad_Salida.Items.Add(item);

        var camiones = from camion in lu
                       where (camion.IDClaveUnidad.Contains("CR") || camion.IDClaveUnidad.Contains("BP")) && camion.IdPlanta == planta_unidad_id && camion.Estatus == "ACTIVO"
                       select new { camion.IDUnidad, camion.IDClaveUnidad };

        foreach (var u in camiones)
        {
            item = new RadComboBoxItem();
            item.Text = u.IDClaveUnidad;
            item.Value = u.IDUnidad.ToString();
            this.CboUnidad_Salida.Items.Add(item);
        }
    }

    #region Operadores
    public void llenaOperadores()
    {
        AgentePersonal ap = new AgentePersonal();
        List<Personal> lista = new List<Personal>();
        lista = ap.ObtenerChoferUnidad(-1, DatosUsuario.Ciudad);

        RadComboBoxItem item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.CboOperador_Salida.Items.Add(item);


        var operadores = from oo in lista
                         where oo.Estatus == "Alta"
                         select new { oo.IDPersonal, oo.Nombre , oo.APaterno };




        foreach (var chofer in operadores)
        {
            item = new RadComboBoxItem();
            item.Text = chofer.Nombre + " " + chofer.APaterno;
            item.Value = chofer.IDPersonal.ToString();
            this.CboOperador_Salida.Items.Add(item);
        }

    }

    #endregion

    protected void CboUnidad_Salida_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        llenaOperadores();
    }

    string ValidaValoresSalida()
    {
        string mensaje = string.Empty;
        if (CboCiudad.SelectedValue == "-1")
        {
            mensaje += "Seleccione una ciudad , ";
        }

        if (CboPlanta.SelectedValue == "-1")
        {
            mensaje += "Seleccione una Planta , ";
        }

        if (CboTanque.SelectedValue == "-1")
        {
            mensaje += "Seleccione un Tanque , ";
        }

        if (txtTemperatura.Text.Trim().Length == 0)
        {
            mensaje += "Capture Temp. Actual , ";
        }

        if (CboPlantaUnidad.SelectedValue == "-1")
        {
            mensaje += "Seleccione una Planta para la unidad , ";
        }

        if (CboUnidad_Salida.SelectedValue == "-1")
        {
            mensaje += "Seleccione una unidad , ";
        }

        if (CboOperador_Salida.SelectedValue == "-1")
        {
            mensaje += "Seleccione un Operador , ";
        }

        if (txtFolioVale_Salida.Text.Trim().Length == 0)
        {
            mensaje += "Capture El Folio Vale , ";
        }

        if (txtFolioVale_Salida.Text.Trim().Length == 0)
        {
            mensaje += "Capture El Consecutivo Bomba , ";
        }

        if (txtLitros_Salida.Text.Trim().Length == 0)
        {
            mensaje += "Capture los litros despachados , ";
        }

        if (txtOdometroActual_Salida.Text.Trim().Length == 0)
        {
            mensaje += "Capture el valor del Odometro , ";
        }

        if (txtHorometroActual_Salida.Text.Trim().Length == 0)
        {
            mensaje += "Capture el valor del Horometro , ";
        }

        return mensaje;
    }

    protected void btnCalcular_Salidas_Click(object sender, ImageClickEventArgs e)
    {
        Tanque valores                      = new Tanque();
        List<Tanque> valores_vol_ajuste     = new List<Tanque>();
        Tanque valor                        = new Tanque();
        Tanque valor_vol_ajuste             = new Tanque();
        AgenteCombustibles agente           = new AgenteCombustibles();


        if (ValidaValoresSalida().Length == 0)
        {
            int IdTanque = int.Parse(CboTanque.SelectedValue.ToString());
            float TempActual = float.Parse(txtTemperatura.Text.ToString());
            float InventarioActual_Salidas = float.Parse(txtInvActual.Text) - float.Parse(txtLitros_Salida.Text);

            List<Tanque> valores_vol = new List<Tanque>();
            float Litros_Salida_15C = 0;
            valores_vol = agente.Busca_Volumen_Temperatura(IdTanque, TempActual, float.Parse(txtLitros_Salida.Text));
            if (valores_vol != null && valores_vol.Count > 0)
            {
                Litros_Salida_15C = valores_vol[0].VolumenAjustado;
                txtLitros_15C_Salida.Text = Litros_Salida_15C.ToString();
                txtInventario15C_Salida.Text = (float.Parse(txtInv15Grados.Text) - float.Parse(txtLitros_15C_Salida.Text)).ToString();
            }


            txtInventarioTA_Salida.Text = InventarioActual_Salidas.ToString();

            //3-La altura hay que calcularla en base al total de litros a temp 15C convertida a temp Actual
            agente = new AgenteCombustibles();
            List<Tanque> ValoresAlturaSalida = new List<Tanque>();
            ValoresAlturaSalida = agente.Busca_Altura_Volumen_Tanque(int.Parse(TempActual.ToString()), float.Parse(txtInventario15C_Salida.Text), IdTanque);

            if (ValoresAlturaSalida != null && ValoresAlturaSalida.Count > 0)
            {
                txtInvNuevoCms_Salida.Text = ValoresAlturaSalida[0].Altura.ToString();
            }


            int idunidad = int.Parse(CboUnidad_Salida.SelectedValue);
            float horimetro = float.Parse(txtHorometroActual_Salida.Text);
            float odometro = float.Parse(txtOdometroActual_Salida.Text);
            //Valores de calculo de Odometro y horimetro
            valores = agente.ValoresCalculoSalida(idunidad, odometro, horimetro);

            txtDistanciaOdometro_Salida.Text = valores.DistRecorridaOdometro.ToString();
            txtTiempoTrabajado_Salida.Text = valores.TiempoTrabajado.ToString();
            dtCargaAnterior_Salida.SelectedDate = valores.UltimaFechaCarga;

            btngrabar_salidas.Visible = true;
        }
        else
        {
            ErroresSalidas.Text = ValidaValoresSalida();
        }
        
    }

    protected void btngrabar_salidas_Click(object sender, ImageClickEventArgs e)
    {
        ErroresSalidas.Text = string.Empty;

        agenteC = new AgenteCombustibles();
        Tanque entidad = new Tanque();
        bool resultado = false;

        entidad.IdTanque            = int.Parse(CboTanque.SelectedValue.ToString());
        entidad.TipoMovimientoId    = int.Parse(CboTipoMovimiento.SelectedValue.ToString());
        entidad.InvActualCms        = double.Parse(txtInvActualCms.Text);
        entidad.FechaMovimiento     = DateTime.Parse(dtfechalecturar.DateInput.Text.Substring(0, 10));
        entidad.HoraMovimiento      = DateTime.Parse(drLecturaHora.SelectedDate.ToString());
        entidad.TempActual          = double.Parse(txtTemperatura.Text.ToString());
        entidad.InvActualLts        = double.Parse(txtInvActual.Text.ToString());
        entidad.InvActual15CLts     = double.Parse(txtInv15Grados.Text.ToString());
        entidad.UsuarioIdRegistro   = DatosUsuario.Id_Usuario;

        //Seccion de los datos
        entidad.PlantaId_Unidad     = int.Parse(CboPlantaUnidad.SelectedValue);
        entidad.IdUnidad            = int.Parse(CboUnidad_Salida.SelectedValue);
        entidad.OperadorId          = int.Parse(CboOperador_Salida.SelectedValue);
        entidad.FolioVale           = txtFolioVale_Salida.Text;
        entidad.ConsecutivoBomba    = txtConsBomba_Salida.Text;
        entidad.litrosCargados      = float.Parse(txtLitros_Salida.Text);
        entidad.odometro_actual     = float.Parse(txtOdometroActual_Salida.Text);
        entidad.horimetro_actual    = float.Parse(txtHorometroActual_Salida.Text);
        //Inventario Nuevo Temperatura Actual
        entidad.NInvTAmbiente       = double.Parse(txtInventarioTA_Salida.Text);
        //Inventario Nuevo 15C
        entidad.NInvExistente15C    = double.Parse(txtInventario15C_Salida.Text);
        //Inventario Nuevo CMS
        entidad.NInvCms             = double.Parse(txtInvNuevoCms_Salida.Text); ;
        //ObservacionesId
        entidad.ObservacionesIdOut  = int.Parse(CboObservaciones_Salida.SelectedValue);

        resultado = agenteC.RegistraSalidaCombustible(entidad);
        try
        {
            if (resultado)
            {
                LimpiaCamposEntradas();
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
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

    void llenarObservaciones_Entrada()
    {
        AgentePedidos ap = new AgentePedidos();
        List<Contingencia> listaObservaciones = ap.LeerContingencias(-1, string.Empty, 1, 13);

        //===================================================================================================


        CboObservaciones_Salida.Items.Clear();

        RadComboBoxItem item = new RadComboBoxItem();
        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.CboObservaciones_Entradas.Items.Add(item);

        foreach (Contingencia a in listaObservaciones)
        {
            item = new RadComboBoxItem();
            item.Text = a.Descripcion;
            item.Value = a.idContingencia.ToString();
            this.CboObservaciones_Entradas.Items.Add(item);
        }
    }

    void llenarObservaciones_Salida()
    {
        AgentePedidos ap = new AgentePedidos();
        List<Contingencia> listaObservaciones = ap.LeerContingencias(-1, string.Empty, 1, 12);

        //===================================================================================================


        CboObservaciones_Salida.Items.Clear();

        RadComboBoxItem item = new RadComboBoxItem();
        item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.CboObservaciones_Salida.Items.Add(item);

        foreach (Contingencia a in listaObservaciones)
        {
            item = new RadComboBoxItem();
            item.Text = a.Descripcion;
            item.Value = a.idContingencia.ToString();
            this.CboObservaciones_Salida.Items.Add(item);
        }

    }

    protected void CboPlantaUnidad_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

        int planta_unidad_id = int.Parse(CboPlantaUnidad.SelectedValue);
        cargaunidad(planta_unidad_id);
    }
}