using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventionWeb.Front
{
    public partial class loginout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string comefrom = Request.QueryString["comefrom"];
                if (comefrom == null) {
                    Session.Clear();
                    Response.Redirect("~/Front/index.aspx");                  
                }
                else if (comefrom == "bbs")
                {
                    Session.Clear();
                    Response.Redirect("~/Front/BBS/new_index/index2.aspx");
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("~/Front/index.aspx");   
                }
                     
            }
        }
    }
}