<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="RptGraficaConsumos.aspx.cs" Inherits="Views_RptGraficaConsumos" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form id="form1" runat="server">

        <span style="text-align: center">
            <h2>Comparacion Volumenes</h2>
        </span>

        <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table cellspacing="1">
                    <tr>
                        <td><asp:Label ID="lblfiltersPoblacion" runat="server" Text="Fecha Entrega Inicio:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Fecha Entrega Fin:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label2" runat="server" Text="Ciudad:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>&nbsp;</td>
                        <td></td>

                    </tr>
                    <tr>
                        <td>
                            <telerik:RadDatePicker ID="inicio" runat="server" MinDate="2005-01-01" Width="200px" EnableViewState="False" Skin="Metro">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Metro"></Calendar>

                                <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="fin" runat="server" MinDate="2005-01-01" Width="200px" EnableViewState="False" Skin="Metro">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Metro"></Calendar>
                                <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy"></DateInput>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td><asp:DropDownList ID="cboCiudades" runat="server" CssClass="select"></asp:DropDownList></td>
                        <td>&nbsp;</td>
                        
                
                        <td><asp:ImageButton ID="btnBuscar" runat="server" EnableViewState="False" Height="35px" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnBuscar_Click" />
                        </td>

                    </tr>


                </table>
            </div>
        </asp:Panel>



        <div style="margin-left: 10px; text-align: left;">
            <asp:DropDownList ID="estatus" runat="server" Width="2px" Visible="False"></asp:DropDownList>
            <asp:DropDownList ID="cliente" runat="server" Width="2px" Visible="False"></asp:DropDownList>

        </div>
        <div style="width: auto; text-align: center;">
            &nbsp;&nbsp;&nbsp;
        
            
        </div>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
    </form>
</asp:Content>


