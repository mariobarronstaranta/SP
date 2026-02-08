<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Contabilidad.master" AutoEventWireup="true"
    CodeFile="AutorizacionClientes.aspx.cs" Inherits="Views_AutorizacionClientes" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <table width="100%">
            <tr>
                <td colspan="2" style="text-align: center">
                    <h2>Habilitar Clientes</h2>
                </td>
            </tr>
        </table>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Nombre o Clave:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Estatus:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td></td>
                    </tr>



                    <tr>
                        <td><asp:TextBox ID="txtBuscar" runat="server" EnableViewState="False" CssClass="txtgradiente"></asp:TextBox></td>
                        <td>
                            <asp:DropDownList ID="cboEstatus" runat="server" CssClass="select">
                                <asp:ListItem Value="-1">(Seleccione)</asp:ListItem>
                                <asp:ListItem Value="5">En Autorizacion</asp:ListItem>
                                <asp:ListItem Value="6">Autorizado</asp:ListItem>
                                <asp:ListItem Value="7">Rechazado</asp:ListItem>
                             </asp:DropDownList>
                        </td>
                        <td><asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png"  OnClick="btnBuscar_Click" Height="35px" /></td>
                    </tr>
                </table>
            </div>
        </asp:Panel>

        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCommand="RadGrid1_ItemCommand" OnItemDataBound="RadGrid1_ItemDataBound" CellSpacing="0" Skin="Metro">
            <MasterTableView>
                <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                <RowIndicatorColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
                <ExpandCollapseColumn Created="True">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn HeaderText="Clave Cliente" UniqueName="column"
                        DataField="ClaveCliente">
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Nombre" UniqueName="column1"
                        DataField="NombreCompleto">
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Clave Vendedor" UniqueName="column2"
                        DataField="IDVendedor">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Telefonos" UniqueName="column3"
                        DataField="Telefonos">
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Lim. Credito" UniqueName="column4"
                        DataField="LimiteCredito">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Saldo Actual" UniqueName="column5"
                        DataField="Saldo">
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Saldo Disponible" UniqueName="column6"
                        DataField="CreditoDisponible">
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Estatus" UniqueName="column9"
                        DataField="EstatusAutorizacion">
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn HeaderText="Detalle" Text="Ver" UniqueName="column7" CommandName="Ver">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn HeaderText="Autorizar" Text="OK" UniqueName="column8"
                        CommandName="Habilitar" Visible="False">
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="IDCliente" HeaderText="IDCliente"
                        UniqueName="column10">
                    </telerik:GridBoundColumn>
                </Columns>

                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                </EditFormSettings>

                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
            </MasterTableView>

            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

            <FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
    </form>
</asp:Content>
