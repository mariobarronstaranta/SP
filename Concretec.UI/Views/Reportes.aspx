<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reportes.aspx.cs" Inherits="Views_Reportes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Shared/Reportes.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            margin-bottom: 0px;
        }
    </style>
</head>
<body >
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <div>
            <table align="center">
                <tr>
                    <td class="formLabel">Reporte</td>
                    <td class="formValue">
                        <telerik:RadComboBox ID="RadComboBox1" runat="server" Skin="Glow" Width="200px">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Selected="True" Text="(Seleccione)" Value="-1" />
                                <telerik:RadComboBoxItem runat="server" Text="Plantas" Value="Plantas" />
                                <telerik:RadComboBoxItem runat="server" Text="Vendedores" Value="Vendedores" />
                                <telerik:RadComboBoxItem runat="server" Text="Pedidos" Value="Pedidos" />
                                <telerik:RadComboBoxItem runat="server" Text="Obras" Value="Obras" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td class="formLabel">Ciudad</td>
                    <td class="formValue">
                        <telerik:RadComboBox ID="cboCiudades" runat="server" Skin="Glow" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="cboCiudades_SelectedIndexChanged"></telerik:RadComboBox>
                    </td>
                    <td class="formLabel">Inicio</td>
                    <td class="formValue">
                        <telerik:RadDatePicker ID="RadDatePicker2" runat="server" Skin="Glow" Width="190px">
                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="Glow"></Calendar>

                            <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%"></DateInput>

                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td class="formLabel">Final</td>
                    <td class="formValue">
                        <telerik:RadDatePicker ID="RadDatePicker1" runat="server" Skin="Glow" Width="190px">
                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="Glow"></Calendar>

                            <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%"></DateInput>

                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                    <td rowspan="2">
                         <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Imagenes/Reporte_Buscar.png"
                                    OnClick="btnBuscar_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="formLabel">Planta</td>
                    <td class="formValue">
                        <telerik:RadComboBox ID="cboPlanta" runat="server" Skin="Glow" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="cboPlanta_SelectedIndexChanged">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Selected="True" Text="(Vacio)" Value="-1" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td class="formLabel">Cliente</td>
                    <td class="formValue">
                        <telerik:RadComboBox ID="cboCliente" runat="server" Skin="Glow" Width="200px" RenderMode="Lightweight" DropDownAutoWidth="Enabled">
                        </telerik:RadComboBox>
                    </td>
                    <td class="formLabel">Obra</td>
                    <td class="formValue">
                        <telerik:RadComboBox ID="RadComboBox2" runat="server" Skin="Glow" Width="200px">
                        </telerik:RadComboBox>
                    </td>
                    <td class="formLabel">Vendedor</td>
                    <td class="formValue">
                        <telerik:RadComboBox ID="RadComboBox5" runat="server" Skin="Glow" Width="200px">
                        </telerik:RadComboBox>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
