using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using InventionModel;
using System.IO;

namespace InventionWeb.Background.NoticeAdmin
{
    public partial class NoticeEdit : System.Web.UI.Page
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
            NoticeArticleBLL noticearticle = new NoticeArticleBLL();
            NoticeArticle da = new NoticeArticle();
            da = noticearticle.GetNewsArticle(id);
            TxtTitle.Text = da.Title;
            TxtWriter.Text = da.Writer;
            TxtDate.Text = da.AddDate.ToString("d");
            txtContent.Text = da.Content.ToString();

        }
        protected void Save_Click(object sender, EventArgs e)
        {

            if (txtContent.Text.Trim().Length == 0)
            {
                Response.Write("<script>alert('内容不能为空！');</script>");
                return;
            }
            object id = Request.QueryString["id"];//有待改善不安全
            NoticeArticle da = new NoticeArticle();
            NoticeArticleBLL noticearticle = new NoticeArticleBLL();
            da.AddDate = Convert.ToDateTime(TxtDate.Text);
            da.Writer = Server.HtmlEncode(TxtWriter.Text.Trim());
            da.Title = Server.HtmlEncode(TxtTitle.Text.Trim());
            da.Id = id;
            da.Content = txtContent.Text;
            if (noticearticle.Update(da))
            {
                Response.Write("<script>alert('修改成功');window.location.href='NoticeMgr.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('更新失败');history.back();</script>");
            }
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("NoticeMgr.aspx");
        }
    }
}