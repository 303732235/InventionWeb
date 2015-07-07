using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace InventionWeb.Front.BBS.App_Code
{
    public class DataCon
    {
    public DataCon()
     {   
     }
    private static string sqlCon = System.Configuration.ConfigurationSettings.AppSettings["ConStr"];
    public SqlConnection getCon()
    {      
        SqlConnection myCon = new SqlConnection(sqlCon);
        return myCon;
    }
    }
        
}