<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="rptRemisiones.aspx.cs" Inherits="Views_rptRemisiones" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <form id="form1" runat="server">
    <asp:ScriptManager id='scriptManager' runat='server' />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" ProcessingMode="Remote" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="800px" 
        Width="990px">
        <ServerReport ReportPath="/Remisiones" />
    </rsweb:ReportViewer>
    </form>
</asp:Content>

