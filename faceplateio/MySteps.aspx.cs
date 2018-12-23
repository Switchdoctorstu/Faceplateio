using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace faceplateio
{
    public partial class MySteps : System.Web.UI.Page
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
                buildDropDowns();
                readMySteps();
                buildStepGrid();
            }
        }

        protected void buildDropDowns()
        {
                ListItem li0 = new ListItem();
            ListItem li1 = new ListItem();
            ListItem li2 = new ListItem();

            li0.Text = "Move";
                OperatorList.Items.Add(li0);
            li1.Text = "Source IPV6";
                OperantList.Items.Add(li1);
            li2.Text = "Data";
            OperandList.Items.Add(li2);
        }

        protected void readMySteps()  // build a list of devices
        {
            List<Step> myList = (from p in myData.Steps select p).Where(p => p.Account.Equals(mySession().ToString())).ToList(); // works

            setMySteps(myList);
        }

        protected List<Step> getMySteps()
        {
            return (List<Step>)Session["mySteps"];

        }

        protected void setMySteps(List<Step> olist)
        {
            Session["mySteps"] = olist;
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

        protected void buildStepGrid()
        {
            int mySess = mySession();
            if (mySess > 0)
            {
                // load Gridview3
                int row = 0;

                System.Data.DataTable dt = new System.Data.DataTable();

                System.Data.DataRow dr = null;
                dt.Columns.Add(new System.Data.DataColumn("ID", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Label", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Operator", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Operand", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Operant", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Mode", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("EQ", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("GT", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("LT", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("NULL", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Data", typeof(string)));
                // List<Message> myList = mydcdc.Messages.Where(p => p.To.Contains("")).Take(10).ToList();
                // List<device> myList = (from p in mydcdc.devices select p).Where(p => p.Account.Equals(mySession().ToString())).ToList(); // works
                List<Step> myList = getMySteps();
                foreach (var z in myList)
                {

                    dr = dt.NewRow();
                    dr["ID"] = z.Id;
                    dr["Label"] = z.Label;
                    dr["Operator"] = z.Operator;
                    dr["Operand"] = z.Operand;
                    dr["Operant"] = z.Operant;
                    dr["Mode"] = z.Mode;
                    dr["EQ"] = z.EQ;
                    dr["GT"] = z.GT;
                    dr["LT"] = z.LT;
                    dr["NULL"] = z.NULL;
                    dr["Data"] = z.Data;

                    dt.Rows.Add(dr);
                    row++;
                }
                //Store the DataTable in ViewState
                ViewState["CurrentTable"] = dt;
                StepGridView.DataSource = dt;
                StepGridView.DataBind();
            }
        }

        protected void Add_Step_Click(object sender, EventArgs e)
        {
            MyDataClassesDataContext myData = new MyDataClassesDataContext();
            if (mySession() > 0)
            {
                // add new controller
                Boolean valid = true;
                Step myStep = new Step();


                if (OperandList.Text == "")
                {
                    valid = false;
                    AddStepMessage.Text = "Operand Invalid";
                }
                


                if (valid)
                {
                    myStep.Label = LabelBox.Text.Trim();
                    myStep.Account = mySession();
                    myStep.Operator = OperatorList.SelectedIndex;
                    myStep.Operand = OperandList.SelectedIndex;
                    myStep.Operant = OperantList.SelectedIndex;
                    myStep.Mode = ModeList.SelectedIndex;
                    myStep.Data = Message.Text;
                    myStep.EQ = cleanInt(EQBox.Text);
                    myStep.GT = cleanInt(GTBox.Text);
                    myStep.LT = cleanInt(LTBox.Text);
                    myStep.NULL = cleanInt(NULLBox.Text);
                     
                    myData.Steps.InsertOnSubmit(myStep);

                    // executes the appropriate commands to implement the changes to the database
                    myData.SubmitChanges();
                    AddStepMessage.Text = "Step Added to Account:" + mySession().ToString();

                }
            }

        }
        protected int cleanInt(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                
                return 0;
            }

            return Int32.Parse(s);

           
        }

    }
}
