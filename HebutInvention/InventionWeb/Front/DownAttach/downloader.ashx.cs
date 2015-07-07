using System;
using System.Web;
using System.Web.SessionState;
using InventionWeb.Front.BBS.App_Code;
using System.IO;

namespace InventionWeb.Front.DownAttach
{
    /// <summary>
    /// downloader 的摘要说明
    /// </summary>
    public class downloader : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string file = context.Request.Params.Get("file");
           //string File = Convert.ToString(e.CommandArgument);   //获取行号

                //string sql1 = "update tb_User set UserMark=UserMark-10 where UserName='" + context.Session["UserName"].ToString() + "'";
                DataOperate dataoper = new DataOperate();
                string sql2 = "update DownAttach set count=count+1 where filesavename='" + file + "'";
                DataOperate dataoper2 = new DataOperate();
                if (dataoper2.DataCom(sql2))
                {
                    context.Session["Mark"] = (Convert.ToInt32(context.Session["Mark"]) - 0).ToString();
                }

                string parentpath = HttpContext.Current.Server.MapPath("/Attach/");
                string FullFileName = parentpath + file;
                FileInfo DownloadFile = new FileInfo(FullFileName);
                FullFileName = file;
                context.Response.Clear();
                context.Response.ClearContent();
                context.Response.ClearHeaders();
                context.Response.Buffer = false;
                context.Response.ContentType = "application/octet-stream";
                context.Response.AppendHeader("Content-Disposition", "attachment;filename=" + file);
                context.Response.AppendHeader("Content-Length", DownloadFile.Length.ToString());
                context.Response.AddHeader("Content-Transfer-Encoding", "binary");
                context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                context.Response.WriteFile(DownloadFile.FullName);
                context.Response.Flush();
                context.Response.End();
           
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}