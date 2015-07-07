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
    public partial class Card : System.Web.UI.Page
    {
        DataCon myCon = new DataCon();
        DataOperate sqlBind = new DataOperate();
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    SqlConnection sqlconn = myCon.getCon();
                    sqlconn.Open();
                    string sqlstr = "select a.*,b.ModuleID,b.ModuleName from tb_Card as a "
                       + "join tb_Module as b on a.ModuleID = b.ModuleID where a.CardID = '"
                       + Request["CardID"].ToString() + "'";//接受CardInfo.aspx页传值
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sqlstr, sqlconn);
                    DataSet myDSCard = new DataSet();
                    DataSet myDSModule = new DataSet();
                    myAdapter.Fill(myDSCard, "tb_Card");
                    myAdapter.Fill(myDSModule, "tb_Module");
                    DataRowView rowViewCard = myDSCard.Tables["tb_Card"].DefaultView[0];
                    DataRowView rowViewModule = myDSModule.Tables["tb_Module"].DefaultView[0];
                    labCardContent.Text = Convert.ToString(rowViewCard["CardContent"]);
                    labCardTitle.Text = Convert.ToString(rowViewCard["CardName"]);
                    labCardDate.Text =  Convert.ToString(rowViewCard["CardDate"]);
                    labCardMod.Text =  Convert.ToString(rowViewModule["ModuleName"]);
                    sqlconn.Close();
            }
        }
    }
}