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
    public partial class EditCard : System.Web.UI.Page
    {
        DataCon myCon = new DataCon();
        DataOperate sqlBind = new DataOperate();
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    SqlConnection sqlconn1 = myCon.getCon();
                    string strsql = "select * from tb_Module";
                    sqlconn1 = myCon.getCon();
                    sqlconn1.Open();
                    SqlDataAdapter myApter = new SqlDataAdapter(strsql, sqlconn1);
                    DataSet myDS = new DataSet();
                    myApter.Fill(myDS, "tb_Module");
                    hpLinkCardMod.DataSource = myDS;
                    hpLinkCardMod.DataTextField = "ModuleName";
                    hpLinkCardMod.DataValueField = "ModuleID";
                    hpLinkCardMod.DataBind();

                    string sqlstr = "select * from ModuleInfo_View where CardID='" + Request["CardID"].ToString() + "'";
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sqlstr, sqlconn1);
                    DataSet myDSCard = new DataSet();
                    myAdapter.Fill(myDSCard, "ModuleInfo_View");
                    DataRowView rowViewCard = myDSCard.Tables["ModuleInfo_View"].DefaultView[0];
                    txtCardContent.Text = Convert.ToString(rowViewCard["CardContent"]);
                    labCardTitle.Text = Convert.ToString(rowViewCard["CardName"]);
                    labCardDate.Text =  Convert.ToDateTime(rowViewCard["CardDate"]).ToString("d");
                    hpLinkCardMod.SelectedValue = Convert.ToString(rowViewCard["ModuleID"]);
                    sqlconn1.Close();
                }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtCardContent.Text.Trim().Length == 0)
            {
                Response.Write("<script>alert('内容不能为空！');</script>");
                return;
            }
            string title = Server.HtmlEncode(labCardTitle.Text);
            DateTime dt = Convert.ToDateTime( labCardDate.Text.Trim());
            string strModuleID = hpLinkCardMod.SelectedValue;
            string sqlstr = "update tb_Card set CardName='" + title + "', ModuleID='" + strModuleID.ToString() + "', CardContent='" + txtCardContent.Text
               + "', CardDate='" + dt + "' where  CardID='" + Request["CardID"].ToString() + "'";
            sqlBind.DataCom(sqlstr);
            Response.Redirect("ManageCard.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageCard.aspx");
        }
    }
}