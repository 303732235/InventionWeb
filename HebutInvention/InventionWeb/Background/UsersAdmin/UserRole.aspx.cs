using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using System.Data;
using System.Data.SqlClient;
namespace InventionWeb.Background.UsersAdmin
{
    public partial class UserRole : System.Web.UI.Page
    {
        private UsersBLL usersbll;

        protected void Page_Load(object sender, EventArgs e)
        {
            usersbll = new UsersBLL();
            if (!IsPostBack)
            {
                binduser();
                bindcaiuser();
            }
        }
        public void binduser()//绑定用户
        {
            int curpage = Convert.ToInt32(this.labPage.Text);
            PagedDataSource ps = new PagedDataSource();
            DataTable datatable = usersbll.GetUserRole(null);
            ps.DataSource = datatable.DefaultView;
            ps.AllowPaging = true; //是否可以分页
            ps.PageSize = 10; //显示的数量
            ps.CurrentPageIndex = curpage - 1; //取得当前页的页码
            this.lnkbtnUp.Enabled = true;
            this.lnkbtnNext.Enabled = true;
            this.lnkbtnBack.Enabled = true;
            this.lnkbtnOne.Enabled = true;
            if (curpage == 1)
            {
                this.lnkbtnOne.Enabled = false;//不显示第一页按钮
                this.lnkbtnUp.Enabled = false;//不显示上一页按钮
            }
            if (curpage == ps.PageCount)
            {
                this.lnkbtnNext.Enabled = false;//不显示下一页
                this.lnkbtnBack.Enabled = false;//不显示最后一页
            }
            this.labBackPage.Text = Convert.ToString(ps.PageCount);
            this.DataList1.DataSource = ps;
            this.DataList1.DataBind();
        }
        protected void lnkbtnOne_Click(object sender, EventArgs e)
        {
            this.labPage.Text = "1";
            this.binduser();
        }
        protected void lnkbtnUp_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) - 1);
            this.binduser();
        }
        protected void lnkbtnNext_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) + 1);
            this.binduser();
        }
        protected void lnkbtnBack_Click(object sender, EventArgs e)
        {
            this.labPage.Text = this.labBackPage.Text;
            this.binduser();
        }

        
        public void bindcaiuser()//调用CAI用户
        {

            DataTable datatable = usersbll.GetCAIUser();
            this.DataList2.DataSource = datatable;
            this.DataList2.DataBind();
        }

        protected void warranty_Click(object sender, EventArgs e)//用于分配用户一个CAI用户
        {
            object s=0;
            object b=0;
            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                if (((CheckBox)DataList1.Items[i].FindControl("selected")).Checked == true)
                {
                     s = ((System.Web.UI.WebControls.HyperLink)DataList1.Items[i].FindControl("Hyperlink1")).Text;//捕获异常
                     string distribute = ((System.Web.UI.WebControls.Label)DataList1.Items[i].FindControl("Label1")).Text;
                     if (distribute.Length!=0) 
                     {
                         Response.Write("<script>alert('你选的用户有权限，你需要先移除，再分配');history.back();</script>");
                         return;
                     }
                     count1++;
                }
            }
            if (count1 > 1||count1==0) 
            {
                Response.Write("<script>alert('用户列表你选择了多个或未选，请选择一个');history.back();</script>");
            }
            for (int i = 0; i < DataList2.Items.Count; i++)
            {
                if (((CheckBox)DataList2.Items[i].FindControl("selected")).Checked == true)
                {
                    b = ((System.Web.UI.WebControls.HyperLink)DataList2.Items[i].FindControl("Hyperlink2")).Text;//捕获异常
                    count2++;
                }
            }
            if (count2 > 1||count2==0)
            {
                Response.Write("<script>alert('CAI用户，你选择了多个或未选，请选择一个');history.back();</script>");
            }
            usersbll.warranty(s, b);
            binduser();
            bindcaiuser();
        }

        protected void remove_Click(object sender, EventArgs e)
        {
            object s = 0;
            int del = 0;
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                if (((CheckBox)DataList1.Items[i].FindControl("selected")).Checked == true)
                {
                    s = ((System.Web.UI.WebControls.HyperLink)DataList1.Items[i].FindControl("Hyperlink1")).Text;//捕获异常
                    del++;
                }
            }
            if(del==0)
            {
             Response.Write("<script>alert('请选择你要移除权限的用户');history.back();</script>");
            }
            usersbll.remove(s);
            binduser();
            bindcaiuser();
        }
    }
}