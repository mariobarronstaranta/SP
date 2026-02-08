<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Vendedor.master" AutoEventWireup="true" 
    CodeFile="ListaPedidosLectura.aspx.cs" Inherits="Views_ListaPedidosLectura" EnableEventValidation="false" EnableViewStateMac="False"%>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">


        <div>
            <span style="text-align: center">
                <h2>Pedidos</h2>
            </span>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="En Autorizacion" Width="200px" BackColor="Yellow" Font-Bold="true"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Cancelado" Width="200px" BackColor="LightGray" Font-Bold="true"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Rechazado" Width="200px" BackColor="Red" Font-Bold="true"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Sin Viajes" Width="200px" BackColor="LightSalmon" Font-Bold="true"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Incompleto" Width="200px" BackColor="LightSteelBlue" Font-Bold="true"></asp:Label></td>
                </tr>
            </table>
        </div>
        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td>
                            <asp:Label ID="lblfiltersPoblacion" runat="server" Text="Fecha Entrega Inicio:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Fecha Entrega Fin:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Planta Dispensadora:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Estatus Pedido:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
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
                        <td>
                            <asp:DropDownList ID="cboPlanta" runat="server" class="combo" Width="190px"></asp:DropDownList></td>
                        <td>
                            <asp:DropDownList ID="cboEstatus" runat="server" class="combo" Width="190px">
                                <asp:ListItem Value="-1">(Seleccione)</asp:ListItem>
                                <asp:ListItem Value="2">Entregado</asp:ListItem>
                                <asp:ListItem Value="3">Programado</asp:ListItem>
                                <asp:ListItem Value="5">En Autorizacion</asp:ListItem>
                                <asp:ListItem Value="6">Autorizado</asp:ListItem>
                                <asp:ListItem Value="7">Rechazado</asp:ListItem>
                                <asp:ListItem Value="8">Cancelado</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                        <td>
                            <asp:ImageButton ID="btnBuscar" runat="server" EnableViewState="False" Height="35px" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnBuscar_Click" />
                            <asp:ImageButton ID="btnnuevo" runat="server" EnableViewState="False" ForeColor="#000020" Height="35px" ImageUrl="~/MetroImages/NuevoElemento.png" OnClick="btnnuevo_Click" Visible="false" />
                            <asp:ImageButton ID="btnPlaneacion" runat="server" EnableViewState="False" Height="35px" ImageUrl="~/MetroImages/Calendarizar.png" OnClick="btnPlaneacion_Click" />
                            <asp:ImageButton ID="btnExportar" runat="server" ImageUrl="~/MetroImages/ExcelExport.png" OnClick="btnExportar_Click" Height="35px" EnableViewState="False" />
                            <asp:ImageButton ID="btnHelp" runat="server" ImageUrl="~/MetroImages/HelpSign.png" OnClick="btnHelp_Click" Height="35px" EnableViewState="False" Visible="false" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>

                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Total M3 Pedidos:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="LblTotalPedidos" runat="server" Font-Bold="True" Font-Size="Small" Width="150px"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Total M3 Programados:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="LblTotalRemision" runat="server" Font-Bold="True" Font-Size="Small" Width="150px"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label10w" runat="server" Text="Total M3 Remisionados:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="LblTotalRemision2" runat="server" Font-Bold="True" Font-Size="Small" Width="150px"></asp:Label></td>
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
        
            <telerik:RadGrid ID="grdPedidos" runat="server" AllowPaging="True"
                AutoGenerateColumns="False" AllowAutomaticDeletes="True" AllowAutomaticInserts="True"
                AllowAutomaticUpdates="True" OnItemCommand="grdPedidos_ItemCommand" OnNeedDataSource="grdPedidos_NeedDataSource" OnDeleteCommand="grdPedidos_DeleteCommand" OnItemDataBound="grdPedidos_ItemDataBound"
                PageSize="20" AllowSorting="True" Width="100%" Skin="Metro">

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
                        <telerik:GridBoundColumn HeaderText="Pedido" UniqueName="IDPedido" Visible="true" DataField="IDPedido" DataType="System.Int32" SortExpression="IDPedido">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="IDObra" UniqueName="IDObra" Visible="false" DataField="IDObra" SortExpression="IDObra">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="IDCliente" UniqueName="IDCliente" Visible="false" DataField="IDCliente" SortExpression="IDCliente">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Obra" UniqueName="NombreObra" DataField="NombreObra" SortExpression="NombreObra">
                            <HeaderStyle Font-Bold="True" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Cliente" UniqueName="NombreCliente" DataField="NombreCliente"
                            SortExpression="NombreCliente">
                            <HeaderStyle Font-Bold="True" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="Estatus" HeaderText="Estatus" UniqueName="column1">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaHoraCompromiso" HeaderText="Fecha Entrega"
                            UniqueName="column2">
                            <HeaderStyle Font-Bold="True" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn HeaderText="M3 Pedido" UniqueName="M3Pro" DataField="CargaProgramada"
                            SortExpression="NombreCliente">
                            <HeaderStyle Font-Bold="True" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn HeaderText="M3 Viaje" UniqueName="M3Via" DataField="CargaViajes"
                            SortExpression="NombreCliente">
                            <HeaderStyle Font-Bold="True" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>


                        <telerik:GridBoundColumn DataField="CargaRemisiones" FilterControlAltText="Filter column4 column" HeaderText="M3 Rem" UniqueName="column4">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>


                        <%--<telerik:GridButtonColumn CommandName="Editar" HeaderText="Editar" Text="Editar"
                            UniqueName="column">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridButtonColumn>--%>
                        
                        <telerik:GridButtonColumn CommandName="Detalle" HeaderText="Detalle" Text="Ver" UniqueName="column">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridButtonColumn>
                        
                        <%--<telerik:GridButtonColumn CommandName="Cerrar" HeaderText="Cerrar"
                            Text="Cerrar" UniqueName="column3">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridButtonColumn>--%>

<%--                        <telerik:GridButtonColumn CommandName="Cancelar" HeaderText="Cancelar" ConfirmText="Desea eliminar el pedido , asi como todos sus viajes relacionados.? Los datos no podran ser recuperados y su usuario quedara registrado."
                            Text="Cancelar" UniqueName="column3">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridButtonColumn>--%>

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
        </div>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
    </form>
</asp:Content>
