using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventionModel
{
    /// <summary>
    /// User类
    /// </summary>
    [Serializable]
    public class Users
    {
        #region fields
        private object userid;
        private string username;
        private string password;
        private string role;
        private string telephone;
        private string usersex;
        private string address;
        private string email;
        private int usermark;
        private string quepwd;
        private string anspwd;
        private DateTime createtime;
        private DateTime logintime;
        #endregion

        #region properties
        ///<summary>
        ///用户ID
        ///</summary>
        public object UserId
        {
            get { return userid; }
            set { userid = value; }
        }
        ///<summary>
        ///用户账号
        ///</summary>
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        ///<summary>
        ///用户密码
        ///</summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        ///<summary>
        ///用户权限
        ///</summary>
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        ///<summary>
        ///会员积分
        ///</summary>
        public int UserMark
        {
            get { return usermark; }
            set { usermark = value; }
        }
        ///<summary>
        ///用户电话
        ///</summary>
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        ///<summary>
        ///用户性别
        ///</summary>
        public string UserSex
        {
            get { return usersex; }
            set { usersex = value; }
        }
        ///<summary>
        ///用户地址
        ///</summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        ///<summary>
        ///用户邮件
        ///</summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        ///<summary>
        ///密码问题
        ///</summary>
        public string QuePwd
        {
            get { return quepwd; }
            set { quepwd = value; }
        }      
        ///<summary>
        ///密码答案
        ///</summary>
        public string AnsPwd
        {
            get { return anspwd; }
            set { anspwd = value; }
        }           
        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime CreateTime
        {
            get { return createtime; }
            set { createtime = value; }
        }
        ///<summary>
        ///登录时间
        ///</summary>
        public DateTime LoginTime
        {
            get { return logintime; }
            set { logintime = value; }
        }
        #endregion

        ///<summary>
        ///constructor
        ///</summary>
        public Users(int userid, string username, string password, string role, string telephone, string usersex, string address, string email, DateTime createtime, DateTime logintime, string quepwd, string anspwd,int usermark)
        {
            this.userid = userid;
            this.address = address;
            this.email = email;
            this.role = role;
            this.username = username;
            this.password = password;
            this.telephone = telephone;
            this.usersex = usersex;
            this.logintime = logintime;
            this.createtime = createtime;
            this.usermark = usermark;
            this.quepwd = quepwd;
            this.anspwd = anspwd;
        }

        public Users()
        {

        }
    }

}
