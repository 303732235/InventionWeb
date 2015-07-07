using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;

namespace InventionWeb.Front.BBS.FrontDesk.Login
{
    public partial class Help : System.Web.UI.Page
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
            bbshelp.Text = rm.BBShelp;
        }
    }
}
