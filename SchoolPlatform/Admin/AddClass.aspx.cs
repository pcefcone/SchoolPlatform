﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static SchoolPlatform.Models.CommonFunction;

namespace SchoolPlatform.Admin
{
    public partial class AddClass1 : System.Web.UI.Page
    {
        CommonFnx commonFnx = new CommonFnx();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void GetClass()
        {
            DataTable dt = commonFnx.Fetch("SELECT Row_NUMBER() OVER (ORDER BY (SELECT 1)) AS [Sr.No], ClassId, ClassName FROM Class");
            GridViewAddClass.DataSource = dt;
            GridViewAddClass.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = commonFnx.Fetch("SELECT * FROM Class WHERE ClassName = '" + txtClass.Text.Trim() + "'");
                if (dt.Rows.Count == 0)
                {
                    string query = "INSERT INTO Class VALUES('" + txtClass.Text.Trim() + "')";
                    commonFnx.Query(query);
                    lblMsg.Text = "Inserted Successfully!";
                    lblMsg.CssClass = "alert alert-success";
                    txtClass.Text = string.Empty;
                    GetClass();
                }
                else
                {
                    lblMsg.Text = "Entered Class already exists!";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridViewAddClass_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridViewAddClass_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridViewAddClass_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridViewAddClass_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}