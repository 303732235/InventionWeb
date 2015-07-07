using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace InventionWeb.Front.BBS.App_Code
{
	public class ValidateCode
	{
        public ValidateCode()
        {
        }
        public string validateCode()
        {
            byte[] bytes = new byte[100];
            Random randObj = new Random();
            int code;
            for (int i = 0; i < 4; i++)
            {
                code = randObj.Next(44, 122);
                bytes[i] = Convert.ToByte(code);
            }
            ASCIIEncoding ascii = new ASCIIEncoding();
            string validateCode = ascii.GetString(bytes, 0, 4);
            return validateCode.ToString();
        }

	}

}