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
    public partial class FindPwd : System.Web.UI.Page
    {
        DataCon myCon = new DataCon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                txtUserID.Text = Session["UserName"].ToString();//接受FillUserID页传值
            }
            
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../../../index.aspx");
        }

        protected void xiugai_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text.Length == 0)
            {
                Response.Write("<script lanuage=javascript>alert('密码不能为空！');</script>");
            }
            else
            {
                string textpwd = CJ_DBOperater.CJ.PwdSecurity(txtPwd.Text.Trim());
                DataOperate dataopr = new DataOperate();
                //string sql="update tb_User set UserPwd=" + textpwd.ToString() + " where UserName="
                //    +Session["UserName"].ToString();

                string sql = string.Format("update tb_User set UserPwd='{0}' where UserName='{1}'", textpwd, Session["UserName"].ToString());
                if (dataopr.DataCom(sql))
                {
                    Session.Clear();
                    Response.Write("<script lanuage=javascript>alert('密码修改成功！'); location.href='../../../login.aspx' </script>");
                }
                else
                {
                    Session.Clear();
                    Response.Write("<script lanuage=javascript>alert('密码修改失败！');location.href='../../../login.aspx'</script>");
                }
            }
        }
    }
}