using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventionModel
{
   public class RightImage
    {
         #region fields
        private object id;
        private string title;
        private string content;
        private string url;
        private DateTime addDate;

        #endregion

        #region properties
        ///<summary>
        ///编号
        ///</summary>
        public object Id
        {
            get { return id; }
            set { id = value; }
        }
        ///<summary>
        ///标题
        ///</summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        ///<summary>
        ///内容
        ///</summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
       
        ///<summary>
        ///添加时间
        ///</summary>
        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }
       
        ///<summary>
        ///存放地址
        ///</summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        /// <summary>
        /// 获得Model对应的表名
        /// </summary>
        /// <returns></returns>
        private string ReturnTableName()
        {
            return "dbo.[RightImage]";
        }

        /// <summary>
        /// 获得自增键
        /// </summary>
        /// <returns></returns>
        private string ReturnAutoID()
        {
            return "id";
        }
        #endregion

        ///<summary>
        ///constructor
        ///</summary>
        public RightImage(object id, string title, string content,string url, DateTime addDate)
        {
            this.id = id;
            this.title = title;
            this.content = content;
            this.url=url;
            this.addDate = addDate;
        }
        public RightImage()
        {


        }
    }
}
