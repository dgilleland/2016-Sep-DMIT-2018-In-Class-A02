using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageSongs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected string ConvertMillisecondsToText(int milliseconds)
    {
        int seconds = milliseconds / 1000;
        string text = $"{seconds / 60} min, {seconds % 60} sec";
        return text;
    }
}