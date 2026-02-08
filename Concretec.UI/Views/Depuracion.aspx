<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="Depuracion.aspx.cs" Inherits="Views_Depuracion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">

        <span style="text-align: center">
            <h2>Depuracion de Informacion</h2>
        </span>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Desde:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Hasta:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label2" runat="server" Text="Ciudad:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label3" runat="server" Text="Cliente:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
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
                            <asp:DropDownList ID="cbociudad" runat="server" class="combo" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="cbociudad_SelectedIndexChanged"></asp:DropDownList></td>
                        <td>
                            <asp:DropDownList ID="cboCliente" runat="server" class="combo" Width="200px"></asp:DropDownList>

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
                                </span>
                            </a>

                            <a href="#" class="tooltip">
                                <asp:ImageButton ID="btnPlaneacion" runat="server" EnableViewState="False" Height="35px" ImageUrl="~/MetroImages/CalendarOk.png" OnClick="btnPlaneacion_Click" />
                                <span>
                                        <img class="callout" src="../Imagenes/callout.gif" />
                                        <strong>Guardar</strong><br />
                                        Programar para eliminacion todos los registros
                                </span>
                            </a>
                            <a href="#" class="tooltip">
                                <asp:ImageButton ID="btnCalendarizacion" runat="server" EnableViewState="False" Height="35px" ImageUrl="~/MetroImages/CalendarDate.png" OnClick="btnCalendarizacion_Click" OnClientClick = "ConfirmAbandonar()"/>
                                    <span>
                                        <img class="callout" src="../Imagenes/callout.gif" />
                                        <strong>Calendarizacion</strong><br />
                                        Ver Depuracion Programada
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
                        <telerik:GridBoundColumn HeaderText="Pedido" UniqueName="IDPedido" Visible="true"
                            DataField="IDPedido" DataType="System.Int32" SortExpression="IDPedido">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="IDObra" UniqueName="IDObra" Visible="false"
                            DataField="IDObra" SortExpression="IDObra">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="IDCliente" UniqueName="IDCliente" Visible="false"
                            DataField="IDCliente" SortExpression="IDCliente">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Obra" UniqueName="NombreObra" DataField="NombreObra"
                            SortExpression="NombreObra">
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
                        <telerik:GridBoundColumn DataField="FechaHoraCompromiso" HeaderText="Fecha Pedido"
                            UniqueName="column2">
                            <HeaderStyle Font-Bold="True" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CargaProgramada" FilterControlAltText="Filter column4 column" HeaderText="M3 Pedido" UniqueName="column4">
                         <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CargaViajes" FilterControlAltText="Filter column column" HeaderText="M3 Viajes" UniqueName="column">
                         <HeaderStyle Font-Bold="True" /></telerik:GridBoundColumn>
                        <telerik:GridButtonColumn CommandName="Cancelar" HeaderText="Depurar" Text="Borrar"
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

<script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Desea Borrar el pedido?")) {
                confirm_value.value = "SI";
            } else {
                confirm_value.value = "NO";
            }
            document.forms[0].appendChild(confirm_value);
        }

        function Confirmacion() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Desea Borrar el pedido?")) {
                confirm_value.value = "SI";
            } else {
                confirm_value.value = "NO";
            }
            document.forms[0].appendChild(confirm_value);
        }

        function ConfirmAbandonar() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Desea abandonar la pagina actual e ir a la calendarizacion de depuracion?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
</script>

</asp:Content>
