using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    private string GetHashedText(string inputData)
    {
        byte[] tmpSource;
        byte[] tmpData;
        tmpSource = ASCIIEncoding.ASCII.GetBytes(inputData);
        tmpData = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        return Convert.ToBase64String(tmpData);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void TextBoxUsername_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBoxPassword_TextChanged(object sender, EventArgs e)
    {

    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        Pontaje_firma_topografieEntities db = new Pontaje_firma_topografieEntities();
        string username = TextBoxUsername.Text;
        string password = GetHashedText(TextBoxPassword.Text);
        var u = (from user in db.Users where user.username == username && user.password == password select user).FirstOrDefault();
        if (u != null)
        {
            Session["username"] = TextBoxUsername.Text;
            int id_user = (from user in db.Users where user.username == username select user.id).FirstOrDefault();
            Session["id_user"] = id_user;
            int id_role = (from user in db.Users where user.username == username select user.id_role).FirstOrDefault();
            if (id_role == 1)
            {
                Response.Redirect("AdminMain.aspx");
            }
            else if (id_role == 2)
            {
                Response.Redirect("Main.aspx");
            }
            else if (id_role == 3)
            {
                Response.Redirect("DriverMain.aspx");
            }
            Session.RemoveAll();
        }
        else
        {
            LabelWrong.Visible = true;
        }

    }
}