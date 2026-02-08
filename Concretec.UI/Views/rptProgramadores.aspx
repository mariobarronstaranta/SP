<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="rptProgramadores.aspx.cs" Inherits="Views_rptProgramadores" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">

        <span style="text-align: center">
            <h2>Reporte por Programador</h2>
        </span>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Desde:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Hasta:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label2" runat="server" Text="Ciudad:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label4" runat="server" Text="Cliente:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label3" runat="server" Text="Programador:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
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
                            <asp:DropDownList ID="cbociudad" runat="server" class="combo" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="cbociudad_SelectedIndexChanged"></asp:DropDownList></td>
                        <td>
                            <asp:DropDownList ID="cbocliente" runat="server" class="combo" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="cbocliente_SelectedIndexChanged"></asp:DropDownList>
                        </td>

                         <td><asp:DropDownList ID="cboprogramador" runat="server" class="combo" Width="150px"></asp:DropDownList>

                        </td>
                        <td>
                            <a href="#" class="tooltip">
                                <asp:ImageButton ID="btnBuscar" runat="server" EnableViewState="False" Height="35px" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnBuscar_Click" />
                                <span>
                                        <img class="callout" src="../Imagenes/callout.gif" />
                                        <strong>Buscar</strong>
                                </span>
                            
                            </a>

                            <a href="#" class="tooltip">
                                <asp:ImageButton ID="btnLimpiar" runat="server" EnableViewState="False" ForeColor="#000020" Height="35px" ImageUrl="~/MetroImages/Clean.png" OnClick="btnnuevo_Click" />
                                <span>
                                        <img class="callout" src="../Imagenes/callout.gif" />
                                        <strong>Limpiar</strong><br />
                                        Limpiar Busqueda
                                <img class="callout" src="../Imagenes/callout.gif" />
                            <strong>Guardar</strong><br /> Programar para eliminacion todos los registros
                            <img class="callout" src="../Imagenes/callout.gif" />
                            <strong>Calendarizacion</strong><br /> Ver Depuracion Programada
                                </span>
                            </a>

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
        
            <telerik:RadGrid ID="grdPedidos" runat="server" AllowPaging="True"
                AutoGenerateColumns="False" AllowAutomaticDeletes="True" AllowAutomaticInserts="True"
                AllowAutomaticUpdates="True" OnItemCommand="grdPedidos_ItemCommand" OnNeedDataSource="grdPedidos_NeedDataSource" OnDeleteCommand="grdPedidos_DeleteCommand" OnItemDataBound="grdPedidos_ItemDataBound"
                PageSize="20" AllowSorting="True" Width="990px" Skin="Metro" GroupPanelPosition="Top">

                <MasterTableView>
                    <RowIndicatorColumn>
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Created="True">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                    <Columns>
                        <telerik:GridBoundColumn HeaderText="Ciudad" UniqueName="IDPedido" Visible="true"
                            DataField="Ciudad" DataType="System.Int32" SortExpression="IDPedido">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Programador" UniqueName="IDObra"
                            DataField="NombreProgramador">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Cantidad Pedidos" UniqueName="IDCliente"
                            DataField="NumPedidos">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Vol. Pedidos" UniqueName="NombreObra" DataField="M3Pedidos">
                            <HeaderStyle Font-Bold="True" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Vol. Viajes" UniqueName="NombreCliente" DataField="M3Viajes">
                            <HeaderStyle Font-Bold="True" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="M3Remision" HeaderText="Vol Remisionado" UniqueName="column1">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PedidoProm" HeaderText="Vol Ped Prom"
                            UniqueName="column2">
                            <HeaderStyle Font-Bold="True" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="M3Cancelados" FilterControlAltText="Filter column4 column" HeaderText="Vol Cancelado" UniqueName="column4">
                         <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="M3Autorizados" FilterControlAltText="Filter column column" HeaderText="Vol Autorizado" UniqueName="column">
                         <HeaderStyle Font-Bold="True" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NumPedidoFueraHorario" FilterControlAltText="Filter column5 column" HeaderText="Vol Fuera Horario" UniqueName="column5">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn CommandName="Cancelar" HeaderText="Detalle" Text="Ver"
                            UniqueName="column3" FilterControlAltText="Filter column3 column">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridButtonColumn>

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


