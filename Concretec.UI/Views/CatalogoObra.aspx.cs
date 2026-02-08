using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_CatalogoObra : System.Web.UI.Page
{
    public int IDObra
    {
        get
        {
            int _idobra = 0;
            if (Request.QueryString["IDObra"] != null)
            {
                _idobra = int.Parse(Request.QueryString["IDObra"].ToString());
            }
        return _idobra;
        }
    }

    public int vendedor
    { get { return int.Parse(cboVendedor.SelectedValue.ToString()); } }

    public int cliente
    { get { return int.Parse(cboCliente.SelectedValue.ToString()); } }

    public string ciudad
    { get { return cboCiudad.SelectedValue.ToString(); } }
    
    public int ciclo
    { get { return int.Parse(cboCiclo.SelectedValue.ToString()); } }

    public string planta
    { get { return cboPlanta.SelectedValue.ToString();} }

    public string Altitud
    { get { return txtAltitud.Text.ToString(); } }

    public string Latitud
    { get { return txtlatitud.Text.ToString(); } }

    public string codigopostal
    { get { return txtCP.Text.ToString(); } }
        
    public string poblacion
    { get { return txtPoblacion.Text.ToString(); } }
    
    public float? distancia
    { 
        get { 
        float? salida = null;
        if (txtDistancia.Text !="") {salida=float.Parse(txtDistancia.Text);}
        return salida; 
        
    } }
    
    public string telefono
    { get { return txtTelefono.Text.ToString(); } }
    
    public string direccion
    { get { return txtDireccion.Text.ToString(); } }

    public string rfc
    { get { return txtRFC.Text.ToString(); } }

    public string nombreobra
    { get { return txtNombre.Text.ToString(); } }

    public string colonia
    { get { return this.txtColonia.Text.ToString(); } }

    public string claveobra
    { get { return txtClave.Text.ToString(); } }
    
    public float? volesperado
    { get { 
        float? salida = null;
        if (txtVolE.Text !="") {salida=float.Parse(txtVolE.Text);}
        return salida; 
        
    } }

    public float? volacumulado
    { get { 
        float? salida = null;
        if (txtVolA.Text !="") {salida=float.Parse(txtVolA.Text);}
        return salida; 
        
    } }

    public string atencion
    { get { return txtAtencion.Text; } }

    public string  responsable
    { get { return txtResponsable.Text.ToString(); } }

   public string URLMaps
   { get { return this.txtUrlMaps.Text.ToString(); } }

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
        if (DatosUsuario.Ciudad == "")
        {Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);}

        if (IsPostBack != true)
        {
            this.txtCP.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
            this.txtVolE.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
            this.txtVolA.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
            this.txtDistancia.Attributes.Add("OnKeyPress", "return AcceptNum(event)");

            this.txtClave.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
            CargaCiudades();
            CargaClientes();
            CargaPlantas();
            cboCiudad.SelectedValue = DatosUsuario.Ciudad;
            CargaDatosEdicion();
            CargaVendedores(DatosUsuario.Ciudad);
        }
    }

    Obra DatosEdicion(int CveObra)
    {
        AgenteObras Agente = new AgenteObras();
        Obra Dato = Agente.BuscarObra(CveObra, DatosUsuario.Ciudad);
        return Dato;
    }

    void llenaCamposEdicion(Obra DatosObra)
    {
        CargaVendedores(DatosUsuario.Ciudad);
        txtClave.Text               = DatosObra.ClaveObra;
        txtNombre.Text              = DatosObra.Nombre;
        cboCliente.SelectedValue    = DatosObra.ClaveCliente;
        txtRFC.Text                 = DatosObra.RFC;
        txtColonia.Text             = DatosObra.Colonia;
        txtDireccion.Text           = DatosObra.Direccion;
        txtCP.Text                  = DatosObra.CP;
        txtPoblacion.Text           = DatosObra.Poblacion;
        cboCiudad.SelectedValue     = DatosObra.CveCiudad;
        txtTelefono.Text            = DatosObra.Telefonos;
        cboPlanta.SelectedValue     = DatosObra.Planta;
        cboVendedor.SelectedValue   = DatosObra.Vendedor.ToString();
        txtDistancia.Text           = DatosObra.Distancia.ToString();
        txtAltitud.Text             = DatosObra.Roji;
        cboCiclo.SelectedValue      = DatosObra.TiempoCiclo;
        if (DatosObra.VolumenEstimado != null)
        { txtVolE.Text = DatosObra.VolumenEstimado.ToString(); }

        if (DatosObra.VolumenAcumulado != null)
        { txtVolA.Text = DatosObra.VolumenAcumulado.ToString();}
        
        txtAtencion.Text            = DatosObra.Atencion;
        txtResponsable.Text         = DatosObra.Responsable;
        cboestatus.SelectedValue    = DatosObra.Estatus.GetHashCode().ToString();

        txtentrecalles.Text         = DatosObra.EntreCalles;
        txtAltitud.Text             = DatosObra.Altitud;
        txtlatitud.Text             = DatosObra.Latitud;

        txtUrlMaps.Text             = DatosObra.URLMaps;
        txtCiudadObra.Text          = DatosObra.MunicipioSEPOMEX;

        imgGuardar.ImageUrl = "~/Imagenes/Actualizar.png";
    }

    private void CargaDatosEdicion()
    {
        int resultado;
        string CvePedido = "";
        if (Request.QueryString["IDObra"] != null)
        {
            CvePedido = Request.QueryString["IDObra"].ToString();
        }
        bool ExisteEdicion = Int32.TryParse(CvePedido, out resultado);
        Obra ObraEdicion = new Obra();
        if (ExisteEdicion)
        {
            ObraEdicion = DatosEdicion(resultado);
            llenaCamposEdicion(ObraEdicion);
        }
    }

    private void CargaPlantas()
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> _planta = new List<Planta>();
        _planta = au.ObtenerPlantasObra(DatosUsuario.Ciudad);

        ListItem item = new ListItem();
        item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboPlanta.Items.Add(item);

        foreach (Planta a in _planta)
        {
            item = new ListItem();
            item.Text = a.CvePlanta;
            item.Value = a.Nombre;
            this.cboPlanta.Items.Add(item);
        }
    }

    private void CargaVendedores(string ciudad)
    {
        AgentePersonal ap = new AgentePersonal();
        List<Personal> vendedores = new List<Personal>();
        vendedores = ap.ObtenerPersonal("VE", ciudad);

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboVendedor.Items.Add(item);

        foreach (Personal v in vendedores)
        {
            item = new ListItem();
            item.Text = v.Nombre + " - " + v.AMaterno;
            item.Value = v.IDPersonal.ToString();
            this.cboVendedor.Items.Add(item);

        }

    }

    private void CargaClientes()
    {
        AgenteClientes au = new AgenteClientes();
        List<Cliente> cliente_ = new List<Cliente>();
        cliente_ = au.ObtenerClientes(DatosUsuario.Ciudad);
        cboCliente.Items.Clear();

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboCliente.Items.Add(item);

        foreach (Cliente a in cliente_)
        {
            item = new ListItem();
            item.Text = a.NombreCompleto;
            item.Value = a.ClaveCliente;
            this.cboCliente.Items.Add(item);

        }

    }

    private void CargaCiudades()
    {
        cboCiudad.Items.Clear();
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();

        lc = ac.ObtenerCiudades();
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cboCiudad.Items.Add(item);
        foreach (Ciudad c in lc)
        {
            item = new ListItem();
            item.Text = c.Descripcion;
            item.Value = c.CveCiudad.ToString();
            cboCiudad.Items.Add(item);
        }

    }

    protected void imgCancelar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListaObras.aspx");
    }

    void LimpiaDatos()
    { 
        txtNombre.Text = "";
        txtRFC.Text = "";
        txtDireccion.Text = "";
        txtColonia.Text = "";
        txtCP.Text = "";
        txtPoblacion.Text = "";
        txtTelefono.Text = "";
    }

    protected void imgLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        LimpiaDatos();
    }

    bool ActualizarObra()
    {
        AgenteObras Agente = new AgenteObras();
        bool Resultado = false;
        bool _estatus = false;
        if (cboestatus.SelectedValue.ToString() == "1")
        { _estatus = true; }
        Resultado = Agente.ActualizarObra(
            IDObra,
            claveobra,
            direccion,
            nombreobra,
            telefono,
            responsable,
            txtentrecalles.Text,
            _estatus,
            vendedor,
            rfc,
            poblacion,
            codigopostal,
            atencion, "",
            planta.ToString(),
            cboCliente.SelectedValue,
            distancia,
            ciclo,
            volesperado,
            volacumulado,
            ciudad,
            colonia,
            Altitud,
            Latitud,
            URLMaps,
            txtCiudadObra.Text.ToString());
        return Resultado;
    }

    bool InsertarObra()
    {
        AgenteObras Agente = new AgenteObras();
        bool Resultado = false;
        bool _estatus = false;
        if (cboestatus.SelectedValue.ToString() == "1")
        { _estatus = true; }
        Resultado = Agente.InsertarObra(
            claveobra,
            direccion,
            nombreobra,
            telefono,
            responsable,
            Altitud, 
            Latitud,
            txtentrecalles.Text,
            _estatus,
            vendedor,
            rfc,
            poblacion,
            codigopostal,
            atencion, "",
            planta.ToString(),
            cboCliente.SelectedValue,
            distancia,
            ciclo,
            volesperado,
            volacumulado,
            ciudad,colonia,URLMaps,txtCiudadObra.Text.ToString());
        return Resultado;
    }

    //public bool ValidaCP(string)

    protected void imgGuardar_Click(object sender, ImageClickEventArgs e)
    {
        string accion = "";
        bool Resultado = false;

        if (codigopostal.Trim().Length == 0)
        {
            Alert.Show("El Campo Codigo Postal es Obligatorio");
        }
        else
        {
            if (codigopostal.Trim().Length < 5)
            {
                Alert.Show("La longitud del CP son 5 numeros");
            }
            else
            {
                if (IDObra > 0)
                                    {
                                        Resultado = ActualizarObra();
                                        accion = Concretec.Pedidos.Constantes.Etiquetas.TAG_ACTUALIZADO;
                                    }
                                    else
                                    {  Resultado = InsertarObra();
                                    accion = Concretec.Pedidos.Constantes.Etiquetas.TAG_INSERTADO;
                                    }
        
                                    if (Resultado == true)
                                    {
                                        Alert.Show(Concretec.Pedidos.Constantes.Mensajes.LA_OBRA + " se ha " + accion + Concretec.Pedidos.Constantes.Mensajes.EXITOSAMENTE);
                                        Response.Redirect("ListaObras.aspx");
                                    }
                                    else
                                    {
                                        Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
                                    }
            }

                
        }

        
    }
    protected void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        AgenteObras _agente = new AgenteObras();
        string numObra = _agente.ObtenerNumeroObra(cliente, DatosUsuario.Ciudad);
        txtClave.Text = numObra;

        if (chkDatos.Checked)
        {
            ClonaDatosCliente();
        }
    }

    public void ClonaDatosCliente()
    {
        AgenteClientes _agente = new AgenteClientes();
        Cliente entidad = new Cliente();

        if (cliente != -1)
        {
            entidad = _agente.BuscarClienteCve(cliente.ToString(), DatosUsuario.Ciudad);

            // Buscar los datos del cliente
            txtNombre.Text = entidad.NombreCompleto;
            txtRFC.Text = entidad.RFC;
            txtDireccion.Text = entidad.Direccion;
            txtColonia.Text = entidad.Colonia;
            txtCP.Text = entidad.CP;
            txtPoblacion.Text = entidad.Poblacion;
            txtTelefono.Text = entidad.Poblacion;
        }
        else
        {
            LimpiaDatos();
        }

    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (chkDatos.Checked)
        {
            ClonaDatosCliente();
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string url = txtUrlMaps.Text;
        Response.Write("<script>window.open('" + url + "','_blank');</script>"); 

    }

    protected void cmdValidaCP_Click(object sender, EventArgs e)
    {
        if (txtCP.Text.Length == 0)
        {
            Alert.Show("El CP debe contener informacion");
        }
        else
        {
            if (txtCP.Text.Length != 5)
            {
                Alert.Show("La longitud del CP son 5 numeros favor de capturar");
            }
            else
            {
                List<Sepomex> resultado = new List<Sepomex>();
                Sepomex elemento = new Sepomex();
                AgenteObras AO = new AgenteObras();
                resultado = AO.BUSCAINFO_CP(txtCP.Text.ToString());

                if (resultado != null)
                {
                    elemento = resultado[0];
                    txtCiudadObra.Text = elemento.Municipio.ToString();
                }
                else
                {
                    Alert.Show("El CP no existe en la Base de Datos , reportarlo a su administrador de sistemas");
                }
            }
        }
    }
}