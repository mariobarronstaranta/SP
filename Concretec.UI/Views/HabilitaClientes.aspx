<%@ Page Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true"
    CodeFile="HabilitaClientes.aspx.cs" Inherits="Views_HabilitaClientes" EnableEventValidation="false" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Usuarios
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">

        <table width="100%">
            <tr>
                <td style="text-align: center">
                    <h2>Catalogo de Clientes en Cartera </h2>
                </td>
            </tr>
        </table>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Nombre o Clave:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Planta:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td colspan="3"></td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadTextBox ID="txtBuscar" runat="server" Height="25px" Skin="Metro" Width="200px">
                            </telerik:RadTextBox></td>
                        <td>
                            <telerik:RadComboBox ID="cboplantas" runat="server" Skin="Metro" Width="200px">
                            </telerik:RadComboBox></td>
                            <td>

                            </td>
                        <td style="text-align: right;">
                            &nbsp;<td style="text-align: right;">
                            <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png"
                                OnClick="btnBuscar_Click" Height="35px" />
                        </td>
                    </tr>
                </table>

            </div>
        </asp:Panel>




       <table width="100%" align="center">
            <tr align="center">
                <td colspan="2">
                    <telerik:RadGrid ID="gridClientes" runat="server" GridLines="None" AllowPaging="True"
                        AutoGenerateColumns="False" OnNeedDataSource="gridClientes_NeedDataSource" OnItemDataBound="gridClientes_ItemDataBound"
                        PageSize="20" OnItemCommand="gridClientes_ItemCommand" CellSpacing="0" Width="990px" Skin="Metro">
                        <MasterTableView>
                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Created="True">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="IDCliente" UniqueName="column8" Visible="false"
                                    DataField="IDCliente">
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Ciudad" UniqueName="column1" DataField="Poblacion">
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Clave Cliente" UniqueName="column"
                                    DataField="ClaveCliente">
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Clave Vendedor" UniqueName="column5" DataField="IDVendedor">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Planta" HeaderText="Planta" UniqueName="column6" Visible="False">
                                    <HeaderStyle Width="300px" />
                                    <ItemStyle Width="300px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Nombre" UniqueName="column2" DataField="NombreCompleto">
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Teléfonos" UniqueName="column3" DataField="Telefonos">
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="LimiteCredito" FilterControlAltText="Filter column9 column" HeaderText="Lim Credito" UniqueName="column9">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Saldo Actual" UniqueName="column4" DataField="Saldo">
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn HeaderText="Pedidos" Text="Prog." UniqueName="column7" Visible="false"
                                    CommandName="Editar">
                                </telerik:GridButtonColumn>

                                <telerik:GridBoundColumn DataField="EstatusAutorizacion" FilterControlAltText="Filter column10 column" HeaderText="Estatus" UniqueName="column10">
                                </telerik:GridBoundColumn>

                                <telerik:GridTemplateColumn>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnTest" runat="server" CommandName="Programacion" ImageUrl="~/MetroImages/EnviarAut.png" ToolTip="Generar Pedido" Width="20px" Height="20px"
                                            CommandArgument='<%# Eval("ClaveCliente") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                            </Columns>

                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                            </EditFormSettings>

                            <PagerStyle Mode="NumericPages" />
                        </MasterTableView>
                        <PagerStyle Mode="NumericPages" />

                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                    </telerik:RadGrid>
                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"
                        EnableViewState="False">
                    </telerik:RadScriptManager>

                </td>
            </tr>
            <tr>
                <td style="width: 546px">&nbsp;
                </td>
                <td style="text-align: right">&nbsp;
                </td>
            </tr>
        </table>
        </td>
            </tr>
        </table>

    </form>
</asp:Content>
