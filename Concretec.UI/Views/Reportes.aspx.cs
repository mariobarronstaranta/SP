using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;

public partial class Views_Reportes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            CargaCiudades();
        }
    }
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {

    }

    #region llenarFiltros

    private void CargaCombosInicio()
    {
        CargaCiudades();
    }

    private void CargaCiudades()
    {
        cboCiudades.Items.Clear();
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();

        lc = ac.ObtenerCiudades();
        Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem();
        item.Text = "(Todas)";
        item.Value = "-1";
        cboCiudades.Items.Add(item);
        foreach (Ciudad c in lc)
        {
            item = new Telerik.Web.UI.RadComboBoxItem();
            item.Text = c.Descripcion;
            item.Value = c.CveCiudad;
            cboCiudades.Items.Add(item);
        }

    }

    private void cargaplantas()
    {
        cboPlanta.Items.Clear();
        AgentePlantas ap = new AgentePlantas();
        List<Planta> ListaPlantas = new List<Planta>();
        ListaPlantas = ap.ObtenerPlantas();

        var plantas = from pp in ListaPlantas
                      where pp.Ciudad == cboCiudades.SelectedValue
                      select new { pp.Nombre, pp.IDPlanta };

        Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = "-1";
        this.cboPlanta.Items.Add(item);

        foreach (var p in plantas)
        {
            item = new Telerik.Web.UI.RadComboBoxItem();
            item.Text = p.Nombre;
            item.Value = p.IDPlanta.ToString();
            this.cboPlanta.Items.Add(item);

        }
    }

    private void CargaClientes()
    {
        AgenteClientes au = new AgenteClientes();
        List<Cliente> cliente_ = new List<Cliente>();
        cliente_ = au.ObtenerClientesConObra(cboCiudades.SelectedValue.ToString());
        cboCliente.Items.Clear();

        var query = from cc in cliente_
                    select new { cc.NombreCompleto, cc.ClaveCliente };

        if (this.cboPlanta.SelectedValue != "-1")
        {
            query = from cc in cliente_
                    where cc.Planta == cboPlanta.Text
                    select new { cc.NombreCompleto, cc.ClaveCliente };

        }

        Telerik.Web.UI.RadComboBoxItem item = new Telerik.Web.UI.RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = "-1";
        this.cboCliente.Items.Add(item);
        var cientesfiltrados = query.Distinct();

        foreach (var a in cientesfiltrados)
        {
            item = new Telerik.Web.UI.RadComboBoxItem();
            item.Text = a.NombreCompleto;
            item.Value = a.ClaveCliente;
            this.cboCliente.Items.Add(item);

        }

    }


    #endregion

    protected void cboCiudades_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        cargaplantas();
        CargaClientes();
    }
    protected void cboPlanta_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        CargaClientes();
    }
}