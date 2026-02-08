<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="CapturaFacturas.aspx.cs" Inherits="Views_CapturaFacturas" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Asociar Obras </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server" enableviewstate="True">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <span style="text-align: center"> <h2>Asociacion de Facturas</h2></span>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Factura:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Remisiones Asociadas:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadTextBox ID="txtFactura" Runat="server" Height="25px" Skin="Metro" Width="200px" LabelWidth="80px" Resize="None">
                            </telerik:RadTextBox>
                        </td>
                        <td><telerik:RadTextBox ID="txtRemisiones" Runat="server" Height="25px" Skin="Metro" Width="600px" ReadOnly="true"/></td>
                        <td style="text-align: right">
                            <asp:ImageButton ID="btnGuardar" runat="server" ImageUrl="~/MetroImages/aceptar.png" EnableViewState="False" Height="35px" OnClick="btnGuardar_Click" /></td>
                        <td><asp:ImageButton ID="btnBuscarFactura" runat="server" ImageUrl="~/MetroImages/PreviewF.png" Height="35px" Style="text-align: right" OnClick="btnBuscarFactura_Click" /></td>
                        <td><asp:ImageButton ID="btnEliminarFacturas" runat="server" ImageUrl="~/MetroImages/BorrarDatos.png" Height="35px" Style="text-align: right" OnClick="btnEliminarFacturas_Click" /></td> 
                    </tr>
                </table>
            </div>

            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td colspan="1"><asp:Label ID="Label5" runat="server" Text="Desde:" Font-Bold="True" Font-Size="Small"></asp:Label>
                        <telerik:RadDatePicker ID="dtDesde" runat="server" Width="200px" Skin="Metro">
                            <Calendar EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                            </Calendar>
                            <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" LabelWidth="40%">
                                <EmptyMessageStyle Resize="None" />
                                <ReadOnlyStyle Resize="None" />
                                <FocusedStyle Resize="None" />
                                <DisabledStyle Resize="None" />
                                <InvalidStyle Resize="None" />
                                <HoveredStyle Resize="None" />
                                <EnabledStyle Resize="None" />
                            </DateInput>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDatePicker></td>
                        
                        <td colspan="1"><asp:Label ID="Label6" runat="server" Text="Hasta:" Font-Bold="True" Font-Size="Small"></asp:Label>
                        <telerik:RadDatePicker ID="dtHasta" runat="server" Skin="Metro">
                            <Calendar EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                            </Calendar>
                            <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" LabelWidth="40%">
                                <EmptyMessageStyle Resize="None" />
                                <ReadOnlyStyle Resize="None" />
                                <FocusedStyle Resize="None" />
                                <DisabledStyle Resize="None" />
                                <InvalidStyle Resize="None" />
                                <HoveredStyle Resize="None" />
                                <EnabledStyle Resize="None" />
                            </DateInput>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDatePicker></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label2" runat="server" Text="Cliente:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label3" runat="server" Text="Pedido - Fecha - Obra:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label4" runat="server" Text="Remision:" Font-Bold="True" Font-Size="Small"/></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td><telerik:RadComboBox ID="cboCliente" Runat="server" Skin="Metro" Width="350px" DropDownAutoWidth="Enabled" AutoPostBack="true" OnSelectedIndexChanged="cboCliente_SelectedIndexChanged"></telerik:RadComboBox></td>
                        <td><telerik:RadComboBox ID="cboObra" Runat="server"  Skin="Metro" Width="400px" OnSelectedIndexChanged="cboObra_SelectedIndexChanged" DropDownAutoWidth="Enabled"></telerik:RadComboBox></td>
                        <td> <telerik:RadTextBox ID="txtRemision" Runat="server" Height="25px" Skin="Metro" Width="100px" LabelWidth="80px" Resize="None"></telerik:RadTextBox></td>
                        <td></td>
                        <td><asp:ImageButton ID="btnBuscarRemision" runat="server" ImageUrl="~/MetroImages/PreviewF.png" Height="35px" Style="text-align: right" OnClick="btnBuscarRemision_Click"  /></td> 
                    </tr>
                </table>
            </div>
            
        </asp:Panel>

         <table width="100%" align="center">
            <tr align="center">
                <td colspan="2">
                    <telerik:RadGrid ID="GridRemisiones" runat="server" AllowPaging="True"
                        AutoGenerateColumns="False" 
                        PageSize="20" OnItemCommand="GridRemisiones_ItemCommand" Width="990px" Skin="Metro">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>

                            <ExpandCollapseColumn Created="True">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>

                                <telerik:GridBoundColumn DataField="NombreCliente"          HeaderText="Cliente"    UniqueName="NombreCliente"> </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreObra"             HeaderText="Obra"       UniqueName="NombreObra"> </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="IDPedido"               HeaderText="Pedido"     UniqueName="IDPedido"> </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaInicio"            HeaderText="Fecha"      UniqueName="FechaInicio" DataFormatString="{0:yyyy-MM-dd}" DataType="System.DateTime"> </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Remision"               HeaderText="Remision"   UniqueName="Remision"> </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="factura"                HeaderText="Factura"    UniqueName="factura"> </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn CommandName="Agregar" Text="Agregar"  UniqueName="column12"> </telerik:GridButtonColumn>

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

