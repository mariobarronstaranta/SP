<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="CapturaProducto.aspx.cs" Inherits="Views_CapturaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <span style="text-align:center"><H2> Captura Manual de Productos </H2></span>
    <form id="form1" runat="server">
        <table align="center">
            <tr><td class="formLabel">Clave</td><td class="formValue"><asp:TextBox ID="txtClave" runat="server" Height="20px" CssClass="txtgradiente"></asp:TextBox></td></tr>
            <tr><td class="formLabel">Descripcion</td><td class="formValue"><asp:TextBox ID="txtDescripcion" runat="server" Height="20px" CssClass="txtgradiente"></asp:TextBox></td></tr>
            <tr><td class="formLabel">Unidad</td><td class="formValue"><asp:TextBox ID="txtUnidad" runat="server" Height="20px" CssClass="txtgradiente" ReadOnly="True" Text="M3"></asp:TextBox></td></tr>
            <tr><td class="formLabel">Precio</td><td class="formValue"><asp:TextBox ID="txtPrecio" runat="server" Height="20px" CssClass="txtgradiente" Text="0.0"></asp:TextBox></td></tr>
            <tr><td class="formLabel">Ciudad</td><td class="formValue"><asp:DropDownList ID="cboCiudades" runat="server" Height="20px" CssClass="select">
                <asp:ListItem Value="-1">(Seleccione)</asp:ListItem>
                <asp:ListItem Value="MTY">Monterrey</asp:ListItem>
                <asp:ListItem Value="AGS">Aguascalientes</asp:ListItem>
                <asp:ListItem Value="GDL">Guadalajara</asp:ListItem>
                <asp:ListItem Value="LEON">Leon</asp:ListItem>
                <asp:ListItem Value="PUE">Puebla</asp:ListItem>
                <asp:ListItem Value="QRO">Queretaro</asp:ListItem>
                </asp:DropDownList></td></tr>
            <tr><td class="formLabel">Clasificación</td><td class="formValue"><asp:DropDownList ID="cboclasificacion" runat="server" Height="20px" CssClass="select">
                <asp:ListItem Selected="True" Value="-1">(Seleccione)</asp:ListItem>
                <asp:ListItem>ACTIV</asp:ListItem>
                <asp:ListItem>ADCON</asp:ListItem>
                <asp:ListItem>AGR</asp:ListItem>
                <asp:ListItem>CONC</asp:ListItem>
                <asp:ListItem>MOR</asp:ListItem>
                <asp:ListItem>MP</asp:ListItem>
                <asp:ListItem>SERBO</asp:ListItem>
                <asp:ListItem>SERV</asp:ListItem>
                </asp:DropDownList></td></tr>
            <tr><td class="formLabel">Clave Alterna</td><td class="formValue"><asp:TextBox ID="txtCveAlterna" runat="server" Height="20px" CssClass="txtgradiente"></asp:TextBox></td></tr>

            <tr>
            <td style="text-align: center;" colspan="2">
                <input id="IdPlanta" type="hidden" runat="server" />
                <asp:ImageButton ID="imgCancelar" runat="server" ImageUrl="~/Imagenes/Cancelar.png" OnClick="imgCancelar_Click" CausesValidation="False" />
                <asp:ImageButton ID="imgLimpiar" runat="server" ImageUrl="~/Imagenes/Limpiar.png"   OnClick  ="imgLimpiar_Click" CausesValidation="False" />
                <asp:ImageButton ID="imgGuardar" runat="server" ImageUrl="~/Imagenes/Grabar.png"  OnClick ="imgGuardar_Click"/>
            </td>
        </tr>

        </table>
    </form>
</asp:Content>

