using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;

public partial class Views_RptConsumosDetalle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AgenteViajes agente = new AgenteViajes();
            List<ViajeDetalle> lista = agente.RptConsumosDetalle(
                        DateTime.Parse(Request.QueryString["Desde"].ToString()), 
                        DateTime.Parse(Request.QueryString["Hasta"].ToString()),
                        Request.QueryString["CveCiudad"].ToString(),
                        Request.QueryString["Planta"].ToString());
            this.grdPedidos.DataSource = lista;
            this.grdPedidos.DataBind();
        }
    }
}