using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventionModel
{
    /// <summary>
    /// ExampleArticle类
    /// </summary>
    [Serializable]
    public class ExampleArticle
    {

        #region fields
        private object id;
        private string title;
        private string content;
        private string writer;
        private DateTime addDate;
        private string url;
        //private int hits;
        //private object cid;

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
        ///作者
        ///</summary>
        public string Writer
        {
            get { return writer; }
            set { writer = value; }
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
        ///首页图片
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
            return "dbo.[ExampleArticle]";
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
        public ExampleArticle(object id, string title, string content, string writer,string url, DateTime addDate)
        {
            this.id = id;
            this.title = title;
            this.content = content;
            this.writer = writer;
            this.addDate = addDate;
            this.url = url;
            //this.hits = hits;, int hits, object cid(定义的类型)
            //this.cid = cid;

        }

        public ExampleArticle()
        {


        }
    }
}
