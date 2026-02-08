<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Contabilidad.master" AutoEventWireup="true" CodeFile="ConsultaPedidoAutorizar.aspx.cs" Inherits="Views_ConsultaPedidoAutorizar" %>
<%@ Import Namespace="Concretec.Pedidos.BE" %>
<%@ Import Namespace="Concretec.Agentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">

    <table align="center" width="80%" border="0">
    <tr>
    <td></td>
    <td style="text-align: center">
        <asp:ImageButton ID="imgcancelar" runat="server" Height="35px" 
            ImageUrl="~/Imagenes/regresar.jpg" Width="90px" 
            onclick="imgcancelar_Click" />
        <asp:ImageButton ID="imgDenegar" runat="server" Height="35px" 
            ImageUrl="~/Imagenes/Denegar.jpg" Width="90px" 
            onclick="imgDenegar_Click" />
        <asp:ImageButton ID="imgAutorizar" runat="server" Height="35px" 
            ImageUrl="~/Imagenes/Autorizar.jpg" Width="90px" 
            onclick="imgAutorizar_Click" />
        </td>
    <td></td>
    </tr>
    </table>
    <br />
    <table align="right" width="30%" border="0">
        <tr>
            <td class="formLabelReporte">
                Num Pedido
            </td>
            <td class="formLabelReporte">
                Fecha
            </td>
        </tr>
        <tr>
            <td class="formValueReporte">
                <asp:Literal ID="numPedido" runat="server"></asp:Literal>
            </td>
            <td class="formValueReporte">
                <asp:Literal ID="FechaCompromiso" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>

    <table align="left" width="50%" border="0">
        <tr>
            <td class="formLabelReporte">
                Limite de Credito
            </td>
            <td class="formLabelReporte">
                Saldo Actual
            </td>
            <td class="formLabelReporte">
                Credito Solicitado
            </td>
        </tr>
        <tr>
            <td class="formValueReporte">
                <asp:Literal ID="limcredito" runat="server"></asp:Literal>
            </td>
            <td class="formValueReporte">
                <asp:Literal ID="saldoactual" runat="server"></asp:Literal>
            </td>
            <td class="formValueReporte">
                <asp:Literal ID="Solicitado" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>

    <br />
    <br />
    <br />
    <table align="center" width="80%" border="0">
        <tr>
            <td class="formLabelReporte">
                Datos Cliente
            </td>
            <td class="formLabelReporte">
                Datos Obra
            </td>
        </tr>
        <tr>
            <td class="formValueReporte" >
                <asp:Literal ID="datoscliente" runat="server"></asp:Literal>
                <br />
                <asp:Literal ID="dircliente" runat="server"></asp:Literal>
                <br />
                <asp:Literal ID="ColCliente" runat="server"></asp:Literal>
                <br />
                <asp:Literal ID="CdCliente" runat="server"></asp:Literal>
            </td>
            <td class="formValueReporte" >
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
        <td class="formLabelReporte" style="width:20%">Cantidad</td>
        <td class="formLabelReporte">Producto</td>
     </tr>
     <%
         List<PedidoProducto> Lista = new List<PedidoProducto>();
         AgentePedidos Agente = new AgentePedidos();
         Lista = Agente.BuscarProductosPedido(int.Parse(Request.QueryString["IDPedido"]));

         foreach (PedidoProducto pp in Lista)
         {
             Response.Write("<tr>");
             Response.Write("<td class=formValueReporte>" + pp.CargaTotal.ToString()  +"</td>");
             Response.Write("<td class=formValueReporte>" + pp.NombreProducto + "</td>");
             Response.Write("</tr>");
         }
     %>
    </table>

    <br />
    <br />
    <br />
    
    </form>
</asp:Content>

