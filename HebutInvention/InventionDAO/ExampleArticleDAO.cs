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
    public class ExampleArticleDAO
    {
         public ExampleArticleDAO()//取得用于连接数据库的字符串
        {
          
        }
        static string sql;
        static ExampleArticle a;
        static DataSet ds;
        static DataRow dr;

        public  bool Add(ExampleArticle a)
        {
             if (DbHelperSQL.Insert(a))
                return true;
            else
                return false;
        }

        public  bool Update(ExampleArticle a)
        {
            if (DbHelperSQL.Update(a))
                return true;
            else
                return false;
        }

        public  bool Delete(object id)
        {
            sql = string.Format("Delete ExampleArticle where id='{0}'", id);
            return DbHelperSQL.ExecSqlCommand(sql);
        }

        public ExampleArticle Find(object id)//从ExampleArticle找到该id的数据，返回一个ExampleArticle类生成的对象
        {
            a = new ExampleArticle();
            string sql = string.Format("select * from ExampleArticle where id='{0}'", id);
            dr = DbHelperSQL.GetDateRow(sql);
            try
            {
                a.AddDate =Convert.ToDateTime(dr["AddDate"].ToString());
                a.Content = dr["Content"].ToString();
                a.Id = dr["id"];
                a.Title = dr["Title"].ToString();
                a.Writer = dr["Writer"].ToString();
                a.Url = dr["Url"].ToString();
                return a;
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetTable(object cid)//查找一个类的数据，返回一个表，暂时没用到
        {
            sql = "select * from ExampleArticle where cid=" + cid + " order by id desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else 
                return ds.Tables[0];
        }
     
        public IList<ExampleArticle> Getlist(object num)//取ExampleArticle表中前num个记录,以列表的形式返回
        {
            List<ExampleArticle> list = new List<ExampleArticle>();
            if (num != null && num.ToString() != "")
            {
                sql = "select top " + num + " * from ExampleArticle order by id desc";
            }
            else {
                sql = "select * from ExampleArticle where url is not null order by id desc";
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
                    ExampleArticle a = new ExampleArticle();
                    a.AddDate = Convert.ToDateTime(dr["addDate"].ToString());
                    a.Content = dr["Content"].ToString();
                    a.Id = dr["id"];
                    a.Title = dr["Title"].ToString();
                    a.Writer = dr["Writer"].ToString();
                    a.Url = dr["Url"].ToString();
                    list.Add(a);
                }
                return list;
            }
        }
        public  IList<ExampleArticle> FindALL(object cid,int num)//找到cid的类中前num的列表
        {
            List<ExampleArticle> list = new List<ExampleArticle>();
            if (cid != null && cid.ToString() != "")
            {
                sql = "select top " + num + " * from ExampleArticle where cid=" + cid + " order by id desc";
            }
            else
            {
                sql = "select top " + num + " * from ExampleArticle order by id desc";
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
                    ExampleArticle a = new ExampleArticle();
                    a.AddDate = Convert.ToDateTime(dr["addDate"].ToString());
                    a.Content = dr["Content"].ToString();
                    a.Id = dr["id"];
                    a.Title = dr["Title"].ToString();
                    a.Writer = dr["Writer"].ToString();
                    a.Url = dr["Url"].ToString();
                    list.Add(a);
                }
                return list;
            }
        }

        public  IList<ExampleArticle> FindALLByHits()
        {
            List<ExampleArticle> list = new List<ExampleArticle>();
            sql = "select top 12 * from ExampleArticle order by hits desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ExampleArticle a = new ExampleArticle();
                    a.AddDate = Convert.ToDateTime(dr["addDate"].ToString());
                    a.Content = dr["Content"].ToString();
                    a.Id = dr["id"];
                    a.Title = dr["Title"].ToString();
                    a.Writer = dr["Writer"].ToString();
                    a.Url = dr["Url"].ToString();
                    list.Add(a);
                }
                return list;
            }
        }
        public DataTable GetNewsDetailsByID(int mNewsID)//获得某条记录详细信息
        {
            try
            {
                sql = "select * from ExampleArticle where id="+mNewsID;
                ds = DbHelperSQL.GetDataSet(sql);
                return ds.Tables[0];
            }
            catch 
            {
                return null;
            }
        }

        public IList<ExampleArticle> search(string cid)//搜索该表中，所有与关键字匹配的记录，当cid为空时，搜索整个表
        {
            if (cid == "" || cid == null)
            {
                sql = "select * from ExampleArticle order by id desc";
                ds = DbHelperSQL.GetDataSet(sql);
            }
            else
            {
                sql = "select * from ExampleArticle where title like '%" + cid + "%' order by id desc";
                SqlParameter par = new SqlParameter("@titlesea", SqlDbType.NVarChar, 50);
                par.Value = cid;
                SqlParameter tablename = new SqlParameter("@tablename", SqlDbType.NVarChar, 50);
                tablename.Value = "ExampleArticle";
                SqlParameter[] cmdParms = { tablename, par };
                ds = DbHelperSQL.RunProcedure("ExampleSearch", cmdParms, "ExampleArticle");
            }
            List<ExampleArticle> list = new List<ExampleArticle>();
           
            if (ds == null)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ExampleArticle a = new ExampleArticle();
                    a.AddDate = Convert.ToDateTime(dr["addDate"].ToString());
                    a.Content = dr["Content"].ToString();
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
