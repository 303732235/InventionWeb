using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using System.Data;
using System.Data.SqlClient;
using InventionModel;
namespace InventionWeb.Front.NewImage
{
    public partial class NewImageRight : System.Web.UI.Page
    {
        private NewsImageBLL newsimagesbll;
        protected void Page_Load(object sender, EventArgs e)
        {
            newsimagesbll = new NewsImageBLL();
            if (!IsPostBack)
            {
                bindNews();
            }
        }

        public string CutString(string content)
        {
            if (content.Length > 8)
            {
                return content.Substring(0, 7) + "...";
            }
            else
            {
                return content;
            }
        }
        public void bindNews()
        {
            int curpage = Convert.ToInt32(this.labPage.Text);
            PagedDataSource ps = new PagedDataSource();
            IList<InventionModel.NewsImage> newimage = newsimagesbll.Getlist();
            if (newimage == null)
            {
                return;
            }
            ps.DataSource = newsimagesbll.Getlist();
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
            this.bindNews();
        }
        protected void lnkbtnUp_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) - 1);
            this.bindNews();
        }
        protected void lnkbtnNext_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) + 1);
            this.bindNews();
        }
        protected void lnkbtnBack_Click(object sender, EventArgs e)
        {
            this.labPage.Text = this.labBackPage.Text;
            this.bindNews();
        }
    }
}