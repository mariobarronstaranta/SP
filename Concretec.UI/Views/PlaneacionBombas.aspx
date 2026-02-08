<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlaneacionBombas.aspx.cs"
    Inherits="Views_PlaneacionBombas" %>

<%@ Import Namespace="Concretec.Pedidos.BE" %>
<%@ Import Namespace="Concretec.Agentes" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
       
    </title>
    <link href="Planeacion.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1
        {
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <table width="100%" border="0" align="left">
        <tr>
            <td class="tdgrisCelda">
                Fecha
            </td>
            <td class="tdNuevo">
                <telerik:RadDatePicker ID="DTfecha" runat="server" Culture="en-US">
                </telerik:RadDatePicker>
            </td>
            <td class="tdgrisCelda">
                Hora Inicial
            </td>
            <td class="tdNuevo">
                <telerik:RadTimePicker ID="DThorainicio" runat="server" Culture="en-US" FocusedDate="2011-01-03"
                    MinDate="2011-01-03" OnSelectedDateChanged="DThorainicio_SelectedDateChanged">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                    </Calendar>
                    <DatePopupButton Visible="False" CssClass="" ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    <TimeView CellSpacing="-1" Columns="4" EndTime="20:59:59" Interval="01:00:00" StartTime="07:00:00">
                    </TimeView>
                    <TimePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></TimePopupButton>
                    <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelCssClass="">
                    </DateInput>
                </telerik:RadTimePicker>
            </td>
            <td class="tdgrisCelda">
                Plantas
            </td>
            <td rowspan="2" class="tdNuevo" valign="top">
                <asp:ListBox ID="selplantas" runat="server" Width="150px" SelectionMode="Multiple">
                </asp:ListBox>
            </td>
            <td style="text-align: right" class="tdNuevo">
                <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Imagenes/BotonBuscar.jpg"
                    OnClick="btnBuscar_Click" Height="35px" Width="90px" />
            </td>
        </tr>
        <tr>
            <td class="tdgrisCelda">
                &nbsp;
            </td>
            <td class="tdNuevo">
                &nbsp;
            </td>
            <td class="tdgrisCelda">
                Hora Final
            </td>
            <td class="tdNuevo">
                <telerik:RadTimePicker ID="DThorafin" runat="server" Culture="en-US" FocusedDate="2011-01-03"
                    MinDate="2011-01-03" SelectedDate="2011-12-30 19:00:00">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                    </Calendar>
                    <DatePopupButton Visible="False" CssClass="" ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    <TimeView CellSpacing="-1" Columns="4" EndTime="20:59:59" Interval="01:00:00" StartTime="07:00:00">
                    </TimeView>
                    <TimePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></TimePopupButton>
                    <DateInput DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy" LabelCssClass="">
                    </DateInput>
                </telerik:RadTimePicker>
            </td>
            <td class="tdgrisCelda">
                &nbsp;
            </td>
            <td style="text-align: right" class="tdNuevo">
                &nbsp;
            </td>
        </tr>
    </table>
    <br />
    <table width="100%" border="1">
        <tr>
            <td class="vprogramado">
                PROGRAMADO
            </td>
            <td class="vdespachado">
                EN TRANSITO
            </td>
            <td class="vcerrado">
                ENTREGADO
            </td>
        </tr>
    </table>
    <table border="1px">
        <%
            AgenteUnidades au = new AgenteUnidades();
            List<ConsultaUnidad> planta = new List<ConsultaUnidad>();
            int saltos = 0;
            int numviaje = 0;

            planta = au.ObtenerBombas();

            var plantas = from pp in planta
                          where pp.CveCiudad == DatosUsuario.Ciudad
                          orderby pp.Planta
                          select new { pp.Planta, pp.IDClaveUnidad };

            if (Request.QueryString["Plantas"] != null)
            {
                string[] valstr = Request.QueryString["Plantas"].Split("|".ToArray());
                int[] valores = new int[valstr.Length - 1];
                for (int j = 0; j <= (valstr.Length - 2); j++)
                {
                    valores[j] = int.Parse(valstr[j]);
                }

                if (valores[0].ToString() == "-1")
                {
                    plantas = from pp in planta
                              where pp.CveCiudad == DatosUsuario.Ciudad
                              orderby pp.Planta
                              select new { pp.Planta, pp.IDClaveUnidad };
                }
                else
                {
                    plantas = from pp in planta
                              where pp.CveCiudad == DatosUsuario.Ciudad
                              && valores.Contains(pp.IdPlanta)
                              orderby pp.Planta
                              select new { pp.Planta, pp.IDClaveUnidad };
                }
            }

            List<ConsultaUnidad> UnidadesOcupadas = new List<ConsultaUnidad>();

            string dia = "";
            string _hora = "";
            string _minutos = "";
            string _horaminutos = "";
            string _plantaanterior = "";
            string _nuevaplanta = "";
            StringBuilder _html = new StringBuilder();

            Response.Write("<tr>");
            Response.Write("<td width=120 class='tdgris'>Planta Origen</td>");
            Response.Write("<td width=120 class='tdgris'>Unidad</td>");
            for (int i = int.Parse(HoraInicio.Substring(0, 2)); i <= int.Parse(HoraFin.Substring(0, 2)); i++)
            {
                _hora = i.ToString();
                if (_hora.Length == 1)
                { _hora = "0" + _hora; }

                for (int ii = 0; ii <= 50; ii = ii + 10)
                {
                    _html.Clear();
                    _minutos = ii.ToString();
                    if (_minutos.Length == 1) { _minutos = "0" + _minutos; }
                    _horaminutos = _hora + _minutos;
                    _html.Append("<td class='tdgris' id=" + _horaminutos + ">");
                    _html.Append(_hora + ":" + _minutos);
                    _html.Append("</td>");
                    Response.Write(_html);
                }
            }
            Response.Write("</tr>");

            au = new AgenteUnidades();
            UnidadesOcupadas = new List<ConsultaUnidad>();
            dia = Request.QueryString["Fecha"];
            UnidadesOcupadas = au.ObtenerBombasOcupadas(DatosUsuario.Ciudad, DateTime.Parse(dia));
            ConsultaUnidad Entidad = new ConsultaUnidad();

            foreach (var p in plantas)
            {
                var _unidades = from _unidad in UnidadesOcupadas
                                where _unidad.Planta == p.Planta && _unidad.IDClaveUnidad == p.IDClaveUnidad
                                select new { _unidad.IDClaveUnidad, _unidad.Planta, _unidad.fechapedido };

                int cuantos = _unidades.Count();
                int celdaocupada = 0;


                Response.Write("<tr>");
                if (_plantaanterior != p.Planta)
                {
                    _nuevaplanta = p.Planta;
                    _plantaanterior = _nuevaplanta;
                    Response.Write("<td width='120' class='tdgris'>" + p.Planta + "</td>");
                }
                else
                {
                    Response.Write("<td width='120' class='tdgris'></td>");
                }


                Response.Write("<td width='120' class='tdgris'>" + p.IDClaveUnidad + "</td>");

                for (int i = int.Parse(HoraInicio.Substring(0, 2)); i <= int.Parse(HoraFin.Substring(0, 2)); i++)
                {
                    _hora = i.ToString();
                    if (_hora.Length == 1)
                    { _hora = "0" + _hora; }

                    for (int ii = 0; ii <= 50; ii = ii + 10)
                    {
                        _html.Clear();
                        _minutos = ii.ToString();
                        if (_minutos.Length == 1) { _minutos = "0" + _minutos; }
                        _horaminutos = _hora + _minutos;

                        if (cuantos > 0)
                        {
                            var _unidades_ = from _unidad in UnidadesOcupadas
                                             where _unidad.Planta == p.Planta && _unidad.IDClaveUnidad == p.IDClaveUnidad && _unidad.horaminutos_inicio.Replace(":", "") == _horaminutos
                                             select new
                                             {
                                                 _unidad.CveCiudad,
                                                 _unidad.IDClaveUnidad,
                                                 _unidad.IDUnidad,
                                                 _unidad.IdPlanta,
                                                 _unidad.Planta,
                                                 _unidad.fechapedido,
                                                 _unidad.horaminutos_fin,
                                                 _unidad.horaminutos_inicio,
                                                 _unidad.IDPedido,
                                                 _unidad.CveCliente,
                                                 _unidad.NombreCliente,
                                                 _unidad.CveObra,
                                                 _unidad.NombreObra,
                                                 _unidad.CveProducto,
                                                 _unidad.CveAlternaProducto,
                                                 _unidad.NombreProducto,
                                                 _unidad.Estatus,
                                                 _unidad.numviaje,
                                                 _unidad.bloques,
                                                 _unidad.carga
                                             };

                            celdaocupada = _unidades_.Count();

                            if (celdaocupada > 0)
                            {
                                Entidad = new ConsultaUnidad();
                                foreach (var u in _unidades_)
                                {
                                    Entidad.CveCiudad = u.CveCiudad;
                                    Entidad.IDClaveUnidad = u.IDClaveUnidad;
                                    Entidad.IDUnidad = u.IDUnidad;
                                    Entidad.IdPlanta = u.IdPlanta;
                                    Entidad.Planta = u.Planta;
                                    Entidad.fechapedido = u.fechapedido;
                                    Entidad.horaminutos_fin = u.horaminutos_fin;
                                    Entidad.horaminutos_inicio = u.horaminutos_inicio;
                                    Entidad.IDPedido = u.IDPedido;
                                    Entidad.CveCliente = u.CveCliente;
                                    Entidad.NombreCliente = u.NombreCliente;
                                    Entidad.CveObra = u.CveObra;
                                    Entidad.NombreObra = u.NombreObra;
                                    Entidad.CveProducto = u.CveProducto;
                                    Entidad.CveAlternaProducto = u.CveAlternaProducto;
                                    Entidad.NombreProducto = u.NombreProducto;
                                    Entidad.Estatus = u.Estatus;
                                    Entidad.numviaje = u.numviaje;
                                    Entidad.bloques = u.bloques;
                                    Entidad.carga = u.carga;

                                }

                                switch (Entidad.Estatus)
                                {
                                    case "Despachado":
                                        _html.Append("<td id=" + _horaminutos + " class='vdespachado' colspan='" + Entidad.bloques.ToString() + "'><a href='#'   STYLE='TEXT-DECORATION: NONE;color:Black;' title='Cliente:");
                                        break;

                                    case "Cancelado":
                                        _html.Append("<td id=" + _horaminutos + " class='vcancelado' colspan='" + Entidad.bloques.ToString() + "'><a href='#'   STYLE='TEXT-DECORATION: NONE;color:Black;' title='Cliente:");
                                        break;

                                    case "Programado":
                                        _html.Append("<td id=" + _horaminutos + " class='vprogramado' colspan='" + Entidad.bloques.ToString() + "'><a href='#'  STYLE='TEXT-DECORATION: NONE;color:Black;' title='Cliente:");
                                        break;

                                    case "Entregado":
                                        _html.Append("<td id=" + _horaminutos + " class='vcerrado' colspan='" + Entidad.bloques.ToString() + "'><a href='#'   STYLE='TEXT-DECORATION: NONE;color:Black;' title='Cliente:");
                                        break;

                                    default:
                                        _html.Append("<td id=" + _horaminutos + " class='vprogramado' colspan='" + Entidad.bloques.ToString() + "'><a href='#'  STYLE='TEXT-DECORATION: NONE;color:Black;' title='Cliente:");
                                        break;
                                }


                                if (Entidad.bloques > 1)
                                {
                                    _html.Append(
                                                    Entidad.CveCliente.ToString()
                                                   + " - " + Entidad.NombreCliente
                                                   + " Carga: " + Entidad.carga.ToString() + " m3"
                                                   + " Producto: " + Entidad.CveAlternaProducto
                                                   + " - " + Entidad.NombreProducto
                                                   + "'>"
                                                   + "Viaje : " + Entidad.numviaje.ToString() + " Pedido: "
                                                   + Entidad.IDPedido.ToString()
                                                   + " Obra:" + Entidad.CveObra.ToString()
                                                   + " - " + Entidad.NombreObra
                                                   + "</a>");
                                }
                                else
                                {
                                    _html.Append(
                                                    Entidad.CveCliente.ToString()
                                                   + " Unidad :" + Entidad.IDClaveUnidad
                                                   + "'>"
                                                   + "Viaje : " + Entidad.numviaje.ToString() + " Pedido: "
                                                   + Entidad.IDPedido.ToString()
                                                   + " Obra:" + Entidad.CveObra.ToString()
                                                   + "</a>");
                                }

                                saltos = Entidad.bloques;
                            }
                            else
                            {
                                saltos = saltos - 1;
                                if (saltos < 1)
                                {
                                    _html.Append("<td id=" + _horaminutos + " class='tdverde'>");
                                }

                            }

                        }
                        else
                        {
                            saltos = saltos - 1;
                            if (saltos < 1)
                            {
                                _html.Append("<td id=" + _horaminutos + " class='tdverde'>");
                            }
                        }

                        _html.Append("");
                        _html.Append("</td>");
                        Response.Write(_html);
                    }
                }

                Response.Write("</tr>");
            } 
        
        %>
    </table>
    </form>
</body>
</html>
