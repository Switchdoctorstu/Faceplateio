
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace faceplateio.Controllers
{
    public class IoController : ApiController
/*

    methods
*/
    {
        // declare the data
        MyDataClassesDataContext mydcdc = new MyDataClassesDataContext();
        
        public String GetNew(String from,String to, String msg)
        {
            String retmsg = "got full msg\n";
            retmsg += "From" + from + "\n";
            retmsg += "To" + to + "\n";
            retmsg += "Msg" + msg + "\n";

            var ok = true;
            if (from == "") ok = false;
            if (to == "") ok = false;
            if (msg == "") ok = false;
            //Data maping object to our database
            if (ok == true)
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

       

        public String[] GetMine(String Mto)
        {
            //String[] messages = new String[50];
            int row = 0; 
            // var records = from p in mydcdc.Messages select p;
            // var results = from p in mydcdc.Messages select p;
            var rows = (from p in mydcdc.Messages orderby p.Time descending select p).Where(p=> p.To.Equals(Mto)).Take(1);
            String[] messages = new String[rows.Count()];
            foreach (Message z in rows){
                messages[row] = z.Msg.ToString() + "Time"+z.Time.ToString();
                row++;
            }
            if(row==0)
            {
                String[] nothing = new String[1];
                nothing[0] = "No messages";
                return nothing;

            } else
            {
                return messages;
            }
        }

        public Message[] GetAll()
        {
            // String[] messages = new String[50];

           // List<Packet> myPackets = new List<Packet>();
            int row = 0;

            List<Message> myList = (from p in mydcdc.Messages orderby p.Time descending select p).Take(10).ToList();
            Message[] list = new Message[myList.Count];
            foreach (var z in myList)
            {
                
                list[row]=z;
              
                row++;
            }
            return list;
            //return myPackets;
           
        }
    }
}
