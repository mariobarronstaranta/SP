<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true"
    CodeFile="BitacoraClientes.aspx.cs" Inherits="Views_BitacoraClientes" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        GridLines="None" Width="600px">
        <MasterTableView>
            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
            <RowIndicatorColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="RegistrosNuevos" HeaderText="Reg. Nuevos" UniqueName="column">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="RegistrosActualizados" HeaderText="RegistrosActualizados"
                    UniqueName="column1">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FechaProceso" HeaderText="FechaProceso" UniqueName="column2">
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
    </form>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
