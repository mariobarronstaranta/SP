<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true"
    CodeFile="CapturaViajes.aspx.cs" Inherits="Views_CapturaViajes" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">
        <span style="text-align: center">
            <h2>Asignacion de Cargas a Pedidos Programados
            </h2>
        </span>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <table width="990px" border="0" align="center">
            <tr>
                <td bgcolor="#D7D7D7">Cliente</td>
                <td colspan="3"><asp:Label ID="lblCliente" runat="server" Text="Label"></asp:Label></td>
                
                <td bgcolor="#D7D7D7">Obra</td>
                <td colspan="3"><asp:Label ID="lblObra" runat="server" Text="Label"></asp:Label></td>

                
            </tr>

            <tr>
                <td bgcolor="#D7D7D7">Cve Pedido</td>
                <td><asp:Label ID="lblPedido" runat="server" Text="Label"></asp:Label></td>

                <td bgcolor="#D7D7D7">Fecha Pedido</td>
                <td><asp:Label ID="lblFecha" runat="server" Text="Label"></asp:Label></td>

                <td bgcolor="#D7D7D7">Carga Sol.</td>
                <td><asp:Label ID="lblCarga" runat="server" Text="Label"></asp:Label></td>

                <td bgcolor="#D7D7D7">Carga Pro.</td>
                <td><asp:Label ID="lblCargaPro" runat="server" Text="0" Width="50px"></asp:Label></td>

                
            </tr>

            
            <tr>
                <td bgcolor="#D7D7D7">Planta</td>
                <td><asp:Label ID="lblPlanta" runat="server" Text="Label"></asp:Label></td>

                <td bgcolor="#D7D7D7">Producto</td>
                <td colspan="3"><asp:Label ID="lblProducto" runat="server" Text="Label"></asp:Label></td>

                <td bgcolor="#D7D7D7">Viajes</td>
                <td><asp:Label ID="lblviajes" runat="server" Text="Label"></asp:Label></td>

                
            </tr>

            <tr>
                <td bgcolor="#D7D7D7">Desfase</td>
                <td><asp:Label ID="lblDesfase" runat="server" Text="Label"></asp:Label></td>

                <td bgcolor="#D7D7D7">Colado Nocturno</td>
                <td><asp:Label ID="lblColadoNocturno" runat="server" Text="Label"></asp:Label></td>
                
                <td bgcolor="#D7D7D7">Vendedor</td>
                <td><asp:Label ID="lblVendedor" runat="server" Text="Label"></asp:Label></td>

                <td bgcolor="#D7D7D7">Uso</td>
                <td><asp:Label ID="lblUso" runat="server" Text="Label"></asp:Label></td>

            </tr>
        </table>
        <table width="990px" border="0" align="center">
            </table>
        <asp:TextBox ID="consecutivoviaje" runat="server" Visible="False"></asp:TextBox>
        <asp:Label ID="lblDescripcion" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
            DisplayMode="List" Font-Bold="True" />
        <br />
        <br />
        <div class="content">
            <span>
                <asp:Label ID="lblMensajes" runat="server" Visible="False" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
            </span>
        </div>
        <table width="100%" align="center">
            <tr>
                <td class="tdCeldaGrisEdicionViaje" bgcolor="#D7D7D7">Planta
                </td>
                <td width="20%" align="left" style="text-align: left;" class="td150">
                    <asp:DropDownList ID="plantas" runat="server" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="plantas_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="validaplanta" runat="server"
                        ControlToValidate="plantas"
                        ErrorMessage="Es necesrio capturar la planta origen del viaje"
                        Operator="GreaterThan" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                </td>
                <td class="tdCeldaGrisEdicionViaje" bgcolor="#D7D7D7">Tipo de Viaje</td>
                <td width="20%" align="left" style="text-align: left;" class="td150">
                    <asp:DropDownList ID="tiposviaje" runat="server" Width="120px"
                        AutoPostBack="True" OnSelectedIndexChanged="tiposviaje_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="validatipov" runat="server"
                        ControlToValidate="tiposviaje"
                        ErrorMessage="Es necesario capturar el tipo de el viaje" Type="Integer"
                        ValueToCompare="-1" Operator="GreaterThan">*</asp:CompareValidator>
                </td>
                <td class="tdCeldaGrisEdicionViaje" bgcolor="#D7D7D7">Carga
                </td>
                <td width="111" align="left" style="text-align: left" class="td150">
                    <asp:TextBox ID="carga" runat="server" Width="80px" MaxLength="3">7</asp:TextBox>
                    m3
                <asp:RequiredFieldValidator ID="validacarga" runat="server"
                    ErrorMessage="Es necesrio capturar la carga del viaje"
                    ControlToValidate="carga">*</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="validarangocarga" runat="server"
                        ControlToValidate="carga"
                        ErrorMessage="El valor de la carga no puede ser mayor a 7 y menor a 1"
                        MaximumValue="7" MinimumValue="0" Type="Double">*</asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="tdCeldaGrisEdicionViaje" bgcolor="#D7D7D7">Fecha Inicio
                </td>
                <td width="20%" align="left"
                    style="text-align: left; height: 15px; width: 190px" class="td150">
                    <telerik:RadDatePicker ID="fechainicio" runat="server" Width="123px" ShowPopupOnFocus="True"
                        Skin="Default" EnableTyping="False" OnSelectedDateChanged="fechainicio_SelectedDateChanged1">
                        <DateInput ID="DateInput1" runat="server" ReadOnly="True">
                        </DateInput>
                        <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            ViewSelectorText="x" OnDayRender="CustomizeDay">
                            <SpecialDays>
                                <telerik:RadCalendarDay Date="2009-06-24" IsDisabled="True" IsSelectable="False">
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                            <DisabledDayStyle Font-Bold="True" Font-Strikeout="True" />
                        </Calendar>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </td>
                <td class="tdCeldaGrisEdicionViaje" bgcolor="#D7D7D7">Hora Inicio
                </td>
                <td width="20%" align="left"
                    style="height: 15px; text-align: left; width: 94px" class="td150">
                    <telerik:RadTimePicker ID="horainicio" runat="server" Width="120px" Culture="en-US" DateInput-DateFormat="HH:mm" TimeView-TimeFormat="HH:mm" AutoPostBack="True" AutoPostBackControl="TimeView" HiddenInputTitleAttibute="Visually hidden input created for functionality purposes." OnSelectedDateChanged="horainicio_SelectedDateChanged" WrapperTableSummary="Table holding date picker control for selection of dates." EnableTyping="False">
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DatePopupButton Visible="False" CssClass="" ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        <TimeView CellSpacing="-1" EndTime="20:30:00" HeaderText="Inicio Ciclo" Interval="00:10:00"
                            StartTime="06:00:00" Columns="6">
                        </TimeView>
                        <TimePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></TimePopupButton>
                        <DateInput Width="" DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelCssClass="" AutoPostBack="True" ReadOnly="True">
                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                            <FocusedStyle Resize="None"></FocusedStyle>
                            <DisabledStyle Resize="None"></DisabledStyle>
                            <InvalidStyle Resize="None"></InvalidStyle>
                            <HoveredStyle Resize="None"></HoveredStyle>
                            <EnabledStyle Resize="None"></EnabledStyle>
                        </DateInput>
                    </telerik:RadTimePicker>
                </td>
                <td class="tdCeldaGrisEdicionViaje" bgcolor="#D7D7D7">Hora Fin
                </td>
                <td align="left" style="height: 15px; text-align: left" class="td150">
                    <telerik:RadTimePicker ID="horafin" runat="server" Width="120px" DateInput-DateFormat="HH:mm" TimeView-TimeFormat="HH:mm tt" OnSelectedDateChanged="horafin_SelectedDateChanged" AutoPostBack="True" EnableTyping="False">
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DatePopupButton Visible="False" CssClass="" ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        <TimeView CellSpacing="-1" EndTime="20:30:00" HeaderText="Fin Ciclo" Interval="00:10:00"
                            StartTime="06:00:00" Columns="6">
                        </TimeView>
                        <TimePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></TimePopupButton>
                        <DateInput Width="" DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelCssClass="" AutoPostBack="True" ReadOnly="True">
                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                            <FocusedStyle Resize="None"></FocusedStyle>
                            <DisabledStyle Resize="None"></DisabledStyle>
                            <InvalidStyle Resize="None"></InvalidStyle>
                            <HoveredStyle Resize="None"></HoveredStyle>
                            <EnabledStyle Resize="None"></EnabledStyle>
                        </DateInput>
                    </telerik:RadTimePicker>
                </td>
            </tr>
            <tr>
                <td class="tdCeldaGrisEdicionViaje" bgcolor="#D7D7D7">Unidad
                </td>
                <td width="20%" align="left" style="text-align: left; width: 190px"
                    class="td150">
                    <asp:DropDownList ID="unidades" runat="server" AutoPostBack="True" OnSelectedIndexChanged="unidades_SelectedIndexChanged"
                        Width="120px">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="validaunidad" runat="server"
                        ControlToValidate="unidades"
                        ErrorMessage="Es necesrio capturar la unidad que llevara el viaje"
                        Operator="GreaterThan" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                </td>
                <td class="tdCeldaGrisEdicionViaje" bgcolor="#D7D7D7">Operador
                </td>
                <td width="20%" align="left" style="text-align: left; width: 94px"
                    class="td150">
                    <asp:DropDownList ID="operadores" runat="server" Width="120px" OnSelectedIndexChanged="operadores_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="validaoperador" runat="server"
                        ControlToValidate="operadores"
                        ErrorMessage="Es necesrio capturar el operador que llevara el viaje"
                        Type="Integer" ValueToCompare="-1" Operator="GreaterThan">*</asp:CompareValidator>
                </td>
                <td class="tdCeldaGrisEdicionViaje" bgcolor="#D7D7D7" rowspan="2">Observaciones</td>
                <td align="left" style="text-align: left" class="td150" rowspan="2">
                    <asp:TextBox ID="observaciones" runat="server" Width="120px"
                        TextMode="MultiLine" MaxLength="255" Height="55"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdCeldaGrisEdicionViaje" bgcolor="#D7D7D7" style="height: 40px">&nbsp;Distancia</td>
                <td width="20%" align="left"
                    style="text-align: left; width: 190px;" class="td150">
                    <asp:TextBox ID="distancia" runat="server" Width="120px" MaxLength="4"></asp:TextBox>
                </td>
                <td class="tdCeldaGrisEdicionViaje" bgcolor="#D7D7D7" style="height: 40px">Estatus Viaje
                </td>
                <td width="20%" align="left"
                    style="text-align: left; width: 94px;" class="td150">
                    <asp:DropDownList ID="estatusviaje" runat="server" Width="120px"
                        Enabled="False" OnSelectedIndexChanged="estatusviaje_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="validaEV" runat="server"
                        ControlToValidate="estatusviaje"
                        ErrorMessage="Es necesrio capturar el estatus del viaje" Type="Integer"
                        ValueToCompare="-1" Operator="GreaterThan">*</asp:CompareValidator>
                </td>
                
            </tr>
            <tr>
                <td class="tdCeldaGrisEdicionViaje" bgcolor="#D7D7D7">Es Ajuste</td>
                <td class="td150">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="120px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Value="0">NO</asp:ListItem>
                        <asp:ListItem Value="1">SI</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="tdCeldaGrisEdicionViaje">&nbsp;</td>
                <td width="20%" align="left"
                    style="text-align: left; width: 94px;" class="td150">&nbsp;</td>
                <td class="tdCeldaGrisEdicionViaje">&nbsp;</td>
                <td align="left" style="text-align: left;" class="td150">
                    <asp:TextBox ID="remision" runat="server" Width="120px" MaxLength="10" Visible="false" Enabled="false"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div style="text-align: center">
            <asp:ImageButton ID="imgCancelar" runat="server" ImageUrl="~/MetroImages/Cancelar_Large.png"
                OnClick="imgCancelar_Click" CausesValidation="False" 
                onMouseOver="MouseRollover(this,'Cancelar_Large_Over.png')" onMouseOut="MouseOut(this,'Cancelar_Large.png')"/>
            <asp:ImageButton ID="imgLimpiar" runat="server" ImageUrl="~/MetroImages/Limpiar.png"
                OnClick="imgLimpiar_Click" CausesValidation="False" Visible="False"
                onMouseOver="MouseRollover(this,'Limpiar_Over.png')" onMouseOut="MouseOut(this,'Limpiar.png')"/>
            <asp:ImageButton ID="imgAgregar" runat="server" ImageUrl="~/MetroImages/AgregarViajes.png"
                OnClick="imgAgregar_Click" EnableViewState="False" 
                onMouseOver="MouseRollover(this,'AgregarViajes_Over.png')" onMouseOut="MouseOut(this,'AgregarViajes.png')"/>
            <asp:ImageButton ID="imgProgAuto" runat="server" ImageUrl="~/MetroImages/ProgramacionAutomatica.png"
                OnClick="imgProgAuto_Click" CausesValidation="False" EnableViewState="False" Visible="False"             
                onMouseOver="MouseRollover(this,'ProgramacionAutomatica_Over.png')" onMouseOut="MouseOut(this,'ProgramacionAutomatica.png')"/>
            <asp:ImageButton ID="imgBorrar" runat="server" ImageUrl="~/MetroImages/BorrarPedido.png"
                OnClick="imgBorrar_Click" CausesValidation="False"
                onMouseOver="MouseRollover(this,'BorrarPedido_Over.png')" onMouseOut="MouseOut(this,'BorrarPedido.png')"/>
            <asp:ImageButton ID="imgGuardar" runat="server" ImageUrl="~/MetroImages/Grabar.png"
                OnClick="imgGuardar_Click" CausesValidation="False" Visible="False" 
                onMouseOver="MouseRollover(this,'Grabar_Over.png')" onMouseOut="MouseOut(this,'Grabar.png')"/>
            <asp:ImageButton ID="imgImprimir" runat="server" ImageUrl="~/MetroImages/ImprimirPedido.png"
                OnClick="imgImprimir_Click" CausesValidation="False" 
                onMouseOver="MouseRollover(this,'ImprimirPedido_Over.png')" onMouseOut="MouseOut(this,'ImprimirPedido.png')"/>
        </div>
        <div>
            <br />
            <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" GridLines="None" CellSpacing="0"
                OnItemCommand="RadGrid1_ItemCommand" OnNeedDataSource="RadGrid1_NeedDataSource">
                <MasterTableView>
                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                    <RowIndicatorColumn>
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Created="True">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <Columns>

                        <telerik:GridBoundColumn HeaderText="Viaje" UniqueName="column1" DataField="IDViaje">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Pedido" UniqueName="column" DataField="IDPedido">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Fecha" UniqueName="column7" DataField="FechaInicio"
                            DataFormatString="{0:dd/MM/yyyy}">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Inicio" UniqueName="column2" DataField="HoraInicio">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Fin" UniqueName="column3" DataField="HoraFin">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Carga" UniqueName="column4" DataField="CargaViaje">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CvePlanta" HeaderText="Planta"
                            UniqueName="column8">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Unidad" UniqueName="column5"
                            DataField="DescripcionUnidad">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Operador" UniqueName="column6"
                            DataField="NombreOperador">
                        </telerik:GridBoundColumn>

                        <telerik:GridButtonColumn CommandName="Cancelar" HeaderText="Cancelar"
                            Text="Cancelar" UniqueName="CanViaje">
                            <HeaderStyle Font-Bold="True" />
                        </telerik:GridButtonColumn>
                    </Columns>

                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>

                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                </MasterTableView>

                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
        </div>
    </form>
</asp:Content>
