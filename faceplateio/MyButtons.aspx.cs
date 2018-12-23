using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace faceplateio
{
    public partial class MyButtons : System.Web.UI.Page
    {

        MyDataClassesDataContext myData = new MyDataClassesDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated || (mySession() < 1))
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                if (!IsPostBack)
                { // 1st time here
                    hideRelayControls();
                    readMyButtons();
                    buildMydevices();
                    loadDropDowns();
                    RedBox1.Visible = false;
                    RedBox2.Visible = false;
                    GreenBox3.Visible = false;
                    GreenBox4.Visible = false;
                    BlueBox5.Visible = false;
                    BlueBox6.Visible = false;
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;
                    LinkButton3.Visible = false;
                }
                else
                {
                   
                }
            }
        }

        protected void showRelayControls()
        {
            Label22.Visible = true;
            RelayBox1.Visible = true;
            RelayBox2.Visible = true;
            RelayBox3.Visible = true;
            RelayBox4.Visible = true;
            RelayBox5.Visible = true;
            RelayBox6.Visible = true;
            RelayBox7.Visible = true;
            RelayBox8.Visible = true;
            RelayEn1.Visible = true;
            RelayEn2.Visible = true;
            RelayEn3.Visible = true;
            RelayEn4.Visible = true;
            RelayEn5.Visible = true;
            RelayEn6.Visible = true;
            RelayEn7.Visible = true;
            RelayEn8.Visible = true;

        }

        protected void hideRelayControls()
        {
            Label22.Visible = false;
            RelayBox1.Visible = false;
            RelayBox2.Visible = false;
            RelayBox3.Visible = false;
            RelayBox4.Visible = false;
            RelayBox5.Visible = false;
            RelayBox6.Visible = false;
            RelayBox7.Visible = false;
            RelayBox8.Visible = false;
            RelayEn1.Visible = false;
            RelayEn2.Visible = false;
            RelayEn3.Visible = false;
            RelayEn4.Visible = false;
            RelayEn5.Visible = false;
            RelayEn6.Visible = false;
            RelayEn7.Visible = false;
            RelayEn8.Visible = false;
        }

        protected void loadDropDowns()
        {
            List<Device> myList = getMyDevices();
            foreach(Device d in myList)
            {
                FromList.Items.Add(d.Name);
                ToList.Items.Add(d.Name);
            }
            
        }

        protected void buildMydevices()  // build a list of devices
        {
            List<Device> myList = (from p in myData.Devices select p).Where(p => p.Account.Equals(mySession().ToString())).ToList(); // works

            setMydevices(myList);
        }
        protected List<Device> getMyDevices()
        {
            return (List<Device>)Session["myDevices"];

        }

        protected void setMydevices(List<Device> olist)
        {
            Session["myDevices"] = olist;
        }

        protected void readMyButtons()  // build a list of devices
        {
            List<Button> myList = (from p in myData.Buttons select p).Where(p => p.Owner.Equals(mySession().ToString())).ToList(); // works

            setMyButtons(myList);
        }

        protected List<Button> getMyButtons()
        {
            return (List<Button>)Session["myButtons"];

        }

        protected void setMyButtons(List<Button> olist)
        {
            Session["myButtons"] = olist;
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

        protected void EN_relayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (EN_relayBox.Checked)
            {
                showRelayControls();
            }
            else
            {
                hideRelayControls();
               
            }
        }

        protected void EN_LightsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (EN_LightsBox.Checked)
            {
                RedBox1.Visible = true;
                RedBox2.Visible = true;
                GreenBox3.Visible = true;
                GreenBox4.Visible = true;
                BlueBox5.Visible = true;
                BlueBox6.Visible = true;
                LinkButton1.Visible = true;
                LinkButton2.Visible = true;
                LinkButton3.Visible = true;
            }
            else
            {
                RedBox1.Visible = false;
                RedBox2.Visible = false;
                GreenBox3.Visible = false;
                GreenBox4.Visible = false;
                BlueBox5.Visible = false;
                BlueBox6.Visible = false;
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;
                LinkButton3.Visible = false;
            }
        }

        protected void RelayButton_Click(object sender, EventArgs e) // make relay check boxes visible
        {
            RelayBox1.Visible = true;
            RelayBox2.Visible = true;
            RelayBox3.Visible = true;
            RelayBox4.Visible = true;
            RelayBox5.Visible = true;
            RelayBox6.Visible = true;
            RelayBox7.Visible = true;
            RelayBox8.Visible = true;
        }

        protected void LightButton_Click(object sender, EventArgs e) // make light controls visible
        {
            RedBox1.Visible = true;
            RedBox2.Visible = true;
            GreenBox3.Visible = true;
            GreenBox4.Visible = true;
            BlueBox5.Visible = true;
            BlueBox6.Visible = true;
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
        }

       
        protected void Send_Click(object sender, EventArgs e)
        {
            // So Send the data we have
            List<Device> myDevices = getMyDevices();
            Device myDevice = myDevices[FromList.SelectedIndex];

            // from
            String fromIPV6 = myDevice.IPV6;

            // to
            myDevice = myDevices[ToList.SelectedIndex];
            String toIPV6 = myDevice.IPV6;

            // key

            String myKey = myDevice.Key;
            // message

            String msg = "";
            // build relays
            if (EN_relayBox.Checked)
            {
                msg += buildRelayMessage();
            }

            // build colour
            if (EN_LightsBox.Checked)
            {
                msg += buildLightMessage();
            }
            // send it

            ButtonMessage.Text = "To:" + toIPV6 + " From:" + fromIPV6+" Msg:"+msg;
        }
        protected String buildLightMessage()
        {
            String m = "C";
            m += RedBox2.Text.PadLeft(3, '0') + GreenBox4.Text.PadLeft(3, '0') + BlueBox6.Text.PadLeft(3, '0');
            return m;
        }


        public String putNewMessage(String from, String to, String msg, String key)
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
                myNewMessage.Key = key;

                myData.Messages.InsertOnSubmit(myNewMessage);

                // executes the appropriate commands to implement the changes to the database
                myData.SubmitChanges();
                retmsg = "record written";
            }
            else
            {
                retmsg = "Failed Validation";
            }

            return retmsg;
        }


        protected string buildRelayMessage()  // returns string from check boxes
        {
            String m = "R";

            if (RelayBox1.Checked) { m += "1"; } else { m += "0"; }
            if (RelayBox2.Checked) { m += "1"; } else { m += "0"; }
            if (RelayBox3.Checked) { m += "1"; } else { m += "0"; }
            if (RelayBox4.Checked) { m += "1"; } else { m += "0"; }
            if (RelayBox5.Checked) { m += "1"; } else { m += "0"; }
            if (RelayBox6.Checked) { m += "1"; } else { m += "0"; }
            if (RelayBox7.Checked) { m += "1"; } else { m += "0"; }
            if (RelayBox8.Checked) { m += "1"; } else { m += "0"; }

            return m;
        }

        protected void Configure_Click(object sender, EventArgs e)
        {
            // So Send the data we have
            List<Device> myDevices = getMyDevices();
            Device myDevice = myDevices[FromList.SelectedIndex];

            // from
            String fromIPV6 = myDevice.IPV6;

            // to
            myDevice = myDevices[ToList.SelectedIndex];
            String toIPV6 = myDevice.IPV6;

            // key

            String myKey = myDevice.Key;
            // message

            String msg = "";
            // build relays
            if (EN_relayBox.Checked)
            {
                msg += buildRelayMessage();
            }

            // build colour
            if (EN_LightsBox.Checked)
            {
                msg += buildLightMessage();
            }
            // send it

            ButtonMessage.Text = "To:" + toIPV6 + " From:" + fromIPV6 + " Msg:" + msg;
        }
    }
}