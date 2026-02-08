using Concretec.Agentes;
using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Views_RptTransmisionCB2 : System.Web.UI.Page
{
    #region properties
    public Usuario DatosUsuario
    {
        get
        {
            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
            return Login[0];
        }
    }


    #endregion
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
            if (IsPostBack != true)
            {
                DateTime Hoy = DateTime.Now.Date;
                fin.SelectedDate = Hoy;

                CargaGrid();
                LimpiaGridDetalle();
            }
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        CargaGrid();
        LimpiaGridDetalle();
    }

    private void CargaGrid()
    {
        List<LogCb2> Datos = new List<LogCb2>();
        AgenteCB2 agente = new AgenteCB2();
        Datos = agente.ConsultaConexiones(DateTime.Parse(fin.DateInput.Text.ToString().Substring(0, 10)));
        grdPedidos.DataSource = Datos;
        grdPedidos.DataBind();
    }

    private void LimpiaGridDetalle()
    {
        List<LogCb2> datos = new List<LogCb2>();
        this.gridDetalle.DataSource = datos;
        this.gridDetalle.DataBind();
    }

    protected void grdPedidos_ItemCommand(object sender, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {

            case "Detalle":
                string ciudad = e.Item.Cells[2].Text;
                string planta = e.Item.Cells[3].Text;
                List<LogCb2> datos = new List<LogCb2>();
                AgenteCB2 agente = new AgenteCB2();
                datos = agente.ConsultaErrorConexiones(DateTime.Parse(fin.DateInput.Text.ToString().Substring(0, 10)), ciudad, planta);
                
                this.gridDetalle.DataSource = datos;
                this.gridDetalle.DataBind();
                break;
        }
    }

}