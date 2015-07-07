using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventionModel;
using InventionCommon;
using System.Data;

namespace InventionDAO
{
   public class UsersDAO
    {
       public UsersDAO()
        {
          
        }
       static string sql;
       static Users a;
       static DataSet ds;
       static DataRow dr;

       public  bool Add(Users a)
       {
           sql = string.Format("insert into tb_User (UserName,UserPwd,Role,UserSex,UserAddress,UserTel,UserEmail,LoginTime,CreateTime,UserQuePwd,UserAnsPwd,UserMark) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", a.UserName, a.Password, a.Role, a.UserSex, a.Address, a.Telephone, a.Email, a.LoginTime, a.CreateTime, a.QuePwd, a.AnsPwd,a.UserMark);
           return DbHelperSQL.ExecSqlCommand(sql);
       }

       public  bool Update(Users a)
       {
           sql = string.Format("update tb_User set UserPwd='{0}',Role='{1}',UserSex='{2}',UserAddress='{3}',UserTel='{4}',UserEmail='{5}',UserName='{6}',UserMark='{7}',LoginTime='{8}' where userid='{9}'", a.Password, a.Role, a.UserSex, a.Address, a.Telephone, a.Email, a.UserName, a.UserMark,a.LoginTime, a.UserId);
           return DbHelperSQL.ExecSqlCommand(sql);
       }
       public  bool Delete(object id)
       {
           sql = string.Format("Delete tb_User where UserID='{0}'", id);
           return DbHelperSQL.ExecSqlCommand(sql);
       }
       public bool Detect(string username)//检测时用
       {
           a = new Users();
           string sql = string.Format("select * from tb_User where UserName='{0}'", username);
           return DbHelperSQL.Detect(sql);
           
          
       }
       public  Users Find(string username)//登陆时用
       {
           a= new Users();
           string sql = string.Format("select * from tb_User where UserName='{0}'", username);
           dr = DbHelperSQL.GetDateRow(sql);
           try
           {
               a.UserId = dr["UserID"].ToString();
               a.UserName = dr["UserName"].ToString();
               a.Password = dr["UserPwd"].ToString();
               a.Role = dr["Role"].ToString();
               a.Telephone = dr["UserTel"].ToString();
               a.Address = dr["UserAddress"].ToString();
               a.Email = dr["UserEmail"].ToString();
               a.UserSex = dr["UserSex"].ToString();
               a.UserMark = Convert.ToInt32(dr["UserMark"].ToString());
               a.LoginTime = Convert.ToDateTime(dr["LoginTime"].ToString());
               a.CreateTime = Convert.ToDateTime(dr["CreateTime"].ToString());
               a.UserId = Convert.ToInt32(dr["UserID"].ToString());
               return a;
           }
           catch 
           {
               return null;
           }
       }
       public Users Find(object id)//编辑时用
       {
           a = new Users();
           string sql = string.Format("select * from tb_User where UserID='{0}'", id);
           dr = DbHelperSQL.GetDateRow(sql);
           try
           {
               a.UserName = dr["UserName"].ToString();
               a.Password = dr["UserPwd"].ToString();
               a.Role = dr["Role"].ToString();
               a.Telephone = dr["UserTel"].ToString();
               a.Address = dr["UserAddress"].ToString();
               a.Email = dr["UserEmail"].ToString();
               a.UserSex = dr["UserSex"].ToString();
               a.QuePwd = dr["UserQuePwd"].ToString();
               a.AnsPwd = dr["UserAnsPwd"].ToString();
               a.UserMark = Convert.ToInt32(dr["UserMark"].ToString());
               a.LoginTime = Convert.ToDateTime(dr["LoginTime"].ToString());
               a.CreateTime = Convert.ToDateTime(dr["CreateTime"].ToString());
               a.UserId = Convert.ToInt32(dr["UserID"].ToString());
               return a;
           }
           catch
           {
               return null;
           }
       }
       public  DataTable FindAll()
       {

           string sql = "select * from tb_User";
           ds = DbHelperSQL.GetDataSet(sql);
           if(ds==null)
           {
               return null;
           }
           else
           {
              
               return ds.Tables[0];
           }           
       }
       public DataTable GetRole(string webusername)
       {
           if (webusername == null)
           {  sql = "select * from view_Role"; }
           else 
           {
               sql = string.Format("select CAIUser,CAIPwd from view_Role where UserName ='{0}'",webusername);
               //sql = "select CAIUser,CAIPwd from CAIUser where PKID" + webusername;
           }
           ds = DbHelperSQL.GetDataSet(sql);
           if (ds == null)
           {
               return null;
           }
           else
           {

               return ds.Tables[0];
           }
       }
       public DataTable GetCAIUser()
      {

           string sql = "select CAIUser,ID from CAIUser where PKID=0";
           ds = DbHelperSQL.GetDataSet(sql);
           if (ds == null)
           {
               return null;
           }
           else
           {

               return ds.Tables[0];
           }
       }
       public int warranty(object s, object b)
       {
           List<string> SQLStringList = new List<string>();
           string sql1 = string.Format("update tb_User set CAIflag='{0}' where userid='{1}'", 1, Convert.ToInt32(s));
           string sql2 = string.Format("update CAIUser set PKID='{0}' where ID='{1}'", Convert.ToInt32(s), Convert.ToInt32(b));
           SQLStringList.Add(sql1);
           SQLStringList.Add(sql2);
           int flag = DbHelperSQL.ExecuteSqlTran(SQLStringList);
           return flag;
       }
       public int remove(object s)
       {
           List<string> SQLStringList = new List<string>();
           string sql1 = string.Format("update tb_User set CAIflag='{0}' where userid='{1}'", 0, Convert.ToInt32(s));
           string sql2 = string.Format("update CAIUser set PKID='{0}' where PKID='{1}'", 0, Convert.ToInt32(s));
           SQLStringList.Add(sql1);
           SQLStringList.Add(sql2);
           int flag = DbHelperSQL.ExecuteSqlTran(SQLStringList);
           return flag;
       }
       public DataTable getmarkDao(int mark)
       {
           string sql = "select MarkName from tb_Mark  where "+mark+">=tb_Mark.MarkMin and "+mark+"<tb_Mark.MarkMax";
           ds = DbHelperSQL.GetDataSet(sql);
           if (ds == null)
           {
               return null;
           }
           else
           {
               return ds.Tables[0];
           }
       }
    }
}
