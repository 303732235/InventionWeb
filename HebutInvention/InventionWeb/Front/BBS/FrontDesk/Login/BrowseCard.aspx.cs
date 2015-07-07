using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using InventionWeb.Front.BBS.App_Code;
using System.Text;
namespace InventionWeb.Front.BBS.FrontDesk.Login
{
    public partial class BrowseCard : System.Web.UI.Page
    {
        DataOperate sqlBind = new DataOperate();
        DataCon myCon = new DataCon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        public void bind()
        {
            string sqlstr = "select * from ModuleInfo_View order by CardDate desc";
            CardInfo.DataKeyNames = new string[] { "CardID" };
            sqlBind.gvBind(CardInfo, sqlstr);
        }

        protected void gvModuleInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (txtKeyWord.Text.Trim() == "")
            {
                CardInfo.PageIndex = e.NewPageIndex;
                string sqlstr = "select * from ModuleInfo_View order by CardDate desc";
                sqlBind.gvBind(CardInfo, sqlstr);
            }
            else {
                CardInfo.PageIndex = e.NewPageIndex;
                string search = txtKeyWord.Text.Trim();
                string sqlstr = "select * from ModuleInfo_View where CardName like @title order by CardDate desc";
                CardInfo.DataSource = sqlBind.Search(sqlstr, search);
                CardInfo.DataBind();
            }
        }

        protected void btnSelect_Click1(object sender, EventArgs e)
        {
           string search = txtKeyWord.Text.Trim();
           string sqlstr = "select * from ModuleInfo_View where CardName like @title order by CardDate desc";
           CardInfo.DataSource = sqlBind.Search(sqlstr, search);
            CardInfo.DataBind();
           
        }
        protected void unsolved_Click(object sender, EventArgs e)
        {
            string sqlstr = "select * from ModuleInfo_View where CardIsPride=0 order by CardDate desc";
            CardInfo.DataKeyNames = new string[] { "CardID" };
            sqlBind.gvBind(CardInfo, sqlstr);
        }

        protected void resolved_Click(object sender, EventArgs e)
        {
            string sqlstr = "select * from ModuleInfo_View where CardIsPride=1 order by CardDate desc";
            CardInfo.DataKeyNames = new string[] { "CardID" };
            sqlBind.gvBind(CardInfo, sqlstr);

        }

        protected void CardInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = this.CardInfo.PageIndex * this.CardInfo.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }
    }
}