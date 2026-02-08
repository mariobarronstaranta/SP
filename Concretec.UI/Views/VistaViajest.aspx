<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true"
    CodeFile="VistaViajest.aspx.cs" Inherits="Views_VistaViajest" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">
    <table style="width: 100%">
        <tr>
            <td align="left">
                Cliente:
                <asp:Label ID="cliente" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Obra:
                <asp:Label ID="obra" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="grdViajes" runat="server" GridLines="None" AllowPaging="True"
                    AutoGenerateColumns="False" Width="837px" AllowSorting="True" AllowAutomaticDeletes="True"
                    AllowAutomaticInserts="True" AllowAutomaticUpdates="True">
                    <MasterTableView>
                        <RowIndicatorColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="Pedido" UniqueName="IDPedido" Visible="true"
                                DataField="IDPedido" DataType="System.Int32" SortExpression="IDPedido">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Viaje" UniqueName="IDViaje" DataField="IDViaje"
                                SortExpression="IDViaje">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Fecha Inicio" UniqueName="FechaInicio" DataField="FechaInicio"
                                SortExpression="FechaInicio">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Hora Inicio" UniqueName="HoraInicio" DataField="HoraInicio"
                                SortExpression="HoraInicio">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Carga Viaje" UniqueName="CargaViaje" DataField="CargaViaje"
                                SortExpression="CargaViaje">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Remision" HeaderText="Remision" SortExpression="Remision"
                                UniqueName="Remision">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </form>
</asp:Content>
