using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using InventionBLL;


namespace InventionWeb.Front.Workdt
{
    public partial class PolicyDetails : System.Web.UI.Page
    {
        private WorkdtArticleBLL workdtarticlebll;
        protected void Page_Load(object sender, EventArgs e)
        {
            workdtarticlebll = new WorkdtArticleBLL();
            if (!IsPostBack)
            {
                string id = Request["id"].ToString();
                Detailshow(int.Parse(id));
            }
        }
        protected void Detailshow(int NewsID)
        {
            DataTable datatable = workdtarticlebll.GetNewsDetailsByID(NewsID);
            this.ListViewWorkdt.DataSource = datatable;
            this.ListViewWorkdt.DataBind();
        }
    }
}