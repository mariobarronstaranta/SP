<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="ConfigSalmat.aspx.cs" Inherits="Views_ConfigSalmat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" Runat="Server">
    ConfigSalmat
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <form id="form1" runat="server">
        <span style="text-align: center">
        <h2>
            Salmat
        </h2>
    </span>
       
                         <asp:Panel ID="pnlFiltro" runat="server" GroupingText="Filtros" CssClass="gridFilter">
            <div style="text-align: left;">
                <table align="center" cellspacing="1">
                        <tr>
                            
                        <td><asp:Label ID="Label1" runat="server" Text="Ciudad:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td><asp:Label ID="Label2" runat="server" Text="Sección:" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td></td>
                            </tr>
                    <tr>
                    
                     <td class="formValue" style="height:32px">
                          <asp:DropDownList ID="Ciudad" runat="server" TabIndex="2" CssClass="select">

                          </asp:DropDownList>
                     </td>
                            
                            <td class="formValue" style="height:32px">
                                <asp:DropDownList ID="Seccion" runat="server" TabIndex="3" CssClass="select">

                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:ImageButton ID="btnBuscar" runat="server" EnableViewState="False" Height="35px" ImageUrl="~/MetroImages/BuscarDatos.png" OnClick="btnBuscar_Click"  />
                            </td>
                            </tr>
                    </table>
                </div>
                        
                </asp:Panel>
             <table width="100%">
            <tr>
                <td>
                    <table align="center">
                                <tr>
                                    
                                <th class="formLabel"  style="text-align:center; height: 10px;" >
                                    Campo CB2
                                
                         </th>    
                                <th class="formLabel" style="text-align:center; height: 10px;">
                                    Mostrar Campo
                                </th>
                            </tr>
                        <td class="formLabel">
                            Ingrediente
                        </td>
                        <td class="formValue" style="height:32px">
                           <asp:TextBox ID="Ingrediente" runat="server" MaxLength="20" TabIndex="1" Width="220px">

                           </asp:TextBox>
                        </td>
                              <tr>
                        <td class="formLabel">
                            Unidad de Medicion
                        </td>
                        <td class="formValue" style="height:32px">
                            <asp:TextBox ID="UM" runat="server" MaxLength="10" TabIndex="2" Width="220px">

                            </asp:TextBox>
                        </td>
                           </tr>
                        
                      
                        <tr>
                            <td class="formLabel">
                                HuFac
                            </td>
                            <td class="formValue" style="height:32px">
                                <asp:TextBox ID="HuFac" runat="server" MaxLength="10" TabIndex="3" Width="220px">

                                </asp:TextBox>
                            </td>
                             </tr>
                        
                            <td class="formLabel">
                                Aca
                            </td>
                            <td class="formValue" style="height:32px">
                                <asp:TextBox ID="Aca" runat="server" MaxLength="10" TabIndex="4" Width="220px">

                                </asp:TextBox>

                            </td>
                       
                        <tr>
                            <td class="formLabel">
                                ABS Fac
                            </td>
                            <td class="formValue" style="height:32px">
                                <asp:TextBox ID="ABSFac" runat="server" MaxLength="10" TabIndex="5" Width="220px">

                                </asp:TextBox>
                            </td>
                            </tr>
                            <td class="formLabel">
                                M3
                            </td>
                            <td class="formValue" style="height:32px">
                                <asp:TextBox ID="AF" runat="server" MaxLength="10" TabIndex="6" Width="220px">

                                </asp:TextBox>
                            </td>
                        
                            <tr>
                                <td class="formLabel">
                                    Sec
                                </td>
                                
                                <td class="formValue" style="height:32px">
                                    <asp:TextBox ID="Sec" runat="server" MaxLength="10" TabIndex="7" Width="220px">

                                    </asp:TextBox>
                                </td>
                                </tr>
                                
                                <td class="formLabel">
                                    Obj
                                </td>
                                <td>
                                    <asp:TextBox ID="Obj" runat="server" MaxLength="10" TabIndex="8" Width="220px">

                                    </asp:TextBox>
                                </td>
                            
                        <tr>
                            <td class="formLabel">
                                Abs
                            </td>
                            <td class="formValue" style="height:32px">
<asp:TextBox ID="As" runat="server" MaxLength="10" TabIndex="9" Width="220px">

</asp:TextBox>
                            </td>
                            </tr>
                  <tr>
                            <td class="formLabel">
                                Real
                            </td>
                            <td class="formValue" style="height:32px">
                                <asp:TextBox ID="Real" runat="server" MaxLength="10" TabIndex="10" Width="220px">

                                </asp:TextBox>
                            </td>
                      </tr>
                            <td class="formLabel">
                                SSS
                            </td>
                            <td class="formValue" style="height:32px">
                                <asp:TextBox ID="SSS" runat="server" MaxLength="10" Width="220px">

                                </asp:TextBox>
                            </td>
                        <tr>
                           <td class="formLabel">
                                Porcentaje
                            </td>
                            
                            <td class="formValue" style="height:32px">
                                <asp:TextBox ID="Pj" runat="server" MaxLength="10" TabIndex="11" Width="220px">

                                </asp:TextBox>
                            </td>
                        </tr>
                                                <tr>
                       
                      
                        <td align="right" style="text-align: center;" valign="top" colspan="5">
                         
                           
                               <br/>
                            <br/>
                            <asp:ImageButton ID="imgCancelar" runat="server" ImageUrl="~/Imagenes/Cancelar.png"
                                OnClick="imgCancelar_Click" EnableViewState="False" />
                            <asp:ImageButton ID="imgLimpiar" runat="server" ImageUrl="~/Imagenes/Limpiar.png"
                                EnableViewState="False" />
                            <asp:ImageButton ID="imgGuardar" runat="server" ImageUrl="~/Imagenes/Grabar.png"
                                OnClick="imgGuardar_Click" EnableViewState="False" />
                        </td>
                    </tr>
                 </table>
                </td>
            </tr>
        </table>    
        

    </form>

</asp:Content>

