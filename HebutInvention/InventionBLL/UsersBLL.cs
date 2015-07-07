using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InventionModel;
using InventionDAO;
using System.Data;
namespace InventionBLL
{
    public class UsersBLL
    {
        private UsersDAO UserDao;
        public UsersBLL()
      {
          this.UserDao = new UsersDAO();
      }
        public  bool CheckLogin(Users u)
        {
            Users a = UserDao.Find(u.UserName);
           try
           {
               return a.Password == u.Password ? true : false;
             
           }
           catch
           {
               return false;
           }
        }
        public bool Detect(string name)
        {
            return UserDao.Detect(name);
        }
        public  bool Update(Users u)
        {
            return UserDao.Update(u);
        }
        public bool Add(Users u)
        {
            return UserDao.Add(u);
        }
        public bool Delete(object id)
        {
            return UserDao.Delete(id);
        }
        public Users GetUser(string name)
        {
            return UserDao.Find(name);
        }
        public Users GetUser(object id)
        {
            return UserDao.Find(id);
        }
        public DataTable GetAll()
        {
            return UserDao.FindAll();
        }
        public DataTable GetUserRole(string webusername)
        {
            return UserDao.GetRole(webusername);
        }
        public DataTable GetCAIUser()
        {
            return UserDao.GetCAIUser();
        }
        public void warranty(object s,object b)
        {

            UserDao.warranty(s, b);
        }
        public void addIKCUser()
        {
                    
        }
        public void remove(object s)
        {
            UserDao.remove(s);
        }
        public DataTable getmarkBLL(int s)
        {
           return UserDao.getmarkDao(s);
        }
    }
}
