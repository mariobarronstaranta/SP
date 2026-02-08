<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true"
    CodeFile="CatalogoObra.aspx.cs" Inherits="Views_CatalogoObra" %>

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

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table runat="server" id="tblCamposGenerales" cellspacing="1" visible="true">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Clave" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Nombre" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Cliente" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="RFC" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top">
                            <asp:TextBox ID="txtClave" runat="server" TabIndex="1" CssClass="txtgradiente"
                                ReadOnly="True"></asp:TextBox></td>
                        <td style="vertical-align:top">
                            <asp:TextBox ID="txtNombre" TabIndex="2"
                                runat="server" Width="250px" Rows="2"
                                TextMode="MultiLine" MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="validanombre" runat="server"
                                    ControlToValidate="txtNombre"
                                    ErrorMessage="Es necesario capturar un nombre para la obra">*</asp:RequiredFieldValidator></td>
                        <td style="vertical-align:top">
                            <asp:DropDownList ID="cboCliente" runat="server" TabIndex="3" CssClass="select"
                                AutoPostBack="True" OnSelectedIndexChanged="cboCliente_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="validacliente" runat="server"
                                ControlToValidate="cboCliente" ErrorMessage="Es necesario capturar un cliente"
                                ValueToCompare="-1" Type="Integer" Operator="GreaterThan">*</asp:CompareValidator>
                        </td>
                        <td style="vertical-align:top">
                            <asp:TextBox ID="txtRFC" runat="server" CssClass="txtgradiente" MaxLength="25" TabIndex="4"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Direccion" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Entre Calles" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Colonia" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" Text="Poblacion"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top"><asp:TextBox ID="txtDireccion" TabIndex="5" runat="server" Width="225px" Rows="3"
                        TextMode="MultiLine" MaxLength="255"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="validadireccion" runat="server"
                        ControlToValidate="txtDireccion"
                        ErrorMessage="Capture una direccion para la obra">*</asp:RequiredFieldValidator></td>
                        <td style="vertical-align:top"><asp:TextBox ID="txtentrecalles" runat="server" Width="250px" Rows="3"
                        TabIndex="6" TextMode="MultiLine" MaxLength="255"></asp:TextBox></td>
                        <td style="vertical-align:top">
                            <asp:TextBox ID="txtColonia" runat="server" CssClass="txtgradiente" TabIndex="7"></asp:TextBox>
                        </td>
                        <td style="vertical-align:top">
                            <asp:TextBox ID="txtPoblacion" runat="server" CssClass="txtgradiente" MaxLength="255" TabIndex="8"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 19px">
                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" Text="Planta"></asp:Label>
                        </td>
                        <td style="height: 19px">
                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" Text="Codigo Postal"></asp:Label>
                        </td>
                        <td style="height: 19px">
                            <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Size="Small" Text="Ciudad Obra"></asp:Label>
                        </td>
                        <td style="height: 19px">
                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" Text="Ciudad Sistema Pedidos"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td> <asp:DropDownList ID="cboPlanta" runat="server" TabIndex="9" CssClass="select">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="validaplanta" runat="server"
                        ControlToValidate="cboPlanta" ErrorMessage="Es necesario capturar una planta"
                        ValueToCompare="-1" Operator="NotEqual">*</asp:CompareValidator></td>
                        <td>
                            <asp:TextBox ID="txtCP" runat="server" CssClass="" MaxLength="9" TabIndex="10" Width="100px"></asp:TextBox>
                            <asp:Button ID="cmdValidaCP" runat="server" OnClick="cmdValidaCP_Click" Text="Validar CP" TabIndex="11" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtCiudadObra" runat="server" CssClass="txtgradiente" TabIndex="12"></asp:TextBox>
                        </td>
                        <td><asp:DropDownList ID="cboCiudad" runat="server" Enabled="False" TabIndex="13" CssClass="select" Width="250">
                            </asp:DropDownList></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" Text="Latitud (Norte/Sur)"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" Text="Longitud (Este/Oeste)"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Telefono" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top">
                            <asp:TextBox ID="txtAltitud" runat="server" CssClass="txtgradiente" MaxLength="20" TabIndex="14"></asp:TextBox>
                        </td>
                        <td style="vertical-align:top">
                            <asp:TextBox ID="txtlatitud" runat="server" CssClass="txtgradiente" MaxLength="20" TabIndex="15"></asp:TextBox>
                            </td>
                        <td style="vertical-align:top">
                            <asp:TextBox ID="txtTelefono" runat="server" TabIndex="16"
                        CssClass="txtgradiente" MaxLength="50"></asp:TextBox></td>
                        <td style="vertical-align:top">
                           </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Size="Small" Text="Atencion"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="Small" Text="Responsable"></asp:Label>
                        </td>
                        <td colspan="2"><asp:Label ID="Label15" runat="server" Text="Google Maps" Font-Bold="True" Font-Size="Small"></asp:Label>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top"> 
                            <asp:TextBox ID="txtAtencion" runat="server" CssClass="txtgradiente" MaxLength="255" TabIndex="17"></asp:TextBox>
                        </td>
                        <td style="vertical-align:top">
                            <asp:TextBox ID="txtResponsable" runat="server" CssClass="txtgradiente" MaxLength="255" TabIndex="18"></asp:TextBox>
                        </td>
                        <td colspan="2" style="vertical-align:top"><asp:TextBox ID="txtUrlMaps" TabIndex="19" runat="server" Width="450px" Rows="2"
                        TextMode="MultiLine" MaxLength="400"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton1" runat="server" EnableTheming="True" Height="40px" ImageUrl="~/MetroImages/VistaPrevia.png" OnClick="ImageButton1_Click" Width="40px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Size="Small" Text="Distancia"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Small" Text="Vendedor"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="Small" Text="Tiempo de Ciclo"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Size="Small" Text="Estatus"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top"><asp:TextBox ID="txtDistancia" runat="server" TabIndex="20"
                        CssClass="txtgradiente" MaxLength="6"></asp:TextBox></td>
                       <td style="vertical-align:top">
                            <asp:DropDownList ID="cboVendedor" runat="server" CssClass="select" TabIndex="21">
                            </asp:DropDownList>
                        </td>
                        <td style="vertical-align:top"><asp:DropDownList ID="cboCiclo" runat="server" TabIndex="22" CssClass="select">
                        <asp:ListItem Value="-1">(Seleccione)</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>60</asp:ListItem>
                        <asp:ListItem>90</asp:ListItem>
                        <asp:ListItem Selected="True">120</asp:ListItem>
                        <asp:ListItem>150</asp:ListItem>
                        <asp:ListItem>180</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="validaciclo" runat="server"
                        ControlToValidate="cboCiclo" ErrorMessage="Es necesario capturar un cliclo de viaje"
                        ValueToCompare="-1" Type="Integer" Operator="GreaterThan">*</asp:CompareValidator></td>
                        <td style="vertical-align:top">
                            <asp:DropDownList ID="cboestatus" runat="server" CssClass="select" TabIndex="23">
                                <asp:ListItem Value="1">Activo</asp:ListItem>
                                <asp:ListItem Value="0">Inactivo</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                       
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label20" runat="server" Text="Vol. Acumulado" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Size="Small" Text="Vol. Estimado"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Label23" runat="server" Text="Vol. Usar Datos Cliente" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top">
                            <asp:TextBox ID="txtVolA" runat="server" CssClass="txtgradiente" MaxLength="6" TabIndex="24"></asp:TextBox>
                        </td>
                        <td style="vertical-align:top">
                            <asp:TextBox ID="txtVolE" runat="server" CssClass="txtgradiente" MaxLength="6" TabIndex="25"></asp:TextBox>
                        </td>
                        <td style="vertical-align:top">
                            
                        </td>
                        <td style="vertical-align:top">
                            <asp:CheckBox ID="chkDatos" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Usar Datos de Cliente" TabIndex="26" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td></td>
                        <td></td>
                    </tr>


                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </div>
        </asp:Panel>


       


        <br />
        <br />
        <table width="75%" border="0" cellspacing="0" cellpadding="0" align="center">

            <tr>
                <td align="right" style="text-align: center;" colspan="4">
                    <input id="IdPlanta" type="hidden" runat="server" />
                    <asp:ImageButton ID="imgCancelar" runat="server" ImageUrl="~/MetroImages/UI_Regresar.png"
                        OnClick="imgCancelar_Click" CausesValidation="False" onMouseOver="MouseRollover(this,'UI_Regresar_Over.png')" onMouseOut="MouseOut(this,'UI_Regresar.png')" />
                    <asp:ImageButton ID="imgLimpiar" runat="server" ImageUrl="~/MetroImages/UI_Limpiar.png"
                        OnClick="imgLimpiar_Click" CausesValidation="False" onMouseOver="MouseRollover(this,'UI_Limpiar_Over.png')" onMouseOut="MouseOut(this,'UI_Limpiar.png')" />
                    <asp:ImageButton ID="imgGuardar" runat="server" ImageUrl="~/MetroImages/UI_Grabar.png"
                        OnClick="imgGuardar_Click" onMouseOver="MouseRollover(this,'UI_Grabar_Over.png')" onMouseOut="MouseOut(this,'UI_Grabar.png')" />
                </td>

            </tr>

            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                        BackColor="#E0E0E0" DisplayMode="List" Font-Bold="False" Font-Names="Segoe UI"
                        Font-Size="Small" ForeColor="#B91D47" />
                </td>
            </tr>

            <tr>
                <td>

                    
                   
                    

                </td>
            </tr>
        </table>
    </form>
    <script type="text/javascript">
        function AcceptNum(evt) {

            var nav4 = window.Event ? true : false;
            var key = nav4 ? evt.which : evt.keyCode;
            return (key <= 13 || (key >= 46 && key <= 57) || key == 44);
        }
    </script>
</asp:Content>
