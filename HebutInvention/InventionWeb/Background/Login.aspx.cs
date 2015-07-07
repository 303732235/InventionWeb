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
using InventionBLL;
using InventionModel;

namespace InventionWeb.Background
{
    public partial class Login2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (identify.Text != null && identify.Text.ToString() != "")
            {
                if (identify.Text.ToString().ToLower() != Session["check"].ToString().ToLower())
                {
                    Response.Write("<script lanuage=javascript>alert('您输入的验证码不正确，请重新输入！')</script>");
                    identify.Text = "";
                    return;
                }
                UsersBLL adminbll = new UsersBLL();
                string UserName = txtUserName.Text;
                string UserPass = txtUserPass.Text;
                InventionModel.Users u = new InventionModel.Users();
                u.UserName = UserName;
                u.Password = CJ_DBOperater.CJ.PwdSecurity(UserPass);
                if (adminbll.CheckLogin(u))
                {
                    InventionModel.Users mgr = adminbll.GetUser(u.UserName);
                    string m = mgr.Role.ToString();
                    if (m != "管理员")
                    {
                        Response.Write("<script>alert('您的权限不够，登录失败！');</script>");
                        return;
                    }
                    Session["UserName"] = mgr.UserName;
                    Session["UserID"] = mgr.UserId;
                    Session["UserPwd"] = mgr.Password;
                    Session["class"] = mgr.Role;
                    Session["Mark"] = mgr.UserMark;
                    mgr.LoginTime = DateTime.Now;
                    adminbll.Update(mgr);//记录用户当前登录时间
                    FormsAuthentication.RedirectFromLoginPage(mgr.UserName, false);
                    Response.Redirect("adminindex.aspx");
                }
                else
                {
                    Response.Write("<script>alert('用户名或密码有误！');</script>");
                    Response.Write(" <script lanuage=javascript> location.href= './Login.aspx' </script> ");
                }
            }
            else
            {
                Response.Write("<script lanuage=javascript>alert('请输入验证码！')</script>");
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            txtUserName.Text = "";
            txtUserPass.Text = "";
        }


    }
}