using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using InventionBLL;

namespace InventionWeb.WebControl
{
    public partial class head2 : System.Web.UI.UserControl
    {
        protected string userloginifo;
        private UsersBLL usersbll;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["UserName"] != null)
            {
                string CurrentUsername = Session["UserName"].ToString();
                userloginifo = "<span>欢迎您：" + CurrentUsername + "访问河北工业大学学报编辑部！<a href='/Front/loginout.aspx'>【退出】</a></span>";
            }
            else
            {
                userloginifo = "<span >您好!欢迎访问河北工业大学学报编辑部 <a href='/front/login.aspx?type=mokuai'>【请登录】</a> 新用户？<a href='/front/register.aspx'>【注册】</a></span>";

            }
            this.tongji.Text = Application["user_total "].ToString();
        }
        protected void CAIStart_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                string webusername = Session["UserName"].ToString();
                DataTable viewinfo = new DataTable();
                usersbll = new UsersBLL();
                viewinfo = usersbll.GetUserRole(webusername);
                string cainame = viewinfo.Rows[0].ItemArray[0].ToString();
                string caipwd = viewinfo.Rows[0].ItemArray[1].ToString();
                if (cainame == "")
                {
                    Response.Write("<script>alert('你的权限不够');history.back(-1);</script>");
                }
                else
                {
                    //Response.Write("<script>window.open('http://202.113.125.121:8080/View/backMgr.aspx?username=' + cainame + '&userpwd=' + caipwd','_blank');</script>");
                    Response.Redirect("http://202.113.125.121:8080/View/backMgr.aspx?username=" + cainame + "&userpwd=" + caipwd);//注意url传参数时，不能有空格
                }
            }
            else
            {
                Response.Write("<script>alert('你还未登录');window.history.back();</script>");

            }
        }
    }
}