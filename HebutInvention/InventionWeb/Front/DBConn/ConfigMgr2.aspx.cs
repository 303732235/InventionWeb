using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using InventionWeb.Front.BBS.App_Code;
namespace InventionWeb.Front.DBConn
{
    public partial class ConfigMgr2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["DBConn"] == null)
                {
                    Response.Redirect("DBLogin.aspx");
                }
            }
        }
        //重设用户名和密码
        protected void Button2_Click(object sender, EventArgs e)
        {
            this.welcome.Style["Display"] = "none";
            this.Panel1.Style["Display"] = "Block";
        }
        //重设用户名和密码时，取消按钮
        protected void quit_Click(object sender, EventArgs e)
        {
            TxtNewname.Text = "";
            TxtNewpwd.Text = "";
            TextBox1.Text = "";
            this.Panel1.Style["Display"] = "none";
            this.welcome.Style["Display"] = "Block";
        }
        //返回首页
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/front/index.aspx");
        }
        //修改字符串
        protected void Btn_Login_Click1(object sender, EventArgs e)
        {
            string newConString = "server=" + SQLIP.Text.Trim() + ";database=" + SQLName.Text.Trim() + ";uid=" + SQLUser.Text.Trim() + ";pwd=" + SQLPwd.Text.Trim() + ";";
            UpdateWebConfig("ConStr", newConString);
        }
        public void UpdateWebConfig(string key, string strValue)
        {
            string keyPath = "/configuration/appSettings/add[@key='?']";
            XmlDataDocument webConfig = new XmlDataDocument();
            string webConfigPath = HttpContext.Current.Server.MapPath("~") + @"\web.config";
            webConfig.Load(webConfigPath);
            XmlNode updateKey = webConfig.SelectSingleNode((keyPath.Replace("?", key)));
            if (updateKey == null)
            {
                throw new ArgumentException("没有找到<add key='" + key + "'value=/>的配置字节");
            }
            updateKey.Attributes["value"].InnerText = strValue;
            webConfig.Save(webConfigPath);
        }
        protected void submit_Click(object sender, EventArgs e)
        {
            if (TxtNewname.Text.Trim().Length == 0 || TxtNewpwd.Text.Trim().Length==0)
            {
                Response.Write("<script>alert('用户名或密码不能为空！');</script>");
                return;
            }
            if (TxtNewpwd.Text.Trim() != TextBox1.Text.Trim()) {
                Response.Write("<script>alert('两次密码不一致');</script>");
                return;
            }

            string name = TxtNewname.Text.Trim();
            string pwd = TxtNewpwd.Text.Trim();
            config.Set(name, pwd);
            this.Panel1.Style["Display"] = "none";
            this.welcome.Style["Display"] = "Block";
        }
        //清空按钮
        protected void Button1_Click(object sender, EventArgs e)
        {
            SQLIP.Text = "";
            SQLName.Text = "";
            SQLUser.Text = "";
            SQLPwd.Text = "";

        }
    }
}