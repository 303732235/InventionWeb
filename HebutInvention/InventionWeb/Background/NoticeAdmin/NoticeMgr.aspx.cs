using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using System.Data;
using System.Data.SqlClient;
namespace InventionWeb.Background.NoticeAdmin
{
    public partial class NoticeMgr : System.Web.UI.Page
    {
        private NoticeArticleBLL noticearticlebll;
        protected void Page_Load(object sender, EventArgs e)
        {
            noticearticlebll = new NoticeArticleBLL();
            if (!IsPostBack)
            {
                DateBind();
            }
        }
        public void DateBind()
        {
            int curpage = Convert.ToInt32(this.labPage.Text);
            PagedDataSource ps = new PagedDataSource();
            IList<InventionModel.NoticeArticle> noticeart = noticearticlebll.Getlist(null);
            if (noticeart == null) {
                return;
            }
            ps.DataSource = noticeart;
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
            this.DateBind();
        }
        protected void lnkbtnUp_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) - 1);
            this.DateBind();
        }
        protected void lnkbtnNext_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) + 1);
            this.DateBind();
        }
        protected void lnkbtnBack_Click(object sender, EventArgs e)
        {
            this.labPage.Text = this.labBackPage.Text;
            this.DateBind();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                if (((CheckBox)DataList1.Items[i].FindControl("selected")).Checked == true)
                {
                    object s = ((System.Web.UI.WebControls.HyperLink)DataList1.Items[i].FindControl("Hyperlink3")).Text;
                    NoticeArticleBLL noticearticlebll = new NoticeArticleBLL();
                    if (noticearticlebll.Delete(s))
                    {
                        Response.Write("<script>alert('删除成功');</script>");
                    }
                }
            }
            this.Response.Redirect(this.Request.Url.ToString());
        }
        public string CutString(string content)
        {
            if (content.Length > 25)
            {
                return content.Substring(0, 24) + "...";
            }
            else
            {
                return content;
            }
        }
        protected void DataList1_DeleteCommand(object sender, DataListCommandEventArgs e)
        {
            NoticeArticleBLL noticearticlebll2 = new NoticeArticleBLL();
            string id = e.CommandArgument.ToString();
            if (noticearticlebll2.Delete(id))
            {
                Response.Write("<script>alert('删除成功');</script>");
            }
            this.Response.Redirect(this.Request.Url.ToString());
        }
      }
}

