using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using InventionBLL;
using InventionWeb.Front.BBS.App_Code;

namespace InventionWeb.Front.DownAttach
{
    public partial class filedownload : System.Web.UI.Page
    {
        public static int class1;
        private DownAttachBLL downbll;
        protected void Page_Load(object sender, EventArgs e)
        {
           //Response.Write(Request["num"]);
            //float ab = float.Parse(Context.Request["canshu"]);
            downbll = new DownAttachBLL();
            if (!IsPostBack)
            {
              
             
              
                    string b = Request.Params.Get("type");
                    string aa = b.Substring(0, 1);
                    if (b == "0") GridviewDatabind2(1);
                    else
                    {
                        if (b == "1") { int cid = Convert.ToInt32(b); GridviewDatabind2(cid); }
                        else if (b == "2") { int cid = Convert.ToInt32(b); GridviewDatabind2(cid); }
                            
                        else if (aa=="a"){
                            int id = Convert.ToInt32(b.Substring(1));
                            GridviewDatabind3(id);
                        
                        
                        }
                        else
                        {
                            int year = Convert.ToInt32(b.Substring(0, 4));
                            float a = (float)System.Convert.ToDouble(b.Substring(4));


                            GridviewDatabind1(year, a);
                        }
                    }
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text.Length > 0 && this.TextBox2.Text.Length == 0)
            {
                Response.Write("<script lanuage=javascript>alert('请正确填写年份区间！')</script>");
                return;
            }
            else if (this.TextBox1.Text.Length == 0 && this.TextBox2.Text.Length >0)
            {
                Response.Write("<script lanuage=javascript>alert('请正确填写年份区间！')</script>");
                return;
            }
            else if (this.TextBox1.Text.Length == 0 && this.TextBox2.Text.Length == 0)
            {

                string key = this.searchtext.Text;
                DataTable datatable = downbll.searchkey(key);
                this.GridViewArticle.DataSource = datatable;
                this.GridViewArticle.DataKeyNames = new string[] { "id" };
                this.GridViewArticle.DataBind();
                if(datatable==null||datatable.Rows.Count==0)
                    this.searchNone.Style["display"] = "block";
                else
                    this.searchNone.Style["display"] = "none";
                

            }
            else
            {
                int year1 = Convert.ToInt32(this.TextBox1.Text);
                int year2 = Convert.ToInt32(this.TextBox2.Text);
                string key = this.searchtext.Text;
                DataTable datatable = downbll.searchkey1(year1,year2,key);
                this.GridViewArticle.DataSource = datatable;
                this.GridViewArticle.DataKeyNames = new string[] { "id" };
                this.GridViewArticle.DataBind();
                if (datatable == null || datatable.Rows.Count == 0)
                    this.searchNone.Style["display"] = "block";
                else
                    this.searchNone.Style["display"] = "none";
            }
           
            
        
        }
        protected void GridviewDatabind(int cid)
        {
            DataTable datatable = downbll.GetTable(cid);
            this.GridViewArticle.DataSource = datatable;
            this.GridViewArticle.DataKeyNames = new string[] { "id" };
            this.GridViewArticle.DataBind();
        }

        protected void GridviewDatabind1(int year,float type)
        {
            DataTable datatable = downbll.GetTable1(year,type);
            this.GridViewArticle.DataSource = datatable;
            this.GridViewArticle.DataKeyNames = new string[] { "id" };
            this.GridViewArticle.DataBind();
        }
        protected void GridviewDatabind2(int cid)
        {
            DataTable datatable = downbll.GetTable2(cid);
            this.GridViewArticle.DataSource = datatable;
            this.GridViewArticle.DataKeyNames = new string[] { "id" };
            this.GridViewArticle.DataBind();
        }
        protected void GridviewDatabind3(int id)
        {
            DataTable datatable = downbll.GetTable3(id);
            this.GridViewArticle.DataSource = datatable;
            this.GridViewArticle.DataKeyNames = new string[] { "id" };
            this.GridViewArticle.DataBind();
        }

