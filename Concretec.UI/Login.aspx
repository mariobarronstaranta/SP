<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>


<html lang="en">
<head>
	<meta charset="utf-8">
	<title>SimpleAdmin - Login to CMS</title>
	
	<!-- Stylesheets -->
	<link href='http://fonts.googleapis.com/css?family=Droid+Sans:400,700' rel='stylesheet'>
	<link rel="stylesheet" href="Shared/css/style.css">

	<!-- Optimize for mobile devices -->
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>  
</head>
<body>

	<!-- TOP BAR -->
	<div id="top-bar">
		
		<div class="page-full-width">
		
			

		</div> <!-- end full-width -->	
	
	</div> <!-- end top-bar -->
	
	
	
	<!-- HEADER -->
	<div id="header">
		
		<div class="page-full-width cf">
	
			<div id="login-intro" class="fl">
			
				<h1>MIX - MANAGER</h1>
				<h5>Introduzca por favor sus credenciales</h5>
			
			</div> <!-- login-intro -->
			
			<!-- Change this image to your own company's logo -->
			<!-- The logo will automatically be resized to 39px height. -->
			<a href="#" id="company-branding" class="fr"><img src="MetroImages/SmallLogo.png" alt="Blue Hosting" /></a>
			
		</div> <!-- end full-width -->	

	</div> <!-- end header -->
	
	
	
	<!-- MAIN CONTENT -->
	<div id="content">
	
		<form id="loginform" runat="server">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                    </asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                    </asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                    </asp:ScriptReference>
                </Scripts>
            </telerik:RadScriptManager>
		
			<fieldset>

				<p>
					<label for="login-username">Usuario</label>
                    <asp:TextBox  ID="txtUserName" runat="server" EnableViewState="False" class="round full-width-input"></asp:TextBox>
				</p>

				<p>
					<label for="login-password">Contraseña</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"  EnableViewState="False" class="round full-width-input"></asp:TextBox>
				</p>
				
				<p><a href="#">Recuperar Contraseña</a>.</p>

                <telerik:RadButton ID="RadButton1" runat="server" Font-Names="Segoe UI" Skin="MetroTouch" Text="Ingresar" Width="120px"></telerik:RadButton>

			</fieldset>

			<br/><div class="information-box round">En caso de no contar con sus credenciales favor de contactar a su administrador</div>

		</form>
		
	</div> <!-- end content -->
	
	
	
	<!-- FOOTER -->
	<div id="footer">

		
	
	</div> <!-- end footer -->

</body>
</html>