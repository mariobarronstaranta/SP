<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.master" AutoEventWireup="true" CodeFile="CierrePedido.aspx.cs" Inherits="Views_CierrePedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">




    <form id="form1" runat="server">
    <div style="margin-left: 10px; text-align: right;">
        <span style="text-align: center">
            <h2> Cierre de Pedidos</h2>
        </span>
        <asp:ImageButton ID="btnCierre" runat="server" ImageUrl="~/Imagenes/Confirmar_Cerrar_Pedidos.png" OnClick="btnCierre_Click"
            ForeColor="#000020" Width="90px" EnableViewState="False" Height="35px" /> 

           
    </div>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
<TABLE class="tabledata"> 
			<TR>
				<TD class="formLabel">Cve Pedido</TD>
				<TD><DIV>
                    <asp:Literal ID="litCvePedido" runat="server"></asp:Literal>
                    </DIV></TD>
				<TD class="formLabel">Fecha Compromiso</TD>
				<TD ><DIV>
                    <asp:Literal ID="LitFecha" runat="server"></asp:Literal>
                    </DIV></TD>
			</TR>
			<TR>
				<TD class="formLabel">Cliente</TD>
				<TD ><DIV>
                    <asp:Literal ID="litCliente" runat="server"></asp:Literal>
                    </DIV></TD>
				<TD class="formLabel">Producto</TD>
				<TD ><DIV>
                    <asp:Literal ID="LitProducto" runat="server"></asp:Literal>
                    </DIV></TD>
			</TR>
			<TR>
				<TD class="formLabel">Obra</TD>
				<TD><DIV>
                    <asp:Literal ID="litObra" runat="server"></asp:Literal>
                    </DIV></TD>
				<TD class="formLabel">Cantidad</TD>
				<TD ><DIV>
                    <asp:Literal ID="LitCantidad" runat="server"></asp:Literal>
                    </DIV></TD>
			</TR>
			<TR>
				<TD class="formLabel">Direccion</TD>
				<TD ><DIV>
                    <asp:Literal ID="litDireccion" runat="server"></asp:Literal>
                    </DIV></TD>
				<TD class="formLabel">Num Viajes</TD>
				<TD><DIV>
                    <asp:Literal ID="LitViajes" runat="server"></asp:Literal>
                    </DIV></TD>
			</TR>
		</TABLE>
		
		<BR>
		
		
    <telerik:RadGrid ID="GridViajes" runat="server" AutoGenerateColumns="False" onneeddatasource="GridViajes_NeedDataSource" OnItemCommand="GridViajes_ItemCommand" GroupPanelPosition="Top">
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
    <Columns>
        <telerik:GridBoundColumn DataField="IDViaje" HeaderText="Cve Viaje" 
            UniqueName="column1">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Remision" HeaderText="Remision" 
            UniqueName="column2">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Planta" UniqueName="colPlanta" 
            DataField="CvePlanta">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Unidad" UniqueName="colUnidad" 
            DataField="IDClaveUnidad">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Carga" UniqueName="colCarga" 
            DataField="CargaViaje" DataType="System.Double">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Hora Salida" UniqueName="colHS" 
            DataField="HoraInicio">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Llegada Obra" UniqueName="colLO" 
            DataField="HoraLlegadaObra">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Inicio Colado" UniqueName="colIC" 
            DataField="HoraInicioColado" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Fin Colado" UniqueName="colFC" 
            DataField="HoraFinColado" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Salida Obra" UniqueName="colSO" 
            DataField="HoraSalidaObra">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="Llegada Planta" UniqueName="colLP" 
            DataField="HoraFin">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Factura" FilterControlAltText="Filter column3 column" HeaderText="Factura" UniqueName="column3">
        </telerik:GridBoundColumn>
        <telerik:GridButtonColumn CommandName="Editar" HeaderText="Editar" 
            Text="Editar" UniqueName="column">
        </telerik:GridButtonColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
    </telerik:RadGrid>
    </form>
</asp:Content>

