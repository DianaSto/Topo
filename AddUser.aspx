<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <link href="Theme/Style.css" rel="stylesheet" type="text/css" />
    <div class="Base">
     <div class="Login_Div">
    <form id="form1" runat="server" class="AddUser_Form">
    <h1>Adăugare utilizator</h1>
       
        <asp:TextBox ID="TextBoxFirstName" placeholder="Prenume" runat="server" CssClass="Add_TextBox"></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidatorFirstName" runat="server"
          ControlToValidate="TextBoxFirstName"
          ErrorMessage="Obligatoriu!"
          ForeColor="Red">
        </asp:RequiredFieldValidator>
        <p>
            <asp:TextBox ID="TextBoxLastName" placeholder="Nume" runat="server" CssClass="Add_TextBox"></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidatorLastName" runat="server"
            ControlToValidate ="TextBoxLastName"
            ErrorMessage="Obligatoriu!"
            ForeColor="Red">
        </asp:RequiredFieldValidator>
        </p>
        <asp:TextBox ID="TextBoxEmail" placeholder="Email" runat="server" CssClass="Add_TextBox"></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidatorEmail" runat="server"
          ControlToValidate="TextBoxEmail"
          ErrorMessage="Obligatoriu!"
          ForeColor="Red">
        </asp:RequiredFieldValidator>
        <p>
            <asp:TextBox ID="TextBoxUsername" placeholder="Username" runat="server" CssClass="Add_TextBox" ></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidatorUsername" runat="server"
            ControlToValidate="TextBoxUsername"
            ErrorMessage="Obligatoriu!"
            ForeColor="Red">
        </asp:RequiredFieldValidator>
            <asp:Label ID="LabelUsernameExists" runat="server" Text="Username already exists!" Visible="False"></asp:Label>
        </p>
         <p>
       
        <p>
        <asp:TextBox ID="TextBoxPassword" placeholder="Parolă" TextMode="Password" runat="server" CssClass="Add_TextBox"></asp:TextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidatorPassword" runat="server"
          ControlToValidate="TextBoxPassword"
          ErrorMessage="Obligatoriu!"
          ForeColor="Red">
        </asp:RequiredFieldValidator>
        <p>
            <asp:TextBox ID="TextBoxConfirmPassword" placeholder="Confirmă parola" TextMode="Password" runat="server" CssClass="Add_TextBox" ></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidatorConfirmPassword" runat="server"
          ControlToValidate="TextBoxConfirmPassword"
          ErrorMessage="Obligatoriu!"
          ForeColor="Red">
        </asp:RequiredFieldValidator>
            <asp:Label ID="LabelMismatch" runat="server" Text="Password mismatch!" Visible="False" ></asp:Label>
            <br/>
        </p>
            <br/>
        <asp:DropDownList ID="DropDownList1" CssClass="Dropdown" runat="server" >
        </asp:DropDownList>
        <p>
            <asp:Button ID="ButtonRegister" runat="server"  Text="SALVEAZĂ" Width="124px"  OnClick="ButtonRegister_Click" CssClass="Main_btn"/>
           
        </p>
    </form>
      </div>
        </div>
</body>
</html>
