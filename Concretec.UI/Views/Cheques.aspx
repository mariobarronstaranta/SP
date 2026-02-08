<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="Cheques.aspx.cs" Inherits="Views_Cheques" %>



<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Office2010Black" MultiPageID="RadMultiPage1" Width="95%">
            <Tabs>
                <telerik:RadTab Text="Cheques" NavigateUrl="Cheques.aspx" runat="server"></telerik:RadTab>
                <telerik:RadTab Text="Registro" NavigateUrl="Cheques.aspx?page=Registro" runat="server"></telerik:RadTab>
                <telerik:RadTab Text="Seguimiento" NavigateUrl="Cheques.aspx?page=Seguimiento" runat="server"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" Width="95%">
            <telerik:RadPageView runat="server" ID="RadPageView1">
                <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
                    <div style="text-align: left;">
                        <table runat="server" id="tblfiltros">
                            <tr>
                                <td>
                                    <asp:Label ID="lblCliente" runat="server" Text="Cliente:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblFechaInicio" runat="server" Text="Desde:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblFechaFin" runat="server" Text="Hasta:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Estatus:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="cboClienteBuscar" runat="server" CssClass="select">
                                    </asp:DropDownList>

                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="inicio" runat="server" MinDate="2005-01-01" Width="200px" EnableViewState="False" Skin="Metro">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Metro" runat="server"></Calendar>
                                        <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%" runat="server"></DateInput>
                                        <%-- <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton> --%>
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="fin" runat="server" MinDate="2005-01-01" Width="200px" EnableViewState="False" Skin="Metro">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Metro" runat="server"></Calendar>
                                        <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%" runat="server"></DateInput>
                                        <%-- <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton> --%>
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboEstatus" runat="server" CssClass="select"></asp:DropDownList>

                                </td>
                                <td>
                                    <a href="#" class="tooltip">
                                        <asp:ImageButton ID="btnBuscar" runat="server" EnableViewState="False" Height="35px" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnBuscar_Click" />
                                        <span>
                                            <img class="callout" src="../Imagenes/callout.gif" />
                                            <strong>Buscar Cheques</strong>
                                        </span>

                                    </a>
                                </td>
                                <td>
                                    <a href="#" class="tooltip">
                                        <asp:ImageButton ID="btnNuevo" runat="server" EnableViewState="False" Height="35px" ImageUrl="~/MetroImages/NuevoElemento.png" OnClick="btnNuevo_Click" />
                                        <span>
                                            <img class="callout" src="../Imagenes/callout.gif" />
                                            <strong>Registrar Nuevo Cheque</strong>
                                        </span>

                                    </a>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="gridCheques" runat="server" AutoGenerateColumns="False" Skin="Metro" OnItemCommand="gridCheques_ItemCommand1" CellSpacing="-1" GridLines="Both">
                                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="IdCheque" HeaderText="Id" UniqueName="IDCliente">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NombreCliente" HeaderText="Cliente" UniqueName="IDBanco">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NombreBanco" HeaderText="Banco" UniqueName="NombreCliente">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Monto" HeaderText="Monto" UniqueName="Monto">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FechaCobro" HeaderText="Fecha Cobro" UniqueName="FechaCobro">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NombreEstatus" HeaderText="Estatus" UniqueName="Banco">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NombreProtectora" FilterControlAltText="Filter column1 column" HeaderText="Protegido Por" UniqueName="column1">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridButtonColumn CommandName="Editar" HeaderText="Editar" Text="&gt;&gt;">
                                                </telerik:GridButtonColumn>
                                                <telerik:GridButtonColumn CommandName="Seguimiento" HeaderText="Seguimiento" Text="&gt;&gt;" UniqueName="Seguimiento">
                                                </telerik:GridButtonColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server">
                <asp:Panel ID="pnlRegistro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
                    <div style="text-align: left;">
                        <table id="tblRegistroCheques">
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Ciudad:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Cliente:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Banco:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Monto:" Font-Bold="True" Font-Size="Small"></asp:Label></td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="cbociudad" runat="server" CssClass="select" OnSelectedIndexChanged="cbociudad_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                                <td>
                                    <asp:DropDownList ID="cboCliente" runat="server" CssClass="select"></asp:DropDownList></td>
                                <td>
                                    <asp:DropDownList ID="cboBanco" runat="server" CssClass="select"></asp:DropDownList></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtMonto" runat="server" MaxLength="25" CssClass="txtgradiente"></telerik:RadNumericTextBox></td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Fecha Recepcion:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Fecha Cobro:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Protegido Por:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Ref Proteccion:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadDatePicker ID="dtRecepcion" runat="server" MinDate="2005-01-01" Width="200px" EnableViewState="False" Skin="Metro">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Metro" runat="server"></Calendar>
                                        <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%" runat="server"></DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="dtFechaCobro" runat="server" MinDate="2005-01-01" Width="200px" EnableViewState="False" Skin="Metro">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Metro" runat="server"></Calendar>
                                        <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%" runat="server"></DateInput>
                                    </telerik:RadDatePicker>
                                </td>

                                <td valign="top">
                                    <asp:DropDownList ID="cboProtectora" runat="server" CssClass="select">
                                        <asp:ListItem Value="-1">(Seleccione)</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:TextBox ID="txtReferencia" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="Label6" runat="server" Text="Observaciones:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Rows="5" Width="600px"></asp:TextBox>
                                    <asp:Label ID="txtIdCheque_Edicion" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <a href="#" class="tooltip">
                                        <asp:ImageButton ID="cmdGuardarCheque" runat="server" ImageUrl="~/MetroImages/Aceptar2.png" OnClick="cmdGuardarCheque_Click" Width="35px" />
                                        <span>
                                            <img class="callout" src="../Imagenes/callout.gif" />
                                            <strong>Guardar Informacion</strong>
                                        </span>

                                    </a>

                                </td>
                            </tr>
                        </table>


                    </div>
                </asp:Panel>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView3" runat="server">
                <asp:Panel ID="pnlSeguimientoHeader" runat="server" GroupingText="Seguimiento" CssClass="gridFilter">
                    <div style="text-align: left;">
                        <table width="80%" border="0" align="center">
                            <tr>
                                <td class="formLabelReporte">Clave:</td>
                                <td class="formLabelReporte">Cliente:</td>
                                <td class="formLabelReporte">Banco</td>
                                <td class="formLabelReporte">Monto</td>
                                <td class="formLabelReporte">Protectora</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="formValueReporte">
                                    <asp:Label ID="lblIdCheque" runat="server" Enabled="false" Font-Bold="true"></asp:Label></td>
                                <td class="formValueReporte">
                                    <asp:Label ID="lblClienteHeader" runat="server" Enabled="false" Font-Bold="true"></asp:Label></td>
                                <td class="formValueReporte">
                                    <asp:Label ID="lblBancoHeader" runat="server" Enabled="false" Font-Bold="true"></asp:Label></td>
                                <td class="formValueReporte">
                                    <asp:Label ID="lblMontoHeader" runat="server" Enabled="false" Font-Bold="true"></asp:Label></td>
                                <td class="formValueReporte">
                                    <asp:Label ID="lblProtectoraHeader" runat="server" Enabled="false" Font-Bold="true"></asp:Label></td>
                                <td>
                                    <a href="#" class="tooltip">
                                        <asp:ImageButton ID="cmdNuevoSeguimiento" runat="server" ImageUrl="~/MetroImages/NuevoElemento.png" OnClick="cmdNuevoSeguimiento_Click" Width="35px" />
                                        <span>
                                            <img class="callout" src="../Imagenes/callout.gif" />
                                            <strong>Agregar Seguimiento</strong>
                                        </span>

                                    </a>




                                </td>

                            </tr>
                        </table>
                    </div>
                    <div style="text-align: left;">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="gridChequesSeguimientos" runat="server" AutoGenerateColumns="False" Skin="Metro" CellSpacing="-1" GridLines="Both">
                                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="IdChequeSeguimiento" HeaderText="Clave" UniqueName="IdChequeSeguimiento">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FechaSeguimiento" HeaderText="Fecha" UniqueName="FechaSeguimiento">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ChequeEstatus" HeaderText="Estatus" UniqueName="ChequeEstatus">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Observaciones" HeaderText="Observaciones" UniqueName="Observaciones">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NombreUsuario" FilterControlAltText="Filter column column" HeaderText="Registrado Por" UniqueName="column">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlSeguimientoAgregar" runat="server" GroupingText="Nuevo Seguimiento" Visible="false">
                    <div style="text-align: left;">
                        <table width="80%" border="0" align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Estatus:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="Asegurado Por:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="Fecha Cobro:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Referencia:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:DropDownList ID="cboEstatusEdit" runat="server" OnSelectedIndexChanged="cboEstatusEdit_SelectedIndexChanged" AutoPostBack="true" CssClass="select">
                                    </asp:DropDownList>

                                </td>
                                <td valign="top">
                                    <asp:DropDownList ID="cboProtegidoPorEdit" runat="server" CssClass="select">
                                        <asp:ListItem Value="-1">(Seleccione)</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>
                                    <telerik:RadDatePicker ID="dtFechaCobroEdit" runat="server" MinDate="2005-01-01" Width="200px" EnableViewState="False" Skin="Metro" Enabled="false">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Metro" runat="server"></Calendar>
                                        <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%" runat="server"></DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtreferenciaedit" runat="server" Enabled="false" Width="200px" Text=""></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td class="formLabel" valign="top">Observaciones</td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtObservacionesSeguimiento" runat="server" TextMode="MultiLine" Rows="5" Width="600px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <a href="#" class="tooltip">
                                        <asp:ImageButton ID="btnGuardarSeguimiento" runat="server" ImageUrl="~/MetroImages/Aceptar2.png" OnClick="cmdGuardarSeguimiento_Click" Width="35px" />
                                        <span>
                                            <img class="callout" src="../Imagenes/callout.gif" />
                                            <strong>Guardar Seguimiento</strong>
                                        </span>

                                    </a>

                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </form>
</asp:Content>

