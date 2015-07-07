using System;
using System.IO;
using InventionBLL;
using InventionModel;
namespace InventionWeb.Background.NewImageAdmin
{
    public partial class NewsImageEdit : System.Web.UI.Page
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
        
         NewsImageBLL newsimagelbll = new NewsImageBLL();
         NewsImage ni = new NewsImage();
         ni = newsimagelbll.GetNewsImage(id);
         TxtTitle.Text = ni.Title;
         this.Image1.ImageUrl = "~/IndexImages/"+ni.Url;
         TxtDate.Text = ni.AddDate.ToString("d");
        
     }

      protected void Save_Click(object sender, EventArgs e)
      {
          object id = Request.QueryString["id"];//有待改善不安全
          NewsImage ni = new NewsImage();
          NewsImageBLL newsimagebll = new NewsImageBLL();
          string title = Server.HtmlEncode(TxtTitle.Text.Trim());
          ni.AddDate = Convert.ToDateTime(TxtDate.Text);         
         
          ni.Title = title;
          ni.Id = id;
          string name=this.Image1.ImageUrl.Substring(14);//原来图片的URL
           if (FileUp.PostedFile.ContentLength == 0)
          {             
              ni.Url=name;
          }
          else
          {
              FileInfo file1 = new FileInfo(FileUp.PostedFile.FileName);
              if (file1.Extension.ToLower() != ".bmp" && file1.Extension.ToLower() != ".jpg" && file1.Extension.ToLower() != ".jpeg" && file1.Extension.ToLower() != ".png" && file1.Extension.ToLower() != ".gif")
              {
                  Response.Write("<script>alert('上传的资料格式应为bmp/jpg/jpeg/png/gif格式');history.back(-1);</script>");
                  return;
              }

              string webFilePath = Server.MapPath("~/NewsImages/"+name);//用来删除原有的图片
              string indexpath = Server.MapPath(this.Image1.ImageUrl);

              string filename = FileUp.PostedFile.FileName;
              filename = System.IO.Path.GetFileName(filename);
              //改文件名
              int index = filename.LastIndexOf(".");
              string lastName = filename.Substring(index, filename.Length - index);//获得文件后缀类型
              //新文件名称,以时间年月日时分秒作为文件名
              string newname = "NewImage" + DateTime.Now.ToString("yyyyMMddhhmmss") + lastName;

              string newpath = Server.MapPath("/NewsImages/" + newname);//用来保存新上传的图片
              string newindexpath = Server.MapPath("/IndexImages/" + newname);
              System.IO.FileInfo file = new System.IO.FileInfo(webFilePath);
              System.IO.FileInfo indexfile = new System.IO.FileInfo(indexpath);
              if (file.Exists)
              {
                  file.Delete();//删除
              }

              if (indexfile.Exists)
              {
                  indexfile.Delete();//删除
              }
              if (!File.Exists(newpath))
              {
                  FileUp.SaveAs(newpath);// 使用 SaveAs 方法保存文件
                  System.Drawing.Image image = System.Drawing.Image.FromFile(newpath);
                  float a = image.Width / image.Height;
                  if (a > 5)
                  {
                      image.Dispose();
                      File.Delete(newpath);
                      Response.Write("<script>alert('高宽比例不合适');</script>");
                      return;
                  }
                  System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(image, 168, 155);
                  if (!File.Exists(newindexpath))
                      bmp.Save(newindexpath);
                  image.Dispose();
                  bmp.Dispose();
              }
              ni.Url = newname;
          }
          if (newsimagebll.Update(ni))
          {
              Response.Write("<script>alert('更新成功');window.location.href='NewsImageMgr.aspx';</script>");
          }
          else
          {
              Response.Write("<script>alert('更新失败');history.back();</script>");
          }
      }

      protected void Cancel_Click(object sender, EventArgs e)
      {
          Response.Redirect("NewsImageMgr.aspx");
      }

    }
}