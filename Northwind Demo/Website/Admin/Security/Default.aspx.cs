using Northwind.Application.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Security_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DataBindRoleList();
            DataBindUserList();
        }
    }

    private void DataBindUserList()
    {
        UserListView.DataSource = new UserManager().Users.ToList();
        UserListView.DataBind();
    }

    private void DataBindRoleList()
    {
        RoleListView.DataSource = new RoleManager().Roles.ToList();
        RoleListView.DataBind();
    }
}
