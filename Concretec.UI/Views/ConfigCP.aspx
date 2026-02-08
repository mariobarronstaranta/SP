<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MP_CP.master" AutoEventWireup="true" CodeFile="ConfigCP.aspx.cs" Inherits="Views_ConfigCP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="95%">
        <tr>
            <td colspan="2" style="text-align: center">
                <h2>Configuracion de Sistema</h2>
            </td>
        </tr>
        </table>


    <table  border="0" align="center">
      <tr>

            <td style="text-align: center"><a href="CambioCR.aspx"><img src="../MetroImages/CambiaUnidades.png" width="120" height="120"   onMouseOver="MouseRollover(this,'CambiaUnidades.png')" onMouseOut="MouseOut(this,'CambiaUnidades.png')"/></a></td>
            <td style="text-align: center"><a href="ReasignaUnidad.aspx"><img src="../MetroImages/ReasignaUnidades.png" width="120" height="120"   onMouseOver="MouseRollover(this,'ReasignaUnidades.png')" onMouseOut="MouseOut(this,'ReasignaUnidades.png')"/></a></td>
               
      </tr>


        <tr runat="server" id="trhidden" visible="false">
            
            <td style="text-align: center"><a href="Depuracion.aspx"><img src="../MetroImages/EliminaPedidos.png" width="120" height="120"   onMouseOver="MouseRollover(this,'EliminaPedidos.png')" onMouseOut="MouseOut(this,'EliminaPedidos.png')"/></a></td>
        </tr>
     
    </table>

    <p>&nbsp;</p>
</asp:Content>


