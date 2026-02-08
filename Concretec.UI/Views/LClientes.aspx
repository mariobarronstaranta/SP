<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="LClientes.aspx.cs" Inherits="Views_LClientes" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server">
    Catalogo de Clientes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table width="100%">
            <tr>
                <td style="text-align: center">
                    <h2>Catalogo de Clientes </h2>
                </td>
            </tr>
        </table>


        <table style="width: 100%">
            <tr>
                <td class="tdIzquierda">
                    <h4>Nombre o Clave</h4>
                </td>
                <td class="tdIzquierda">
                    <h4>Planta</h4>
                </td>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td class="tdIzquierda">
                    <asp:TextBox ID="txtBuscar" runat="server" EnableViewState="False" CssClass="txtgradiente"></asp:TextBox>
                    <telerik:RadTextBox ID="RadTextBox1" Runat="server" Skin="Metro">
                    </telerik:RadTextBox>
                    <td class="tdIzquierda">
                        <asp:DropDownList ID="cboplantas" runat="server" CssClass="select"></asp:DropDownList>
                        <td>

                            <%if (DatosUsuario.Perfil == "Admon" || DatosUsuario.Perfil == "Conta")
                              {%>
                            <asp:ImageButton ID="btnActualizar" runat="server" ImageUrl="~/Imagenes/SincronizarClientes.png"
                                OnClick="btnActualizar_Click" Height="35px" Width="90px" />
                            <%} %>
                        </td>
                        <td style="text-align: left;">
                            <asp:ImageButton ID="btnAutorizaciones" runat="server" ImageUrl="~/Imagenes/Autorizacion_Clientes.png"
                                OnClick="btnAutorizaciones_Click" Height="35px" Width="90px" />
                            <td style="text-align: left;">
                                <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Imagenes/BotonBuscar.jpg"
                                    OnClick="btnBuscar_Click" Height="35px" Width="90px" />
                            </td>
            </tr>
        </table>

        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" GridLines="None" AutoGenerateColumns="False" OnItemCommand="Radgrid1_ItemCommand" AllowPaging="True" PageSize="20" OnNeedDataSource="RadGrid1_NeedDataSource">
            <MasterTableView>
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>

                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column" Created="True">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>

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
                    <telerik:GridBoundColumn HeaderText="Saldo Libre" UniqueName="column4" DataField="Saldo">
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>

                    <telerik:GridTemplateColumn>
                               <ItemTemplate>
                                   <asp:ImageButton ID="btnTest" runat="server" CommandName="SendMail" ImageUrl="~/Imagenes/Programacion_small.png" ToolTip="Generar Pedido" Width="20px" Height="20px"
                                       CommandArgument='<%# Eval("ClaveCliente") %>' />
                               </ItemTemplate>
                           </telerik:GridTemplateColumn>
                </Columns>


                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                </EditFormSettings>

                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
            </MasterTableView>

            <PagerStyle PageSizeControlType="RadComboBox" Mode="NumericPages" ShowPagerText="False"></PagerStyle>

            <FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>

    </form>


</asp:Content>

