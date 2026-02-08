<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pedidos_remision_Print.aspx.cs" Inherits="Views_pedidos_remision_Print" %>
<%@ Import Namespace="Concretec.Pedidos.BE" %>
<%@ Import Namespace="Concretec.Agentes" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
<title>Sistema de Programaci&oacute;n de Pedidos</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="/Shared/estilos.css" rel="stylesheet" type="text/css">
<script language="javascript" src="/scripts/funciones.js" type="text/jscript"></script>
<style type="text/css">
<!--
.style1 {font-family: arial}
-->
</style>
</head>
<script type="text/jscript" language="javascript">
    function imprimir() 
    {
        if (confirm("¿Desea imprimir la remisión?")) 
        {
            window.print();
        }
    }
</script>
<body onLoad="imprimir();">
    <form id="form1" runat="server">
<table width="720" border="0"  cellpadding="0" cellspacing="0">
  <tr>
    <td width="30">&nbsp;</td>
    <td width="670">
    <table width="272" height="144" border="0" align="right" cellpadding="0" cellspacing="0" class="texto style1">
        <tr> 
          <td width="272" height="62" colspan="2" valign="bottom"><div align="center"> <font size="3">
              <asp:Literal ID="numPedido" runat="server"></asp:Literal>
          </font> </div></td>
        </tr>
        <tr> 
          <td colspan="2" class="texto" height="10" width="272"></td>
        </tr>
        
        <tr valign="top"> 
          <td width="272" height="20" class="texto" style="text-align: right"><div align="right"> <font size="2">
              <asp:Literal ID="FechaRemision" runat="server"></asp:Literal>
          </font> </div></td>
          <td width="272" height="20" class="texto" style="text-align: right"><div align="right"> <font size="5"> 
              <asp:Literal ID="NombrePlanta" runat="server"></asp:Literal>
          </font></div></td>
        </tr>
        <tr> 
          <td height="17" class="texto2" width="272"></td>
          <td width="272" height="17" valign="top" class="texto"><div align="center"> <font size="2"> 
              <asp:Literal ID="FechaCompromiso" runat="server"></asp:Literal>
          </font></div></td>
        </tr>
        <tr> 
          <td class="texto2" height="18" width="272"></td>
          <td width="272" height="18" valign="top" class="texto"><div align="center"> <font size="3"> 
              <asp:Literal ID="HoraPrometida" runat="server"></asp:Literal>
          </font></div></td>
        </tr>
    </table></td>
  </tr>
</table>
<br/>
<table width="720" border="0"  cellpadding="0" cellspacing="0" class="texto">
  <tr>
    <td width="10">&nbsp;</td> 
    <td width="365">&nbsp;</td>
    <td width="345">&nbsp;</td>
  </tr>
  <tr>
    <td class="texto">&nbsp;</td> 
    <td class="texto"><span class="style1"><font size="2"> 
      <asp:Literal ID="NombreCliente" runat="server"></asp:Literal>
      </font></span></td>
    <td class="texto"><span class="style1"><font size="2"> 
      <asp:Literal ID="NombreObra" runat="server"></asp:Literal>
      </font></span></td>
  </tr>
  <tr>
    <td class="texto">&nbsp;</td> 
    <td class="texto"><span class="style1"><font size="2"> 
      <asp:Literal ID="DireccionCliente" runat="server"></asp:Literal><%=" "%><asp:Literal ID="ColoniaCliente" runat="server"></asp:Literal>
      </font></span></td>
    <td class="texto"><span class="style1"><font size="2"> 
      <asp:Literal ID="DireccionObra" runat="server"></asp:Literal>
      </font></span></td>
  </tr>
  <tr>
    <td class="texto">&nbsp;</td> 
    <td class="texto"><span class="style1"><font size="2"> 
      <asp:Literal ID="Telefono" runat="server"></asp:Literal>
      </font></span></td>
    <td class="texto"><span class="style1"><font size="2"><strong>Entre:</strong> 
      <asp:Literal ID="EntreCallesObra" runat="server"></asp:Literal>
      </font></span></td>
  </tr>
  <tr>
    <td class="texto">&nbsp;</td> 
    <td class="texto"><span class="style1"><font size="2"> 
      <asp:Literal ID="CPObra" runat="server"></asp:Literal><%="  " %><asp:Literal ID="PoblacionObra" runat="server"></asp:Literal>
      </font></span></td>
    <td class="texto"><span class="style1"><font size="2"> 
        <%="  " %>
      </font></span></td>
  </tr>
  <tr>
    <td class="texto">&nbsp;</td> 
    <td class="texto"><span class="style1"><font size="2"><strong>No. de obra:</strong> 
      <asp:Literal ID="ClaveObra" runat="server"></asp:Literal>
      </font></span></td>
    <td class="texto"><span class="style1"><font size="2"><strong>Solicit&oacute;:</strong> 
      <asp:Literal ID="Solicito" runat="server"></asp:Literal>
      </font></span></td>
  </tr>
  <tr>
    <td class="texto">&nbsp;</td> 
    <td class="texto"><span class="style1"><font size="2"><strong>No. de cliente:</strong> 
      <asp:Literal ID="ClaveCliente" runat="server"></asp:Literal>
      </font></span></td>
    <td class="texto"><span class="style1"><font size="2"><strong>Autoriz&oacute;:</strong> 
      <asp:Literal ID="Autorizo" runat="server" Visible="False"></asp:Literal>
      </font></span></td>
  </tr>
  <tr>
    <td class="texto">&nbsp;</td> 
    <td class="texto"><span class="style1"><font size="2"><strong>Ventas:</strong> 
      <asp:Literal ID="Vendedor" runat="server"></asp:Literal>
      </font></span></td>
    <td class="texto"><span class="style1"><font size="2"><strong>Recibe:</strong> 
    <asp:Literal ID="Recibe" runat="server"></asp:Literal>
      </font></span></td>
  </tr>
