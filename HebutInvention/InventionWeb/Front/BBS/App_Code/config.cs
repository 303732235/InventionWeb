using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
namespace InventionWeb.Front.BBS.App_Code
{
    public class config
    {
        //配置文件NBBSConfig.xml的绝对路径
        private static readonly string configFilePath = HttpContext.Current.Server.MapPath("~/InventionwebConfig.xml");

        /// <summary>
        /// 获取过滤字符串
        /// </summary>
        /// <returns>由“,”分隔的所有过滤字符串组成的长字符串</returns>
        public static string GetFilter()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@configFilePath);
            XmlNodeList filters = xmlDoc.GetElementsByTagName("Filter");

            int i;
            string filterStr = "";
            for (i = 0; i < filters[0].ChildNodes.Count; i++)
            {
                filterStr += filters[0].ChildNodes[i].InnerText;
                if (i != filters[0].ChildNodes.Count - 1)
                {
                    filterStr += ",";
                }
            }

            return filterStr;
        }

        /// <summary>
        /// 设置过滤字符串
        /// </summary>
        /// <param name="filterStr">由“,”分隔的所有过滤字符串组成的长字符串</param>
        public static void SetFilter(string filterStr)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@configFilePath);
            XmlNodeList filters = xmlDoc.GetElementsByTagName("Filter");

            string[] filterWords = filterStr.Split(',');

            filters[0].RemoveAll();
            int i;
            for (i = 0; i < filterWords.Length; i++)
            {
                XmlNode newNode = xmlDoc.CreateNode(XmlNodeType.Element, "FilterItem", "");
                newNode.InnerText = filterWords[i];
                filters[0].AppendChild(newNode);
            }

            xmlDoc.Save(@configFilePath);
        }
        public static bool checkout(string uid, string pwd)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@configFilePath);
            XmlNodeList DbMgr = xmlDoc.GetElementsByTagName("DbMgr");
            string name = DbMgr[0].ChildNodes[0].InnerText;
            string password = DbMgr[0].ChildNodes[1].InnerText;
            if (uid == name && pwd == password)
            {
                return true;
            }
            return false;
        }
        public static void Set(string name, string pwd)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@configFilePath);
            XmlNodeList DbMgr = xmlDoc.GetElementsByTagName("DbMgr");

            DbMgr[0].ChildNodes[0].InnerText = name;
            DbMgr[0].ChildNodes[1].InnerText = pwd;


            xmlDoc.Save(@configFilePath);
        }
    }

}