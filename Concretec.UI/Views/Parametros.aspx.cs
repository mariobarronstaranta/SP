using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;


public partial class Views_Parametros : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AgenteParametros Agente = new AgenteParametros();
        List<Parametros> Lista = new List<Parametros>();
        
        List<Usuario> Login = new List<Usuario>();
        Login =   (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
        if (Login == null)
        {
            Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_DEFAULT);
        }
        else
        {
            this.rgParametros.DataSource = Lista;
            rgParametros.DataBind();
        }
    }
    protected void rgParametrs_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }

    protected void rgParametrs_ItemCommand(object source, GridCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Parametros _p = new Parametros();
            cargaEntidad(_p, e);

            Session.Add("Parametros", _p);

            Response.Redirect("~/Views/CatalogoParametros.aspx");

        }
    }

    private void cargaEntidad(Parametros P, GridCommandEventArgs e)
    {
        P.IDParametro = e.Item.Cells[2].Text;
        P.Valor = e.Item.Cells[3].Text;
        P.Descripcion = e.Item.Cells[4].Text;

    }
    
    protected void rgdUnidades_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {

    }
}