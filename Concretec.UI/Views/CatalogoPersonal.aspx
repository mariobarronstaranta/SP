<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="CatalogoPersonal.aspx.cs" Inherits="Views_CatalogoPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
    <span style="text-align:center"><H2> Personal </H2></span>
    <br /><br />
   <table width="80%" border="0" align="center">
       <tr>
           <td class="formLabel" >ID Empleado</td>
           <td class="formValue"><asp:TextBox ID="txtID" runat="server" MaxLength="20" CssClass="txtgradiente" ReadOnly="true"></asp:TextBox></td>

           <td></td>
           <td class="formValue"></td>

       </tr>
  <tr>
    <td class="formLabel" >Clave</td>
    <td class="formValue">
        <asp:TextBox ID="txtclave" runat="server" MaxLength="20" CssClass="txtgradiente"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rv_ValidaClave" runat="server" 
            ControlToValidate="txtclave" ErrorMessage="La clave de empleado es requerida">*</asp:RequiredFieldValidator>
      </td>
    <td class="formLabel">Ciudad</td>
    <td class="formValue">
        <asp:DropDownList ID="cbociudad" runat="server" CssClass="select">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td class="formLabel" >Nombre</td>
    <td class="formValue"> 
        <asp:TextBox ID="txtnombre" runat="server"  MaxLength="25" CssClass="txtgradiente"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rv_Nombre" runat="server" 
            ControlToValidate="txtnombre" 
            ErrorMessage="El nombre del empleado es requerido">*</asp:RequiredFieldValidator>
      </td>
    <td class="formLabel">Planta</td>
    <td class="formValue">
        <asp:DropDownList ID="cboplanta" runat="server"  CssClass="select">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td class="formLabel">Apellido Paterno</td>
    <td class="formValue">
        <asp:TextBox ID="txtapaterno" runat="server" MaxLength="25" CssClass="txtgradiente"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rv_AP" runat="server" 
            ControlToValidate="txtapaterno" ErrorMessage="El Apellido Paterno es requerido">*</asp:RequiredFieldValidator>
      </td>
    <td class="formLabel">Interno&nbsp; / Externo</td>
    <td class="formValue">
        <asp:DropDownList ID="cbotipo" runat="server"  
            onselectedindexchanged="cbotipo_SelectedIndexChanged" CssClass="select">
            <asp:ListItem Value="-1">(Seleccione)</asp:ListItem>
            <asp:ListItem>Interno</asp:ListItem>
            <asp:ListItem>Externo</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td class="formLabel">Apellido Materno</td>
    <td class="formValue">
        <asp:TextBox ID="txtamaterno" runat="server" MaxLength="25" CssClass="txtgradiente"></asp:TextBox>
      </td>
    <td class="formLabel">Estatus</td>
    <td class="formValue">
        <asp:DropDownList ID="cboEstatus" runat="server"  CssClass="select">
            <asp:ListItem Value="-1">(Seleccione)</asp:ListItem>
            <asp:ListItem>Alta</asp:ListItem>
            <asp:ListItem>Baja</asp:ListItem>
            <asp:ListItem>Reingreso</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td class="formLabel">Puesto</td>
    <td class="formValue">
        <asp:DropDownList ID="cbopuesto" runat="server"  
            AutoPostBack="True" CssClass="select">
            <asp:ListItem  Value=0>(Seleccione)</asp:ListItem>
            <asp:ListItem Value="Asesor Comercial">Asesor Comercial</asp:ListItem>
            <asp:ListItem Value="Ayudante de Bomba">Ayudante de Bomba</asp:ListItem>
            <asp:ListItem Value="Coordinador Comercial">Coordinador Comercial</asp:ListItem>
            <asp:ListItem Value="Jefe de Planta">Jefe de Planta</asp:ListItem>
            <asp:ListItem Value="Operador Cargador Frontal">Operador Cargador Frontal</asp:ListItem>
            <asp:ListItem Value="Operador de Camion Bomba">Operador de Camion Bomba</asp:ListItem>
            <asp:ListItem Value="Operador de Camion Revolvedor">Operador de Camion Revolvedor</asp:ListItem>
            <asp:ListItem Value="Operador Payloder">Operador Payloder</asp:ListItem>
            <asp:ListItem Value="Vendedor">Vendedor</asp:ListItem>
        </asp:DropDownList>
      </td>
    <td class="formLabel" >&nbsp;</td>
    <td class="formValue">&nbsp;</td>
  </tr>
  <tr>
    <td class="formLabel" >Tipo Personal</td>
    <td class="formValue">
        <asp:DropDownList ID="cbotipopersonal" runat="server" CssClass="select">
            <asp:ListItem Value="-1">(Seleccione)</asp:ListItem>
            <asp:ListItem Value="AYU">AYU</asp:ListItem>
            <asp:ListItem Value="COC">COC</asp:ListItem>
            <asp:ListItem Value="JEP">JEP</asp:ListItem>
            <asp:ListItem Value="OP">OP</asp:ListItem>
            <asp:ListItem Value="VE">VE</asp:ListItem>
        </asp:DropDownList>
      </td>
    <td class="formLabel" >&nbsp;</td>
    <td class="formValue">&nbsp;</td>
  </tr>
  </table>
</table>
    <br /><br />
     <br /><br />
    <table width="80%" border="0" cellspacing="0" cellpadding="0" align="center">
    <tr>
        <td>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                BackColor="#CCCCCC" DisplayMode="List" Font-Bold="True" Font-Names="Segoe UI" 
                Font-Size="Small" />
        </td>
    </tr>
    <tr>
                <td align="right" style="text-align: center;" colspan="4">
                    <input id="IdPlanta" type="hidden" runat="server" />
                    <asp:ImageButton ID="imgCancelar" runat="server" ImageUrl="~/Imagenes/Cancelar.png"
                        OnClick="imgCancelar_Click" CausesValidation="False" />
                    <asp:ImageButton ID="imgLimpiar" runat="server" ImageUrl="~/Imagenes/Limpiar.png"
                        OnClick="imgLimpiar_Click" CausesValidation="False" />
                    <asp:ImageButton ID="imgGuardar" runat="server" ImageUrl="~/Imagenes/Grabar.png"
                        OnClick="imgGuardar_Click" />
                </td>
            </tr>
    </table>

    </form>


</asp:Content>

