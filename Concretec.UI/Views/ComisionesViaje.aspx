<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="ComisionesViaje.aspx.cs" Inherits="Views_ComisionesViaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <form id="form1" runat="server">

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                </asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                </asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>

        <table width="100%">
            <tr>
                <td style="text-align: center">
                    <h2>Comision Operadores</h2>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                
                <table runat="server" id="tblfiltros">
                    <tr>
                        <td><asp:Label ID="Label6" runat="server" Text="Ciudad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label8" runat="server" Text="Unidad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label9" runat="server" Text="Tipo Operador" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td rowspan="2">
                            <asp:ImageButton ID="cmdbuscar" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="cmdbuscar_Click" Width="35px" />
                        </td>
                        <td rowspan="2">
                            <asp:ImageButton ID="cmdnuevo" runat="server" ImageUrl="~/MetroImages/NuevoElemento.png" OnClick="cmdnuevo_Click" Width="35px" />
                        </td>
                    </tr>
                    <tr>
                            <td><telerik:RadComboBox ID="cboCiudadFiltro" runat="server" Skin="Metro"></telerik:RadComboBox></td>
                            <td><telerik:RadComboBox ID="cboUnidadFiltro" runat="server" Skin="Metro">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="(Seleccione)" Value="-1" />
                                    <telerik:RadComboBoxItem runat="server" Text="Metros Cubicos" Value="1" />
                                    <telerik:RadComboBoxItem runat="server" Text="Viajes" Value="2" />
                                </Items>
                                </telerik:RadComboBox></td>
                            <td><telerik:RadComboBox ID="cboPersonalFiltro" runat="server" Skin="Metro">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="(Seleccione)" Value="-1" />
                                    <telerik:RadComboBoxItem runat="server" Text="Operador de Bomba" Value="OPB" />
                                    <telerik:RadComboBoxItem runat="server" Text="Operador de Revolvedor" Value="OPR" />
                                    <telerik:RadComboBoxItem runat="server" Text="Ayudante de Bomba" Value="AYUB" />
                                </Items>
                                </telerik:RadComboBox></td>
                    </tr>
                </table>
                
                <table runat="server" id="tbl" cellspacing="1" visible="false">
                    <tr>
                        <td><asp:Label ID="Label7" runat="server" Text="Clave" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Valor Minimo" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Valor Maximo" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label2" runat="server" Text="Unidad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label3" runat="server" Text="Tipo Operador" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label4" runat="server" Text="Comision" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label5" runat="server" Text="Ciudad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td rowspan="2">
                            <asp:ImageButton ID="cmdguardar" runat="server" ImageUrl="~/MetroImages/GuardarDatos.png" Width="35px" OnClick="cmdguardar_Click" />
                        </td>
                        <td rowspan="2">
                            <asp:ImageButton ID="cmdcancelar" runat="server" ImageUrl="~/MetroImages/Close.png"  Width="35px" OnClick="cmdcancelar_Click"/>
                        </td>
                        <td rowspan="2">
                            <asp:ImageButton ID="cmdborrar" runat="server" ImageUrl="~/MetroImages/BorrarDatos.png"  Width="35px" OnClick="cmdborrar_Click" Visible="false"/>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblidcomision" runat="server" Text="" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <telerik:RadNumericTextBox ID="txtinicio" runat="server" Culture="en-US" DbValueFactor="1" LabelWidth="64px" MaxValue="100" MinValue="1" Skin="Metro" Width="100px" DataType="System.Int32">
                            </telerik:RadNumericTextBox>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="txtfin" runat="server" Culture="en-US" DbValueFactor="1" LabelWidth="64px" MaxValue="100" MinValue="1" Skin="Metro" Width="100px" DataType="System.Int32">
                            </telerik:RadNumericTextBox>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cboUnidades" runat="server" Skin="Metro">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="(Seleccione)" Value="-1" />
                                    <telerik:RadComboBoxItem runat="server" Text="Metros Cubicos" Value="1" />
                                    <telerik:RadComboBoxItem runat="server" Text="Viajes" Value="2" />
                                </Items>
                                </telerik:RadComboBox></td>
                        
                        <td>
                            <telerik:RadComboBox ID="cboPersonal" runat="server" Skin="Metro">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="(Seleccione)" Value="-1" />
                                    <telerik:RadComboBoxItem runat="server" Text="Operador de Bomba" Value="OPB" />
                                    <telerik:RadComboBoxItem runat="server" Text="Operador de Revolvedor" Value="OPR" />
                                    <telerik:RadComboBoxItem runat="server" Text="Ayudante de Bomba" Value="AYUB" />
                                </Items>
                                </telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="txtcomision" runat="server" Width="100px">
                            </telerik:RadNumericTextBox>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cboCiudades" runat="server" Width="150px" Skin="Metro"></telerik:RadComboBox>
                        </td>
                        
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <table style="width: 100%"><tr><td>
            <telerik:RadGrid ID="gridComisiones" runat="server" AllowPaging="True" AutoGenerateColumns="False" Skin="Metro" OnItemCommand="gridComisiones_ItemCommand">
<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                <MasterTableView>
                    <Columns>
                        <telerik:GridBoundColumn DataField="idComisionViaje" FilterControlAltText="Filter column7 column" HeaderText="Clave" UniqueName="column7">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column column" HeaderText="Inicio" UniqueName="column" DataField="Inicio">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column1 column" HeaderText="Fin" UniqueName="column1" DataField="Fin">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column2 column" HeaderText="Unidad" UniqueName="column2" DataField="TipoUnidad">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column3 column" HeaderText="Tipo Operador" UniqueName="column3" DataField="TipoPersonal">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column4 column" HeaderText="Ciudad" UniqueName="column4" DataField="NombreCiudad">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column5 column" HeaderText="Comision" UniqueName="column5" DataField="Comision">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn CommandName="Editar" FilterControlAltText="Filter column6 column" HeaderText="Editar" Text="&gt;&gt;" UniqueName="column6">
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </td></tr></table>
    </form>
</asp:Content>

