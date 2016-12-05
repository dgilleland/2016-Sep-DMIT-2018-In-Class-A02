using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sandbox_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.IsAuthenticated)
        {
            UserNameLabel.Text = "You are logged in as '" + User.Identity.Name + "'";
        }
        else
        {
            UserNameLabel.Text = "You are not logged into the website.";
        }
    }
}