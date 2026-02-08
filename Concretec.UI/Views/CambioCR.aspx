<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="CambioCR.aspx.cs" Inherits="Views_CambioCR" %>


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
        <span style="text-align: center">
            <h2>Reasignar Unidad de Planta</h2>
        </span>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td>
                            <asp:Label ID="lblciudadorigen" runat="server" Text="Ciudad Origen:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblfiltersPoblacion" runat="server" Text="Unidad:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Planta Origen:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Ciudad Destino:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Planta Destino:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Desde:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Motivo:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadComboBox ID="cboCiudadOrigen" runat="server" Skin="Metro" Width="120px" OnSelectedIndexChanged="cboCiudadOrigen_SelectedIndexChanged" AutoPostBack="true"></telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cboCR" runat="server" Skin="Metro" Width="150px" OnSelectedIndexChanged="cboCR_SelectedIndexChanged" AutoPostBack="true"></telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="CboPlanta" runat="server" Skin="Metro" Width="120px"></telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cboCiudadDestino" runat="server" Skin="Metro" Width="120px" OnSelectedIndexChanged="cboCiudadDestino_SelectedIndexChanged" AutoPostBack="true"></telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="CboPlantaDestino" runat="server" Skin="Metro" Width="120px"></telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="DTFechaCambio" runat="server" Width="120" ShowPopupOnFocus="True"
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
                        <td>
                            <telerik:RadComboBox ID="cboComentario" runat="server" Skin="Metro" Width="150px">
                            </telerik:RadComboBox>
                        </td>
                        <%--</telerik:RadComboBox>--%>
                        <%--</td>--%>
                        <td>
                            <asp:ImageButton ID="btnLimpiar" runat="server" ImageUrl="~/MetroImages/Clean.png" EnableViewState="False" Height="35px" OnClick="btnLimpiar_Click" /></td>
                        <td>
                            <asp:ImageButton ID="btnAplicar" runat="server" ImageUrl="~/MetroImages/Aceptar2.png" Height="35px" Style="text-align: right" OnClick="btnAplicar_Click" /></td>


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

                                <telerik:GridBoundColumn DataField="NombreUnidad" HeaderText="Unidad" UniqueName="NombreCliente"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PlantaOrigen" HeaderText="Planta Origen" UniqueName="NombreObra"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PlantaDestino" HeaderText="Planta Destino" UniqueName="IDPedido"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Inicio" HeaderText="Desde" UniqueName="column" FilterControlAltText="Filter column column"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Fin" HeaderText="Hasta" UniqueName="FechaInicio" DataType="System.DateTime"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaMovimiento" HeaderText="Fecha Movimiento" UniqueName="Remision"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Comentario" FilterControlAltText="Filter column1 column" HeaderText="Motivo" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreUsuario" HeaderText="Modificado Por" UniqueName="factura"></telerik:GridBoundColumn>

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
