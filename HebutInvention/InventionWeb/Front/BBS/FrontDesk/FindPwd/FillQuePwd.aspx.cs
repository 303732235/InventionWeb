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
    public partial class FillQuePwd : System.Web.UI.Page
    {
        DataCon myCon = new DataCon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                SqlConnection sqlconn = myCon.getCon();
                sqlconn.Open();
                SqlCommand sqlcom = new SqlCommand("select UserQuePwd from tb_User  where UserName='"
                    + Convert.ToString(Session["UserName"]) + "'", sqlconn);//接受FillUserID页传值
                txtQuePwd.Text = Convert.ToString(sqlcom.ExecuteScalar());
                sqlconn.Close();
            }
            
        }
        protected void btnSure_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = myCon.getCon();
            sqlconn.Open();
            SqlCommand sqlcom = new SqlCommand("select count(*) from tb_User where UserAnsPwd='"
                + txtAnsPwd.Text + "' and UserName='" + Convert.ToString(Session["UserName"]) + "'", sqlconn);
            int count = Convert.ToInt32(sqlcom.ExecuteScalar());
            if (count > 0)
            {
                Page.Response.Redirect("FindPwd.aspx");
            }
            else
            {
                Response.Write("<script>alert('提示问题答案输入有误！');location='javascript:history.go(-1)'</script>");
                return;
            }
            sqlconn.Close();
        }
    }
}