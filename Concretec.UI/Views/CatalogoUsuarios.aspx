<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/MasterPage.master"
    CodeFile="CatalogoUsuarios.aspx.cs" Inherits="Views_Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Usuarios
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <table align="center" style="width: 34%">
                                <tr>
                                    <td class="tdEdicion" bgcolor="#D7D7D7">
                                        Nombre
                                    </td>
                                    <td>
                                        <asp:TextBox ID="nombre" runat="server" Width="97%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdEdicion" bgcolor="#D7D7D7">
                                        Password
                                    </td>
                                    <td>
                                        <asp:TextBox ID="password" runat="server" Width="97%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdEdicion" bgcolor="#D7D7D7">
                                        Confirmar Password
                                    </td>
                                    <td>
                                        <asp:TextBox ID="confirmapassword" runat="server" Width="97%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdEdicion" bgcolor="#D7D7D7">
                                        Perfil
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="perfil" runat="server">
                                            <asp:ListItem Value="1">Administrador</asp:ListItem>
                                            <asp:ListItem Value="2">Programador</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdEdicion" bgcolor="#D7D7D7">
                                        Estatus
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="estatus" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Activo" Value="true"></asp:ListItem>
                                            <asp:ListItem Text="Inactivo" Value="false"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 25%">
                                        &nbsp;
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Button ID="btnAceptar0" runat="server" OnClick="btnAceptar_Click" Text="Grabar"
                                            UseSubmitBehavior="False" />
                                        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar"
                                            UseSubmitBehavior="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</asp:Content>
