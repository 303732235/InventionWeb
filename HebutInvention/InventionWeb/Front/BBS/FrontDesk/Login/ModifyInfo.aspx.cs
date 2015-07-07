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
namespace InventionWeb.Front.BBS.FrontDesk.Login
{
    public partial class ModifyInfo : System.Web.UI.Page
    {
        DataCon myCon = new DataCon();
        DataOperate sqlBind = new DataOperate();
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
                    SqlConnection sqlconn = myCon.getCon();
                    sqlconn.Open();
                    string sqlstr = "Select * from tb_User where UserID='" + Session["UserID"].ToString() + "'";
                    SqlDataAdapter myApter = new SqlDataAdapter(sqlstr, sqlconn);
                    DataSet myDS = new DataSet();
                    myApter.Fill(myDS, "tb_User");
                    DataRowView rowView = myDS.Tables["tb_User"].DefaultView[0];
                    txtLoginName.Text = Convert.ToString(rowView["UserName"]);
                    txtTel.Text = Convert.ToString(rowView["UserTel"]);
                    txtEmail.Text = Convert.ToString(rowView["UserEmail"]);
                    txtAddress.Text = Convert.ToString(rowView["UserAddress"]);
                    if (Convert.ToString(rowView["UserSex"]).Trim() == "男")
                    {
                        ddlSex.SelectedIndex = 0;
                    }
                    if (Convert.ToString(rowView["UserSex"]).Trim() == "女")
                    {
                        ddlSex.SelectedIndex = 1;
                    }
                    sqlconn.Close();
                }
            }
        }
        protected void btnModify_Click(object sender, EventArgs e)
        {
            string sqlstr = "";
            if (newpwd1.Text != null && newpwd1.Text != "" && newpwd1.Text == newpwd2.Text)
            {
                string newpwd = CJ_DBOperater.CJ.PwdSecurity(this.newpwd1.Text.Trim());
                sqlstr = "update tb_User set UserSex='" + ddlSex.Text + "',UserPwd='" + newpwd + "',UserTel='" + txtTel.Text
                + "',UserEmail= '" + txtEmail.Text + "',UserAddress= '" + txtAddress.Text
                + "'where UserID = '" + Session["UserID"].ToString() + "'";//接受Login.aspx传值
            }
            else { 
             sqlstr = "update tb_User set UserSex='" + ddlSex.Text + "',UserTel='" + txtTel.Text
                + "',UserEmail= '" + txtEmail.Text + "',UserAddress= '" + txtAddress.Text
                + "'where UserID = '" + Session["UserID"].ToString() + "'";//接受Login.aspx传值
            }           
            sqlBind.DataCom(sqlstr);
            Response.Write("<script lanuage=javascript>alert('修改成功');location='BrowseModule.aspx'</script>");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BrowseModule.aspx");
        }
    }
}