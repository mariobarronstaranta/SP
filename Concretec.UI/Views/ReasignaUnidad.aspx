<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="ReasignaUnidad.aspx.cs" Inherits="Views_ReasignaUnidad" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Reasignar Viajes - CR</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server" enableviewstate="True">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <span style="text-align: center"> <h2>Reasignar Viajes - CR</h2></span>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Ciudad:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Planta:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Unidad:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label2" runat="server" Text="Desde:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td><telerik:RadComboBox ID="cboCiudad" runat="server" Skin="Metro" Width="200px" OnSelectedIndexChanged="cboCiudad_SelectedIndexChanged" AutoPostBack="true"></telerik:RadComboBox></td>
                        <td><telerik:RadComboBox ID="cboPlanta" runat="server" Skin="Metro" Width="200px" OnSelectedIndexChanged="cboPlanta_SelectedIndexChanged" AutoPostBack="true"></telerik:RadComboBox></td>
                        <td><telerik:RadComboBox ID="cboCR" runat="server" Skin="Metro" Width="200px"></telerik:RadComboBox></td>
                        
                        <td>
                            <telerik:RadDatePicker ID="DTFechaCambio" runat="server" Width="123px" ShowPopupOnFocus="True"
                        Skin="Metro" EnableTyping="False" EnableViewState="False" TabIndex="12">
                        <DateInput ID="DateInput1" runat="server" ReadOnly="True" TabIndex="12">
                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                            <FocusedStyle Resize="None"></FocusedStyle>

                            <DisabledStyle Resize="None"></DisabledStyle>

                            <InvalidStyle Resize="None"></InvalidStyle>

                            <HoveredStyle Resize="None"></HoveredStyle>

                            <EnabledStyle Resize="None"></EnabledStyle>
                        </DateInput>
                        <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            ViewSelectorText="x" OnDayRender="CustomizeDay" Skin="Metro">
                            <SpecialDays>
                                <telerik:RadCalendarDay Date="2009-06-24" IsDisabled="True" IsSelectable="False">
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                            <DisabledDayStyle Font-Bold="True" Font-Strikeout="True" />
                        </Calendar>
                        <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="12"></DatePopupButton>
                    </telerik:RadDatePicker>
                        </td>
                        <td><asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/MetroImages/PreviewF.png" Height="40px" Style="text-align: right" OnClick="btnBuscar_Click" /></td>
                        <td><asp:ImageButton ID="btnLimpiar" runat="server" ImageUrl="~/MetroImages/Clean.png" EnableViewState="False" Height="40px" OnClick="btnLimpiar_Click" /></td>
                        <td><asp:ImageButton ID="btnProcesar" runat="server" ImageUrl="~/MetroImages/DataSync.png" Height="40px" Style="text-align: right" OnClick="btnProcesar_Click" /></td> 
                    </tr>
                </table>
            </div>
            
        </asp:Panel>

         <table width="100%">
            <tr>
                <td colspan="2">
                    <telerik:RadGrid ID="GridRemisiones" runat="server" AllowPaging="True"
                        AutoGenerateColumns="False" 
                        PageSize="20" OnItemCommand="GridRemisiones_ItemCommand" Width="990px" Skin="Metro" GroupPanelPosition="Top">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>

                            <ExpandCollapseColumn Created="True">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>

                                <telerik:GridBoundColumn DataField="NombreCROrigen"          HeaderText="CR Origen"          UniqueName="NombreCliente"> </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreCRDestino"             HeaderText="CR Destino"         UniqueName="NombreObra"> </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaViaje"               HeaderText="Fecha"              UniqueName="IDPedido"> </telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="HoraViaje" HeaderText="Hora" UniqueName="column" FilterControlAltText="Filter column column"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NumPedidoViaje"            HeaderText="Pedido - Viaje"     UniqueName="FechaInicio" DataType="System.DateTime"> </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Carga"               HeaderText="Carga"              UniqueName="Remision"> </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ClienteObra"                HeaderText="Cliente - Obra"     UniqueName="factura"> </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn CommandName="Agregar" Text="Agregar"  UniqueName="column12" Visible="False"> </telerik:GridButtonColumn>

                            </Columns>

                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                            </EditFormSettings>

                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        </MasterTableView>
                        <PagerStyle Mode="NumericPages" />

                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                    </telerik:RadGrid>
                    

                </td>
            </tr>
        </table>

    </form>
</asp:Content>

