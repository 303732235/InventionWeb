using System;
using InventionModel;
using InventionBLL;
using System.IO;
namespace InventionWeb.Background.AllianceAdmin
{
    public partial class AllianceArticleAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    TxtWriter.Text = Session["UserName"].ToString();
                } 
                TxtDate.Text = DateTime.Now.ToString("d");
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            if (txtContent.Text.Trim().Length == 0)
            {
                Response.Write("<script>alert('内容不能为空！');</script>");
                return;
            }
            AllianceArticle da = new AllianceArticle();
            AllianceArticleBLL alliancearticlebll = new AllianceArticleBLL();
            string title = Server.HtmlEncode(TxtTitle.Text.Trim());
            string writer = Server.HtmlEncode(TxtWriter.Text.Trim());
            da.AddDate = Convert.ToDateTime(TxtDate.Text);
            da.Writer = writer;
            da.Title = title;
            da.Content = txtContent.Text;
            if (alliancearticlebll.Add(da))
            {
                Response.Write("<script>alert('添加成功');window.location.href='AllianceMgr.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败');history.back();</script>");
            }
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllianceMgr.aspx");
        }
    }
}