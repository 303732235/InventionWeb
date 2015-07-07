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
using InventionCommon;
using System.Text;
namespace InventionWeb.Front.BBS.FrontDesk.Login
{
    public partial class CardPartInfo : System.Web.UI.Page
    {
        DataCon sqlCon = new DataCon();
        DataOperate sqlBind = new DataOperate();
        SqlConnection sqlconn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    editor.Style["display"] = "Block";
                    tishi.Style["display"] = "none";
                }

                string idStr = Page.Request.QueryString["CardID"];
                SqlConnection sqlconn = sqlCon.getCon();
                sqlconn.Open();
                string sqlstrbind = "select * from tb_Card where CardID='" + idStr + "'";
                SqlCommand sqlcom = new SqlCommand(sqlstrbind, sqlconn);
                SqlDataReader tmpReader = sqlcom.ExecuteReader();
                if (tmpReader.Read())
                {
                    labCardTitle.Text = "问题标题：" + tmpReader["CardName"].ToString();
                   labCardID.Text = tmpReader["CardID"].ToString();
                    username.Text = "发布人：" + tmpReader["UserName"].ToString();
                    labCardDate.Text = "发布日期：" + tmpReader["CardDate"].ToString();
                    labCardContent.Text = tmpReader["CardContent"].ToString();
                }
                tmpReader.Close();
                dlBind();

            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BrowseModule.aspx");
        }
        protected void btnRevert_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserName"].ToString() == "")
            {
                Response.Write("<script>alert('你未登录，需要登录！');</script>");
                txtContent.Text = "";
                return;
            }
            else
            {
                if (txtContent.Text == "" || txtContent.Text == null)
                {
                    Response.Write("<script>alert('回复内容不能为空');</script>");
                    return;
                }
                string[] filterWords = config.GetFilter().Split(',');
                int i;
                for (i = 0; i < filterWords.Length; i++)
                {
                    txtContent.Text = txtContent.Text.Replace(filterWords[i], "***");

                }
                string classrole=Session["class"].ToString();
                List<string> SQLStringList = new List<string>();
                if (classrole == "管理员" || classrole == "专家")
                {
                    string sql1 = "insert into tb_RevertCard(RevertCardUserID,RevertCardUserName,CardID,RevertCardContent,RevertCardDate,RevertRole)"
                                  + " values('" + Session["UserID"].ToString() + "','" + Session["UserName"].ToString() + "','" + labCardID.Text + "','" + txtContent.Text.ToString() + "','" + DateTime.Now + "','" + Session["Role"].ToString() + "')";
                    string sql2 = "update tb_Card set CardIsPride=1 where CardID= '" + labCardID.Text + "'";//找到相应的帖子，意思是已解决
                    string sql3 = "update tb_User set UserMark=UserMark+5 where UserID='" + Session["UserID"].ToString() + "'";
                    SQLStringList.Add(sql1);
                    SQLStringList.Add(sql2);
                    SQLStringList.Add(sql3);
                }
                else {
                    string sql1 = "insert into tb_RevertCard(RevertCardUserID,RevertCardUserName,CardID,RevertCardContent,RevertCardDate,RevertRole)"
                                     + " values('" + Session["UserID"].ToString() + "','" + Session["UserName"].ToString() + "','" + labCardID.Text + "','" + txtContent.Text.ToString() + "','" + DateTime.Now + "','" + Session["Role"].ToString() + "')";                  
                    string sql3 = "update tb_User set UserMark=UserMark+5 where UserID='" + Session["UserID"].ToString() + "'";
                    SQLStringList.Add(sql1);
                    SQLStringList.Add(sql3);

                }
                int flag = DbHelperSQL.ExecuteSqlTran(SQLStringList);
                if (flag > 0)
                {
                    string cardid = Page.Request.QueryString["CardID"];
                    StringBuilder str = new StringBuilder();
                    str.Append("<script language=javascript>");
                    str.Append("alert('回复成功！奖励5分！');parent.location.href='/Front/BBS/new_index/index2.aspx?comefrom=CardPartInfo&&CardId=");
                    str.Append(cardid);
                    str.Append("';</script>");
                    Response.Write(str);
               }
                else
                {
                    Response.Write("<script>alert('回复失败！');</script>");
                }
            }
        }
        public void dlBind()
        {
            string idStr = Page.Request.QueryString["CardID"];
            int curpage = Convert.ToInt32(this.labPage.Text);
            PagedDataSource ps = new PagedDataSource();
            sqlconn = sqlCon.getCon();
            sqlconn.Open();
            string sqlstr = "select * from CardInfo_View where CardID='" + idStr + "'";
            SqlDataAdapter MyAdapter = new SqlDataAdapter(sqlstr, sqlconn);
            DataSet ds = new DataSet();
            MyAdapter.Fill(ds, "CardInfo_View");
            ps.DataSource = ds.Tables["CardInfo_View"].DefaultView;
            ps.AllowPaging = true; //是否可以分页
            ps.PageSize = 5; //显示的数量
            ps.CurrentPageIndex = curpage - 1; //取得当前页的页码
            this.lnkbtnUp.Enabled = true;
            this.lnkbtnNext.Enabled = true;
            this.lnkbtnBack.Enabled = true;
            this.lnkbtnOne.Enabled = true;
            if (curpage == 1)
            {
                this.lnkbtnOne.Enabled = false;//不显示第一页按钮
                this.lnkbtnUp.Enabled = false;//不显示上一页按钮
            }
            if (curpage == ps.PageCount)
            {
                this.lnkbtnNext.Enabled = false;//不显示下一页
                this.lnkbtnBack.Enabled = false;//不显示最后一页
            }
            this.labBackPage.Text = Convert.ToString(ps.PageCount);
            this.dlRevertCard.DataSource = ps;
            this.dlRevertCard.DataKeyField = "CardID";
            this.dlRevertCard.DataBind();
        }
        protected void lnkbtnOne_Click(object sender, EventArgs e)
        {
            this.labPage.Text = "1";
            this.dlBind();
        }
        protected void lnkbtnUp_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) - 1);
            this.dlBind();
        }
        protected void lnkbtnNext_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) + 1);
            this.dlBind();
        }
        protected void lnkbtnBack_Click(object sender, EventArgs e)
        {
            this.labPage.Text = this.labBackPage.Text;
            this.dlBind();
        }
    }
}