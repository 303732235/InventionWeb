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
    public class ExampleArticleBLL
    {

        
       private ExampleArticleDAO ExampleArticleDao;
        public  ExampleArticleBLL()
      {
          this.ExampleArticleDao = new ExampleArticleDAO();//得到数据库连接字符串
      }
        public bool Add(ExampleArticle news)//加数据
      {
          return ExampleArticleDao.Add(news);
      }

        public bool Update(ExampleArticle news)//更新数据
      {
          return ExampleArticleDao.Update(news);
      }

      public  bool Delete(object id)//删掉某一个数据
      {
          return ExampleArticleDao.Delete(id);
      }

      public ExampleArticle GetNewsArticle(object id)//找到某一个记录,返回一个ExampleArticle类的对象
      {
          return ExampleArticleDao.Find(id);
      }
      public DataTable GetTable(object cid)//获得某一类数据
      {
          return ExampleArticleDao.GetTable(cid);
      }
      public IList<ExampleArticle> search(string cid)//搜索关键字，当cid为空时，搜索整个表
      {
          return ExampleArticleDao.search(cid);
      }
      public IList<ExampleArticle> Getlist(object cid,int num)//获取某一类数据的前num个
      {
          return ExampleArticleDao.FindALL(cid,num);
      }
      public IList<ExampleArticle> Getlist(object num)//读表中前num个记录,如果num为空，则读取整个表的记录
      {
          return ExampleArticleDao.Getlist(num);
      }
    public IList<ExampleArticle> GetlistByHits()//暂时没用
      {
          return ExampleArticleDao.FindALLByHits();
      }

      public DataTable GetNewsDetailsByID(int mNewsID)//返回一个记录，以表的形式返回
      {
          return ExampleArticleDao.GetNewsDetailsByID(mNewsID);
      }
    }
}
