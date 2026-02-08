using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;

public partial class Views_CambioPassword : System.Web.UI.Page
{
    private string CveUsuario
    {
        get
        { return this.txtUserName.Text.ToString(); }
    }

    private string OldPassword
    {
        get
        { return this.txtPassword.Text.ToString(); }
    }

    private string NewPassword
    {
        get
        { return this.txtPassword0.Text.ToString(); }
    }

    private string ConfirmaPassword
    {
        get
        { return this.txtPassword1.Text.ToString(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmdCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    bool ValidaPasswordAnterior()
    {
        bool salida = false;
        AgenteUsuarios Agente = new AgenteUsuarios();
        List<Usuario> DatosUsuario = new List<Usuario>();
        DatosUsuario = Agente.ValidaUsuario(CveUsuario, OldPassword);
        if (DatosUsuario.Count() == 0)
        {   salida = false;   }
        else
        {   salida = true;    }
        return salida;
    }
   
    protected void cmdAceptar_Click(object sender, EventArgs e)
    {
        AgenteUsuarios AU = new AgenteUsuarios();
        // Realizar una funcion para verificar que el password anterior sea el que esta en la base de datos
        // En caso de que no sea se debe de regresar a la pagina con un mensaje de que el password no es correcto
        bool ValidaUsuario = ValidaPasswordAnterior();
        if (ValidaUsuario == true)
        {
            //Aqui va el proceo para actuaizar los datos
            //1- Primero hay que validar que el password y la confirmacion sean iguales
            if (ConfirmaPassword == NewPassword)
            {
               bool Respuesta = AU.ActualizaPassword(txtUserName.Text,txtPassword.Text, txtPassword0.Text);
               if (Respuesta == true)
               {
                   cmdCancelar.Text = Concretec.Pedidos.Constantes.Etiquetas.REGRESAR;
                   cmdAceptar.Visible = false;
                   lblMensaje.Text = "El cambio de password se ha realizado con Exito";}
                else
                {lblMensaje.Text = "Hubo problemas al realizar el cambio de password, contacte a su administrador";}
            }
            else
            {  lblMensaje.Text = "Confirme el nuevo password y su confirmacion, hay diferencia"; }
 
        }
        else
        { lblMensaje.Text = "El password actual no corresponde, intente de nuevo"; }
    }
}