﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using InventionModel;
using System.IO;

namespace InventionWeb.Background.ExampleAdmin
{
    public partial class ExampleArticleAdd : System.Web.UI.Page
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
                Response.Write("<script>alert('内容不能为空,请填写内容！');</script>");
                return;
            }
            ExampleArticle da = new ExampleArticle();
            ExampleArticleBLL examplearticlebll = new ExampleArticleBLL();
            string newname = "";
         
            da.Url = newname;
            da.AddDate = Convert.ToDateTime(TxtDate.Text);
            da.Writer = Server.HtmlEncode(TxtWriter.Text.Trim());
            da.Title = Server.HtmlEncode(TxtTitle.Text.Trim());
            da.Content = txtContent.Text;
            if (examplearticlebll.Add(da))
            {
                Response.Write("<script>alert('添加成功');window.location.href='ExampleMgr.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败');history.back();</script>");
            }
        }
       protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExampleMgr.aspx");
        }
    }
}