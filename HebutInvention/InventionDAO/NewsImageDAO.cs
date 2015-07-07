using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventionCommon;
using InventionModel;
using System.Data;
namespace InventionDAO
{
   public class NewsImageDAO
    {
       public NewsImageDAO()
        {
           
        }
       static string sql;
       static NewsImage a;
       static DataSet ds;
       static DataRow dr;
       public bool Add(NewsImage a)
       {
           if (DbHelperSQL.Insert(a))
               return true;
           else
               return false;
       }
       public bool Add1(RightImage a)
       {
           if (DbHelperSQL.Insert(a))
               return true;
           else
               return false;
       }
       public IList<NewsImage> FindALL()
       {
           List<NewsImage> list = new List<NewsImage>();
           sql = "select * from NewsImage order by id desc";
           ds = DbHelperSQL.GetDataSet(sql);
           if (ds == null)
           {
               return null;
           }
           else
           {
               foreach (DataRow dr in ds.Tables[0].Rows)
               {
                   NewsImage a = new NewsImage();
                   a.AddDate = Convert.ToDateTime(dr["addDate"].ToString());
                   a.Url = dr["url"].ToString();
                   a.Content = dr["content"].ToString();
                   a.Id = dr["id"];
                   a.Title = dr["title"].ToString();
                   list.Add(a);
               }
               return list;
           }
       }
       public IList<RightImage> FindALL1()
       {
           List<RightImage> list = new List<RightImage>();
           sql = "select * from RightImage order by id desc";
           ds = DbHelperSQL.GetDataSet(sql);
           if (ds == null)
           {
               return null;
           }
           else
           {
               foreach (DataRow dr in ds.Tables[0].Rows)
               {
                   RightImage a = new RightImage();
                   a.AddDate = Convert.ToDateTime(dr["addDate"].ToString());
                   a.Url = dr["url"].ToString();
                   a.Content = dr["content"].ToString();
                   a.Id = dr["id"];
                   a.Title = dr["title"].ToString();
                   list.Add(a);
               }
               return list;
           }
       }
       public NewsImage Find(object id)
       {
           a = new NewsImage();
           string sql = string.Format("select * from NewsImage where id='{0}'", id);
           dr = DbHelperSQL.GetDateRow(sql);
           try
           {
               a.AddDate = Convert.ToDateTime(dr["AddDate"].ToString());
               a.Content = dr["content"].ToString();
               a.Id = dr["id"];
               a.Title = dr["title"].ToString();
               a.Url = dr["url"].ToString();
               return a;
           }
           catch
           {
               return null;
           }
       }
       public RightImage Find1(object id)
       {
           RightImage a = new RightImage();
           string sql = string.Format("select * from RightImage where id='{0}'", id);
           dr = DbHelperSQL.GetDateRow(sql);
           try
           {
               a.AddDate = Convert.ToDateTime(dr["AddDate"].ToString());
               a.Content = dr["content"].ToString();
               a.Id = dr["id"];
               a.Title = dr["title"].ToString();
               a.Url = dr["url"].ToString();
               return a;
           }
           catch
           {
               return null;
           }
       }

       public bool Update(NewsImage a)
       {
           if (DbHelperSQL.Update(a))
               return true;
           else
               return false;
       }
       public bool Update1(RightImage a)
       {
           if (DbHelperSQL.Update(a))
               return true;
           else
               return false;
       }
       public bool Delete(object id)
       {
           sql = string.Format("Delete NewsImage where id='{0}'", id);
           return DbHelperSQL.ExecSqlCommand(sql);
       }
       public bool Delete1(object id)
       {
           sql = string.Format("Delete RightImage where id='{0}'", id);
           return DbHelperSQL.ExecSqlCommand(sql);
       }
       public DataTable Gettable(object num)//读取表中前num个记录
       {
           sql = "select top " + num + " * from NewsImage order by id desc";
           ds = DbHelperSQL.GetDataSet(sql);
           if (ds == null)
           {
               return null;
           }
           else
           {
               return ds.Tables[0];
           }
       }
       public DataTable GetNewsDetailsByID(int mNewsID)//获得某条记录详细信息
       {
           try
           {
               sql = "select * from NewsImage where id=" + mNewsID;
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
