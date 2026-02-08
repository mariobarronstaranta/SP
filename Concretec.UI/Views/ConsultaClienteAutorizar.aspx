<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Contabilidad.master" AutoEventWireup="true" CodeFile="ConsultaClienteAutorizar.aspx.cs" Inherits="Views_ConsultaClienteAutorizar" %>
<%@ Import Namespace="Concretec.Pedidos.BE" %>
<%@ Import Namespace="Concretec.Agentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
<table align="center" width="85%" border="0">
    <tr>
    <td></td>
    <td style="text-align: right">
        <asp:ImageButton ID="imgcancelar" runat="server" Height="35px"  
            ImageUrl="~/Imagenes/regresar.jpg" Width="90px"   onclick="imgcancelar_Click" 
            CausesValidation="False" />
        <asp:ImageButton ID="imgDenegar" runat="server" Height="35px"   ImageUrl="~/Imagenes/Denegar.jpg" Width="90px"  onclick="imgDenegar_Click" CausesValidation="False" />
        <asp:ImageButton ID="imgAutorizar" runat="server" Height="35px"   ImageUrl="~/Imagenes/Autorizar.jpg" Width="90px"  onclick="imgAutorizar_Click" />
    </td>
    <td></td>
    </tr>
    </table>
    <br />

<table width="85%" border="0" cellspacing="0" cellpadding="0" align=center>
  <tr>
    <td bgcolor="#D7D7D7" class="tdCeldaGrisEdicionCierre">Nombre</td>
    <td class="tdCeldaEdicion" align=left style="text-align: left">
        <asp:Literal ID="txtNombre" runat="server"></asp:Literal>
      </td>
    <td bgcolor="#D7D7D7" class="tdCeldaGrisEdicionCierre">RFC</td>
    <td class="tdCeldaEdicion" style="text-align: left">
        <asp:Literal ID="txtRFC" runat="server"></asp:Literal>
      </td>
  </tr>
  <tr>
    <td bgcolor="#D7D7D7" class="tdCeldaGrisEdicionCierre">Direccion</td>
    <td class="tdCeldaEdicion" style="text-align: left">
        <asp:Literal ID="txtDireccion" runat="server"></asp:Literal>
      </td>
    <td bgcolor="#D7D7D7" class="tdCeldaGrisEdicionCierre">Colonia</td>
    <td class="tdCeldaEdicion" style="text-align: left">
        <asp:Literal ID="txtColonia" runat="server"></asp:Literal>
      </td>
  </tr>
  <tr>
    <td bgcolor="#D7D7D7" class="tdCeldaGrisEdicionCierre">Poblacion</td>
    <td class="tdCeldaEdicion" style="text-align: left">
        <asp:Literal ID="txtPoblacion" runat="server"></asp:Literal>
      </td>
    <td bgcolor="#D7D7D7" class="tdCeldaGrisEdicionCierre">CP</td>
    <td class="tdCeldaEdicion" style="text-align: left">
        <asp:Literal ID="txtCP" runat="server"></asp:Literal>
      </td>
  </tr>
  <tr>
    <td bgcolor="#D7D7D7" class="tdCeldaGrisEdicionCierre">Telefono</td>
    <td class="tdCeldaEdicion" style="text-align: left">
        <asp:Literal ID="txtTelefono" runat="server"></asp:Literal>
      </td>
    <td bgcolor="#D7D7D7" class="tdCeldaGrisEdicionCierre">Fax</td>
    <td class="tdCeldaEdicion" style="text-align: left">
        <asp:Literal ID="txtFax" runat="server"></asp:Literal>
      </td>
  </tr>
  <tr>
    <td bgcolor="#D7D7D7" class="tdCeldaGrisEdicionCierre">Correo</td>
    <td class="tdCeldaEdicion" style="text-align: left">
        <asp:Literal ID="txtCorreo" runat="server"></asp:Literal>
      </td>
    <td bgcolor="#D7D7D7" class="tdCeldaGrisEdicionCierre">Ultima Compra</td>
    <td class="tdCeldaEdicion" style="text-align: left">$
        <asp:Literal ID="txtUltima" runat="server"></asp:Literal>
      </td>
  </tr>
  <tr>
    <td bgcolor="#D7D7D7" class="tdCeldaGrisEdicionCierre">Descuento</td>
    <td class="tdCeldaEdicion" style="text-align: left">
        <asp:Literal ID="txtDescuento" runat="server"></asp:Literal>
      &nbsp;%</td>
    <td bgcolor="#D7D7D7" class="tdCeldaGrisEdicionCierre">Estatus</td>
    <td class="tdCeldaEdicion" style="text-align: left">
        <asp:Literal ID="LitEstatus" runat="server"></asp:Literal>
      </td>
  </tr>
</table>


<br /><br /><br />

    <table align="center" width="85%" border="0">
        <tr>
            <td class="tdCeldaEdicion" bgcolor="#D7D7D7">
                Limite de Credito
            </td>
            <td class="tdCeldaEdicion" bgcolor="#D7D7D7">
                Saldo Actual
            </td>
            <td class="tdCeldaEdicion" bgcolor="#D7D7D7">
                Credito Solicitado
            </td>
            <td class="tdCeldaEdicion" bgcolor="#D7D7D7">
                Lim. Credito Autorizado
            </td>
            <td class="tdCeldaEdicion" bgcolor="#D7D7D7">
                Saldo Actualizado
            </td>
        </tr>
        <tr>
            <td class="tdCeldaEdicion">
                <asp:Literal ID="limcredito" runat="server"></asp:Literal>
            </td>
            <td class="tdCeldaEdicion">
                <asp:Literal ID="saldoactual" runat="server"></asp:Literal>
            </td>
            <td class="tdCeldaEdicion">
                <asp:Literal ID="Solicitado" runat="server"></asp:Literal>
            </td>
            <td class="tdCeldaEdicion">
                <asp:TextBox ID="txtLimCredito" runat="server" style="text-align: left" 
                    Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtLimCredito" 
                    ErrorMessage="El nuevo limite de credito es  obligatorio">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="ComparaSaldos" runat="server" ControlToCompare="txtSaldoNuevo" ControlToValidate="txtLimCredito" ErrorMessage="El Credito autorizado debe de ser mayor al saldo actualizado" Operator="GreaterThan">*</asp:CompareValidator>
            </td>
            <td class="tdCeldaEdicion">
                <asp:TextBox ID="txtSaldoNuevo" runat="server" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtSaldoNuevo" ErrorMessage="El nuevo Saldo es  obligatorio">*</asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>

    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
    Font-Bold="True" Font-Names="Segoe UI" Font-Size="Small" />
    <br />
    <br />
     <br />
 
</form>

    <script type="text/javascript">
        function AcceptNum(evt) {

            var nav4 = window.Event ? true : false;
            var key = nav4 ? evt.which : evt.keyCode;
            return (key <= 13 || (key >= 46 && key <= 57) || key == 44);
        }
    </script>
</asp:Content>

