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
    public partial class BrowseModule : System.Web.UI.Page
    {
        DataCon myCon = new DataCon();
        SqlConnection sqlconn;
        DataOperate dataopr = new DataOperate();
        protected void Page_Load(object sender, EventArgs e)
        {
            dlBind();
        }
        public void dlBind()
        {
            string idStr = Page.Request.QueryString["ModuleName"];
            int curpage = 1;
            PagedDataSource ps = new PagedDataSource();
            sqlconn = myCon.getCon();
            sqlconn.Open();
            string sqlstr = "select ModuleID, ModuleName, ModuleDate,ModuleDescribe,ModuleImage FROM tb_Module";
            SqlDataAdapter MyAdapter = new SqlDataAdapter(sqlstr, sqlconn);
            DataSet ds = new DataSet();
            MyAdapter.Fill(ds, "tb_Module");
            ps.DataSource = ds.Tables["tb_Module"].DefaultView;
            ps.AllowPaging = false; //是否可以分页
            ps.PageSize = 6; //显示的数量(当allowpaging=true时才有效)
            ps.CurrentPageIndex = curpage - 1; //取得当前页的页码
            this.dlModuleList.DataSource = ps;
           this.dlModuleList.DataKeyField = "ModuleID";
            this.dlModuleList.DataBind();
        }
        public string CutString(string content)
        {
            if (content.Length > 20)
            {
                return content.Substring(0, 19) + "...";
            }
            else
            {
                return content;
            }
        }
        protected void dlModuleList_ItemDataBound(object sender, DataListItemEventArgs e)
        { 
            DataList dl = null;               
            dl = (DataList)e.Item.FindControl("newtop");         
            string zhujian=this.dlModuleList.DataKeys[e.Item.ItemIndex].ToString();
            string newsql = "select top 3 * from tb_Card where ModuleID=" + zhujian + " order by CardDate DESC ";
             dataopr.dataBind(dl, newsql);
        }
    }
}