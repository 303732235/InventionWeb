using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using InventionModel;
using System.Data;
namespace InventionWeb.Front
{
    public partial class login : System.Web.UI.Page
    {
        private static string type;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["type"] != null)
                {
                    type = Request["type"].ToString();
                }
            }
        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            if (identify.Text.ToString().ToLower() != Session["check"].ToString().ToLower())
            {
                Response.Write("<script lanuage=javascript>alert('您输入的验证码错误，请重新输入！')</script>");
                identify.Text = "";
                return;
            }
            else if (TxtUserName.Text.Trim().Length <= 0 || TxtPwd.Text.Trim().Length <= 0)
            {
                Response.Write("<script lanuage=javascript>alert('用户名或密码不能为空！');</script>");
                return;
            }
            else
            {
                UsersBLL usersbll = new UsersBLL();
                Users u = usersbll.GetUser(Server.HtmlEncode(TxtUserName.Text.Trim().Replace("'", "")));
                //Md5+盐值加密算法，相对安全
                if (u != null && u.Password.Trim() == CJ_DBOperater.CJ.PwdSecurity(TxtPwd.Text.Trim()))
                {
                    Session["UserID"] = u.UserId;
                    Session["UserName"] = u.UserName;
                    Session["UserPwd"] = u.Password;
                    Session["Mark"] = u.UserMark;
                    Session["class"] = u.Role;
                    int mark = u.UserMark;
                    u.LoginTime = DateTime.Now;
                    usersbll.Update(u);//记录用户当前登录时间

                    //以下是调用Mark表，查找匹配的用户级别
                    //DataTable markname = new DataTable();
                    //markname = usersbll.getmarkBLL(mark);
                    //Session["Role"] = markname.Rows[0].ItemArray[0].ToString();
                    switch (type)
                    {
                        case "indexpage":
                            Response.Redirect("index.aspx");
                            break;
                        case "bbs":
                            Response.Redirect("~/Front/BBS/new_index/index2.aspx");
                            break;
                        case "mokuai":
                            Response.Redirect("index.aspx");
                            break;
                        default:
                            Response.Redirect("index.aspx");
                            break;
                    }
                }
                else
                {
                    Response.Write("<script lanuage=javascript>alert('用户名或密码有误！');</script>");
                    Response.Write(" <script lanuage=javascript> location.href= './login.aspx' </script> ");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("index.aspx");
        }
    }
}