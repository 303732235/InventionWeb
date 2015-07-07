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
    public class WorkdtArticleDAO
    {

        public WorkdtArticleDAO()//取得用于连接数据库的字符串
        {
            
        }
        static string sql;
        static WorkdtArticle a;
        static DataSet ds;
        static DataRow dr;

        public  bool Add(WorkdtArticle a)
        {
            if (DbHelperSQL.Insert(a))
                return true;
            else
                return false;
        }

        public  bool Update(WorkdtArticle a)
        {
            if (DbHelperSQL.Update(a))
                return true;
            else
                return false;
        }

        public DataTable GetImage()//查找5条记录，用于显示在首页工作动态图片
        {
            //sql = "select top 6 id,title,url from WorkdtArticle where url is not null order by id desc";
            sql = "select id,title,url from NewsImage where url is not null order by id desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else
                return ds.Tables[0];
        }
        public DataTable GetImage1()//查找5条记录，用于显示在首页工作动态图片
        {
            //sql = "select top 6 id,title,url from WorkdtArticle where url is not null order by id desc";
            sql = "select id,title,url from RightImage where url is not null order by id desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else
                return ds.Tables[0];
        }



        public  bool Delete(object id)
        {
            sql = string.Format("Delete WorkdtArticle where id='{0}'", id);
            return DbHelperSQL.ExecSqlCommand(sql);
        }

        public WorkdtArticle Find(object id)//从WorkdtArticle找到该id的数据，返回一个WorkdtArticle类生成的对象
        {
            a = new WorkdtArticle();
            string sql = string.Format("select * from WorkdtArticle where id='{0}'", id);
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
            sql = "select * from WorkdtArticle where cid=" + cid + " order by id desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else 
                return ds.Tables[0];
        }

        public IList<WorkdtArticle> Getlist(object num)//取WorkdtArticle表中前num个记录,以列表的形式返回
        {
            List<WorkdtArticle> list = new List<WorkdtArticle>();
            if (num != null && num.ToString() != "")
            {
                sql = "select top " + num + " * from WorkdtArticle order by id desc"; 
            }
            else {
                sql = "select * from WorkdtArticle order by id desc"; 
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
                    WorkdtArticle a = new WorkdtArticle();
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
        public  IList<WorkdtArticle> FindALL(object cid,int num)//找到cid的类中前num的列表
        {
            List<WorkdtArticle> list = new List<WorkdtArticle>();
            if (cid != null && cid.ToString() != "")
            {
                sql = "select top " + num + " * from WorkdtArticle where cid=" + cid + " order by id desc";
            }
            else
            {
                sql = "select top " + num + " * from WorkdtArticle order by id desc";
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
                    WorkdtArticle a = new WorkdtArticle();
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
       public  IList<WorkdtArticle> FindALLByHits()
        {
            List<WorkdtArticle> list = new List<WorkdtArticle>();
            sql = "select top 12 * from WorkdtArticle order by hits desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    WorkdtArticle a = new WorkdtArticle();
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
                sql = "select * from WorkdtArticle where id="+mNewsID;
                ds = DbHelperSQL.GetDataSet(sql);
                return ds.Tables[0];
            }
            catch 
            {
                return null;
            }
        }
        public IList<WorkdtArticle> search(string cid)//搜索该表中，所有与关键字匹配的记录，当cid为空时，搜索整个表
        {
            if (cid == "" || cid == null)
            {
                sql = "select * from WorkdtArticle order by id desc";
                ds = DbHelperSQL.GetDataSet(sql);
            }
            else
            {
                sql = "select * from WorkdtArticle where title like '%" + cid + "%' order by id desc";

                SqlParameter par = new SqlParameter("@titlesea", SqlDbType.NVarChar, 50);
                par.Value = cid;
                SqlParameter tablename = new SqlParameter("@tablename", SqlDbType.NVarChar, 50);
                tablename.Value = "WorkdtArticle";
                SqlParameter[] cmdParms = { tablename, par };
                ds = DbHelperSQL.RunProcedure("WorkdtSearch", cmdParms, "WorkdtArticle");

            }
            List<WorkdtArticle> list = new List<WorkdtArticle>();
            if (ds == null)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    WorkdtArticle a = new WorkdtArticle();
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
