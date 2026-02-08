using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Agentes;
using Concretec.Pedidos.BE;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            this.txtPassword.Text = string.Empty;
            this.txtUserName.Text = string.Empty;
        }
  }
    
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string UserName = txtUserName.Text;
        string Password = txtPassword.Text;
        AgenteUsuarios Agente = new AgenteUsuarios();
        List<Usuario> DatosUsuario = new List<Usuario>();
        DatosUsuario = Agente.ValidaUsuario(UserName, Password);
        if (DatosUsuario.Count() == 0)
        {
            Alert.Show(Concretec.Pedidos.Constantes.Mensajes.USUARIO_FALLIDO);
            lblmsg.Text = Concretec.Pedidos.Constantes.Mensajes.USUARIO_FALLIDO;
        }
        else
        {
            //Claves de los Perfiles
            // 1- Administrador
            // 2- Contabilidad
            // 3- Programador
            Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO] = DatosUsuario;
            List<Usuario> Login = new List<Usuario>();
            Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
            int Perfil = 0;
            Perfil = Login[0].IDPerfil;

            switch (Perfil)
            {
                case 1:
                    Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP] = Concretec.Pedidos.Constantes.Etiquetas.TAG_MP_ADMON;
                    break;
                case 2:
                    Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP] = Concretec.Pedidos.Constantes.Etiquetas.TAG_MP_CONTABILIDAD;
                    break;
                case 3:
                    Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP] = Concretec.Pedidos.Constantes.Etiquetas.TAG_MP_OPERADOR;
                    break;
                case 4:
                    Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP] = Concretec.Pedidos.Constantes.Etiquetas.TAG_MP_VENDEDOR;
                    break;
                case 5:
                    Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP] = Concretec.Pedidos.Constantes.Etiquetas.TAG_MP_JEFEPLANTA;
                    break;
                case 6:
                    Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP] = Concretec.Pedidos.Constantes.Etiquetas.TAG_MP_CONSULTA;
                    break;
                case 7:
                    Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP] = Concretec.Pedidos.Constantes.Etiquetas.TAG_MP_ADMON_PLANTAS;
                    break;
                case 8:
                    Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP] = Concretec.Pedidos.Constantes.Etiquetas.TAG_MP_ADMON_PERSONAL;
                    break;
                case 9:
                    Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP] = Concretec.Pedidos.Constantes.Etiquetas.TAG_MP_CARTA_PORTE;
                    break;
                default:
                    Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_MP] = Concretec.Pedidos.Constantes.Etiquetas.TAG_MP_CONSULTA;
                    break;
            }
            if (Perfil == 7)
            {
                Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_CALIBRACION);
            }
            else if (Perfil == 8)
            {
                Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_PERSONAL);
            }
            else if (Perfil == 9)
            {
                Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_PERSONAL);
            }
            else
            {
                Response.Redirect(Concretec.Pedidos.Constantes.Etiquetas.TAG_REL_PAG_LCLIENTES);
            }
            
        }
    }
}