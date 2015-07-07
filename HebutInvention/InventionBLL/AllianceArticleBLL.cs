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
   public  class AllianceArticleBLL
    {

          private AllianceArticleDAO AllianceArticleDao;
        public  AllianceArticleBLL()
      {
          this.AllianceArticleDao = new AllianceArticleDAO();//得到数据库连接字符串
      }
        public bool Add(AllianceArticle news)//添加数据
      {
          return AllianceArticleDao.Add(news);
      }
     public bool Update(AllianceArticle news)//更新数据
      {
          return AllianceArticleDao.Update(news);
      }
      public  bool Delete(object id)//删掉某一个数据
      {
          return AllianceArticleDao.Delete(id);
      }
     public AllianceArticle GetNewsArticle(object id)//找到某一个记录,返回一个AllianceArticle类的对象
      {
          return AllianceArticleDao.Find(id);
      }
      public DataTable GetTable(object cid)//获得某一类数据,暂时没用到
      {
          return AllianceArticleDao.GetTable(cid);
      }
      public IList<AllianceArticle> search(string cid)//搜索关键字,当cid为空时，搜索整个表
      {
          return AllianceArticleDao.search(cid);
      }
      public IList<AllianceArticle> Getlist(object cid,int num)//获取某一类数据的前num个
      {
          return AllianceArticleDao.FindALL(cid,num);
      }
      public IList<AllianceArticle> Getlist(object num)//读表中前num个记录,如果num为空,则读取整个表的记录
      {
          return AllianceArticleDao.Getlist(num);
      }
     public IList<AllianceArticle> GetlistByHits()//暂时没用
      {
          return AllianceArticleDao.FindALLByHits();
      }
     public DataTable GetNewsDetailsByID(int mNewsID)//返回一个记录，以表的形式返回
      {
          return AllianceArticleDao.GetNewsDetailsByID(mNewsID);
      }
    }
}
