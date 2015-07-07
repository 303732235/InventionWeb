using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using InventionModel;
using System.IO;


namespace InventionWeb.Background.AllianceAdmin
{
    public partial class AllianceEdit : System.Web.UI.Page
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

            AllianceArticleBLL alliancearticlebll = new AllianceArticleBLL();
            AllianceArticle da = new AllianceArticle();
            da = alliancearticlebll.GetNewsArticle(id);
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
            AllianceArticle da = new AllianceArticle();
            AllianceArticleBLL alliancearticlebll = new AllianceArticleBLL();
            string title = Server.HtmlEncode(TxtTitle.Text.Trim());
            string writer = Server.HtmlEncode(TxtWriter.Text.Trim());
            da.AddDate = Convert.ToDateTime(TxtDate.Text);
            da.Writer = writer;
            da.Title = title;
            da.Id = id;
            da.Content = txtContent.Text;
            if (alliancearticlebll.Update(da))
            {
                Response.Write("<script>alert('修改成功');window.location.href='AllianceMgr.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('更新失败');history.back();</script>");
            }
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllianceMgr.aspx");
        }
    }
}