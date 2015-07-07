using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using InventionModel;
using InventionBLL;

namespace NewsManager
{
    public partial class NewsArticleAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ( Session["UserName"] != null)
                {
                    txtWriter.Text = Session["UserName"].ToString();
                }              
                txtTime.Text = DateTime.Now.ToString("d");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtContent.Text.Trim().Length == 0)
            {
                Response.Write("<script>alert('内容不能为空！');</script>");
                return;
            }
            NewsArticle na = new NewsArticle();
            NewsArticleBLL newsarticalbll = new NewsArticleBLL();
            string title = Server.HtmlEncode(TxtTitle.Text.Trim());
            string writer = Server.HtmlEncode(txtWriter.Text.Trim());
            na.AddDate = Convert.ToDateTime(txtTime.Text);
            na.Cid = 10;
            na.Content = txtContent.Text;
            na.Hits = 0;
            na.Title = title;
            na.Writer = writer;
            if (newsarticalbll.Add(na))
            {
                Response.Write("<script>alert('添加成功');window.location.href='NewsManager.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败');history.back();</script>");
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsManager.aspx");
        }
    }
}
