using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace faceplateio
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // declare the data
            MyDataClassesDataContext mydcdc = new MyDataClassesDataContext();

            int row = 0;
            List<Message> myList = mydcdc.Messages.Where(p => p.To.Contains("")).Take(10).ToList();
           
           
            foreach (var z in myList)
            {
                //                myPackets.Add(new Packet(z.From.ToString(),z.To.ToString(),z.Msg.ToString()));
              
                // Packet myPacket = new Packet("from me", "to you", "hello");
                
           
                ListBox1.Items.Add(new ListItem(z.Msg));
                // list[row] = z.Msg.ToString();
                row++;
            }
           

           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // declare the data
            MyDataClassesDataContext mydcdc = new MyDataClassesDataContext();

            int row = 0;

            System.Data.DataTable dt = new System.Data.DataTable();

            System.Data.DataRow dr = null;
            dt.Columns.Add(new System.Data.DataColumn("RowNumber", typeof(string)));

            dt.Columns.Add(new System.Data.DataColumn("ID", typeof(string)));

            dt.Columns.Add(new System.Data.DataColumn("From", typeof(string)));

            dt.Columns.Add(new System.Data.DataColumn("To", typeof(string)));

            dt.Columns.Add(new System.Data.DataColumn("Message", typeof(string)));

            List<Message> myList = mydcdc.Messages.Where(p => p.To.Contains("")).Take(10).ToList();


            foreach (var z in myList)
            {
                //                myPackets.Add(new Packet(z.From.ToString(),z.To.ToString(),z.Msg.ToString()));

                // Packet myPacket = new Packet("from me", "to you", "hello");
             dr = dt.NewRow();
                dr["RowNumber"] = row;
                dr["ID"] = z.Id.ToString();
                dr["From"] = z.From;
                dr["To"] = z.To;
                dr["Message"] = z.Msg.ToString();
                    dt.Rows.Add(dr);
                    row++;
            }
            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;
            GridView2.DataSource = dt;
            GridView2.DataBind();

        }

    }
}