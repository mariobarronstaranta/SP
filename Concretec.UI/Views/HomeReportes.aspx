<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="HomeReportes.aspx.cs" Inherits="Views_HomeReportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%">
        <tr>
            <td colspan="2" style="text-align: center">
                <h2>
                    Reportes</h2>
            </td>
        </tr>
        </table>
<br /><br />
    <table  border="0" align="center">
      <tr>

      <td style="text-align: center">
            <a href="rptPlanta.aspx" ><img id="img_plantas" src="../MetroImages/Reporte_Plantas.png" onMouseOver="MouseRollover(this,'Reporte_Plantas_Over.png')" onMouseOut="MouseOut(this,'Reporte_Plantas.png')"/></a>
        </td>

      <td style="text-align: center">
            <a href="rptVendedor.aspx"><img id="img_vendedores" src="../MetroImages/Reporte_Vendedores.png" width="120" height="120" onMouseOver="MouseRollover(this,'Reporte_Vendedores_Over.png')" onMouseOut="MouseOut(this,'Reporte_Vendedores.png')"/></a>
        </td>
        <td style="text-align: center">
            <a href="rptPedidos.aspx"><img id="img_pedidos" src="../MetroImages/Reporte_Pedidos.png" width="120" height="120" onMouseOver="MouseRollover(this,'Reporte_Pedidos_Over.png')" onMouseOut="MouseOut(this,'Reporte_Pedidos.png')"/></a>
        </td>
        <td style="text-align: center">
            <a href="rptProductos.aspx"><img id="img_productos" src="../MetroImages/Reporte_Productos.png" width="120" height="120" onMouseOver="MouseRollover(this,'Reporte_Productos_Over.png')" onMouseOut="MouseOut(this,'Reporte_Productos.png')"/></a>
        </td>
        <td style="text-align: center">
            <a href="rptObras.aspx"><img id="img_obras" src="../MetroImages/Reporte_Obras.png" width="120" height="120" onMouseOver="MouseRollover(this,'Reporte_Obras_Over.png')" onMouseOut="MouseOut(this,'Reporte_Obras.png')"/></a>
        </td>

          <td style="text-align: center">
            <a href="rptComisionCR.aspx" target="blank"><img id="img_comparativo" src="../MetroImages/Reporte_Comparativo.png" width="120" height="120" onMouseOver="MouseRollover(this,'Reporte_Comparativo_Over.png')" onMouseOut="MouseOut(this,'Reporte_Comparativo.png')"/></a>
        </td>


          <td style="text-align: center">
            <a href="RptConsumos.aspx"><img id="img_consumos" src="../MetroImages/Reporte_Consumos.png" width="120" height="120" onMouseOver="MouseRollover(this,'Reporte_Consumos_Over.png')" onMouseOut="MouseOut(this,'Reporte_Consumos.png')"/></a>
        </td>
      </tr>
     
        <tr>
            <td style="text-align: center"><a href="rptProgramadores.aspx" ><img id="img_programadores" src="../MetroImages/Reporte_Programadores.png" width="120" height="120" onMouseOver="MouseRollover(this,'Reporte_Programadores_over.png')" onMouseOut="MouseOut(this,'Reporte_Programadores.png')"/></a></td>
            <td style="text-align: center"><a href="RptTransmisionCB2.aspx" ><img id="img_transmision" src="../MetroImages/Rpt_TransmisionArchivos.png" width="120" height="120" onMouseOver="MouseRollover(this,'Rpt_TransmisionArchivos_over.png')" onMouseOut="MouseOut(this,'Rpt_TransmisionArchivos.png')"/></a></td>
            <td style="text-align: center"><a href="PedidosDelDia.aspx" ><img id="img_deldia" src="../MetroImages/Pedidos_Dia.png" width="120" height="120" onMouseOver="MouseRollover(this,'Pedidos_Dia_On.png')" onMouseOut="MouseOut(this,'Pedidos_Dia.png')"/></a></td>
            <td style="text-align: center"><a href="rptRemisiones.aspx" ><img id="img_deldia" src="../MetroImages/rptRemisiones.png" width="120" height="120" onMouseOver="MouseRollover(this,'rptRemisiones.png')" onMouseOut="MouseOut(this,'rptRemisiones.png')"/></a></td>

            <td style="text-align: center"><a href="RptURLObras.aspx" ><img id="img_deldia" src="../MetroImages/URLObras.png" width="120" height="120" onMouseOver="MouseRollover(this,'URLObras.png')" onMouseOut="MouseOut(this,'URLObras.png')"/></a></td>
        </tr>

    </table>
    <p>&nbsp;</p>
</asp:Content>

