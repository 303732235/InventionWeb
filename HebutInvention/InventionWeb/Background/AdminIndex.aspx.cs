﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventionWeb.Background
{
    public partial class AdminIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                //Session["User"] = u.UserName;
                //Session["UserGrade"] = "admin";
            }
        }
    }
}