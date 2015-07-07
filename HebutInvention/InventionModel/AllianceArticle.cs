﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventionModel
{
    /// <summary>
    /// AllianceArticle类
    /// </summary>
    [Serializable]
    public class AllianceArticle
    {

        #region fields
        private object id;
        private string title;
        private string content;
        private string writer;
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

        /// <summary>
        /// 获得Model对应的表名
        /// </summary>
        /// <returns></returns>
        private string ReturnTableName()
        {
            return "dbo.[AllianceArticle]";
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
        public AllianceArticle(object id, string title, string content, string writer, DateTime addDate)
        {
            this.id = id;
            this.title = title;
            this.content = content;
            this.writer = writer;
            this.addDate = addDate;
            //this.hits = hits;, int hits, object cid(定义的类型)
            //this.cid = cid;

        }

        public AllianceArticle()
        {


        }
    }
}
