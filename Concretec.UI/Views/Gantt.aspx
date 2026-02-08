<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gantt.aspx.cs" Inherits="Views_Gantt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" type="text/css" href="../scripts/jquery-ui-1.8.4.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/reset.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/jquery.ganttView.css" />
    <style type="text/css">
        body
        {
            font-family: tahoma, verdana, helvetica;
            font-size: 0.8em;
            padding: 10px;
        }
    </style>
    <title>jQuery Gantt</title>
</head>
<body>
    <div id="ganttChart">
    </div>
    <br />
    <br />
    <div id="eventMessage">
    </div>
    <script type="text/javascript" src="../scripts/jquery-1.4.2.js"></script>
    <script type="text/javascript" src="../scripts/date.js"></script>
    <script type="text/javascript" src="../scripts/jquery-ui-1.8.4.js"></script>
    <script type="text/javascript" src="../scripts/jquery.ganttView.js"></script>
    <script type="text/javascript" src="../scripts/data.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#ganttChart").ganttView({
                data: ganttData,
                slideWidth: 900,
                behavior: {
                    onClick: function (data) {
                        var msg = "You clicked on an event: { start: " + data.start.toString("M/d/yyyy") + ", end: " + data.end.toString("M/d/yyyy") + " }";
                        $("#eventMessage").text(msg);
                    },
                    onResize: function (data) {
                        var msg = "You resized an event: { start: " + data.start.toString("M/d/yyyy") + ", end: " + data.end.toString("M/d/yyyy") + " }";
                        $("#eventMessage").text(msg);
                    },
                    onDrag: function (data) {
                        var msg = "You dragged an event: { start: " + data.start.toString("M/d/yyyy") + ", end: " + data.end.toString("M/d/yyyy") + " }";
                        $("#eventMessage").text(msg);
                    }
                }
            });

            // $("#ganttChart").ganttView("setSlideWidth", 600);
        });
    </script>
</body>
</html>
