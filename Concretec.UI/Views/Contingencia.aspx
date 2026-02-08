<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="Contingencia.aspx.cs" Inherits="Views_Contingencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Contingencias
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
        <span style="text-align: center">
            <h2>Maestro de Catálogos</h2>
        </span>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Catalogo:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Elemento:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>

                    <tr>
                        <td><asp:DropDownList ID="cboCategoria" runat="server" CssClass="select"></asp:DropDownList></td>
                        <td><telerik:RadTextBox ID="txtFiltro" runat="server" EmptyMessage="Descripcion a buscar" LabelWidth="64px" Resize="None" Skin="Metro" Width="350px"></telerik:RadTextBox></td>
                        
                        <td><asp:ImageButton ID="btnBuscar" runat="server" Height="35px" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnBuscar_Click" /></td>
                        <td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/MetroImages/NuevoElemento.png" Height="35px" OnClick="ImageButton1_Click" /></td>
                        <td><asp:ImageButton ID="btnExportar" runat="server" ImageUrl="~/MetroImages/ExcelExport.png" OnClick="btnExportar_Click" Height="35px" EnableViewState="False" /></td>
                    </tr>



                </table>
            </div>
        </asp:Panel>

        <table width="80%">
            <tr align="center">
                <td>


                    <telerik:RadGrid ID="GridContingencias" runat="server" AutoGenerateColumns="False" Skin="Metro" OnNeedDataSource="GridContingencias_NeedDataSource" OnItemCommand="GridContingencias_ItemCommand">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn FilterControlAltText="Filter column column" HeaderText="Clave" UniqueName="column" DataField="idContingencia">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn FilterControlAltText="Filter column1 column" HeaderText="Descripcion" UniqueName="column1" DataField="Descripcion">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn FilterControlAltText="Filter column3 column" HeaderText="Catalogo" UniqueName="column3" DataField="DescripcionCategoriaObservaciones">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn FilterControlAltText="Filter column2 column" HeaderText="Fecha Modificacion" UniqueName="column2" DataField="fechaultimamodificacion" DataType="System.DateTime">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn CommandName="Editar" HeaderText="Editar"
                                    Text="Editar" UniqueName="column10" ImageUrl="~/Imagenes/Edit.png">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>

            </tr>
        </table>

    </form>
</asp:Content>

