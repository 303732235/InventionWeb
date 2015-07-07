using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using InventionBLL;

namespace InventionWeb.Front.Policy
{
    public partial class PolicyDetails : System.Web.UI.Page
    {
        private PolicyArticleBLL policyarticlebll;
        protected void Page_Load(object sender, EventArgs e)
        {
            policyarticlebll = new PolicyArticleBLL();
            if (!IsPostBack)
            {
                string id = Request["id"].ToString();
                Detailshow(int.Parse(id));
            }
        }
        protected void Detailshow(int NewsID)
        {
            DataTable datatable = policyarticlebll.GetNewsDetailsByID(NewsID);
            this.ListViewPolicy.DataSource = datatable;
            this.ListViewPolicy.DataBind();
        }
    }
}