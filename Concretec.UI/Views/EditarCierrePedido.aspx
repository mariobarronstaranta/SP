<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true"
    CodeFile="EditarCierrePedido.aspx.cs" Inherits="Views_EditarCierrePedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <span style="text-align: center">
        <h2>
            Edicion Viaje Cierre de Pedido</h2>
    </span>
    <br>
    <table class="tabledata950">
        <tr>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Colado Nocturno
            </td>
            <td class="tdEdicionCampo">
                <div>
                    <asp:Literal ID="litColadoNocturno" runat="server"></asp:Literal>
                </div>
            </td>
            <td></td><td></td>
        </tr>
        <tr>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Cve Pedido
            </td>
            <td class="tdEdicionCampo">
                <div>
                    <asp:Literal ID="litCvePedido" runat="server"></asp:Literal>
                </div>
            </td>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Fecha Compromiso
            </td>
            <td class="tdEdicionCampo">
                <div>
                    <asp:Literal ID="LitFecha" runat="server"></asp:Literal>
                </div>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Cliente
            </td>
            <td class="tdEdicionCampo">
                <div>
                    <asp:Literal ID="litCliente" runat="server"></asp:Literal>
                </div>
            </td>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Producto
            </td>
            <td class="tdEdicionCampo">
                <div>
                    <asp:Literal ID="LitProducto" runat="server"></asp:Literal>
                </div>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Obra
            </td>
            <td class="tdEdicionCampo">
                <div>
                    <asp:Literal ID="litObra" runat="server"></asp:Literal>
                </div>
            </td>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Cantidad
            </td>
            <td class="tdEdicionCampo" colspan="2">
                <div>
                    <asp:Literal ID="LitCantidad" runat="server"></asp:Literal>
                </div>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Direccion
            </td>
            <td class="tdEdicionCampo">
                <div>
                    <asp:Literal ID="litDireccion" runat="server"></asp:Literal>
                </div>
            </td>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Num Viajes
            </td>
            <td class="tdEdicionCampo">
                <div>
                    <asp:Literal ID="LitViajes" runat="server"></asp:Literal>
                </div>
            </td>
            
        </tr>
    </table>
    <br>
    <br>
    <table border="0" cellspacing="0" cellpadding="0" class="tabledata" align="center">
        <tr>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Carga de Viaje
            </td>
            <td class="tdEdicionCampo">
                <asp:TextBox ID="txtCarga" runat="server" Width="150px" MaxLength="4"></asp:TextBox>
            </td>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Ticket CB2</td>
            <td class="tdEdicionCampo">
            <asp:TextBox ID="txtCB2" runat="server" MaxLength="10" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Planta
            </td>
            <td class="tdEdicionCampo">
                <asp:DropDownList ID="planta" runat="server" Width="150px" AutoPostBack="True" 
                    onselectedindexchanged="planta_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                &nbsp;Hora de Compromiso</td>
            <td class="tdEdicionCampo">
                <asp:TextBox ID="txtCompromiso" runat="server" MaxLength="10" Width="150px" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Unidad
            </td>
            <td class="tdEdicionCampo">
                <asp:DropDownList ID="cboUnidad" runat="server" Width="150px">
                </asp:DropDownList>
            </td>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Salida de Planta</td>
            <td class="tdEdicionCampo">
                <telerik:RadTimePicker ID="dtFechaSalida" runat="server" EnableViewState="False" EnableTyping="False" OnSelectedDateChanged="dtFechaSalida_SelectedDateChanged"
                    Culture="en-US" Width="150px" Skin="Metro" AutoPostBack="True">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                    </Calendar>
                    <DatePopupButton Visible="False" CssClass="" ImageUrl="" HoverImageUrl="" TabIndex="13">
                    </DatePopupButton>
                    <TimeView CellSpacing="-1" EndTime="20:00:00" Interval="00:10:00" HeaderText="Hora Salida de Planta"
                        StartTime="06:00:00" Columns="12">
                    </TimeView>
                    <TimePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></TimePopupButton>
                    <DateInput Width="" DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelCssClass="">
                    </DateInput>
                </telerik:RadTimePicker>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Operador</td>
            <td class="tdEdicionCampo" valign="top">
                <asp:DropDownList ID="cbooperador" runat="server" Width="150px">
                </asp:DropDownList>
            </td>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Llegada a Obra</td>
            <td class="tdEdicionCampo">
                <telerik:RadTimePicker ID="dtLlegadaObra" runat="server" EnableViewState="False" EnableTyping="False"
                    Culture="en-US" Width="150px" Skin="Metro">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                    </Calendar>
                    <DatePopupButton Visible="False" CssClass="" ImageUrl="" HoverImageUrl="" TabIndex="13">
                    </DatePopupButton>
                    <TimeView CellSpacing="-1" EndTime="20:00:00" Interval="00:10:00" HeaderText="Hora de llegada a Obra" 
                        StartTime="06:00:00" Columns="12">
                    </TimeView>
                    <TimePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></TimePopupButton>
                    <DateInput Width="" DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelCssClass="">
                    </DateInput>
                </telerik:RadTimePicker>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Observaciones
            </td>
            <td rowspan="2" class="tdEdicionCampo">
                <asp:TextBox ID="txtObservaciones" runat="server" Width="150px" Rows="3" 
                    TextMode="MultiLine" MaxLength="255"></asp:TextBox>
            </td>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Salida de Obra</td>
            <td class="tdEdicionCampo">
                <telerik:RadTimePicker ID="dtSalidaObra" runat="server" EnableViewState="False" EnableTyping="False"
                    Culture="en-US" Width="150px" Skin="Metro">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                    </Calendar>
                    <DatePopupButton Visible="False" CssClass="" ImageUrl="" HoverImageUrl="" TabIndex="13">
                    </DatePopupButton>
                    <TimeView CellSpacing="-1" EndTime="20:00:00" Interval="00:10:00" HeaderText="Hora Salida de Obra" 
                        StartTime="06:00:00" Columns="12">
                    </TimeView>
                    <TimePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></TimePopupButton>
                    <DateInput Width="" DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelCssClass="">
                    </DateInput>
                </telerik:RadTimePicker>
                </td>
        </tr>
        <tr>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                &nbsp;</td>
                
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">
                Llegada a Planta</td>
            <td class="tdEdicionCampo">
                <telerik:RadTimePicker ID="dtLlegadaPlanta" runat="server" EnableViewState="False" EnableTyping="False"
                   Culture="en-US" Width="150px" Skin="Metro">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                    </Calendar>
                    <DatePopupButton Visible="False" CssClass="" ImageUrl="" HoverImageUrl="" TabIndex="13">
                    </DatePopupButton>
                    <TimeView CellSpacing="-1" EndTime="20:00:00" Interval="00:10:00" 
                        StartTime="06:00:00" Columns="12">
                    </TimeView>
                    <TimePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></TimePopupButton>
                    <DateInput Width="" DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelCssClass="">
                    </DateInput>
                </telerik:RadTimePicker>
                </td>
        </tr>
        <tr>
        <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">Remisión</td>
        <td class="tdEdicionCampo"><asp:TextBox ID="txtremision" runat="server" Width="150px" MaxLength="8" ReadOnly="True"></asp:TextBox></td>
        <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">Contingencias</td>
        <td class="tdEdicionCampo">
            <asp:DropDownList ID="cboContingencias" runat="server" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="cboContingencias_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">Factura</td>
            <td class="tdEdicionCampo"><asp:TextBox ID="txtfactura" runat="server" Width="150px" MaxLength="8" Enabled="false"></asp:TextBox></td>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">Observaciones</td>
            <td class="tdEdicionCampo"><asp:DropDownList ID="cboObservaciones" runat="server" Width="150px" Enabled="false"></asp:DropDownList></td>
        </tr>
        <tr>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">Merma / Reasignacion</td>
            <td class="tdEdicionCampo">
                <asp:CheckBox ID="chkmerma" runat="server" Enabled="false" OnCheckedChanged="chkmerma_CheckedChanged" AutoPostBack="True"/>
            </td>
            <td class="tdCeldaGrisEdicionCierre" bgcolor="#D7D7D7">Reasignado a</td>
            <td class="tdEdicionCampo">
                <asp:TextBox ID="txtreasignado" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
    </table>
        <br /><br />
    <table width="75%" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td align="right" style="text-align: center;" colspan="4">
                <asp:ImageButton ID="imgCancelar" runat="server" ImageUrl="~/Imagenes/Cancelar.png"
                    OnClick="imgCancelar_Click" CausesValidation="False" />
                <asp:ImageButton ID="imgGuardar" runat="server" ImageUrl="~/Imagenes/Grabar.png"
                    OnClick="imgGuardar_Click" />
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/Imagenes/PrintIE.png"  
                    onclick="ImageButton1_Click" Visible="False" />
                    <asp:ImageButton ID="imgPrintFF" runat="server" 
                    ImageUrl="~/Imagenes/PrintFF.png"  
                    onclick="imgPrintFF_Click" />
                <asp:ImageButton ID="imgPrint_Laser" runat="server" 
                    ImageUrl="~/Imagenes/Print_Remision_Laser.png"  
                    onclick="imgPrint_Laser_Click" />
            </td>
        </tr>
    </table>
    </form>
</asp:Content>
