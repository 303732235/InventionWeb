using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using System.Data;
using System.Data.SqlClient;
using InventionWeb.Front.BBS.App_Code;

namespace InventionWeb.Front.DownAttach
{
    public partial class Default : System.Web.UI.Page
    {
        DownAttachBLL showyear;
        protected void Page_Load(object sender, EventArgs e)
        {
            ziran();
            sheke();
        }
        public void ziran()//通知通告
        {

            showyear = new DownAttachBLL();
            this.DatalistNotice.DataSource = showyear.Getlist();
            this.DatalistNotice.DataBind();

        }
        public void sheke()//通知通告
        {

            showyear = new DownAttachBLL();
            this.Datalist1.DataSource = showyear.Getlist1();
            this.Datalist1.DataBind();

        }

        public string CutString(string content)
        {
            if (content.Length > 14)
            {
                return content.Substring(0, 13) + "...";
            }
            else
            {
                return "<a onclick=get('"+content+"');>"+content+"</a> ";
            }
        }
        public string CutString1(string content)
        {
            if (content.Length > 14)
            {
                return content.Substring(0, 13) + "...";
            }
            else
            {
                return  content;
            }
        }
    }
}