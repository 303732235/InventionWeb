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
    public partial class RevertCardAdmin : System.Web.UI.Page
    {
        DataOperate sqlBind = new DataOperate();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sqlstr = "select a.*,b.CardName from tb_RevertCard as a inner join tb_Card as b on a.CardID=b.CardID ";
                gvCardInfo.DataKeyNames = new string[] { "RevertCardID" };
                sqlBind.gvBind(gvCardInfo, sqlstr);
            }
        }
        protected void gvCardInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sqlrevert = "delete from tb_RevertCard where RevertCardID='" + gvCardInfo.DataKeys[e.RowIndex].Value + "'";
            if (sqlBind.DataCom(sqlrevert))
            {
                Response.Write("<script language=javascript>alert('删除成功');</script>");
                Response.Redirect("RevertCardAdmin.aspx");
            }
        }
        protected void gvCardInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)(e.Row.Cells[5].Controls[0])).Attributes.Add("onclick", "return confirm('确定删除吗？')");
            }
        }
        protected void gvCardInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string sqlstr = "select a.*,b.CardName from tb_RevertCard as a inner join tb_Card as b on a.CardID=b.CardID ";
            gvCardInfo.PageIndex = e.NewPageIndex;
            sqlBind.gvBind(gvCardInfo, sqlstr);
        }
    }
}