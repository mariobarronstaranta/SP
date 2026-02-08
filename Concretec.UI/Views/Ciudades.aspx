<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="Ciudades.aspx.cs" Inherits="Views_Ciudades" %>



<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Ciudades
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <span style="text-align: center">
            <h2>Catálogo de Ciudades</h2>
        </span>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1" runat="server" id="tblbusqueda">
                    <tr>
                        <td>
                            <asp:Label ID="lblfiltersPoblacion" runat="server" Text="Nombre Ciudad:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>

                    <tr>
                        <td><telerik:RadTextBox ID="txtFiltro" runat="server" EmptyMessage="Nombre de Ciudad" LabelWidth="64px" Resize="None" Skin="Metro" Width="350px"></telerik:RadTextBox></td>
                        <td>&nbsp;</td>
                        <td><asp:ImageButton ID="btnBuscar" runat="server" Height="35px" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnBuscar_Click" /></td>
                        <td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/MetroImages/NuevoElemento.png" Height="35px" OnClick="ImageButton1_Click" /></td>
                        <td>&nbsp;</td>
                    </tr>
                    </table>
                   <table>
                    <tr runat="server" id="frmCiudad" visible="false">
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Nombre Ciudad:" Font-Bold="True" Font-Size="Small"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtNombreCiudad" runat="server" EmptyMessage="Nombre de Ciudad" LabelWidth="64px" Resize="None" Skin="Metro" Width="300px"></telerik:RadTextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Clave:" Font-Bold="True" Font-Size="Small"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtCveCiudad" runat="server" EmptyMessage="Clave de Ciudad" LabelWidth="64px" Resize="None" Skin="Metro" Width="300px"></telerik:RadTextBox>
                        </td>
                        <td><asp:ImageButton ID="btnGuardar" runat="server" Height="35px" ImageUrl="~/MetroImages/Aceptar.png" OnClick="btnGuardar_Click" /></td>
                    </tr>
                </table>
            </div>
        </asp:Panel>

        <table width="80%">
            <tr align="center">
                <td>


                    <telerik:RadGrid ID="GridCiudades" runat="server" AutoGenerateColumns="False" Skin="Metro" OnNeedDataSource="GridCiudades_NeedDataSource" OnItemCommand="GridCiudades_ItemCommand" CellSpacing="-1" GridLines="Both">
<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn FilterControlAltText="Filter column column" HeaderText="ID" UniqueName="column" DataField="IDCiudad">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn FilterControlAltText="Filter column1 column" HeaderText="Nombre Ciudad" UniqueName="column1" DataField="Descripcion">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn FilterControlAltText="Filter column3 column" HeaderText="Clave" UniqueName="column3" DataField="CveCiudad">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn CommandName="Editar" HeaderText="Editar"
                                    Text="Editar" UniqueName="column10" ImageUrl="~/Imagenes/Edit.png">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>

            </tr>
        </table>

    </form>
</asp:Content>