</table>  
<table width="720" border="0"  cellpadding="0" cellspacing="0" class="texto">
  <tr> 
    <td colspan="6"><span class="style1"></span></td>
  </tr>
  <tr>
    <td width="29">&nbsp;</td> 
    <td width="149" height="43"><span class="style1"></span></td>
    <td width="242"><span class="style1"></span></td>
    <td width="90"><span class="style1"></span></td>
    <td width="68"><span class="style1"></span></td>
    <td width="142"><span class="style1"></span></td>
  </tr>
  <tr>
    <td>&nbsp;</td> 
    <td><span class="style1"><font size="2"> 
      <asp:Literal ID="Distancia" runat="server"></asp:Literal>
      </font></span></td>
    <td><span class="style1"><font size="2"> 
      <asp:Literal ID="UsoObra" runat="server"></asp:Literal>
      </font></span></td>
    <td><span class="style1"><font size="2"> 
      <asp:Literal ID="Roji" runat="server"></asp:Literal>
      </font></span></td>
    <td><span class="style1"><font size="2"> 
      <asp:Literal ID="Hrs" runat="server"></asp:Literal>
      </font></span></td>
    <td><span class="style1"><font size="2"> 
      <asp:Literal ID="Colado" runat="server"></asp:Literal>
      </font></span></td>
  </tr>
</table>
<br/>
<table width="720" border="0"  cellpadding="0" cellspacing="0" class="texto" height="14">
  <tr>
    <td width="29">&nbsp;</td> 
    <td width="180" height="14"><span class="style1"></span></td>
    <td colspan="2" height="14"><span class="style1"></span></td>
  </tr>
    <% 

      AgentePedidos _agentepedidos = new AgentePedidos();
      List<PedidoProducto> lista = new List<PedidoProducto>();
      lista = _agentepedidos.BuscarProductosPedido(int.Parse(Request.QueryString["IDPedido"]));

      StringBuilder SB = new StringBuilder();
      StringBuilder SB_2 = new StringBuilder();
      int elementos = lista.Count;
      elementos = 3 - elementos;
      
      foreach (PedidoProducto entidad in lista)
      {
          SB.Append("<tr class='texto'>");
          SB.Append("<td>&nbsp;</td>");
          SB.Append("<td height='1'><span class='style1'><font size='3'>");
          SB.Append(entidad.CargaTotal.ToString() + " <span class=texto>m<sup>3</sup></span>");
          SB.Append("</font></span></td>");
          SB.Append("<td width='137' height='1'><span class='style1'><font size='3'>");
          SB.Append(entidad.ClaveProducto.ToString()); 
          SB.Append("</font></span></td>");
          SB.Append("<td width='354' height='1'><span class='style1'><font size='2'>");
          SB.Append(entidad.NombreProducto);
          SB.Append("</font></span></td></tr>");
      }

      Response.Write(SB.ToString());

      if (elementos > 0)
      { 
      for (int i = 1; i <= elementos; i++)
            {
                SB_2.Append("<tr class='texto'>");
                SB_2.Append("<td>&nbsp;</td>");
                SB_2.Append("<td height='1'><span class='style1'><font size='3'>");
                SB_2.Append("<span class=texto></span><BR/>");
                SB_2.Append("</font></span></td>");
                SB_2.Append("<td width='137' height='1'><span class='style1'><font size='3'>");
                SB_2.Append("</font></span></td>");
                SB_2.Append("<td width='354' height='1'><span class='style1'><font size='2'>");
                SB_2.Append("</font></span></td></tr>");
            }

      Response.Write(SB_2.ToString());
      }   
  %>

</table>
<table width="720" border="0"  cellpadding="0" cellspacing="0" class="texto">
                        <tr>
    <td width="700">
                                <p style="text-align: center"></p>
                            </td>
                        </tr>
  <tr> 
    <td class="texto"><div align="center"><span class="style1"><font size="4">
      <asp:Literal ID="ObsPedido" runat="server"></asp:Literal>
    </font></span></div></td>
  </tr>
