using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace faceplateio
{
    public partial class HomeCtl : System.Web.UI.Page
    {

        MyDataClassesDataContext mydcdc = new MyDataClassesDataContext();
        Boolean IAmLoggedIn = false;
        int myAccount = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label9.Visible = false;
            CNameBox.Visible = false;
            Label10.Visible = false;
            CDescBox.Visible = false;
            Label8.Visible = false;
            CIPBox.Visible = false;
            Label11.Visible = false;
            CKeyBox.Visible = false;
            Button3.Visible = false;
            CMessage.Visible = false;
        }

       
        protected void Button2_Click(object sender, EventArgs e)
        {
            // send lights 
            String f = FromAddress.Text;
            String t = ToAddress.Text;
            String m = "C";
            m += buildLightMessage();
            LightMessage.Text = m;
                // hold off until we're ready
           // LightMessage.Text = GetNew(f, t, m);
        }

        protected String buildLightMessage()
        {
            String m = "";
            m += RedBox2.Text.PadLeft(3, '0') + GreenBox4.Text.PadLeft(3, '0') + BlueBox6.Text.PadLeft(3, '0');

            return m;
        }


        public String GetNew(String from, String to, String msg)
        {
            String retmsg = "";
            Boolean ok = true;
            if (from == "") ok = false;
            if (to == "") ok = false;
            if (msg == "") ok = false;
            //Data maping object to our database
            if (ok)
            {
                Message myNewMessage = new Message();
                myNewMessage.To = to;
                myNewMessage.From = from;
                myNewMessage.Msg = msg;
                myNewMessage.Time = DateTime.Now;

                mydcdc.Messages.InsertOnSubmit(myNewMessage);

                // executes the appropriate commands to implement the changes to the database
                mydcdc.SubmitChanges();
                retmsg = "record written";
            }
            else
            {
                retmsg = "Failed Validation";
            }

            return retmsg;
        }


        protected string buildRelayMessage()
        {
            String m = "";

            if (Relay0.Checked) { m += "1";             } else            {                m += "0";            }
            if (Relay1.Checked) { m += "1";            } else            {                m += "0";            }
            if (Relay2.Checked) { m += "1";            } else            {                m += "0";            }
            if (Relay3.Checked)  { m += "1";            } else            {                m += "0";            }
            if (Relay4.Checked) {  m += "1";            } else            {                m += "0";            }
            if (Relay5.Checked) {  m += "1";            }  else            {                m += "0";            }
            if (Relay6.Checked) {  m += "1";            } else            {                m += "0";            }
            if (Relay7.Checked) {  m += "1";            } else            {                m += "0";            }

            return m;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            // Send Relay
            String f = FromAddress.Text;
            String t = ToAddress.Text;
            String m = "R";
            m += buildRelayMessage();
            RelayMessage.Text = m;
            // hold off until we're ready
            // RelayMessage.Text = GetNew(f, t, m);
        }

        protected void SendAll_Click(object sender, EventArgs e)
        {
            // Send All clicked
            String m="R";
            m += buildRelayMessage();
            m += ":C" + buildLightMessage();
            AllMsg.Text = m;
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            // login button pressed
            String User = UserID.Text.Trim();
            String Pwd = Password.Text.Trim();
            // get account from userID and password combination
            Boolean matched = false;
            int acc = 0;
            var rows = (from p in mydcdc.Accounts select p).Where(p => p.Userid.Equals(User)).Take(1);
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
               Label7.Text = "Login OK:"+acc.ToString();
                this.myAccount = acc;
                IAmLoggedIn = true;
            }
            else
            {
                Label7.Text = "Login Failed";
            }

        }

        protected void BuildTree()
        {
            // get owners
            TreeNode myTN = new TreeNode();
            var rows = (from p in mydcdc.Owners select p).Where(p => p.Account.Equals(myAccount));
            foreach(Owner z in rows)
            {
                myTN.Text = z.Name;
                myTN.Value=z.Id.ToString();
                TreeView1.Nodes.Add(myTN);
            }
        }

        protected void Create_Click(object sender, EventArgs e)
        {

        }

        protected void AddController_Button_Click(object sender, EventArgs e)
        {
            Boolean valid = true;
           
            if (this.myAccount < 0)
            {
                valid = false;
                Label7.Text = "Invalid acount - Logged In?"+ myAccount.ToString();
            }
            else
            {
            Label9.Visible = true;
            CNameBox.Visible = true;
            Label10.Visible = true;
            CDescBox.Visible = true;
            Label8.Visible = true;
            CIPBox.Visible = true;
            Label11.Visible = true;
            CKeyBox.Visible = true;
            Button3.Visible = true;
            CMessage.Visible = true;
                Label7.Text = "Add Controller to Account:" + this.myAccount.ToString();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // add new controller
            Boolean valid = true;
            Owner myOwner = new Owner();
          
            
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
                myOwner.Name = CNameBox.Text.Trim();
                myOwner.IPV6 = CIPBox.Text.Trim();
                myOwner.Key = CKeyBox.Text.Trim();
                myOwner.Description = CDescBox.Text.Trim();
                mydcdc.Owners.InsertOnSubmit(myOwner);

                // executes the appropriate commands to implement the changes to the database
                mydcdc.SubmitChanges();

                // rebuild tree **************
            }



        }
    }
}