<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true"
    CodeFile="CambioPassword.aspx.cs" Inherits="Views_CambioPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Usuarios
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <div id="apDiv1" class="centrar">
        <div id="apDiv2" style="top: 101px; left: 141px">
            <table width="100%">
                <tr>
                    <td colspan="2">
                        <span style="font-family: 'Segoe UI'; font-size: large; color: #7E8EAA"><strong>Cambio
                            de contraseña</strong></span><br />
                        <br />
                        <tr>
                            <td class="TextboxNumerico">
                                <strong class="introContent">Usuario</strong>
                            <td>
                                &nbsp;<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        </tr>
                <tr>
                    <td class="TextboxNumerico">
                        <strong>Contraseña Anterior</strong>
                    <td>
                        &nbsp;<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </tr>
                <tr>
                    <td class="TextboxNumerico">
                        <strong>Contraseña Nueva</strong>
                    <td>
                        <asp:TextBox ID="txtPassword0" runat="server" TextMode="Password" Style="margin-bottom: 0px"></asp:TextBox>
                </tr>
                <tr>
                    <td class="TextboxNumerico">
                        <strong>Confirmar Contraseña</strong>
                    <td>
                        <asp:TextBox ID="txtPassword1" runat="server" TextMode="Password"></asp:TextBox>
                </tr>
                <tr>
                    <td>
                    <td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" OnClick="cmdCancelar_Click" />
                        &nbsp;
                        <asp:Button ID="cmdAceptar" runat="server" Text="Cambiar" OnClick="cmdAceptar_Click" />
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                        <br />
            </table>
        </div>
        <div id="inferior">
            &nbsp;</div>
    </div>
    </form>
</asp:Content>
