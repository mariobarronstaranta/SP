<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="PlaneacionUnidades.aspx.cs" Inherits="Views_PlaneacionUnidades" %>

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

        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Office2010Black" MultiPageID="RadMultiPage1" Width="95%" SelectedIndex="1">
            <Tabs>
                <telerik:RadTab Text="Planeacion"       PageViewID="TabPlaneacion"      TabIndex="0"    NavigateUrl="PlaneacionUnidades.aspx" runat="server"  Visible="false"></telerik:RadTab>
                <telerik:RadTab Text="Unidades"         PageViewID="TabUnidades"        TabIndex="1"    NavigateUrl="PlaneacionUnidades.aspx?page=Unidades" Selected="true" runat="server"></telerik:RadTab>
                <telerik:RadTab Text="Configuracion"    PageViewID="TabConfiguracion"   TabIndex="2"    NavigateUrl="PlaneacionUnidades.aspx?page=Configuracion" runat="server"></telerik:RadTab>
                <telerik:RadTab Text="Registro"         PageViewID="TabRegistro"        TabIndex="3"    NavigateUrl="PlaneacionUnidades.aspx?page=Registro" runat="server" Visible="false"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="1" Width="95%">

            <telerik:RadPageView runat="server" ID="RPV_Planeacion">
                <asp:Panel ID="pnl_Planeacion" runat="server" GroupingText="Planeacion" CssClass="gridFilter">
                    <div style="text-align: left;"></div>
                </asp:Panel>
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RPV_Unidades">
                <asp:Panel ID="pnl_Unidades" runat="server" GroupingText="Unidades" CssClass="gridFilter">
                    <div style="text-align: left;">
                        <table runat="server" id="tblfiltros">
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Planta" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <telerik:RadComboBox ID="CboPlantaBusqueda" runat="server" Skin="Metro"></telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Unidad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                                <td>
                                    <telerik:RadTextBox ID="txtNombreUnidad" runat="server"></telerik:RadTextBox></td>
                                <td>
                                    <asp:ImageButton ID="cmdbuscar" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="cmdbuscar_Click" Width="35px" /></td>

                                <td>
                                    <asp:TextBox ID="txtidtanqueregistro" runat="server" Visible="False"></asp:TextBox>
                                </td>
                            </tr>
                        </table>

                        <table width="95%" align="center">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rgdUnidades" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        AllowSorting="True" OnNeedDataSource="rgdUnidades_NeedDataSource"
                                        Width="990px" AllowAutomaticInserts="True" AllowAutomaticUpdates="True" PageSize="100"
                                        OnItemCommand="rgdUnidades_ItemCommand" Skin="Metro">
                                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                        <MasterTableView>
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <RowIndicatorColumn>
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn Created="True">
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="IDUnidad" FilterControlAltText="Filter column5 column" HeaderText="id" UniqueName="column5">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="IDClaveUnidad" HeaderText="Clave" UniqueName="column">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CveAlterna" FilterControlAltText="Filter column2 column" HeaderText="Cve Alterna" UniqueName="column2">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Planta" HeaderText="Planta" UniqueName="column1">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NombreOperador" HeaderText="Nombre Operador" UniqueName="column13">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Estatus" FilterControlAltText="Filter column3 column" HeaderText="Estatus" UniqueName="column3">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="StrMotivoInactividad" FilterControlAltText="Filter column4 column" HeaderText="Motivo Inactividad" UniqueName="column4">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="StrMotivoCambioOperador" FilterControlAltText="Filter column4 column" HeaderText="Motivo Operador" UniqueName="column5">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridButtonColumn CommandName="Editar" HeaderText="Editar" ImageUrl="~/Imagenes/editText.jpg" Text="Editar" UniqueName="column">
                                                </telerik:GridButtonColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                </EditColumn>
                                            </EditFormSettings>
                                            <PagerStyle Mode="NumericPages" />
                                        </MasterTableView>
                                        <PagerStyle Mode="NumericPages" />

                                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;
                                </td>
                            </tr>
                        </table>

                    </div>
                </asp:Panel>
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RPV_Configuracion">
                <asp:Panel ID="pnl_Configuracion" runat="server" GroupingText="Configuracion" CssClass="gridFilter">
                    <div style="text-align: left;">
                        <table  runat="server" id="tblEditaUnidad">
                            <tr id="rowIdUnidad" runat="server">
                                <td><asp:Label ID="Label10" runat="server" Text="ID" Font-Bold="True" Font-Size="Large" ></asp:Label></td>
                                <td><asp:Label ID="Label2" runat="server" Text="Clave" Font-Bold="True" Font-Size="Large" ></asp:Label></td>
                                <td><asp:Label ID="Label3" runat="server" Text="Clave Alterna" Font-Bold="True" Font-Size="Large"></asp:Label></td>
                                <td><asp:Label ID="Label4" runat="server" Text="Planta" Font-Bold="True" Font-Size="Large"></asp:Label></td>
                            </tr>
                            <tr id="rowIdUnidadDatos" runat="server">
                                <td><telerik:RadTextBox ID="txtUnidadId" runat="server" Skin="MetroTouch" Width="200px" ReadOnly="True"></telerik:RadTextBox></td>                             
                                <td><telerik:RadTextBox ID="txtClave" runat="server" Skin="MetroTouch" Width="200px" ReadOnly="True"></telerik:RadTextBox></td>
                                <td><telerik:RadTextBox ID="txtCveAlterna" runat="server" Skin="MetroTouch" Width="200px" ReadOnly="True"></telerik:RadTextBox></td>
                                <td><telerik:RadComboBox ID="cboPlantaEdicion" runat="server" Skin="MetroTouch" Width="200px"></telerik:RadComboBox></td>                                                          
                            </tr>
                       


                        
                            

                            <tr runat="server" visible="true" id="rowmotivo">
                                
                                <td colspan="2"><asp:Label ID="Label7" runat="server" Text="Estatus Unidad" Font-Bold="True" Font-Size="Large"></asp:Label></td>
                                <td colspan="2"><asp:Label ID="Label8" runat="server" Text="Motivo Inactividad" Font-Bold="True" Font-Size="Large"></asp:Label></td>
                            </tr>

                            

                            <tr>
                                
                                <td colspan="2"><telerik:RadComboBox ID="cboEstatus" runat="server" Skin="MetroTouch" Width="400px" AutoPostBack="True" OnSelectedIndexChanged="cboEstatus_SelectedIndexChanged">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="(Seleccione)" Value="-1" />
                                        <telerik:RadComboBoxItem runat="server" Text="Activo" Value="1" />
                                        <telerik:RadComboBoxItem runat="server" Text="Inactivo" Value="0" />
                                    </Items>
                                    </telerik:RadComboBox></td>
                                <td colspan="2"><telerik:RadComboBox ID="cboMotivoInactividad" runat="server" Skin="MetroTouch" Width="400px" OnSelectedIndexChanged="cboMotivoInactividad_SelectedIndexChanged" Enabled="False"></telerik:RadComboBox></td>
                            </tr>


                            <tr>
                                <td colspan="2"><asp:Label ID="Label11" runat="server" Text="Operador Asignado" Font-Bold="True" Font-Size="Large"></asp:Label></td>
                                <td colspan="2"><asp:Label ID="Label12" runat="server" Text="Estatus Operador" Font-Bold="True" Font-Size="Large"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:Label ID="lblOperadorAsignado" runat="server" Text="" Font-Bold="True" Font-Size="Large"></asp:Label></td>
                                <td colspan="2"><telerik:RadComboBox ID="cboEstatusOperador" runat="server" Skin="MetroTouch" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="cboEstatusOperador_SelectedIndexChanged">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Selected="True" Text="(Seleccione)" Value="-1" />
                                        <telerik:RadComboBoxItem runat="server" Text="Activo" Value="1" />
                                        <telerik:RadComboBoxItem runat="server" Text="Inactivo" Value="0" />
                                    </Items>
                                    </telerik:RadComboBox></td>
                            </tr>

                            <tr runat="server" visible="true" id="rowempleado">
                                <td colspan="2"><asp:Label ID="Label5" runat="server" Text="Operador Reasignado" Font-Bold="True" Font-Size="Large"></asp:Label></td>
                                <td colspan ="2"><asp:Label ID="Label9" runat="server" Text="Motivo Cambio Operador" Font-Bold="True" Font-Size="Large"></asp:Label></td>
                            </tr>
                            

                            <tr>
                                
                                <td colspan="2"><telerik:RadComboBox ID="cboOperador" runat="server" Skin="MetroTouch" Width="400px" AutoPostBack="True" OnSelectedIndexChanged="cboOperador_SelectedIndexChanged" Enabled="False"></telerik:RadComboBox></td>
                                <td colspan="2"><telerik:RadComboBox ID="cboMotivoOperador" runat="server" Skin="MetroTouch" Width="250px" Enabled="False"></telerik:RadComboBox></td>
                            </tr>


                            <tr>
                                <td></td>
                                <td><asp:ImageButton ID="cmdGuardarUnidad" runat="server" ImageUrl="~/MetroImages/aceptar.png" OnClick="cmdGuardarUnidad_Click" Width="35px" /></td>
                                 <td></td>
                                <td></td>
                            </tr>

                           

                            <tr>
                                <td></td>
                                <td></td>
                                 <td></td>
                            </tr>

                            <tr>
                                <td></td>
                                <td></td>
                                 <td></td>
                            </tr>
                        </table>

                    </div>
                </asp:Panel>
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RPV_Registro">
                <asp:Panel ID="pnl_Registro" runat="server" GroupingText="Registro" CssClass="gridFilter">
                    <div style="text-align: left;"></div>
                </asp:Panel>
            </telerik:RadPageView>

        </telerik:RadMultiPage>
    </form>
</asp:Content>

