<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true"
    CodeFile="ConsultaPedido.aspx.cs" Inherits="Views_ConsultaPedido" %>
<%@ Import Namespace="Concretec.Pedidos.BE" %>
<%@ Import Namespace="Concretec.Agentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">
    <table align="right" width="60%" border="0">
        <tr>
            <td class="tdCeldaEdicion" bgcolor="#D7D7D7">Registrador Por</td>
            <td class="tdCeldaEdicion" bgcolor="#D7D7D7">Capturado el Dia</td>
            <td class="tdCeldaEdicion" bgcolor="#D7D7D7">Num Pedido</td>
            <td class="tdCeldaEdicion" bgcolor="#D7D7D7">Fecha Compromiso</td>
            <td class="tdCeldaEdicion" bgcolor="#D7D7D7">Hora Compromiso</td>
            <td class="tdCeldaEdicion"  rowspan="2">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/Imagenes/Impresion.png" Width="64px" 
                    onclick="ImageButton1_Click" Visible="False" />
            </td>
            <td class="tdCeldaEdicion"  rowspan="2">
                <asp:ImageButton ID="ImprimirFF" runat="server" 
                    ImageUrl="~/Imagenes/Impresion_FF.png" Width="64px" 
                    onclick="ImprimirFF_Click" />
            </td>
        </tr>
        <tr>
            
            <td class="tdCeldaEdicion">
                <asp:Literal ID="lit_nombreusuario" runat="server"></asp:Literal>
            </td>
            <td class="tdCeldaEdicion">
                <asp:Literal ID="lit_fechacreado" runat="server"></asp:Literal>
            </td>
            <td class="tdCeldaEdicion">
                <asp:Literal ID="numPedido" runat="server"></asp:Literal>
            </td>
            <td class="tdCeldaEdicion">
                <asp:Literal ID="FechaCompromiso" runat="server"></asp:Literal>
            </td>
            <td class="tdCeldaEdicion"><asp:Literal ID="lit_HoraCompromiso" runat="server"></asp:Literal></td>
            <td class="tdCeldaEdicion"  colspan="2">
                
            </td>
        </tr>
        
    </table>
    <br />
    <br />
    <br />
    <table align="center" width="80%" border="0">
        <tr>
            <td class="tdCeldaEdicion" bgcolor="#D7D7D7">
                Datos Cliente
            </td>
            <td class="tdCeldaEdicion" bgcolor="#D7D7D7">
                Datos Obra
            </td>
        </tr>
        <tr>
            <td class="tdCeldaEdicion" >
                <asp:Literal ID="datoscliente" runat="server"></asp:Literal>
                <br />
                <asp:Literal ID="dircliente" runat="server"></asp:Literal>
                <br />
                <asp:Literal ID="ColCliente" runat="server"></asp:Literal>
                <br />
                <asp:Literal ID="CdCliente" runat="server"></asp:Literal>
            </td>
            <td class="tdCeldaEdicion" >
                <asp:Literal ID="datosobra" runat="server"></asp:Literal>
                <br />
                <asp:Literal ID="dirobra" runat="server"></asp:Literal>
                <br />
                <asp:Literal ID="CdObra" runat="server"></asp:Literal>
                <br />
                <br />
            </td>
        </tr>
    </table>
     <br />
 
    <table align="center" width="80%" border="0">
    <tr>
        <td class="tdCeldaEdicion" bgcolor="#D7D7D7" style="width:20%">Cantidad</td>
        <td class="tdCeldaEdicion" bgcolor="#D7D7D7">Producto</td>
     </tr>
     <%
         List<PedidoProducto> Lista = new List<PedidoProducto>();
         AgentePedidos Agente = new AgentePedidos();
         Lista = Agente.BuscarProductosPedido(int.Parse(Request.QueryString["IDPedido"]));

         foreach (PedidoProducto pp in Lista)
         {
             Response.Write("<tr>");
             Response.Write("<td class=tdCeldaEdicion>" + pp.CargaTotal.ToString()  +"</td>");
             Response.Write("<td class=tdCeldaEdicion>" + pp.NombreProducto + "</td>");
             Response.Write("</tr>");
         }
     %>
    </table>

    <br />
    <table align="center" width="80%" border="0">
     <tr><th colspan="7">Datos de Viaje Programados</th></tr>
    <tr>
        <td class="tdCeldaEdicion" bgcolor="#D7D7D7" >Viaje</td>
        <td class="tdCeldaEdicion" bgcolor="#D7D7D7" >Cve Viaje</td>
        <td class="tdCeldaEdicion" bgcolor="#D7D7D7" >Planta</td>
        <td class="tdCeldaEdicion" bgcolor="#D7D7D7">Unidad</td>
        <td class="tdCeldaEdicion" bgcolor="#D7D7D7">Fecha</td>
        <td class="tdCeldaEdicion" bgcolor="#D7D7D7" >H. Salida</td>
        <td class="tdCeldaEdicion" bgcolor="#D7D7D7">H. Regreso</td>
        <td class="tdCeldaEdicion" bgcolor="#D7D7D7" >Carga</td>
        <td class="tdCeldaEdicion" bgcolor="#D7D7D7" >H. Compromiso</td>
     </tr>
     <%
         List<PedidoViaje> ListaVP = new List<PedidoViaje>();
         Agente = new AgentePedidos();
         ListaVP = Agente.BuscarViajesPedido(int.Parse(Request.QueryString["IDPedido"]));
                       
         
         int iviaje = 0;
         foreach (PedidoViaje _ListaVP in ListaVP)
         {
             iviaje = iviaje + 1;
             Response.Write("<tr>");
             Response.Write("<td class=tdCeldaEdicion>" + iviaje.ToString() + "</td>");
             Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.IDViaje.ToString() + "</td>");
             Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.CvePlanta + "</td>");
             Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.IDClaveUnidad + "</td>");
             Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.FechaInicio.ToShortDateString() + "</td>");
             Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.HoraInicio + "</td>");
             Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.HoraFin + "</td>");
             Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.CargaViaje.ToString() + "</td>");
             Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.HoraCompromiso.ToString() + "</td>");
             Response.Write("</tr>");
         }
     %>
       
     </table>
        <br /><br />
        <table>
            <tr><th colspan="8">Datos de Viaje Remisionados</th></tr>
            <tr>
                <td class="tdCeldaEdicion" bgcolor="#D7D7D7" >Viaje</td>
                <td class="tdCeldaEdicion" bgcolor="#D7D7D7" >Remision</td>
                <td class="tdCeldaEdicion" bgcolor="#D7D7D7" >Planta</td>
                <td class="tdCeldaEdicion" bgcolor="#D7D7D7">Unidad</td>
                <td class="tdCeldaEdicion" bgcolor="#D7D7D7" >Carga</td>
                <td class="tdCeldaEdicion" bgcolor="#D7D7D7" >H. Salida</td>
                <td class="tdCeldaEdicion" bgcolor="#D7D7D7">H. Llegada Obra</td>
                <td class="tdCeldaEdicion" bgcolor="#D7D7D7">H. Llegada Planta</td>
                <td class="tdCeldaEdicion" bgcolor="#D7D7D7">H. Compromiso</td>
            </tr>
            <% 
                Agente = new AgentePedidos();
                ListaVP = new List<PedidoViaje>();
                Agente = new AgentePedidos();
                ListaVP = Agente.LeerCierreViajesPedido(int.Parse(Request.QueryString["IDpedido"]));

                iviaje = 0;
                foreach (PedidoViaje _ListaVP in ListaVP)
                {
                    iviaje = iviaje + 1;
                     Response.Write("<tr>");
                     Response.Write("<td class=tdCeldaEdicion>" + iviaje.ToString() + "</td>");
                     Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.Remision + "</td>");
                     Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.CvePlanta + "</td>");
                     Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.IDClaveUnidad + "</td>");
                     Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.CargaViaje.ToString() + "</td>");
                     Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.HoraInicio + "</td>");
                     Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.HoraLlegadaObra.ToString() + "</td>");
                     Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.HoraFin.ToString() + "</td>");
                    Response.Write("<td class=tdCeldaEdicion>" + _ListaVP.HoraCompromiso.ToString() + "</td>");
                     Response.Write("</tr>");
                }

            %>
        </table>
    </form>
</asp:Content>
