using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;

namespace InventionWeb.Front.NewsImage
{
    public partial class NewsImageDetails : System.Web.UI.Page
    {
        private NewsImageBLL newsimagebll;
        protected void Page_Load(object sender, EventArgs e)
        {
            newsimagebll = new NewsImageBLL();
            if (!IsPostBack)
            {
                string id = Request["id"].ToString();
                listview1(int.Parse(id));
            }
        }
        protected void listview1(int NewsID)
        {
            System.Data.DataTable datatable = newsimagebll.GetNewsDetailsByID(NewsID);
            this.ListView1.DataSource = datatable;
            this.ListView1.DataBind();
         }
    }
}