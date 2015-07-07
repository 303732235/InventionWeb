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
    public class AllianceArticleDAO
    {
         public AllianceArticleDAO()//取得用于连接数据库的字符串
        {
          
        }
        static string sql;
        static AllianceArticle a;
        static DataSet ds;
        static DataRow dr;

        public  bool Add(AllianceArticle a)
        {           
           if (DbHelperSQL.Insert(a))
                return true;
            else
                return false;
        }
        public  bool Update(AllianceArticle a)
        {
            if (DbHelperSQL.Update(a))
                return true;
            else
                return false;
        }

        public  bool Delete(object id)
        {
            sql = string.Format("Delete AllianceArticle where id='{0}'", id);
            return DbHelperSQL.ExecSqlCommand(sql);
        }

        public AllianceArticle Find(object id)//从AllianceArticle找到该id的数据，返回一个AllianceArticle类生成的对象
        {
            a = new AllianceArticle();
            string sql = string.Format("select * from AllianceArticle where id='{0}'", id);
            dr = DbHelperSQL.GetDateRow(sql);
            try
            {
                a.AddDate =Convert.ToDateTime(dr["AddDate"].ToString());
                a.Content = dr["Content"].ToString();
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
        public DataTable GetTable(object cid)//查找一个类的数据，返回一个表，暂时没用到
        {
            sql = "select * from AllianceArticle where cid=" + cid + " order by id desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else 
                return ds.Tables[0];
        }
        public IList<AllianceArticle> search(string cid)//搜索该表中，所有与关键字匹配的记录，当cid为空时，搜索整个表
        {
            if (cid == "" || cid == null)
            {
                sql = "select * from AllianceArticle order by id desc";
                ds = DbHelperSQL.GetDataSet(sql);
            }
            else {               
                SqlParameter par = new SqlParameter("@titlesea", SqlDbType.NVarChar, 50);
                par.Value = cid;
                SqlParameter tablename = new SqlParameter("@tablename", SqlDbType.NVarChar, 50);
                tablename.Value = "AllianceArticle";
                SqlParameter[] cmdParms = { tablename, par };
                ds = DbHelperSQL.RunProcedure("AllianceSearch", cmdParms, "AllianceArticle");
            }
            
            List<AllianceArticle> list = new List<AllianceArticle>();
            
            if (ds == null)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    AllianceArticle a = new AllianceArticle();
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

         public IList<AllianceArticle> Getlist(object num)//取AllianceArticle表中前num个记录,以列表的形式返回
        {
            List<AllianceArticle> list = new List<AllianceArticle>();
            if (num != null && num.ToString() != "")
            {
                sql = "select top " + num + " * from AllianceArticle order by id desc"; 
            }
            else {
                sql = "select * from AllianceArticle order by id desc"; 
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
                    AllianceArticle a = new AllianceArticle();
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
        public  IList<AllianceArticle> FindALL(object cid,int num)//找到cid的类中前num的列表
        {
            List<AllianceArticle> list = new List<AllianceArticle>();
            if (cid != null && cid.ToString() != "")
            {
                sql = "select top " + num + " * from AllianceArticle where cid=" + cid + " order by id desc";
            }
            else
            {
                sql = "select top " + num + " * from AllianceArticle order by id desc";
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
                    AllianceArticle a = new AllianceArticle();
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

        public  IList<AllianceArticle> FindALLByHits()
        {
            List<AllianceArticle> list = new List<AllianceArticle>();
            sql = "select top 12 * from AllianceArticle order by hits desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    AllianceArticle a = new AllianceArticle();
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
        public DataTable GetNewsDetailsByID(int mNewsID)//获得某条记录详细信息
        {
            try
            {
                sql = "select * from AllianceArticle where id="+mNewsID;
                ds = DbHelperSQL.GetDataSet(sql);
                return ds.Tables[0];
            }
            catch 
            {
                return null;
            }
        }

      }
}
