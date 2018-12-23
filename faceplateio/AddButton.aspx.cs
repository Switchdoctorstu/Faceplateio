using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace faceplateio
{
    public partial class AddButton : System.Web.UI.Page
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
                    readMyScripts();
                    buildDropdowns();
                }
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

        protected void buildDropdowns()
        {
            List<Script> myScripts = getMyScripts();
            foreach (Script s in myScripts)
            {


                ListItem myLI = new ListItem();
                myLI.Value = s.Id.ToString();
                myLI.Text = s.Name;
                ScriptList.Items.Add(myLI);
            }
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

        protected void Add_Button_Click(object sender, EventArgs e)
        {
            MyDataClassesDataContext myData = new MyDataClassesDataContext();
            if (mySession() > 0)
            {
                // add new button
                Boolean valid = true;

                Button myButton = new Button();

                if (TextText.Text == "")
                {
                    valid = false;
                    BMessage.Text = "Text Invalid";
                }

                int selectedscript =Int32.Parse( ScriptList.SelectedItem.Value);

                if (valid)
                {
                    myButton.Text = TextText.Text.Trim();
                    myButton.Owner = mySession();
                    myButton.Script = selectedscript;
                   //  myButton.Timer = DateTime.Parse(Timerx.Text.Trim());

                    myButton.Description = Desc.Text.Trim();
                    myData.Buttons.InsertOnSubmit(myButton);

                    // executes the appropriate commands to implement the changes to the database
                    myData.SubmitChanges();
                    BMessage.Text = "Button Added to Account:" + mySession().ToString();

                }
            }
        }

        protected void ScriptList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptNameLabel.Text = ScriptList.SelectedItem.Text;
        }
    }
}