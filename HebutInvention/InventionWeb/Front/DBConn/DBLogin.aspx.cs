using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using InventionWeb.Front.BBS.App_Code;

namespace InventionWeb.Front.DBConn
{
    public partial class DBLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (identify.Text.ToString().ToLower() != Session["check"].ToString().ToLower())
            {
                Response.Write("<script lanuage=javascript>alert('您输入的验证码错误，请重新输入！')</script>");
                identify.Text = "";
                return;
            }
            string uid = txtUserName.Text.Trim();
            string pwd = txtUserPass.Text.Trim();
            bool flag = config.checkout(uid, pwd);
            if (flag)
            {
                Session["DBConn"]="pass";
                Response.Redirect("~/Front/DBConn/ConfigMgr2.aspx");
            }
            Response.Write("<script lanuage=javascript>alert('用户名或密码有误！');</script>");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            txtUserName.Text = "";
            txtUserPass.Text = "";
        }
    }
}