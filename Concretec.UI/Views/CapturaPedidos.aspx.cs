using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;
using System.Web.Configuration;

public partial class Views_CapturaPedidos : System.Web.UI.Page
{
    private DateTime startDate = DateTime.Today;
    private DateTime endDate = DateTime.Today.AddDays(60);

    Concretec.Pedidos.Utils.BitacoraErrores BitError = new Concretec.Pedidos.Utils.BitacoraErrores();
    readonly string Aplicacion = "Programacion de Pedidos V 2.5";
    readonly string Modulo = "Views_CapturaPedidos.cs";
    string Metodo = string.Empty;

    public int Horario_Diurno_Inicio_Hora = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Inicio_Hora"].ToString());
    public int Horario_Diurno_Inicio_Minuto = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Inicio_Minuto"].ToString());
    public int Horario_Diurno_Inicio_Segundo = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Inicio_Segundo"].ToString());

    public int Horario_Diurno_Fin_Hora = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Fin_Hora"].ToString());
    public int Horario_Diurno_Fin_Minuto = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Fin_Minuto"].ToString());
    public int Horario_Diurno_Fin_Segundo = int.Parse(WebConfigurationManager.AppSettings["Horario_Diurno_Fin_Segundo"].ToString());

    public int Horario_Nocturno_Inicio_Hora = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Inicio_Hora"].ToString());
    public int Horario_Nocturno_Inicio_Minuto = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Inicio_Minuto"].ToString());
    public int Horario_Nocturno_Inicio_Segundo = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Inicio_Segundo"].ToString());

    public int Horario_Nocturno_Fin_Hora = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Fin_Hora"].ToString());
    public int Horario_Nocturno_Fin_Minuto = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Fin_Minuto"].ToString());
    public int Horario_Nocturno_Fin_Segundo = int.Parse(WebConfigurationManager.AppSettings["Horario_Nocturno_Fin_Segundo"].ToString());

    public int Intervalo_Minutos_Pedidos = int.Parse(WebConfigurationManager.AppSettings["Intervalo_Minutos_Pedidos"].ToString());
    public int Intervalo_Viajes_Pedidos = int.Parse(WebConfigurationManager.AppSettings["Intervalo_Viajes_Pedidos"].ToString());

    public Usuario DatosUsuario
    {
        get
        {

            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session["DatosUsuario"];
            return Login[0];
        }

    }

    public string OrdenCompra
    { get { return txtOrdenCompra.Text; } }

    public string Contrato
    { get { return this.txtContrato.Text; } }

    public string Comentarios
    { get { return txtComentarios.Text; } }

    public int IDPedido
    { get { return int.Parse(lblNumPedido.Text.ToString()); } }

    public int IDObra
    { get { return int.Parse(obra.SelectedValue.ToString()); } }

    public int IDComentario
    { get { return int.Parse(cboObservaciones.SelectedValue.ToString()); } }

    public int IDCliente
    { get { return int.Parse(cbocliente.SelectedValue.ToString()); } }

    public float Distancia
    { get { return float.Parse(distancia.Text.ToString()); } }

    public DateTime FechaCompromiso
    { get { return DateTime.Parse(fechacompromiso.DateInput.Text.Substring(0, 10)); } }

    public string HoraCompromiso
    { get { return horacompromiso.DateInput.Text; } }

    public float CargaTotal
    { get { return float.Parse(cargatotal.Text.ToString()); } }

    public int Viajes
    { get { return int.Parse(NumViajes.Text.ToString()); } }

    public int Desfase
    { get { return int.Parse(desface.Text.ToString()); } }

    public int IDUso
    { get { return int.Parse(usos.SelectedValue.ToString()); } }

    public string Observaciones
    {
        get
        {

            string ListaObs = "";
            int[] seleccionados = cboObservaciones.GetSelectedIndices();
            foreach (int valor in seleccionados)
            {
                ListaObs = ListaObs + cboObservaciones.Items[valor].Value + "|";
            }
            return ListaObs;
        }
    }

    public int IDPlanta
    { get { return int.Parse(planta.SelectedValue.ToString()); } }

    public int IDProducto
    { get { return int.Parse(producto.SelectedValue.ToString()); } }

    public int IDVendedor
    { get { return int.Parse(vendedor.SelectedValue.ToString()); } }

    public string Solicito
    { get { return solicito.Text.ToString(); } }

    public string Recibe
    { get { return recibe.Text.ToString(); } }

