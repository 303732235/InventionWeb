using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventionBLL;
using System.Data;
using System.Data.SqlClient;
using InventionWeb.Front.BBS.App_Code;

namespace InventionWeb.Front
{
    public partial class index2 : System.Web.UI.Page
    {
        private WorkdtArticleBLL workdtarticlebll;
        private NewsArticleBLL newsarticalbll;
        private NoticeArticleBLL noticearticlebll;
        private PolicyArticleBLL policyarticlebll;
        private AllianceArticleBLL alliancearticlebll;
        private ExampleArticleBLL examplearticlebll;
        private NewsImageBLL newsimagesbll;
        private WorkdtArticleBLL workdtImage3;
        private WorkdtArticleBLL workdtImage2;
        private UsersBLL usersbll;
        private RemarkBLL remrkbll;

        protected string userloginifo;
        public string showMsgUrl = null;//用于工作动态在首页显示的图片
        public string showMsgTitle = null;//用于工作动态在首页显示图片的标题
        public string showMsgId = null;//用于工作动态在首页显示图片的标题
        public string showMsgUrl1 = null;//用于工作动态在首页显示的图片
        public string showMsgTitle1 = null;//用于工作动态在首页显示图片的标题
        public string showMsgId1 = null;//用于工作动态在首页显示图片的标题

        public string CurrentUsername;
        public string UserPwd;
        public string label;

