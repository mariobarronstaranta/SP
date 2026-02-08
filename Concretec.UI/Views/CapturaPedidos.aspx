<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="CapturaPedidos.aspx.cs" Inherits="Views_CapturaPedidos" EnableViewStateMac="False" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">
        <span style="text-align: center">
            <h2>lPedidos </h2>
        </span>
        <table width="95%" border="0" align="center">
            <tr>
                <td class="formLabel">
                    <asp:Label ID="Label1" runat="server" Text="Colado Nocturno"></asp:Label>
                </td>
                <td class="formValue" style="width: 277px"><asp:DropDownList ID="cboTipoColado" runat="server" OnSelectedIndexChanged="cboTipoColado_SelectedIndexChanged"
                        AutoPostBack="True" Width="250px" TabIndex="1" Enabled="False">
                    <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                    <asp:ListItem Value="1">SI</asp:ListItem>
                    </asp:DropDownList></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr runat="server" id="trheader">
                <td class="formLabel">
                    <asp:Label ID="lblPedido" runat="server" Text="Cve Pedido"></asp:Label>
                </td>
                <td class="formValue" style="width: 277px">
                    <asp:Label ID="lblNumPedido" runat="server"></asp:Label>
                </td>
                <td>&nbsp;
                </td>
                <td class="formLabel">Autorizo
                </td>
                <td class="formValue">
                    <asp:Label ID="autorizo" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formLabel">Cliente
                </td>
                <td class="formValue" style="width: 277px">
                    <asp:DropDownList ID="cbocliente" runat="server" OnSelectedIndexChanged="cbocliente_SelectedIndexChanged"
                        AutoPostBack="True" Width="250px" TabIndex="1">
                    </asp:DropDownList>


                    <asp:CompareValidator ID="CompareValidator1" runat="server"
                        ControlToValidate="cbocliente" ErrorMessage="Seleccione un cliente"
                        ValueToCompare="-1" Type="Integer" Operator="GreaterThan">*</asp:CompareValidator>
                </td>
                <td>&nbsp;
                </td>
                <td class="formLabel">&nbsp;Vendedor</td>
                <td class="formValue">
                    <asp:DropDownList ID="vendedor" runat="server" Width="250px" TabIndex="10">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="ValidaVendedor" runat="server"
                        ControlToValidate="vendedor" ErrorMessage="Seleccione un vendedor"
                        ValueToCompare="-1" Type="Integer" Operator="GreaterThan">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="formLabel">Obra
                </td>
                <td class="formValue" style="width: 277px">
                    <asp:DropDownList ID="obra" runat="server" Width="250px" TabIndex="2"
                        AutoPostBack="True" OnSelectedIndexChanged="obra_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="ValidaObraValor" runat="server"
                        ControlToValidate="obra" ErrorMessage="Seleccione una Obra"
                        ValueToCompare="-1" Type="Integer" Operator="GreaterThan">*</asp:CompareValidator>
                </td>
                <td></td>
                <td class="formLabel">Tipo de Pago</td>
                <td class="formValue">
                    <asp:DropDownList ID="cboTPago" runat="server" Width="250px" OnSelectedIndexChanged="cboTPago_SelectedIndexChanged"
                        TabIndex="11">
                        <asp:ListItem Value="0">Contado</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">Credito</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="formLabel" style="height: 33px">Planta
                </td>
                <td class="formValue" style="width: 277px; height: 33px;">
                    <asp:DropDownList ID="planta" runat="server" Width="250px" TabIndex="3">
                    </asp:DropDownList>

                    <asp:CompareValidator ID="ValidaPlantaValor" runat="server"
                        ControlToValidate="planta" ErrorMessage="Seleccione una planta"
                        ValueToCompare="-1" Type="Integer" Operator="GreaterThan">*</asp:CompareValidator>

                </td>
                <td style="height: 33px">&nbsp;
                </td>
                <td class="formLabel" style="height: 33px">Fecha-Hora Compromiso
                </td>
                <td class="formValue" style="height: 33px">
                    <telerik:RadDatePicker ID="fechacompromiso" runat="server" Width="123px" ShowPopupOnFocus="True"
                        Skin="Metro" EnableTyping="False" EnableViewState="False" TabIndex="12">
                        <DateInput ID="DateInput1" runat="server" ReadOnly="True" TabIndex="12">
                            <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                            <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                            <FocusedStyle Resize="None"></FocusedStyle>

                            <DisabledStyle Resize="None"></DisabledStyle>

                            <InvalidStyle Resize="None"></InvalidStyle>

                            <HoveredStyle Resize="None"></HoveredStyle>

                            <EnabledStyle Resize="None"></EnabledStyle>
                        </DateInput>
                        <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            ViewSelectorText="x" OnDayRender="CustomizeDay" Skin="Metro">
                            <SpecialDays>
                                <telerik:RadCalendarDay Date="2009-06-24" IsDisabled="True" IsSelectable="False">
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                            <DisabledDayStyle Font-Bold="True" Font-Strikeout="True" />
                        </Calendar>
                        <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="12"></DatePopupButton>
                    </telerik:RadDatePicker>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <telerik:RadTimePicker ID="horacompromiso" runat="server" TabIndex="13"
                    EnableViewState="False" Culture="en-US" Skin="Metro" EnableTyping="False">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                    <DatePopupButton Visible="False" CssClass="" ImageUrl="" HoverImageUrl="" TabIndex="13"></DatePopupButton>
                    <TimeView CellSpacing="-1" EndTime="20:30:00" Interval="00:30:00" StartTime="06:00:00" Columns="8"></TimeView>
                    <TimePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></TimePopupButton>
                    <DateInput Width="" DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelCssClass="" ReadOnly="True">
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
                <td class="formLabel">Distancia/Desfase 
                </td>
                <td class="formValue" style="width: 277px">
                    <asp:TextBox ID="distancia" runat="server" Width="80px" OnTextChanged="distancia_TextChanged"
                        MaxLength="6" EnableViewState="False" TabIndex="4"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="distancia"
                        ErrorMessage="El campo distancia es requerido">*</asp:RequiredFieldValidator>
                    Kms
                <asp:TextBox ID="desface" runat="server" Width="80px" MaxLength="3"
                    TabIndex="5">10</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="desface"
                        ErrorMessage="El campo hora desfase  es requerido">*</asp:RequiredFieldValidator>
                    mins
                </td>
                <td>&nbsp;
                </td>
                <td class="formLabel">Solicito
                </td>
                <td class="formValue">
                    <asp:TextBox ID="solicito" runat="server" Width="250px" EnableViewState="False"
                        TabIndex="14"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formLabel">Uso
                </td>
                <td class="formValue" style="width: 277px">
                    <asp:DropDownList ID="usos" runat="server" OnSelectedIndexChanged="usos_SelectedIndexChanged"
                        Width="250px" TabIndex="6">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="usos" ErrorMessage="Seleccione un uso" Operator="GreaterThan" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                </td>
                <td>&nbsp;
                </td>
                <td class="formLabel">Recibe
                </td>
                <td class="formValue">
                    <asp:TextBox ID="recibe" runat="server" Width="250px" EnableViewState="False"
                        TabIndex="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formLabel">Producto 
                </td>
                <td class="formValue" style="width: 277px">
                    <asp:DropDownList ID="producto" runat="server" Width="250px" TabIndex="7"
                        OnSelectedIndexChanged="producto_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="ValidaProductoValor" runat="server"
                        ControlToValidate="producto" ErrorMessage="Seleccione un producto"
                        ValueToCompare="-1" Type="Integer" Operator="GreaterThan">*</asp:CompareValidator>
                </td>
                <td>&nbsp;
                </td>
                <td class="formLabel">Orden de Compra</td>
                <td class="formValue">
                    <asp:TextBox ID="txtOrdenCompra" runat="server" Width="250px" TabIndex="16"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formLabel">Carga Total / Viajes</td>
                <td class="FormValue" style="width: 277px;">

                    <asp:TextBox ID="cargatotal" runat="server" Width="80px" OnTextChanged="cargatotal_TextChanged1" AutoPostBack="True" TabIndex="8"></asp:TextBox> m3
                    <asp:TextBox ID="NumViajes" runat="server" Width="80px" MaxLength="2" EnableViewState="False" TabIndex="9"></asp:TextBox>viajes


                <asp:RequiredFieldValidator ID="ValidaValorcarga" runat="server"
                    ControlToValidate="cargatotal"
                    ErrorMessage="Capture un valor para carga del pedido">*</asp:RequiredFieldValidator>
                    <asp:Label ID="lblEstatus" runat="server" Visible="False"></asp:Label>
                </td>
                <td></td>

                <td class="formLabel">Contrato</td>
                <td class="FormValue">
                    <asp:TextBox ID="txtContrato" runat="server" Width="250px" TabIndex="17"></asp:TextBox></td>

            </tr>
            
            <tr>
                <td class="formLabel">Comentarios</td>
                <td class="formValue" style="width: 277px">
                    <asp:TextBox ID="txtComentarios" runat="server" rows="4" TextMode="MultiLine"
                        Width="250px"></asp:TextBox>
                </td>

                <td></td>
                
             <td class="formLabel">Observaciones
             </td>

                <td class="formValue" valign="top">
                    <asp:ListBox ID="cboObservaciones" runat="server" SelectionMode="Multiple" heigh="150px"
                        Width="250px" TabIndex="18"></asp:ListBox>
                </td>

            </tr>

        </table>
        <div>
        <table width="90%" border="0" align="center">
            <tr>
                <td colspan="3" class="formLabelCenter">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                        DisplayMode="List" Font-Bold="True" Font-Names="Segoe UI" Style="text-align: left;" />
                    Productos Adicionales
                </td>
            </tr>
            </div><div>
