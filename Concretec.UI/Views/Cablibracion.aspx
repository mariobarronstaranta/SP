<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="Cablibracion.aspx.cs" Inherits="Views_Cablibracion" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Control de Verificaciones y Calibraciones</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>

        <span style="text-align: center">
            <h2>Control de Verificaciones y Calibraciones</h2>
        </span>


        <div style="text-align: left;">
            <table runat="server" id="tblFiltros" visible="true">
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Ciudad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Planta" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text="Desde" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label22" runat="server" Text="Hasta" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>

                    <td>
                        <telerik:RadComboBox ID="cboCiudadFiltro" runat="server" Skin="Metro" OnSelectedIndexChanged="cboCiudadFiltro_SelectedIndexChanged" Enabled="False"></telerik:RadComboBox>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="cboPlantaFiltro" runat="server" Skin="Metro"></telerik:RadComboBox>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="dtDesde" runat="server" Skin="Metro">
                            <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"></Calendar>
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
                        <telerik:RadDatePicker ID="dthasta" runat="server" Skin="Metro">
                            <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"></Calendar>
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
                        <asp:ImageButton ID="cmdbuscar" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="cmdbuscar_Click" Width="35px" /></td>
                    <td>
                        <asp:ImageButton ID="cmdnuevo" runat="server" ImageUrl="~/MetroImages/NuevoElemento.png" OnClick="cmdnuevo_Click" Width="35px" /></td>
                    <td>
                        <asp:TextBox ID="txtidCalibracionId" runat="server" Visible="False" Width="25px"></asp:TextBox></td>
                <td>
                        <asp:ImageButton ID="cmdExportar" runat="server" ImageUrl="~/MetroImages/ExcelExport.png" Width="35px" OnClick="cmdExportar_Click1" /></td>
                </tr>
                
            </table>
            <table id="tblresultados" runat="server">
                <tr>
                    <td colspan="7">
                        <telerik:RadGrid ID="gridResultados" runat="server" AutoGenerateColumns="False" OnNeedDataSource="gridResultados_NeedDataSource"  Skin="Metro" OnItemCommand="gridResultados_ItemCommand" OnItemDataBound="gridResultados_ItemDataBound">
