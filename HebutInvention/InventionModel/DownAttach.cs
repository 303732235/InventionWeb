using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventionModel
{
  public  class DownAttach
    {
         #region fields
        private object id;
        private string fileid;
        private string title;
        private string filesavename;
        private string writer;
        private object cid;
        private int count;
        private float type;
        private int addDate;

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
        ///文件名称
        ///</summary>
        public string FileSaveName
        {
            get { return filesavename; }
            set { filesavename = value; }
        }
        public string FileId
        {
            get { return fileid; }
            set { fileid = value; }
        }
       
        ///<summary>
        ///添加时间
        ///</summary>
        public int AddDate
        {
            get { return addDate; }
            set { addDate = value; }
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
        ///种类，为以后预留的
        ///</summary>
        ///
        public object Cid
        {
            get { return cid; }
            set { cid = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public float Type
        {
            get { return  type;}
            set { type = value; }
        }
        #endregion
        ///<summary>
        ///constructor
        ///</summary>
        public DownAttach(object id,object cid, string title, string fileid,string filesavename,string writer, int count, int addDate,float type)
        {
            this.id = id;
            this.cid = cid;
            this.title = title;
            this.fileid = fileid;
            this.filesavename = filesavename;
            this.writer = writer;
            this.addDate = addDate;
            this.count = count;
            this.type = type;

        }

        public DownAttach()
        {


        }
    }
}
