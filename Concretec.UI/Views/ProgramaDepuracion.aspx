<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="ProgramaDepuracion.aspx.cs" Inherits="Views_ProgramaDepuracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">

        <span style="text-align: center"><h2>Calendario Depuracion de Informacion</h2></span>
        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Desde:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Hasta:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label2" runat="server" Text="Ciudad:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label3" runat="server" Text="Estatus:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
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
                            <asp:DropDownList ID="cbociudad" runat="server" class="combo" Width="200px" ></asp:DropDownList></td>
                        <td>
                            <asp:DropDownList ID="cboCliente" runat="server" class="combo" Width="200px">
                                <asp:ListItem Selected="True" Value="-1">(Todos)</asp:ListItem>
                                <asp:ListItem Value="PRO">Programado</asp:ListItem>
                                <asp:ListItem Value="CAN">Cancelado</asp:ListItem>
                                <asp:ListItem Value="ELIM">Eliminados</asp:ListItem>
                                <asp:ListItem Value="ERROR">Error</asp:ListItem>
                            </asp:DropDownList>

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
                                <asp:ImageButton ID="btnCalendarizacion" runat="server" EnableViewState="False" Height="35px" ImageUrl="~/MetroImages/CalendarDelete.png" OnClick="btnCalendarizacion_Click" />
                                    <span>
                                        <img class="callout" src="../Imagenes/callout.gif" />
                                        <strong>Depuracion</strong><br />
                                        Ver pagina de depuracion
                                    </span>
                            </a>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
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
                        <telerik:GridBoundColumn HeaderText="Clave" UniqueName="IDPedido" Visible="true"
                            DataField="IdCalendarioDepuracion" DataType="System.Int32" SortExpression="IDPedido">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Desde" UniqueName="IDObra" Visible="false"
                            DataField="Desde" SortExpression="IDObra">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Hasta" UniqueName="IDCliente" Visible="false"
                            DataField="Hasta" SortExpression="IDCliente">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Ciudad" UniqueName="NombreObra" DataField="CveCiudad"
                            SortExpression="NombreObra">
                            <HeaderStyle Font-Bold="True" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Cliente" UniqueName="NombreCliente" DataField="NombreCliente"
                            SortExpression="NombreCliente">
                            <HeaderStyle Font-Bold="True" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NombreUsuario" HeaderText="Usuario" UniqueName="column1">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Str_Desde" HeaderText="Desde"
                            UniqueName="column2">
                            <HeaderStyle Font-Bold="True" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Str_Hasta" FilterControlAltText="Filter column3 column" HeaderText="Hasta" UniqueName="column3">
                        <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaRegistro" FilterControlAltText="Filter column4 column" HeaderText="Fecha Registro" UniqueName="column4">
                        <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Estatus" FilterControlAltText="Filter column column" HeaderText="Estatus" UniqueName="column">
                        <HeaderStyle Font-Bold="True" />
                        </telerik:GridBoundColumn>

                        <telerik:GridButtonColumn FilterControlAltText="Filter column5 column" Text="Cancelar" UniqueName="column5" CommandName="Cancelar">
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


