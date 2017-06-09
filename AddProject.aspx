<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddProject.aspx.cs" Inherits="AddProject" %>

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
        <h1>Adăugare proiect</h1>
     <asp:TextBox ID="TextBoxName" Placeholder="DENUMIRE PROIECT" runat="server" CssClass="Add_TextBox" ></asp:TextBox>
         <asp:RequiredFieldValidator id="RequiredFieldValidatorName" runat="server"
          ControlToValidate="TextBoxName"
          ErrorMessage="Obligatoriu!"
          ForeColor="Red">
        </asp:RequiredFieldValidator>
        <p>
        
        <asp:DropDownList ID="DropDownList1" placeholder="Rol" runat="server" CssClass="Dropdown">
        </asp:DropDownList>
        </p>
        <asp:Button ID="ButtonSave" runat="server" Text="Salvează" OnClick="ButtonSave_Click" CssClass="Main_btn" />
    </form>
         </div>
        </div>
</body>
</html>
