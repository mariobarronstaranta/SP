<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="RptURLObras.aspx.cs" Inherits="Views_RptURLObras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
    
        <span style="text-align: center">
            <h2>Obras con Alttud y Latitud</h2>
        </span>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblDesde" runat="server" Text="Desde:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="lblHasta" runat="server" Text="Hasta:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="lblCiduad" runat="server" Text="Ciudad:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
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
                            <telerik:RadDatePicker ID="dtHasta" runat="server" MinDate="2005-01-01" Width="200px" EnableViewState="False" Skin="Metro">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Metro"></Calendar>
                                <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%"></DateInput>
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
                PageSize="20" AllowSorting="True" Width="990px" Skin="Metro">

<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                <MasterTableView>
                    <RowIndicatorColumn>
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Created="True">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                    <Columns>
                        <telerik:GridBoundColumn HeaderText="Ciudad"                        DataField="CveCiudad"      UniqueName="Ciudad"         Visible="true"  DataType="System.Int32"><HeaderStyle Font-Bold="True" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Clave Obra"                        DataField="ClaveObra"      UniqueName="Planta"         Visible="true">                         <HeaderStyle Font-Bold="True" Width="150px" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Obra"                  DataField="Nombre"     UniqueName="Pedidos"        Visible="true" >                        <HeaderStyle Font-Bold="True" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Direccion"                   DataField="Direccion"      UniqueName="Viajes"         Visible="true">                         <HeaderStyle Font-Bold="True" /><ItemStyle HorizontalAlign="Left" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Altitud"              DataField="Altitud"    UniqueName="Remision"       Visible="true">                         <HeaderStyle Font-Bold="True" /><ItemStyle HorizontalAlign="Left" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Latitud"                      DataField="Latitud"         UniqueName="Cb2"            Visible="true">                         <HeaderStyle Font-Bold="True" /></telerik:GridBoundColumn>
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

