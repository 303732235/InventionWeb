using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using InventionBLL;

namespace InventionWeb.Front.News
{
    public partial class NewsDetails : System.Web.UI.Page
    {
        private NewsArticleBLL newsarticlebll;
        protected void Page_Load(object sender, EventArgs e)
        {
            newsarticlebll = new NewsArticleBLL();
            if (!IsPostBack)
            {
                string id = Request["id"].ToString();
                Detailshow(int.Parse(id));
            }
        }

        protected void Detailshow(int NewsID)
        {
            DataTable datatable = newsarticlebll.GetNewsDetailsByID(NewsID);
            this.ListViewNews.DataSource = datatable;
            this.ListViewNews.DataBind();
        }
    }
}