    public int TipoVenta
    { get { return int.Parse(cboTPago.SelectedValue.ToString()); } }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        try
        { this.Page.MasterPageFile = Session["MP"].ToString(); }
        catch (Exception ex)
        { Response.Redirect("Default.aspx"); }

    }

    protected void Page_command(object sender, FormViewCommandEventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (DatosUsuario == null || DatosUsuario.Ciudad == "")
        {
            Response.Redirect("../Default.aspx");
        }

        if (IsPostBack != true)
        {
            this.distancia.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
            this.cargatotal.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
            this.desface.Attributes.Add("OnKeyPress", "return AcceptNum(event)");

            NumViajes.Attributes.Add("OnKeyPress", "return AcceptNum(event)");

            if (DatosUsuario == null || DatosUsuario.Ciudad == "")
            {
                Response.Redirect("../Default.aspx");
            }
            else
            {


                if (Session["idPedido"] == null)
                {
                    CargaClientes(DatosUsuario.Ciudad);  // Migrado a BC
                    Cargaobras();                        // Migrado a BC
                    CargaUsos();                         // Migrado a BC
                    CargaComentarios();                  // Migrado a BC
                    CargaProductos(DatosUsuario.Ciudad); // Migrado a BC
                    CargaAdicionales(DatosUsuario.Ciudad); // Migrado a BC
                    CargaVendedores(DatosUsuario.Ciudad); // Migrado a BC
                    CargaPlantas(DatosUsuario.Ciudad);
                    cboTipoColado.SelectedValue = "0";
                    trheader.Visible = false;
                }
                else
                {
                    lblNumPedido.Text = Session["idPedido"].ToString();
                    int idPedido = IDPedido;
                    cargadatosEdicion(idPedido);
                }


                if (Session["IDCliente"] != null && Session["IDObra"] == null)
                {
                    cbocliente.SelectedValue = Session["IDCliente"].ToString();
                    Cargaobras();
                    Session["IDCliente"] = null;
                }

                if (Session["IDObra"] != null && Session["IDCliente"] != null)
                {
                    cbocliente.SelectedValue = Session["IDCliente"].ToString();
                    Cargaobras();
                    obra.SelectedValue = Session["IDObra"].ToString();
                    // Aqui debemos de mandarle hablar a la entidad de obra

                    ConsultaDatosObra(int.Parse(Session["IDObraSQL"].ToString()));
                    vendedor.SelectedValue = Session["IDVendedor"].ToString();

                    Session["IDCliente"] = null;
                    Session["IDObra"] = null;
                    Session["IDVendedor"] = null;
                }
            }


        }

        CargaDatos_Horas();
    }

    private void CargaDatos_Horas()
    {
        if (cboTipoColado.SelectedValue == "1")
        {
            //INSTRUCCIONES PARA ACTIVAR HORARIO NOCTURNO
            horacompromiso.TimeView.StartTime = new TimeSpan(Horario_Nocturno_Inicio_Hora, Horario_Nocturno_Inicio_Minuto, Horario_Nocturno_Inicio_Segundo);
            horacompromiso.TimeView.EndTime = new TimeSpan(Horario_Nocturno_Fin_Hora, Horario_Nocturno_Fin_Minuto, Horario_Nocturno_Fin_Segundo);
            horacompromiso.TimeView.Columns = 8;
            horacompromiso.TimeView.Interval = new TimeSpan(0, 30, 0);
        }
        else
        {
            //INSTRUCCIONES PARA ACTIVAR HORARIO DIURNO
            horacompromiso.TimeView.StartTime = new TimeSpan(Horario_Diurno_Inicio_Hora, Horario_Diurno_Inicio_Minuto, Horario_Diurno_Inicio_Segundo);
            horacompromiso.TimeView.EndTime = new TimeSpan(Horario_Diurno_Fin_Hora, Horario_Diurno_Fin_Minuto, Horario_Diurno_Fin_Segundo);
            horacompromiso.TimeView.Columns = 6;
            horacompromiso.TimeView.Interval = new TimeSpan(0, 30, 0);
        }
    }

    private void CargaPlantas(string CveCiudad)
    {
        planta.Items.Clear();
        AgentePlantas au = new AgentePlantas();
        List<Planta> _planta = new List<Planta>();

        _planta = au.ObtenerPlantas();
        var plantas = from pp in _planta
                      where pp.Ciudad == CveCiudad && pp.CveDosificadora.Contains("PD")
                      select new { pp.IDPlanta, pp.Nombre };
        ListItem item = new ListItem();
        item.Text = "(Seleccione)";
        item.Value = "-1";
        this.planta.Items.Add(item);


        foreach (var a in plantas)
        {
            item = new ListItem();
            item.Text = a.Nombre;
            item.Value = a.IDPlanta.ToString().Trim();
            this.planta.Items.Add(item);

        }

    }
    private void CargaClientes(string ciudad)
    {
        AgenteClientes au = new AgenteClientes();
        List<Cliente> cliente_ = new List<Cliente>();
        cliente_ = au.ObtenerClientesConObra(ciudad);
        var _cliente = from cl in cliente_
                       select new { cl.NombreCompleto, cl.ClaveCliente };

        cbocliente.Items.Clear();

        ListItem item = new ListItem();
        item.Text = "(Seleccione)";
        item.Value = "-1";
        this.cbocliente.Items.Add(item);

        foreach (var a in _cliente.Distinct())
        {
            item = new ListItem();
            item.Text = a.NombreCompleto;
            item.Value = a.ClaveCliente;
            this.cbocliente.Items.Add(item);

        }

    }

    void ConsultaDatosObra(int IDObraSQL)
    {
        AgenteObras aobra = new AgenteObras();
        Obra entidadobra = new Obra();
        entidadobra = aobra.BuscarObra(IDObraSQL, DatosUsuario.Ciudad);

        distancia.Text = entidadobra.Distancia.ToString();
        planta.SelectedValue = entidadobra.IDPlanta.ToString();
        vendedor.SelectedValue = entidadobra.Vendedor.ToString();
    }

    protected void CustomizeDay(object sender, Telerik.Web.UI.Calendar.DayRenderEventArgs e)
    {
        DateTime CurrentDate = e.Day.Date;
        if (startDate <= CurrentDate && CurrentDate <= DateTime.Today.AddDays(60))
        {
            return;
        }
        e.Day.IsDisabled = true;
        e.Day.IsSelectable = false;
        (sender as RadCalendar).SpecialDays.Add(e.Day);
    }

    private void CargaComentarios()
    {
        AgentePedidos au = new AgentePedidos();
        List<Comentario> _comentarios = new List<Comentario>();
        _comentarios = au.LeerComentarios(1);
        cboObservaciones.Items.Clear();

        ListItem item = new ListItem();

        foreach (Comentario a in _comentarios)
        {
            item = new ListItem();
            item.Text = a.Descripcion;
            item.Value = a.IDComentario.ToString();
            this.cboObservaciones.Items.Add(item);

        }
    }

    private void CargaAdicionalesEdicion(int IDPedido)
    {
        AgentePedidos ap = new AgentePedidos();
        List<Producto> productos = new List<Producto>();
        productos = ap.LeerPedidoProductosAdicionales(IDPedido, 1);

        foreach (Producto a in productos)
        {
            ListItem item = new ListItem();
            item.Text = a.Descripcion;
            item.Value = a.IDProducto.ToString();
            this.listaadicionales.Items.Add(item);

        }

        productos = new List<Producto>();
        productos = ap.LeerPedidoProductosAdicionales(IDPedido, 0);
        foreach (Producto a in productos)
        {
            ListItem item = new ListItem();
            item.Text = a.Descripcion;
            item.Value = a.IDProducto.ToString();
            this.adicionales.Items.Add(item);

        }

    }

    private void CargaUsos()
    {
        AgenteUsos au = new AgenteUsos();
        List<Uso> _Usos = new List<Uso>();
        _Usos = au.LeerUsos();


        ListItem item = new ListItem();
        item.Text = "(Seleccione)";
        item.Value = "-1";
        this.usos.Items.Add(item);

        foreach (Uso u in _Usos)
        {
            item = new ListItem();
            item.Text = u.Descripcion;
            item.Value = u.IDUso.ToString();
            this.usos.Items.Add(item);
        }

    }

    private void CargaProductos(string ciudad)
    {
        producto.Items.Clear();
        AgenteProductos ap = new AgenteProductos();
        List<Producto> productos = new List<Producto>();

        productos = ap.ObtenerProducto(0, ciudad);
        ListItem item = new ListItem();
        item.Text = "(Seleccione)";
        item.Value = "-1";
        this.producto.Items.Add(item);

        foreach (Producto a in productos)
        {
            item = new ListItem();
            item.Text = a.Descripcion;
            item.Value = a.IDProducto.ToString();
            this.producto.Items.Add(item);

        }

    }
    private void CargaAdicionales(string ciudad)
    {
        AgenteProductos ap = new AgenteProductos();
        List<Producto> productos = new List<Producto>();
        productos = ap.ObtenerProducto(1, ciudad);

        foreach (Producto a in productos)
        {
            ListItem item = new ListItem();
            item.Text = a.Descripcion;
            item.Value = a.IDProducto.ToString();
            this.adicionales.Items.Add(item);

        }

    }
    private void CargaVendedores(string ciudad)
    {
        AgentePersonal ap = new AgentePersonal();
        List<Personal> vendedores = new List<Personal>();
        vendedores = ap.ObtenerPersonal("VE", ciudad);

        ListItem item = new ListItem();
        item.Text = "(Seleccione)";
        item.Value = "-1";
        this.vendedor.Items.Add(item);

        foreach (Personal v in vendedores)
        {
            item = new ListItem();
            item.Text = v.Nombre + " - " + v.AMaterno;
            item.Value = v.IDPersonal.ToString();
            this.vendedor.Items.Add(item);

        }

    }

    private void GrabaPedido()
    {
        AgentePedidos AP = new AgentePedidos();
    }

    private void Cargaobras()
    {
        this.obra.Items.Clear();
        AgenteObras ao = new AgenteObras();
        List<Obra> obras = new List<Obra>();

        obras = ao.ObtenerObrasFiltroActivas("", "(Seleccione)", int.Parse(cbocliente.SelectedValue.ToString()), DatosUsuario.Ciudad);

        ListItem item = new ListItem();
        item.Text = "(Seleccione)";
        item.Value = "-1";
        this.obra.Items.Add(item);

        foreach (Obra a in obras)
        {
            item = new ListItem();
            item.Text = a.ClaveObra + " - " + a.Nombre;
            item.Value = a.ClaveObra.ToString();
            this.obra.Items.Add(item);

        }

    }

    private void cargadatosEdicion(int CvePedido)
    {
        trheader.Visible = true;

        int idPedido = IDPedido;
        List<Pedido> lista = new List<Pedido>();
        AgentePedidos ap = new AgentePedidos();
        lista = ap.ConsultaPedido(idPedido);
        Pedido PedidoPadre = lista[0];
        txtOrdenCompra.Text = PedidoPadre.OrdenCompra.ToString().Trim();
        txtComentarios.Text = PedidoPadre.Observaciones;
        lblNumPedido.Text = PedidoPadre.IDPedido.ToString();
        CargaClientes(DatosUsuario.Ciudad);
        this.cbocliente.SelectedValue = PedidoPadre.IDCliente.ToString();
        Cargaobras();
        this.obra.SelectedValue = PedidoPadre.IDObra.ToString();
        distancia.Text = PedidoPadre.Distancia.ToString();
        horacompromiso.SelectedDate = PedidoPadre.HoraPrometida;
        cargatotal.Text = PedidoPadre.CargaTotal.ToString();
        NumViajes.Text = PedidoPadre.Viajes.ToString();
        desface.Text = PedidoPadre.Desfase.ToString();
        CargaUsos();
        usos.SelectedValue = PedidoPadre.IDUso.ToString();
        CargaProductos(DatosUsuario.Ciudad);
        producto.SelectedValue = PedidoPadre.IDProducto.ToString();
        CargaPlantas(DatosUsuario.Ciudad);
        planta.SelectedValue = PedidoPadre.IDPlanta.ToString();
        CargaVendedores(DatosUsuario.Ciudad);
        vendedor.SelectedValue = PedidoPadre.IDVendedor.ToString();
        solicito.Text = PedidoPadre.Solicito.ToString();
        recibe.Text = PedidoPadre.Recibe.ToString();
        fechacompromiso.SelectedDate = PedidoPadre.FechaCompromiso;
        cboTPago.SelectedValue = PedidoPadre.IDTipoVenta.ToString();
        lblEstatus.Text = PedidoPadre.Estatus;
        CargaComentarios();
        this.cboObservaciones.SelectedValue = PedidoPadre.IDComentario.ToString();
        txtContrato.Text = PedidoPadre.Contrato;
        cboTipoColado.SelectedValue = PedidoPadre.ColadoNocturno.ToString();

        CargaAdicionalesEdicion(idPedido);
        imgGuardar.ImageUrl = "~/Imagenes/Actualizar.png";
        imgImprimir.ImageUrl = "~/Imagenes/UI_ActualizarImprimir.png";
        Session["idPedido"] = null;

        if (PedidoPadre.FechaCompromiso.Date.AddDays(1) <= DateTime.Now.Date)
        {
            AdministraEdicion("-1");
        }
        else
        {
            AdministraEdicion(PedidoPadre.Estatus);
        }



    }

    private void MuestraDatos(List<PedidoHijo> ph)
    {
    }
    protected void agregaadicional_Click(object sender, EventArgs e)
    {
        ListItem li = new ListItem();
        try
        {
            li.Text = adicionales.SelectedItem.Text;
            li.Value = adicionales.SelectedValue;
            listaadicionales.Items.Add(li);
            adicionales.Items.RemoveAt(adicionales.SelectedIndex);
        }
        catch (Exception ex)
        {
            BitError = new Concretec.Pedidos.Utils.BitacoraErrores();
            BitError.EscribirBitacora(Aplicacion, Modulo, "agregaadicional_Click", ex.Message);
        }


    }
    protected void eliminaadicional_Click(object sender, EventArgs e)
    {
        ListItem li = new ListItem();
        li.Text = listaadicionales.SelectedItem.Text;
        li.Value = listaadicionales.SelectedValue;
        adicionales.Items.Add(li);
        listaadicionales.Items.RemoveAt(listaadicionales.SelectedIndex);
    }

    protected void imgCancelar_Click(object sender, ImageClickEventArgs e)
    {
        Session[""] = "";
        Session[""] = "";
        Session[""] = "";

        Response.Redirect("~/Views/ListaPedidos.aspx");
    }
    protected void imgLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        distancia.Text = "";
        cargatotal.Text = "";
        cargatotal.Text = "";
        fechacompromiso.DateInput.Text = "";
        horacompromiso.DateInput.Text = "";
        solicito.Text = "";
        recibe.Text = "";
        desface.Text = "";
        autorizo.Text = "";
    }

    void BloquearCampos()
    {
        lblNumPedido.Enabled = false;
        cbocliente.Enabled = false;
        obra.Enabled = false;
        planta.Enabled = false;
        distancia.Enabled = false;
        usos.Enabled = false;
        producto.Enabled = false;
        cargatotal.Enabled = false;
        NumViajes.Enabled = false;
        autorizo.Enabled = false;
        vendedor.Enabled = false;
        cboTPago.Enabled = false;
        fechacompromiso.Enabled = false;
        horacompromiso.Enabled = false;
        desface.Enabled = false;
        solicito.Enabled = false;
        recibe.Enabled = false;
        adicionales.Enabled = false;
        listaadicionales.Enabled = false;
        agregaadicional.Enabled = false;
        eliminaadicional.Enabled = false;
        cboObservaciones.Enabled = false;
        txtOrdenCompra.Enabled = false;
        txtComentarios.Enabled = false;

    }

    void AdministraEdicion(string Estatus)
    {

        switch (Estatus)
        {

            case "-1":
                BloquearCampos();

                imgLimpiar.Visible = false;
                imgGuardar.Visible = false;
                imgImprimir.Visible = false;
                imgCancelarPedido.Visible = false;
                break;
            case "8":
                BloquearCampos();
                imgLimpiar.Visible = false;
                imgGuardar.Visible = false;
                imgImprimir.Visible = false;
                imgCancelarPedido.Visible = false;
                break;
            case "2":
                BloquearCampos();
                imgLimpiar.Visible = false;
                imgGuardar.Visible = false;
                imgImprimir.Visible = false;
                imgCancelarPedido.Visible = false;
                break;
            case "3":
                imgViajes.Visible = true;
                break;

        }



    }



    bool ValidaFechaHoraEntrega()
    {
        bool salida = true;
        if (fechacompromiso.DateInput.Text == "" || horacompromiso.DateInput.Text == "")
        { salida = false; }
        //else
        //{
        //    DateTime? fechahoracompromiso = horacompromiso.SelectedDate;
        //    if( (fechahoracompromiso.Value.Hour > 20 || fechahoracompromiso.Value.Hour < 6) && cboTipoColado.SelectedValue == "0")
        //    {
        //        Alert.Show("La hora compromiso pertenece al colado nocturno favor de verificar");
        //        salida = false;
        //    }
        //    else
        //    {
        //        salida = true;
        //    }

        //}



        return salida;
    }



    protected void imgGuardar_Click(object sender, ImageClickEventArgs e)
    {
        AgentePedidos ap = new AgentePedidos();
        List<Pedido> resp = new List<Pedido>();
        Pedido ph = new Pedido();
        string Listaads = "";
        string ListaObs = "";

        if (ValidaFechaHoraEntrega())
        {
            //Preparar la informacion de los Productos Adicionales
            foreach (ListItem Li in listaadicionales.Items)
            {
                Listaads = Listaads + Li.Value.ToString() + "|";
            }

            int[] seleccionados = cboObservaciones.GetSelectedIndices();
            foreach (int valor in seleccionados)
            {
                ListaObs = ListaObs + cboObservaciones.Items[valor].Value + "|";
            }


            if (cboTPago.SelectedValue.ToString() == "0" || ValidaCreditoPedido() == true || lblEstatus.Text == "6")
            {


                if (lblNumPedido.Text == "")
                {
                    int Status = 3;

                    resp = ap.InsertaPedidoconDetalle(IDUso, IDPlanta, IDProducto, IDVendedor, Distancia,
                                       CargaTotal, Viajes, FechaCompromiso, HoraCompromiso,
                                       Status, Solicito, Recibe, Desfase, ListaObs, IDCliente,
                                       IDObra, autorizo.Text, Listaads, TipoVenta, txtOrdenCompra.Text.ToString(), Comentarios, Contrato, DatosUsuario.Id_Usuario, int.Parse(cboTipoColado.SelectedValue.ToString()));

                    Session["PedidoPadre"] = resp;
                    if (resp == null)
                    {
                        Alert.Show("Ha ocurrido un error al grabar");
                    }
                    else
                    {
                        Alert.Show("El Pedido se ha grabado con Exito con el numero " + resp[0].IDPedido.ToString());
                        lblNumPedido.Text = resp[0].IDPedido.ToString();
                        imgGuardar.Visible = false;
                        imgImprimir.Visible = false;
                        imgViajes.Visible = true;

                    }
                }
                else
                {
                    int Status = 3;
                    bool respuesta = false;
                    respuesta = ap.ActualizaPedidoDetalle(int.Parse(lblNumPedido.Text),
                            0,
                            IDUso, IDPlanta, IDProducto, IDVendedor, Distancia,
                                       CargaTotal, Viajes, FechaCompromiso, HoraCompromiso,
                                       Status, Solicito, Recibe, Desfase, Observaciones, IDCliente,
                                       IDObra, autorizo.Text, Listaads, TipoVenta, Comentarios, Contrato, int.Parse(cboTipoColado.SelectedValue.ToString()),txtOrdenCompra.Text.ToString().Trim());

                    ConsultaPedidoSesion();
                    if (respuesta == false)
                    { Alert.Show("Ha ocurrido un error al grabar"); }
                    else
                    {
                        Alert.Show("El Pedido se ha actualizado con Exito");
                        imgViajes.Visible = true;
                    }
                }
            }

            if (cboTPago.SelectedValue.ToString() == "1" && ValidaCreditoPedido() == false && lblEstatus.Text != "6")
            {
                Alert.Show("El cliente no cuenta con credito suficiente, es necesario una autorizacion por parte de contabilidad");
                imgAutorizacion.Visible = true;
                imgGuardar.Visible = false;
                imgImprimir.Visible = false;
            }
        }
        else
        {
            Alert.Show("Es necesario capturar la Fecha y Hora de entrega del pedido");
        }

    }

    void ConsultaPedidoSesion()
    {
        AgentePedidos ap = new AgentePedidos();
        List<Pedido> resp = new List<Pedido>();
        resp = ap.ConsultaPedido(int.Parse(lblNumPedido.Text));
        Session["PedidoPadre"] = resp;
    }

    protected void usos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void cbocliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cargaobras();
    }
    protected void distancia_KeyPressed(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        //If KeyAscii < 48 Or KeyAscii > 57 Then KeyAscii = 0
        int ascii = Convert.ToInt16(e.KeyChar);
        if ((ascii < 46 && ascii > 57))
        { e.Handled = false; }
        else
        { e.Handled = true; }
    }
    protected void distancia_TextChanged(object sender, EventArgs e)
    {

    }
    protected void cargatotal_TextChanged(object sender, EventArgs e)
    {
        int CargaTotal = (int)Math.Round(double.Parse(cargatotal.Text.ToString()));
        int iViajes = 0;
        int Diferencial = 0;
        int totalViajes = 0;
        iViajes = CargaTotal / 7;
        Diferencial = CargaTotal % 7;
        totalViajes = iViajes;
        if (Diferencial > 0)
        {
            totalViajes = totalViajes + 1;
        }

        this.NumViajes.Text = totalViajes.ToString();
    }
    protected void imgViajes_Click(object sender, ImageClickEventArgs e)
    {
        ConsultaPedidoSesion();
        Response.Redirect("CapturaViajes.aspx");
    }

    bool ValidaCreditoPedido()
    {
        AgenteProductos ap = new AgenteProductos();
        AgenteClientes ac = new AgenteClientes();
        List<Producto> ListaProductos = new List<Producto>();
        ListaProductos = ap.ObtenerProducto(0, DatosUsuario.Ciudad);


        List<Producto> productos = new List<Producto>();
        Producto _producto = new Producto();

        _producto = new Producto();
        _producto.IDProducto = int.Parse(producto.SelectedValue.ToString());
        _producto.Cantidad = float.Parse(cargatotal.Text);

        var _precio = from pp in ListaProductos
                      where pp.IDProducto == _producto.IDProducto
                      select pp.Precio;

        _producto.Precio = _precio.Sum() * _producto.Cantidad;

        productos.Add(_producto);

        foreach (ListItem Li in listaadicionales.Items)
        {
            _producto = null;
            _producto = new Producto();
            _producto.IDProducto = int.Parse(Li.Value.ToString());
            _producto.Cantidad = 1;

            _precio = from pp in ListaProductos
                      where pp.IDProducto == _producto.IDProducto
                      select pp.Precio;

            _producto.Precio = _precio.Sum();
            productos.Add(_producto);
        }

        var subtotal = from pp in productos
                       select pp.Precio;

        bool salida = ac.ObtenerClientesSaldo(DatosUsuario.Ciudad, IDCliente, subtotal.Sum());

        return salida;
    }

    protected void cboTPago_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void imgAutorizacion_Click(object sender, ImageClickEventArgs e)
    {
        AgentePedidos ap = new AgentePedidos();
        List<Pedido> resp = new List<Pedido>();
        Pedido ph = new Pedido();
        string Listaads = "";


        foreach (ListItem Li in listaadicionales.Items)
        { Listaads = Li.Value.ToString() + "|"; }

        if (lblNumPedido.Text == "")
        {
            int Status = 5;

            resp = ap.InsertaPedido(IDUso, IDPlanta, IDProducto, IDVendedor, Distancia,
                               CargaTotal, Viajes, FechaCompromiso, HoraCompromiso,
                               Status, Solicito, Recibe, Desfase, Observaciones, IDCliente,
                               IDObra, autorizo.Text, Listaads, TipoVenta, OrdenCompra, Comentarios, DatosUsuario.Id_Usuario);

            Session["PedidoPadre"] = resp;
            if (resp == null)
            {
                Alert.Show("Ha ocurrido un error al grabar");
            }
            else
            {
                Alert.Show("El pedido ha sido aignado para su autorizacion");
                Response.AddHeader("REFRESH", "2;URL=ListaPedidos.aspx");
            }
        }

    }
    protected void producto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void imgCancelarPedido_Click(object sender, ImageClickEventArgs e)
    {
        AgentePedidos ap = new AgentePedidos();
        List<Pedido> resp = new List<Pedido>();
        Pedido ph = new Pedido();
        string Listaads = "";

        int Status = 8;
        bool respuesta = false;
        respuesta = ap.ActualizaPedido(int.Parse(lblNumPedido.Text),
                0,
                IDUso, IDPlanta, IDProducto, IDVendedor, Distancia,
                           CargaTotal, Viajes, FechaCompromiso, HoraCompromiso,
                           Status, Solicito, Recibe, Desfase, Observaciones, IDCliente,
                           IDObra, autorizo.Text, Listaads, TipoVenta, Comentarios);

        resp = ap.ConsultaPedido(int.Parse(lblNumPedido.Text));
        Session["PedidoPadre"] = resp;

        if (respuesta == false)
        {
            Alert.Show("Ha ocurrido un error al grabar");
        }
        else
        { imgViajes.Visible = true; }
    }
    protected void cargatotal_TextChanged1(object sender, EventArgs e)
    {
        float CargaTotal = float.Parse(cargatotal.Text.ToString());
        int _carga = (int)(Math.Round(CargaTotal, 0, MidpointRounding.ToEven));

        if (float.Parse(cargatotal.Text.ToString()) > _carga)
        { _carga++; }


        int iViajes = 0;
        int Diferencial = 0;
        int totalViajes = 0;
        iViajes = _carga / 7;
        Diferencial = _carga % 7;
        totalViajes = iViajes;
        if (Diferencial > 0)
        {
            totalViajes = totalViajes + 1;
        }

        NumViajes.Text = totalViajes.ToString();
    }
    protected void imgCerrarPedido_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CierrePedido.aspx?IDPedido=" + IDPedido.ToString());
    }

    void ConsultaPlantaObra(int idobra)
    {
        AgenteObras Agente = new AgenteObras();
        List<Obra> Lista = new List<Obra>();
        Lista = Agente.ObtenerObrasFiltroActivas("", "-1", int.Parse(cbocliente.SelectedValue.ToString()), DatosUsuario.Ciudad);
        var _obras = from ob in Lista
                     where ob.ClaveObra == idobra.ToString()
                     select new { ob.IDPlanta, ob.Distancia, ob.Vendedor };

        if (_obras.Count() > 0)
        {
            planta.SelectedValue = _obras.First().IDPlanta.ToString();
            distancia.Text = _obras.First().Distancia.ToString();
            try
            {
                vendedor.SelectedValue = _obras.First().Vendedor.ToString();
            }
            catch (Exception e)
            {
                vendedor.SelectedValue = "-1";
            }

        }
        else
        {
            planta.SelectedValue = "-1";
        }

    }

    protected void obra_SelectedIndexChanged(object sender, EventArgs e)
    {
        Obra obraseleccionada = new Obra();
        // Aqui hay que poner el codigo para ir por la planta de la obra
        ConsultaPlantaObra(IDObra);
    }
    protected void imgImprimir_Click(object sender, ImageClickEventArgs e)
    {
        AgentePedidos ap = new AgentePedidos();
        List<Pedido> resp = new List<Pedido>();
        Pedido ph = new Pedido();
        string Listaads = "";
        string ListaObs = "";

        if (ValidaFechaHoraEntrega())
        {
            //Preparar la informacion de los Productos Adicionales
            foreach (ListItem Li in listaadicionales.Items)
            {
                Listaads = Listaads + Li.Value.ToString() + "|";
            }

            int[] seleccionados = cboObservaciones.GetSelectedIndices();
            foreach (int valor in seleccionados)
            {
                ListaObs = ListaObs + cboObservaciones.Items[valor].Value + "|";
            }


            if (cboTPago.SelectedValue.ToString() == "0" || ValidaCreditoPedido() == true || lblEstatus.Text == "6")
            {


                if (lblNumPedido.Text == "")
                {
                    int Status = 3;

                    resp = ap.InsertaPedidoconDetalle(IDUso, IDPlanta, IDProducto, IDVendedor, Distancia,
                                       CargaTotal, Viajes, FechaCompromiso, HoraCompromiso,
                                       Status, Solicito, Recibe, Desfase, ListaObs, IDCliente,
                                       IDObra, autorizo.Text, Listaads, TipoVenta, txtOrdenCompra.Text.ToString(),
                                       Comentarios, Contrato, DatosUsuario.Id_Usuario, int.Parse(cboTipoColado.SelectedValue.ToString()));

                    Session["PedidoPadre"] = resp;
                    if (resp == null)
                    {
                        Alert.Show("Ha ocurrido un error al grabar");
                    }
                    else
                    {
                        Alert.Show("El Pedido se ha grabado con Exito con el numero " + resp[0].IDPedido.ToString());
                        lblNumPedido.Text = resp[0].IDPedido.ToString();
                        Response.Redirect("Pedido_Print_FF.aspx?IDPedido=" + resp[0].IDPedido.ToString(), "_new", "width=800,height=700");
                        imgGuardar.Visible = false;
                        imgImprimir.Visible = false;
                        imgViajes.Visible = true;

                    }
                }
                else
                {
                    int Status = 3;
                    bool respuesta = false;
                    respuesta = ap.ActualizaPedidoDetalle(int.Parse(lblNumPedido.Text),
                            0,
                            IDUso, IDPlanta, IDProducto, IDVendedor, Distancia,
                                       CargaTotal, Viajes, FechaCompromiso, HoraCompromiso,
                                       Status, Solicito, Recibe, Desfase, Observaciones, IDCliente,
                                       IDObra, autorizo.Text, Listaads, TipoVenta, Comentarios, Contrato,
                                       int.Parse(cboTipoColado.SelectedValue.ToString()),txtOrdenCompra.Text.ToString().Trim());

                    ConsultaPedidoSesion();
                    if (respuesta == false)
                    { Alert.Show("Ha ocurrido un error al grabar"); }
                    else
                    {
                        Alert.Show("El Pedido se ha actualizado con Exito");
                        Response.Redirect("Pedido_Print_FF.aspx?IDPedido=" + lblNumPedido.Text, "_new", "width=800,height=700");

                        imgViajes.Visible = true;
                    }
                }
            }

            if (cboTPago.SelectedValue.ToString() == "1" && ValidaCreditoPedido() == false && lblEstatus.Text != "6")
            {
                Alert.Show("El cliente no cuenta con credito suficiente, es necesario una autorizacion por parte de contabilidad");
                imgAutorizacion.Visible = true;
                imgGuardar.Visible = false;
                imgImprimir.Visible = false;
            }
        }
        else
        {
            Alert.Show("Es necesario capturar la Fecha y Hora de entrega del pedido");
        }

    }

    protected void cboTipoColado_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargaDatos_Horas();
    }

    protected void imgImprimir_Laser_Click(object sender, ImageClickEventArgs e)
    {
        AgentePedidos ap = new AgentePedidos();
        List<Pedido> resp = new List<Pedido>();
        Pedido ph = new Pedido();
        string Listaads = "";
        string ListaObs = "";

        if (ValidaFechaHoraEntrega())
        {
            //Preparar la informacion de los Productos Adicionales
            foreach (ListItem Li in listaadicionales.Items)
            {
                Listaads = Listaads + Li.Value.ToString() + "|";
            }

            int[] seleccionados = cboObservaciones.GetSelectedIndices();
            foreach (int valor in seleccionados)
            {
                ListaObs = ListaObs + cboObservaciones.Items[valor].Value + "|";
            }


            if (cboTPago.SelectedValue.ToString() == "0" || ValidaCreditoPedido() == true || lblEstatus.Text == "6")
            {


                if (lblNumPedido.Text == "")
                {
                    int Status = 3;

                    resp = ap.InsertaPedidoconDetalle(IDUso, IDPlanta, IDProducto, IDVendedor, Distancia,
                                       CargaTotal, Viajes, FechaCompromiso, HoraCompromiso,
                                       Status, Solicito, Recibe, Desfase, ListaObs, IDCliente,
                                       IDObra, autorizo.Text, Listaads, TipoVenta, txtOrdenCompra.Text.ToString(),
                                       Comentarios, Contrato, DatosUsuario.Id_Usuario, int.Parse(cboTipoColado.SelectedValue.ToString()));

                    Session["PedidoPadre"] = resp;
                    if (resp == null)
                    {
                        Alert.Show("Ha ocurrido un error al grabar");
                    }
                    else
                    {
                        Alert.Show("El Pedido se ha grabado con Exito con el numero " + resp[0].IDPedido.ToString());
                        lblNumPedido.Text = resp[0].IDPedido.ToString();
                        Response.Redirect("Pedido_Print_Laser.aspx?IDPedido=" + resp[0].IDPedido.ToString(), "_new", "width=800,height=700");
                        imgGuardar.Visible = false;
                        imgImprimir.Visible = false;
                        imgViajes.Visible = true;

                    }
                }
                else
                {
                    int Status = 3;
                    bool respuesta = false;
                    respuesta = ap.ActualizaPedidoDetalle(int.Parse(lblNumPedido.Text),
                            0,
                            IDUso, IDPlanta, IDProducto, IDVendedor, Distancia,
                                       CargaTotal, Viajes, FechaCompromiso, HoraCompromiso,
                                       Status, Solicito, Recibe, Desfase, Observaciones, IDCliente,
                                       IDObra, autorizo.Text, Listaads, TipoVenta, Comentarios, Contrato,
                                       int.Parse(cboTipoColado.SelectedValue.ToString()), txtOrdenCompra.Text.ToString().Trim());

                    ConsultaPedidoSesion();
                    if (respuesta == false)
                    { Alert.Show("Ha ocurrido un error al grabar"); }
                    else
                    {
                        Alert.Show("El Pedido se ha actualizado con Exito");
                        Response.Redirect("Pedido_Print_Laser.aspx?IDPedido=" + lblNumPedido.Text, "_new", "width=800,height=700");

                        imgViajes.Visible = true;
                    }
                }
            }

            if (cboTPago.SelectedValue.ToString() == "1" && ValidaCreditoPedido() == false && lblEstatus.Text != "6")
            {
                Alert.Show("El cliente no cuenta con credito suficiente, es necesario una autorizacion por parte de contabilidad");
                imgAutorizacion.Visible = true;
                imgGuardar.Visible = false;
                imgImprimir.Visible = false;
            }
        }
        else
        {
            Alert.Show("Es necesario capturar la Fecha y Hora de entrega del pedido");
        }
    }
}
