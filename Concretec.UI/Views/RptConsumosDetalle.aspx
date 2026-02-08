<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RptConsumosDetalle.aspx.cs" Inherits="Views_RptConsumosDetalle" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Shared/style.css" rel="stylesheet" type="text/css" />
    <link href="../Shared/estilostelerik.css" rel="stylesheet" type="text/css" />
</head>
<body style='text-align:center'>
    <form id="form1" runat="server">
    <div style="width: auto; text-align: center;">
            &nbsp;&nbsp;&nbsp;
        
            <telerik:RadGrid ID="grdPedidos" runat="server" AllowPaging="True"
                AutoGenerateColumns="False" AllowAutomaticDeletes="True" AllowAutomaticInserts="True"
                AllowAutomaticUpdates="True"
                PageSize="1000" Skin="Metro" >

                <MasterTableView>
                    <RowIndicatorColumn>
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Created="True">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                    <Columns>
                        <telerik:GridBoundColumn HeaderText="Num Pedido"                        DataField="IDPedido"      UniqueName="Ciudad"         Visible="true"  DataType="System.Int32"><HeaderStyle Font-Bold="True" Width="60px" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Cve Cliente"                        DataField="IDClienteSAE"      UniqueName="Planta"         Visible="true">                    <HeaderStyle Font-Bold="True" Width="60px" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CveCiudad" FilterControlAltText="Filter column1 column" HeaderText="Ciudad" UniqueName="column1">                                 <HeaderStyle Font-Bold="True" Width="60px" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NombrePlantaViaje" FilterControlAltText="Filter column column" HeaderText="Planta" UniqueName="column">                           <HeaderStyle Font-Bold="True" Width="100px" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Cliente"                  DataField="NombreCliente"     UniqueName="Pedidos"        Visible="true" >                             <HeaderStyle Font-Bold="True" Width="120px" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Obra"                   DataField="NombreObra"      UniqueName="Viajes"         Visible="true">                                <HeaderStyle Font-Bold="True" Width="120px" /><ItemStyle HorizontalAlign="Left" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NombreProducto" FilterControlAltText="Filter column2 column" HeaderText="Producto" UniqueName="column2">                        <HeaderStyle Font-Bold="True" Width="100px" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="Vol. Viaje"              DataField="CargaViaje"    UniqueName="Remision"       Visible="true">                         <HeaderStyle Font-Bold="True"  Width="50px" /><ItemStyle HorizontalAlign="Left" /></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column3 column" HeaderText="Unidad" UniqueName="Unidad" DataField="UnidadRemision"><HeaderStyle Font-Bold="True" Width="80px"/></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column4 column" HeaderText="Vol Remision" UniqueName="VolRemision" AllowSorting="False" DataField="VolRemision" ><HeaderStyle Font-Bold="True" Width="60px"/></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column5 column" HeaderText="Remision" UniqueName="Remision" DataField="Remision"><HeaderStyle Font-Bold="True" Width="80px"/></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column6 column" HeaderText="Hora Salida" UniqueName="Salida" DataField="Salida"><HeaderStyle Font-Bold="True" Width="60px"/></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter column7 column" HeaderText="Hora Llegada" UniqueName="Llegada" DataField="Llegada"><HeaderStyle Font-Bold="True" Width="60px"/></telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn UniqueName="EditCommandColumn1">
                        </EditColumn>
                    </EditFormSettings>
                    <PagerStyle Mode="NumericPages" />
                </MasterTableView>
                <PagerStyle Mode="NumericPages" />

                <FilterMenu EnableImageSprites="False"></FilterMenu>

            </telerik:RadGrid>
        </div>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
    </form>
</body>
</html>
