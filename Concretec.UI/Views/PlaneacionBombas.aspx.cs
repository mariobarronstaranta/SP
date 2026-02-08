using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;

public partial class Views_PlaneacionBombas : System.Web.UI.Page
{
    private DateTime startDate = DateTime.Today;

    public DateTime FechaCompromiso
    { get { return DateTime.Parse(DTfecha.DateInput.Text.Substring(0, 10)); } }

    //2011-12-30-08-00
    public string HoraInicio
    { get { return DThorainicio.DateInput.Text.Substring(11, 5).Replace("-", ":"); } }

    public string HoraFin
    { get { return DThorafin.DateInput.Text.Substring(11, 5).Replace("-", ":"); ; } }

    public Usuario DatosUsuario
    {
        get
        {
            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
            return Login[0];
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            if (DatosUsuario.Ciudad == "")
            {
                Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
            }
            CargaPlantas(DatosUsuario.Ciudad);

            if (Request.QueryString["Fecha"] == null)
            { DTfecha.SelectedDate = startDate; }
            else
            { DTfecha.SelectedDate = DateTime.Parse(Request.QueryString["Fecha"]); }

            if (Request.QueryString["HoraInicio"] == null)
            { DThorainicio.SelectedDate = DateTime.Parse("2011-12-12 07:00:00"); }
            else
            { DThorainicio.SelectedDate = DateTime.Parse("2011-12-12" + " " + Request.QueryString["HoraInicio"]); }

            if (Request.QueryString["HoraFin"] == null)
            { DThorafin.SelectedDate = DateTime.Parse("2011-12-12 19:00:00"); }
            else
            { DThorafin.SelectedDate = DateTime.Parse("2011-12-12" + " " + Request.QueryString["HoraFin"]); }

        }
    }

    private void CargaPlantas(string CveCiudad)
    {
        AgentePlantas au = new AgentePlantas();
        List<Planta> planta = new List<Planta>();

        planta = au.ObtenerPlantasBombeo();
        var plantas = from pp in planta
                      where pp.Ciudad == DatosUsuario.Ciudad 
                      select new { pp.IDPlanta, pp.Nombre };

        ListItem item = new ListItem();
        item.Text = "(Todas)";
        item.Value = "-1";
        item.Selected = true;
        this.selplantas.Items.Add(item);

        foreach (var a in plantas)
        {
            item = new ListItem();
            item.Text = a.Nombre;
            item.Value = a.IDPlanta.ToString();
            this.selplantas.Items.Add(item);
        }
    }

    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        string Listaads = "";
        int[] seleccionados = selplantas.GetSelectedIndices();
        foreach (int valor in seleccionados)
        {
            Listaads = Listaads + selplantas.Items[valor].Value + "|";
        }

        Response.Redirect("PlaneacionBombas.aspx?Fecha=" + FechaCompromiso.Date.ToShortDateString() + "&HoraInicio=" + HoraInicio + "&HoraFin=" + HoraFin + "&Plantas=" + Listaads);
    }
    protected void DThorainicio_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {

    }
}