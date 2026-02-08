<%@ page language="C#" autoeventwireup="true" inherits="Views_Remision_Print_Laser" CodeFile="Remision_Print_Laser.aspx.cs"%>
<%@ Import Namespace="Concretec.Pedidos.BE" %>
<%@ Import Namespace="Concretec.Agentes" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
<title>Sistema de Programaci&oacute;n de Pedidos</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="/Shared/estilos.css" rel="stylesheet" type="text/css">

<style type="text/css">

    .style1 
    {
        font-family: arial;
        font-size: 12px;
        font-weight: normal;
        text-align : left;
        color: #000000;
    }
.style2
    {
        height: 19px;
    }

    .style3
    {
        font-family: arial;
        font-size: 12px;
        font-weight: normal;
        text-align : left;
        color: #000000;
        height: 16px;
    }

    .auto-style1 {
        width: 30px;
    }

    .auto-style3 {
        width: 100px;
    }

</style>
</head>
<script type="text/jscript" language="javascript">
    function imprimir() {
        if (confirm("¿Desea imprimir la remisión?")) {
            window.print();
        }
    }
</script>
<body onLoad="imprimir();">
    <form id="form1" runat="server" style="margin: 0px 0px 0px 0px;">
<table width="850" border="0"  cellpadding="0" cellspacing="0">
  <tr>
    <td class="auto-style1">&nbsp;</td>
    <td width="850">
        <table width="272"  border="0" align="right" cellpadding="0" cellspacing="0" class="style1">
            <tr> 
              <td width="272" height="100" colspan="3" valign="center"><div align="center"> <font size="3">
                  <asp:Literal ID="numPedido" runat="server"></asp:Literal>
              </font> </div></td>
            </tr>
            <tr> 
              <td colspan="3" class="style1" height="50" width="272"></td>
            </tr>
            <tr valign="top"> 
              <td width="100" height="20" class="style1" style="text-align: left" valign="center"><div align="right"> <font size="3">
                  <asp:Literal ID="FechaRemision" runat="server"></asp:Literal>
              </font> </div></td>
              <td width="140" height="20" class="style1" style="text-align: left" valign="center"><div align="right"> <font size="3"> 
                  <asp:Literal ID="NombrePlanta" runat="server"></asp:Literal>
              </font></div></td>
              <td width="32" height="20" class="style1" style="text-align: left"><div align="right"> <font size="3"> 
                 
              </font></div></td>
            </tr>
            </table>
       </td>
  </tr>
</table>

<br/>
<br/>
<table width="800"  border="0" cellpadding="0" cellspacing="0" class="style1">
  <tr>
    <td width="50" height="10">&nbsp;</td> 
    <td width="375" height="10">&nbsp;</td>
    <td width="345" height="10" style="text-align: left">&nbsp;</td>
  </tr>
  <tr>
    <td width="50" height="10">&nbsp;</td> 
    <td width="375" height="10">&nbsp;</td>
    <td width="345" height="10" style="text-align: left">&nbsp;</td>
  </tr>
  <tr>
    <td class="style1">&nbsp;</td> 
    <td class="style1" style="text-align: left"><span class="style1"><font size="2"> 
      <asp:Literal ID="NombreCliente" runat="server"></asp:Literal>
      </font></span></td>
    <td class="style1" style="text-align: left"><span class="style1"><font size="2"> 
      <asp:Literal ID="NombreObra" runat="server"></asp:Literal>
      </font></span></td>
  </tr>
  <tr>
    <td class="style3"></td> 
    <td height="30" style="text-align: left" ><span class="style1" ><font size="2"> 
      <asp:Literal ID="DireccionCliente" runat="server"></asp:Literal><%=" "%><asp:Literal ID="ColoniaCliente" runat="server"></asp:Literal>
      </font></span></td>
    <td height="30" style="text-align: left"><span class="style1" ><font size="2"> 
      <asp:Literal ID="DireccionObra" runat="server"></asp:Literal>
      </font></span></td>
  </tr>
  <tr>
    <td class="style1">&nbsp;</td> 
    <td class="style1" style="text-align: left"><span class="style1"><font size="2"> 
      <asp:Literal ID="Telefono" runat="server"></asp:Literal>
      </font></span></td>
    <td class="style1" style="text-align: left"><span class="style1"><font size="2"> 
      <asp:Literal ID="EntreCallesObra" runat="server"></asp:Literal>
        </font></span></td>
  </tr>
  <tr>
    <td ></td> 
    <td class="style2"><span class="style1"><font size="2"> 
        <%="  " %>
      </font></span></td>
    <td class="style2" style="text-align: right"><span class="style1"><font size="2"> 
        <%="  " %>
      <asp:Literal ID="CPObra" runat="server"></asp:Literal>
        </font></span></td>
  </tr>



