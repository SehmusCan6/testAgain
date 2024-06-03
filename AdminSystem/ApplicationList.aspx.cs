using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            DisplayApplications();
        }
    }

    void DisplayApplications()
    {
        clsApplicationCollection apps = new clsApplicationCollection();
        lstApplicationList.DataSource = apps.ApplicationList;
        lstApplicationList.DataValueField = "StaffId";
        lstApplicationList.DataTextField = "PositionApplied";
        lstApplicationList.DataBind();
    }

    public void btnAdd_Click(object sender, EventArgs e)
    {
        Session["StaffId"] = -1;
        Response.Redirect("ApplicationDataEntry.aspx");
    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApplicationDataEntry.aspx");
    }
}