using Concretec.Agentes;
using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_CapturaFacturas : System.Web.UI.Page
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

    public int IDPedido
    {
        get
        {
            int salida = -1;
            if (this.cboObra.SelectedValue.ToString() != "")
            { salida = int.Parse(cboObra.SelectedValue.ToString()); }
            return salida;
        }
    }

    public DateTime Desde
    { get { return DateTime.Parse(dtDesde.DateInput.Text.Substring(0, 10)); } }

    public DateTime Hasta
    { get { return DateTime.Parse(dtHasta.DateInput.Text.Substring(0, 10)); } }

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
                CargaClientes(DatosUsuario.Ciudad);
                this.dtDesde.SelectedDate = DateTime.Now.AddDays(-30);
                this.dtHasta.SelectedDate = DateTime.Now;
            }
        }
    }
    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        Concretec.Pedidos.BC.Pedidos Agente = new Concretec.Pedidos.BC.Pedidos();
        bool resultado = false;
        resultado = Agente.ActualizaFacturaRemisiones(txtFactura.Text, txtRemisiones.Text);

        if (!resultado)
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
        }
        else
        {
            resetform();
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
        }

    }
    protected void btnBuscarFactura_Click(object sender, ImageClickEventArgs e)
    {
        string factura = txtFactura.Text;
        if (factura.Trim().Length > 0)
        {
            string remisiones = BuscaRemisiones(factura);
            this.txtRemisiones.Text = remisiones;


            List<PedidoViaje> informacion = BuscaRemisionesPorFactura(factura);
            this.GridRemisiones.DataSource = informacion;
            this.GridRemisiones.DataBind();
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.FACTURA_BUSQUEDA_CAMPO);
        }
        
    }
    protected void btnEliminarFacturas_Click(object sender, ImageClickEventArgs e)
    {
        Concretec.Pedidos.BC.Pedidos Agente = new Concretec.Pedidos.BC.Pedidos();
        bool resultado = false;
        resultado = Agente.ActualizaFacturaRemisiones(string.Empty, txtRemisiones.Text);

        if (!resultado)
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_FALLIDO);
        }
        else
        {
            resetform();
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.REGISTRO_EXITOSO);
        }
    }
    protected void btnBuscarRemision_Click(object sender, ImageClickEventArgs e)
    {
        llenaGrid();
    }
    protected void cboCliente_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        CargaPedidos();
    }
    protected void cboObra_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    protected void GridRemisiones_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_CONSULTA && DatosUsuario.Perfil.ToUpper() != Concretec.Pedidos.Constantes.Etiquetas.TAG_PERFIL_VENDEDOR)
        {
            switch (e.CommandName)
            {
                case Concretec.Pedidos.Constantes.Etiquetas.TAR_AGREGAR:
                    string NumRemision = e.Item.Cells[6].Text.Trim();
                    if (NumRemision == "&nbsp;")
                    {
                        NumRemision = string.Empty;
                    }

                    if (NumRemision.Length > 0)
                    {
                        if (txtRemisiones.Text.Trim().Length == 0)
                        {
                            txtRemisiones.Text = NumRemision;
                        }
                        else
                        {
                            txtRemisiones.Text = txtRemisiones.Text + ',' + NumRemision;
                        }
                    }
                    else
                    {
                        Alert.Show(Concretec.Pedidos.Constantes.Mensajes.VIAJE_NO_REMISIONADO);
                    }
                    
                    
                    break;
            }
        }
        else
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.PERMISOS_ERROR);
        }
    }

    private void CargaClientes(string ciudad)
    {
        AgenteClientes au = new AgenteClientes();
        List<Cliente> cliente_ = new List<Cliente>();
        cliente_ = au.ObtenerClientesConObra(ciudad);
        var _cliente = from cl in cliente_
                       select new { cl.NombreCompleto, cl.ClaveCliente };

        cboCliente.Items.Clear();

        Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboCliente.Items.Add(item);

        foreach (var a in _cliente.Distinct())
        {
            item = new Telerik.Web.UI.RadComboBoxItem();
            item.Text = a.NombreCompleto;
            item.Value = a.ClaveCliente;
            this.cboCliente.Items.Add(item);

        }

    }

    private void CargaPedidos()
    {
        Concretec.Pedidos.BC.Pedidos au = new Concretec.Pedidos.BC.Pedidos();
        List<Pedido> cliente_ = new List<Pedido>();
        cliente_ = au.PedidosCliente(IDCliente, DatosUsuario.Ciudad,Desde,Hasta);


        cboObra.Items.Clear();

        Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        this.cboObra.Items.Add(item);

        foreach (Pedido a in cliente_)
        {
            item = new Telerik.Web.UI.RadComboBoxItem();
            item.Text = a.NombreObra;
            item.Value = a.IDPedido.ToString();
            this.cboObra.Items.Add(item);

        }

    }

    private void llenaGrid()
    {
        Concretec.Pedidos.BC.Pedidos Agente = new Concretec.Pedidos.BC.Pedidos();
        List<PedidoViaje> Lista = new List<PedidoViaje>();
        Lista = Agente.BuscaRemisiones(IDCliente.ToString(), IDPedido, txtRemision.Text,Desde,Hasta);
        this.GridRemisiones.DataSource = Lista;
        this.GridRemisiones.DataBind();
    }

    private void resetform()
    {
        txtFactura.Text             = string.Empty;
        txtRemision.Text            = string.Empty;
        txtRemisiones.Text          = string.Empty;

        cboCliente.SelectedValue    = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        CargaPedidos();

        List<PedidoViaje> Lista = new List<PedidoViaje>();
        this.GridRemisiones.DataSource = Lista;
        this.GridRemisiones.DataBind();
    }

    private List<PedidoViaje> BuscaRemisionesPorFactura(string factura)
    {
        Concretec.Pedidos.BC.Pedidos Agente = new Concretec.Pedidos.BC.Pedidos();
        List<PedidoViaje> Lista = new List<PedidoViaje>();
        Lista = Agente.BuscaRemisiones(factura);
        return Lista;
    }

    private string BuscaRemisiones(string factura)
    {
        string salida = string.Empty;
        Concretec.Pedidos.BC.Pedidos Agente = new Concretec.Pedidos.BC.Pedidos();
        List<PedidoViaje> Lista = new List<PedidoViaje>();
        Lista = Agente.BuscaRemisiones(factura);

        int _counter = 1;

        foreach (PedidoViaje elemento in Lista)
        {
            if (_counter == 1)
            {
                salida = elemento.Remision;
            }
            else
            {
                salida = salida + "," + elemento.Remision;
            }

            _counter++;
        }

        return salida;
    }
}