using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Concretec.Pedidos.BE;

public partial class Shared_MasterPage : System.Web.UI.MasterPage
{
    private List<Usuario> DatosUsuario
    {
        get
        { return (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO]; }
    }

    
    
}
