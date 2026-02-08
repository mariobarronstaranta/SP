<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Concretos Tecnicos de Mexico - Sistema de Administracion de Pedidos</title>

    <!-- Stylesheets -->
    <link rel="stylesheet" href="Shared/css/style.css">

    <!-- Optimize for mobile devices -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>

    <!-- TOP BAR -->
    <div id="top-bar">

        <div class="page-full-width">
        </div>
        <!-- end full-width -->

    </div>
    <!-- end top-bar -->



    <!-- HEADER -->
    <div id="header">

        <div class="page-full-width cf">

            <div id="login-intro" class="fl">

                <h1>Sistema de Administracion de Pedidos</h1>
                <h5>Introduzca por favor sus credenciales</h5>

            </div>
            <!-- login-intro -->

            <!-- Change this image to your own company's logo -->
            <!-- The logo will automatically be resized to 39px height. -->
            <a href="#" id="company-branding" class="fr">
                <img src="Imagenes/ConcretecLogo.jpg" alt="Blue Hosting" /></a>

        </div>
        <!-- end full-width -->

    </div>
    <!-- end header -->



    <!-- MAIN CONTENT -->
    <div id="content">

        <form id="loginform" runat="server">
<%--            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
                </Scripts>
            </telerik:RadScriptManager>--%>

            <fieldset>

                <p>
                    <b>
                        <label for="login-username">Usuario</label></b>
                    <asp:TextBox ID="txtUserName" runat="server" EnableViewState="False" class="round full-width-input"></asp:TextBox>
                </p>

                <p>
                    <b>
                        <label for="login-password">Contraseña</label></b>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" EnableViewState="False" class="round full-width-input"></asp:TextBox>
                </p>

                <br />


                <p align="center">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/MetroImages/BotonRegistro.png" OnClick="ImageButton1_Click" Width="200px" /></p>
            </fieldset>

            <br />
            <asp:Literal ID="lblmsg" runat="server" Visible="false"></asp:Literal>


        </form>

    </div>
    <!-- end content -->



    <!-- FOOTER -->
    <div id="footer">
    </div>
    <!-- end footer -->

</body>
</html>