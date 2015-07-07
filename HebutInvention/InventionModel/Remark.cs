using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventionModel
{
    /// <summary>
    /// Remark备注类
    /// </summary>
    [Serializable]
    public class Remark
    {
        #region fields
        private object id;
        private string cid;
        private string tel;
        private string email;
        private string address;
        private string about;
        private string bbshelp;
        private string ziranhelp;
        private string shekehelp;
        #endregion

        #region properties
        ///<summary>
        ///备注ID
        ///</summary>
        public object Id
        {
            get { return id; }
            set { id = value; }
        }
        ///<summary>
        ///分类
        ///</summary>
        public string Cid
        {
            get { return cid; }
            set { cid = value; }
        }
        ///<summary>
        ///电话
        ///</summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        ///<summary>
        ///邮箱
        ///</summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        ///<summary>
        ///地址
        ///</summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        ///<summary>
        ///关于我们和帮助，都用这个字段
        ///</summary>
        public string About
        {
            get { return about; }
            set { about = value; }
        }        ///<summary>
        ///关于BBS帮助
        ///</summary>
        public string BBShelp
        {
            get { return bbshelp; }
            set { bbshelp = value; }
        }
        public string Shekehelp
        {
            get { return shekehelp; }
            set { shekehelp = value; }
        }
        public string Ziranhelp
        {
            get { return ziranhelp; }
            set { ziranhelp = value; }
        }
        #endregion

        ///<summary>
        ///constructor
        ///</summary>
        public Remark(int id, string cid, string tel, string address, string email, string about, string bbshelp, string ziranhelp, string shekehelp)
        {
            this.id = id;
            this.cid = cid;
            this.email = email;
            this.tel = tel;
            this.address = address;
            this.about = about;
            this.bbshelp = bbshelp;
            this.ziranhelp = ziranhelp;
            this.shekehelp = shekehelp;
        }

        public Remark()
        {

        }
    }
}
