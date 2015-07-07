﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventionCommon;
using InventionModel;
using System.Data;
using System.Data.SqlClient;

namespace InventionDAO
{
   public class PolicyArticleDAO
    {
        
        public PolicyArticleDAO()//取得用于连接数据库的字符串
        {
          
        }
        static string sql;
        static PolicyArticle a;
        static DataSet ds;
        static DataRow dr;

        public  bool Add(PolicyArticle a)
        {
             if (DbHelperSQL.Insert(a))
                return true;
            else
                return false;
        }

        public  bool Update(PolicyArticle a)
        {
            if (DbHelperSQL.Update(a))
                return true;
            else
                return false;
        }

        public  bool Delete(object id)
        {
            sql = string.Format("Delete PolicyArticle where id='{0}'", id);
            return DbHelperSQL.ExecSqlCommand(sql);
        }

        public PolicyArticle Find(object id)//从PolicyArticle找到该id的数据，返回一个PolicyArticle类生成的对象
        {
            a = new PolicyArticle();
            string sql = string.Format("select * from PolicyArticle where id='{0}'", id);
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
            sql = "select * from PolicyArticle where cid=" + cid + " order by id desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else 
                return ds.Tables[0];
        }

        public IList<PolicyArticle> Getlist(object num)//取PolicyArticle表中前num个记录,以列表的形式返回
        {
            List<PolicyArticle> list = new List<PolicyArticle>();
            if (num != null && num.ToString() != "")
            {
                sql = "select top " + num + " * from PolicyArticle order by id desc"; 
            }
            else {
                sql = "select * from PolicyArticle order by id desc"; 
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
                    PolicyArticle a = new PolicyArticle();
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
        public  IList<PolicyArticle> FindALL(object cid,int num)//找到cid的类中前num的列表
        {
            List<PolicyArticle> list = new List<PolicyArticle>();
            if (cid != null && cid.ToString() != "")
            {
                sql = "select top " + num + " * from PolicyArticle where cid=" + cid + " order by id desc";
            }
            else
            {
                sql = "select top " + num + " * from PolicyArticle order by id desc";
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
                    PolicyArticle a = new PolicyArticle();
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

        public  IList<PolicyArticle> FindALLByHits()
        {
            List<PolicyArticle> list = new List<PolicyArticle>();
            sql = "select top 12 * from PolicyArticle order by hits desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    PolicyArticle a = new PolicyArticle();
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
                sql = "select * from PolicyArticle where id="+mNewsID;
                ds = DbHelperSQL.GetDataSet(sql);
                return ds.Tables[0];
            }
            catch 
            {
                return null;
            }
        }

        public IList<PolicyArticle> search(string cid)//搜索该表中，所有与关键字匹配的记录，当cid为空时，搜索整个表
        {
            if (cid == "" || cid == null)
            {
                sql = "select * from PolicyArticle order by id desc";
                ds = DbHelperSQL.GetDataSet(sql);
            }
            else
            {
                sql = "select * from ExampleArticle where title like '%" + cid + "%' order by id desc";
                SqlParameter par = new SqlParameter("@titlesea", SqlDbType.NVarChar, 50);
                par.Value = cid;
                SqlParameter tablename = new SqlParameter("@tablename", SqlDbType.NVarChar, 50);
                tablename.Value = "PolicyArticle";
                SqlParameter[] cmdParms = { tablename, par };
                ds = DbHelperSQL.RunProcedure("PolicySearch", cmdParms, "PolicyArticle");
            }
            List<PolicyArticle> list = new List<PolicyArticle>();            
            if (ds == null)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    PolicyArticle a = new PolicyArticle();
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
