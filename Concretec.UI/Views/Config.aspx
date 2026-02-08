<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="Config.aspx.cs" Inherits="Views_Config" %>

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

        <td style="text-align: center">
            <a href="Ciudades.aspx"><img src="../MetroImages/BotonCiudades.png" width="120" height="120" onMouseOver="MouseRollover(this,'BotonCiudades_Over.png')" onMouseOut="MouseOut(this,'BotonCiudades.png')"/></a>
        </td>

          <td style="text-align: center">
            <a href="ComisionesViaje.aspx"><img src="../MetroImages/ComisionViaje.png" width="120" height="120" onMouseOver="MouseRollover(this,'ComisionViaje_Over.png')" onMouseOut="MouseOut(this,'ComisionViaje.png')"/></a>
        </td>
      <td style="text-align: center">
            <a href="Contingencia.aspx"><img src="../MetroImages/Contingencias.png" width="120" height="120" onMouseOver="MouseRollover(this,'Contingencias_Over.png')" onMouseOut="MouseOut(this,'Contingencias.png')"/></a>
       </td>

          <td style="text-align: center">
            <a href="BitacoraError.aspx"><img src="../MetroImages/Log.png" width="120" height="120" onMouseOver="MouseRollover(this,'Log_Over.png')" onMouseOut="MouseOut(this,'Log.png')"/></a>
        </td>

      <td style="text-align: center"><a href="CapturaFacturas.aspx"><img src="../MetroImages/CaptFacturas.png" width="120" height="120" onMouseOver="MouseRollover(this,'CaptFacturas_Over.png')" onMouseOut="MouseOut(this,'CaptFacturas.png')"/></a></td>
      <td style="text-align: center"><a href="Combustibles.aspx"><img src="../MetroImages/TanqueCombustible.png" width="120" height="120" onMouseOver="MouseRollover(this,'TanqueCombustible.png')" onMouseOut="MouseOut(this,'TanqueCombustible.png')"/></a></td>
      <td style="text-align: center"><a href="AdmonCombustibles.aspx"><img src="../MetroImages/MovsCombustible.png" width="120" height="120"   onMouseOver="MouseRollover(this,'MovsCombustible.png')" onMouseOut="MouseOut(this,'MovsCombustible.png')"/></a></td>
      <td style="text-align: center"><a href="ReasignaUnidad.aspx"><img src="../MetroImages/ReasignaUnidades.png" width="120" height="120"   onMouseOver="MouseRollover(this,'ReasignaUnidades.png')" onMouseOut="MouseOut(this,'ReasignaUnidades.png')"/></a></td>
               
      </tr>
        <tr>
            <td style="text-align: center"><a href="CambioCR.aspx"><img src="../MetroImages/CambiaUnidades.png" width="120" height="120"   onMouseOver="MouseRollover(this,'CambiaUnidades.png')" onMouseOut="MouseOut(this,'CambiaUnidades.png')"/></a></td>
            <td style="text-align: center"><a href="Cheques.aspx"><img src="../MetroImages/Cheques.png" width="120" height="120"   onMouseOver="MouseRollover(this,'Cheques.png')" onMouseOut="MouseOut(this,'Cheques.png')"/></a></td>
            <td style="text-align: center"><a href="Cablibracion.aspx"><img src="../MetroImages/Calibracion.png" width="120" height="120"   onMouseOver="MouseRollover(this,'Calibracion_over.png')" onMouseOut="MouseOut(this,'Calibracion.png')"/></a></td>
        </tr>

        <tr runat="server" id="trhidden" visible="false">
            
            <td style="text-align: center"><a href="Depuracion.aspx"><img src="../MetroImages/EliminaPedidos.png" width="120" height="120"   onMouseOver="MouseRollover(this,'EliminaPedidos.png')" onMouseOut="MouseOut(this,'EliminaPedidos.png')"/></a></td>
        </tr>
     
    </table>

    <p>&nbsp;</p>
</asp:Content>