</table>  
<table   border="0"  cellpadding="0" cellspacing="0" class="style1" >
  <tr> 
    <td colspan="7"><span class="style1"></span></td>
  </tr>
  <tr>
    <td width="121" height="50" class="style1" align="right"></td>
    <td width="121" height="50" class="style1" align="right"></td>
    <td width="121" height="50" class="style1" align="right"></td>
    <td width="121" height="50" class="style1" align="right"></td>
    <td width="121" height="50" class="style1" align="right"></td>
    <td width="121" height="50" class="style1" align="right"></td>
    <td width="121" height="50" class="style1" align="right"></td>
  </tr>
  <tr>
    <td  width="121" style="font-size: medium" align="right">
        <asp:Literal ID="litPedido" runat="server"></asp:Literal>
      </td> 
    <td  width="121" style="font-size: medium" align="right">
        <asp:Literal ID="litPdo" runat="server"></asp:Literal>
      </td>
    <td  width="121" style="font-size: medium"  align="right">
        <asp:Literal ID="lituso" runat="server"></asp:Literal>
      </td>
    <td  width="121">&nbsp;</td>
    <td  width="121" style="text-align: right; font-size: medium;">
        <asp:Literal ID="litMPedidos" runat="server"></asp:Literal>
      </td>
    <td  width="121" style="text-align: right; font-size: medium;">
        <asp:Literal ID="litMSurt" runat="server"></asp:Literal>
      </td>
      <td style="text-align: center; font-size: medium;" class="auto-style3">
          <asp:Literal ID="LitXSurt" runat="server"></asp:Literal>
      </td>
  </tr>
