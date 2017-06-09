<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogWork.aspx.cs" Inherits="LogWork" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <link href="Theme/Style.css" rel="stylesheet" type="text/css" />
    <div class="Base">
     <div class="Login_Div">
    <form id="form1" runat="server" class="Log_Form">
    <h1>Pontare</h1>
        <p>
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="Dropdown">
        </asp:DropDownList>
        <p>
        <asp:TextBox ID="TextBoxQuantity" placeholder="CANTITATE" runat="server" CssClass="Log_TextBox"></asp:TextBox>
        </p>
        <p>
        <asp:TextBox ID="TextBoxData" placeholder="DATA" runat="server" CssClass="Log_TextBox"></asp:TextBox>       
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False" CssClass="Calendar">
             <TitleStyle BackColor="#6189df" ForeColor="White">
         </TitleStyle>
             <TodayDayStyle BackColor="#6189df" ForeColor="White">
            </TodayDayStyle>
             
        </asp:Calendar>
          
            
        <asp:Button ID="ButtonSelectDate" runat="server" Text="Selectare data" OnClick="ButtonSelectDate_Click" CssClass="Main_btn" />
            <asp:Label ID="LabelMissingDate" runat="server" Text="Vă rugăm selectați data" ForeColor="#FF3300" Visible="False"></asp:Label>

         </p>
        <p>
        <asp:TextBox ID="TextBoxHours" placeholder="ORE" runat="server" CssClass="Log_TextBox"></asp:TextBox>
            <asp:Label ID="LabelMissingHours" runat="server" Text="Vă rugăm să precizați câte ore ați lucrat" ForeColor="#FF3300" Visible="False"></asp:Label>
            </p>
        <p>
        <asp:TextBox ID="TextBoxObservations" PLACEHOLDER="OBSERVAȚII" runat="server" CssClass="Log_TextBox"></asp:TextBox>
            </p>
        <p>
             <asp:Button ID="ButtonSave" runat="server" Text="Salvează" OnClick="ButtonSave_Click" CssClass="Main_btn"/>
        </p>
    </form>
   
    </div>
        </div>
    
</body>
</html>
