using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogWork : System.Web.UI.Page
{
    Pontaje_firma_topografieEntities db = new Pontaje_firma_topografieEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DropDownList1.Items.Count == 0)
        {
            var activity = (from act in db.ActivityTypes select act).ToList();
            foreach (var a in activity)
            {
                ListItem element = new ListItem(a.name, a.id.ToString());
                DropDownList1.Items.Add(element);
            }
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

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        Log log = new Log();
        log.id_user = Int32.Parse(Session["id_user"].ToString());
        log.id_project = Int32.Parse(Session["id_project"].ToString());
        log.id_activity_type = Int32.Parse(DropDownList1.SelectedItem.Value);
        if (string.IsNullOrWhiteSpace(TextBoxQuantity.Text))
        {
            log.cantitate = null;
        }
        else
        {
            log.cantitate = Int32.Parse(TextBoxQuantity.Text);
        }
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
        if (string.IsNullOrWhiteSpace(TextBoxObservations.Text))
        {
            log.observations = null;
        }
        else
        {
            log.observations = TextBoxObservations.Text;
        }
        if (string.IsNullOrWhiteSpace(TextBoxData.Text)==false&& string.IsNullOrWhiteSpace(TextBoxHours.Text)==false)
        {
            db.Logs.Add(log);
            db.SaveChanges();
            Response.Redirect("Main.aspx");
        }
    }
}