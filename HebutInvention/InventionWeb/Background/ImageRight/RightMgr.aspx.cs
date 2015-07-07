using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using InventionModel;

namespace InventionWeb.Background.ImageRight
{
    public partial class RightMgr : System.Web.UI.Page
    {
        private NewsImageBLL newsimagebll;
        protected void Page_Load(object sender, EventArgs e)
        {
            newsimagebll = new NewsImageBLL();
            if (!IsPostBack)
            {
                DateBind();
            }
        }
        public void DateBind()
        {
            int curpage = Convert.ToInt32(this.labPage.Text);
            PagedDataSource ps = new PagedDataSource();
            IList<RightImage> newimage = newsimagebll.Getlist1();
            if (newimage == null)
            {
                return;
            }
            ps.DataSource = newimage;
            ps.AllowPaging = true; //是否可以分页
            ps.PageSize = 6; //显示的数量
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
                    NewsImageBLL NewsImageBLL = new NewsImageBLL();
                    if (NewsImageBLL.Delete1(s))
                    {
                        string url1 = ((System.Web.UI.WebControls.Image)DataList1.Items[i].FindControl("CommodityImage")).ImageUrl.ToString();
                        string webFilePath = Server.MapPath(url1);//用来删除原有的图片
                        System.IO.FileInfo file = new System.IO.FileInfo(webFilePath);
                        if (file.Exists)
                        {
                            file.Delete();//删除
                        }
                        string url2 = ((System.Web.UI.WebControls.Image)DataList1.Items[i].FindControl("basicImage")).ImageUrl.ToString();
                        string webFilePath2 = Server.MapPath(url2);//用来删除原有的图片
                        System.IO.FileInfo file2 = new System.IO.FileInfo(webFilePath2);
                        if (file2.Exists)
                        {
                            file2.Delete();//删除
                        }
                    }
                }
            }
            this.Response.Redirect(this.Request.Url.ToString());
        }
        public string CutString(string content)
        {
            if (content.Length > 18)
            {
                return content.Substring(0, 17) + "...";
            }
            else
            {
                return content;
            }
        }
        protected void DataList1_DeleteCommand(object sender, DataListCommandEventArgs e)
        {
            string url1 = ((System.Web.UI.WebControls.Image)e.Item.FindControl("CommodityImage")).ImageUrl.ToString();
            string webFilePath = Server.MapPath(url1);//用来删除原有的图片
            System.IO.FileInfo file = new System.IO.FileInfo(webFilePath);
            if (file.Exists)
            {
                file.Delete();//删除
            }
            string url3 = ((System.Web.UI.WebControls.Image)e.Item.FindControl("basicImage")).ImageUrl.ToString();
            string webFilePath2 = Server.MapPath(url3);//用来删除原有的图片
            System.IO.FileInfo file2 = new System.IO.FileInfo(webFilePath2);
            if (file2.Exists)
            {
                file2.Delete();//删除
            }
            NewsImageBLL newsimagebll2 = new NewsImageBLL();
            string id = e.CommandArgument.ToString();
            if (newsimagebll2.Delete1(id))
            {
                Response.Write("<script>alert('删除成功');</script>");
            }
            this.Response.Redirect(this.Request.Url.ToString());
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}