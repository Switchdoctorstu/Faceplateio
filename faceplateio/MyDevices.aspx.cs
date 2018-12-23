using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace faceplateio
{
    public partial class HomeCtl : System.Web.UI.Page
    {

        MyDataClassesDataContext mydcdc = new MyDataClassesDataContext();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            // make sure we're logged in
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            if (mySession() < 0)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                if (!IsPostBack)
                {
                    reGetAll(); // build everything we need
                }
            }
        }

       protected void reGetAll()
        {
            buildMydevices(); // get list of devices into session variable
            BuildTree();
            BuildControllerGrid();
        }

        protected void LightButton_Click(object sender, EventArgs e)
        {
           
            String m = "C";
            m += buildLightMessage();
            LightMessage.Text = m;
            doDevices(m); // cycle through ticked devices

            }

        protected void doDevices(String message)
        {
           // bool atLeastOneRowDeleted = false;
            int itemcount = 0;
            int item = 0;
            String toIPV6 = "";
            String fromIPV6 = "";
            String toKey = "";

            // Iterate through the Products.Rows property
            foreach (GridViewRow row in ControllerGridView.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("SelectFrom");
                if (cb != null && cb.Checked)
                {
                   
                    // First, get the ID for the selected row
                    item = Convert.ToInt32(ControllerGridView.DataKeys[row.RowIndex].Value);
                    
                    // get from IPV6
                                      
                    fromIPV6 = (row.Cells[5].Text);
                   
                    // now we need to iterate the to column

                    foreach (GridViewRow torow in ControllerGridView.Rows)
                    {
                        // Access the CheckBox
                        CheckBox tb = (CheckBox)torow.FindControl("SelectTo");
                        if (tb != null && tb.Checked)
                        {
                            // get the to address
                           
                            toIPV6 = torow.Cells[5].Text;
                            toKey = torow.Cells[6].Text;
                            CGVMessage.Text = putNewMessage(fromIPV6, toIPV6, message, toKey);

                        }
                    }

                            itemcount++;
                }
            }
            if (itemcount == 0)
            {
                CGVMessage.Text = " No From Selected.";
            }
            else
            {
               // CGVMessage.Text = itemcount.ToString() + " Items Selected. Last:" + item.ToString();
            }
                // Show the Label if at least one row was deleted...
            // DeleteResults.Visible = atLeastOneRowDeleted;

        }

        protected String buildLightMessage()
        {
            String m = "";
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

            if (Relay0.Checked) { m += "1";} else{m += "0";}
            if (Relay1.Checked) { m += "1";} else{m += "0";}
            if (Relay2.Checked) { m += "1";} else{m += "0";}
            if (Relay3.Checked)  { m += "1";} else{m += "0";}
            if (Relay4.Checked) {  m += "1";} else{m += "0";}
            if (Relay5.Checked) {  m += "1";}  else{m += "0";}
            if (Relay6.Checked) {  m += "1";} else{m += "0";}
            if (Relay7.Checked) {  m += "1";} else{m += "0";}

            return m;
        }


        protected void RelayButton_Click(object sender, EventArgs e)
        {

         
            // Send Relay
            String m = "R";
            m += buildRelayMessage();
            RelayMessage.Text = m;
         

            doDevices(m); // cycle through ticked devices


        }

        protected void SendAll_Click(object sender, EventArgs e)
        {
            // Send All clicked
            String m="R";
            m += buildRelayMessage();
            m += ":C" + buildLightMessage();
            AllMsg.Text = m;
            doDevices(m); // cycle through ticked devices

        }



        protected void BuildControllerGrid()
        {
            int mySess = mySession();
            if (mySess > 0)
            {
                // load Gridview3
                int row = 0;

                System.Data.DataTable dt = new System.Data.DataTable();

                System.Data.DataRow dr = null;
                dt.Columns.Add(new System.Data.DataColumn("ID", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Name", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("IPV6", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Key", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Desc", typeof(string)));

                // List<Message> myList = mydcdc.Messages.Where(p => p.To.Contains("")).Take(10).ToList();
                // List<device> myList = (from p in mydcdc.devices select p).Where(p => p.Account.Equals(mySession().ToString())).ToList(); // works
                List<Device> myList = getMyDevices();
                foreach (var z in myList)
                {
                  
                    dr = dt.NewRow();
                        dr["ID"] = z.Id;
                    dr["Name"] = z.Name;
                    dr["IPV6"] = z.IPV6;
                    dr["Key"] = z.Key;
                    dr["Desc"] = z.Description;
                    dt.Rows.Add(dr);
                    row++;
                }
                //Store the DataTable in ViewState
                ViewState["CurrentTable"] = dt;
                ControllerGridView.DataSource = dt;
                ControllerGridView.DataBind();
            }
        }

        protected void temp()
        {

        }

        protected void CGV_SelectedIndexChanged(Object sender, EventArgs e)
        {

            // Determine the index of the selected row.
            int index = ControllerGridView.SelectedIndex;

            // Display the primary key value of the selected row.
            CGVMessage.Text = "The primary key value of the selected row is " +
                ControllerGridView.DataKeys[index].Value.ToString() + ".";

        }


        protected void ControllerGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ControllerGridView.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            BuildControllerGrid();
        }

        protected void ControllerGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            ControllerGridView.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            BuildControllerGrid();
        }

        protected void ControllerGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                // Retrieve the CommandArgument property
                int cellvalue = Convert.ToInt32(e.CommandArgument); // or convert to other datatype
                CGVMessage.Text = " Selected Row:" + cellvalue.ToString();
            }
        }

        protected void ControllerGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            ControllerGridView.EditIndex = -1;
            //Bind data to the GridView control.
            BuildControllerGrid();
        }

        protected List<Device> getMyDevices()
        {
            return (List<Device>)Session["myDevices"];

            }

        protected void setMydevices(List<Device> olist)
        {
            Session["myDevices"] = olist;
        }

        protected void ControllerGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int r = mySession();
            if (r > 0)
            {
                //ok so let's try to update the record
                Device newdevice = new Device();
                //get our data
                GridViewRow row = ControllerGridView.Rows[e.RowIndex];

                newdevice.Account = r;
                newdevice.Id = Int32.Parse(row.Cells[3].Text);
               // newdevice.Id= Int32.Parse( ((TextBox)(row.Cells[3].Controls[0])).Text);
                newdevice.Name = ((TextBox)(row.Cells[4].Controls[0])).Text;
                newdevice.IPV6 = ((TextBox)(row.Cells[5].Controls[0])).Text;
                newdevice.Key = ((TextBox)(row.Cells[6].Controls[0])).Text;
                newdevice.Description = ((TextBox)(row.Cells[7].Controls[0])).Text;

                Boolean valid = true;

                if (newdevice.Name == "")
                {
                    CGVMessage.Text = "Invalid Name"; valid = false;
                }
                if (newdevice.IPV6 == "")
                {
                    CGVMessage.Text = "Invalid IPV6"; valid = false;
                }
                if (newdevice.Key == "")
                {
                    CGVMessage.Text = "Invalid Key"; valid = false;
                }
                // get the record

                if (valid == true)
                {
                    var qry = from p in mydcdc.Devices where p.Id == newdevice.Id select p;
                    foreach(Device d in qry)
                    {
                        d.Description = newdevice.Description;
                        d.IPV6 = newdevice.IPV6;
                        d.Key = newdevice.Key;
                        d.Name = newdevice.Name;

                    }
                    // Submit the changes to the database.
                    try
                    {
                        mydcdc.SubmitChanges();
                    }
                    catch (Exception f)
                    {
                        Console.WriteLine(f);
                        // Provide for exceptions.
                    }
                    reGetAll(); // re-build everything we need

                }

                //Reset the edit index.
                ControllerGridView.EditIndex = -1;

                //Bind data to the GridView control.
                BuildControllerGrid();
            }
        }


        protected void buildMydevices()  // build a list of devices
        {
            List<Device> myList = (from p in mydcdc.Devices select p).Where(p => p.Account.Equals(mySession().ToString())).ToList(); // works

            setMydevices(myList);
        }


        protected void BuildTree()
        {
            TreeView1.Nodes.Clear();
            
            // get devices
            TreeNode parentNode = null;
            TreeNode childNode = null;
            var rows = (from p in mydcdc.Devices select p).Where(p => p.Account.Equals(mySession().ToString()));
            foreach(Device z in rows)
            {
                parentNode = new TreeNode(z.Name, z.Id.ToString());
                // add children here
                var peers = (from p in mydcdc.Messages join o in mydcdc.Devices on p.From equals o.IPV6 select new { p.To, o.Name}).Where(p => p.To.Equals(z.IPV6)).Distinct();
                foreach(var m in peers)
                {
                    childNode = new TreeNode(m.Name);
                    parentNode.ChildNodes.Add(childNode);
                }

                TreeView1.Nodes.Add(parentNode);
            }
            
        }
        void TreeView1_NodeMouseClick(object sender,
                TreeNodeEventArgs e)
        {
            TreeMessage.Text = e.Node.Text;
        }



        protected void AddController_Button_Click(object sender, EventArgs e)
        {
           // dummy entry as click has spawned new page
            
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



        protected void Create_Click(object sender, EventArgs e)
        {
            // dummy handler for create account button
            // it spawns new browser session.
        }

       
    }
}