        public string houtaicashu;//用于连接CAI工具用
        protected void Page_Load(object sender, EventArgs e)
        {
            remrkbll = new RemarkBLL();
            if (Session["UserName"] != null)
            {
                CurrentUsername = Session["UserName"].ToString();
                userloginifo = "<span>欢迎您：" + CurrentUsername + "访问河北工业大学学报编辑部！<a href='loginout.aspx'>【退出】</a></span>";
                string UserID = Session["UserID"].ToString();
                //string  Role = Session["Role"].ToString();
                UserPwd = Session["UserPwd"].ToString();
            }
            else
            {
                userloginifo = "<span >您好!欢迎访问河北工业大学学报编辑部 <a href='login.aspx?type=indexpage'>【请登录】</a> 新用户？<a href='register.aspx'>【注册】</a></span>";
                Session["Role"] = "";
            }
            Response.AddHeader("P3P", "CP=CAO PSA OUR");
            if (!IsPostBack)
            {
                this.tongji.Text = Application["user_total "].ToString();
                notice();//通知通告
                bindNews();//首页新闻
                alliance(); //工作联盟
                workdt(); //工作动态

                workdtImage(); //工作动态首页图片，读取的是NewsImages文件下的图片
                workdtImage1();
                example(); //创新案例，用于在首页显示创新案例图片
                poliy();//政策法规==创新理论
                connetion();//综合交流
                bind();
                zirannotice();
                shekenotice();
            }
        }
        public void bind()
        {
            InventionModel.Remark rm = new InventionModel.Remark();
            rm = remrkbll.GetRemark(1);//返回一个remark实体
            tel.Text = rm.Tel;
            email.Text = rm.Email;
            address.Text = rm.Address;
        }
        protected void CAIStart_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                string webusername = Session["UserName"].ToString();
                DataTable viewinfo = new DataTable();
                usersbll = new UsersBLL();
                viewinfo = usersbll.GetUserRole(webusername);
                string cainame = viewinfo.Rows[0].ItemArray[0].ToString();
                string caipwd = viewinfo.Rows[0].ItemArray[1].ToString();
                if (cainame == "")
                {
                    Response.Write("<script>alert('你的权限不够');history.back(-1);</script>");
                }
                else
                {
                    //Response.Write("<script>window.open('http://202.113.125.121:8080/View/backMgr.aspx?username=' + cainame + '&userpwd=' + caipwd','_blank');</script>");
                    Response.Redirect("http://202.113.125.121:8080/View/backMgr.aspx?username=" + cainame + "&userpwd=" + caipwd);//注意url传参数时，不能有空格
                }
            }
            else
            {
                Response.Write("<script>alert('你还未登录');window.history.back();</script>");

            }
        }
        public void notice()//通知通告
        {

            noticearticlebll = new NoticeArticleBLL();
            this.DatalistNotice.DataSource = noticearticlebll.Getlist(9);
            this.DatalistNotice.DataBind();

        }
        public void zirannotice()//自然版
        {

            noticearticlebll = new NoticeArticleBLL();
            this.Datalist1.DataSource = noticearticlebll.Getlist1(11);
            this.Datalist1.DataBind();

        }
        public void shekenotice()//社科版
        {

            noticearticlebll = new NoticeArticleBLL();
            this.Datalist2.DataSource = noticearticlebll.Getlist2(11);
            this.Datalist2.DataBind();

        }
        public void bindNews()//首页新闻
        {
            newsarticalbll = new NewsArticleBLL();
            this.DatalistNews.DataSource = newsarticalbll.Getlist(10, 6);
            this.DatalistNews.DataBind();
        }
        public void alliance() //工作联盟
        {
            alliancearticlebll = new AllianceArticleBLL();
            this.DatalistAlliance.DataSource = alliancearticlebll.Getlist(5);
            this.DatalistAlliance.DataBind();
        }
        public void workdt() //工作动态
        {
            workdtarticlebll = new WorkdtArticleBLL();
            this.DatalistWorkdt.DataSource = workdtarticlebll.Getlist(8);
            this.DatalistWorkdt.DataBind();
        }
        public void workdtImage() //工作动态首页图片，读取的是NewsImages文件下的图片
        {
            workdtImage3 = new WorkdtArticleBLL();
            DataTable dt = workdtImage3.GetImage();//读取全部图片
            if (dt == null)
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                showMsgUrl += "/NewsImages/" + dt.Rows[i][2] + "|";
            }
            showMsgUrl = showMsgUrl.TrimEnd('|');
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                showMsgTitle += dt.Rows[i][1] + "|";
            }
            showMsgTitle = showMsgTitle.TrimEnd('|');
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                showMsgId += "/Front/abstractus/default.aspx|";
            }
            showMsgId = showMsgId.TrimEnd('|');
        }
        public void workdtImage1() //首页右边图片，读取的是RightImages文件下的图片
        {
            workdtImage2 = new WorkdtArticleBLL();
            DataTable dt = workdtImage2.GetImage1();//读取全部图片
            if (dt == null)
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                showMsgUrl1 += "/NewsImages/" + dt.Rows[i][2] + "|";
            }
            showMsgUrl1 = showMsgUrl1.TrimEnd('|');
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                showMsgTitle1 += dt.Rows[i][1] + "|";
            }
            showMsgTitle1 = showMsgTitle1.TrimEnd('|');
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                showMsgId1 += "/Front/abstractus/default.aspx|";
            }
            showMsgId1 = showMsgId1.TrimEnd('|');
        }
        public void newimages() //图片新闻
        {
            newsimagesbll = new NewsImageBLL();
            this.DatalistNewsImages.DataSource = newsimagesbll.Gettable(4);
            this.DatalistNewsImages.DataBind();
        }
        public void example() //创新案例，用于在首页显示创新案例图片
        {
            examplearticlebll = new ExampleArticleBLL();
            this.DatalistExamplepic.DataSource = examplearticlebll.Getlist(null);
            this.DatalistExamplepic.DataBind();
        }
        public void poliy() //政策法规，创新理论 用于在首页显示
        {
            policyarticlebll = new PolicyArticleBLL();
            this.DatalistPoliy.DataSource = policyarticlebll.Getlist(6);
            this.DatalistPoliy.DataBind();
        }
        public void connetion()//综合交流
        {
            DataOperate dataoper = new DataOperate();
            string sqlconn = "select top 6 * from ModuleInfo_View where ModuleID=34 order by CardDate desc";
            dataoper.dataBind(DatalistConn, sqlconn);
        }
        public string CutString(string content)
        {
            if (content.Length > 14)
            {
                return content.Substring(0, 13) + "...";
            }
            else
            {
                return content;
            }
        }
        public string CutString1(string content)
        {
            if (content.Length > 18)
            {
                return content.Substring(0, 13) + "...";
            }
            else
            {
                return content;
            }
        }
        public bool display(string adddate)
        {
            DateTime addDate = Convert.ToDateTime(adddate);
            if (addDate.AddHours(72) >= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}