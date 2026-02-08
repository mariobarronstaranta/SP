<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true"
    CodeFile="RegistraUsuario.aspx.cs" Inherits="Views_RegistraUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
<span style="text-align:center"><H2> Usuarios </H2></span>
    <form id="form1" runat="server">
    <asp:TextBox ID="txtIDUsuario" runat="server" Visible="False"></asp:TextBox>
    <br />
    
    <table align="center">
        <tr>
            <td class="formLabel">
                Nombre de Usuario
            </td>
            <td class="formValue">
                <asp:TextBox ID="txtusername" runat="server" Height="20px" ReadOnly="False" 
                    CssClass="txtgradiente"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVUserName" runat="server" ControlToValidate="txtusername"
                    ErrorMessage="El Nombre de Usuario es Obligatorio">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="formLabel">
                Password
            </td>
            <td class="formValue">
                <asp:TextBox ID="txtpassword" runat="server" Height="20px" TextMode="Password" 
                    CssClass="txtgradiente"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVPassword" runat="server" ControlToValidate="txtpassword"
                    ErrorMessage="El Password es Obligatorio">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="formLabel">
                Confirmar Password
            </td>
            <td class="formValue">
                <asp:TextBox ID="txtpassword2" runat="server" Height="20px" TextMode="Password" CssClass="txtgradiente"></asp:TextBox>
                <asp:CompareValidator ID="ValidaPassword" runat="server" ControlToCompare="txtpassword"
                    ControlToValidate="txtpassword2" ErrorMessage="Verifique su Password">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="formLabel">
                Nombre
            </td>
            <td class="formValue">
                <asp:TextBox ID="txtNombre" runat="server" Height="20px" 
                    CssClass="txtgradiente"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVNombre" runat="server" ControlToValidate="txtNombre"
                    ErrorMessage="El Nombre del Usuario  es Obligatorio">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="formLabel">
                Apellido Paterno
            </td>
            <td class="formValue">
                <asp:TextBox ID="txtAP" runat="server" Height="20px" CssClass="txtgradiente"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVApellido" runat="server" ControlToValidate="txtAP"
                    ErrorMessage="El Apellido es Obligatorio">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="formLabel">
                Apellido Materno
            </td>
            <td class="formValue">
                <asp:TextBox ID="txtAM" runat="server" Height="20px" CssClass="txtgradiente"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="formLabel">
                Perfil
            </td>
            <td class="formValue">
                <asp:DropDownList ID="cboPerfil" runat="server" Height="20px" CssClass="select">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RFVPerfil" runat="server" ControlToValidate="cboPerfil"
                    ErrorMessage="valido para el Perfil de usuario">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="formLabel">
                Ciudad
            </td>
            <td class="formValue">
                <asp:DropDownList ID="cboCiudades" runat="server" Height="20px" 
                    CssClass="select" AutoPostBack="True" OnSelectedIndexChanged="cboCiudades_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RFVCiudad" runat="server" ControlToValidate="cboCiudades">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="formLabel">
                Planta
            </td>
            <td class="formValue">
                <asp:DropDownList ID="cboPlanta" runat="server" Height="20px" CssClass="select"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="text-align: center;" colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="#EBEBEB"
                    DisplayMode="List" Font-Bold="True" Font-Names="Segoe UI" ForeColor="Maroon" />
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="2">
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
