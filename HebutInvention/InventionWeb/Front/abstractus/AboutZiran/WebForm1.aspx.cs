using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;

namespace InventionWeb.Front.abstractus.AboutZiran
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private RemarkBLL remrkbll;
        protected void Page_Load(object sender, EventArgs e)
        {
            remrkbll = new RemarkBLL();
            if (!IsPostBack)
            {
                bind();
            }
        }
        public void bind()
        {
            InventionModel.Remark rm = new InventionModel.Remark();
            rm = remrkbll.GetRemark(1);//返回一个remark实体
            about.Text = rm.Ziranhelp;

        }
    }
}