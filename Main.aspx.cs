using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{
    private Pontaje_firma_topografieEntities db = new Pontaje_firma_topografieEntities();
    private Dictionary<Log, string> data = new Dictionary<Log, string>();
    protected int id_user;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        var name = Session["username"];
        id_user = (from user in db.Users where user.username == name.ToString() select user.id).FirstOrDefault();
        var data_logged_work = (from log in db.Logs where log.id_user == id_user select log).ToList();
        foreach (var dlw in data_logged_work)
        {
            var proj = (from project in db.Projects where project.id == dlw.id_project select project.name).FirstOrDefault();
             data.Add(dlw, proj);
        }
        SqlDataSourcePontajeleMele.SelectParameters.Clear();
        var usr = Session["id_user"].ToString();
        SqlDataSourcePontajeleMele.SelectParameters.Add("usr", usr);
        SqlDataSourcePontajeleMele.SelectCommand = "SELECT * FROM [Logs] where [id_user]=@usr order by [date] desc";
        SqlDataSourcePontajeleMele.DataBind();
      
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
        Response.Redirect("LogWork.aspx?id="+Session["id_user"].ToString().Trim()+"&id_project="+Session["id_project"].ToString().Trim());

    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        int index = Int32.Parse(e.Item.Value);
        multiTabs.ActiveViewIndex = index;
    }

    public string GetLabelTextCategory(object dataItem)
    {
       
        int? val = dataItem as int?;
        string category_name = (from category in db.ProjectCategories where category.id== val select category.name).FirstOrDefault();
        return category_name; 
    }
    public string GetLabelTextProject(object dataItem)
    {

        int? val = dataItem as int?;
        string project_name = (from project in db.Projects where project.id == val select project.name).FirstOrDefault();
        return project_name;
    }

    public string GetLabelTextActivity(object dataItem)
    {

        int? val = dataItem as int?;
        string activity_name = (from activity in db.ActivityTypes where activity.id == val select activity.name).FirstOrDefault();
        return activity_name;
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
                 var u =(from user in db.Users where user.id== user_id select user).FirstOrDefault();
                u.password= GetHashedText(TextBoxNewPassword.Text);
                db.SaveChanges();
                Response.Redirect("Main.aspx");
            }
           
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