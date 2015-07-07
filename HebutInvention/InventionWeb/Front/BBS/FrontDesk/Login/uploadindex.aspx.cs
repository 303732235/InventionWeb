using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using System.Data;
using System.IO;
using InventionWeb.Front.BBS.App_Code;
using InventionCommon;

namespace InventionWeb.Front.BBS.FrontDesk.Login
{
    public partial class uploadindex : System.Web.UI.Page
    {
        public string cid1;
        public int class1;
        private DownAttachBLL downbll;
        protected void Page_Load(object sender, EventArgs e)
        {
            downbll = new DownAttachBLL();
            if (!IsPostBack)
            {
                GridviewDatabind(4);
            }
        }

        protected void GridviewDatabind(int cid)
        {
            DataTable datatable = downbll.GetTable(cid);
            this.uploadifo.DataSource = datatable;
            this.uploadifo.DataKeyNames = new string[] { "id" };
            this.uploadifo.DataBind();
        }

        protected void GridViewArticle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.uploadifo.PageIndex = e.NewPageIndex;
            GridviewDatabind(4);
        }

        protected void GridViewArticle_onRowCommand(object sender, GridViewCommandEventArgs e)
        {
            
                        string sql1 = "update tb_User set UserMark=UserMark-0 where UserName='wlq123'";
                        DataOperate dataoper = new DataOperate();
                        if (dataoper.DataCom(sql1))
                        {
                            Response.Write("<script language=javascript>alert('下载成功！');</script>");
                        }

                        string File = Convert.ToString(e.CommandArgument);   //获取行号
                        string parentpath = HttpContext.Current.Server.MapPath("/Attach/");
                        string FullFileName = parentpath + File;
                        FileInfo DownloadFile = new FileInfo(FullFileName);
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.Buffer = false;
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=" +File);
                        Response.AppendHeader("Content-Length", DownloadFile.Length.ToString());
                        Response.AddHeader("Content-Transfer-Encoding", "binary");
                        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
                        Response.WriteFile(DownloadFile.FullName);
                        Response.Flush();
                        Response.End();
                   
        }
        protected void GridViewArticle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = this.uploadifo.PageIndex * this.uploadifo.PageSize + e.Row.RowIndex + 1; 
                e.Row.Cells[0].Text = id.ToString();
            }
        }

        protected void GridViewArticle_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                System.Web.UI.WebControls.Unit unit1 = Unit.Parse("5%");
                System.Web.UI.WebControls.Unit unit2 = Unit.Parse("65%");
                System.Web.UI.WebControls.Unit unit3 = Unit.Parse("10%");
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
            if (content.Length > 10)
            {
                return content.Substring(0, 9) + "...";
            }
            else
            {
                return content;
            }
        }

        protected void up_Click(object sender, EventArgs e)
        {
           
                uppanel.Style["display"] = "Block";
            
        }
        protected void uploadbtn_Click(object sender, EventArgs e)
        {
            if (TxtTitle.Text.Trim() == "" || !FileUpload1.HasFile)
            {
                Response.Write("<script>alert('资料名称和文件均不能为空');</script>");
                return;
            }
            string name="";
            InventionModel.DownAttach da = new InventionModel.DownAttach();
            if (FileUpload1.HasFile)
            {
                FileInfo file = new FileInfo(FileUpload1.PostedFile.FileName);
                if (file.Extension.ToLower() != ".doc" && file.Extension.ToLower() != ".txt" && file.Extension.ToLower() != ".zip" && file.Extension.ToLower() != ".rar")
                {
                    Response.Write("<script>alert('上传的资料格式应为doc/txt/zip/rar格式');</script>");
                    return;
                }
                DownAttachBLL downattachbll = new DownAttachBLL();
                name = FileUpload1.FileName;                  // 客户端文件路径

                string filename = FileUpload1.PostedFile.FileName;
                filename = System.IO.Path.GetFileName(filename);
                //改文件名
                int index = filename.LastIndexOf(".");
                string lastName = filename.Substring(index, filename.Length - index);//获得文件后缀类型
                //新文件名称,以时间年月日时分秒作为文件名
                name =TxtTitle.Text.Trim()+ DateTime.Now.ToString("hhmmss") + lastName;
                string webFilePath = Server.MapPath("/Attach/" + name);  // 服务器端文件路径
                double size = FileUpload1.PostedFile.ContentLength;//文件大小
                if (size >= 20480000)
                {
                    Response.Write("<script>alert('上传失败！（资料容量请不要超过20MB）');history.back();</script>");

                    return;
                }
                if (!File.Exists(webFilePath))
                {
                    FileUpload1.SaveAs(webFilePath);                              // 使用 SaveAs 方法保存文件  
                }
                else
                {
                    Response.Write("<script>alert('上传失败，请重试！');</script>");
                    return;
                }
            }
            //da.AddDate = DateTime.Now;
            da.Writer = Session["UserName"].ToString();
            da.Title = TxtTitle.Text.Trim();
            da.FileSaveName = name;
            da.Cid = 4;
            string sql1 = string.Format("insert into DownAttach (addDate,writer,title,filesavename,cid) values ('{0}','{1}','{2}','{3}','{4}')", da.AddDate, da.Writer, da.Title, da.FileSaveName, da.Cid);
            string sql2 = "update tb_User set UserMark=UserMark+10 where UserName='" + Session["UserName"].ToString() + "'";
            List<string> SQLStringList = new List<string>();
            SQLStringList.Add(sql1);
            SQLStringList.Add(sql2);
            int flag = DbHelperSQL.ExecuteSqlTran(SQLStringList);
            if (flag>0)
            {
                Response.Write("<script>alert('上传成功！积分加10分');</script>");
                Response.Write(" <script language=javascript>parent.location.href='/Front/BBS/new_index/index2.aspx?comefrom=Uploadindex';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败');history.back();</script>");

            }
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            uppanel.Style["display"] = "none";
            TxtTitle.Text = "";
        }
    }
}