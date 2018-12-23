using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace faceplateio
{
    public partial class AddScript : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated || (mySession() < 1))
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

        protected void HyperLink_Click(object sender,EventArgs e)
        {

        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            MyDataClassesDataContext myData = new MyDataClassesDataContext();
            if (mySession() > 0)
            {
                // add new Script
                Boolean valid = true;
                Script myScript = new Script();


                if (From.Text == "")
                {
                    valid = false;
                    SMessage.Text = "From Invalid";
                }
                if (Name.Text == "")
                {
                    valid = false;
                    SMessage.Text = "Name Invalid";
                }

                if (To.Text == "")
                {
                    valid = false;
                    SMessage.Text = "To Invalid";
                }
                if (From.Text == "")
                {
                    valid = false;
                    SMessage.Text = "From Invalid";
                }



                if (valid)
                {
                    myScript.From = From.Text.Trim();
                    myScript.Owner = mySession();
                    myScript.Key = Key.Text.Trim();
                    myScript.To = To.Text.Trim();
                    myScript.Message = Msg.Text;
                    myScript.Name = Name.Text.Trim();
                    myScript.Description = Description.Text;
                    if (string.IsNullOrEmpty(Wait.Text))
                    {
                        myScript.Wait_Delay = 0;
                    }
                    else {
                        myScript.Wait_Delay = Int32.Parse(Wait.Text);
                    }
                    myScript.Wait_Confirm = Confirm.Text;
                    myData.Scripts.InsertOnSubmit(myScript);

                    // executes the appropriate commands to implement the changes to the database
                    myData.SubmitChanges();
                    SMessage.Text = "Script Added to Account:" + mySession().ToString();

                }
            }

        }

      
    }


}
