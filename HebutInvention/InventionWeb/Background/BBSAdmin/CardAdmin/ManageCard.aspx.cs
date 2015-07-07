using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionWeb.Front.BBS.App_Code;
using InventionCommon;

namespace InventionWeb.Background.BBSAdmin.CardAdmin
{
    public partial class ManageCard : System.Web.UI.Page
    {
        DataOperate sqlBind = new DataOperate();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sqlstr = "select * from ModuleInfo_View order by CardDate desc";
                gvCardInfo.DataKeyNames = new string[] { "CardID" };
                sqlBind.gvBind(gvCardInfo, sqlstr);
            }
        }
        protected void gvCardInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sqlstr = "delete from tb_Card where CardID='" + gvCardInfo.DataKeys[e.RowIndex].Value + "'";
            string sqlrevert = "delete from tb_RevertCard where CardID='" + gvCardInfo.DataKeys[e.RowIndex].Value + "'";          
            //用事务删除帖子和它所回复的帖子操作
            List<string> SQLStringList = new List<string>();
            SQLStringList.Add(sqlrevert);//先删除所含帖子的回复贴
            SQLStringList.Add(sqlstr);//再删除所含帖子
            int flag = DbHelperSQL.ExecuteSqlTran(SQLStringList);
            if (flag > 0)
            {
                Response.Write("<script language=javascript>alert('删除成功');</script>");
                Response.Redirect("ManageCard.aspx");
            }
        }
        protected void gvCardInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)(e.Row.Cells[6].Controls[0])).Attributes.Add("onclick", "return confirm('确定删除吗？')");
            }
        }
        protected void gvCardInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (search.Text.Trim() == "")
            {
                gvCardInfo.PageIndex = e.NewPageIndex;
                string sqlstr = "select * from ModuleInfo_View order by CardDate desc";
                sqlBind.gvBind(gvCardInfo, sqlstr);
            }
            else
            {
                gvCardInfo.PageIndex = e.NewPageIndex;
                string searchstr = search.Text.Trim();
                string sqlstr = "select * from ModuleInfo_View where CardName like @title order by CardDate desc";
                gvCardInfo.DataSource = sqlBind.Search(sqlstr, searchstr);
                gvCardInfo.DataBind();
            }

        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            string searchstr = search.Text.Trim();
            string sqlstr = "select * from ModuleInfo_View where CardName like @title order by CardDate desc";
            gvCardInfo.DataSource = sqlBind.Search(sqlstr, searchstr);
            gvCardInfo.DataBind();
        }

    }
}