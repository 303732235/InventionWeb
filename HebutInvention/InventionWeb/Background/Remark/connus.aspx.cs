using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
namespace InventionWeb.Background.Remark
{
    public partial class connus : System.Web.UI.Page
    {
        RemarkBLL remarkbll = new RemarkBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        public void bind()
        {
            InventionModel.Remark rm = new InventionModel.Remark();
            rm = remarkbll.GetRemark(1);//返回一个remark实体
            tel.Text = Server.HtmlDecode(rm.Tel);
            email.Text = Server.HtmlDecode(rm.Email);
            address.Text = Server.HtmlDecode(rm.Address);
            aboutus.Text = rm.About;
            bbshelp.Text = rm.BBShelp;
            TextBox1.Text = rm.Ziranhelp;
            TextBox2.Text = rm.Shekehelp;
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            InventionModel.Remark rm = new InventionModel.Remark();
            rm.Id = 1;
            string telstr = Server.HtmlEncode(tel.Text.Trim());
            string emailstr = Server.HtmlEncode(email.Text.Trim());
            string addressstr = Server.HtmlEncode(address.Text.Trim());
            rm.Tel = telstr;
            rm.Email = emailstr;
            rm.Address = addressstr;
            rm.BBShelp = bbshelp.Text.Trim();
            rm.About = aboutus.Text.Trim();
            rm.Ziranhelp = TextBox1.Text.Trim();
            rm.Shekehelp = TextBox2.Text.Trim();
            if (remarkbll.Update(rm))
            {
                Response.Write("<script>alert('修改成功');window.location.href='remark.aspx';</script>");
            }
        }
    }
}