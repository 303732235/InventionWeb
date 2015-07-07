using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using InventionWeb.Front.BBS.App_Code;
using System.Data;


namespace InventionWeb.Background.BBSAdmin.CardAdmin
{
    public partial class RevertCard : System.Web.UI.Page
    {
        DataCon myCon = new DataCon();
        DataOperate sqlBind = new DataOperate();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection sqlconn = myCon.getCon();
                sqlconn.Open();
                string sqlstr = "select a.*,b.CardName from tb_RevertCard as a join tb_Card as b on a.CardID=b.CardID where a.RevertCardID = '"
                   + Request["RevertCardID"].ToString() + "'";//接受CardInfo.aspx页传值
                SqlDataAdapter myAdapter = new SqlDataAdapter(sqlstr, sqlconn);
                DataSet myDSCard = new DataSet();
                DataSet myDSModule = new DataSet();
                myAdapter.Fill(myDSCard, "tb_RevertCard");
                myAdapter.Fill(myDSModule, "tb_Card");
                DataRowView rowViewCard = myDSCard.Tables["tb_RevertCard"].DefaultView[0];
                DataRowView rowViewModule = myDSModule.Tables["tb_Card"].DefaultView[0];
                labCardContent.Text = Convert.ToString(rowViewCard["RevertCardContent"]);
                labCardTitle.Text =  Convert.ToString(rowViewCard["RevertCardUserName"]);
                labCardDate.Text =  Convert.ToString(rowViewCard["RevertCardDate"]);
                labCardMod.Text =  Convert.ToString(rowViewModule["CardName"]);
                sqlconn.Close();
            }
        }
    }
}