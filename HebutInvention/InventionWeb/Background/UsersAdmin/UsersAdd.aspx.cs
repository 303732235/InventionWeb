using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using InventionModel;
namespace InventionWeb.Background.UsersAdmin
{
    public partial class UsersAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            if (this.TxtName.Text.Trim().Length == 0)
            {
                Response.Write("<script lanuage=javascript>alert('用户名不能为空！')</script>");
                return;
            }
            UsersBLL usersbll = new UsersBLL();
            bool jiance = usersbll.Detect(this.TxtName.Text);
            if (jiance)
            {
                Response.Write("<script>alert('对不起，用户名已存在');history.back();</script>");
                return;
            }
            Users a = new Users();
            a.UserName = this.TxtName.Text;
            a.Password = CJ_DBOperater.CJ.PwdSecurity(this.TxtPassword.Text.Trim());
            a.QuePwd = question.Text.Trim();
            a.AnsPwd = answer.Text.Trim();
            a.Role = this.DropDownList1.SelectedItem.Text;
            a.Telephone = this.TxtPhone.Text;
            if (this.RadioButton_Male.Checked == true)
            {
                a.UserSex = "男";
            }
            else if (this.RadioButton_Female.Checked == true)
            {
                a.UserSex = "女";
            }
            a.Address = this.TxtAddress.Text;
            a.Email = this.TxtEmail.Text;
            if (mark.Text.Trim().Length == 0)
            {
                a.UserMark = 0;
            }
            else
            {
                a.UserMark = Convert.ToInt32(mark.Text);
            }            
            a.LoginTime = Convert.ToDateTime(DateTime.Now.ToString());
            a.CreateTime = Convert.ToDateTime(DateTime.Now.ToString());
            if (usersbll.Add(a))
            {
                Response.Write("<script>alert('添加成功');window.location.href='UsersMgr.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败');history.back();</script>");
            }
        }
    }
}