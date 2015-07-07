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
    public class NoticeArticleDAO
    {

        
      public NoticeArticleDAO()//取得用于连接数据库的字符串
        {
         
        }
        static string sql;
        static NoticeArticle a;
        static DataSet ds;
        static DataRow dr;

        public  bool Add(NoticeArticle a)
        {
            if (DbHelperSQL.Insert(a))
                return true;
            else
                return false;
        }

        public  bool Update(NoticeArticle a)
        {
            if (DbHelperSQL.Update(a))
                return true;
            else
                return false;
        }

        public  bool Delete(object id)
        {
            sql = string.Format("Delete NoticeArticle where id='{0}'", id);
            return DbHelperSQL.ExecSqlCommand(sql);
        }

        public NoticeArticle Find(object id)//从NoticeArticle找到该id的数据，返回一个NoticeArticle类生成的对象
        {
            a = new NoticeArticle();
            string sql = string.Format("select * from NoticeArticle where id='{0}'", id);
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
            sql = "select * from NoticeArticle where cid=" + cid + " order by id desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else 
                return ds.Tables[0];
        }

        public IList<NoticeArticle> Getlist(object num)//取NoticeArticle表中前num个记录,以列表的形式返回
        {
            List<NoticeArticle> list = new List<NoticeArticle>();
            if (num != null && num.ToString() != "")
            {
                sql = "select top " + num + " * from NoticeArticle order by id desc"; 
            }
            else {
                sql = "select * from NoticeArticle order by id desc"; 
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
                    NoticeArticle a = new NoticeArticle();
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
        public IList<DownAttach> Getlist1(object num)//取DownAttach表自然版（cid=1）中前num个记录,以列表的形式返回
        {
            List<DownAttach> list = new List<DownAttach>();
            if (num != null && num.ToString() != "")
            {
                sql = "select top " + num + " * from DownAttach where cid=1 order by id desc";
            }
            else
            {
                sql = "select * from DownAttach where cid=1 order by id desc";
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
                    DownAttach a = new DownAttach();
                    a.AddDate = Convert.ToInt32(dr["AddDate"].ToString());
                    a.Type = Convert.ToSingle(dr["type"]);
                    a.Id = dr["id"];
                    a.Title = dr["Title"].ToString();
                   
                    list.Add(a);
                }
                return list;
            }
        }
        public IList<DownAttach> Getlist2(object num)//取DownAttach表社科版（cid=0）中前num个记录,以列表的形式返回
        {
            List<DownAttach> list = new List<DownAttach>();
            if (num != null && num.ToString() != "")
            {
                sql = "select top " + num + " * from DownAttach where cid=2 order by id desc";
            }
            else
            {
                sql = "select * from DownAttach where cid=2 order by id desc";
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
                    DownAttach a = new DownAttach();
                    a.AddDate = Convert.ToInt32(dr["AddDate"].ToString());
                    a.Type = Convert.ToSingle(dr["type"]);
                    a.Id = dr["id"];
                    a.Title = dr["Title"].ToString();

                    list.Add(a);
                }
                return list;
            }
        }
        public  IList<NoticeArticle> FindALL(object cid,int num)//找到cid的类中前num的列表
        {
            List<NoticeArticle> list = new List<NoticeArticle>();
            if (cid != null && cid.ToString() != "")
            {
                sql = "select top " + num + " * from NoticeArticle where cid=" + cid + " order by id desc";
            }
            else
            {
                sql = "select top " + num + " * from NoticeArticle order by id desc";
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
                    NoticeArticle a = new NoticeArticle();
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

        public  IList<NoticeArticle> FindALLByHits()
        {
            List<NoticeArticle> list = new List<NoticeArticle>();
            sql = "select top 12 * from NoticeArticle order by hits desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    NoticeArticle a = new NoticeArticle();
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
                sql = "select * from NoticeArticle where id="+mNewsID;
                ds = DbHelperSQL.GetDataSet(sql);
                return ds.Tables[0];
            }
            catch 
            {
                return null;
            }
        }

        public IList<NoticeArticle> search(string cid)//搜索该表中，所有与关键字匹配的记录，当cid为空时，搜索整个表
        {
            if (cid == "" || cid == null)
            {
                sql = "select * from NoticeArticle order by id desc";
                ds = DbHelperSQL.GetDataSet(sql);
            }
            else
            {
                
                SqlParameter par = new SqlParameter("@titlesea", SqlDbType.NVarChar, 50);
                par.Value = cid;
                SqlParameter tablename = new SqlParameter("@tablename", SqlDbType.NVarChar, 50);
                tablename.Value = "NoticeArticle";
                SqlParameter[] cmdParms = { tablename,par};
                ds = DbHelperSQL.RunProcedure("NoticeSearch", cmdParms, "NoticeArticle");
            }

            List<NoticeArticle> list = new List<NoticeArticle>();
            
            if (ds == null)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    NoticeArticle a = new NoticeArticle();
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
