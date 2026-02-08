<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true"
    CodeFile="CatalogoParametros.aspx.cs" Inherits="Views_CatalogoParametros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">
    <span style="text-align:center"><H2> Edicion : Parametros de Configuración </H2></span>
    <br />
    <table style="width: 100%">
        <tr>
            <td>
                <table align="center" style="width: 56%">
                    <tr>
                        <td width="30%" bgcolor="#D7D7D7" class="PopupNombre" style="text-align: right; width: 141px">
                            Clave
                        </td>
                        <td width="70%" style="text-align: left; width: 512px">
                            <asp:Label ID="clave" runat="server" Style="text-align: left" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" bgcolor="#D7D7D7" class="PopupNombre" style="height: 16px; text-align: right;
                            width: 141px">
                            Valor
                        </td>
                        <td width="70%" class="style7" style="height: 16px; width: 512px">
                            <asp:TextBox ID="valor" runat="server" Width="444px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" bgcolor="#D7D7D7" class="PopupNombre" style="text-align: right; width: 141px">
                            Descripción
                        </td>
                        <td width="70%" class="style7" style="width: 512px">
                            <asp:TextBox ID="descripcion" runat="server" Width="442px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" class="PopupNombre" style="text-align: right; width: 141px">
                            &nbsp;
                        </td>
                        <td width="70%" class="style7" style="width: 512px; text-align: center">
                            <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Imagenes/Cancelar.png"
                                OnClick="btnCancelar_Click" CausesValidation="False" />
                            <asp:ImageButton ID="imgLimpiar" runat="server" ImageUrl="~/Imagenes/Limpiar.png"
                                OnClick="imgLimpiar_Click" CausesValidation="False" />
                            <asp:ImageButton ID="btnAceptar" runat="server" ImageUrl="~/Imagenes/Grabar.png"
                                OnClick="btnAceptar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" class="PopupNombre" style="text-align: right; width: 141px">
                            &nbsp;
                        </td>
                        <td width="70%" class="style7" style="width: 512px; text-align: center">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo valor es requerido"
                                ControlToValidate="valor"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    </form>
</asp:Content>
