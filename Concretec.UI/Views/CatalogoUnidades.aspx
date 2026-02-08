<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/MasterPage.master"
    CodeFile="CatalogoUnidades.aspx.cs" Inherits="Views_CatalogoUnidades" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    CatalogoUnidades
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <span style="text-align: center">
        <h2>
            Unidades
        </h2>
    </span>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <table width="100%">
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td class="formLabel">
                            Clave Unidad
                        </td>
                        <td class="formValue">
                            <asp:TextBox ID="claveUnidad" runat="server" MaxLength="10" TabIndex="1" Width="220px"
                                EnableViewState="False"></asp:TextBox>
                        </td>
                        <td width="10%">
                            &nbsp;
                        </td>
                        <td class="formLabel">
                            Tipo de Placa
                        </td>
                        <td class="formValue">
                            <asp:DropDownList ID="tipoplacas" runat="server" TabIndex="10" 
                                CssClass="select">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="formLabel">
                            Clave Alterna
                        </td>
                        <td class="formValue">
                            <asp:TextBox ID="cvealterna" runat="server" MaxLength="10" TabIndex="1"
                                EnableViewState="False" width="220px"></asp:TextBox>
                        </td>
                        <td width="10%">
                            &nbsp;
                        </td>
                        <td class="formLabel">
                            Centro de Costos
                        </td>
                        <td class="formValue">
                            <asp:DropDownList ID="centrocostos" runat="server" TabIndex="11" 
                                CssClass="select">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="formLabel">
                            Planta
                        </td>
                        <td class="formValue">
                            <asp:DropDownList ID="planta" runat="server" TabIndex="2" 
                                AutoPostBack="True" onselectedindexchanged="planta_SelectedIndexChanged" 
                                CssClass="select" Enabled="true">
                            </asp:DropDownList>
                        </td>
                        <td width="10%">
                            &nbsp;
                        </td>
                        <td class="formLabel">
                            Póliza
                        </td>
                        <td class="formValue">
                            <asp:TextBox ID="poliza" runat="server" MaxLength="10" TabIndex="12"
                                EnableViewState="False" width="220px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formLabel">
                            Operador
                        </td>
                        <td class="formValue">
                            <asp:DropDownList ID="operador" runat="server" TabIndex="3" CssClass="select">
                            </asp:DropDownList>
                        </td>
                        <td width="10%">
                            &nbsp;
                        </td>
                        <td class="formLabel">
                            Inciso
                        </td>
                        <td class="formValue">
                            <asp:TextBox ID="inciso" runat="server" MaxLength="5" TabIndex="13"
                                EnableViewState="False" width="220px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formLabel">
                            Estatus
                        </td>
                        <td class="formValue">
                            <asp:DropDownList ID="cboEstatus" runat="server" TabIndex="2" 
                                AutoPostBack="True" CssClass="select" Enabled="true">
                                <asp:ListItem Selected="True" Value="1">Activo</asp:ListItem>
                                <asp:ListItem Value="0">Inactivo</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="10%">
                            &nbsp;
                        </td>
                        <td class="formLabel">
                            Aseguradora
                        </td>
                        <td class="formValue">
                            <asp:DropDownList ID="aseguradora" runat="server" TabIndex="14" 
                                CssClass="select">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="formLabel">
                            Marca
                        </td>
                        <td class="formValue">
                            <asp:DropDownList ID="marca" runat="server" TabIndex="5" CssClass="select">
                            </asp:DropDownList>
                        </td>
                        <td width="10%">
                            &nbsp;
                        </td>
                        <td class="formLabel">
                            Inicio Vigencia
                        </td>
                        <td class="formValue">
                            <telerik:RadDatePicker ID="vigenciainicial" runat="server" Culture="en-US" MinDate="2010-01-01"
                                TabIndex="15" EnableViewState="False" Width="220px">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" TabIndex="15">
                                </DateInput>
                                <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="15"></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="formLabel">
                            Modelo
                        </td>
                        <td class="formValue">
                            <asp:TextBox ID="modelo" runat="server" MaxLength="4" TabIndex="6"
                                EnableViewState="False" width="220px"></asp:TextBox>
                        </td>
                        <td width="10%">
                            &nbsp;
                        </td>
                        <td class="formLabel">
                            Fin Vigencia
                        </td>
                        <td class="formValue">
                            <telerik:RadDatePicker ID="vigenciafinal" runat="server" MinDate="2010-01-01" TabIndex="16"
                                EnableViewState="False" Width="220px">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" TabIndex="16">
                                </DateInput>
                                <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="16"></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="formLabel">
                            Num. Serie
                        </td>
                        <td class="formValue">
                            <asp:TextBox ID="noserie" runat="server" MaxLength="20" TabIndex="7"
                                EnableViewState="False" width="220px"></asp:TextBox>
                        </td>
                        <td width="10%">
                            &nbsp;
                        </td>
                        <td class="formLabel">
                            Propietario
                        </td>
                        <td class="formValue">
                            <asp:TextBox ID="propietario" runat="server" TabIndex="17" 
                                EnableViewState="False" width="220px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="formLabel">
                            Tipo de Combustible
                        </td>
                        <td class="formValue">
                            <asp:DropDownList ID="combustible" runat="server" TabIndex="8" 
                                CssClass="select">
                            </asp:DropDownList>
                        </td>
                        <td width="10%">
                            &nbsp;
                        </td>
                        <td class="formLabel">
                            Verificación Vehicular
                        </td>
                        <td class="formValue">
                            <telerik:RadDatePicker ID="verificacionvehicular" runat="server" MinDate="2010-01-01"
                                TabIndex="18" EnableViewState="False" Width="220px">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" TabIndex="18">
                                </DateInput>
                                <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="18"></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="formLabel">
                            Placas
                        </td>
                        <td class="formValue">
                            <asp:TextBox ID="placas" runat="server" MaxLength="10" TabIndex="9"
                                EnableViewState="False" width="220px"></asp:TextBox>
                            <asp:TextBox ID="PKUnidad" runat="server" Visible="False" Width="5px"></asp:TextBox>
                        </td>
                        <td width="10%" valign="top">
                            &nbsp;
                        </td>
                        <td class="formLabel">
                            Observaciones
                        </td>
                        <td class="formValue">
                            <asp:TextBox ID="observaciones" runat="server" Height="75px" TextMode="MultiLine"
                                Rows="3" Width="220px" TabIndex="19" EnableViewState="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                       
                      
                        <td align="right" style="text-align: center;" valign="top" colspan="5">
                         
                            <asp:HiddenField ID="Idunidad" runat="server" />
                               <br/>
                            <br/>
                            <asp:ImageButton ID="imgCancelar" runat="server" ImageUrl="~/Imagenes/Cancelar.png"
                                OnClick="imgCancelar_Click" EnableViewState="False" />
                            <asp:ImageButton ID="imgLimpiar" runat="server" ImageUrl="~/Imagenes/Limpiar.png"
                                EnableViewState="False" />
                            <asp:ImageButton ID="imgGuardar" runat="server" ImageUrl="~/Imagenes/Grabar.png"
                                OnClick="imgGuardar_Click" EnableViewState="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

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
