<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="CargaCB2.aspx.cs" Inherits="Views_CargaCB2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
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
            <h2>Carga Archivos CB2 </h2>
        </span>




        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">

                    <tr>
                        <td>


                            <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" 
                                ChunkSize="0" 
                                MultipleFileSelection="Automatic" 
                                Skin="Metro" 
                                AllowedFileExtensions=".txt"
                                Width="500px">

                            </telerik:RadAsyncUpload>
                            
                        </td>
                        <td>
                            <telerik:RadComboBox ID="RadComboBox1" runat="server" Skin="Metro" Width="300px">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/MetroImages/SyncDatos.png" Width="40px"/>

                        </td>
                    </tr>
                    <tr><td><telerik:RadProgressArea runat="server" ID="RadProgressArea1" Skin="Metro" /></td></tr>
                </table>
            </div>
        </asp:Panel>
    </form>
</asp:Content>

