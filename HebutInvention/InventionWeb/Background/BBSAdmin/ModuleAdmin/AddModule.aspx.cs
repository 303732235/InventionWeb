using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionWeb.Front.BBS.App_Code;
using System.IO;

namespace InventionWeb.Background.BBSAdmin.ModuleAdmin
{
    public partial class AddModule : System.Web.UI.Page
    {
        DataCon myCon = new DataCon();
        DataOperate sqlBind = new DataOperate();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {            
            if (UpImage.HasFile)
            {
                FileInfo file = new FileInfo(UpImage.PostedFile.FileName);
                if (file.Extension.ToLower() != ".bmp" && file.Extension.ToLower() != ".jpg" && file.Extension.ToLower() != ".jpeg" && file.Extension.ToLower() != ".png" && file.Extension.ToLower() != ".gif")
                {
                    Response.Write("<script>alert('上传的图片格式应为bmp/jpg/jpeg/png/gif格式');history.back(-1);</script>");
                    return;
                }
                string filename = UpImage.PostedFile.FileName;
                filename = System.IO.Path.GetFileName(filename);
                //改文件名
                int index = filename.LastIndexOf(".");
                string lastName = filename.Substring(index, filename.Length - index);//获得文件后缀类型
                //新文件名称,以时间年月日时分秒作为文件名
                string newname = "BBSSubject" + DateTime.Now.ToString("yyyyMMddhhmmss") + lastName;
                double size = UpImage.PostedFile.ContentLength;
                if (size >= 1024000)
                {
                    Response.Write("<script>alert('添加失败！（图片容量请不要超过1MB）')</script>");
                    return;
                }
                // 客户端文件路径 ,取得图片的文件名 
                string webFilePath = Server.MapPath("/NewsImages/" + newname);
                if (!File.Exists(webFilePath))
                {
                    UpImage.SaveAs(webFilePath); // 使用 SaveAs 方法保存文件 
                    System.Drawing.Image image = System.Drawing.Image.FromFile(webFilePath);
                    float a = image.Width / image.Height;
                    if (a > 5)
                    {
                        image.Dispose();
                        File.Delete(webFilePath);
                        Response.Write("<script>alert('高宽比例不合适');</script>");
                        return;
                    }
                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(image, 80, 80);
                    string path = Server.MapPath("/IndexImages/" + newname);
                    if (!File.Exists(path))
                    {
                        bmp.Save(path);                        
                    }
                    image.Dispose();
                    bmp.Dispose();
                    File.Delete(webFilePath);
                }
                else
                {
                    Response.Write("<script>alert('上传失败，请重试！')</script>");
                    return;
                }
                string title = Server.HtmlEncode(txtModuleName.Text.Trim());
                string describe = Server.HtmlEncode(Describe.Text.Trim());
                string sqlstr = "insert into tb_Module "
                    + "(ModuleName,ModuleDate,ModuleImage,ModuleDescribe)"
                    + "values('" + title + "','" + DateTime.Now.ToString() + "','" + newname + "','" + describe + "')";
                if (sqlBind.DataCom(sqlstr)) {
                    Response.Write("<script lanuage=javascript>alert('添加成功');location='ManageMudole.aspx'</script>");
                }               
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMudole.aspx");
        }
    }
}