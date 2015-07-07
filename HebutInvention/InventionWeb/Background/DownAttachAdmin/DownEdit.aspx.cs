using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using InventionModel;
using System.IO;
namespace InventionWeb.Background.DownAttachAdmin
{
    public partial class DownEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object id = Request.QueryString["id"];
                DateBind(id);

            }
        }
        public void DateBind(object id)//绑定要修改的信息
        {

            DownAttachBLL downbll = new DownAttachBLL();
            DownAttach da = new DownAttach();
            da = downbll.GetDownAttach(id);
            TxtTitle.Text = da.Title;
            TxtWriter.Text = da.Writer;
            TxtFileName.Text = da.FileSaveName;
            TxtDate.Text = da.AddDate.ToString("d");
            this.classification.SelectedValue = da.Cid.ToString();
         }      

        protected void Save_Click(object sender, EventArgs e)
        {
            object id = Request.QueryString["id"];//有待改善不安全
          DownAttach da = new DownAttach();
          DownAttachBLL downbll = new DownAttachBLL();
         // da.AddDate = Convert.ToInt32(dr["AddDate"].ToString()); ;
          da.Writer = Server.HtmlEncode(TxtWriter.Text.Trim());
          da.Title = Server.HtmlEncode(TxtTitle.Text.Trim());
          da.Id = id;
          if (classification.SelectedItem.Text == "自然版过刊")
          {
              da.Cid = 1;
          }
          else if (classification.SelectedItem.Text == "社科版过刊")
          {
              da.Cid = 2;
          }
          //else if (classification.SelectedItem.Text == "TRIZ书籍")
          //{
          //    da.Cid = 3;
          //}
          //else if (classification.SelectedItem.Text == "BBS资料")
          //{
          //    da.Cid = 4;
          //}

          if (FileUp.PostedFile.ContentLength == 0)
          { da.FileSaveName = TxtFileName.Text; }
          else
          {
              //以下是上传资料的格式检验
              FileInfo file1 = new FileInfo(FileUp.PostedFile.FileName);
              if (file1.Extension.ToLower() != ".doc" && file1.Extension.ToLower() != ".txt" && file1.Extension.ToLower() != ".zip" && file1.Extension.ToLower() != ".rar")
              {
                  Response.Write("<script>alert('上传的资料格式应为doc/txt/zip/rar格式');history.back(-1);</script>");
                  return;
              }

              string filename = FileUp.PostedFile.FileName;
              filename = System.IO.Path.GetFileName(filename);
              //改文件名
              int index = filename.LastIndexOf(".");
              string lastName = filename.Substring(index, filename.Length - index);//获得文件后缀类型
              //新文件名称,以时间年月日时分秒作为文件名
              string name = TxtTitle.Text.Trim()+DateTime.Now.ToString("hhmmss") + lastName;

              string webFilePath = Server.MapPath("~/Attach/" + TxtFileName.Text);//用来删除原有的资料
              string newpath = Server.MapPath("~/Attach/" + name);//用来保存新上传的资料
              System.IO.FileInfo file = new System.IO.FileInfo(webFilePath);
              if (file.Exists)
              {
                  file.Delete();//删除
              }
              if (!File.Exists(newpath))
              {
                  FileUp.SaveAs(newpath);                              // 使用 SaveAs 方法保存文件  
              }
              da.FileSaveName = name;
          }
          if (downbll.Update(da))
          {
              Response.Write("<script>alert('修改成功');window.location.href='DownMgr.aspx';</script>");
          }
          else
          {
              Response.Write("<script>alert('修改失败');history.back();</script>");
          }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DownMgr.aspx");
        }
    }
}