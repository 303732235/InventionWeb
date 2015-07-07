using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using InventionModel;
using System.IO;


namespace InventionWeb.Background.PolicyAdmin
{
    public partial class PolicyEdit : System.Web.UI.Page
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
            PolicyArticleBLL policyarticlebll = new PolicyArticleBLL();
            PolicyArticle da = new PolicyArticle();
            da = policyarticlebll.GetNewsArticle(id);
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
            PolicyArticle da = new PolicyArticle();
            PolicyArticleBLL policyarticlebll = new PolicyArticleBLL();
            da.AddDate = Convert.ToDateTime(TxtDate.Text);
            da.Writer = Server.HtmlEncode(TxtWriter.Text.Trim());
            da.Title = Server.HtmlEncode(TxtTitle.Text.Trim());
            da.Id = id;
            da.Content = txtContent.Text;
            if (policyarticlebll.Update(da))
            {
                Response.Write("<script>alert('修改成功');window.location.href='PolicyMgr.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('更新失败');history.back();</script>");
            }
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PolicyMgr.aspx");
        }
    }
}