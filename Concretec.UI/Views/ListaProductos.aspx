<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/MasterPage.master"
    CodeFile="ListaProductos.aspx.cs" Inherits="Views_ListaProductos" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Usuarios
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <span style="text-align: center">
            <h2>Catálogo de Productos</h2>
        </span>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Producto:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Clasificacion:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td></td>
                        <td></td>
                    </tr>

                    <tr>
                        <td><asp:TextBox ID="txtBuscar" runat="server" CssClass="txtgradiente"></asp:TextBox></td>
                        <td><asp:DropDownList ID="cboclasificacion" runat="server" AutoPostBack="True" CssClass="select"></asp:DropDownList></td>
                        <td>

                            <%if (DatosUsuario.Perfil == "Admon" || DatosUsuario.Perfil == "Conta")
                              {%>
                            <asp:ImageButton ID="btnActualizar" runat="server" ImageUrl="~/MetroImages/SyncDatos.png"
                                OnClick="btnActualizar_Click" Height="35px" />
                            <%} %>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnBuscar_Click" Height="35px" />
                            <asp:ImageButton ID="btnAgregarProducto" runat="server" ImageUrl="~/MetroImages/NuevoElemento.png" OnClick="btnAgregarProducto_Click" Height="35px" />
                            <asp:ImageButton ID="btnExportar" runat="server" ImageUrl="~/MetroImages/ExcelExport.png" OnClick="btnExportar_Click" Height="35px" EnableViewState="False" />
                        </td>
                    </tr>

                </table>
            </div>
        </asp:Panel>



        <table width="100%">
            <tr>
                <td align="center">
                    <table align="center" style="width: 97%">

                        <tr>
                            <td colspan="4">
                                <telerik:RadGrid ID="grdProductos" runat="server" GridLines="None" Width="990px"
                                    AllowPaging="True" AutoGenerateColumns="False" PageSize="20" Skin="Metro">
                                    <MasterTableView>
                                        <RowIndicatorColumn>
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn Created="True">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                        </ExpandCollapseColumn>
                                        <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                                        <Columns>
                                            <telerik:GridBoundColumn HeaderText="IDProducto" UniqueName="column" Visible="false"
                                                DataField="IDProducto">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Cve Producto" UniqueName="column"
                                                DataField="ClaveProducto">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Cve Alterna" UniqueName="column2"
                                                DataField="CveAlterna">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Descripcion" HeaderText="Nombre Producto"
                                                UniqueName="column">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Unidad" UniqueName="column" DataField="Unidad">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Precio" UniqueName="column" DataField="Precio">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Clasificacion" HeaderText="Clasificación"
                                                UniqueName="column1">
                                            </telerik:GridBoundColumn>
                                        </Columns>

                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                        </EditFormSettings>

                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                                    </MasterTableView>
                                    <PagerStyle Mode="NumericPages" />

                                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                                </telerik:RadGrid>
                                <telerik:RadScriptManager ID="RadScriptManager1" runat="server" ViewStateMode="Enabled">
                                </telerik:RadScriptManager>
                                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                                    <AjaxSettings>
                                        <telerik:AjaxSetting AjaxControlID="RadGrid1">
                                        </telerik:AjaxSetting>
                                    </AjaxSettings>
                                </telerik:RadAjaxManager>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 599px">&nbsp;
                            </td>
                            <td style="text-align: right">&nbsp;
                            </td>
                        </tr>
                    </table>
                    <div id="boton" align="right">
                    </div>
                </td>
            </tr>
        </table>

    </form>
</asp:Content>
