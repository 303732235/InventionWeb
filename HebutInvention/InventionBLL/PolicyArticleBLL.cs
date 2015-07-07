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
    public class PolicyArticleBLL
    {
         private PolicyArticleDAO PolicyArticleDAO;
        public  PolicyArticleBLL()
      {
          this.PolicyArticleDAO = new PolicyArticleDAO();//得到数据库连接字符串
      }
        public bool Add(PolicyArticle news)//加数据
      {
          return PolicyArticleDAO.Add(news);
      }

        public bool Update(PolicyArticle news)//更新数据
      {
          return PolicyArticleDAO.Update(news);
      }

      public  bool Delete(object id)//删掉某一个数据
      {
          return PolicyArticleDAO.Delete(id);
      }

      public PolicyArticle GetNewsArticle(object id)//找到某一个记录,返回一个PolicyArticle类的对象
      {
          return PolicyArticleDAO.Find(id);
      }
      public DataTable GetTable(object cid)//获得某一类数据
      {
          return PolicyArticleDAO.GetTable(cid);
      }
      public IList<PolicyArticle> Getlist(object cid,int num)//获取某一类数据的前num个
      {
          return PolicyArticleDAO.FindALL(cid,num);
      }
      public IList<PolicyArticle> Getlist(object num)//读表中前num个记录,如果num为空，则返回整个表的记录
      {
          return PolicyArticleDAO.Getlist(num);
      }

      public IList<PolicyArticle> GetlistByHits()//暂时没用
      {
          return PolicyArticleDAO.FindALLByHits();
      }

      public DataTable GetNewsDetailsByID(int mNewsID)//返回一个记录，以表的形式返回
      {
          return PolicyArticleDAO.GetNewsDetailsByID(mNewsID);
      }
      public IList<PolicyArticle> search(string cid)//搜索关键字，当cid为空时，搜索整个表
      {
          return PolicyArticleDAO.search(cid);
      }
    }
}
