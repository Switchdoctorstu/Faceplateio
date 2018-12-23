using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace faceplateio
{
    public partial class AddDevice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated || (mySession()<1))
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }
        protected int mySession()
        {
            String mySessionS = (String)Session["mySession"];
            if (string.IsNullOrEmpty(mySessionS))
            {
                return -1;
            }

            return Int32.Parse(mySessionS);

        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            MyDataClassesDataContext myData = new MyDataClassesDataContext();
            if (mySession() > 0)
            {
                // add new controller
                Boolean valid = true;
                Device mydevice = new Device();


                if (CNameBox.Text == "")
                {
                    valid = false;
                    CMessage.Text = "Name Invalid";
                }
                if (CIPBox.Text == "")
                {
                    valid = false;
                    CMessage.Text = " IPV6 invalid";
                }
                if (CKeyBox.Text == "")
                {
                    valid = false;
                    CMessage.Text = " Key invalid";
                }

                if (valid)
                {
                    mydevice.Name = CNameBox.Text.Trim();
                    mydevice.Account = mySession();
                    mydevice.IPV6 = CIPBox.Text.Trim();
                    mydevice.Key = CKeyBox.Text.Trim();
                    mydevice.Description = CDescBox.Text.Trim();
                    myData.Devices.InsertOnSubmit(mydevice);

                    // executes the appropriate commands to implement the changes to the database
                    myData.SubmitChanges();
                    CMessage.Text = "Controller Added to Account:" + mySession().ToString();
                    
                }
            }

        }
    }
}