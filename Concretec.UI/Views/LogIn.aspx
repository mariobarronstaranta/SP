<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/SiteLogin.Master"
    CodeFile="LogIn.aspx.cs" Inherits="Views_LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <div id="apDiv1">
                    <div id="apDiv2" style="top: 101px; left: 141px">
                        <table width="100%">
                            <tr>
                                <td colspan="2">
                                    <span style="font-family: 'Segoe UI'; font-size: large; color: #7E8EAA"><strong>Sistema
                                        de Programacion de Pedidos</strong></span><br />
                                    <br />
                                    <tr>
                                        <td class="TextboxNumerico">
                                            <strong class="introContent">Usuario</strong>
                                        <td>
                                            &nbsp;<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                    </tr>
                            <tr>
                                <td class="TextboxNumerico">
                                    <strong>Contraseña</strong>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                            </tr>
                            <tr>
                                <td>
                                <td>
                                    <br />
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    &nbsp;<asp:Button ID="cmdAceptar" runat="server" Text="Ingresar" OnClick="cmdAceptar_Click" />
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <span style="text-decoration: underline; color: #0000FF"><a href="CambioPassword.aspx">
                                        Cambiar Contraseña</a></span>&nbsp;&nbsp; <span style="color: #0000FF; text-decoration: underline">
                                            <a href="RecuperacionUsuario.aspx">Recuperar Contraseña</a></span>
                        </table>
                    </div>
                    <div id="inferior">
                        &nbsp;</div>
                </div>
            </td>
        </tr>
    </table>
    </form>
</asp:Content>
