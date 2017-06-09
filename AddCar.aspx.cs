using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddCar : System.Web.UI.Page
{
    Pontaje_firma_topografieEntities db = new Pontaje_firma_topografieEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        Car car = new Car();
        car.number = TextBoxCar.Text;
        db.Cars.Add(car);
        db.SaveChanges();
        Response.Redirect("AdminMain.aspx");
    }
}