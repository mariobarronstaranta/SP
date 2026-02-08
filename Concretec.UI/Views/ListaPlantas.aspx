<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/MasterPage.master"
    CodeFile="ListaPlantas.aspx.cs" Inherits="ListaPlantas" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Plantas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <span style="text-align: center">
            <h2>Catálogo de Plantas </h2>
        </span>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Nombre Planta:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>&nbsp;</td>
                        
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>

                    <tr>
                        <td><asp:TextBox ID="txtnombrePlanta" runat="server" EnableViewState="False" CssClass="txtgradiente"></asp:TextBox></td>
                        <td>
                            &nbsp;</td>


                        <td>&nbsp;
                <asp:ImageButton ID="buscar" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png"
                    OnClick="buscar_Click" Height="35px" EnableViewState="False" />
                        </td>
                        <td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/MetroImages/NuevoElemento.png" OnClick="ImageButton1_Click" Height="35px" EnableViewState="False" /></td>
                        <td><asp:ImageButton ID="btnExportar" runat="server" ImageUrl="~/MetroImages/ExcelExport.png" OnClick="btnExportar_Click" Height="35px" EnableViewState="False" /></td>
                    </tr>
                </table>
            </div>
        </asp:Panel>



        <table style="width: 95%">
            <tr>
                <td style="text-align: center" colspan="2">
                    <telerik:RadGrid ID="gridPlantas" runat="server" AutoGenerateColumns="False" AllowPaging="True" GridLines="None" OnNeedDataSource="rgdUnidades_NeedDataSource"
                        Width="990px" AllowAutomaticInserts="True" AllowAutomaticUpdates="True" PageSize="20"
                        OnItemCommand="rgdUnidades_ItemCommand" CellSpacing="0" Skin="Metro">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Created="True">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="IDPlanta" HeaderText="Cve Planta"
                                    UniqueName="column" Display="False">
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CvePlanta" HeaderText="Clave"
                                    UniqueName="column7">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Nombre" HeaderText="Nombre" UniqueName="column1">
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CveDosificadora" HeaderText="CveDosificadora"
                                    UniqueName="column2">
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Telefono" HeaderText="Telefono" UniqueName="column3">
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Ciudad" HeaderText="Ciudad" UniqueName="column4">
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Calle" HeaderText="Calle" UniqueName="column5">
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NumExt" HeaderText="NumExt" UniqueName="column6">
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn CommandName="Edit" HeaderText="Editar" ImageUrl="~/Imagenes/editText.jpg"
                                    Text="Editar" UniqueName="column">
                                    <ItemStyle HorizontalAlign="Left" />
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
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