<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="CalibracionId" FilterControlAltText="Filter column7 column" HeaderText="Clave" UniqueName="column7">
                                        <HeaderStyle Width="50px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="fechasalida" FilterControlAltText="Filter column column" HeaderText="Fecha" UniqueName="column">
                                        <HeaderStyle Width="100px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="horasalida" FilterControlAltText="Filter column6 column" HeaderText="Hora" UniqueName="column6">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CveCiudad" FilterControlAltText="Filter column1 column" HeaderText="Ciudad" UniqueName="column1">
                                        <HeaderStyle Width="100px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NombrePlanta" FilterControlAltText="Filter column2 column" HeaderText="Planta" UniqueName="column2">
                                        <HeaderStyle Width="100px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Material" FilterControlAltText="Filter column4 column" HeaderText="Mat. Prima" UniqueName="column4">
                                        <HeaderStyle Width="80px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TEO_Bajo" FilterControlAltText="Filter column3 column" HeaderText="Teo. Bajo" UniqueName="column3">
                                        <HeaderStyle Width="80px" />
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="CB2_Bajo" FilterControlAltText="Filter column4 column" HeaderText="CB2 Bajo" UniqueName="column4">
                                        <HeaderStyle Width="80px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ERROR_Bajo" FilterControlAltText="Filter column3 column" HeaderText="Error Bajo" UniqueName="column3">
                                        <HeaderStyle Width="80px" />
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="TEO_Alto" FilterControlAltText="Filter column4 column" HeaderText="Teo Alto" UniqueName="column4">
                                        <HeaderStyle Width="80px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CB2_Alto" FilterControlAltText="Filter column3 column" HeaderText="CB2 Alto" UniqueName="column3">
                                        <HeaderStyle Width="80px" />
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="ERROR_Alto" FilterControlAltText="Filter column5 column" HeaderText="Error Alto" UniqueName="column5">
                                        <HeaderStyle Width="80px" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>

            <table runat="server" id="tblRegistro" visible="false">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Ciudad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Planta" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Fecha" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Hora" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    
                    <td></td>
                    <td></td>
                    <td style="width: 35px"></td>
                </tr>

                <tr>
                    <td>
                        <telerik:RadComboBox ID="CboCiudadRegistro" runat="server" Skin="Metro" OnSelectedIndexChanged="CboCiudadRegistro_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></telerik:RadComboBox>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="CboPlantaRegistro" runat="server" Skin="Metro" AutoPostBack="True" OnSelectedIndexChanged="CboPlantaRegistro_SelectedIndexChanged"></telerik:RadComboBox>
                    </td>
                    <td>

                        <telerik:RadDatePicker ID="dtfechaRegistro" runat="server" Skin="Metro">
                            <Calendar EnableWeekends="True" Skin="Metro" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"></Calendar>
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
                        <asp:ImageButton ID="cmdGuardarTanque" runat="server" ImageUrl="~/MetroImages/Aceptar2.png" OnClick="cmdGuardarTanque_Click" Width="35px" /></td>
                    <td style="width: 35px">
                        <asp:ImageButton ID="cmdbacktanque" runat="server" ImageUrl="~/MetroImages/Previous.png" OnClick="cmdbacktanque_Click" Width="35px" /></td>
                <td style="width: 35px"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/MetroImages/Clean.png" OnClick="ImageButton1_Click" Width="35px" /></td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:Label ID="lblMensajes" runat="server" Text="Label" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            <table runat="server" id="tblRegistroCalibracion" visible="false">
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Materia Prima" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Teorico Bajo" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="CB2 Bajo" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                     <td>
                        <asp:Label ID="Label25" runat="server" Text="Error Bajo" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Teorico Alto" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="CB2 Alto" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                   <td>
                        <asp:Label ID="Label24" runat="server" Text="Error Alto" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Cemento" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_CEM_TEO_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>Kgs</B></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_CEM_CB2_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>Kgs</B></td>
                    <td>
                        <asp:Label ID="LBL_CEM_ERR_BAJO" runat="server" Font-Bold="True" Font-Size="Small" Width="100px"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_CEM_TEO_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox>  <B>Kgs</B></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_CEM_CB2_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox>  <B>Kgs</B></td>
                    <td><asp:Label ID="LBL_CEM_ERR_ALTO" runat="server" Font-Bold="True" Font-Size="Small" Width="50px"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="Agregados" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AGR_TEO_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>Kgs</B></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AGR_CB2_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>Kgs</B></td>
                    <td><asp:Label ID="LBL_AGR_ERR_BAJO" runat="server" Font-Bold="True" Font-Size="Small" Width="50px"></asp:Label></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AGR_TEO_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>Kgs</B></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AGR_CB2_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>Kgs</B></td>
                    <td><asp:Label ID="LBL_AGR_ERR_ALTO" runat="server" Font-Bold="True" Font-Size="Small" Width="50px"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text="Agua" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AGU_TEO_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>Lts</B></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AGU_CB2_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>Lts</B></td>
                    <td><asp:Label ID="LBL_AGU_ERR_BAJO" runat="server" Font-Bold="True" Font-Size="Small" Width="50px"></asp:Label></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AGU_TEO_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>Lts</B></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AGU_CB2_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>Lts</B></td>
                   <td><asp:Label ID="LBL_AGU_ERR_ALTO" runat="server" Font-Bold="True" Font-Size="Small" Width="50px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 26px">
                        <asp:Label ID="Label16" runat="server" Text="AD 1" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td style="height: 26px">
                        <telerik:RadNumericTextBox ID="TXT_AD1_TEO_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td style="height: 26px">
                        <telerik:RadNumericTextBox ID="TXT_AD1_CB2_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td style="height: 26px"><asp:Label ID="LBL_AD1_ERR_BAJO" runat="server" Font-Bold="True" Font-Size="Small" Width="50px"></asp:Label></td>
                    <td style="height: 26px">
                        <telerik:RadNumericTextBox ID="TXT_AD1_TEO_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td style="height: 26px">
                        <telerik:RadNumericTextBox ID="TXT_AD1_CB2_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td style="height: 26px"><asp:Label ID="LBL_AD1_ERR_ALTO" runat="server" Font-Bold="True" Font-Size="Small" Width="50px"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label17" runat="server" Text="AD 2" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AD2_TEO_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AD2_CB2_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td><asp:Label ID="LBL_AD2_ERR_BAJO" runat="server" Font-Bold="True" Font-Size="Small" Width="50px"></asp:Label></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AD2_TEO_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AD2_CB2_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td><asp:Label ID="LBL_AD2_ERR_ALTO" runat="server" Font-Bold="True" Font-Size="Small" Width="50px"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label18" runat="server" Text="AD 3" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AD3_TEO_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AD3_CB2_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td><asp:Label ID="LBL_AD3_ERR_BAJO" runat="server" Font-Bold="True" Font-Size="Small" Width="50px"></asp:Label></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AD3_TEO_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AD3_CB2_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td><asp:Label ID="LBL_AD3_ERR_ALTO" runat="server" Font-Bold="True" Font-Size="Small" Width="50px"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label19" runat="server" Text="AD 4" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AD4_TEO_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AD4_CB2_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td><asp:Label ID="LBL_AD4_ERR_BAJO" runat="server" Font-Bold="True" Font-Size="Small" Width="50px"></asp:Label></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AD4_TEO_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td>
                        <telerik:RadNumericTextBox ID="TXT_AD4_CB2_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td><asp:Label ID="LBL_AD4_ERR_ALTO" runat="server" Font-Bold="True" Font-Size="Small" Width="50px"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label20" runat="server" Text="AD 5" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    <td><telerik:RadNumericTextBox ID="TXT_AD5_TEO_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td><telerik:RadNumericTextBox ID="TXT_AD5_CB2_BAJO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td><asp:Label ID="LBL_AD5_ERR_BAJO" runat="server" Font-Bold="True" Font-Size="Small" Width="50px"></asp:Label></td>
                     <td><telerik:RadNumericTextBox ID="TXT_AD5_TEO_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td><telerik:RadNumericTextBox ID="TXT_AD5_CB2_ALTO" runat="server" Skin="Metro" Width="120px"></telerik:RadNumericTextBox> <B>ml</B></td>
                    <td><asp:Label ID="LBL_AD5_ERR_ALTO" runat="server" Font-Bold="True" Font-Size="Small" Width="50px"></asp:Label></td>
                </tr>
            </table>
            
        </div>



    </form>
</asp:Content>

