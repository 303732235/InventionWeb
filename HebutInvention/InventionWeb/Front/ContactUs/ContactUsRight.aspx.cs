using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using InventionBLL;

namespace InventionWeb.Front.ContactUs
{
    public partial class ContactUsRight : System.Web.UI.Page
    {
        private RemarkBLL remrkbll;
        protected void Page_Load(object sender, EventArgs e)
        {
            remrkbll = new RemarkBLL();
            if (!IsPostBack) {
                bind();
            }
        }
        public void bind() {
            InventionModel.Remark rm = new InventionModel.Remark();
            rm = remrkbll.GetRemark(1);//返回一个remark实体
            tel.Text = rm.Tel;
            email.Text = rm.Email;
            address.Text = rm.Address;
        }
    }
}