using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using InventionModel;
using System.Text;
namespace InventionWeb.Front
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        //注册
        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            if (UserLoginName.Text.Trim().Length == 0)
            {
                Response.Write("<script lanuage=javascript>alert('用户名不能为空！')</script>");
                return;
            }
            if (identify.Text.ToString().ToLower() != Session["check"].ToString().ToLower())
            {
                Response.Write("<script lanuage=javascript>alert('您输入的验证码有误，请重新输入！')</script>");
                identify.Text = "";
                return;
            }
            if ( Password.Text.Trim().Length == 0 || AffrimPassword.Text.Trim().Length==0) {
                Response.Write("<script lanuage=javascript>alert('密码和确认密码均不能为空！')</script>");
                return;
            }
            if (txtQuePwd.Text.Trim().Length == 0 || txtAnsPwd.Text.Trim().Length == 0)
            {
                Response.Write("<script lanuage=javascript>alert('密码问题和密码答案均不能为空！')</script>");
                return;
            }
            if (EmailAddress.Text.Trim().Length == 0)
            {
                Response.Write("<script lanuage=javascript>alert('邮箱不能为空！')</script>");
                return;
            }
            UsersBLL usersbll = new UsersBLL();
            bool panduan = usersbll.Detect(this.UserLoginName.Text.Trim());
            if (panduan)
            {
                Response.Write("<script lanuage=javascript>alert('你的用户名已被占用！');</script>");
                return;
            }
            Users a = new Users();
            a.UserName = this.UserLoginName.Text.Trim();
            a.Password = CJ_DBOperater.CJ.PwdSecurity(this.Password.Text.Trim());
            a.Role = "会员";//注册为一般用户
            a.Telephone = this.TelephoneNum.Text.Trim();
            if (this.RadioButton_Male.Checked == true)
            {
                a.UserSex = "男";
            }
            else if (this.RadioButton_Female.Checked == true)
            {
                a.UserSex = "女";
            }
            a.Address = this.Address.Text.Trim();
            a.Email = this.EmailAddress.Text.Trim();
            a.UserMark = 0;
            a.QuePwd = this.txtQuePwd.Text.Trim();
            a.AnsPwd = this.txtAnsPwd.Text.Trim();


            a.LoginTime = DateTime.Now;
            a.CreateTime = DateTime.Now;
            if (usersbll.Add(a))
            {

                Response.Write("<script lanuage=javascript>alert('注册用户成功，现在转向登录界面！')</script>");
                Response.Write(" <script lanuage=javascript> location.href= './login.aspx' </script> ");
            }
            else
            {
                Response.Write("<script lanuage=javascript>alert('注册用户时出现错误,请重新注册！')</script>");
                Response.Write(" <script lanuage=javascript> location.href= './register.aspx' </script> ");
            }
        }
        //用户名检测
        protected void Detect_Click(object sender, EventArgs e)
        {
            if (this.UserLoginName.Text.Trim().Length == 0)
            {
                Response.Write("<script lanuage=javascript>alert('用户名不能为空！')</script>");
                return;
            }
            UsersBLL usersbll = new UsersBLL();
            bool a = usersbll.Detect(this.UserLoginName.Text);
            if (a)
                lblmessage.Text = "对不起，用户名已存在";

            else
                lblmessage.Text = "恭喜您！用户名可用";
        }


        //重置
        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Password.Text = "";
            AffrimPassword.Text = "";
            Address.Text = "";
            TelephoneNum.Text = "";
            EmailAddress.Text = "";
            txtAnsPwd.Text = "";
            txtQuePwd.Text = "";
        }
    }
}