<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/MasterPage.master"
    CodeFile="ListaUsuarios.aspx.cs" Inherits="Views_ListaUsuarios" EnableEventValidation="false" EnableViewStateMac="False" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Usuarios
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <table width="100%">
            <tr>
                <td style="text-align: center">
                    <h2>Catalogo de Usuarios </h2>
                </td>
            </tr>
        </table>


        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Usuario:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Perfil:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label2" runat="server" Text="Ciudad:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtBuscar" runat="server" CssClass="txtgradiente"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="cboPerfil" runat="server" CssClass="select"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="cboCiudades" runat="server" CssClass="select"></asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:ImageButton ID="buscar" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png"
                                OnClick="buscar_Click" Height="35px"  />
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/MetroImages/NuevoElemento.png"
                                OnClick="ImageButton1_Click" Height="35px" />
                            <asp:ImageButton ID="btnExportar" runat="server" ImageUrl="~/MetroImages/ExcelExport.png" OnClick="btnExportar_Click" Height="35px" EnableViewState="False" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>



        <table width="95%" align="center">
            <tr>
                <td>
                    <telerik:RadGrid ID="grdUsuarios" runat="server" GridLines="None" AllowPaging="True"
                        AutoGenerateColumns="False" Width="990px" OnNeedDataSource="grdUsuarios_NeedDataSource"
                        OnItemCommand="grdUsuarios_ItemCommand" PageSize="20" CellSpacing="0" Skin="Metro">
                        <MasterTableView>
                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Created="True">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="Clave" UniqueName="column5"
                                    DataField="Id_Usuario">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Usuario" UniqueName="column6" DataField="UserName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Nombre" UniqueName="column7" DataField="Nombre">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="APaterno" HeaderText="Apellidos" UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="AMaterno" UniqueName="column4">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Ciudad" UniqueName="column" DataField="Ciudad">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Perfil" HeaderText="Perfil" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn HeaderText="Editar" Text="Editar" UniqueName="column8">
                                </telerik:GridButtonColumn>
                            </Columns>

                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                            </EditFormSettings>

                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Left" Wrap="True" />
                            <AlternatingItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" Wrap="True" />
                            <PagerStyle Mode="NumericPages" />
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
    </form>
</asp:Content>
