﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddActivity : System.Web.UI.Page
{
    Pontaje_firma_topografieEntities db = new Pontaje_firma_topografieEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        ActivityType activity = new ActivityType();
        activity.name = TextBoxActivity.Text;
        db.ActivityTypes.Add(activity);
        db.SaveChanges();
        Response.Redirect("AdminMain.aspx");

    }
}