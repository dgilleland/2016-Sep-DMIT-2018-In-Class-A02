using StudentGradebook.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            var controller = new DummyController();
            StudentMarksGridView.DataSource = controller.ListFakeStudents();
            StudentMarksGridView.DataBind();
        }
    }
}