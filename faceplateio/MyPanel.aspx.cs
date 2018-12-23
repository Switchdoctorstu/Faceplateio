using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace faceplateio{
    public partial class MyPanel : System.Web.UI.Page{

        MyDataClassesDataContext myData = new MyDataClassesDataContext();

        protected void Page_Load(object sender, EventArgs e){
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
                    setup(); // build everything we need
                }
            }
        }
        protected void BGV_RowCommand(object sender,            GridViewCommandEventArgs e)
         {
            if (e.CommandName == "Select")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button 
                // from the Rows collection.
                GridViewRow row = ButtonGridView.Rows[index];
                int s1 = Int32.Parse(row.Cells[2].Text);
                // Add code here to run the script.
                Bmessage.Text = "Script " + s1 + " Selected";
                runScript(s1);
            }

        }

        protected void runScript( int sIndex)
        {
            // run the script
            List<Script> sList = getMyScripts();
            Script s = sList[sIndex];
            String from = s.From;
            String to = s.To;
            String msg = s.Message;
            String key = s.Key;
            String ret = putNewMessage(from, to, msg, key);
            Bmessage.Text = ret;
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

        protected void BGV_RowUpdating(object sender, GridViewUpdateEventArgs e) //done
        {
            int r = mySession();
            if (r > 0)
            {
                //ok so let's try to update the record
                Button newButton = new Button();
                //get our data
                GridViewRow row = ButtonGridView.Rows[e.RowIndex];

                newButton.Owner = r;
                // ID,   Name,  From,To , Message,Key,Next , Wait Time , Confirm,Description
                newButton.Id = Int32.Parse(row.Cells[2].Text);
                newButton.Text = ((TextBox)(row.Cells[3].Controls[0])).Text;
                newButton.Script = Int32.Parse(((TextBox) (row.Cells[4].Controls[0])).Text);
                try {
                    newButton.Timer = DateTime.Parse(((TextBox)(row.Cells[5].Controls[0])).Text);
                }
                catch (Exception f)
                {
                    
                }


                    newButton.Description = ((TextBox)(row.Cells[6].Controls[0])).Text;

               Boolean valid = true;

                if (newButton.Text == "")
                {
                    newButton.Text = "Invalid Name"; valid = false;
                }
                if (newButton.Script <0)
                {
                    Bmessage.Text = "Invalid Script"; valid = false;
                }
                if (newButton.Description == "")
                {
                    Bmessage.Text = "Invalid Description"; valid = false;
                }
                // get the record

                if (valid == true)
                {
                    var qry = from p in myData.Buttons where p.Id == newButton.Id select p;
                    foreach (Button d in qry)
                    {
                        d.Text = newButton.Text;
                        d.Owner = newButton.Owner;
                        d.Script = newButton.Script;
                        d.Timer = newButton.Timer;
                        d.Description = newButton.Description;
                    }
                    // Submit the changes to the database.
                    try
                    {
                        myData.SubmitChanges();
                        Bmessage.Text = "Updated";
                    }
                    catch (Exception f)
                    {
                        Console.WriteLine(f);
                        // Provide for exceptions.
                        Bmessage.Text = "Update Failed";
                    }
                    readMyButtons(); // get buttons too // re-build everything we need
                }

                //Reset the edit index.
                ButtonGridView.EditIndex = -1;
                //Bind data to the GridView control.
                buildButtonGrid();
            }
        }

        protected void BGV_RowEditing(object sender, GridViewEditEventArgs e) // done
        {
            //Set the edit index.
            ButtonGridView.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            buildButtonGrid();
        }

        protected void BGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) // done
        {
            ButtonGridView.EditIndex = -1;
            buildButtonGrid();
        }

        protected void BGV_PageIndexChanging(object sender, GridViewPageEventArgs e) // done
        {
            ButtonGridView.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            buildButtonGrid();
        }

        protected void BGV_SelectedIndexChanged(object sender, EventArgs e) // done
        {
            // Determine the index of the selected row.
            int index = ButtonGridView.SelectedIndex;

            // Display the primary key value of the selected row.
            Bmessage.Text = "The primary key value of the selected row is " +
                ButtonGridView.DataKeys[index].Value.ToString() + ".";
        }

        protected void setup()
        {
            readMyScripts(); // get scripts into session variable
            readMyButtons(); // get buttons too
            buildButtonGrid();
        }


        protected void buildButtonGrid()
        {
            int row = 0;

            System.Data.DataTable dt = new System.Data.DataTable();

            System.Data.DataRow dr = null;
            dt.Columns.Add(new System.Data.DataColumn("ID", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Script", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Timer", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Desc", typeof(string)));

       
            List<Button> myList = getMyButtons();
            foreach (var z in myList)
            {

                dr = dt.NewRow();
                dr["ID"] = z.Id;
                dr["Text"] = z.Text;
                dr["Script"] = z.Script;
                dr["Timer"] = z.Timer;
                dr["Desc"] = z.Description;
                dt.Rows.Add(dr);
                row++;
            }
            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;
            ButtonGridView.DataSource = dt;
            ButtonGridView.DataBind();
        }

        protected void readMyButtons()  // build a list of buttons
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
        
        protected void readMyScripts()  // build a list of devices
        {
            List<Script> myList = (from p in myData.Scripts select p).Where(p => p.Owner.Equals(mySession().ToString())).ToList(); // works
            setMyScripts(myList);
        }

        protected List<Script> getMyScripts()
        {
            return (List<Script>)Session["myScripts"];
        }

        protected void setMyScripts(List<Script> olist)
        {
            Session["myScripts"] = olist;
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
        
        protected void GridButton_Click1(object sender, EventArgs e)
        {
            // Retrieve the row index stored in the 
            // CommandArgument property.
            int z = 0; // int index =Int32.Parse( sender.Text);

            // Retrieve the row that contains the button 
            // from the Rows collection.
            //GridViewRow row = ButtonGridView.Rows[index];
            //int s1 = Int32.Parse(row.Cells[1].Text);
            // Add code here to run the script.
            //Bmessage.Text = "Script " + s1 + " Selected";
        }
    }
}
