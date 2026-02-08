using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_CatalogoPersonal : System.Web.UI.Page
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

    public string ciudad
    { get { return this.cbociudad.SelectedValue.ToString(); } }

    public string ClaveEmpleado
    { get { return txtclave.Text.ToString();} }

    public string idpersonal
    {
        get
        {
            string salida = string.Empty;
            if (Request.QueryString["idpersonal"] != null)
            {
                salida = Request.QueryString["idpersonal"].ToString();
            }
            else
            {
                salida = txtID.Text.ToString();
            }
            return salida;
        }
    }

    public string Nombre
    { get { return txtnombre.Text.ToString(); } }

    public string APaterno
    { get { return txtapaterno.Text.ToString(); } }

    public string AMaterno
    { get { return txtamaterno.Text.ToString(); } }

    public string Estatus
    { get { return cboEstatus.SelectedValue.ToString(); } }

    public string Puesto
    { get { return cbopuesto.SelectedValue.ToString(); } }

    public int IDPlanta
    { get { return int.Parse(cboplanta.SelectedValue.ToString()); } }

    public string TipoPersonal
    { get { return cbotipopersonal.SelectedValue.ToString(); } }

    public string Tipo
    { get { return cbotipo.SelectedValue.ToString(); } }


    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
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
                CargaCiudades();
                CargaPlantas();
                if (idpersonal.ToString() != string.Empty)
                {
                    CargaDatosEdicion();
                }

            }
        }
        //********************************************************
    }

    private void CargaDatosEdicion()
    {
        AgentePersonal agente = new AgentePersonal();
        Personal empleado = new Personal();
        empleado = agente.BuscarEmpleado(idpersonal);

        txtID.Text                  = empleado.IDPersonal.ToString();
        txtamaterno.Text            = empleado.AMaterno;
        txtapaterno.Text            = empleado.APaterno;
        txtclave.Text               = empleado.ClavePersonal;
        txtnombre.Text              = empleado.Nombre;
        cbociudad.SelectedValue     = empleado.CveCiudad;
        cboEstatus.SelectedValue    = empleado.Estatus;
        cboplanta.SelectedValue     = empleado.IDPlanta.ToString();
        cbopuesto.SelectedValue     = empleado.Puesto;
        cbotipo.SelectedValue       = empleado.TipoPersonal;
        cbotipopersonal.SelectedValue =empleado.CvePuesto;

        imgGuardar.ImageUrl = "~/Imagenes/Actualizar.png";
    }

    protected void imgCancelar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListaPersonal.aspx");
    }
    protected void imgLimpiar_Click(object sender, ImageClickEventArgs e)
    {

    }
    
    
    protected void imgGuardar_Click(object sender, ImageClickEventArgs e)
    {
        AgentePersonal AP = new AgentePersonal();
        bool salida = false;

        if (Request.QueryString["idpersonal"] != null)
        {
            salida = AP.ActualizaPersonal(int.Parse(idpersonal), ClaveEmpleado, Nombre, APaterno, AMaterno, Puesto, TipoPersonal, ciudad, IDPlanta, Tipo, Estatus);


            if (salida == true)
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
            }
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
            }

        }
        else
        {
            //Hay que validar si la clave de usuario no exista ates de registrarla
            bool ExisteClave = false;
            Personal BuscarEmpleado = AP.BuscarEmpleadoClave(ClaveEmpleado);
            if (BuscarEmpleado != null && BuscarEmpleado.ClavePersonal != null && BuscarEmpleado.ClavePersonal.Length > 0)
            {
                ExisteClave = true;
            }

            if (!ExisteClave)
            {
                salida = AP.InsertarPersonal(ClaveEmpleado, Nombre, APaterno, AMaterno, Puesto, TipoPersonal, ciudad, IDPlanta, Tipo, Estatus);
                if (salida == true)
                {
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
                    Response.Redirect("ListaPersonal.aspx");
                }
                else
                {
                    Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
                }

            }
            else
            {
                Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_EXISTE_CVE_EMPLEADO);
            }

            
        }


        
       
        
    }

    private void CargaCiudades()
    {
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();
        cbociudad.Items.Clear();

        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        cbociudad.Items.Add(item);

        lc = ac.ObtenerCiudades();
        foreach (Ciudad c in lc)
        {
            item = new ListItem();
            item.Text = c.Descripcion;
            item.Value = c.CveCiudad;
            cbociudad.Items.Add(item);

        }

    }

    private void CargaPlantas()
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> _planta = new List<Planta>();
        _planta = au.ObtenerPlantasObra(DatosUsuario.Ciudad);
        cboplanta.Items.Clear();

        ListItem item = new ListItem();
        item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboplanta.Items.Add(item);

        foreach (Planta a in _planta)
        {
            item = new ListItem();
            item.Text = a.Nombre;
            item.Value = a.IDPlanta.ToString();
            this.cboplanta.Items.Add(item);
        }
    }
    protected void cbotipo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}