</table>
<br/>
<table width="720" border="0"  cellpadding="0" cellspacing="0" class="style1">
  <tr>
    <td width="29" height="35">&nbsp;</td> 
    <td width="180" height="35"><span class="style1"></span></td>
    <td colspan="2" height="35"><span class="style1"></span></td>
  </tr>
    <% 

      AgentePedidos _agentepedidos = new AgentePedidos();
      List<PedidoProducto> lista = new List<PedidoProducto>();
      lista = _agentepedidos.BuscarProductosRemision(Request.QueryString["IDRemision"].ToString(), int.Parse(Request.QueryString["IDPedido"]));

      StringBuilder SB = new StringBuilder();
      StringBuilder SB_2 = new StringBuilder();
      StringBuilder SB_3 = new StringBuilder();
      int elementos = lista.Count;
      elementos = 15 - elementos;

      string nombreunidad = Request.QueryString["Unidad"].ToString();
      bool tieneunidadbombeo = false;
      tieneunidadbombeo = nombreunidad.Contains("BP");
      
      foreach (PedidoProducto entidad in lista)
      {
          SB.Append("<tr class='texto'>");
          SB.Append("<td>&nbsp;</td>");
          SB.Append("<td height='1'><span class='style1'><font size='3'>");
          if(entidad.CargaTotal!= 0 )
          {
            SB.Append(entidad.CargaTotal.ToString() + " <span class=texto>m<sup>3</sup></span>");
          }
          else
          {
              SB.Append(" <span class=texto></span>");
          }
          SB.Append("</font></span></td>");
          SB.Append("<td width='137' height='1'><span class='style1'><font size='3'>");
          SB.Append(entidad.ClaveProducto.ToString()); 
          SB.Append("</font></span></td>");
          SB.Append("<td width='354' height='1'><span class='style1'><font size='3'>");
          SB.Append(entidad.NombreProducto);
          SB.Append("</font></span></td></tr>");
      }

      Response.Write(SB.ToString());

      if (tieneunidadbombeo)
      {
          SB_3.Append("<tr class='texto'>");
          SB_3.Append("<td>&nbsp;</td>");
          SB_3.Append("<td height='1'><span class='style1'><font size='3'>");
          SB_3.Append(" <span class=texto></span>");
          SB_3.Append("</font></span></td>");
          SB_3.Append("<td width='137' height='1'><span class='style1'><font size='3'>");
          SB_3.Append("");
          SB_3.Append("</font></span></td>");
          SB_3.Append("<td width='354' height='1'><span class='style1'><font size='3'>");
          SB_3.Append("SERVICIO DE BOMBEO");
          SB_3.Append("</font></span></td></tr>");
      }

      Response.Write(SB_3.ToString());
      
      if (elementos > 0)
      { 
      for (int i = 1; i <= elementos; i++)
            {
                SB_2.Append("<tr class='texto'>");
                SB_2.Append("<td>&nbsp;</td>");
                SB_2.Append("<td height='20'><span class='style1'><font size='3'>");
                SB_2.Append("<span class=texto></span><BR/>");
                SB_2.Append("</font></span></td>");
                SB_2.Append("<td width='137' height='20'><span class='style1'><font size='3'>");
                SB_2.Append("</font></span></td>");
                SB_2.Append("<td width='354' height='20'><span class='style1'><font size='3'>");
                SB_2.Append("</font></span></td></tr>");
            }

      Response.Write(SB_2.ToString());
      }   
  %>

</table>

<br />
<table width="850" border="0"  cellpadding="0" cellspacing="0" class="style1">

    <tr  class='texto' valign="middle">
        <td height='120' style="text-align: center; font-size: medium;">
            <asp:Literal ID="LitComentarios" runat="server"></asp:Literal>
        </td>
    </tr>

</table>
        
<table width="850" border="0"  cellpadding="0" cellspacing="0" class="style1">
<tr>
    <td colspan="2" height="75">.</td>
    <td colspan="2" height="75">&nbsp;</td>
    <td height="45" height="75">&nbsp;</td>
    <td height="45" height="75">&nbsp;</td>
    <td height="45" height="75">&nbsp;</td>
    <td height="45" height="75">&nbsp;</td>
    <td height="45" height="75">&nbsp;</td>
    <td height="45">&nbsp;</td>
</tr>
<tr>
    <td height="50">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td rowspan="2" width="65" valign="bottom" style="text-align: right">
        <asp:Literal ID="litUnidad" runat="server"></asp:Literal>
    </td>
    <td rowspan="2" width="65" valign="bottom" colspan="2" align="center">
        <asp:Literal ID="litOperador" runat="server"></asp:Literal>
    </td>
    
    <td></td>
    <td></td>
    <td></td>
</tr>
<tr>
    <td height="50" width="65" valign="bottom" style="text-align: right">
        <asp:Literal ID="litsalida" runat="server"></asp:Literal>
    </td>
    <td height="50" width="65"></td>
    <td height="50" width="55"></td>
    <td height="50" width="60"></td>
    <td height="50" width="65" colspan="3" style="text-align: right" valign="bottom">
        <asp:Literal ID="litConformidad" runat="server"></asp:Literal>
    </td>
</tr>
</table>
    </form>
</body>
</html>


