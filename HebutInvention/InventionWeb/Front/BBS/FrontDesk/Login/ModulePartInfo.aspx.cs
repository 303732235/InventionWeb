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
namespace InventionWeb.Front.BBS.FrontDesk.Login
{
    public partial class ModulePartInfo : System.Web.UI.Page
    {
        DataCon sqlCon = new DataCon();
        DataOperate sqlBind = new DataOperate();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idStr = Page.Request.QueryString["ModuleName"];
                labModTitle.Text = "专题名称：" + idStr;
                bind();
            }
        }

        public void bind()
        {
            string idStr = Page.Request.QueryString["ModuleName"];
            string sqlstr = "select * from ModuleInfo_View where ModuleName='" + idStr + "'order by CardDate desc";
            sqlBind.gvBind(gvModuleInfo, sqlstr);
        }

        protected void gvModuleInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string idStr = Page.Request.QueryString["ModuleName"];
            if (txtKeyWord.Text.Trim() == "")
            {
                gvModuleInfo.PageIndex = e.NewPageIndex;
                string sqlstr = "select * from ModuleInfo_View where ModuleName='" + idStr + "' and CardName like  '%" + txtKeyWord.Text + "%'order by CardDate desc";
                sqlBind.gvBind(gvModuleInfo, sqlstr);
            }
            else
            {
                gvModuleInfo.PageIndex = e.NewPageIndex;
                string search = txtKeyWord.Text.Trim();
                string sqlstr = "select * from ModuleInfo_View where ModuleName='" + idStr + "' and CardName like  @title order by CardDate desc";
                gvModuleInfo.DataSource = sqlBind.Search(sqlstr, search);
                gvModuleInfo.DataBind();
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            string idStr = Page.Request.QueryString["ModuleName"];
            string search = txtKeyWord.Text.Trim();
            string sqlstr = "select * from ModuleInfo_View where ModuleName='" + idStr + "' and CardName like  @title order by CardDate desc";
            gvModuleInfo.DataSource = sqlBind.Search(sqlstr, search);
            gvModuleInfo.DataBind();

        }

        protected void gvModuleInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = this.gvModuleInfo.PageIndex * this.gvModuleInfo.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }
    }
}
