<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Planeacion.aspx.cs" Inherits="Views_Planeacion" %>

<%@ Import Namespace="Concretec.Pedidos.BE" %>
<%@ Import Namespace="Concretec.Agentes" %>
<!DOCTYPE html
    PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title></title>
    <link href="Planeacion.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/FreezePanels/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../scripts/FreezePanels/jquery.jfreezegrid-1.0.min.js" type="text/javascript"></script>
    <script src="../scripts/FreezePanels/jquery.getscrollbarwidth.js" type="text/javascript"></script>

    <script type="text/javascript">
        $().ready(function () {
            //$("#t1").jFreezeGrid({"height": 300});
            $("#t1").jFreezeGrid({ "height": 'available' });
        });
    </script>

    <link rel="stylesheet" type="text/css" href="../scripts/FreezePanels/jfreezegrid.css" media="screen" />
    <style type="text/css">
        table {
            background: transparent;
            height: auto;
        }


        .th {
            background: #e5e7eb;
            height: auto;
        }

        .jfg_frozen_row {
            background: #e5e7eb;
            height: auto;
        }

        .jfg_frozen_col {
            background: #e5e7eb;
            height: auto;
        }

        .line1 td {
            background: #e5e7eb;
            height: auto;
        }
    </style>

</head>

<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <table border="0" align="left">
            <tr>
                <td class="formLabel">Fecha</td>
                <td class="formValue">
                    <telerik:RadDatePicker ID="DTfecha" runat="server" Culture="en-US" Skin="Metro">
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            Skin="Metro"></Calendar>

                        <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelWidth="40%">
                        </DateInput>

                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </td>
                <td class="formLabel">Hora Inicio / Fin</td>
                <td class="formValue" width="330px">
                    <telerik:RadTimePicker ID="DThorainicio" runat="server" Culture="en-US"
                        FocusedDate="2011-01-03" MinDate="2011-01-03"
                        OnSelectedDateChanged="DThorainicio_SelectedDateChanged" Skin="Metro">
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            ViewSelectorText="x">
                        </Calendar>
                        <DatePopupButton Visible="False" CssClass="" ImageUrl="" HoverImageUrl="">
                        </DatePopupButton>
                        <TimeView CellSpacing="-1" Columns="4" EndTime="20:59:59" Interval="01:00:00"
                            StartTime="06:00:00">
                        </TimeView>
                        <TimePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></TimePopupButton>
                        <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelCssClass="">
                        </DateInput>
                    </telerik:RadTimePicker>


                    <telerik:RadTimePicker ID="DThorafin" runat="server" Culture="en-US"
                        FocusedDate="2011-01-03" MinDate="2011-01-03" SelectedDate="2011-12-30 19:00:00"
                        Skin="Metro">
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            ViewSelectorText="x">
                        </Calendar>
                        <DatePopupButton Visible="False" CssClass="" ImageUrl="" HoverImageUrl="">
                        </DatePopupButton>
                        <TimeView CellSpacing="-1" Columns="4" EndTime="20:59:59" Interval="01:00:00"
                            StartTime="07:00:00">
                        </TimeView>
                        <TimePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></TimePopupButton>
                        <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelCssClass="">
                        </DateInput>
                    </telerik:RadTimePicker>
                </td>

                <td class="formLabel">Plantas</td>
                <td rowspan="2" class="formValue" valign="top">
                    <telerik:RadComboBox ID="rcboplanta" runat="server" CheckBoxes="True" Skin="Metro">
                    </telerik:RadComboBox>
                </td>
                <td style="text-align: right" class="formValue">
                    <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/MetroImages/BuscarDatos.png"
                        OnClick="btnBuscar_Click" Height="40px" />
                    <asp:ImageButton ID="btnBombas" runat="server" ImageUrl="~/MetroImages/Bombas.png"
                        OnClick="btnBombasr_Click" Height="40px" />
                </td>
            </tr>


        </table>
        <br />
        <table width="100%" border="0">
            <tr>
                <td class="vprogramado">PROGRAMADO</td>
                <td class="vdespachado">DESPACHADO</td>
                <td class="vcerrado">ENTREGADO</td>
            </tr>
        </table>

        <table id="t1" border="0px">
            <%
                int saltos = 0;
                AgenteUnidades au = new AgenteUnidades();
                List<ConsultaUnidad> planta = au.ObtieneUnidad();

                var plantas = from pp in planta
                              where pp.CveCiudad == DatosUsuario.Ciudad && pp.CveDosificadora.Contains("PD") && pp.IDEstatus == 1
                              orderby pp.Planta
                              select new { pp.Planta, pp.IDClaveUnidad };

                if (Request.QueryString["Plantas"] != null)
                {
                    string[] valstr = Request.QueryString["Plantas"].Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    if (valstr.Length > 0 && valstr[0] != "-1")
                    {
                        try
                        {
                            int[] valores = Array.ConvertAll(valstr, int.Parse);
                            plantas = from pp in planta
                                      where pp.CveCiudad == DatosUsuario.Ciudad &&
                                            pp.CveDosificadora.Contains("PD") &&
                                            pp.IDEstatus == 1 &&
                                            valores.Contains(pp.IdPlanta)
                                      orderby pp.Planta
                                      select new { pp.Planta, pp.IDClaveUnidad };
                        }
                        catch (FormatException)
                        {
                            // If parsing fails, show no plants.
                            plantas = plantas.Take(0);
                        }
                    }
                }

                string dia = Request.QueryString["Fecha"];
                List<ConsultaUnidad> UnidadesOcupadas = au.ObtenerUnidadesOcupadas(DatosUsuario.Ciudad, DateTime.Parse(dia));

                string _plantaanterior = "";
                StringBuilder _html = new StringBuilder();

                Response.Write("<THEAD><tr>");
                Response.Write("<td class='tdgris2'>Planta Origen</td>");

                for (int i = int.Parse(HoraInicio.Substring(0, 2)); i <= int.Parse(HoraFin.Substring(0, 2)); i++)
                {
                    string _hora = i.ToString("D2");
                    for (int ii = 0; ii <= 50; ii = ii + 10)
                    {
                        string _minutos = ii.ToString("D2");
                        string _horaminutos = _hora + _minutos;
                        _html.Clear();
                        _html.AppendFormat("<td class='tdgris2' id='{0}'>{1}:{2}</td>", _horaminutos, _hora, _minutos);
                        Response.Write(_html);
                    }
                }
                Response.Write("</tr></THEAD><TBODY><tr><td class='tdgris'></td><td class='tdgris' colspan='12'></td></tr>");

                foreach (var p in plantas)
                {
                    Response.Write("<tr>");
                    if (_plantaanterior != (p.Planta + p.IDClaveUnidad))
                    {
                        _plantaanterior = p.Planta + p.IDClaveUnidad;
                        Response.Write("<td class='tdgris'>" + p.Planta.Substring(0, 3) + " " + p.IDClaveUnidad + "</td>");
                    }
                    else
                    {
                        Response.Write("<td class='tdgris'></td>");
                    }

                    for (int i = int.Parse(HoraInicio.Substring(0, 2)); i <= int.Parse(HoraFin.Substring(0, 2)); i++)
                    {
                        string _hora = i.ToString("D2");
                        for (int ii = 0; ii <= 50; ii = ii + 10)
                        {
                            _html.Clear();
                            string _minutos = ii.ToString("D2");
                            string _horaminutos = _hora + _minutos;

                            if (saltos < 1)
                            {
                                var _unidades_ = from _unidad in UnidadesOcupadas
                                                 where _unidad.Planta == p.Planta &&
                                                       _unidad.IDClaveUnidad == p.IDClaveUnidad &&
                                                       _unidad.horaminutos_inicio.Replace(":", "") == _horaminutos
                                                 select _unidad;

                                ConsultaUnidad Entidad = _unidades_.FirstOrDefault();

                                if (Entidad != null)
                                {
                                    string cssClass = "vprogramado";
                                    switch (Entidad.Estatus)
                                    {
                                        case "Despachado": cssClass = "vdespachado"; break;
                                        case "Cancelado": cssClass = "vcancelado"; break;
                                        case "Entregado": cssClass = "vcerrado"; break;
                                        case "Programado":
                                        default:
                                            cssClass = "vprogramado"; break;
                                    }

                                    _html.AppendFormat("<td id='{0}' class='{1}' colspan='{2}'><a href='#' STYLE='TEXT-DECORATION: NONE;color:Black;' class='tooltip'>",
                                        _horaminutos, cssClass, Entidad.bloques);

                                    if (Entidad.bloques > 1)
                                    {
                                        _html.AppendFormat("<div>Viaje : {0} Pedido: {1} Obra:{2} - {3}</div>",
                                            Entidad.numviaje, Entidad.IDPedido, Entidad.CveObra, Entidad.NombreObra);
                                        _html.AppendFormat("<span>Cliente:{0} - {1}<BR> Carga: {2} m3<BR> Producto: {3} - {4}<BR> Unidad : {5}<BR>Programador:{6}</span>",
                                            Entidad.CveCliente, Entidad.NombreCliente, Entidad.carga, Entidad.CveAlternaProducto, Entidad.NombreProducto, Entidad.IDClaveUnidad, Entidad.ProgramadoPor);
                                    }
                                    else
                                    {
                                        _html.AppendFormat("Viaje : {0} <br>Ped: {1} Obra:{2}", Entidad.numviaje, Entidad.IDPedido, Entidad.CveObra);
                                        _html.AppendFormat("<span>Cliente:{0} Unidad :{1}</span>", Entidad.CveCliente, Entidad.IDClaveUnidad);
                                    }
                                    _html.Append("</a></td>");
                                    saltos = Entidad.bloques;
                                }
                                else
                                {
                                    _html.AppendFormat("<td id='{0}' class='tdverde'></td>", _horaminutos);
                                }
                            }
                            saltos--;
                            Response.Write(_html);
                        }
                    }
                    Response.Write("</tr>");
                }
                Response.Write("</tbody>");
            %>
        </table>
    </form>
</body>

</html>