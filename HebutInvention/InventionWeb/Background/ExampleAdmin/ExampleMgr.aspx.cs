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
namespace InventionWeb.Background.ExampleAdmin
{
    public partial class ExampleMgr : System.Web.UI.Page
    {
        private ExampleArticleBLL examplearticlebll;
        protected void Page_Load(object sender, EventArgs e)
        {
            examplearticlebll = new ExampleArticleBLL();
            if (!IsPostBack)
            {
                DateBind();
            }
        }
        public void DateBind()
        {
            int curpage = Convert.ToInt32(this.labPage.Text);
            PagedDataSource ps = new PagedDataSource();
            IList<ExampleArticle> exampleart = examplearticlebll.Getlist(null);
            if (exampleart == null) {
                return;
            }
            ps.DataSource = exampleart;
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
                    ExampleArticleBLL examplearticlebll = new ExampleArticleBLL();
                    if (examplearticlebll.Delete(s))
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
         //string url1 = ((System.Web.UI.WebControls.Image)e.Item.FindControl("CommodityImage")).ImageUrl.ToString();
         //if (url1 != null && url1 != "")
         //{
         //    string webFilePath = Server.MapPath(url1);//用来删除原有的图片
         //    System.IO.FileInfo file = new System.IO.FileInfo(webFilePath);
         //    if (file.Exists)
         //    {
         //        file.Delete();//删除
         //    }
         //    string url3 = ((System.Web.UI.WebControls.Image)e.Item.FindControl("basicImage")).ImageUrl.ToString();
         //    string webFilePath2 = Server.MapPath(url3);//用来删除原有的图片
         //    System.IO.FileInfo file2 = new System.IO.FileInfo(webFilePath2);
         //    if (file2.Exists)
         //    {
         //        file2.Delete();//删除
         //    }
         //}
         ExampleArticleBLL examplearticlebll2 = new ExampleArticleBLL(); ;
         string id = e.CommandArgument.ToString();
         if (examplearticlebll2.Delete(id))
         {
             Response.Write("<script>alert('删除成功');</script>");
         }
         this.Response.Redirect(this.Request.Url.ToString());
     }
    }
}

