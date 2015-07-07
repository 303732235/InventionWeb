using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventionCommon;
using InventionModel;
using System.Data;
using System.Data.SqlClient;
namespace InventionDAO
{
   public  class NewsArticleDAO
    {
       public NewsArticleDAO()
        {
          
        }
        static string sql;
        static NewsArticle a;
        static DataSet ds;
        static DataRow dr;

        public  bool Add(NewsArticle a)
        {
            if (DbHelperSQL.Insert(a))
                return true;
            else
                return false;
        }

        public  bool Update(NewsArticle a)
        {
            if (DbHelperSQL.Update(a))
                return true;
            else
                return false;
        }

        public  bool Delete(object id)
        {
            sql = string.Format("Delete NewsArticle where id='{0}'", id);
            return DbHelperSQL.ExecSqlCommand(sql);
        }

        public  NewsArticle Find(object id)
        {
            a = new NewsArticle();
            string sql = string.Format("select * from NewsArticle where id='{0}'", id);
            dr = DbHelperSQL.GetDateRow(sql);
            try
            {
                a.AddDate =Convert.ToDateTime(dr["AddDate"].ToString());
                a.Cid = dr["Cid"];
                a.Content = dr["Content"].ToString();
                a.Hits=Convert.ToInt32(dr["hits"]);
                a.Id = dr["id"];
                a.Title = dr["Title"].ToString();
                a.Writer = dr["Writer"].ToString();
                return a;
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetTable(object cid)
        {
            sql = "select * from NewsArticle where cid=" + cid + " order by id desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else 
                return ds.Tables[0];
        }
        public IList<NewsArticle> FindALL(object cid)
        {
            List<NewsArticle> list = new List<NewsArticle>();
            if (cid != null && cid.ToString() != "")
            {
                sql = "select * from NewsArticle where cid="+cid + " order by id desc";
            }
            else
            {
                sql = "select * from NewsArticle order by id desc";
            }


            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    NewsArticle a = new NewsArticle();
                    a.AddDate = Convert.ToDateTime(dr["addDate"].ToString());
                    a.Cid = dr["cid"];
                    a.Content = dr["Content"].ToString();
                    a.Hits = Convert.ToInt32(dr["hits"]);
                    a.Id = dr["id"];
                    a.Title = dr["Title"].ToString();
                    a.Writer = dr["Writer"].ToString();
                    list.Add(a);
                }
                return list;
            }
        }

        public  IList<NewsArticle> FindALL(object cid,int num)
        {
            List<NewsArticle> list = new List<NewsArticle>();
            if (cid != null && cid.ToString() != "")
            {
                sql = "select top " + num + " * from NewsArticle where cid=" + cid + " order by id desc";
            }
            else
            {
                sql = "select top " + num + " * from NewsArticle order by id desc";
            }


            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    NewsArticle a = new NewsArticle();
                    a.AddDate = Convert.ToDateTime(dr["addDate"].ToString());
                    a.Cid = dr["cid"];
                    a.Content = dr["Content"].ToString();
                    a.Hits = Convert.ToInt32(dr["hits"]);
                    a.Id = dr["id"];
                    a.Title = dr["Title"].ToString();
                    a.Writer = dr["Writer"].ToString();
                    list.Add(a);
                }
                return list;
            }
        }

        public  IList<NewsArticle> FindALLByHits()
        {
            List<NewsArticle> list = new List<NewsArticle>();
            sql = "select top 12 * from NewsArticle order by hits desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    NewsArticle a = new NewsArticle();
                    a.AddDate = Convert.ToDateTime(dr["addDate"].ToString());
                    a.Cid = dr["cid"];
                    a.Content = dr["Content"].ToString();
                    a.Hits = Convert.ToInt32(dr["hits"]);
                    a.Id = dr["id"];
                    a.Title = dr["Title"].ToString();
                    a.Writer = dr["Writer"].ToString();
                    list.Add(a);
                }
                return list;
            }
        }
        public DataTable GetNewsDetailsByID(int mNewsID)//获得某条记录详细信息
        {
            try
            {
                sql = "select * from NewsArticle where id="+mNewsID;
                ds = DbHelperSQL.GetDataSet(sql);
                return ds.Tables[0];
            }
            catch 
            {
                return null;
            }
        }

        public IList<NewsArticle> search(string cid)//搜索该表中，所有与关键字匹配的记录，当cid为空时，搜索整个表
        {
            if (cid == "" || cid == null)
            {
                sql = "select * from NewsArticle order by id desc";
                ds = DbHelperSQL.GetDataSet(sql);
            }
            else
            {
                SqlParameter par = new SqlParameter("@titlesea", SqlDbType.NVarChar, 50);
                par.Value = cid;
                SqlParameter tablename = new SqlParameter("@tablename", SqlDbType.NVarChar, 50);
                tablename.Value = "NewsArticle";
                SqlParameter[] cmdParms = { tablename, par };
                ds = DbHelperSQL.RunProcedure("NewsSearch", cmdParms, "NewsArticle");
            }
            List<NewsArticle> list = new List<NewsArticle>();
            if (ds == null)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    NewsArticle a = new NewsArticle();
                    a.AddDate = Convert.ToDateTime(dr["addDate"].ToString());
                    //a.Cid = dr["cid"];
                    a.Content = dr["Content"].ToString();
                    //a.Hits = Convert.ToInt32(dr["hits"]);
                    a.Id = dr["id"];
                    a.Title = dr["Title"].ToString();
                    a.Writer = dr["Writer"].ToString();
                    list.Add(a);
                }
                return list;
            }
        }
     }
}