</table>
<br />
&nbsp;<table width="720" border="0"  cellpadding="0" cellspacing="0" class="texto" height="109">
  <tr> 
    <td colspan="3" width="190" height="11"></td>
  </tr>
  <tr> 
    <td width="52" height="80">&nbsp;</td>
    <td width="62" height="80">&nbsp;</td>
    <td width="55" height="80">&nbsp;</td>
    <td width="90" height="80">&nbsp;</td>
    <td width="50" height="80">&nbsp;</td>
    <td width="200" height="80">&nbsp;</td>
    <td width="160" height="80"><font size="1">&nbsp; </font>
    <p></p>    </td>
  </tr>
        <% 
      StringBuilder SB_Viajes = new StringBuilder();
      _agentepedidos = new AgentePedidos();
      List<PedidoViaje> _listaViajes = new List<PedidoViaje>();
      _listaViajes = _agentepedidos.BuscarViajesPedido(int.Parse(Request.QueryString["IDPedido"]));
      float _acumulado = 0;
      int elementosLV = _listaViajes.Count();

      foreach (PedidoViaje elemento in _listaViajes)
      {
          _acumulado = _acumulado + float.Parse(elemento.CargaViaje.ToString());
          
          SB_Viajes.Append("<tr valign='top' class='texto'>");
          SB_Viajes.Append("<td width='62' height='1'><span class='style1'><font size='2'>");
          SB_Viajes.Append(elemento.Remision);
          SB_Viajes.Append("</font></span></td>");
          SB_Viajes.Append("<td width='62' height='1'><span class='style1'><font size='2'>");
          if (elemento.CargaViaje != 0)
          {
              SB_Viajes.Append(elemento.CargaViaje.ToString() + " m<sup>3</sup>");
          }
          else
          {
              SB_Viajes.Append("");
          }
          SB_Viajes.Append("</font></span></td>");
          SB_Viajes.Append("<td width='90' height='1'><span class='style1'><font size='2'>");
          if (elemento.CargaViaje != 0)
          {
              SB_Viajes.Append(_acumulado.ToString() + " m<sup>3</sup>");// AQUI va el volumen acumulado
          }
          SB_Viajes.Append("</font></span></td>");
          SB_Viajes.Append("<td width='90' height='1'><span class='style1'><font size='2'>");
          SB_Viajes.Append(elemento.HoraInicio + " Hrs"); // Hay que calcular la hora en la que va a estar en la Obra
          SB_Viajes.Append("</font></span></td>");
          SB_Viajes.Append("<td width='50' height='1'><span class='style1'><font size='2'>");
          SB_Viajes.Append(elemento.IDClaveUnidad);
          SB_Viajes.Append("</font></span></td>");
          SB_Viajes.Append("<td width='200' height='1'><span class='style1'><font size='1'>");
          SB_Viajes.Append(elemento.Operador);
          SB_Viajes.Append("</font></span></td>");
          SB_Viajes.Append("<td width='160' height='1'><span class='style1'><font size='1'>");
          SB_Viajes.Append("&nbsp;" + elemento.Observaciones + "</tr>");
      }

      Response.Write(SB_Viajes.ToString());

      if (elementosLV <= 12)
      {
          SB_Viajes = new StringBuilder();
          for (int i = 1; i <= (12 - elementosLV); i++)
          {
              SB_Viajes.Append("<tr valign='top' class='texto'>");
                  SB_Viajes.Append("<td width='62' height='25'><span class='style1'><font size='2'>");
                  SB_Viajes.Append("</font></span></td>");
                  SB_Viajes.Append("<td width='62' height='25'><span class='style1'><font size='2'>");
                  SB_Viajes.Append("</font></span></td>");
                  SB_Viajes.Append("<td width='90' height='25'><span class='style1'><font size='2'>");
                  SB_Viajes.Append("</font></span></td>");
                  SB_Viajes.Append("<td width='90' height='25'><span class='style1'><font size='2'>");
                  SB_Viajes.Append("</font></span></td>");
                  SB_Viajes.Append("<td width='50' height='25'><span class='style1'><font size='2'>");
                  SB_Viajes.Append("</font></span></td>");
                  SB_Viajes.Append("<td width='200' height='25'><span class='style1'><font size='1'>");
                  SB_Viajes.Append("</font></span></td>");
                  SB_Viajes.Append("<td width='160' height='25'><span class='style1'><font size='1'>");
              SB_Viajes.Append("</tr>");
          }

          Response.Write(SB_Viajes.ToString());
      }
  %>

  <br /><br />
</table>
<table width="720" border="0"  cellpadding="0" cellspacing="0" class="texto">

    <tr valign='top' class='texto'>
        <td>
            <asp:Literal ID="LitComentarios" runat="server"></asp:Literal>
        </td>
    </tr>

</table>
    </form>
</body>
</html>
