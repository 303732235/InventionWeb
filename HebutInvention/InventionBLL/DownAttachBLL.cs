using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventionModel;
using InventionDAO;
using System.Data;
using System.Data.SqlClient;
namespace InventionBLL
{
   public class DownAttachBLL
    {
       private DownAttachDAO DownAttachDao;
       
       public DownAttachBLL()
      {
          this.DownAttachDao = new DownAttachDAO();
      }
       public DataTable searchkey(string key)//读取表中cid类中前num个记录
       {
           return DownAttachDao.searchkey(key);

       }
       public DataTable searchkey1(int year1,int year2,string key)//读取表中cid类中前num个记录
       {
           return DownAttachDao.searchkey1(year1,year2,key);

       }
       public DataTable GetTable(int cid)//读取表中cid类中前num个记录
       {
           return DownAttachDao.GetTable(cid);

       }
       public DataTable GetTable1(int year,float type)//读取表中cid类中前num个记录
       {
           return DownAttachDao.GetTable1(year,type);

       }
       public DataTable GetTable2(int cid)//读取表中cid类中前num个记录
       {
           return DownAttachDao.GetTable2(cid);

       }
       public DataTable GetTable3(int id)//读取表中cid类中前num个记录
       {
           return DownAttachDao.GetTable3(id);

       }
       public DataTable GetClass(object cid)//读取表中cid类的名称
       {
           return DownAttachDao.GetClass(cid);

       }
       public bool Add(DownAttach da)
       {
           return DownAttachDao.Add(da);
       }
       public DownAttach GetDownAttach(object id)
       {
           return DownAttachDao.Find(id);
       }
       public bool Update(DownAttach da)
       {
           return DownAttachDao.Update(da);
       }
       public bool Delete(object id)
       {
           return DownAttachDao.Delete(id);
       }
       public IList<DownAttach> Getlist()//读表中前num个记录,如果num为空，则读取整个表
       {
           return DownAttachDao.Getlist( );
       }
       public IList<DownAttach> Getlist1()//读表中前num个记录,如果num为空，则读取整个表
       {
           return DownAttachDao.Getlist1();
       }
    }
}
