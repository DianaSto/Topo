<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <link href="Theme/Style.css" rel="stylesheet" type="text/css" />
    <div class="Base">
     <div class="Login_Div">  
         
    <form id="form1" runat="server" class="Login_Form">
       <h1>Logare</h1>
       <br/> <br/>
    
        <asp:TextBox ID="TextBoxUsername" Placeholder="USERNAME" runat="server"  CssClass="Login_username" OnTextChanged="TextBoxUsername_TextChanged"></asp:TextBox>
        <p>
            <asp:TextBox ID="TextBoxPassword" TextMode="Password" Placeholder="PASSWORD" runat="server"  CssClass="Login_password" OnTextChanged="TextBoxPassword_TextChanged"></asp:TextBox>
        </p>
        <asp:Button ID="ButtonLogin" runat="server"  Height="30px" Text="LOGARE" Width="90px"  CssClass="Login_btn" OnClick="ButtonLogin_Click"/>
      
        <br/><br/>
        <p>
            <asp:Label ID="LabelWrong" runat="server" Text="Wrong username or password!" Visible="False" CssClass="Login_lbl"></asp:Label>
        </p>
    </form>
    </div>
    </div>
   
</body>
</html>
