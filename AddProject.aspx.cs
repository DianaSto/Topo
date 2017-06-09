using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddProject : System.Web.UI.Page
{
    Pontaje_firma_topografieEntities db = new Pontaje_firma_topografieEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DropDownList1.Items.Count == 0)
        {
            var category = (from c in db.ProjectCategories select c).ToList();
            foreach (var c in category)
            {
                ListItem element = new ListItem(c.name, c.id.ToString());
                DropDownList1.Items.Add(element);
            }
        }
    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        Project project = new Project();
        project.name = TextBoxName.Text;
        project.id_category= Int32.Parse(DropDownList1.SelectedItem.Value);
        db.Projects.Add(project);
        db.SaveChanges();
        Response.Redirect("AdminMain.aspx");
    }
}