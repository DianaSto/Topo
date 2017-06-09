<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="AddCategory" %>

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
        <h1>Adăugare categorie</h1>
      <br/>
     <asp:TextBox ID="TextBoxCategory" Placeholder="DENUMIRE CATEGORIE" runat="server" CssClass="Add_TextBox"></asp:TextBox>
         <asp:RequiredFieldValidator id="RequiredFieldValidatorCategory" runat="server"
          ControlToValidate="TextBoxCategory"
          ErrorMessage="Obligatoriu!"
          ForeColor="Red">
        </asp:RequiredFieldValidator>
        <p>
        <asp:Button ID="ButtonSave" runat="server" Text="Salvează" OnClick="ButtonSave_Click" CssClass="Main_btn"/>
        </p>
   
    </form>
         </div>
        </div>
</body>
</html>
