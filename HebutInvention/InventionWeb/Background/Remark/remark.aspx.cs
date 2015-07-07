using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;

namespace InventionWeb.Background.Remark
{
    public partial class remark : System.Web.UI.Page
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
            tel.Text = rm.Tel;
            email.Text = rm.Email;
            address.Text = rm.Address;
            aboutus.Text = rm.About;
            bbshelp.Text = rm.BBShelp;
            Label1.Text = rm.Ziranhelp;
            Label2.Text = rm.Shekehelp;
        }

    }
}