using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace InventionWeb.Front.BBS.App_Code
{
    public class DataOperate
    {
        public DataOperate()
        {
        }
        DataCon dataCon = new DataCon();
        public bool DataCom(string sqlstr)
        {
            SqlConnection sqlconn = dataCon.getCon();
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlstr, sqlconn);
            try
            {
                int result=sqlcomm.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                else {
                    return false;
                }
               
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlconn.Close();
            }
        }
        public bool gvBind(GridView gv, string sqlstr)
        {
            SqlConnection sqlconn = dataCon.getCon();
            sqlconn.Open();
            SqlDataAdapter sqldataadapter = new SqlDataAdapter(sqlstr, sqlconn);
            DataSet mydataset = new DataSet();
            sqldataadapter.Fill(mydataset);
            gv.DataSource = mydataset;
            try
            {
                gv.DataBind();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlconn.Close();
            }
        }
        public bool dataBind(DataList dl, string sqlstr)
        {
            SqlConnection sqlconn = dataCon.getCon();
            sqlconn.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(sqlstr, sqlconn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset);
            dl.DataSource = mydataset;
            try
            {
                dl.DataBind();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlconn.Close();
            }
        }
        public DataSet Query(string sqlstr) 
        {
            using (SqlConnection conn = dataCon.getCon()) {
                DataSet ds = new DataSet();
                try
                {
                    conn.Open();
                    SqlDataAdapter command = new SqlDataAdapter(sqlstr, conn);
                    command.Fill(ds, "tb_Card");

                }
                catch (System.Data.SqlClient.SqlException ex) {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
        public DataSet Search(string sqlstr,string searchstr) 
        {
            DataSet ds = new DataSet();
            SqlConnection conn = dataCon.getCon();
            conn.Open();
            SqlCommand sqlcom = new SqlCommand(sqlstr,conn);
            sqlcom.Parameters.AddWithValue("@title","%" + searchstr+ "%");
            using (SqlDataAdapter da = new SqlDataAdapter(sqlcom))
            {
                try
                {
                    da.Fill(ds, "ModuleInfo_View");
                    sqlcom.Parameters.Clear();
                }
                catch(System.Data.SqlClient.SqlException ex) {
                    throw new Exception(ex.Message);
                }
            }
            conn.Close();
            return ds;
        }

    }
}
