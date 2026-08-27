<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/MasterPage.master"
    CodeFile="CatalogoUnidades.aspx.cs" Inherits="Views_CatalogoUnidades" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    CatalogoUnidades
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <span style="text-align: center">
            <h2>Unidades</h2>
        </span>

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>

        <table width="90%" border="0" cellspacing="10" cellpadding="0" align="center">
            <tr valign="top">
                <td>
                    <asp:Panel ID="pnlViajesProgramados" runat="server"
                        GroupingText="Información de Viajes" CssClass="gridFilter">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="formLabel" style="width: 75%; text-align: left;">
                                    Viajes Programados de la Unidad
                                </td>
                                <td class="formValue" style="width: 25%; text-align: center;">
                                    <asp:Label ID="lblViajesProgramados" runat="server" Text="0"
                                        Font-Bold="True" Font-Size="Large" ForeColor="#B91D47"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>

        <table width="90%" border="0" cellspacing="10" cellpadding="0" align="center">
            <tr valign="top">
                <td width="50%">
                    <asp:Panel ID="pnlCamposObligatorios" runat="server" GroupingText="Campos Obligatorios" CssClass="gridFilter">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="formLabel">Clave Unidad</td>
                                <td class="formValue">
                                    <asp:TextBox ID="claveUnidad" runat="server" MaxLength="10" TabIndex="1"
                                        Width="220px" EnableViewState="False"></asp:TextBox>
                                    <asp:TextBox ID="PKUnidad" runat="server" Visible="False" Width="5px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Clave Alterna</td>
                                <td class="formValue">
                                    <asp:TextBox ID="cvealterna" runat="server" MaxLength="10" TabIndex="2"
                                        Width="220px" EnableViewState="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Ciudad</td>
                                <td class="formValue">
                                    <asp:DropDownList ID="cboCiudad" runat="server" TabIndex="3"
                                        AutoPostBack="True" OnSelectedIndexChanged="cboCiudad_SelectedIndexChanged"
                                        CssClass="select" Enabled="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Planta</td>
                                <td class="formValue">
                                    <asp:DropDownList ID="planta" runat="server" TabIndex="4"
                                        AutoPostBack="True" OnSelectedIndexChanged="planta_SelectedIndexChanged"
                                        CssClass="select" Enabled="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Operador</td>
                                <td class="formValue">
                                    <asp:DropDownList ID="operador" runat="server" TabIndex="5" CssClass="select">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Estatus</td>
                                <td class="formValue">
                                    <asp:DropDownList ID="cboEstatus" runat="server" TabIndex="6"
                                        AutoPostBack="True" CssClass="select" Enabled="true">
                                        <asp:ListItem Selected="True" Value="1">Activo</asp:ListItem>
                                        <asp:ListItem Value="0">Inactivo</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td width="50%">
                    <asp:Panel ID="pnlDatosCamion" runat="server" GroupingText="Datos del Camión" CssClass="gridFilter">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="formLabel">Marca</td>
                                <td class="formValue">
                                    <asp:DropDownList ID="marca" runat="server" TabIndex="7" CssClass="select">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Modelo</td>
                                <td class="formValue">
                                    <asp:TextBox ID="modelo" runat="server" MaxLength="4" TabIndex="8"
                                        Width="220px" EnableViewState="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Placas</td>
                                <td class="formValue">
                                    <asp:TextBox ID="placas" runat="server" MaxLength="10" TabIndex="9"
                                        Width="220px" EnableViewState="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Num. Serie</td>
                                <td class="formValue">
                                    <asp:TextBox ID="noserie" runat="server" MaxLength="20" TabIndex="10"
                                        Width="220px" EnableViewState="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Tipo de Combustible</td>
                                <td class="formValue">
                                    <asp:DropDownList ID="combustible" runat="server" TabIndex="11" CssClass="select">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Tipo de Placa</td>
                                <td class="formValue">
                                    <asp:DropDownList ID="tipoplacas" runat="server" TabIndex="12" CssClass="select">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr valign="top">
                <td width="50%">
                    <asp:Panel ID="pnlDatosAseguranza" runat="server" GroupingText="Datos Aseguranza" CssClass="gridFilter">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="formLabel">Aseguradora</td>
                                <td class="formValue">
                                    <asp:DropDownList ID="aseguradora" runat="server" TabIndex="13" CssClass="select">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Póliza</td>
                                <td class="formValue">
                                    <asp:TextBox ID="poliza" runat="server" MaxLength="10" TabIndex="14"
                                        Width="220px" EnableViewState="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Inciso</td>
                                <td class="formValue">
                                    <asp:TextBox ID="inciso" runat="server" MaxLength="5" TabIndex="15"
                                        Width="220px" EnableViewState="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Inicio Vigencia</td>
                                <td class="formValue">
                                    <telerik:RadDatePicker ID="vigenciainicial" runat="server" Culture="en-US"
                                        MinDate="2010-01-01" TabIndex="16" EnableViewState="False" Width="220px">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" TabIndex="16">
                                        </DateInput>
                                        <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="16"></DatePopupButton>
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Fin Vigencia</td>
                                <td class="formValue">
                                    <telerik:RadDatePicker ID="vigenciafinal" runat="server" MinDate="2010-01-01"
                                        TabIndex="17" EnableViewState="False" Width="220px">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" TabIndex="17">
                                        </DateInput>
                                        <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="17"></DatePopupButton>
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td width="50%">
                    <asp:Panel ID="pnlOtrosDatos" runat="server" GroupingText="Otros Datos" CssClass="gridFilter">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="formLabel">Propietario</td>
                                <td class="formValue">
                                    <asp:TextBox ID="propietario" runat="server" TabIndex="18"
                                        Width="220px" EnableViewState="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Verificación Vehicular</td>
                                <td class="formValue">
                                    <telerik:RadDatePicker ID="verificacionvehicular" runat="server" MinDate="2010-01-01"
                                        TabIndex="19" EnableViewState="False" Width="220px">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" TabIndex="19">
                                        </DateInput>
                                        <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="19"></DatePopupButton>
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Observaciones</td>
                                <td class="formValue">
                                    <asp:TextBox ID="observaciones" runat="server" Height="75px" TextMode="MultiLine"
                                        Rows="3" Width="220px" TabIndex="20" EnableViewState="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formLabel">Centro de Costos</td>
                                <td class="formValue">
                                    <asp:DropDownList ID="centrocostos" runat="server" TabIndex="21" CssClass="select">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="right" style="text-align: center;" valign="top" colspan="2">
                    <asp:HiddenField ID="Idunidad" runat="server" />
                    <br />
                    <br />

                    <asp:ImageButton ID="imgReasigna" runat="server" ImageUrl="~/Imagenes/ReasignaViajes.png"
                            OnClick="imgReasigna_Click" EnableViewState="False" />

                    <asp:ImageButton ID="imgCancelar" runat="server" ImageUrl="~/Imagenes/Cancelar.png"
                        OnClick="imgCancelar_Click" EnableViewState="False" />
                    <asp:ImageButton ID="imgLimpiar" runat="server" ImageUrl="~/Imagenes/Limpiar.png"
                        EnableViewState="False" />
                    <asp:ImageButton ID="imgGuardar" runat="server" ImageUrl="~/Imagenes/Grabar.png"
                        OnClick="imgGuardar_Click" EnableViewState="False" />
                    
                </td>
            </tr>
        </table>

        <asp:Panel ID="pnlConfirmacionCambio" runat="server" Visible="False"
            Style="position: fixed; z-index: 10000; left: 0; top: 0; width: 100%; height: 100%; background-color: rgba(0, 0, 0, 0.45);">
            <div style="width: 440px; margin: 180px auto 0 auto; padding: 22px; border: 1px solid #cccccc; border-radius: 4px; background-color: #ffffff; font-family: 'Segoe UI'; text-align: center;">
                <div class="formLabelCenter" style="margin-bottom: 18px; text-align: center;">
                    Esta cambiando de Ciudad o Planta es necesario reasignar los viajes antes
                </div>
                <asp:Button ID="btnCambiarUbicacion" runat="server" Text="CAMBIAR"
                    OnClick="btnCambiarUbicacion_Click" CausesValidation="False"
                    Style="margin-right: 10px; padding: 6px 18px;" />
                <asp:Button ID="btnCancelarUbicacion" runat="server" Text="CANCELAR"
                    OnClick="btnCancelarUbicacion_Click" CausesValidation="False"
                    Style="padding: 6px 18px;" />
            </div>
        </asp:Panel>

        <asp:Panel ID="pnlMensaje" runat="server" Visible="False"
            Style="position: fixed; z-index: 10001; left: 0; top: 0; width: 100%; height: 100%; background-color: rgba(0, 0, 0, 0.45);">
            <div style="width: 440px; margin: 180px auto 0 auto; padding: 22px; border: 1px solid #cccccc; border-radius: 4px; background-color: #ffffff; font-family: 'Segoe UI'; text-align: center; box-shadow: 0 4px 18px rgba(0, 0, 0, 0.25);">
                <div class="formLabelCenter" style="margin-bottom: 18px; text-align: center;">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </div>
                <asp:Button ID="btnAceptarMensaje" runat="server" Text="ACEPTAR"
                    OnClick="btnAceptarMensaje_Click" CausesValidation="False"
                    Style="padding: 6px 22px;" />
            </div>
        </asp:Panel>
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
