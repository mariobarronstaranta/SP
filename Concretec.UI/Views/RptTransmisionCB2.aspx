<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="RptTransmisionCB2.aspx.cs" Inherits="Views_RptTransmisionCB2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<%@ Register assembly="Telerik.Web.UI, Version=2015.2.826.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" namespace="Telerik.Web.UI" tagprefix="telerik" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">

        <span style="text-align: center">
            <h2>Reporte de Transmision de Archivos CB2</h2>
        </span>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td>
                            <asp:Label ID="lblfiltersPoblacion" runat="server" Font-Bold="True" Font-Size="Small" Text="Fecha:"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="fin" runat="server" MinDate="2005-01-01" Width="200px" EnableViewState="False" Skin="Metro">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Metro"></Calendar>
                                <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy">
                                    <EmptyMessageStyle Resize="None" />
                                    <ReadOnlyStyle Resize="None" />
                                    <FocusedStyle Resize="None" />
                                    <DisabledStyle Resize="None" />
                                    <InvalidStyle Resize="None" />
                                    <HoveredStyle Resize="None" />
                                    <EnabledStyle Resize="None" />
                                </DateInput>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        
                
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
        <div style="width: auto; text-align: center;vertical-align: text-top;">
            &nbsp;&nbsp;&nbsp;
        <table width="100%" >
            <tr>
                <td style="vertical-align: text-top;">
            <telerik:RadGrid ID="grdPedidos" runat="server" AllowPaging="True"
                AutoGenerateColumns="False" AllowAutomaticDeletes="True" AllowAutomaticInserts="True"
                AllowAutomaticUpdates="True"
                PageSize="20" AllowSorting="True" Width="500px" Skin="Metro" OnItemCommand="grdPedidos_ItemCommand" GroupPanelPosition="Top">

                <MasterTableView>
                    <RowIndicatorColumn>
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Created="True">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                    <Columns>
                        <telerik:GridBoundColumn HeaderText="Ciudad"                        DataField="Ciudad"      UniqueName="Ciudad"         Visible="true"  ><HeaderStyle Font-Bold="True" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Planta"                        DataField="Planta"      UniqueName="Planta"         Visible="true">                         <HeaderStyle Font-Bold="True" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="NombrePC"                  DataField="NombrePC"     UniqueName="Pedidos"        Visible="true" >                        <HeaderStyle Font-Bold="True" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Exitosos"                   DataField="Exitosos"      UniqueName="Viajes"         Visible="true">                         <HeaderStyle Font-Bold="True" /><ItemStyle HorizontalAlign="Left" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Fallidos"              DataField="Fallidos"    UniqueName="Remision"       Visible="true">                         <HeaderStyle Font-Bold="True" /><ItemStyle HorizontalAlign="Left" /></telerik:GridBoundColumn>
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
                    </td>
                <td style="vertical-align: text-top;text-align:left">
                    
                    <telerik:RadGrid Width="500px" ID="gridDetalle" runat="server" Skin="Default" AutoGenerateColumns="False" GroupPanelPosition="Top">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Ciudad" FilterControlAltText="Filter column column" HeaderText="Ciudad" UniqueName="column">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Planta" FilterControlAltText="Filter column1 column" HeaderText="Planta" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Descripcion" FilterControlAltText="Filter column2 column" HeaderText="Descripcion" UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Incidencias" FilterControlAltText="Filter column3 column" HeaderText="Incidencias" UniqueName="column3">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                    
                </td>

            </tr></table>
        </div>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
    </form>
</asp:Content>

