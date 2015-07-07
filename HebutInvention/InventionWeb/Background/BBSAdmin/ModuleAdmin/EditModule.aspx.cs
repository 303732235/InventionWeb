using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionWeb.Front.BBS.App_Code;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace InventionWeb.Background.BBSAdmin.ModuleAdmin
{
    public partial class EditModule : System.Web.UI.Page
    {
        DataCon myCon = new DataCon();
        DataOperate sqlBind = new DataOperate();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection sqlconn = myCon.getCon();
                sqlconn.Open();
                string sqlstr = "select *  from tb_Module where ModuleID = '"
                   + Request["ModuleID"].ToString() + "'";
                SqlDataAdapter myAdapter = new SqlDataAdapter(sqlstr, sqlconn);
                DataSet myDSModule = new DataSet();
                myAdapter.Fill(myDSModule, "tb_Module");
                DataRowView rowViewModule = myDSModule.Tables["tb_Module"].DefaultView[0];
                txtModTitle.Text = Convert.ToString(rowViewModule["ModuleName"]);
                Describe.Text = Convert.ToString(rowViewModule["ModuleDescribe"]);
                this.Image1.ImageUrl = "~/IndexImages/" + rowViewModule["ModuleImage"];
                sqlconn.Close();
            }
        }
        //修改模块信息
        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (UpImage.PostedFile.ContentLength == 0)
            {
                string sqlstr = "update tb_Module set ModuleName='"
                 + txtModTitle.Text + "',ModuleDescribe='"
                 + Describe.Text + "' where  ModuleID='" + Request["ModuleID"].ToString() + "'";
                if (sqlBind.DataCom(sqlstr))
                { Response.Write("<script>alert('修改成功');window.location.href='ManageMudole.aspx';</script>"); }
                else
                {
                    Response.Write("<script>alert('修改失败');history.back();</script>");
                }
            }
            else
            {
                FileInfo file1 = new FileInfo(UpImage.PostedFile.FileName);
                if (file1.Extension != ".bmp" && file1.Extension != ".jpg" && file1.Extension != ".jpeg" && file1.Extension != ".png" && file1.Extension != ".gif")
                {
                    Response.Write("<script>alert('上传的图片格式应为bmp/jpg/jpeg/png/gif格式');history.back(-1);</script>");
                    return;
                }
                double size = UpImage.PostedFile.ContentLength;
                if (size >= 1024000)
                {
                    Response.Write("<script>alert('添加失败！（图片容量请不要超过1MB）')</script>");
                    return;
                }
                string name = this.Image1.ImageUrl.Substring(14);//原来图片的URL
                string webFilePath = Server.MapPath("~/NewsImages/" + name);//用来删除原有的图片
                string indexpath = Server.MapPath(this.Image1.ImageUrl);
                string filename = UpImage.PostedFile.FileName;
                filename = System.IO.Path.GetFileName(filename);
                //改文件名
                int index = filename.LastIndexOf(".");
                string lastName = filename.Substring(index, filename.Length - index);//获得文件后缀类型
                //新文件名称,以时间年月日时分秒作为文件名
                string newname = "BBSSubject" + DateTime.Now.ToString("yyyyMMddhhmmss") + lastName;
                string newpath = Server.MapPath("~/NewsImages/" + newname);//用来保存新上传的图片
                string newindexpath = Server.MapPath("~/IndexImages/" + newname);
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
                    UpImage.SaveAs(newpath);// 使用 SaveAs 方法保存文件
                    System.Drawing.Image image = System.Drawing.Image.FromFile(newpath);
                    float a = image.Width / image.Height;
                    if (a > 5)
                    {
                        image.Dispose();
                        File.Delete(newpath);
                        Response.Write("<script>alert('高宽比例不合适');</script>");
                        return;
                    }
                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(image, 80, 80);
                    if (!File.Exists(newindexpath))
                    { 
                        bmp.Save(newindexpath);
                    }
                    image.Dispose();
                    bmp.Dispose();
                    File.Delete(newpath);
                }
                string title = Server.HtmlEncode(txtModTitle.Text.Trim());
                string describe = Server.HtmlEncode(Describe.Text.Trim());
                string sqlstr = "update tb_Module set ModuleName='"
                   + title + "',ModuleDescribe='"
                   + describe + "',ModuleImage='"
                   + newname + "' where  ModuleID='" + Request["ModuleID"].ToString() + "'";
                if (sqlBind.DataCom(sqlstr))
                { Response.Write("<script>alert('修改成功');window.location.href='ManageMudole.aspx';</script>"); }
                else
                {
                    Response.Write("<script>alert('修改失败');history.back();</script>");
                }
            }
        }
        //取消
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMudole.aspx");
        }
    }
}