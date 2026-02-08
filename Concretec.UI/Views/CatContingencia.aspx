<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="CatContingencia.aspx.cs" Inherits="Views_CatContingencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Contingencias
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">
        <span style="text-align: center">
            <h2> Maestro de Catalogos </h2>
        </span>
        <br />
        <br />
        <table width="50%" border="0" align="center">
            <tr>
                <td class="formLabel">Clave</td>
                <td class="formValue">
                    <asp:TextBox ID="txtclave" runat="server" Enabled="False" Width="226px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formLabel">Descripcion</td>
                <td class="formValue">
                    <asp:TextBox ID="txtdescripcion" runat="server" Width="226px"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="formLabel">Catalogo</td>
                <td class="formValue"><asp:DropDownList ID="cboCategoria" runat="server" Width="150px" CssClass="select"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>

            </tr>

            <tr>

                <td colspan="2">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                        BackColor="#CCCCCC" DisplayMode="List" Font-Bold="True" Font-Names="Segoe UI"
                        Font-Size="Small" />
                </td>
            </tr>
            <tr>
                <td align="left" style="text-align: left;" colspan="2">
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

