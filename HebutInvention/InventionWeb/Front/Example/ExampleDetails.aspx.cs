using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using InventionBLL;


namespace InventionWeb.Front.Example
{
    public partial class ExampleDetails : System.Web.UI.Page
    {
        private ExampleArticleBLL examplearticlebll;
        protected void Page_Load(object sender, EventArgs e)
        {
            examplearticlebll = new ExampleArticleBLL();
            if (!IsPostBack)
            {
                string id = Request["id"].ToString();
                Detailshow(int.Parse(id));
            }
        }

        protected void Detailshow(int NewsID)
        {
            DataTable datatable = examplearticlebll.GetNewsDetailsByID(NewsID);
            this.ListViewExample.DataSource = datatable;
            this.ListViewExample.DataBind();
        }
    }
}