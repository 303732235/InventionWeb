using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventionCommon;
using InventionModel;
using System.Data;
using System.Data.SqlClient;

namespace InventionDAO
{
    public class RemarkDAO
    {
        public RemarkDAO()//取得用于连接数据库的字符串
        {

        }
        static string sql;
        static Remark a;
        static DataSet ds;
        static DataRow dr;

        public bool Add(Remark a)
        {
            sql = string.Format("insert into Remarks (Cid,Tel,Email,Address,About,BBSHelp) values ('{0}','{1}','{2}','{3}','{4}')", a.Cid, a.Tel, a.Email, a.Email, a.About, a.BBShelp);
            return DbHelperSQL.ExecSqlCommand(sql);
        }

        public bool Update(Remark a)
        {
            sql = string.Format("update Remarks set Cid='{0}',Tel='{1}',Email='{2}',Address='{3}',About='{4}',BBSHelp='{5}',ZiranHelp='{8}',ShekeHelp='{7}' where id={6}", a.Cid, a.Tel, a.Email, a.Address, a.About, a.BBShelp, a.Id, a.Shekehelp, a.Ziranhelp);
            return DbHelperSQL.ExecSqlCommand(sql);
        }

        public bool Delete(object id)
        {
            sql = string.Format("Delete Remarks where id='{0}'", id);
            return DbHelperSQL.ExecSqlCommand(sql);
        }

        public Remark Find(object id)//从AllianceArticle找到该id的数据，返回一个AllianceArticle类生成的对象
        {
            a = new Remark();
            string sql = string.Format("select * from Remarks where id='{0}'", id);
            dr = DbHelperSQL.GetDateRow(sql);
            try
            {
                a.Cid = dr["Cid"].ToString();
                a.Tel = dr["Tel"].ToString();
                a.Email = dr["Email"].ToString();
                a.Address = dr["Address"].ToString();
                a.About = dr["About"].ToString();
                a.BBShelp = dr["BBShelp"].ToString();
                a.Ziranhelp = dr["ZiranHelp"].ToString();
                a.Shekehelp = dr["ShekeHelp"].ToString();
                return a;
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetTable(object cid)//查找一个类的数据，返回一个表，暂时没用到
        {
            sql = "select * from Remarks where cid=" + cid + " order by id desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else
                return ds.Tables[0];
        }
        public IList<Remark> FindALL(object cid)//找到cid的类中前num的列表
        {
            List<Remark> list = new List<Remark>();
            sql = "select * from Remarks where cid=" + cid + " order by id desc";
            ds = DbHelperSQL.GetDataSet(sql);
            if (ds == null)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Remark a = new Remark();
                    a.Cid = dr["Cid"].ToString();
                    a.Tel = dr["Tel"].ToString();
                    a.Email = dr["Email"].ToString();
                    a.Address = dr["Address"].ToString();
                    a.About = dr["About"].ToString();
                    a.BBShelp = dr["BBShelp"].ToString();
                    a.Ziranhelp = dr["ZiranHelp"].ToString();
                    a.Shekehelp = dr["ShekeHelp"].ToString();
                    list.Add(a);
                }
                return list;
            }
        }
        public DataTable GetNewsDetailsByID(int mNewsID)//获得某条记录详细信息
        {
            try
            {
                sql = "select * from Remarks where id=" + mNewsID;
                ds = DbHelperSQL.GetDataSet(sql);
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }

    }
}
