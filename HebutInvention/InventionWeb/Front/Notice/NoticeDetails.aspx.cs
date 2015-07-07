using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using InventionBLL;

namespace InventionWeb.Front.Notice
{
    public partial class NoticeDetails : System.Web.UI.Page
    {
        private NoticeArticleBLL noticearticlebll;
        protected void Page_Load(object sender, EventArgs e)
        {
            noticearticlebll = new NoticeArticleBLL();
            if (!IsPostBack)
            {
                string id = Request["id"].ToString();
                Detailshow(int.Parse(id));
            }
        }

        protected void Detailshow(int NewsID)
        {
            DataTable datatable = noticearticlebll.GetNewsDetailsByID(NewsID);
            this.ListViewNotice.DataSource = datatable;
            this.ListViewNotice.DataBind();
        }
    }
}