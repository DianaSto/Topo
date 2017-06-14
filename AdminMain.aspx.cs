using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMain : System.Web.UI.Page
{
    Pontaje_firma_topografieEntities db = new Pontaje_firma_topografieEntities();

    protected int id_user;
    protected string start_date;
    protected string finish_date;
    protected int report_type;
    protected int id_user2;
    protected string start_date2;
    protected string finish_date2;
    protected int report_type2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (DropDownList1.Items.Count == 0)
        {
            DropDownList1.Items.Add(new ListItem("Toți", "0"));
            var user = (from u in db.Users where u.id_role==2 select u).ToList();
            foreach (var u in user)
            {
                ListItem element = new ListItem(u.id.ToString(), u.id.ToString());
                DropDownList1.Items.Add(element);
            }
            
        }
        if (DropDownList2.Items.Count == 0)
        {
            DropDownList2.Items.Add(new ListItem("Per proiecte", "1"));
            DropDownList2.Items.Add(new ListItem("Per tipuri de activități", "2"));
        }
        if (DropDownList12.Items.Count == 0)
        {
            DropDownList12.Items.Add(new ListItem("Toți", "0"));
            var user = (from u in db.Users where u.id_role == 3 select u).ToList();
            foreach (var u in user)
            {
                ListItem element = new ListItem(u.id.ToString(), u.id.ToString());
                DropDownList12.Items.Add(element);
            }

        }
        if (DropDownList22.Items.Count == 0)
        {
            DropDownList22.Items.Add(new ListItem("Per ore", "1"));
            DropDownList22.Items.Add(new ListItem("Per kilometri", "2"));
        }
        var name = Session["username"];
        var id_user = (from user in db.Users where user.username == name.ToString() select user.id).FirstOrDefault();
        var data_logged_work = (from log in db.Logs where log.id_user == id_user select log).ToList();
        foreach (var dlw in data_logged_work)
        {
            var proj = (from project in db.Projects where project.id == dlw.id_project select project.name).FirstOrDefault();
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

    public string GetLabelTextCategory(object dataItem)
    {

        int? val = dataItem as int?;
        string category_name = (from category in db.ProjectCategories where category.id == val select category.name).FirstOrDefault();
        return category_name;
    }

    public string GetLabelTextRole(object dataItem)
    {

        int? val = dataItem as int?;
        string role_name = (from role in db.Roles where role.id == val select role.name).FirstOrDefault();
        return role_name;
    }

    protected void AddUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddUser.aspx");
    }

    protected void ButtonAddCar_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCar.aspx");
    }

    protected void ButtonAddProject_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddProject.aspx");
    }

    protected void ButtonAddActivity_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddActivity.aspx");
    }

    protected void ButtonAddCategory_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCategory.aspx");
    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
       

        if (GetHashedText(TextBoxConfirmNewPassword.Text) != GetHashedText(TextBoxNewPassword.Text))
        {
            LabelMismatch.Visible = true;
        }
        else
        {
            var user_id = Int32.Parse(Session["id_user"].ToString());
            var u = (from user in db.Users where user.id == user_id select user).FirstOrDefault();
            u.password = GetHashedText(TextBoxNewPassword.Text);
            db.SaveChanges();
            Response.Redirect("Main.aspx");
        }

    }

    protected void ButtonSelectDateStart_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        TextBoxDataStart.Text = Calendar1.SelectedDate.ToShortDateString();
        Calendar1.Visible = false;
    }

    protected void ButtonSelectDateFinish_Click(object sender, EventArgs e)
    {
        Calendar2.Visible = true;
    }

    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        TextBoxDataFinish.Text = Calendar2.SelectedDate.ToShortDateString();
        Calendar2.Visible = false;
    }

    protected void ButtonFilter_Click(object sender, EventArgs e)
    {
        string start, finish;
        string[] breakApart = TextBoxDataStart.Text.Split('.');
        if (breakApart.Length > 1)
        {
            start = breakApart[2] + "-" + breakApart[1] + "-" + breakApart[0];
        }
        else
        {
            start = null;
        }
        breakApart = TextBoxDataFinish.Text.Split('.');
        if (breakApart.Length > 1)
        {
            finish = breakApart[2] + "-" + breakApart[1] + "-" + breakApart[0];
        }
        else
        {
            finish = null;
        }
        if (start == null)
            if (finish != null)
            {
                LabelMissingDateStart.Visible = true;
                LabelMissingDateFinish.Visible = false;
            }
        if (finish == null)
            if (start != null)
            {
                LabelMissingDateFinish.Visible = true;
                LabelMissingDateStart.Visible = false;
            }
        if (start != null && finish != null)
        {
            LabelMissingDateStart.Visible = false;
            LabelMissingDateFinish.Visible = false;
            start_date = start;
            finish_date = finish;
        }
        if (start == null && finish == null)
        {
            LabelMissingDateStart.Visible = false;
            LabelMissingDateFinish.Visible = false;
            start_date = null;
            finish_date = null;
        }
        if (DropDownList1.SelectedItem.Value != "0")
        {
            id_user = Int32.Parse(DropDownList1.SelectedItem.Value);
        }
        else
        {
            id_user = 0;
        }
        report_type = Int32.Parse(DropDownList2.SelectedItem.Value);
        
       
    }

    protected void ButtonSelectDateStart2_Click(object sender, EventArgs e)
    {
        Calendar12.Visible = true;
    }

    protected void Calendar12_SelectionChanged(object sender, EventArgs e)
    {
        TextBoxDataStart2.Text = Calendar12.SelectedDate.ToShortDateString();
        Calendar12.Visible = false;
    }

    protected void ButtonSelectDateFinish2_Click(object sender, EventArgs e)
    {
        Calendar22.Visible = true;
    }

    protected void Calendar22_SelectionChanged(object sender, EventArgs e)
    {
        TextBoxDataFinish2.Text = Calendar22.SelectedDate.ToShortDateString();
        Calendar22.Visible = false;
    }

    protected void ButtonFilter2_Click(object sender, EventArgs e)
    {
        string start, finish;
        string[] breakApart = TextBoxDataStart2.Text.Split('.');
        if (breakApart.Length > 1)
        {
            start = breakApart[2] + "-" + breakApart[1] + "-" + breakApart[0];
        }
        else
        {
            start = null;
        }
        breakApart = TextBoxDataFinish2.Text.Split('.');
        if (breakApart.Length > 1)
        {
            finish = breakApart[2] + "-" + breakApart[1] + "-" + breakApart[0];
        }
        else
        {
            finish = null;
        }
        if (start == null)
            if (finish != null)
            {
                LabelMissingDateStart2.Visible = true;
                LabelMissingDateFinish2.Visible = false;
            }
        if (finish == null)
            if (start != null)
            {
                LabelMissingDateFinish2.Visible = true;
                LabelMissingDateStart2.Visible = false;
            }
        if (start != null && finish != null)
        {
            LabelMissingDateStart2.Visible = false;
            LabelMissingDateFinish2.Visible = false;
            start_date2 = start;
            finish_date2 = finish;
        }
        if (start == null && finish == null)
        {
            LabelMissingDateStart2.Visible = false;
            LabelMissingDateFinish2.Visible = false;
            start_date2 = null;
            finish_date2 = null;
        }
        if (DropDownList12.SelectedItem.Value != "0")
        {
            id_user2 = Int32.Parse(DropDownList12.SelectedItem.Value);
        }
        else
        {
            id_user2 = 0;
        }
        report_type2 = Int32.Parse(DropDownList22.SelectedItem.Value);


    }
}