using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity; // for the mgr.FindByName

public partial class Sandbox_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.IsAuthenticated)
        {
            UserNameLabel.Text = "You are logged in as '" + User.Identity.Name + "'";
            // Get the user's ApplicationUser ID
            var mgr = new Northwind.Application.Security.UserManager();
            var userInfo = mgr.FindByName(User.Identity.Name);

            UserNameLabel.Text += "<br />Your user ID is " + userInfo.Id;
        }
        else
        {
            UserNameLabel.Text = "You are not logged into the website.";
        }
    }
}