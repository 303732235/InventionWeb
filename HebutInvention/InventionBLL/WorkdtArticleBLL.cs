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
    public class WorkdtArticleBLL
    {
        private WorkdtArticleDAO WorkdtArticleDao;
        public  WorkdtArticleBLL()
      {
          this.WorkdtArticleDao = new WorkdtArticleDAO();//得到数据库连接字符串
      }
        public bool Add(WorkdtArticle news)//加数据
      {
          return WorkdtArticleDao.Add(news);
      }

        public bool Update(WorkdtArticle news)//更新数据
      {
          return WorkdtArticleDao.Update(news);
      }

       public DataTable GetImage()//获得首页图片
        {
            return WorkdtArticleDao.GetImage();
        }
       public DataTable GetImage1()//获得首页图片
       {
           return WorkdtArticleDao.GetImage1();
       }
      public  bool Delete(object id)//删掉某一个数据
      {
          return WorkdtArticleDao.Delete(id);
      }

      public WorkdtArticle GetNewsArticle(object id)//找到某一个记录,返回一个WorkdtArticle类的对象
      {
          return WorkdtArticleDao.Find(id);
      }
      public DataTable GetTable(object cid)//获得某一类数据
      {
          return WorkdtArticleDao.GetTable(cid);
      }
      public IList<WorkdtArticle> Getlist(object cid,int num)//获取某一类数据的前num个
      {
          return WorkdtArticleDao.FindALL(cid,num);
      }
      public IList<WorkdtArticle> Getlist(object num)//读表中前num个记录，如果num为空,则读取整个表
      {
          return WorkdtArticleDao.Getlist(num);
      }

      public IList<WorkdtArticle> GetlistByHits()//暂时没用
      {
          return WorkdtArticleDao.FindALLByHits();
      }

      public DataTable GetNewsDetailsByID(int mNewsID)//返回一个记录，以表的形式返回
      {
          return WorkdtArticleDao.GetNewsDetailsByID(mNewsID);
      }

      public IList<WorkdtArticle> search(string cid)//搜索关键字，当cid为空时，搜索整个表
      {
          return WorkdtArticleDao.search(cid);
      }
    }
}
