using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionWeb.Front.BBS.App_Code;
using System.Data.SqlClient;
using System.Data;

namespace InventionWeb.Background.BBSAdmin.CardAdmin
{
    public partial class AddCard : System.Web.UI.Page
    {
        DataCon myCon = new DataCon();
        DataOperate sqlBind = new DataOperate();
        SqlConnection sqlconn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            }
        }
        protected void btnDeliver_Click(object sender, EventArgs e)
        {
            if (txtCardContent.Text.Trim().Length == 0)
            {
                Response.Write("<script>alert('内容不能为空！');</script>");
                return;
            }
            string title = Server.HtmlEncode(labCardTitle.Text);
            string strModuleID = ddlModuleName.SelectedValue;
            string sqlstr = "insert into tb_Card (UserID,UserName,ModuleID,CardName,CardContent,CardIsPride,CardDate)"
        + " values('" + Session["UserID"].ToString() + "','" + Session["UserName"].ToString() + "','" + strModuleID.ToString()
        + "','" + title + "','" + txtCardContent.Text + "',0,'" + DateTime.Now + "')";            
            sqlBind.DataCom(sqlstr);
            Response.Write("<script language=javascript>alert('发表成功');</script>");
            Response.Redirect("ManageCard.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageCard.aspx");
        }
    }
}