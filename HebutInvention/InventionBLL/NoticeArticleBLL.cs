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
    public class NoticeArticleBLL
    {

     private NoticeArticleDAO NoticeArticleDao;
        public  NoticeArticleBLL()
      {
          this.NoticeArticleDao = new NoticeArticleDAO();//得到数据库连接字符串
      }
        public bool Add(NoticeArticle news)//加数据
      {
          return NoticeArticleDao.Add(news);
      }

        public bool Update(NoticeArticle news)//更新数据
      {
          return NoticeArticleDao.Update(news);
      }

      public  bool Delete(object id)//删掉某一个数据
      {
          return NoticeArticleDao.Delete(id);
      }

      public NoticeArticle GetNewsArticle(object id)//找到某一个记录,返回一个NoticeArticle类的对象
      {
          return NoticeArticleDao.Find(id);
      }
      public DataTable GetTable(object cid)//获得某一类数据
      {
          return NoticeArticleDao.GetTable(cid);
      }
      public IList<NoticeArticle> Getlist(object cid,int num)//获取某一类数据的前num个
      {
          return NoticeArticleDao.FindALL(cid,num);
      }
      public IList<NoticeArticle> Getlist(object num)//读表中前num个记录,如果num为空，则读取整个表
      {
          return NoticeArticleDao.Getlist(num);
      }
      public IList<DownAttach> Getlist1(object num)//读表中前num个记录,如果num为空，则读取整个表
      {
          return NoticeArticleDao.Getlist1(num);
      }
      public IList<DownAttach> Getlist2(object num)//读表中前num个记录,如果num为空，则读取整个表
      {
          return NoticeArticleDao.Getlist2(num);
      }

      public IList<NoticeArticle> GetlistByHits()//暂时没用
      {
          return NoticeArticleDao.FindALLByHits();
      }

      public DataTable GetNewsDetailsByID(int mNewsID)//返回一个记录，以表的形式返回
      {
          return NoticeArticleDao.GetNewsDetailsByID(mNewsID);
      }
      public IList<NoticeArticle> search(string cid)//搜索关键字，当cid为空时，搜索整个表
      {
          return NoticeArticleDao.search(cid);
      }
    }
}
