<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/MasterPage.master"
    CodeFile="ListaUnidades.aspx.cs" Inherits="View_ListaUnidades" EnableEventValidation="false" %>

<%@ Import Namespace="Concretec.Pedidos.BE" %>
<%@ Import Namespace="Concretec.Agentes" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Unidades
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <span style="text-align: center">
            <h2>Catálogo de Unidades </h2>
        </span>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" EnableTheming="True">
        </telerik:RadScriptManager>

        <div style="text-align: left;">
            <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
                <table cellspacing="1">
                    <tr>
                        <td>
                            <asp:Label ID="lblfiltersPoblacion" runat="server" Text="Nombre Unidad:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Planta:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Estatus:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td></td>
                        <td></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox ID="txtBuscar" runat="server"
                                OnTextChanged="txtBuscar_TextChanged" CssClass="txtgradiente"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="cboPlanta" runat="server" AutoPostBack="True" CssClass="select"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="cboEstatus" runat="server" CssClass="select">
                                <asp:ListItem Selected="True" Value="-1">(Todos)</asp:ListItem>
                                <asp:ListItem Value="1">Activo</asp:ListItem>
                                <asp:ListItem Value="0">Inactivo</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png"
                                OnClick="btnBuscar_Click" Height="35px" />
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/MetroImages/NuevoElemento.png" OnClick="ImageButton1_Click" Height="35px" Visible="false" />
                            <asp:ImageButton ID="btnExportar" runat="server" ImageUrl="~/MetroImages/ExcelExport.png" OnClick="btnExportar_Click" Height="35px" EnableViewState="False" />
                        </td>
                        <td style="text-align: center">
                            <%
                                Usuario _usuario = new Usuario();
                                List<Usuario> Login = new List<Usuario>();
                                Login = (List<Usuario>)Session[Concretec.Pedidos.Constantes.Etiquetas.TAG_SESSION_DATOSUSUSARIO];
                                if (Login != null) { _usuario = Login[0]; }
                            

                                if (_usuario.Perfil=="Admon" || _usuario.Perfil=="JFP" || _usuario.Perfil=="CP")
                                {

                                    Response.Write("<a href=\"" +"PlaneacionUnidades.aspx" + "\"" + ">");
                                    Response.Write("<img id=\"" + "img_plantas" + "\"" + " " + "src=" + "\"" + "../MetroImages/Planeacion_Diaria.png" + "\"" + " " + "onmouseover=MouseRollover(this,'Planeacion_Diaria.png')" +  " " + "onmouseout=" + "\"" + " " + "MouseOut(this,'Planeacion_Diaria.png')" + "\"" + " " + "/></a>");
                                }
                           %>
                           <%-- <a href="PlaneacionUnidades.aspx">
                                <img id="img_plantas" src="../MetroImages/Planeacion_Diaria.png" onmouseover="MouseRollover(this,'Planeacion_Diaria.png')" onmouseout="MouseOut(this,'Planeacion_Diaria.png')" /></a>--%>
                        </td>
                    </tr>

                </table>
            </asp:Panel>
        </div>




        <table width="95%" align="center">
            <tr>
                <td>
                    <telerik:RadGrid ID="rgdUnidades" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        AllowSorting="True" OnNeedDataSource="rgdUnidades_NeedDataSource"
                        Width="990px" AllowAutomaticInserts="True" AllowAutomaticUpdates="True" PageSize="20"
                        OnItemCommand="rgdUnidades_ItemCommand" Skin="Metro" GroupPanelPosition="Top">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Created="True">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="IDClaveUnidad" HeaderText="Clave" UniqueName="column">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CveAlterna" FilterControlAltText="Filter column2 column" HeaderText="Cve Alterna" UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Planta" HeaderText="Planta" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Placas" HeaderText="Placa" UniqueName="column4">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" UniqueName="column7">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NombreOperador" HeaderText="Nombre Operador"
                                    UniqueName="column13">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Estatus" FilterControlAltText="Filter column3 column" HeaderText="Estatus" UniqueName="column3">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn CommandName="Edit" HeaderText="Editar" ImageUrl="~/Imagenes/editText.jpg"
                                    Text="Editar" UniqueName="column">
                                </telerik:GridButtonColumn>
                            </Columns>

                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                            </EditFormSettings>

                            <PagerStyle Mode="NumericPages" />
                        </MasterTableView>
                        <PagerStyle Mode="NumericPages" />

                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
