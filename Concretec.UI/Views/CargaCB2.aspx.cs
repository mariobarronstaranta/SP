using Concretec.Agentes;
using Concretec.Pedidos.BE;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Views_CargaCB2 : System.Web.UI.Page
{
    const int MaxTotalBytes = 10485760; // 10 MB
    long totalBytes;

    protected void Page_Load(object sender, EventArgs e)
    {
        CargaCiudades();
    }
    private void CargaCiudades()
    {
        RadComboBox1.Items.Clear();
        AgenteCiudades ac = new AgenteCiudades();
        List<Ciudad> lc = new List<Ciudad>();

        lc = ac.ObtenerCiudades();
        RadComboBoxItem item = new RadComboBoxItem();
        item.Text = Concretec.Pedidos.Constantes.Mensajes.CBO_SELECCIONE;
        item.Value = Concretec.Pedidos.Constantes.Etiquetas.TAG_MINUS_ONE;
        RadComboBox1.Items.Add(item);
        foreach (Ciudad c in lc)
        {
            item = new RadComboBoxItem();
            item.Text = c.Descripcion;
            item.Value = c.CveCiudad.ToString();
            RadComboBox1.Items.Add(item);
        }

    }

    protected void RadAsyncUpload1_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
    {
            //BtnSubmit.Visible = false;
            //RefreshButton.Visible = true;
            RadAsyncUpload1.Visible = false;
 
            var liItem = new HtmlGenericControl("li");
            liItem.InnerText = e.File.FileName;
            
 
            if (totalBytes < MaxTotalBytes)
            {
                // Total bytes limit has not been reached, accept the file
                e.IsValid = true;
                totalBytes += e.File.ContentLength;
            }
            else
            {
                // Limit reached, discard the file
                e.IsValid = false;
            }
 
            //if (e.IsValid)
            //{
 
            //    ValidFiles.Visible = true;
            //    ValidFilesList.Controls.AddAt(0, liItem);
 
            //}
            //else
            //{
                 
            //    InvalidFiles.Visible = true;
            //    InValidFilesList.Controls.AddAt(0, liItem);
            //}
        }
         
        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Request.RawUrl);
        }
    }
