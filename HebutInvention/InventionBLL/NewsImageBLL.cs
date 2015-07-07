using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventionModel;
using InventionDAO;
using System.Data;

namespace InventionBLL
{
   public class NewsImageBLL
    {
       private NewsImageDAO NewsImageDao;
       public NewsImageBLL()
      {
          this.NewsImageDao = new NewsImageDAO();
      }
       public bool Add(NewsImage newsimage)
       {
           return NewsImageDao.Add(newsimage);
       }
       public bool Add1(RightImage newsimage)
       {
           return NewsImageDao.Add1(newsimage);
       }
       public IList<NewsImage> Getlist()
       {
           return NewsImageDao.FindALL();
       }
       public IList<RightImage> Getlist1()
       {
           return NewsImageDao.FindALL1();
       }
       public NewsImage GetNewsImage(object id)
       {
           return NewsImageDao.Find(id);
       }
       public RightImage GetNewsImage1(object id)
       {
           return NewsImageDao.Find1(id);
       }
       public bool Update(NewsImage news)
       {
           return NewsImageDao.Update(news);
       }
       public bool Update1(RightImage news)
       {
           return NewsImageDao.Update1(news);
       }
       public bool Delete(object id)
       {
           return NewsImageDao.Delete(id);
       }
       public bool Delete1(object id)
       {
           return NewsImageDao.Delete1(id);
       }
       public DataTable Gettable(object num) //读取表中前num个记录
       {
           return NewsImageDao.Gettable(num);
       }
       public DataTable GetNewsDetailsByID(int mNewsID)//返回一个记录，以表的形式返回
       {
           return NewsImageDao.GetNewsDetailsByID(mNewsID);
       }
    }
}
