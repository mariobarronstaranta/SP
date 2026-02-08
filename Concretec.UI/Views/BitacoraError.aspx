<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="BitacoraError.aspx.cs" Inherits="Views_BitacoraError" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Bitacora de Sucesos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">
        <table width="100%">
            <tr>
                <td style="text-align: center">
                    <h2>Bitacora de Sucesos</h2>
                </td>
            </tr>
        </table>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Desde :" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <telerik:RadDatePicker ID="inicio" runat="server" Culture="en-US">
                            </telerik:RadDatePicker>
                        </td>
                        <td><asp:Label ID="Label1" runat="server" Text="Hasta :" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <telerik:RadDatePicker ID="fin" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td align="left">
                            <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnBuscar_Click" Height="35px" EnableViewState="False" />
                            <asp:ImageButton ID="btnExportar" runat="server" ImageUrl="~/MetroImages/ExcelExport.png" OnClick="btnExportar_Click" Height="35px" EnableViewState="False" /></td>
                    </tr>
                </table>
            </div>
        </asp:Panel>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <table align="center" width="95%">
            <tr>
                <td>
                    <telerik:RadGrid ID="rgBitacora" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" AllowPaging="True" PageSize="20" Skin="Metro" Width="990px">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>

                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>

                            <Columns>
                                <telerik:GridBoundColumn DataField="Fecha" FilterControlAltText="Filter column column" HeaderText="Fecha" UniqueName="column">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Hora" FilterControlAltText="Filter column5 column" HeaderText="Hora" UniqueName="column5">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Aplicacion" FilterControlAltText="Filter column1 column" HeaderText="Aplicacion" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Modulo" FilterControlAltText="Filter column2 column" HeaderText="Modulo" UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Funcion" FilterControlAltText="Filter column3 column" HeaderText="Funcion" UniqueName="column3">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Descripcion" FilterControlAltText="Filter column4 column" HeaderText="Descripcion" UniqueName="column4">
                                </telerik:GridBoundColumn>
                            </Columns>

                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                            </EditFormSettings>

                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        </MasterTableView>

                        <PagerStyle PageSizeControlType="RadComboBox" Mode="NumericPages"></PagerStyle>

                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>