        protected void GridViewArticle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewArticle.PageIndex = e.NewPageIndex;
            GridviewDatabind(class1);
        }

        protected void GridViewArticle_onRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "download")
            {
            
                
                  
                        string File = Convert.ToString(e.CommandArgument);   //获取行号
                        ClientScript.RegisterStartupScript(Page.GetType(), "AttachDownBtnClick", "<script language=javascript>window.down = '/Front/DownAttach/downloader.ashx?file=" + File + "'</script>");
                //Page.RegisterStartupScript("DownloadBtnClick","<script language=javascript>window.down = '/Front/DownAttach/downloader.ashx?file=" + File + "'</script>");
                        sort2_SelectedIndexChanged(null, null);

                        //string sql1 = "update tb_User set UserMark=UserMark-10 where UserName='" + Session["UserName"].ToString() + "'";
                        //DataOperate dataoper = new DataOperate();
                        //string sql2 = "update DownAttach set count=count+1 where filesavename='" + File + "'";
                        //DataOperate dataoper2 = new DataOperate();
                        //if (dataoper.DataCom(sql1)&&dataoper2.DataCom(sql2))
                        //{
                        //    Session["Mark"] = (Convert.ToInt32(Session["Mark"]) - 10).ToString();
                        //    //Response.Write("<script language=javascript>alert('下载成功！减10分');</script>");
                        //    //object id = Request.QueryString["id"];
                        //    //DownAttachBLL downbll = new DownAttachBLL();
                        //   // var a=downbll.GetDownAttach();
                        //    //DownAttach da = new DownAttach();
                        //    //DownAttachBLL down = new DownAttachBLL();
                        //    //down.Update(Count);
                        //}

                        //string parentpath = HttpContext.Current.Server.MapPath("/Attach/");
                        //string FullFileName = parentpath + File;
                        //FileInfo DownloadFile = new FileInfo(FullFileName);
                        //FullFileName = File;
                        //Response.Clear();
                        //Response.ClearContent();
                        //Response.ClearHeaders();
                        //Response.Buffer = false;
                        //Response.ContentType = "application/octet-stream";
                        //Response.AppendHeader("Content-Disposition", "attachment;filename=" + File);
                        //Response.AppendHeader("Content-Length", DownloadFile.Length.ToString());
                        //Response.AddHeader("Content-Transfer-Encoding", "binary");
                        //Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                        //Response.WriteFile(DownloadFile.FullName);
                        //Response.Flush();
                        //Response.End();
                   

                
            }
        }

        protected void GridViewArticle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = this.GridViewArticle.PageIndex * this.GridViewArticle.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }

        protected void GridViewArticle_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                System.Web.UI.WebControls.Unit unit1 = Unit.Parse("5%");
                System.Web.UI.WebControls.Unit unit2 = Unit.Parse("10%");
                System.Web.UI.WebControls.Unit unit3 = Unit.Parse("65%");
                System.Web.UI.WebControls.Unit unit4 = Unit.Parse("10%");
                System.Web.UI.WebControls.Unit unit5 = Unit.Parse("10%");
                e.Row.Cells[0].Width = unit1;
                e.Row.Cells[1].Width = unit2;
                e.Row.Cells[1].Width = unit3;
                e.Row.Cells[1].Width = unit4;
                e.Row.Cells[1].Width = unit5;
            }
        }
        public string CutString(string content)
        {
           
                return content;
          
        }

        protected void sort2_SelectedIndexChanged(object sender, EventArgs e)
        {
            class1 = sort2.SelectedIndex + 1;
            DataTable datatable = downbll.GetTable(class1);
            this.GridViewArticle.DataSource = datatable;
            this.GridViewArticle.DataKeyNames = new string[] { "id" };
            this.GridViewArticle.DataBind();
        }



        //protected void sortType(object sender, EventArgs e)
        //{
            
          
            
        //    DataTable datatable = downbll.GetTable();
        //    this.GridViewArticle.DataSource = datatable;
        //    this.GridViewArticle.DataKeyNames = new string[] { "id" };
        //    this.GridViewArticle.DataBind();
        //}

    }
}