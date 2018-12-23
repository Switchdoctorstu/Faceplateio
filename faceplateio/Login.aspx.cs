using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace faceplateio
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String loginstatus = (String)Session["status"];

            if (string.IsNullOrEmpty(loginstatus))
            {

            }
            else
            {
                LoginMessage.Text = loginstatus;
                // return Int32.Parse(mySessionS);
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            // login button pressed
            MyDataClassesDataContext myData = new MyDataClassesDataContext();
            String User = Login1.UserName.Trim();
            String Pwd = Login1.Password.Trim();
            // get account from userID and password combination
            Boolean matched = false;
            int acc = 0;
            var rows = (from p in myData.Accounts select p).Where(p => p.Userid.Equals(User)).Take(1);
            String[] messages = new String[rows.Count()];
            foreach (Account z in rows)
            {
                if (z.Password.Trim() == Pwd)
                {
                    matched = true;
                    acc = z.Id;
                }
            }

            if (matched)
            {
                Session["mySession"] = acc.ToString();
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                LoginMessage.Text = "Login OK:" + acc.ToString();
                Session["status"] = "Login OK";
            }
            else
            {
                Login1.FailureText = "Login Failed";
                LoginMessage.Text = "Login Failed" + User;
                Session["status"] = "Login Failed";
            }

        }
    }
}