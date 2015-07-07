using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using InventionBLL;
using InventionModel;
namespace InventionWeb.Front.News
{
    public partial class NewsRight : System.Web.UI.Page
    {
        string labPage1;
        public string id;
        private NewsArticleBLL newsarticalbll;
        protected void Page_Load(object sender, EventArgs e)
        {
            newsarticalbll = new NewsArticleBLL();
            if (!IsPostBack)
            {
                labPage1 = "1";
                bindNews(null);
            }
        }
        public void bindNews(string id)
        {
            int curpage = Convert.ToInt32(labPage1);
            PagedDataSource ps = new PagedDataSource();
            IList<NewsArticle> searchtab = newsarticalbll.search(id);
            if (searchtab == null||searchtab.Count == 0)
            {
                if (IsPostBack)
                {
                    Response.Write("<script lanuage=javascript>alert('没有你要找的关键字！')</script>");
                }
                return;
            }
            ps.DataSource = searchtab;
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
            this.rightlist.DataSource = ps;
            this.rightlist.DataBind();
        }
        protected void lnkbtnOne_Click(object sender, EventArgs e)
        {
            this.labPage.Text = "1";
            labPage1 = this.labPage.Text;
            string searchstring = txtKwords.Text.Trim();
            id = searchstring;
            if (id == "")
            {
                this.bindNews(null);
            }
            else
            {
                this.bindNews(id);
            }
        }
        protected void lnkbtnUp_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) - 1);
            labPage1 = this.labPage.Text;
            string searchstring = txtKwords.Text.Trim();
            id = searchstring;
            if (id == "")
            {
                this.bindNews(null);
            }
            else
            {
                this.bindNews(id);
            }
        }
        protected void lnkbtnNext_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) + 1);
            labPage1 = this.labPage.Text;
            string searchstring = txtKwords.Text.Trim();
            id = searchstring;
            if (id == "")
            {
                this.bindNews(null);
            }
            else
            {
                this.bindNews(id);
            }
        }
        protected void lnkbtnBack_Click(object sender, EventArgs e)
        {
            this.labPage.Text = this.labBackPage.Text;
            labPage1 = this.labPage.Text;
            string searchstring = txtKwords.Text.Trim();
            id = searchstring;
            if (id == "")
            {
                this.bindNews(null);
            }
            else
            {
                this.bindNews(id);
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)//搜索关键字
        {
            this.labPage.Text = "1";
            labPage1 = "1";
            string searchstring = txtKwords.Text.Trim();
            id = searchstring;
            if (id == "")
            {
                this.bindNews(null);
            }
            else
            {
                this.bindNews(id);
            }
        }

    }
}