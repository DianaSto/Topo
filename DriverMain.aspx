<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DriverMain.aspx.cs" Inherits="DriverMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/Chart.js/2.6.0/Chart.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
    <link href="Theme/Style.css" rel="stylesheet" type="text/css" />
    <div class="Base">
    <form id="form1" runat="server" class="Main_Div">
    <div>
         <h1>
         <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal">
            <Items>
                <asp:MenuItem  Selected="True" Text="Pontează" Value="0"></asp:MenuItem>
                <asp:MenuItem  Text="Pontaje" Value="1"></asp:MenuItem>
                <asp:MenuItem  Text="Calendar" Value="2"></asp:MenuItem>
                <asp:MenuItem  Text="Rapoarte" Value="3"></asp:MenuItem>
                <asp:MenuItem  Text="Schimbă parola" Value="4"></asp:MenuItem>
                 
            </Items>
             <staticmenuitemstyle BorderWidth="10px" BorderColor="#6189df"  forecolor="Black" /> 
        </asp:Menu>
           </h1>   
      
    
         
           
        <div runat="server" id="ScrollList" class="Main_Menu_div">
        <asp:MultiView ID="multiTabs" runat="server" ActiveViewIndex="0" >
                
              
         <asp:View ID="ViewPontaje" runat="server" >

          <p>
        <asp:Label ID="LabelCarNumber" runat="server" Text="Numărul de înmatriculare al mașinii" CssClass="Label"></asp:Label>
        <asp:DropDownList ID="DropDownList1"  runat="server" CssClass="Dropdown">
        </asp:DropDownList>
        <p>
        <asp:Label ID="LabelKm" runat="server" Text="Kilometri parcurși" CssClass="Label"></asp:Label>
        <asp:TextBox ID="TextBoxKm" runat="server" CssClass="TextBox"></asp:TextBox>
             <asp:Label ID="LabelMissingKm" runat="server" Text="Vă rugăm precizați numărul de kilometri parcurși" ForeColor="#FF3300" Visible="False"></asp:Label>
        </p>
        <p>
        <asp:Label ID="LabelDate" runat="server" Text="Data" CssClass="Label"></asp:Label>
        <asp:TextBox ID="TextBoxData" runat="server" CssClass="TextBox"></asp:TextBox>       
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False" CssClass="Calendar">
                 <TitleStyle BackColor="#6189df" ForeColor="White">
         </TitleStyle>
             <TodayDayStyle BackColor="#6189df" ForeColor="White">
            </TodayDayStyle>
             
        </asp:Calendar>
           
        <asp:Button ID="ButtonSelectDate" runat="server" Text="Selectare dată" OnClick="ButtonSelectDate_Click" CssClass="Driver_log_work_btn"/>
            <asp:Label ID="LabelMissingDate" runat="server" Text="Vă rugăm selectați data" ForeColor="#FF3300" Visible="False"></asp:Label>
         </p>
        <p>
        <asp:Label ID="LabelHours" runat="server" Text="Ore deplasare" CssClass="Label"></asp:Label>
        <asp:TextBox ID="TextBoxHours" runat="server" CssClass="TextBox"></asp:TextBox>
            <asp:Label ID="LabelMissingHours" runat="server" Text="Vă rugăm să precizați câte ore ați lucrat" ForeColor="#FF3300" Visible="False"></asp:Label>
            </p>
        <p>
         <asp:Label ID="LabelObservations" runat="server" Text="Observații" CssClass="Label"></asp:Label>
        <asp:TextBox ID="TextBoxObservations" runat="server" CssClass="TextBox"></asp:TextBox>
            </p>
         <p>
         <asp:Label ID="LabelPassenger1" runat="server" Text="Pasager 1" CssClass="Label"></asp:Label>
        <asp:DropDownList ID="DropDownListPass1" runat="server" CssClass="Dropdown">
        </asp:DropDownList>
            </p>
               <p>
         <asp:Label ID="LabelPassenger2" runat="server" Text="Pasager 2" CssClass="Label"></asp:Label>
       <asp:DropDownList ID="DropDownListPass2" runat="server" CssClass="Dropdown">
        </asp:DropDownList>
            </p>
              <p>
         <asp:Label ID="LabelPassenger3" runat="server" Text="Pasager 3" CssClass="Label"></asp:Label>
        <asp:DropDownList ID="DropDownListPass3" runat="server" CssClass="Dropdown">
        </asp:DropDownList>
            </p>
              <p>
         <asp:Label ID="LabelPassenger4" runat="server" Text="Pasager 4" CssClass="Label"></asp:Label>
       <asp:DropDownList ID="DropDownListPass4" runat="server" CssClass="Dropdown">
        </asp:DropDownList>
            </p>

          <p>
        <asp:Label ID="LabelProjectCategory"  runat="server"   Text="Categorie proiect" CssClass="Label"></asp:Label>
        <asp:DropDownList ID="DropDownList2" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" runat="server" CssClass="Dropdown">
        </asp:DropDownList>
        <p>

            
          <p>
        <asp:Label ID="LabelProject" AutoPostBack="True" runat="server" Text="Proiect" CssClass="Label"></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="Dropdown">
        </asp:DropDownList>
                  
        <p>
              
        <p>
             <asp:Button ID="Button1" runat="server" Text="Salvează" OnClick="ButtonSaveLog" CssClass="Driver_log_work_btn" />
        </p>

           
        
        
        
        
        </asp:View>

        <asp:View ID="ViewPontajeleMele" runat="server">
            

               <asp:GridView ID="GridViewPontajeleMele" runat="server" CssClass="grid" Width="1200px" PageSize="10" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AllowPaging="true" DataKeyNames="id" DataSourceID="SqlDataSourcePontajeleMele">
                  
                   
               <EmptyDataRowStyle CssClass="EmptyData" />
                <EmptyDataTemplate>

                    <div>
                        No Data Available
                    </div>

                    <script>
                        $(".EmptyData").parents("table").css("border-width", "0px").prop("border", "0");
                    </script>

               </EmptyDataTemplate>


                    <Columns>

                      <asp:BoundField DataField="date" HeaderText="Data" SortExpression="date" DataFormatString="{0:dd-M-yyyy}" ItemStyle-Width="15%"/>
                      
                      <asp:TemplateField ItemStyle-CssClass="TemplateFieldOneColumn" HeaderText="Proiect" ItemStyle-Width="15%">

                         <ItemTemplate>
                             <asp:Label runat="server" Text='<% #GetLabelTextProject(Eval("id_project")) %>' />
                         </ItemTemplate>

                       </asp:TemplateField>

                       <asp:BoundField DataField="vehicle_number" HeaderText="Mașina" SortExpression="vehicle_number" ItemStyle-Width="15%"/>
                        <asp:BoundField DataField="km" HeaderText="Km parcurși" SortExpression="km" ItemStyle-Width="15%"/>
                       <asp:BoundField DataField="hours" HeaderText="Ore" SortExpression="hours" ItemStyle-Width="10%"/>
                       <asp:BoundField DataField="observations" HeaderText="Observații" SortExpression="observations" ItemStyle-Width="30%"/>
                         
                      <asp:TemplateField ItemStyle-CssClass="TemplateFieldOneColumn" HeaderText="Pasager 1" ItemStyle-Width="15%">

                         <ItemTemplate>
                             <asp:Label runat="server" Text='<% #GetLabelTextUser(Eval("id_pass1")) %>' />
                         </ItemTemplate>

                       </asp:TemplateField>

                         <asp:TemplateField ItemStyle-CssClass="TemplateFieldOneColumn" HeaderText="Pasager 2" ItemStyle-Width="15%">

                         <ItemTemplate>
                             <asp:Label runat="server" Text='<% #GetLabelTextUser(Eval("id_pass2")) %>' />
                         </ItemTemplate>

                       </asp:TemplateField>
                      
                        <asp:TemplateField ItemStyle-CssClass="TemplateFieldOneColumn" HeaderText="Pasager 3" ItemStyle-Width="15%">

                         <ItemTemplate>
                             <asp:Label runat="server" Text='<% #GetLabelTextUser(Eval("id_pass3")) %>' />
                         </ItemTemplate>

                       </asp:TemplateField>

                         <asp:TemplateField ItemStyle-CssClass="TemplateFieldOneColumn" HeaderText="Pasager 4" ItemStyle-Width="15%">

                         <ItemTemplate>
                             <asp:Label runat="server" Text='<% #GetLabelTextUser(Eval("id_pass4")) %>' />
                         </ItemTemplate>

                       </asp:TemplateField>

                      
                      
                   </Columns>

               </asp:GridView>

              

               
              

               <asp:SqlDataSource ID="SqlDataSourcePontajeleMele" runat="server" ConnectionString="<%$ ConnectionStrings:PontajeConnectionString %>" SelectCommand="SELECT * FROM [Log_driver] "
                  DeleteCommand="delete from [Log_driver] where [id]=@id" >

               </asp:SqlDataSource>
              </asp:View>

            <asp:View ID="ViewCalendar" runat="server">
               
                 <asp:Calendar ID="CalendarEvents"  OnDayRender="AttachEvents" runat="server" Width="100%" Height="100%" >
                    
         
        <SelectorStyle BackColor="#FFCC66"></SelectorStyle>
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC"></NextPrevStyle>
        <DayHeaderStyle Height="1px" BackColor="#e5e5e9" Font-Names="Calibri"></DayHeaderStyle>
        <SelectedDayStyle Font-Bold="True" BackColor="#6189df"></SelectedDayStyle>
        <TitleStyle Font-Size="16pt" Font-Bold="True" ForeColor="White" BackColor="#6189df" Font-Names="Calibri"></TitleStyle>
        <OtherMonthDayStyle ForeColor="#e5e5e9"></OtherMonthDayStyle>
        <TodayDayStyle BackColor="#6189df" ForeColor="White"> </TodayDayStyle>
        <DayStyle BorderStyle="Solid" BorderColor="#e5e5e9"></DayStyle>
           
                    

                </asp:Calendar>   
            
            </asp:View>

            <asp:View ID="ViewReports" runat="server">

                  <canvas id="projects-graph" width="800" height="500"></canvas>

                 
    <script>

      

        $(function () {
            $.getJSON("/api/driver/<%= id_user %>", function (result) {
                var labels = [], data = [], colors = [];


                var randomColorGenerator = function () {
                    return '#' + (Math.random().toString(16) + '0000000').slice(2, 8);
                };

                for (var i = 0; i < result.length; i = i + 2) {

                    labels.push(result[i]);
                    data.push(result[i + 1]);
                    colors.push(randomColorGenerator());

                }


                var chartData = {
                    labels: labels,
                    datasets: [
                      {
                          label: 'Ore deplasări per proiect',
                          backgroundColor: colors,
                          data: data
                      }
                    ]
                };
                var opt = {
                    events: false,
                    tooltips: {
                        enabled: false
                    },
                    hover: {
                        animationDuration: 0
                    },
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero:true
                            }
                        }]
                    },
                    animation: {
                        duration: 1,
                        onComplete: function () {
                            var chartInstance = this.chart,
                                ctx = chartInstance.ctx;
                            ctx.font = Chart.helpers.fontString(Chart.defaults.global.defaultFontSize, Chart.defaults.global.defaultFontStyle, Chart.defaults.global.defaultFontFamily);
                            ctx.textAlign = 'center';
                            ctx.textBaseline = 'bottom';

                            this.data.datasets.forEach(function (dataset, i) {
                                var meta = chartInstance.controller.getDatasetMeta(i);
                                meta.data.forEach(function (bar, index) {
                                    var data = dataset.data[index];
                                    ctx.fillText(data, bar._model.x, bar._model.y - 5);
                                });
                            });
                        }
                    }
                };
                var ctx = document.getElementById("projects-graph"),
                    myLineChart = new Chart(ctx, {
                        type: 'bar',
                        data: chartData,
                        options: opt
                    })

            });

        })

        
    </script>
                
            </asp:View>

            <asp:View ID="ViewChangePassword" runat="server" >
               <asp:Label ID="LabelWrongPassword" runat="server" Text="Parolă greșită!" Visible="False"></asp:Label>
        <p>
            <asp:TextBox ID="TextBoxNewPassword" placeholder="PAROLĂ NOUĂ" TextMode="Password" CssClass="TextBox_ChangePassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidatorPassword" runat="server"
          ControlToValidate="TextBoxNewPassword"
          ErrorMessage="Obligatoriu!"
          ForeColor="Red">
                </asp:RequiredFieldValidator>
            
        </p>
                     <p>
            <asp:TextBox ID="TextBoxConfirmNewPassword" placeholder="CONFIRMĂ PAROLA" TextMode="Password" CssClass="TextBox_ChangePassword"  runat="server"  ></asp:TextBox>
            <asp:RequiredFieldValidator id="RequiredFieldValidatorConfirmPassword" runat="server"
          ControlToValidate="TextBoxConfirmNewPassword"
          ErrorMessage="Obligatoriu!"
          ForeColor="Red">
                </asp:RequiredFieldValidator>
            <br/>
                         <asp:Label ID="LabelMismatch" runat="server" Text="Cele două câmpuri nu coincid!" Visible="False" CssClass="Register_lbl"></asp:Label>
                         </p>
                         <asp:Button ID="ButtonSave" runat="server" Text="Salvează" OnClick="ButtonSave_Click" CssClass="Main_btn"/>
        

                 </asp:View>

        </asp:MultiView>
                
            
      
    </div>
        
           <div class="Main_footer" runat="server">
            
            <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Delogare" CausesValidation="false" cssClass="Main_logout_btn"/>
            </div>
    </div>
    
    </form>
    </div>
</body>
</html>
