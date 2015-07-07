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
namespace InventionWeb.Front.BBS.FrontDesk.FindPwd
{
    public partial class FillUserID : System.Web.UI.Page
    {
        DataCon myCon = new DataCon();
        protected void btnSure_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = myCon.getCon();
            sqlconn.Open();
            SqlCommand sqlcom = new SqlCommand("select count(*) from tb_User where UserName='" + txtUserName.Text + "'", sqlconn);
            int count = Convert.ToInt32(sqlcom.ExecuteScalar());
            if (count > 0)
            {
                Session["UserName"] = txtUserName.Text;//给FillQuePwd.aspx和FindPwd.aspx页传值
                Response.Redirect("FillQuePwd.aspx");
            }
            else
            {
                Response.Write("<script>alert('没有该用户ID');location='javascript:history.go(-1)'</script>");
                return;
            }
            sqlconn.Close();
        }
    }
}