<table width="85%" border="0" align="center">
            <tr>
                <td>
                    <asp:ListBox ID="adicionales" runat="server" Width="350px" Height="80px"
                        TabIndex="19"></asp:ListBox>
                </td>
                <td>
                    <asp:ImageButton ID="agregaadicional" ImageUrl="~/MetroImages/Agregar.png"
                        runat="server" OnClick="agregaadicional_Click"
                        Height="60px" Font-Bold="True" Font-Names="Segoe UI" CausesValidation="False"
                        Font-Italic="False" Font-Size="XX-Large" TabIndex="19" 
                        onMouseOver="MouseRollover(this,'Agregar_Over.png')" onMouseOut="MouseOut(this,'Agregar.png')"/>
                    <asp:ImageButton ID="eliminaadicional" runat="server" OnClick="eliminaadicional_Click"
                        ImageUrl="~/MetroImages/Quitar.png" Height="60px" Font-Bold="True"
                        Font-Names="Segoe UI" CausesValidation="False"
                        Font-Size="XX-Large" TabIndex="20" 
                        onMouseOver="MouseRollover(this,'Quitar_Over.png')" onMouseOut="MouseOut(this,'Quitar.png')"/>
                </td>
                <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:ListBox ID="listaadicionales" runat="server" Width="350px" Height="80px"
                        TabIndex="20"></asp:ListBox>
                </td>
            </tr>
        </table>
        </div>
        <br />
        <div style="text-align: center; width: 100%;">
            <asp:ImageButton ID="imgCancelar" runat="server" ImageUrl="~/MetroImages/Cancelar_Large.png"
                OnClick="imgCancelar_Click" CausesValidation="False"
                EnableViewState="False" 
                onMouseOver="MouseRollover(this,'Cancelar_Large_Over.png')" onMouseOut="MouseOut(this,'Cancelar_Large.png')"/>
            <asp:ImageButton ID="imgLimpiar" runat="server" ImageUrl="~/MetroImages/Limpiar.png"
                OnClick="imgLimpiar_Click" CausesValidation="False"
                EnableViewState="False" Visible="False" 
                onMouseOver="MouseRollover(this,'Limpiar_Over.png')" onMouseOut="MouseOut(this,'Limpiar.png')"/>
            <asp:ImageButton ID="imgGuardar" runat="server" ImageUrl="~/MetroImages/Grabar.png"
                OnClick="imgGuardar_Click" EnableViewState="False" 
                onMouseOver="MouseRollover(this,'Grabar_Over.png')" onMouseOut="MouseOut(this,'Grabar.png')"/>

            <asp:ImageButton ID="imgImprimir" runat="server" ImageUrl="~/MetroImages/UI_GrabarImprimir.png"
                OnClick="imgImprimir_Click" EnableViewState="False" 
                onMouseOver="MouseRollover(this,'UI_GrabarImprimir_Over.png')" onMouseOut="MouseOut(this,'UI_GrabarImprimir.png')"/>
            
            <asp:ImageButton ID="imgImprimir_Laser" runat="server" ImageUrl="~/Imagenes/Impresion_Laser.png"
                OnClick="imgImprimir_Laser_Click" EnableViewState="False" />
            
            <asp:ImageButton ID="imgViajes" runat="server" ImageUrl="~/MetroImages/Viajes.png" OnClick="imgViajes_Click"
                Visible="False" EnableViewState="False" 
                onMouseOver="MouseRollover(this,'Viajes_Over.png')" onMouseOut="MouseOut(this,'Viajes.png')"/>
            <asp:ImageButton ID="imgAutorizacion" runat="server"
                ImageUrl="~/Imagenes/Autorizacion.png" OnClick="imgAutorizacion_Click"
                Visible="False" CausesValidation="False"
                EnableViewState="False" />

            <asp:ImageButton ID="imgCancelarPedido" runat="server"
                ImageUrl="~/Imagenes/CancelarPedido.png" OnClick="imgCancelarPedido_Click"
                Visible="False" />

        </div>
        &nbsp;
    </form>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
    <script type="text/javascript">
        function AcceptNum(evt) {

            var nav4 = window.Event ? true : false;
            var key = nav4 ? evt.which : evt.keyCode;
            return (key <= 13 || (key >= 46 && key <= 57) || key == 44);
        }
    </script>
</asp:Content>
