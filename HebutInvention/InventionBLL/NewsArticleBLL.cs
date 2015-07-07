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
  public class NewsArticleBLL
  {
      private NewsArticleDAO NewsArticleDao;
      public NewsArticleBLL()
      {
          this.NewsArticleDao = new NewsArticleDAO();
      }
      public  bool Add(NewsArticle news)
      {
          return NewsArticleDao.Add(news);
      }

      public  bool Update(NewsArticle news)
      {
          return NewsArticleDao.Update(news);
      }

      public  bool Delete(object id)
      {
          return NewsArticleDao.Delete(id);
      }

      public  NewsArticle GetNewsArticle(object id)
      {
          return NewsArticleDao.Find(id);
      }
      public DataTable GetTable(object cid)
      {
          return NewsArticleDao.GetTable(cid);
      }
      public  IList<NewsArticle> Getlist(object cid)
      {
          return NewsArticleDao.FindALL(cid);
      }
      public  IList<NewsArticle> Getlist(object cid,int num)
      {
          return NewsArticleDao.FindALL(cid, num);
      }

      public  IList<NewsArticle> GetlistByHits()
      {
          return NewsArticleDao.FindALLByHits();
      }
     
      public DataTable GetNewsDetailsByID(int mNewsID)
      {
          return NewsArticleDao.GetNewsDetailsByID(mNewsID);
      }
      public IList<NewsArticle> search(string cid)//搜索关键字，当cid为空时，搜索整个表
      {
          return NewsArticleDao.search(cid);
      }

  }
}
