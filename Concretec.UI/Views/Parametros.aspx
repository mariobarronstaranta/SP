<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true"
    CodeFile="Parametros.aspx.cs" Inherits="Views_Parametros" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
<span style="text-align:center"><H2> Parámetros de Configuración </H2></span>
    <form id="form1" runat="server" enableviewstate="False">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <br />
    <telerik:RadGrid ID="rgParametros" runat="server" GridLines="None"
        AutoGenerateColumns="False" AllowAutomaticDeletes="True"
        AllowAutomaticInserts="True" AllowAutomaticUpdates="True" OnItemCommand="rgParametrs_ItemCommand"
        Style="text-align: left" EnableViewState="False">
        <MasterTableView EnableViewState="False">
            <RowIndicatorColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
            <Columns>
                <telerik:GridBoundColumn HeaderText="Clave" UniqueName="IDParametro" Visible="True"
                    DataField="IDParametro" DataType="System.Int32" SortExpression="IDParametro">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Valor" UniqueName="Valor" DataField="Valor"
                    SortExpression="Valor">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Descripción" UniqueName="Descripcion" DataField="Descripcion"
                    SortExpression="Descripcion">
                </telerik:GridBoundColumn>
                <telerik:GridButtonColumn CommandName="Edit" HeaderText="Editar" ImageUrl="~/Imagenes/editText.jpg"
                    Text="Editar" UniqueName="Editar">
                </telerik:GridButtonColumn>
            </Columns>
        </MasterTableView></telerik:RadGrid>
    </form>
</asp:Content>
