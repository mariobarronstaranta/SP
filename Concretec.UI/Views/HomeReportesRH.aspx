<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/RH.master" AutoEventWireup="true" CodeFile="HomeReportesRH.aspx.cs" Inherits="Views_HomeReportesRH" %>

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
            <a href="rptComisionCR.aspx" target="blank"><img id="img_comparativo" src="../MetroImages/Reporte_Comparativo.png" width="120" height="120" onMouseOver="MouseRollover(this,'Reporte_Comparativo_Over.png')" onMouseOut="MouseOut(this,'Reporte_Comparativo.png')"/></a>
        </td>

      </tr>
     


    </table>
    <p>&nbsp;</p>
</asp:Content>

