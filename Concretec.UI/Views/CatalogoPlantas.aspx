<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/MasterPage.master"
    CodeFile="CatalogoPlantas.aspx.cs" Inherits="Views_CatalogoPlantas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    CatalogoPlantas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <span style="text-align:center"><H2> Plantas </H2></span>
    <br />
    <table align="center" style="width: 75%">
        <tr>
          <td class="formLabel">Clave</td>
          <td class="formValue"><asp:TextBox ID="cveplanta" runat="server" 
                  Style="text-align: left" MaxLength="10" CssClass="txtgradiente"></asp:TextBox></td>
          <td class="formLabel">Calle
            &nbsp;</span></td>
          <td class="formValue"><asp:TextBox ID="calle" runat="server" MaxLength="50" CssClass="txtgradiente"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="formLabel">
                Nombre
            </td>
            <td class="formValue">
                <asp:TextBox ID="nombre" runat="server" Style="text-align: left" 
                    MaxLength="50" CssClass="txtgradiente"></asp:TextBox>
            </td>
            <td class="formLabel" >Colonia</td>
          <td class="formValue"><asp:TextBox ID="colonia" runat="server" MaxLength="50" CssClass="txtgradiente"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="formLabel" >
                Dosificadora PD
            </td>
            <td class="formValue">
                <asp:TextBox ID="cveDosificadora" runat="server" MaxLength="50" 
                    CssClass="txtgradiente"></asp:TextBox>
            </td>
            <td class="formLabel">Numero</td>
            <td class="formValue">Interior.
                <asp:TextBox ID="NumInt" runat="server" Width="50px" MaxLength="5"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exterior.
                <asp:TextBox ID="NumExt" runat="server" Width="50px" MaxLength="5"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="formLabel">
                Teléfono 1
            </td>
            <td class="formValue"> 
                <asp:TextBox ID="Telefono" runat="server" MaxLength="25" 
                    CssClass="txtgradiente"></asp:TextBox>
            </td>
            <td class="formLabel">Jefe de Planta</td>
            <td class="formValue"><asp:DropDownList ID="jefeplanta" runat="server" 
                  Width="200px" CssClass="select"> </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="formLabel" >
                Teléfono 2
            </td>
            <td class="formValue"> 
                <asp:TextBox ID="Telefono2" runat="server" MaxLength="25" 
                    CssClass="txtgradiente"></asp:TextBox>
            </td>
            <td class="formLabel">Ciudad</td>
            <td class="formValue"><asp:DropDownList ID="ciudad" runat="server" Width="200px" AutoPostBack="True" 
                    onselectedindexchanged="ciudad_SelectedIndexChanged" CssClass="select">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="formLabel">
                Municipio
            </td>
            <td class="formValue">
                <asp:TextBox ID="municipio" runat="server" 
                  MaxLength="50" CssClass="txtgradiente"></asp:TextBox>
            </td>
            <td class="formLabel">Estatus</td>
            <td class="formValue"><asp:RadioButtonList ID="estatus" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Activo" Value="true" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Inactivo" Value="false"></asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="formValue"> 
                <asp:DropDownList ID="PA1" runat="server"   Width="200px" Visible="False"> </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td class="formValue"><asp:DropDownList ID="PA2" runat="server"   Width="200px" Visible="False"> </asp:DropDownList></td>
        </tr>
        
        
        <tr>
            <td align="right" style="text-align: center;" colspan="4">
                <br />
                <br />



                
                
            </td>
            <tr>
                <td align="right" style="text-align: center;" colspan="4">
                    <input id="IdPlanta" type="hidden" runat="server" />
                    <asp:ImageButton ID="imgCancelar" runat="server" ImageUrl="~/Imagenes/Cancelar.png"
                        OnClick="imgCancelar_Click" />
                    <asp:ImageButton ID="imgLimpiar" runat="server" ImageUrl="~/Imagenes/Limpiar.png"
                        OnClick="imgLimpiar_Click" />
                    <asp:ImageButton ID="imgGuardar" runat="server" ImageUrl="~/Imagenes/Grabar.png"
                        OnClick="imgGuardar_Click" />
                </td>
            </tr>
        <tr>
            <td align="right" style="text-align: center;" colspan="4">
                <asp:RequiredFieldValidator ID="RNombre" runat="server" ControlToValidate="nombre"
                    ErrorMessage="El campo nombre es obligatorio"></asp:RequiredFieldValidator>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cveDosificadora"
                    ErrorMessage="El campo Dosificadora es obligatorio"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
    </table>
    </form>
</asp:Content>
