<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HRM.EmployeePortal.Login" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta charset="utf-8">

    <title></title>
    	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes"> 
    
<link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="Content/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />

<link href="Content/font-awesome.css" rel="stylesheet">
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600" rel="stylesheet">
    
<link href="Content/style.css" rel="stylesheet" type="text/css">
<link href="Content/signin.css" rel="stylesheet" type="text/css">
<link href="Styles/signin.css" rel="stylesheet" type="text/css">
    


</head>
<body>
    <form id="form1" runat="server">
  <!-- /navbar -->
     <div class="navbar">
         <a>

                <span class="logo-lg">
                   <img src="Images/logo.png" style="height: 39px;"/> 
                   <span >  <img src="Images/crm2.png" style="height: 50px"/> </span>
                    

                    </span>
        </a>
 
</div>



<div class="account-container">
	
	<div class="content clearfix">
		
		<form action="#" method="post">
		
			<h1>&nbsp;Login Details</h1>		
			
			<div class="login-fields">
				
				<p>
                    <asp:Label ID="lbMessage" runat="server" Text="Please provide your details"></asp:Label></p>
				
				<div class="field">
					<label for="username">Username</label>
                    <asp:TextBox ID="txtUserName" runat="server" placeholder="Username" CssClass="login username-field" AutoPostBack="true"   OnTextChanged="txtUserName_TextChanged" required="" ></asp:TextBox>
					<%--<input type="text" id="username" name="username" value="" placeholder="Username" class="login username-field" />--%>
				</div> <!-- /field -->
				
				<div class="field">
					<label for="password">Password:</label>
                    <asp:TextBox ID="txtpass" runat="server" placeholder="Password" CssClass="login password-field" TextMode="Password" required=""></asp:TextBox>
			<%--		<input type="password" id="password" name="password" value="" placeholder="Password" class="login password-field"/>--%>
				</div> <!-- /password -->
				<div class="field">
					<label for="dxDdType">Location:</label>
                     <dx:ASPxComboBox ID="dxdDCompany"  CssClass="companyCmb"  runat="server"  DropDownStyle="DropDownList" 
                          ValueField="LocationId"  Theme="Default" TextFormatString="{0}" NullText=" <<Select Location>> " >
                                <Columns>  
                                     <dx:ListBoxColumn FieldName="LocationName"   Width="300px"  />
                                </Columns>
                          <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right">
                               <RequiredField IsRequired="true" />
                          </ValidationSettings>
                               <InvalidStyle BackColor="LightPink" />
                     </dx:ASPxComboBox>
                     
				</div>
                 <div class="col-xs-12 txt-forgot-password">
                       
                    </div>
			</div> <!-- /login-fields -->
			
			<div class="login-actions">
				
			
				<span class="login-checkbox">
					<input id="Field" name="Field" type="checkbox" class="field login-checkbox" value="1" tabindex="4" />
					<label class="choice" for="Field">Keep me Log In</label>
				</span>
				<div style="text-align: right">
                    	<asp:Button ID="btSignIn" runat="server" Text="Login" CssClass="btn btn-block btn-primary btn-large" OnClick="btSignIn_Click" />


				</div>				
			
				
			</div> <!-- .actions -->
			
			
			
		</form>
		
	</div> <!-- /content -->
	
</div> <!-- /account-container -->



<div class="login-extra">
<a href="Register.aspx">Registor</a>|<a href="#">Lost Password</a>
</div> <!-- /login-extra -->


<%--<script src="js/jquery-1.7.2.min.js"></script>--%>
        <script src="Scripts/jquery-1.7.2.min.js"></script>
<script src="Scripts/bootstrap.js"></script>

<script src="Scripts/signin.js"></script>


    </form>
</body>
</html>