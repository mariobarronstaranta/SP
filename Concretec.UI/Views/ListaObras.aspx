<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/MasterPage.master"
    CodeFile="ListaObras.aspx.cs" Inherits="Views_ListaObras" EnableEventValidation="false" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Usuarios
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" enableviewstate="True">
        <span style="text-align: center">
            <h2>Cátalogo de Obras</h2>
        </span>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Obra:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Planta:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label2" runat="server" Text="Cliente:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label3" runat="server" Text="Estatus:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadTextBox ID="txtBuscar" Runat="server" Height="25px" Skin="Metro" Width="200px">
                            </telerik:RadTextBox>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cboPlanta" Runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboPlanta_SelectedIndexChanged1" Skin="Metro" Width="200px">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cboCliente" Runat="server" Skin="Metro" Width="200px" DropDownAutoWidth="Enabled">
                            </telerik:RadComboBox>
                        </td>
                        <td><telerik:RadComboBox ID="cboEstatus" Runat="server" Skin="Metro" Width="200px">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="(Seleccione)" Value="-1" />
                                <telerik:RadComboBoxItem runat="server" Text="Activo" Value="1" />
                                <telerik:RadComboBoxItem runat="server" Text="Inactivo" Value="0" />
                            </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td style="text-align: right">
                            <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnBuscar_Click" EnableViewState="False" Height="35px" /></td>
                        <td><asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="~/MetroImages/NuevoElemento.png" OnClick="btnNuevo_Click" Height="35px" Style="text-align: right" /></td>
                        <td><asp:ImageButton ID="btnExportar" runat="server" ImageUrl="~/MetroImages/ExcelExport.png" OnClick="btnExportar_Click" Height="35px" EnableViewState="False" /></td>  
                            
                    </tr>
                </table>
            </div>
        </asp:Panel>


        <table width="100%" align="center">
            <tr>
                <td colspan="2">
                    <telerik:RadGrid ID="GridObras" runat="server" GridLines="None" AllowPaging="True"
                        AutoGenerateColumns="False" 
                        PageSize="20" OnItemCommand="GridObras_ItemCommand" CellSpacing="0" Width="990px" Skin="Metro">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>

                            <ExpandCollapseColumn Created="True">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>

                                <telerik:GridBoundColumn DataField="IDObra" HeaderText="Num Obra"
                                    UniqueName="column">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ClaveObra" HeaderText="Clave"
                                    UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ClaveCliente" HeaderText="Cve Cliente"
                                    UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Vendedor" HeaderText="Cve Vend"
                                    UniqueName="column3">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Nombre" HeaderText="Nombre de Obra"
                                    UniqueName="column4">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Atencion" HeaderText="Cliente"
                                    UniqueName="column5">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Planta" HeaderText="Planta"
                                    UniqueName="column6">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Roji" HeaderText="Roji"
                                    UniqueName="column7">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Distancia" HeaderText="Dist (Kms)"
                                    UniqueName="column8">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TiempoCiclo" HeaderText="Ciclo (min)"
                                    UniqueName="column9">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="sEstatus" FilterControlAltText="Filter column11 column" HeaderText="Estatus" UniqueName="column11">
                                </telerik:GridBoundColumn>

                                <telerik:GridButtonColumn CommandName="Editar" HeaderText="Editar"
                                    Text="Editar" UniqueName="column10" ImageUrl="~/Imagenes/Edit.png">
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="Prog" HeaderText="Pedidos" Text="Prog"
                                    UniqueName="column12">
                                </telerik:GridButtonColumn>

                                <telerik:GridTemplateColumn Visible="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEditar" runat="server" CommandName="Edicion" ImageUrl="~/Imagenes/Editar_small.png" ToolTip="Generar Pedido" Width="20px" Height="20px"
                                            CommandArgument='<%# Eval("IDObra") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn Visible="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnTest" runat="server" CommandName="Programacion" ImageUrl="~/Imagenes/Programacion_small.png" ToolTip="Generar Pedido" Width="20px" Height="20px"
                                            CommandArgument='<%# Eval("IDObra") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                            </Columns>

                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                            </EditFormSettings>

                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        </MasterTableView>
                        <PagerStyle Mode="NumericPages" />

                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                    </telerik:RadGrid>
                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                    </telerik:RadScriptManager>

                </td>
            </tr>
        </table>
    </form>
</asp:Content>
