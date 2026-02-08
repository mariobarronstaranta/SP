<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Contabilidad.master" AutoEventWireup="true"
    CodeFile="AutorizacionPedidos.aspx.cs" Inherits="Views_AutorizacionPedidos" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">

        <table width="100%">
            <tr>
                <td style="text-align: center">
                    <h2>Autorización de Pedidos</h2>
                </td>
            </tr>
        </table>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="Label2" runat="server" Text="Desde:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label3" runat="server" Text="Hasta:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>&nbsp;</td>
                        <td><asp:Label ID="Label1" runat="server" Text="Estatus:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
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
                        <td></td>
                        <td>
                            <asp:DropDownList ID="cboEstatus" runat="server" CssClass="select">
                                
                                <asp:ListItem Selected="True" Value="-1">(Seleccione)</asp:ListItem>
                                <asp:ListItem Value="6">Autorizado</asp:ListItem>
                                <asp:ListItem Value="7">Rechazado</asp:ListItem>
                                <asp:ListItem Value="5">En Autorizacion</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png"
                                OnClick="btnBuscar_Click" Height="35px" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>


        <table width="100%">
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <table align="center" style="width: 97%">

                                    <tr>
                                        <td colspan="2">
                                            <telerik:RadGrid ID="grdClientes" runat="server" AllowPaging="True"
                                                AutoGenerateColumns="False" OnNeedDataSource="grdClientes_NeedDataSource" OnItemCommand="grdClientes_ItemCommand"
                                                PageSize="50" Skin="Metro" GroupPanelPosition="Top" OnItemDataBound="grdClientes_ItemDataBound">
                                                <MasterTableView>
                                                    <RowIndicatorColumn>
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                    </RowIndicatorColumn>
                                                    <ExpandCollapseColumn Created="True">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                    </ExpandCollapseColumn>
                                                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                                                    <Columns>
                                                        <telerik:GridBoundColumn HeaderText="CvePedido" UniqueName="column"
                                                            DataField="IDPedido">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="NombrePlanta" FilterControlAltText="Filter column6 column" HeaderText="Planta" UniqueName="column6">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FechaCompromiso" FilterControlAltText="Filter column7 column" HeaderText="Fecha Pedido" UniqueName="column7">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn HeaderText="Cliente" UniqueName="column1"
                                                            DataField="NombreCliente">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn HeaderText="Obra" UniqueName="column" DataField="NombreObra">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="StrVolumen" FilterControlAltText="Filter column8 column" HeaderText="Volumen" UniqueName="column8">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn HeaderText="Credito" UniqueName="column2"
                                                            DataField="LimiteCredito">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn HeaderText="Saldo" UniqueName="column3"
                                                            DataField="SaldoActual">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn HeaderText="Solicitado" UniqueName="column4" DataField="CreditoSolicitado"
                                                            DataType="System.Double">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Estatus" HeaderText="Estatus"
                                                            UniqueName="column5">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridButtonColumn HeaderText="Detalle" Text="Ver"
                                                            UniqueName="column" CommandName="Detalle">
                                                        </telerik:GridButtonColumn>
                                                    </Columns>

                                                    <EditFormSettings>
                                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                                    </EditFormSettings>

                                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                                </MasterTableView>

                                                <PagerStyle PageSizeControlType="RadComboBox" Mode="NumericPages"></PagerStyle>

                                                <FilterMenu EnableImageSprites="False"></FilterMenu>
                                            </telerik:RadGrid>
                                            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                                            </telerik:RadScriptManager>
                                            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                                                <AjaxSettings>
                                                    <telerik:AjaxSetting AjaxControlID="RadGrid1">
                                                    </telerik:AjaxSetting>
                                                </AjaxSettings>
                                            </telerik:RadAjaxManager>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 599px">&nbsp;
                                        </td>
                                        <td style="text-align: right">&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</asp:Content>
