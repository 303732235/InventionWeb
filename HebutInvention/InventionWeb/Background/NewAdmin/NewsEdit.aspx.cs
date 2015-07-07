using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using InventionModel;
using System.Data;
using System.Data.SqlClient;

namespace InventionWeb.Background.NewAdmin
{
    public partial class NewsEdit : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EditNews();
                
            }
        }
        public void EditNews()//初始化
        {
                    string id= Request.QueryString["id"];
                    NewsArticleBLL newsarticlebll = new NewsArticleBLL();
                    NewsArticle na = new NewsArticle();
                    na = newsarticlebll.GetNewsArticle(id);
                    TxtTitle.Text = na.Title;
                    txtWriter.Text=na.Writer;
                    txtTime.Text=na.AddDate.ToString("d");
                    txtContent.Text=na.Content;
         }
  

        protected void Button1_Click(object sender, System.EventArgs e)//编辑完，提交
        {
            if (txtContent.Text.Trim().Length == 0)
            {
                Response.Write("<script>alert('内容不能为空！');</script>");
                return;
            }
            var id = Request.QueryString["id"];
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
            na.Id = id;
            if (newsarticalbll.Update(na))
            {
                Response.Write("<script>alert('修改成功');window.location.href='NewsManager.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败');history.back();</script>");
            }
        }

        protected void Button2_Click(object sender, System.EventArgs e)//取消
        {
            Response.Redirect("NewsManager.aspx");
        }
   
        }
    }
