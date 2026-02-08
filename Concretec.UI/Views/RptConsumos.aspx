<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="RptConsumos.aspx.cs" Inherits="Views_RptConsumos" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">

        <span style="text-align: center">
            <h2>Comparacion Volumenes</h2>
        </span>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Fecha Entrega Inicio:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Fecha Entrega Fin:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label2" runat="server" Text="Ciudad:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>&nbsp;</td>
                        <td></td>

                    </tr>
                    <tr>
                        <td>
                            <telerik:RadDatePicker ID="inicio" runat="server" MinDate="2005-01-01" Width="200px" EnableViewState="False" Skin="Metro">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Metro"></Calendar>

                                <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="fin" runat="server" MinDate="2005-01-01" Width="200px" EnableViewState="False" Skin="Metro">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Metro"></Calendar>
                                <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy"></DateInput>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td><asp:DropDownList ID="cboCiudades" runat="server" CssClass="select"></asp:DropDownList></td>
                        <td><asp:ImageButton ID="btnExportar" runat="server" ImageUrl="~/MetroImages/ExcelExport.png" OnClick="btnExportar_Click" Height="35px" EnableViewState="False" /></td>
                        
                
                        <td><asp:ImageButton ID="btnBuscar" runat="server" EnableViewState="False" Height="35px" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnBuscar_Click" />
                        </td>

                    </tr>


                </table>
            </div>
        </asp:Panel>



        <div style="margin-left: 10px; text-align: left;">
            <asp:DropDownList ID="estatus" runat="server" Width="2px" Visible="False"></asp:DropDownList>
            <asp:DropDownList ID="cliente" runat="server" Width="2px" Visible="False"></asp:DropDownList>

        </div>
        <div style="width: auto; text-align: center;">
            &nbsp;&nbsp;&nbsp;
        <table width="100%" align="center">
            <tr align="center">
                <td colspan="2">
            <telerik:RadGrid ID="grdPedidos" runat="server" AllowPaging="True"
                AutoGenerateColumns="False" AllowAutomaticDeletes="True" AllowAutomaticInserts="True"
                AllowAutomaticUpdates="True"
                PageSize="20" AllowSorting="True" Width="990px" Skin="Metro" OnItemCommand="grdPedidos_ItemCommand">

                <MasterTableView>
                    <RowIndicatorColumn>
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Created="True">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                    <Columns>
                        <telerik:GridBoundColumn HeaderText="Ciudad"                        DataField="Ciudad"      UniqueName="Ciudad"         Visible="true"  DataType="System.Int32"><HeaderStyle Font-Bold="True" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Planta"                        DataField="Planta"      UniqueName="Planta"         Visible="true">                         <HeaderStyle Font-Bold="True" Width="150px" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Vol. Pedidos"                  DataField="Pedidos"     UniqueName="Pedidos"        Visible="true" >                        <HeaderStyle Font-Bold="True" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Vol. Viajes"                   DataField="Viajes"      UniqueName="Viajes"         Visible="true">                         <HeaderStyle Font-Bold="True" /><ItemStyle HorizontalAlign="Left" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Vol. Remisionado"              DataField="Remision"    UniqueName="Remision"       Visible="true">                         <HeaderStyle Font-Bold="True" /><ItemStyle HorizontalAlign="Left" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Vol. CB2"                      DataField="Cb2"         UniqueName="Cb2"            Visible="true">                         <HeaderStyle Font-Bold="True" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Cantidad Pedidos"              DataField="NumPedidos"  UniqueName="NumPedidos"     Visible="true">                         <HeaderStyle Font-Bold="True" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Cantidad Viajes"               DataField="NumViajes"   UniqueName="NumViajes"      Visible="true">                         <HeaderStyle Font-Bold="True" /><ItemStyle HorizontalAlign="Left" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Cantidad Remisiones"           DataField="NumRemision" UniqueName="NumRemision"    Visible="true">                         <HeaderStyle Font-Bold="True" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Vol. Prom Viajes Programados"  DataField="PedidoProm"  UniqueName="PedidoProm"     Visible="true">                         <HeaderStyle Font-Bold="True" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Vol. Prom Viajes Remisionados" DataField="ViajeProm"   UniqueName="ViajeProm"      Visible="true">                         <HeaderStyle Font-Bold="True" /></telerik:GridBoundColumn>
                        <telerik:GridButtonColumn HeaderText="Detalle"                                              UniqueName="Detalle"        Visible="true" CommandName="Detalle" Text="Ver">                                                           <HeaderStyle Font-Bold="True" /></telerik:GridButtonColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn UniqueName="EditCommandColumn1">
                        </EditColumn>
                    </EditFormSettings>
                    <PagerStyle Mode="NumericPages" />
                </MasterTableView>
                <PagerStyle Mode="NumericPages" />

                <FilterMenu EnableImageSprites="False"></FilterMenu>

            </telerik:RadGrid>
                    </td></tr></table>
        </div>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
    </form>
</asp:Content>


