using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using InventionBLL;

namespace InventionWeb.Front.Alliance
{
    public partial class AllianceDetails : System.Web.UI.Page
    {
        private AllianceArticleBLL alliancearticlebll;
        protected void Page_Load(object sender, EventArgs e)
        {
            alliancearticlebll = new AllianceArticleBLL();
            if (!IsPostBack)
            {
                string id = Request["id"].ToString();
               listview1(int.Parse(id));
            }
        }
        protected void listview1(int NewsID)
        {
            DataTable datatable = alliancearticlebll.GetNewsDetailsByID(NewsID);
            this.ListView1.DataSource = datatable;
            this.ListView1.DataBind();

        }
    }
}