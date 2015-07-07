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
    public partial class DownAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TxtDate.Text = DateTime.Now.Year.ToString("d");
                if (Session["UserName"] != null)
                {
                    TxtWriter.Text = Session["UserName"].ToString();
                }  
            }

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            DownAttach da = new DownAttach();
            DownAttachBLL downattachbll = new DownAttachBLL();
           
            string filename = FileUp.PostedFile.FileName;
            filename = System.IO.Path.GetFileName(filename);
            //改文件名
            int index = filename.LastIndexOf(".");
            string lastName = filename.Substring(index, filename.Length - index);//获得文件后缀类型
            //新文件名称,以时间年月日时分秒作为文件名
            string name = DateTime.Now.ToString("yyyyMMddhhmmss") + lastName;
           
             //name = FileUp.FileName;                  // 客户端文件路径
            string webFilePath = Server.MapPath("/Attach/" + name);  // 服务器端文件路径
            if (FileUp.HasFile)
            {
                //以下是上传资料的格式检验
                FileInfo file = new FileInfo(FileUp.PostedFile.FileName);
                if (file.Extension.ToLower() != ".doc" && file.Extension.ToLower() != ".txt" && file.Extension.ToLower() != ".zip" && file.Extension.ToLower() != ".rar" && file.Extension.ToLower() != ".pdf")
                {
                    Response.Write("<script>alert('上传的资料格式应为doc/txt/zip/rar/pdf格式');history.back(-1);</script>");
                    return;
                }
                //double size = FileUp.PostedFile.ContentLength;//文件大小
                //if (size >= 20480000)
                //{
                //    Response.Write("<script>alert('上传失败！（资料容量请不要超过20MB）');history.back();</script>");
                //    return;
                //}
                if (!File.Exists(webFilePath))
                {
                    FileUp.SaveAs(webFilePath);                              // 使用 SaveAs 方法保存文件  
                }
                else
                {
                    Response.Write("<script>alert('上传失败，请重试！')</script>");
                }
            }
            else {
                Response.Write("文件名称为空,请填写要上传文件的名称");
                return;
            }
            da.AddDate = Convert.ToInt32(TxtDate.Text.Trim()
                );
            da.Writer = Server.HtmlEncode(TxtWriter.Text.Trim());
            da.Title = Server.HtmlEncode(TxtTitle.Text.Trim()); 
            da.FileSaveName = name;
            da.FileId = TextBox1.Text.Trim();
            
            if (classification.SelectedItem.Text == "自然版过刊")
            {
                da.Cid = 1;
                if (classfenqi.SelectedItem.Text == "第一期") {
                    da.Type = 1.1F;
                }
                else if (classfenqi.SelectedItem.Text == "第二期")
                {
                    da.Type = 1.2F;
                }
                else if (classfenqi.SelectedItem.Text == "第三期")
                {
                    da.Type = 1.3F;
                }
                else if (classfenqi.SelectedItem.Text == "第四期")
                {
                    da.Type = 1.4F;
                }
                else if (classfenqi.SelectedItem.Text == "第五期")
                {
                    da.Type = 1.5F;
                }
                else if(classfenqi.SelectedItem.Text == "第六期")
                {
                    da.Type = 1.6F;
                }
            }
            else if (classification.SelectedItem.Text == "社科版过刊")
            {
                da.Cid = 2;
                if (classfenqi.SelectedItem.Text == "第一期")
                {
                    da.Type = 2.1F;
                }
                else if (classfenqi.SelectedItem.Text == "第二期")
                {
                    da.Type = 2.2F;
                }
                else if (classfenqi.SelectedItem.Text == "第三期")
                {
                    da.Type = 2.3F;
                }
                else if (classfenqi.SelectedItem.Text == "第四期")
                {
                    da.Type = 2.4F;
                }
                else if (classfenqi.SelectedItem.Text == "第五期")
                {
                    da.Type = 2.5F;
                }
                else if (classfenqi.SelectedItem.Text == "第六期")
                {
                    da.Type = 2.6F;
                }
            }
            //else if (classification.SelectedItem.Text == "BBS资料")
            //{ da.Cid = 4; }
            else 
            {
                da.Cid = 3;
            }
            da.Count = 1;

            if (downattachbll.Add(da))
            {
                Response.Write("<script>alert('添加成功');window.location.href='DownMgr.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败');history.back();</script>");
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DownMgr.aspx");
        }
    }
}