using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionWeb.Front.BBS.App_Code;
using System.Data.SqlClient;
using System.IO;
using InventionCommon;
namespace InventionWeb.Background.BBSAdmin.ModuleAdmin
{
    public partial class ManageMudole : System.Web.UI.Page
    {
        DataOperate sqlBind = new DataOperate();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                    string sqlstr = "select * from tb_Module";
                    gvModuleInfo.DataKeyNames = new string[] { "ModuleID" };
                    sqlBind.gvBind(gvModuleInfo, sqlstr);
            }
        }
        protected void gvModuleInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataCon dataCon = new DataCon();
            SqlConnection sqlconn = dataCon.getCon();          
            string fileid = gvModuleInfo.DataKeys[e.RowIndex].Value.ToString();
            if (fileid=="34")
            {
                Response.Write("<script language=javascript>alert('综合交流专题不能删除！');</script>");
                return;
            }
            string str = "select ModuleImage from tb_Module where ModuleID=" + fileid;
            sqlconn.Open();
            SqlCommand sqlcom = new SqlCommand(str,sqlconn);
            SqlDataReader sdr = sqlcom.ExecuteReader();
            sdr.Read();
            string filename = sdr["ModuleImage"].ToString();
            string strFilePath = Server.MapPath("~/IndexImages/") + filename;
            if (File.Exists(strFilePath))
            {
                File.Delete(strFilePath);
            }
            string strImageurl2 = Server.MapPath("~/NewsImages/") + filename;
            if (File.Exists(strImageurl2))
            {
                File.Delete(strImageurl2);
            }
            sdr.Close();
            sqlconn.Close();
            string sqlstr = "delete from tb_Module where ModuleID='" + gvModuleInfo.DataKeys[e.RowIndex].Value + "'";
            string sqlstrcard = "delete from tb_card where ModuleID='" + gvModuleInfo.DataKeys[e.RowIndex].Value + "'";
            string sqlstrRevertCard = "delete from tb_RevertCard where CardID IN ( select CardID from tb_Card where ModuleID='" + gvModuleInfo.DataKeys[e.RowIndex].Value + "' )";
            List<string> SQLStringList = new List<string>();
            SQLStringList.Add(sqlstrRevertCard);//先删除所含帖子的回复贴
            SQLStringList.Add(sqlstrcard);//再删除所含帖子
            SQLStringList.Add(sqlstr);//最后删除专题自己
            int flag = DbHelperSQL.ExecuteSqlTran(SQLStringList);
            if (flag > 0)
            {
                Response.Write("<script language=javascript>alert('删除成功');</script>");
                Response.Redirect("ManageMudole.aspx");
            }
            Response.Redirect("ManageMudole.aspx");
        }
        protected void gvModuleInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)(e.Row.Cells[4].Controls[0])).Attributes.Add("onclick", "return confirm('确定删除吗？')");
            }
        }
        protected void gvModuleInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvModuleInfo.PageIndex = e.NewPageIndex;
            string sqlstr = "select * from tb_Module";
            sqlBind.gvBind(gvModuleInfo, sqlstr);
        }
    }
}