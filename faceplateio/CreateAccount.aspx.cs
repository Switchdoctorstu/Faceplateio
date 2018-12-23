using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace faceplateio
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        // declare the data
        MyDataClassesDataContext myDB = new MyDataClassesDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Create_Button_Click(object sender, EventArgs e)
        {
            // validate inputs
            Boolean valid = true;
            String U1 = UserID1.Text.Trim();
            String U2 = UserID2.Text.Trim();
            String P1 = Password1.Text.Trim();
            String P2 = Password2.Text.Trim();

            if ((U1 != U2) || (P1 != P2))
            {
                LoginMessage.Text = "Tokens do not match";
                valid = false;
            }
            if (U1.Length < 3)
            {
                LoginMessage.Text = "User ID too Short";
                valid = false;
            }
            if (P1.Length < 3)
            {
                LoginMessage.Text = "Password too Short";
                valid = false;
            }
            if(FriendlyName.Text.Length <1)
            {
                LoginMessage.Text = "Invalid friendly name";
                valid = false;
            }
            // check ID not used
            if (valid)
            {
                List<Account> myList = (from p in myDB.Accounts select p).Where(p => p.Userid.Equals(UserID1.Text)).Take(10).ToList();
                if (myList.Count > 0)
                {
                    LoginMessage.Text = "ID already in use";
                    valid = false;
                }
            }
            if (valid)
            {
                if (CreateAcc(U1, P1, FriendlyName.Text, Description.Text))
                {
                    LoginMessage.Text = "Account Created";
                }
                else
                {
                    LoginMessage.Text = "Create Failed";
                }
            }
        }


        protected Boolean CreateAcc( String Uid, String Pwd, String Name, String Desc)
        {

                Account newAccount = new Account();
            newAccount.Userid = Uid;
                newAccount.Name = Name;
            newAccount.Description = Desc;
            newAccount.Password = Pwd;    

                myDB.Accounts.InsertOnSubmit(newAccount);

                // executes the appropriate commands to implement the changes to the database
                myDB.SubmitChanges();
           

            return true;
        }
    }
}