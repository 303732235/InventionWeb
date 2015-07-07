using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionWeb.Front.BBS.App_Code;
using System.Data.SqlClient;
using System.Data;
using InventionCommon;
using System.Text;

namespace InventionWeb.Front.BBS.FrontDesk.Login
{
    public partial class DeliverCard : System.Web.UI.Page
    {
        DataCon myCon = new DataCon();
        DataOperate sqlBind = new DataOperate();
        SqlConnection sqlconn;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AddHeader("P3P", "CP=CAO PSA OUR");
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("/Front/Login.aspx");
                }
                else
                {
                    string strsql = "select * from tb_Module";
                    sqlconn = myCon.getCon();
                    sqlconn.Open();
                    SqlDataAdapter myApter = new SqlDataAdapter(strsql, sqlconn);
                    DataSet myDS = new DataSet();
                    myApter.Fill(myDS, "tb_Module");
                    ddlModuleName.DataSource = myDS;
                    ddlModuleName.DataTextField = "ModuleName";
                    ddlModuleName.DataValueField = "ModuleID";
                    ddlModuleName.DataBind();
                    sqlconn.Close();
                }
            }
        }

        protected void btnDeliver_Click(object sender, EventArgs e)
        {
            if (txtCardTitle.Text.ToString() == "" || txtCardTitle.Text.ToString() == null || txtCardContent.Text.ToString() == "" || txtCardContent.Text.ToString() == null)
            {
                Response.Write("<script language=javascript>alert('标题名或内容不能为空！');</script>");
                return;
            }
            else
            {
                string strModuleID = ddlModuleName.SelectedValue;
                string[] filterWords = config.GetFilter().Split(',');
                int i;
                for (i = 0; i < filterWords.Length; i++)
                {
                    txtCardTitle.Text = txtCardTitle.Text.Replace(filterWords[i], "***");
                    txtCardContent.Text = txtCardContent.Text.Replace(filterWords[i], "***");
                }
                string title = Server.HtmlEncode(txtCardTitle.Text);
                string content = txtCardContent.Text;
                string sql1 = "insert into tb_Card (UserID,UserName,ModuleID,CardName,CardContent,CardIsPride,CardDate)"
                        + " values('" + Session["UserID"].ToString() + "','" + Session["UserName"].ToString() + "','" + strModuleID.ToString()
                        + "','" + title + "','" + content + "',0,'" + DateTime.Now + "')";
                string sql2 = "update tb_User set UserMark=UserMark+10 where UserID='" + Session["UserID"].ToString() + "'";
                List<string> SQLStringList = new List<string>();
                SQLStringList.Add(sql1);
                SQLStringList.Add(sql2);
                int flag = DbHelperSQL.ExecuteSqlTran(SQLStringList);
                if (flag > 0)
                {
                    string sqlstr = "select top 1 CardId from tb_Card order by CardDate desc";
                    DataOperate Dataoper = new DataOperate();
                    string cardid = Dataoper.Query(sqlstr).Tables[0].Rows[0].ItemArray[0].ToString();
                    StringBuilder str = new StringBuilder();
                    str.Append("<script language=javascript>");
                    str.Append("alert('发表成功！奖励10分');parent.location.href='/Front/BBS/new_index/index2.aspx?comefrom=DeliverCard&&CardId=");
                    str.Append(cardid);
                    str.Append("';</script>");
                    Response.Write(str);
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Front/BBS/FrontDesk/Login/BrowseModule.aspx");
        }
    }
}