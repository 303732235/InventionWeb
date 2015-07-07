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
    public partial class UsersEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                object id = Request.QueryString["id"];
                DateBind(id);
            }
        }
        public void DateBind(object id)//绑定要修改的信息
        {

            UsersBLL usersbll = new UsersBLL();
            Users u = new Users();
            u = usersbll.GetUser(id);
            this.TxtName.Text = u.UserName;

            this.TxtPassword.Text = u.Password;//前台读不出
            yuanmima.Text = u.Password;
            this.TxtPhone.Text = u.Telephone;
            this.TxtEmail.Text = u.Email;
            this.TxtAddress.Text = u.Address;
           // this.mark.Text = u.UserMark.ToString();
            if (u.UserSex == "男")
                this.RadioButton_Male.Checked = true;
            else
                this.RadioButton_Female.Checked = true;
            if (u.Role == "会员")
                this.DropDownList1.SelectedValue = "2";
            else if (u.Role == "专家")
            {
                this.DropDownList1.SelectedValue = "3";
            }
            else
            {
                this.DropDownList1.SelectedValue = "1";
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            object id = Request.QueryString["id"];//有待改善不安全
            Users u = new Users();
            UsersBLL usersbll = new UsersBLL();
            u.UserId = id;
            u.UserName = this.TxtName.Text;
            if (TxtPassword.Text.Trim().Length != 0)
            {
                u.Password = CJ_DBOperater.CJ.PwdSecurity(this.TxtPassword.Text.Trim());
            }
            else
            {
                u.Password = yuanmima.Text.Trim();
            }
            u.Telephone = this.TxtPhone.Text;
            u.Address = this.TxtAddress.Text;
            u.Email = this.TxtEmail.Text;
            
            u.Role = this.DropDownList1.SelectedItem.Text;
            u.LoginTime = DateTime.Now;
            if (u.UserSex == "男")
                u.UserSex = this.RadioButton_Male.Text;
            else
                u.UserSex = this.RadioButton_Female.Text;
            if (usersbll.Update(u))
            {
                Response.Write("<script>alert('修改成功');window.location.href='UsersMgr.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('更新失败');history.back();</script>");
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsersMgr.aspx");
        }
    }
}