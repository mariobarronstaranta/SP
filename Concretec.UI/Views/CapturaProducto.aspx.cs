using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;

public partial class Views_CapturaProducto : System.Web.UI.Page
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
        List<Usuario> login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];

        if (login == null)
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }
        {
            if (IsPostBack != true)
            {
                LimpiaDatos();
            }
        }

    }

    protected void LimpiaDatos()
    {
        txtClave.Text = string.Empty;
        txtDescripcion.Text = string.Empty;
        txtPrecio.Text = "0.0";
        cboCiudades.SelectedValue = "-1";
        cboclasificacion.SelectedValue = "-1";
    }

    protected void imgCancelar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListaProductos.aspx");
    }

    protected void imgLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        LimpiaDatos();
    }

    protected void imgGuardar_Click(object sender, ImageClickEventArgs e)
    {
        if (txtClave.Text.Trim().Length == 0)
        {
            Alert.Show("Capture la Clave del Producto");
        }
        else if (txtDescripcion.Text.Trim().Length == 0)
        {
            Alert.Show("Capture la Descripcion del Producto");
        }
        else if (txtCveAlterna.Text.Trim().Length == 0)
        {
            Alert.Show("Capture la Clave Alterna del Producto");
        }
        else if (cboCiudades.SelectedValue.ToString() == "-1")
        {
            Alert.Show("Seleccione una ciudad asociada al Producto");
        }
        else if (cboclasificacion.SelectedValue.ToString() == "-1")
        {
            Alert.Show("Seleccione una clasificacion asociada al Producto");
        }
        else
        {
            GuardaDatos();
        }
        
    }

    protected void GuardaDatos()
    {
        AgenteProductos AP = new AgenteProductos();
        bool resultado = AP.InsertarProducto(0, txtClave.Text.Trim(), txtDescripcion.Text.Trim(), txtUnidad.Text.Trim(), double.Parse(txtPrecio.Text), true, string.Empty, false, 0, txtCveAlterna.Text.Trim(), cboCiudades.SelectedValue.ToString(), cboclasificacion.SelectedValue.ToString());
        if (resultado)
        {
            Alert.Show("El Producto ha sido guardado con exito");
        }
        else
        {
            Alert.Show("Ocurrio un error al guardar");
        }
        LimpiaDatos();

    }
}