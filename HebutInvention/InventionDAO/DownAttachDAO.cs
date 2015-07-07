using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventionCommon;
using InventionModel;
using System.Data;
namespace InventionDAO
{
   public class DownAttachDAO
    {
       public DownAttachDAO()
        {
        
        }
       static string sql;
       static DownAttach a;
       static DataSet ds;
       static DataRow dr;
       public DataTable searchkey(string key)
       {
           sql = "select  * from DownAttach where title like '%" + key + "%' or writer like '%" + key + "%' order by fileid desc  ";
           ds = DbHelperSQL.GetDataSet(sql);
           if (ds == null)
           {
               return null;
           }
           else
               return ds.Tables[0];
       
       }
       public DataTable searchkey1(int year1,int year2,string key)
       {
           sql = "select  * from DownAttach where  adddate between " + year1 + " and " + year2 + "  and(title like '%" + key + "%' or writer like '%" + key + "%' ) order by fileid desc  ";
           ds = DbHelperSQL.GetDataSet(sql);
           if (ds == null)
           {
               return null;
           }
           else
               return ds.Tables[0];

       }
       public DataTable GetTable(int cid)
       {
           if (cid == 0)//cid=0时，用于前台下载中心页面的三类资料
           {
               sql = "select  DownAttach.*,DownAttachClass.* from DownAttach,DownAttachClass where cid=1  and DownAttach.cid=DownAttachClass.id order by fileid desc  ";
           }
           else if (cid == 5)//cid=5时，用于后台下载资料管理页面的四类资料
           {
               sql = "select  DownAttach.*,DownAttachClass.* from DownAttach,DownAttachClass where  DownAttach.cid=DownAttachClass.id order by fileid desc ";
           }
           else {
               //这个用于查找某一类
               sql = "select  DownAttach.*,DownAttachClass.* from DownAttach,DownAttachClass where cid=" + cid + " and DownAttach.cid=DownAttachClass.id order by fileid desc ";
           }
           ds = DbHelperSQL.GetDataSet(sql);
           if (ds == null)
           {
               return null;
           }
           else
               return ds.Tables[0];
       }
       public DataTable GetTable1(int year,float type)
       {
         
               //这个用于查找某一类
               sql = "select  DownAttach.*,DownAttachClass.* from DownAttach,DownAttachClass where type=" + type+ " and adddate ="+year+" and DownAttach.cid=DownAttachClass.id order by adddate desc ";
           
           ds = DbHelperSQL.GetDataSet(sql);
           if (ds == null)
           {
               return null;
           }
           else
               return ds.Tables[0];
       }
       public DataTable GetTable2(int cid)
       {

           //这个用于查找某一类
           sql = "select  DownAttach.*,DownAttachClass.* from DownAttach,DownAttachClass where cid=" + cid + " and DownAttach.cid=DownAttachClass.id order by adddate desc ";

           ds = DbHelperSQL.GetDataSet(sql);
           if (ds == null)
           {
               return null;
           }
           else
               return ds.Tables[0];
       }
       public DataTable GetTable3(int id)
       {

           //这个用于查找某一类
           sql = "select  DownAttach.*,DownAttachClass.* from DownAttach,DownAttachClass where DownAttach.id=" + id + " and DownAttach.cid=DownAttachClass.id order by adddate desc ";

           ds = DbHelperSQL.GetDataSet(sql);
           if (ds == null)
           {
               return null;
           }
           else
               return ds.Tables[0];
       }
       public DataTable GetClass(object cid)//读取类名
       {

               sql = "select * from DownAttachClass order by id desc";

           ds = DbHelperSQL.GetDataSet(sql);
           if (ds == null)
           {
               return null;
           }
           else
               return ds.Tables[0];
       }
       public bool Add(DownAttach a)
       {
           sql = string.Format("insert into DownAttach (addDate,writer,title,filesavename,cid,count,type,fileid) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", a.AddDate, a.Writer, a.Title, a.FileSaveName, a.Cid, a.Count, a.Type,a.FileId);
           return DbHelperSQL.ExecSqlCommand(sql);
       }
       public DownAttach Find(object id)
       {
           a = new DownAttach();
           string sql = string.Format("select * from DownAttach where id='{0}'", id);
           dr = DbHelperSQL.GetDateRow(sql);
           try
           {
               a.AddDate = Convert.ToInt32(dr["AddDate"].ToString());
               a.Title = dr["title"].ToString();
               a.Id = dr["id"];
               a.Cid = dr["cid"];
               a.Writer = dr["writer"].ToString();
               a.FileSaveName = dr["filesavename"].ToString();
               a.Count = Convert.ToInt32(dr["count"].ToString());
               a.Type = Convert.ToSingle(dr["type"].ToString());
               return a;
           }
           catch
           {
               return null;
           }
       }
       public bool Update(DownAttach a)
       {
           sql = string.Format("update DownAttach set addDate='{0}',filesavename='{1}',writer='{2}',title='{3}',cid='{4}' where id='{5}'", a.AddDate, a.FileSaveName, a.Writer, a.Title,a.Cid, a.Id);
           return DbHelperSQL.ExecSqlCommand(sql);
       }
       public bool Delete(object id)
       {
           sql = string.Format("Delete DownAttach where id='{0}'", id);
           return DbHelperSQL.ExecSqlCommand(sql);
       }
       public IList<DownAttach> Getlist()//取NoticeArticle表中前num个记录,以列表的形式返回
       {
           List<DownAttach> list = new List<DownAttach>();

           sql = "select distinct adddate from DownAttach where cid=1 ";
           
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
                   a.AddDate = Convert.ToInt32(dr["adddate"].ToString());
                   


                   list.Add(a);
               }
               return list;
           }
       }
       public IList<DownAttach> Getlist1()//取NoticeArticle表中前num个记录,以列表的形式返回
       {
           List<DownAttach> list = new List<DownAttach>();

           sql = "select distinct adddate from DownAttach where cid=2 ";

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
                   a.AddDate = Convert.ToInt32(dr["adddate"].ToString());
                  


                   list.Add(a);
               }
               return list;
           }
       }
    }
}
