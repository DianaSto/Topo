using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DriverMain : System.Web.UI.Page
{
    private Pontaje_firma_topografieEntities db = new Pontaje_firma_topografieEntities();
    private Dictionary<Log_driver, string> data = new Dictionary<Log_driver, string>();
    protected int id_user;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (DropDownList1.Items.Count == 0)
        {
            var car = (from c in db.Cars select c).ToList();
            foreach (var c in car)
            {
                ListItem element = new ListItem(c.number, c.id.ToString());
                DropDownList1.Items.Add(element);
            }
            DropDownList1.Items.Add(new ListItem("Mașină proprie", ""));
        }


        if (DropDownList2.Items.Count == 0)
        {
            var category = (from c in db.ProjectCategories select c).ToList();
            foreach (var c in category)
            {
                ListItem element = new ListItem(c.name, c.id.ToString());
                DropDownList2.Items.Add(element);
            }
            DropDownList2.DataBind();
        }
       if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
        {
            var category_selected = Int32.Parse(DropDownList2.SelectedItem.Value);
            if (DropDownList3.Items.Count == 0)
            {
            var project = (from p in db.Projects where p.id_category== category_selected select p).ToList();
            foreach (var p in project)
                {
                    ListItem element = new ListItem(p.name, p.id.ToString());
                    DropDownList3.Items.Add(element);
                }
            }
            DropDownList3.DataBind();

        }

        DropDownListPassengerInitialisation(DropDownListPass1);
        DropDownListPassengerInitialisation(DropDownListPass2);
        DropDownListPassengerInitialisation(DropDownListPass3);
        DropDownListPassengerInitialisation(DropDownListPass4);

        var name = Session["username"];
        id_user = (from user in db.Users where user.username == name.ToString() select user.id).FirstOrDefault();
        var data_logged_work = (from log in db.Log_driver where log.id_user == id_user select log).ToList();
        foreach (var dlw in data_logged_work)
        {
            var proj = (from project in db.Projects where project.id == dlw.id_project select project.name).FirstOrDefault();
             data.Add(dlw, proj);
        }
        SqlDataSourcePontajeleMele.SelectParameters.Clear();
        var usr = Session["id_user"].ToString();
        SqlDataSourcePontajeleMele.SelectParameters.Add("usr", usr);
        SqlDataSourcePontajeleMele.SelectCommand = "SELECT * FROM [Log_driver] where [id_user]=@usr order by [date] desc";
        SqlDataSourcePontajeleMele.DataBind();

    }

    protected void DropDownListPassengerInitialisation(DropDownList dl)
    {

        if (dl.Items.Count == 0)
        {
            dl.Items.Add(new ListItem("-", ""));
            var passenger = (from u in db.Users where u.id_role!=1 select u).OrderBy(p => p.last_name);
            foreach (var p in passenger)
            {
                string pass = p.last_name + " " + p.first_name + "(" + p.username + ")";
                ListItem element = new ListItem(pass, p.id.ToString());
                dl.Items.Add(element);
            }

        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList3.Items.Clear();
        var activity_type_selected = Int32.Parse(DropDownList2.SelectedItem.Value);
        var project = (from p in db.Projects where p.id_category == activity_type_selected select p).ToList();
        foreach (var p in project)
        {
            ListItem element = new ListItem(p.name, p.id.ToString());
            DropDownList3.Items.Add(element);
        }
    }
    private string GetHashedText(string inputData)
    {
        byte[] tmpSource;
        byte[] tmpData;
        tmpSource = ASCIIEncoding.ASCII.GetBytes(inputData);
        tmpData = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        return Convert.ToBase64String(tmpData);
    }

    protected void ButtonLogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }

    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id_project = 0;
        int.TryParse(e.CommandArgument as string, out id_project);
        Session["id_project"] = id_project;
        Response.Redirect("LogWork.aspx?id=" + Session["id_user"].ToString().Trim() + "&id_project=" + Session["id_project"].ToString().Trim());

    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        int index = Int32.Parse(e.Item.Value);
        multiTabs.ActiveViewIndex = index;
    }

    public string GetLabelTextUser(object dataItem)
    {

        int? val = dataItem as int?;
        var usr = (from user in db.Users where user.id == val select user).FirstOrDefault();
        if (usr != null)
        {
            string user_name = usr.last_name + " " + usr.first_name;
            return user_name;
        }
        else
        {
            return null;
        }
        
    }
    public string GetLabelTextProject(object dataItem)
    {

        int? val = dataItem as int?;
        string project_name = (from project in db.Projects where project.id == val select project.name).FirstOrDefault();
        return project_name;
    }

  
    protected void ButtonSave_Click(object sender, EventArgs e)
    {

        if (GetHashedText(TextBoxNewPassword.Text) != GetHashedText(TextBoxConfirmNewPassword.Text))
        {
            LabelMismatch.Visible = true;
        }
        else
        {
            var user_id = Int32.Parse(Session["id_user"].ToString());
            var u = (from user in db.Users where user.id == user_id select user).FirstOrDefault();
            u.password = GetHashedText(TextBoxNewPassword.Text);
            db.SaveChanges();
            Response.Redirect("DriverMain.aspx");

        }

    }
    protected void ButtonSaveLog(object sender, EventArgs e)
    {

        Log_driver log = new Log_driver();
        log.id_user = Int32.Parse(Session["id_user"].ToString());
        log.id_project = Int32.Parse(DropDownList3.SelectedItem.Value);
        log.vehicle_number = DropDownList1.SelectedItem.Text;
        if (string.IsNullOrWhiteSpace(TextBoxData.Text))
        {
            LabelMissingDate.Visible = true;
        }
        else
        {
            log.date = Convert.ToDateTime(TextBoxData.Text);
            LabelMissingDate.Visible = false;
        }
        if (string.IsNullOrWhiteSpace(TextBoxHours.Text))
        {
            LabelMissingHours.Visible = true;
        }
        else
        {
            log.hours = Int32.Parse(TextBoxHours.Text);
            LabelMissingHours.Visible = false;
        }
        if (string.IsNullOrWhiteSpace(TextBoxKm.Text))
        {
            LabelMissingKm.Visible = true;
        }
        else
        {
            log.km = Int32.Parse(TextBoxKm.Text);
            LabelMissingKm.Visible = false;
        }
        if (string.IsNullOrWhiteSpace(TextBoxObservations.Text))
        {
            log.observations = null;
        }
        else
        {
            log.observations = TextBoxObservations.Text;
        }
        if (DropDownListPass1.SelectedItem.Text == "-")
        {
            log.id_pass1 = null;
        }
        else
        {
            log.id_pass1 =Int32.Parse(DropDownListPass1.SelectedItem.Value);
        }
        if (DropDownListPass2.SelectedItem.Text == "-")
        {
            log.id_pass2 = null;
        }
        else
        {
            log.id_pass2 = Int32.Parse(DropDownListPass2.SelectedItem.Value);
        }
        if (DropDownListPass3.SelectedItem.Text == "-")
        {
            log.id_pass3 = null;
        }
        else
        {
            log.id_pass3 = Int32.Parse(DropDownListPass3.SelectedItem.Value);
        }
        if (DropDownListPass4.SelectedItem.Text == "-")
        {
            log.id_pass4 = null;
        }
        else
        {
            log.id_pass4 = Int32.Parse(DropDownListPass4.SelectedItem.Value);
        }


        if (string.IsNullOrWhiteSpace(TextBoxData.Text) == false && string.IsNullOrWhiteSpace(TextBoxHours.Text) == false && string.IsNullOrWhiteSpace(TextBoxKm.Text) == false)
        {
            db.Log_driver.Add(log);
            db.SaveChanges();
            Response.Redirect("DriverMain.aspx");
        }



    }

    protected void ButtonSelectDate_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        TextBoxData.Text = Calendar1.SelectedDate.ToShortDateString();
        Calendar1.Visible = false;
    }

    protected void AttachEvents(object sender, DayRenderEventArgs e)
    {

        DateTime day;
        foreach (var p in data)
        {
            day = (DateTime)p.Key.date;

            if (day.Date == e.Day.Date)
            {
                e.Cell.Controls.Add(new LiteralControl("<p>" + p.Value + " -- " + p.Key.hours + " h <p>"));
                e.Cell.Font.Bold = true;
            }
        }
    }

}