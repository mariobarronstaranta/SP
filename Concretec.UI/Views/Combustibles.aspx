<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="Combustibles.aspx.cs" Inherits="Views_Combustibles" %>

<%@ Register Src="~/UserControls/SalidaGas.ascx" TagPrefix="uc1" TagName="Salidas" %>
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
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Office2010Black" MultiPageID="RadMultiPage1" Width="95%"
            SelectedIndex="0">
            <Tabs>
                <telerik:RadTab Text="Tanques" NavigateUrl="Combustibles.aspx" runat="server" Selected="True"></telerik:RadTab>
                <telerik:RadTab Text="Lecturas" NavigateUrl="Combustibles.aspx?page=Lecturas" runat="server" Visible="false"></telerik:RadTab>
                <telerik:RadTab Text="Entradas" NavigateUrl="Combustibles.aspx?page=Entradas" runat="server" Visible="false"></telerik:RadTab>
                <telerik:RadTab Text="Salidas" NavigateUrl="Combustibles.aspx?page=Salidas" runat="server" Visible="false"></telerik:RadTab>
                <telerik:RadTab Text="Consumos" NavigateUrl="Combustibles.aspx?page=Consumos" runat="server" Visible="false"></telerik:RadTab>
                <telerik:RadTab Text="Ajustes" NavigateUrl="Combustibles.aspx?page=Ajustes" runat="server" Visible="false"></telerik:RadTab>
                <telerik:RadTab Text="Estadisticas" NavigateUrl="Combustibles.aspx?page=Estadisticas" runat="server" Visible="false"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" Width="95%">
            <telerik:RadPageView runat="server" ID="RadPageView1">
                <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
                    <div style="text-align: left;">
                        <table runat="server" id="tblfiltros">
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Ciudad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <telerik:RadComboBox ID="cboCiudadFiltro" runat="server" Skin="Metro"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:ImageButton ID="cmdbuscar" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="cmdbuscar_Click" Width="35px" /></td>
                                <td>
                                    <asp:ImageButton ID="cmdnuevo" runat="server" ImageUrl="~/MetroImages/NuevoElemento.png" OnClick="cmdnuevo_Click" Width="35px" /></td>
                                <td>
                                    <asp:TextBox ID="txtidtanqueregistro" runat="server" Visible="False"></asp:TextBox>
                                </td>
                            </tr>
                        </table>

                        <table runat="server" id="tblRegistro" visible="false">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Ciudad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Planta" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Nombre" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Capacidad (lts)" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Combustible" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td></td>
                                <td style="width: 35px"></td>
                            </tr>

                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="CboCiudadRegistro" runat="server" Skin="Metro" OnSelectedIndexChanged="CboCiudadRegistro_SelectedIndexChanged" AutoPostBack="True"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="CboPlantaRegistro" runat="server" Skin="Metro"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtNombreTanqueRegistro" runat="server"></telerik:RadTextBox></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtCapacidadTRegistro" runat="server"></telerik:RadNumericTextBox></td>
                                <td>
                                    <telerik:RadComboBox ID="CboTipoCombustible" runat="server" Skin="Metro">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="(Seleccione)" Value="-1" />
                                            <telerik:RadComboBoxItem runat="server" Text="Gasolina" Value="2" />
                                            <telerik:RadComboBoxItem runat="server" Text="Diesel" Value="3" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:ImageButton ID="cmdGuardarTanque" runat="server" ImageUrl="~/MetroImages/Aceptar2.png" OnClick="cmdGuardarTanque_Click" Width="35px" /></td>
                                <td style="width: 35px">
                                    <asp:ImageButton ID="cmdbacktanque" runat="server" ImageUrl="~/MetroImages/Previous.png" OnClick="cmdbacktanque_Click" Width="35px" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label54" runat="server" Text="Largo (cms)" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label55" runat="server" Text="Forma" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label56" runat="server" Text="Diametro (cms)" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lbldiametro2" runat="server" Text="Diametro 2 (cms)" Font-Bold="True" Font-Size="Small" Visible="False"></asp:Label></td>
                                <td></td>
                                <td></td>
                                <td></td>

                            </tr>
                            <tr>

                                <td>
                                    <telerik:RadNumericTextBox ID="txtAltura_registro" runat="server"></telerik:RadNumericTextBox></td>
                                <td>
                                    <telerik:RadComboBox ID="CboFormaCilindro" runat="server" Skin="Metro" AutoPostBack="True" OnSelectedIndexChanged="CboFormaCilindro_SelectedIndexChanged">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="(Seleccione)" Value="-1" />
                                            <telerik:RadComboBoxItem runat="server" Text="Circular" Value="C" />
                                            <telerik:RadComboBoxItem runat="server" Text="Eliptico" Value="E" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtDiametro1_registro" runat="server"></telerik:RadNumericTextBox></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtDiametro2_registro" runat="server" Visible="False"></telerik:RadNumericTextBox></td>
                                <td></td>
                                <td></td>
                                <td></td>

                            </tr>
                        </table>

                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="gridTanques" runat="server" AutoGenerateColumns="False" Skin="Metro" OnItemCommand="gridTanques_ItemCommand">
                                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="IdTanque" FilterControlAltText="Filter column7 column" HeaderText="Clave" UniqueName="column7">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Nombre" FilterControlAltText="Filter column column" HeaderText="Nombre" UniqueName="column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ciudad" FilterControlAltText="Filter column1 column" HeaderText="Ciudad" UniqueName="column1">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="planta" FilterControlAltText="Filter column2 column" HeaderText="Planta" UniqueName="column2">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="capacidad" FilterControlAltText="Filter column3 column" HeaderText="Capacidad" UniqueName="column3">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="InvActualLts" FilterControlAltText="Filter column8 column" HeaderText="Inv. Actual Lts" UniqueName="column8">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="InvActual15CLts" FilterControlAltText="Filter column9 column" HeaderText="Inv. Actual 15C" UniqueName="column9">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="InvActualCms" FilterControlAltText="Filter column4 column" HeaderText="Inv. Actual Cms" UniqueName="column4">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Movimiento" FilterControlAltText="Filter column10 column" HeaderText="Movimiento" UniqueName="column10">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FechaMovimiento" FilterControlAltText="Filter column5 column" HeaderText="Ultima Mov" UniqueName="column5">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridButtonColumn CommandName="Editar" FilterControlAltText="Filter column6 column" HeaderText="Editar" Text="&gt;&gt;" UniqueName="column6">
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
                <asp:Panel ID="pnlLecturas" runat="server" GroupingText="Filtros" CssClass="gridFilter">
                    <div style="text-align: left;">
                        <table runat="server" id="tbllecturasfiltro">
                            <tr>
                                <td style="height: 20px">
                                    <asp:Label ID="Label7" runat="server" Text="Ciudad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="height: 20px">
                                    <asp:Label ID="Label8" runat="server" Text="Tanque" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="height: 20px">
                                    <asp:Label ID="Label9" runat="server" Text="Desde" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="height: 20px">
                                    <asp:Label ID="Label10" runat="server" Text="Hasta" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="height: 20px"></td>
                                <td style="height: 20px"></td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboCiudadLecturas" runat="server" Skin="Metro" AutoPostBack="True" OnSelectedIndexChanged="cboCiudadLecturas_SelectedIndexChanged" Enabled="False"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cboTanquesLecturas" runat="server" Skin="Metro" Width="250px"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="dtiniciolectura" runat="server" Skin="Metro">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                        </Calendar>
                                        <DateInput DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy" LabelWidth="40%">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="dtfinlecturas" runat="server" Skin="Metro">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                        </Calendar>
                                        <DateInput DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy" LabelWidth="40%">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnbuscarlecturas" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnbuscarlecturas_Click" Width="35px" /></td>
                                <td>
                                    <asp:ImageButton ID="btnnuevalectura" runat="server" ImageUrl="~/MetroImages/NuevoElemento.png" OnClick="btnnuevalectura_Click" Width="35px" /></td>
                            </tr>
                        </table>

                        <table runat="server" id="tblregistrolecturas" visible="false">
                            <tr>
                                <td>
                                    <asp:Label ID="lblidlectura" runat="server" Text="Clave" Font-Bold="True" Font-Size="Small" Visible="false"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Tanque" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="Fecha" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="Hora" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Lectura(lts)" Font-Bold="True" Font-Size="Small"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Label58" runat="server" Text="Lectura(cms)" Font-Bold="True" Font-Size="Small"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Label60" runat="server" Text="Temperatura" Font-Bold="True" Font-Size="Small"></asp:Label>

                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtidlectura" runat="server" Visible="false" Width="50px"></asp:TextBox></td>
                                <td>
                                    <telerik:RadComboBox ID="cboTanqueLecturaRegistro" runat="server" Skin="Metro" Width="150px"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="dtfechalecturar" runat="server" Skin="Metro">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                        </Calendar>
                                        <DateInput DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy" LabelWidth="40%">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <telerik:RadTimePicker ID="drLecturaHora" runat="server">
                                    </telerik:RadTimePicker>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="lecturavalorr" runat="server" Skin="Metro" Width="100px"></telerik:RadNumericTextBox></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="LecturaValor_cms" runat="server" Skin="Metro" Width="100px"></telerik:RadNumericTextBox></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="LectValorTemp" runat="server" Skin="Metro" Width="100px"></telerik:RadNumericTextBox></td>


                                <td>
                                    <asp:ImageButton ID="cmdGuardarLectura" runat="server" ImageUrl="~/MetroImages/Aceptar2.png" OnClick="cmdGuardarLectura_Click" Width="35px" /></td>
                                <td>
                                    <asp:ImageButton ID="cmdBackLecturas" runat="server" ImageUrl="~/MetroImages/Previous.png" OnClick="cmdBackLecturas_Click" Width="35px" /></td>
                            </tr>
                        </table>

                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="gridlecturas" OnItemCommand="gridlecturas_ItemCommand" runat="server" AutoGenerateColumns="False" Skin="Metro">
                                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="idlectura" FilterControlAltText="Filter column3 column" HeaderText="Clave" UniqueName="column3">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="nombretanque" FilterControlAltText="Filter column column" HeaderText="Tanque" UniqueName="column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Fecha" FilterControlAltText="Filter column1 column" HeaderText="Fecha" UniqueName="column1">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Hora" FilterControlAltText="Filter column2 column" HeaderText="Hora" UniqueName="column2">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="valor" DataType="System.Double" FilterControlAltText="Filter column4 column" HeaderText="Lectura (lts)" UniqueName="column4">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Lectura_cms" FilterControlAltText="Filter column8 column" HeaderText="Lectura (cms)" UniqueName="column8">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Vol_Ref" FilterControlAltText="Filter column9 column" HeaderText="Volumen Ref" UniqueName="column9">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Temperatura " FilterControlAltText="Filter column7 column" HeaderText="Temperatura" UniqueName="column7">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="actualizacion" DataType="System.DateTime" FilterControlAltText="Filter column6 column" HeaderText="Fecha Registro" UniqueName="column6">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridButtonColumn CommandName="Editar" FilterControlAltText="Filter column5 column" HeaderText="Editar" Text="&gt;&gt;" UniqueName="column5">
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
            <telerik:RadPageView ID="RadPageView3" runat="server">
                <asp:Panel ID="pnlRegistrocombustible" runat="server" GroupingText="Filtros" CssClass="gridFilter">
                    <div style="text-align: left;">
                        <table runat="server" id="tblFiltrosEntrada">
                            <tr>
                                <td style="height: 20px">
                                    <asp:Label ID="Label15" runat="server" Text="Ciudad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="height: 20px">
                                    <asp:Label ID="Label16" runat="server" Text="Tanque" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="height: 20px">
                                    <asp:Label ID="Label17" runat="server" Text="Desde" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="height: 20px">
                                    <asp:Label ID="Label18" runat="server" Text="Hasta" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="height: 20px"></td>
                                <td style="height: 20px; width: 35px;"></td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cbociudadin_sel" runat="server" Skin="Metro" AutoPostBack="True" OnSelectedIndexChanged="cbociudadin_sel_SelectedIndexChanged" Enabled="False"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cbotanquein_sel" runat="server" Skin="Metro" Width="220px"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="dtdesdein_sel" runat="server" Skin="Metro">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                        </Calendar>
                                        <DateInput DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy" LabelWidth="40%">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="dtdesdehasta_sel" runat="server" Skin="Metro">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                        </Calendar>
                                        <DateInput DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy" LabelWidth="40%">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnbuscain" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnbuscain_Click" Width="35px" /></td>
                                <td style="width: 35px">
                                    <asp:ImageButton ID="btnagregain" runat="server" ImageUrl="~/MetroImages/NuevoElemento.png" OnClick="btnagregain_Click" Width="35px" /></td>
                            </tr>
                        </table>

                        <table runat="server" id="tblEntradaRegistro" visible="false">
                            <tr>
                                <td>
                                    <asp:Label ID="ClaveEntrada" runat="server" Text="Clave" Font-Bold="True" Font-Size="Small" Visible="false"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text="Tanque" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label20" runat="server" Text="Fecha" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label57" runat="server" Text="Hora" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label21" runat="server" Text="Proveedor" Font-Bold="True" Font-Size="Small"></asp:Label></td>

                                <td style="width: 100px">
                                    <asp:Label ID="Label49" runat="server" Font-Bold="True" Font-Size="Small" Text="Referencia"></asp:Label>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtClaveEntrada" runat="server" Visible="false" Width="30px" Enabled="false"></asp:TextBox></td>
                                <td>
                                    <telerik:RadComboBox ID="cbotanquereg_in" runat="server" Skin="Metro" Width="150px"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="dtregistroin" runat="server" Skin="Metro" Width="150px">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                        </Calendar>
                                        <DateInput DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy" LabelWidth="40%">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <telerik:RadTimePicker ID="dtEntradaC" runat="server">
                                    </telerik:RadTimePicker>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtproveedor" runat="server" Skin="Metro" Width="200px">
                                    </telerik:RadTextBox>
                                </td>
                                <td style="width: 100px">
                                    <telerik:RadTextBox ID="txtReferencia" runat="server" Skin="Metro" Width="100px">
                                    </telerik:RadTextBox>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btngrabarin" runat="server" ImageUrl="~/MetroImages/Aceptar2.png" OnClick="btngrabarin_Click" Width="35px" /></td>
                                <td style="width: 36px">
                                    <asp:ImageButton ID="btnregresarin" runat="server" ImageUrl="~/MetroImages/Previous.png" OnClick="btnregresarin_Click" Width="35px" /></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="Label61" runat="server" Text="Litros" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label62" runat="server" Text="Temperatura" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtlitrosin" runat="server" Skin="Metro" Width="150px"></telerik:RadNumericTextBox></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txttemperaturasin" runat="server" Skin="Metro" Width="150px"></telerik:RadNumericTextBox></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>

                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="gridEntradas" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Skin="Metro" OnItemCommand="gridEntradas_ItemCommand">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="IdMovimiento" FilterControlAltText="Filter column3 column" HeaderText="Clave" UniqueName="column3">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="nombretanque" FilterControlAltText="Filter column column" HeaderText="Tanque" UniqueName="column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Fecha" FilterControlAltText="Filter column1 column" HeaderText="Fecha" UniqueName="column1">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="nombreproveedor" FilterControlAltText="Filter column2 column" HeaderText="Proveedor" UniqueName="column2">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="referencia" FilterControlAltText="Filter column7 column" HeaderText="Referencia" UniqueName="column7">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="valor" FilterControlAltText="Filter column4 column" HeaderText="Litros" UniqueName="column4" DataType="System.Double">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FechaActualizacion" DataType="System.DateTime" FilterControlAltText="Filter column6 column" HeaderText="Fecha Registro" UniqueName="column6" DataFormatString="{0:yyyy-MM-dd hh:mm}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridButtonColumn CommandName="Editar" FilterControlAltText="Filter column5 column" HeaderText="Editar" Text="&gt;&gt;" UniqueName="column5">
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
            <telerik:RadPageView ID="RadPageView4" runat="server">

                <asp:Panel ID="Panel1" runat="server" GroupingText="Filtros" CssClass="gridFilter">
                    <div style="text-align: left;">
                        <table runat="server" id="EntradasFiltro" visible="true">
                            <tr>
                                <td>
                                    <asp:Label ID="Label29" runat="server" Text="Desde" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label33" runat="server" Text="Hasta" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label34" runat="server" Text="Tanque" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label35" runat="server" Text="Unidad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadDatePicker ID="dtDesdeSalida" runat="server" Skin="Metro">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
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
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="dtHastaSalida" runat="server" Skin="Metro">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
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
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cboTanqueFiltroSalida" runat="server" Skin="Metro" Width="220px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cboUnidadSalidaFiltro" runat="server" Skin="Metro">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnbuscaout" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnbuscaout_Click" Width="35px" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnagregainout" runat="server" ImageUrl="~/MetroImages/NuevoElemento.png" OnClick="btnagregainout_Click" Width="35px" />
                                </td>
                            </tr>
                        </table>
                        <table runat="server" id="EntradasRegistro" visible="false">
                            <tr>
                                <td><asp:Label ID="Label65" runat="server" Font-Bold="True" Font-Size="Small" Text="Tipo Movimiento"></asp:Label></td>
                                <td><asp:Label ID="Label66" runat="server" Font-Bold="True" Font-Size="Small" Text="Ciudad"></asp:Label></td>
                                <td><asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Size="Small" Text="Planta"></asp:Label></td>
                                <td><asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="Small" Text="Tanque"></asp:Label></td>
                                <td><asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Size="Small" Text="Unidad"></asp:Label></td>
                                <td></td>
                            </tr>
                            <tr>
                                
                                <td><asp:TextBox ID="txtTipoMov" runat="server" Enabled="False"  Width="100px" Text="Salida" ReadOnly="true"></asp:TextBox></td>
                                <td><telerik:RadComboBox ID="cboCiudad_Salida" runat="server" Skin="Metro"><Items><telerik:RadComboBoxItem runat="server" Text="(Seleccione)" Value="-1" /></Items></telerik:RadComboBox></td>
                                <td>
                                    <telerik:RadComboBox ID="cboplanta_salida_reg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboplanta_salida_reg_SelectedIndexChanged" Skin="Metro" Width="160px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cbotanque_salida_reg" runat="server" Skin="Metro" Width="160px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cbounidad_red_salida" runat="server" Skin="Metro">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="(Seleccione)" Value="-1" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                
                                    
                                <td>
                                    <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Size="Small" Text="Operador"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="Small" Text="Folio  Vale"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label63" runat="server" Font-Bold="True" Font-Size="Small" Text="Cons. Bomba"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label31" runat="server" Font-Bold="True" Font-Size="Small" Text="Fecha"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label32" runat="server" Font-Bold="True" Font-Size="Small" Text="Hora"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>

                            <tr>
                                
                                <td style="width: 160px">
                                    <telerik:RadComboBox ID="cbooperadores_salida" runat="server" Skin="Metro">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtFolioVale" runat="server" Culture="en-US" DbValueFactor="1" LabelWidth="64px" MinValue="0" Skin="Metro" Width="160px">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtTicketBomba" runat="server" Culture="en-US" DbValueFactor="1" LabelWidth="64px" MinValue="0" Skin="Metro" Width="160px">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="dtfechasurtido" runat="server" Skin="Metro">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
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
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <telerik:RadTimePicker ID="dthorasurtido" runat="server" Skin="Metro">
                                    </telerik:RadTimePicker>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                
                                <td style="height: 20px; width: 160px;">
                                    <asp:Label ID="Label59" runat="server" Font-Bold="True" Font-Size="Small" Text="Temperatura"></asp:Label>
                                </td>
                                <td style="height: 20px">
                                    <asp:Label ID="Label30" runat="server" Text="Litros Cargados" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="height: 20px"><asp:Label ID="Label67" runat="server" Text="Inv. Actual (15 C)" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="height: 20px"><asp:Label ID="Label68" runat="server" Text="Inv. Nuevo (15 C)" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="height: 20px">
                                    <asp:Label ID="lblClaveSalida" runat="server" Font-Bold="True" Font-Size="Small" Text="Clave" Visible="False"></asp:Label>
                                </td>
                                <td style="height: 20px"></td>
                            </tr>
                            <tr>
                                
                                <td style="width: 160px">
                                    <telerik:RadNumericTextBox ID="txtTempSalida" runat="server" Culture="en-US" DbValueFactor="1" LabelWidth="64px" MinValue="0" Skin="Metro" style="margin-bottom: 0px" Width="100px">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtltsdespachados" runat="server" Skin="Metro">
                                        <NegativeStyle Resize="None" />
                                        <NumberFormat ZeroPattern="n" />
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </telerik:RadNumericTextBox></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtltsdespachados0" runat="server" Skin="Metro">
                                        <NegativeStyle Resize="None" />
                                        <NumberFormat ZeroPattern="n" />
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtltsdespachados1" runat="server" Skin="Metro">
                                        <NegativeStyle Resize="None" />
                                        <NumberFormat ZeroPattern="n" />
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCveSalida" runat="server" Enabled="False" Visible="False" Width="30px"></asp:TextBox>
                                    <asp:ImageButton ID="btnGrabarSalida" runat="server" ImageUrl="~/MetroImages/Aceptar2.png" OnClick="btnGrabarSalida_Click" Width="35px" />
                                    <asp:ImageButton ID="btnRegresarSalida" runat="server" ImageUrl="~/MetroImages/Previous.png" OnClick="btnRegresarSalida_Click" Width="35px" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="Label27" runat="server" Text="Odometro Actual" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td><asp:Label ID="Label28" runat="server" Font-Bold="True" Font-Size="Small" Text="Horometro Actual"></asp:Label></td>
                                <td colspan="4"><asp:Label ID="Label64" runat="server" Font-Bold="True" Font-Size="Small" Text="Observaciones"></asp:Label></td>
                            </tr>
                            <tr>
                                
                                <td><telerik:RadNumericTextBox ID="txtodometro" runat="server" Culture="en-US" DbValueFactor="1" LabelWidth="64px" MinValue="0" Skin="Metro" Width="160px"></telerik:RadNumericTextBox></td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txthorimetro" runat="server" Skin="Metro">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td colspan="4">
                                    <telerik:RadTextBox ID="txtObservacionesSalida" runat="server" Width="450px">
                                    </telerik:RadTextBox>
                                </td> 
                            </tr>
                            <tr>
                                <td><asp:Label ID="Label69" runat="server" Text="Fecha Carga Ant." Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td><asp:Label ID="Label70" runat="server" Text="Distancia Recorrida" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td><asp:Label ID="Label71" runat="server" Text="Tiempo Trabajado" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td><asp:Label ID="Label72" runat="server" Text="Dist. Prod. recorrida" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td><asp:Label ID="Label73" runat="server" Text="Dist. Recorrida GPS" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td><telerik:RadNumericTextBox ID="RadNumericTextBox1" runat="server" Skin="Metro"></telerik:RadNumericTextBox></td>
                                <td><telerik:RadNumericTextBox ID="RadNumericTextBox2" runat="server" Skin="Metro"></telerik:RadNumericTextBox></td>
                                <td><telerik:RadNumericTextBox ID="RadNumericTextBox3" runat="server" Skin="Metro"></telerik:RadNumericTextBox></td>
                                <td><telerik:RadNumericTextBox ID="RadNumericTextBox4" runat="server" Skin="Metro"></telerik:RadNumericTextBox></td>
                                <td><telerik:RadNumericTextBox ID="RadNumericTextBox5" runat="server" Skin="Metro"></telerik:RadNumericTextBox></td>
                                <td></td>
                            </tr>
                        </table>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="gridSalidas" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Skin="Metro" OnItemCommand="gridSalidas_ItemCommand">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="IdMovimiento" FilterControlAltText="Filter column column" HeaderText="Clave" UniqueName="column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Fecha" FilterControlAltText="Filter column5 column" HeaderText="Fecha" UniqueName="column5">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Hora" FilterControlAltText="Filter column6 column" HeaderText="Hora" UniqueName="column6">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="nombretanque" FilterControlAltText="Filter column1 column" HeaderText="Tanque" UniqueName="column1">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="nombreplanta" FilterControlAltText="Filter column2 column" HeaderText="Planta Unidad" UniqueName="column2">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="nombreunidad" FilterControlAltText="Filter column3 column" HeaderText="Unidad" UniqueName="column3">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="operdor" FilterControlAltText="Filter column4 column" HeaderText="Operador" UniqueName="column4">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="valor" FilterControlAltText="Filter column7 column" HeaderText="Litros" UniqueName="column7">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="horimetro" FilterControlAltText="Filter column8 column" HeaderText="Horimetro" UniqueName="column8">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="odometro" FilterControlAltText="Filter column9 column" HeaderText="Odometro" UniqueName="column9">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridButtonColumn CommandName="Editar" FilterControlAltText="Filter column10 column" HeaderText="Editar" Text="&gt;&gt;" UniqueName="column10">
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
            <telerik:RadPageView ID="RadPageView5" runat="server">
                <asp:Panel ID="Panel2" runat="server" GroupingText="Filtros" CssClass="gridFilter">
                    <div style="text-align: left;">
                        <table runat="server" id="Table1">
                            <tr>
                                <td style="height: 20px">
                                    <asp:Label ID="Label36" runat="server" Text="Ciudad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="height: 20px">
                                    <asp:Label ID="Label37" runat="server" Text="Tanque" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="height: 20px">
                                    <asp:Label ID="Label38" runat="server" Text="Desde" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="height: 20px">
                                    <asp:Label ID="Label39" runat="server" Text="Hasta" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="height: 20px"></td>
                                <td style="height: 20px; width: 35px;"></td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboCdConsumos" runat="server" Skin="Metro" AutoPostBack="True" OnSelectedIndexChanged="cboCdConsumos_SelectedIndexChanged" Enabled="False"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cboTanqueConsumos" runat="server" Skin="Metro" Width="220px"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="dtDesdeConsumos" runat="server" Skin="Metro">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                        </Calendar>
                                        <DateInput DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy" LabelWidth="40%">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="dtHastaConsumos" runat="server" Skin="Metro">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                        </Calendar>
                                        <DateInput DateFormat="dd-MMM-yy" DisplayDateFormat="dd-MMM-yy" LabelWidth="40%">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnBuscarConsumos" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnBuscarConsumos_Click" Width="35px" /></td>
                                <td style="width: 35px">&nbsp;</td>
                            </tr>
                        </table>

                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="gridConsumos" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Skin="Metro">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="Nombre" FilterControlAltText="Filter column column" HeaderText="Tanque" UniqueName="column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="fecha" FilterControlAltText="Filter column1 column" HeaderText="Fecha" UniqueName="column1">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="lectura" FilterControlAltText="Filter column4 column" HeaderText="Lec. Inicial" UniqueName="column4">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="lecturafinal" FilterControlAltText="Filter column5 column" HeaderText="Lec. Final" UniqueName="column5">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="entrada" FilterControlAltText="Filter column2 column" HeaderText="Entradas" UniqueName="column2">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="salida" FilterControlAltText="Filter column3 column" HeaderText="Salidas" UniqueName="column3">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>

                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" ID="RadPageView6">
                <asp:Panel ID="Panel3" runat="server" GroupingText="Filtros" CssClass="gridFilter">
                    <div style="text-align: left;">
                        <table runat="server" id="tblAjustesFiltro" visible="true">
                            <tr>
                                <td>
                                    <asp:Label ID="Label45" runat="server" Text="Tanque" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label46" runat="server" Text="Movimiento" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label47" runat="server" Text="Desde" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label48" runat="server" Text="Hasta" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboTanqueAjustesFil" runat="server" Skin="Metro" Width="200px"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cboTipoMovFil" runat="server" Skin="Metro" Width="100px">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="(Seleccione)" Value="-1" />
                                            <telerik:RadComboBoxItem runat="server" Text="Entrada" Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Text="Salida" Value="2" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="dtDesdeAjuste" runat="server" Skin="Metro">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
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
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="dtHastaAjuste" runat="server" Skin="Metro">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
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
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnBuscarAjustes" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnBuscarAjustes_Click" Width="35px" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnAgregaAjuste" runat="server" ImageUrl="~/MetroImages/NuevoElemento.png" OnClick="btnAgregaAjuste_Click" Width="35px" />
                                </td>
                            </tr>
                        </table>
                        <table runat="server" id="tblAjustesRegistro" visible="false">
                            <tr>
                                <td>
                                    <asp:Label ID="Label40" runat="server" Text="Tanque" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label41" runat="server" Text="Movimiento" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label42" runat="server" Text="Valor Ajuste" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td style="width: 171px">
                                    <asp:Label ID="Label43" runat="server" Text="Fecha" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label44" runat="server" Text="Observaciones" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:ImageButton ID="btnGrabarAjuste" runat="server" ImageUrl="~/MetroImages/Aceptar2.png" OnClick="btnGrabarAjuste_Click" Width="35px" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnRegresarAjuste" runat="server" ImageUrl="~/MetroImages/Previous.png" OnClick="btnRegresarAjuste_Click" Width="35px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboTanqueAjustesR" runat="server" Skin="Metro" Width="200px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cboTipoMov" runat="server" Skin="Metro" Width="100px">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="(Seleccione)" Value="-1" />
                                            <telerik:RadComboBoxItem runat="server" Text="Entrada" Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Text="Salida" Value="2" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtvalorajuste" runat="server" Skin="Metro" Width="100px">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td style="width: 171px">
                                    <telerik:RadDatePicker ID="dtAjuste" runat="server" Skin="Metro">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
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
                                    </telerik:RadDatePicker>
                                </td>
                                <td colspan="3">
                                    <telerik:RadTextBox ID="txtObservaciones" runat="server" Skin="Metro" Width="300px">
                                    </telerik:RadTextBox>
                                </td>

                            </tr>
                        </table>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="gridAjustes" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Skin="Metro">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Nombre" FilterControlAltText="Filter column column" HeaderText="Tanque" UniqueName="column">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="fecha" FilterControlAltText="Filter column1 column" HeaderText="Fecha" UniqueName="column1">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="entrada" FilterControlAltText="Filter column2 column" HeaderText="Ajuste Entrada" UniqueName="column2">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="salida" FilterControlAltText="Filter column3 column" HeaderText="Ajuste Salida" UniqueName="column3">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="observaciones" FilterControlAltText="Filter column4 column" HeaderText="Observaciones" UniqueName="column4">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>

                            </td>
                        </tr>
                        <table>
                        </table>
                    </div>
                </asp:Panel>
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView7">
                <asp:Panel ID="Panel4" runat="server" GroupingText="Filtros" CssClass="gridFilter">
                    <div style="text-align: left;">
                        <table runat="server" id="Table2" visible="true">
                            <tr>
                                <td>
                                    <asp:Label ID="Label50" runat="server" Text="Planta" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label51" runat="server" Text="Unidad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label52" runat="server" Text="Desde" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label53" runat="server" Text="Hasta" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadComboBox ID="cboplantaE" runat="server" Skin="Metro" AutoPostBack="True" OnSelectedIndexChanged="cboplantaE_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cboUnidadE" runat="server" Skin="Metro">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="RadDatePicker1" runat="server" Skin="Metro">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
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
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="RadDatePicker2" runat="server" Skin="Metro">
                                        <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
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
                                    </telerik:RadDatePicker>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnBuscarAjustes0" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnBuscarAjustes_Click" Width="35px" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnBuscarAjustes1" runat="server" ImageUrl="~/MetroImages/ExcelExport.png" OnClick="btnBuscarAjustes_Click" Width="35px" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>

                                    <telerik:RadGrid ID="gridResumen" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Skin="Metro">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="planta" FilterControlAltText="Filter column column" HeaderText="Planta" UniqueName="column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NombreUnidad" FilterControlAltText="Filter column1 column" HeaderText="Unidad" UniqueName="column1">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="viajes" FilterControlAltText="Filter column2 column" HeaderText="Viajes" UniqueName="column2">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="M3" FilterControlAltText="Filter column3 column" HeaderText="M3 Surtidos" UniqueName="column3">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Combustible" FilterControlAltText="Filter column4 column" HeaderText="Combustible" UniqueName="column4">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Horas" FilterControlAltText="Filter column5 column" HeaderText="Horas" UniqueName="column5">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Kilometros" FilterControlAltText="Filter column6 column" HeaderText="Kms" UniqueName="column6">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </telerik:RadPageView>

        </telerik:RadMultiPage>

    </form>

</asp:Content>

