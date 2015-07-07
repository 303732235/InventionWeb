using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using InventionModel;
using System.IO;

namespace InventionWeb.Background.WorkdtAdmin
{
    public partial class WorkdtArticleAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TxtDate.Text = DateTime.Now.ToString("d");
                if (Session["UserName"] != null)
                {
                    TxtWriter.Text = Session["UserName"].ToString();
                } 
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            if (txtContent.Text.Trim().Length == 0)
            {
                Response.Write("<script>alert('内容不能为空,请填写内容！');</script>");
                return;
            }
            WorkdtArticle da = new WorkdtArticle();
            WorkdtArticleBLL workdtarticlebll = new WorkdtArticleBLL();
            string newname = "";
          
            da.Url = newname;
            da.AddDate = Convert.ToDateTime(TxtDate.Text);
            da.Writer = Server.HtmlEncode(TxtWriter.Text.Trim());
            da.Title = Server.HtmlEncode(TxtTitle.Text.Trim());
            da.Content = txtContent.Text;
            if (workdtarticlebll.Add(da))
            {
                Response.Write("<script>alert('添加成功');window.location.href='WorkdtMgr.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败');history.back();</script>");
            }
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkdtMgr.aspx");
        }
    }
}