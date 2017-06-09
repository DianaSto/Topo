using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddUser : System.Web.UI.Page
{
    Pontaje_firma_topografieEntities db = new Pontaje_firma_topografieEntities();
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
        if (DropDownList1.Items.Count == 0)
        {
            var role = (from r in db.Roles select r).ToList();
            foreach (var r in role)
            {
                ListItem element = new ListItem(r.name, r.id.ToString());
                DropDownList1.Items.Add(element);
            }
        }
    }

    protected void ButtonRegister_Click(object sender, EventArgs e)
    {
        LabelMismatch.Visible = false;
        LabelUsernameExists.Visible = false;
        Pontaje_firma_topografieEntities pe = new Pontaje_firma_topografieEntities();
        User user = new User();
        user.first_name = TextBoxFirstName.Text;
        user.last_name = TextBoxLastName.Text;
        user.email = TextBoxEmail.Text;
        user.username = TextBoxUsername.Text;
        user.password = GetHashedText(TextBoxPassword.Text);
        var check_username = (from u in pe.Users where u.username == TextBoxUsername.Text select u).Count();
        if (check_username == 1)
        {
            LabelUsernameExists.Visible = true;
        }
        else
        {
            if (GetHashedText(TextBoxPassword.Text) != GetHashedText(TextBoxConfirmPassword.Text))
            {
                LabelMismatch.Visible = true;
            }
            else
            {
                user.id_role= Int32.Parse(DropDownList1.SelectedItem.Value);
                pe.Users.Add(user);
                pe.SaveChanges();
                Response.Redirect("AdminMain.aspx");
            }

        }
    }


  
}