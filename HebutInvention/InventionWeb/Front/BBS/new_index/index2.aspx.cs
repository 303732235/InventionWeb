using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using InventionModel;
using InventionWeb.Front.BBS.App_Code;

namespace InventionWeb.Front.BBS.new_index
{
    public partial class index2 : System.Web.UI.Page
    {
        protected string userloginifo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                top2.Visible = true;
                //以下是取得用户积分
                InventionBLL.UsersBLL usersbll = new InventionBLL.UsersBLL();
                Users u = usersbll.GetUser(Session["UserName"].ToString());
               // mark.Text = "积分：" + u.UserMark.ToString();
                Session["Mark"] = u.UserMark.ToString();
                //以下是取得用户级别
                DataTable markname = new DataTable();
                markname = usersbll.getmarkBLL(u.UserMark);
                Session["Role"] = markname.Rows[0].ItemArray[0].ToString();
                string name = Session["UserName"].ToString();
                userloginifo = "<span >当前用户: <a href='../FrontDesk/Login/ModifyInfo.aspx' target='mainFrame' style='color: #2E9DC8'>" + name + "&nbsp;&nbsp;</a>积分：" + u.UserMark.ToString() + "&nbsp;&nbsp;用户级别：" + Session["Role"].ToString() + "&nbsp;&nbsp; <a style='color: #2E9DC8;' runat='server' href='../../loginout.aspx?comefrom=bbs' target='_top'>退出系统</a></span>";        
            }
            else
            {
                top1.Visible = true;
                userloginifo = "<span>用户级别：游客</span>";
            }
            string comefrom = Request.QueryString["comefrom"];
            switch (comefrom)
            {
                case "DeliverCard":
                    string CardId = Request.QueryString["CardId"];
                    mainFrame.Attributes["src"] = "../FrontDesk/Login/CardPartInfo.aspx?CardID=" + CardId;
                    break;
                case "CardPartInfo":
                     string CardId1 = Request.QueryString["CardId"];
                    mainFrame.Attributes["src"] = "../FrontDesk/Login/CardPartInfo.aspx?CardID=" + CardId1;
                    break;
                case "Uploadindex":
                    mainFrame.Attributes["src"] = "../FrontDesk/Login/uploadindex.aspx";
                    break;
                case "BrowseCard":
                    mainFrame.Attributes["src"] = "../FrontDesk/Login/BrowseCard.aspx";
                    break;
                case "connection":
                    mainFrame.Attributes["src"] = "../FrontDesk/Login/ModulePartInfo.aspx?ModuleName=综合交流";
                    break;
                default:
                    mainFrame.Attributes["src"] = "/Front/BBS/FrontDesk/Login/BrowseModule.aspx";
                    break;
            }
        }
    }
}