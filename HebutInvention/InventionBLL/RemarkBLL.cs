using System.Linq;
using System.Text;
using InventionModel;
using InventionDAO;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace InventionBLL
{
    public class RemarkBLL
    {

        private RemarkDAO RemarkDAO;
        public RemarkBLL()
        {
            this.RemarkDAO = new RemarkDAO();//得到数据库连接字符串
        }
        public bool Add(Remark news)//添加数据
        {
            return RemarkDAO.Add(news);
        }
        public bool Update(Remark news)//更新数据
        {
            return RemarkDAO.Update(news);
        }
        public bool Delete(object id)//删掉某一个数据
        {
            return RemarkDAO.Delete(id);
        }
        public Remark GetRemark(object id)//找到某一个记录,返回一个Remrk类的对象
        {
            return RemarkDAO.Find(id);
        }
        public DataTable GetTable(object cid)//获得某一类数据,暂时没用到
        {
            return RemarkDAO.GetTable(cid);
        }
        public IList<Remark> Getlist(object cid)//获取某一类数据的前num个
        {
            return RemarkDAO.FindALL(cid);
        }
        public DataTable GetNewsDetailsByID(int mNewsID)//返回一个记录，以表的形式返回
        {
            return RemarkDAO.GetNewsDetailsByID(mNewsID);
        }
    }
}
