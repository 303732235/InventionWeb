using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using InventionModel;
using InventionBLL;

namespace InventionWeb.Background.ImageRight
{
    public partial class RightAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtDate.Text = DateTime.Now.ToString("d");

        }
        protected void Add_Click(object sender, EventArgs e)
        {
            RightImage na = new RightImage();
            NewsImageBLL newsimagebll = new NewsImageBLL();
            string newname = "";
            if (FileUp.HasFile)
            {
                FileInfo file = new FileInfo(FileUp.PostedFile.FileName);
                if (file.Extension.ToLower() != ".bmp" && file.Extension.ToLower() != ".jpg" && file.Extension.ToLower() != ".jpeg" && file.Extension.ToLower() != ".png" && file.Extension.ToLower() != ".gif")
                {
                    Response.Write("<script>alert('上传的资料格式应为bmp/jpg/jpeg/png/gif格式');history.back(-1);</script>");
                    return;
                }

                string filename = FileUp.PostedFile.FileName;
                filename = System.IO.Path.GetFileName(filename);
                //改文件名
                int index = filename.LastIndexOf(".");
                string lastName = filename.Substring(index, filename.Length - index);//获得文件后缀类型
                //新文件名称,以时间年月日时分秒作为文件名
                newname = "RightImage" + DateTime.Now.ToString("yyyyMMddhhmmss") + lastName;
                double size = FileUp.PostedFile.ContentLength;
                string webFilePath = Server.MapPath("/NewsImages/" + newname);
                if (!File.Exists(webFilePath))
                {
                    FileUp.SaveAs(webFilePath); // 使用 SaveAs 方法保存文件 
                    System.Drawing.Image image = System.Drawing.Image.FromFile(webFilePath);
                    float a = image.Width / image.Height;
                    if (a > 5)
                    {
                        image.Dispose();
                        File.Delete(webFilePath);
                        Response.Write("<script>alert('高宽比例不合适');</script>");
                        return;
                    }
                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(image, 168, 155);
                    string path = Server.MapPath("/IndexImages/" + newname);
                    if (!File.Exists(path))
                    {
                        bmp.Save(path);
                    }
                    image.Dispose();
                    bmp.Dispose();
                }
                else
                {
                    Response.Write("<script>alert('上传失败，请重试！')</script>");
                    return;
                }
            }
            na.Url = newname;
            na.AddDate = Convert.ToDateTime(TxtDate.Text);

            string title = Server.HtmlEncode(TxtTitle.Text.Trim());
          
            na.Title = title;
            if (newsimagebll.Add1(na))
            {
                Response.Write("<script>alert('添加成功');window.location.href='RightMgr.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败');history.back();</script>");
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("RightMgr.aspx");
        }
    }
}