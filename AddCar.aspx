﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCar.aspx.cs" Inherits="AddCar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <link href="Theme/Style.css" rel="stylesheet" type="text/css" />
    <div class="Base">
     <div class="Login_Div">
    <form id="form1" runat="server" class="Add_Form">
    <h1>Adăugare mașină</h1>
    <asp:TextBox ID="TextBoxCar" placeholder="Număr de înmatriculare"  runat="server"  CssClass="AddActivity_TextBox"></asp:TextBox>
    <p>
    <asp:Button ID="ButtonSave" runat="server"  Text="Salvează" Width="124px"  OnClick="ButtonSave_Click" CssClass="Main_btn"/>
     </p>
    
    </form>
         </div>
        </div>
</body>
</html>