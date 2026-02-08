using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;
using Telerik.Web.UI;

public partial class Views_RptConsumos : System.Web.UI.Page
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

    public string IdCiudad
    { get { return cboCiudades.SelectedValue.ToString(); } }

    #endregion
   #region Load Page     
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
                    inicio.SelectedDate = Hoy.AddDays(-1);
                    fin.SelectedDate = Hoy;
                    CargaCiudades();
                    //CargaCombos(Login[0].Ciudad);
                    //cboEstatus.SelectedValue = "3";
                    //cboPlanta.SelectedValue = DatosUsuario.IDPlanta.ToString();
                    cargaGrid(IdCiudad);
                }

                

            }
        }
 
        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.Page.MasterPageFile = Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP].ToString();
        }
   




    #endregion

   #region Methods
        private void cargaGrid(string CveCiudad)
        {
            AgentePedidos ap = new AgentePedidos();
            List<Consumo> listaconsumo = new List<Consumo>();
            grdPedidos.DataSource = null;

            if (inicio.DateInput.Text.ToString() != "")
            {

                listaconsumo = ap.rptconsumos(this.IdCiudad,
                                                DateTime.Parse(inicio.DateInput.Text.ToString().Substring(0, 10)),
                                                DateTime.Parse(fin.DateInput.Text.ToString().Substring(0, 10)));
            }


            grdPedidos.DataSource = listaconsumo;
            grdPedidos.DataBind();
        }
   #endregion
        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        List<Usuario> Login = new List<Usuario>();
        Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];

        if (DateTime.Parse(inicio.DateInput.Text.Substring(0, 10)) > DateTime.Parse(fin.DateInput.Text.Substring(0, 10)))
        {
            Response.Write("<script>alert('La Fecha Inicio debe de ser menor a la Final')</script>");
        }
        else
        {
            if (Login == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                cargaGrid(this.IdCiudad);
            }

        }
    }

        private void CargaCiudades()
        {
            cboCiudades.Items.Clear();
            AgenteCiudades ac = new AgenteCiudades();
            List<Ciudad> lc = new List<Ciudad>();

            lc = ac.ObtenerCiudades();
            ListItem item = new ListItem();
            item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
            item.Value = "-1";
            cboCiudades.Items.Add(item);
            foreach (Ciudad c in lc)
            {
                item = new ListItem();
                item.Text = c.Descripcion;
                item.Value = c.CveCiudad.ToString();
                cboCiudades.Items.Add(item);
            }

        }

        protected void btnExportar_Click(object sender, ImageClickEventArgs e)
        {
            ConfigureExport();
            grdPedidos.MasterTableView.ExportToExcel();
        }

        public void ConfigureExport()
        {
            grdPedidos.ExportSettings.ExportOnlyData = true;
            grdPedidos.ExportSettings.IgnorePaging = true;
            grdPedidos.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Biff;


        }
        protected void grdPedidos_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {

                case "Detalle":
                    string url = "RptConsumosDetalle.aspx?CveCiudad=" + this.cboCiudades.SelectedValue.ToString() + "&Desde=" + inicio.DateInput.Text.ToString().Substring(0, 10) + "&Hasta=" + fin.DateInput.Text.ToString().Substring(0, 10) + "&Planta=" + e.Item.Cells[3].Text;
                    Response.Write("<script>window.open('" + url + "','_blank');</script>");break;


            }



        }
}