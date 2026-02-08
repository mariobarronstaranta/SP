using Concretec.Agentes;
using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_ProgramaDepuracion : System.Web.UI.Page
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
                DateTime Hoy        = DateTime.Now.Date;
                inicio.SelectedDate = Hoy.AddDays(-60);
                fin.SelectedDate    = Hoy.AddDays(-30);

                CargaCiudades();
                llenagrid();
            }
        }
    }

    private void CargaCiudades()
    {
        cbociudad.Items.Clear();
        List<Ciudad> lc = obtener_Ciudades();
        ListItem item = new ListItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = "-1";
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

    protected bool ActualizaCalendario(int IdCalendarioDepuracion)
    {
        bool result = false;
        AgentePedidos ap = new AgentePedidos();
        List<Usuario> Login = new List<Usuario>();
        Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
        result = ap.ActualizaCalendarioDepuracion(IdCalendarioDepuracion, "CAN", Login[0].Id_Usuario);

        return result;
    }

    protected void grdPedidos_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        AgentePedidos ap = new AgentePedidos();

        switch (e.CommandName)
        {
            case "Cancelar":
                int i = 0;
                string nombre_status = string.Empty;
                bool actualiza = false;
                int IdCalendarioDepuracion = 0;

                if (e.Item.Cells[2].Text != "&nbsp;")
                { IdCalendarioDepuracion = int.Parse(e.Item.Cells[2].Text); }
                else
                { IdCalendarioDepuracion = 0; }

                if (e.Item.Cells[11].Text != "&nbsp;")
                { nombre_status = e.Item.Cells[11].Text; }
                else
                { nombre_status = string.Empty; }

                // Incia validacion del estatus
                switch (nombre_status)
                {
                    case "CAN":
                        Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_ERROR_DEPURACION);
                        break;
                    case "PRO":
                        actualiza = ActualizaCalendario(IdCalendarioDepuracion);
                        if (actualiza)
                        { Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_CANCELACION_DEPURACION); }
                        else
                        { Alert.Show(Concretec.Pedidos.Constantes.Mensajes.MSG_ACT_FALLO); }
                        break;
                }
                llenagrid();
                break;
        }
    }
    protected void grdPedidos_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }

    protected void grdPedidos_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {

    }

    protected void grdPedidos_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {

    }

    protected void llenagrid()
    {
        List<CalendarioDepuracion> lista = new List<CalendarioDepuracion>();
        AgentePedidos ap = new AgentePedidos();
        lista = ap.BuscaCalendarioDepuracion();

        grdPedidos.DataSource = lista;
        grdPedidos.DataBind();
    }

    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btnnuevo_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btnCalendarizacion_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Depuracion.aspx");
    }
}