<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="AdmonCombustibles.aspx.cs" Inherits="Views_AdmonCombustibles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table runat="server" id="tblCamposGenerales" cellspacing="1" visible="true">
                    <tr>
                        <td><asp:Label ID="Label1" runat="server" Text="Movimiento" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label2" runat="server" Text="Ciudad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label3" runat="server" Text="Planta" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label4" runat="server" Text="Tanque" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td style="width: 162px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td><telerik:RadComboBox ID="CboTipoMovimiento" runat="server" Skin="Metro" AutoPostBack="True" OnSelectedIndexChanged="CboTipoMovimiento_SelectedIndexChanged">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="(Seleccione)" Value="-1" />
                                <telerik:RadComboBoxItem runat="server" Text="Entrada" Value="1" />
                                <telerik:RadComboBoxItem runat="server" Text="Salida" Value="2" />
                                <telerik:RadComboBoxItem runat="server" Text="Ajustes" Value="3" />
                            </Items>
                            </telerik:RadComboBox></td>
                        <td><telerik:RadComboBox ID="CboCiudad" runat="server" Skin="Metro" AutoPostBack="true" OnSelectedIndexChanged="CboCiudad_SelectedIndexChanged"></telerik:RadComboBox></td>
                        <td><telerik:RadComboBox ID="CboPlanta" runat="server" Skin="Metro" AutoPostBack="True" OnSelectedIndexChanged="CboPlanta_SelectedIndexChanged" ></telerik:RadComboBox></td>
                        <td><telerik:RadComboBox ID="CboTanque" runat="server" Skin="Metro" AutoPostBack="True" OnSelectedIndexChanged="CboTanque_SelectedIndexChanged"></telerik:RadComboBox></td>
                        <td style="width: 162px">&nbsp;</td>
                    </tr>

                    <tr>
                        <td><asp:Label ID="Label6" runat="server" Text="Fecha" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label7" runat="server" Text="Hora" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label8" runat="server" Text="Temp. Actual" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>&nbsp;</td>
                        <td style="width: 162px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td><telerik:RadDatePicker ID="dtfechalecturar" runat="server" Skin="Metro">
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
                        <td><telerik:RadTimePicker ID="drLecturaHora" runat="server">
                                    </telerik:RadTimePicker></td>
                        <td><telerik:RadTextBox ID="txtTemperatura" runat="server" Skin="Metro">
                                    </telerik:RadTextBox></td>
                        <td>&nbsp;</td>
                        <td style="width: 162px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="5"><asp:Label ID="Label30" runat="server" Text="Datos Actuales del Tanque" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" Text="Inventario Actual Cms"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" Text="Inventario Actual Lts"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" Text="Inventario Actual 15C"></asp:Label>
                        </td>
                        <td><asp:Label ID="Label31" runat="server" Font-Bold="True" Font-Size="Small" Text="Temperatura Ultima Carga"></asp:Label></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadTextBox ID="txtInvActualCms" runat="server" ReadOnly="True" Skin="Metro">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtInvActual" runat="server" ReadOnly="True" Skin="Metro">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtInv15Grados" runat="server" ReadOnly="True" Skin="Metro">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtTemperauraUltimaCarga" runat="server" Skin="Metro" ReadOnly="True">
                            </telerik:RadTextBox>
                        </td>
                        <td></td>
                    </tr>
                </table>
             <%-- Seccion de salidas de combustibles --%>
             <table runat="server" id="tblSalidas" cellspacing="1" visible="true">
                 <tr>
                     <td colspan="5"><asp:Label ID="Label11" runat="server" Text="Seccion Salidas" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                 </tr>
                 <tr>
                     <td>
                         <asp:Label ID="Label43" runat="server" Font-Bold="True" Font-Size="Small" Text="Planta Unidad"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" Text="Unidad"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" Text="Operador"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" Text="Folio Vale"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Small" Text="Cons. Bomba"></asp:Label>
                     </td>
                 </tr>

                 <tr>
                     <td>
                         <telerik:RadComboBox ID="CboPlantaUnidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CboPlantaUnidad_SelectedIndexChanged" Skin="Metro">
                         </telerik:RadComboBox>
                     </td>
                     <td>
                         <telerik:RadComboBox ID="CboUnidad_Salida" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CboUnidad_Salida_SelectedIndexChanged" Skin="Metro">
                         </telerik:RadComboBox>
                     </td>
                     <td>
                         <telerik:RadComboBox ID="CboOperador_Salida" runat="server" Skin="Metro">
                         </telerik:RadComboBox>
                     </td>
                     <td>
                         <telerik:RadTextBox ID="txtFolioVale_Salida" runat="server" Skin="Metro">
                         </telerik:RadTextBox>
                     </td>
                     <td>
                         <telerik:RadTextBox ID="txtConsBomba_Salida" runat="server" Skin="Metro">
                         </telerik:RadTextBox>
                     </td>
                 </tr>
                 <%-- Segundo bloque de la tabla de Salidas --%>
                 <tr>
                     <td>
                         <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Small" Text="Litros Cargados"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Size="Small" Text="Odometro Actual"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Size="Small" Text="Horometro Actual"></asp:Label>
                     </td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td>
                         <telerik:RadTextBox ID="txtLitros_Salida" runat="server" Skin="Metro">
                         </telerik:RadTextBox>
                     </td>
                     <td>
                         <telerik:RadTextBox ID="txtOdometroActual_Salida" runat="server" Skin="Metro">
                         </telerik:RadTextBox>
                     </td>
                     <td>
                         <telerik:RadTextBox ID="txtHorometroActual_Salida" runat="server" Skin="Metro">
                         </telerik:RadTextBox>
                     </td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td>
                         <asp:Label ID="Label46" runat="server" Font-Bold="True" Font-Size="Small" Text="Litros Cargados 15C"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="Label44" runat="server" Font-Bold="True" Font-Size="Small" Text="Inv. Nuevo Temp Actual"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="Small" Text="Inv. Nuevo Existente 15C"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="Label47" runat="server" Font-Bold="True" Font-Size="Small" Text="Inv. Nuevo Cms"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Small" Text="Fecha Carga Anterior"></asp:Label>
                     </td>
                 </tr>

                 <tr>
                     <td>
                         <telerik:RadTextBox ID="txtLitros_15C_Salida" runat="server" ReadOnly="True" Skin="Metro">
                         </telerik:RadTextBox>
                     </td>
                     <td>
                         <telerik:RadTextBox ID="txtInventarioTA_Salida" runat="server" ReadOnly="True" Skin="Metro">
                         </telerik:RadTextBox>
                     </td>
                     <td>
                         <telerik:RadTextBox ID="txtInventario15C_Salida" runat="server" ReadOnly="True" Skin="Metro">
                         </telerik:RadTextBox>
                     </td>
                     <td>
                         <telerik:RadTextBox ID="txtInvNuevoCms_Salida" runat="server" ReadOnly="True" Skin="Metro">
                         </telerik:RadTextBox>
                     </td>
                     <td>
                         <telerik:RadDatePicker ID="dtCargaAnterior_Salida" runat="server" Enabled="False" Skin="Metro">
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
                 </tr>
                 <%-- Tercer bloque de la tabla de Salidas --%>
                 <tr>
                     <td>
                         <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Size="Small" Text="Distancia Recorrida Odometro"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="Small" Text="Tiempo Trabajado (Horometro)"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Size="Small" Text="Distancia Productiva" Visible="False"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Size="Small" Text="Distancia Recorrida GPS" Visible="False"></asp:Label>
                     </td>
                     <td></td>
                 </tr>
                 <tr>
                     <td style="height: 25px">
                         <telerik:RadTextBox ID="txtDistanciaOdometro_Salida" runat="server" Skin="Metro" Enabled="False">
                         </telerik:RadTextBox>
                     </td>
                     <td style="height: 25px">
                         <telerik:RadTextBox ID="txtTiempoTrabajado_Salida" runat="server" Skin="Metro" Enabled="False">
                         </telerik:RadTextBox>
                     </td>
                     <td style="height: 25px">
                         <telerik:RadTextBox ID="txtDistanciaProductiva_Salida" runat="server" Skin="Metro" Visible="False" Enabled="False">
                         </telerik:RadTextBox>
                     </td>
                     <td style="height: 25px">
                         <telerik:RadTextBox ID="txtDitanciaRecorridaGPS_Salida" runat="server" Skin="Metro" Visible="False" Enabled="False">
                         </telerik:RadTextBox>
                     </td>
                     <td style="height: 25px">
                         </td>
                 </tr>
                 <%-- Cuarto bloque de la tabla de Salidas --%>
                 <tr>
                     <td colspan="5"><asp:Label ID="Label25" runat="server" Text="Observaciones" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                 </tr>
                 <tr>
                     <td colspan="5">
                         <telerik:RadComboBox ID="CboObservaciones_Salida" runat="server" Skin="Metro" Width="500px"></telerik:RadComboBox>
                     </td>
                 </tr>

                 <tr>
                     <td colspan="5">
                         
                         <asp:ImageButton ID="btnCalcular_Salidas" runat="server" ImageUrl="~/MetroImages/Calcular_over.png" OnClick="btnCalcular_Salidas_Click" Width="150px" />
                         <asp:ImageButton ID="btngrabar_salidas" runat="server" ImageUrl="~/MetroImages/Grabar_Over.png" OnClick="btngrabar_salidas_Click" Visible="False" Width="120px" />
                         
                         <br />
                         <asp:Label ID="ErroresSalidas" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                         
                     </td>
                 </tr>
                 
             </table>

             <%-- Seccion de Entradas de combustibles --%>
             <table runat="server" id="tblEntradas" cellspacing="1" visible="true">
                 <tr>
                     <td colspan="5"><asp:Label ID="Label26" runat="server" Text="Seccion Entradas" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                 </tr>
                 <tr>
                     <td><asp:Label ID="Label27" runat="server" Text="Proveedor" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                     <td><asp:Label ID="Label28" runat="server" Text="Remision" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                     <td><asp:Label ID="Label29" runat="server" Text=" Carga Lts Temp. Ambiente" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                     <td>
                         <asp:Label ID="Label45" runat="server" Font-Bold="True" Font-Size="Small" Text="Carga Lts Temp. 15C"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="Label33" runat="server" Font-Bold="True" Font-Size="Small" Text="Inv. Nuevo Cms"></asp:Label>
                     </td>
                 </tr>

                 <tr>
                    <td><telerik:RadComboBox ID="cboProveedor_Entrada" runat="server" Skin="Metro">
                        <Items>
                            <telerik:RadComboBoxItem runat="server" Selected="True" Text="(Seleccione)" Value="-1" />
                            <telerik:RadComboBoxItem runat="server" Text="Proveedor A" Value="1" />
                            <telerik:RadComboBoxItem runat="server" Text="Proveedor 2" Value="2" />
                        </Items>
                        </telerik:RadComboBox></td>
                     <td><telerik:RadTextBox ID="txtRemision_Entrada" runat="server" Skin="Metro"></telerik:RadTextBox></td>
                     <td><telerik:RadTextBox ID="txtLitros_Entrada" runat="server" Skin="Metro"></telerik:RadTextBox></td>
                     <td>
                         <telerik:RadTextBox ID="txtLitros_15C_Entrada" runat="server" ReadOnly="True" Skin="Metro">
                         </telerik:RadTextBox>
                     </td>
                     <td>
                         <telerik:RadTextBox ID="txtInvNuevoCms_Entrada" runat="server" ReadOnly="True" Skin="Metro">
                         </telerik:RadTextBox>
                     </td>
                     
                </tr>
                 <tr>
                     <td><asp:Label ID="Label41" runat="server" Text="Inv. Nuevo Existente 15C" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                     <td><asp:Label ID="Label42" runat="server" Text="Inv. Nuevo Temp Ambiente" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                     <td>
                         <asp:Label ID="Label32" runat="server" Font-Bold="True" Font-Size="Small" Text="Observaciones"></asp:Label>
                     </td>
                     <td></td>
                     <td></td>
                 </tr>
                 <tr>
                     <td><telerik:RadTextBox ID="txtInvN15C_Entrada" runat="server" Skin="Metro" Enabled="False"></telerik:RadTextBox></td>
                     <td><telerik:RadTextBox ID="txtInvNAmbiente_Entrada" runat="server" Skin="Metro" Enabled="False"></telerik:RadTextBox></td>
                     <td colspan="2">
                         <telerik:RadComboBox ID="CboObservaciones_Entradas" runat="server" Skin="Metro" Width="400px">
                         </telerik:RadComboBox>
                     </td>
                     
                     <td></td>
                 </tr>
                 <%-- Segundo bloque de la tabla de Salidas --%>
                 <tr>
                     
                     <td colspan="4">&nbsp;</td>
                 </tr>
                 <tr>
                     
                     <td colspan="4">
                         &nbsp;<asp:ImageButton ID="btnCalcularIn" runat="server" ImageUrl="~/MetroImages/Calcular_over.png" OnClick="btnCalcularIn_Click" Width="150px" />
                         <asp:ImageButton ID="btngrabarin" runat="server" ImageUrl="~/MetroImages/Grabar_Over.png" OnClick="btngrabarin_Click" Width="120px" Visible="False" />
                         <br />
                         <asp:Label ID="ErroresEntrada" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                     </td>
                 </tr>
             </table>

            
             <%-- Seccion de Ajustes de combustibles --%>
             <table runat="server" id="tblAjustes" cellspacing="1" visible="true">
                 <tr>
                     <td colspan="5"><asp:Label ID="Label34" runat="server" Text="Seccion Ajustes" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                 </tr>
                  <tr>
                      <td><asp:Label ID="Label35" runat="server" Text="Auditor" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                      <td><asp:Label ID="Label36" runat="server" Text="Inv. Existente Real Cms" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                      <td><asp:Label ID="Label40" runat="server" Text="Inv. Existente Real Lts" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                      <td><asp:Label ID="Label37" runat="server" Text="Ajuste Lts" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                      <td><asp:Label ID="Label38" runat="server" Text="Inv. Nuevo Existente 15C" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                 </tr>
                 <tr>
                     <td><telerik:RadTextBox ID="txtAuditor_Ajustes" runat="server" Skin="Metro"></telerik:RadTextBox></td>
                     <td><telerik:RadTextBox ID="txtInvExistenteRealCms_Ajustes" runat="server" Skin="Metro"></telerik:RadTextBox></td>
                     <td><telerik:RadTextBox ID="txtInvExistenteRealLts_Ajustes" runat="server" Skin="Metro"></telerik:RadTextBox></td>
                     <td><telerik:RadTextBox ID="txtLitros_Ajuste" runat="server" Skin="Metro"></telerik:RadTextBox></td>
                     <td><telerik:RadTextBox ID="txtInvNuevo15C_Ajustes" runat="server" Skin="Metro"></telerik:RadTextBox></td>
                 </tr>

                 <tr>
                     <td><asp:Label ID="Label39" runat="server" Text="Inv. Existente Temp Ambiente" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                     <td></td>
                     <td></td>
                     <td></td>
                     <td></td>
                 </tr>
                 <tr>
                     <td><telerik:RadTextBox ID="txtInvExistAmb_Ajuste" runat="server" Skin="Metro"></telerik:RadTextBox></td>
                     <td></td>
                     <td></td>
                     <td></td>
                     <td>
                         &nbsp;</td>
                 </tr>
                                 <tr>
                    
                    <td colspan="4">
                        &nbsp;<asp:ImageButton ID="CalculaValoresAjustescmd" runat="server" ImageUrl="~/MetroImages/Calcular_over.png" OnClick="btnCalcularIn_Click" Width="150px" />
                        <asp:ImageButton ID="cmdGuardarAjustes" runat="server" ImageUrl="~/MetroImages/Grabar_Over.png" OnClick="btngrabarin_Click" Width="120px" Visible="False" />
                        <br />
                        <asp:Label ID="Label48" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                    </td>
                </tr>
             </table>
        </div>
        </asp:Panel>
         
    
    </form>
</asp:Content>

