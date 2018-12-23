using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace faceplateio
{
    public partial class MyScripts : System.Web.UI.Page
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
                {
                    reGetAll(); // build everything we need
                }
            }
        }

        protected void reGetAll()
        {
            readMyScripts();
            BuildScriptGrid();
        }

        protected void readMyScripts()  // build a list of scripts
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
        protected void BuildScriptGrid()
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
                dt.Columns.Add(new System.Data.DataColumn("From", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("To", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Message", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Key", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Next", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Wait", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Time", typeof(DateTime)));
                dt.Columns.Add(new System.Data.DataColumn("Confirm", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));

                // List<Message> myList = mydcdc.Messages.Where(p => p.To.Contains("")).Take(10).ToList();
                // List<device> myList = (from p in mydcdc.devices select p).Where(p => p.Account.Equals(mySession().ToString())).ToList(); // works
                List<Script> myList = getMyScripts();
                foreach (var z in myList)
                {

                    dr = dt.NewRow();
                    dr["ID"] = z.Id;
                    dr["Name"] = z.Name;
                    dr["From"] = z.From;
                    dr["To"] = z.To;
                    dr["Message"] = z.Message;
                    dr["Key"] = z.Key;
                    dr["Next"] = z.Next_Button;
                    dr["Wait"] = z.Wait_Delay;
                    if (z.Wait_Time == null)
                    {
                      //  dr["Time"] = "0";
                    }
                    else
                    {
                        var date = (DateTime)z.Wait_Time;
                        string dateString = date.ToString("G");
                        dr["Time"] = dateString;
                    }
                    dr["Confirm"] = z.Wait_Confirm;
                    dr["Description"] = z.Description;
                    dt.Rows.Add(dr);
                    row++;
                }
                //Store the DataTable in ViewState
                ViewState["CurrentTable"] = dt;
                ScriptGridView.DataSource = dt;
                ScriptGridView.DataBind();
            }
        }


        protected void SGV_SelectedIndexChanged(Object sender, EventArgs e)
        {

            // Determine the index of the selected row.
            int index = ScriptGridView.SelectedIndex;

            // Display the primary key value of the selected row.
            SGVMessage.Text = "The primary key value of the selected row is " +
                ScriptGridView.DataKeys[index].Value.ToString() + ".";

        }

        protected void SGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int r = mySession();
            if (r > 0)
            {
                //ok so let's try to update the record
                Script newscript = new Script();
                //get our data
                GridViewRow row = ScriptGridView.Rows[e.RowIndex];

                newscript.Owner = r;
                // ID,   Name,  From,To , Message,Key,Next , Wait Time , Confirm,Description
                newscript.Id = Int32.Parse(row.Cells[1].Text);
                  newscript.Name = ((TextBox)(row.Cells[2].Controls[0])).Text;
                newscript.From = ((TextBox)(row.Cells[3].Controls[0])).Text;
                newscript.To = ((TextBox)(row.Cells[4].Controls[0])).Text;
                newscript.Message = ((TextBox)(row.Cells[5].Controls[0])).Text;

                newscript.Key = ((TextBox)(row.Cells[6].Controls[0])).Text;
               // newscript.Wait_Time  = ((TextBox)(row.Cells[7].Controls[0])).Text;

                newscript.Description = ((TextBox)(row.Cells[11].Controls[0])).Text;

                Boolean valid = true;

                if (newscript.Name == "")
                {
                    SGVMessage.Text = "Invalid Name"; valid = false;
                }
                if (newscript.From == "")
                {
                    SGVMessage.Text = "Invalid From"; valid = false;
                }
                if (newscript.Key == "")
                {
                    SGVMessage.Text = "Invalid Key"; valid = false;
                }
                // get the record

                if (valid == true)
                {
                    var qry = from p in myData.Scripts where p.Id == newscript.Id select p;
                    foreach (Script d in qry)
                    {
                        d.From = newscript.From;
                        d.To = newscript.To;
                        d.Message = newscript.Message;
                        d.Owner = newscript.Owner;

                        d.Key = newscript.Key;
                        d.Name = newscript.Name;
                        d.Description = newscript.Description;

                    }
                    // Submit the changes to the database.
                    try
                    {
                        myData.SubmitChanges();
                    }
                    catch (Exception f)
                    {
                        Console.WriteLine(f);
                        // Provide for exceptions.
                    }
                    reGetAll(); // re-build everything we need

                }

                //Reset the edit index.
                ScriptGridView.EditIndex = -1;

                //Bind data to the GridView control.
                BuildScriptGrid();
            }
        }


        protected void SGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ScriptGridView.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            BuildScriptGrid(); ;
        }

        protected void SGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            ScriptGridView.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            BuildScriptGrid(); 
        }

        protected void SGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                // Retrieve the CommandArgument property
                int cellvalue = Convert.ToInt32(e.CommandArgument); // or convert to other datatype
                SGVMessage.Text = " Selected Row:" + cellvalue.ToString();
            }
        }

        protected void SGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            ScriptGridView.EditIndex = -1;
            //Bind data to the GridView control.
            BuildScriptGrid();
        }

    }
}
