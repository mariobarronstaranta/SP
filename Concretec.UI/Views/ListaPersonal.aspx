<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/MasterPage.master"
    CodeFile="ListaPersonal.aspx.cs" Inherits="Views_ListaPersonal" EnableEventValidation="false" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Usuarios
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <span style="text-align: center">
            <h2>Catálogo de Personal
            </h2>
        </span>
        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Nombre:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Planta:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label2" runat="server" Text="Estatus:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label3" runat="server" Text="Tipo:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtBuscar" runat="server" EnableViewState="False" Height="20px" Width="180px"></asp:TextBox></td>
                        <td>
                            <asp:DropDownList ID="cboPlanta" runat="server" CssClass="selectmin"></asp:DropDownList></td>
                        <td>
                            <asp:DropDownList ID="cboEstatus" runat="server" CssClass="selectmin">
                                <asp:ListItem Value="-1">(Seleccione)</asp:ListItem>
                                <asp:ListItem Value="Alta">Activo</asp:ListItem>
                                <asp:ListItem Value="Baja">Inactivo</asp:ListItem>
                            </asp:DropDownList></td>
                        <td>
                            <asp:DropDownList ID="cboTipo" runat="server" CssClass="selectmin">
                                <asp:ListItem Value="-1">(Seleccione)</asp:ListItem>
                                <asp:ListItem Value="Interno">Interno</asp:ListItem>
                                <asp:ListItem Value="Externo">Externo</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnBuscar" runat="server" EnableViewState="False" Height="35px" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnBuscar_Click" />
                        </td>
                        <td>
                            <asp:ImageButton ID="btnnuevo" runat="server" EnableViewState="False" Height="35px" ImageUrl="~/MetroImages/NuevoElemento.png" OnClick="btnnuevo_Click" />
                        </td>
                        <td><asp:ImageButton ID="btnExportar" runat="server" ImageUrl="~/MetroImages/ExcelExport.png" OnClick="btnExportar_Click" Height="35px" EnableViewState="False" /></td>
                    </tr>

                </table>
            </div>
        </asp:Panel>

        <table width="100%">
            <tr>
                <td>
                    <table width="100%">


                        <tr>
                            <td>
                                <telerik:RadGrid ID="GridEmpleados" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" OnNeedDataSource="GridEmpleados_NeedDataSource" OnItemCommand="GridEmpleados_ItemCommand" Skin="Metro">
<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                                    <MasterTableView>
                                        <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                                        <RowIndicatorColumn>
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn Created="True">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="IDPersonal" FilterControlAltText="Filter column4 column" HeaderText="ID" UniqueName="column4">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Cve Personal" UniqueName="column" DataField="ClavePersonal">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Nombre" UniqueName="column" DataField="Nombre">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Puesto" UniqueName="column" DataField="Puesto">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Estatus" UniqueName="column" DataField="Estatus">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Planta" HeaderText="Ubicacion" UniqueName="column1">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoPersonal" HeaderText="Tipo" UniqueName="column2">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridButtonColumn CommandName="Editar" HeaderText="Editar" Text="Ver" UniqueName="column3">
                                            </telerik:GridButtonColumn>
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
                                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                                    <AjaxSettings>
                                        <telerik:AjaxSetting AjaxControlID="RadGrid1">
                                        </telerik:AjaxSetting>
                                    </AjaxSettings>
                                </telerik:RadAjaxManager>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
