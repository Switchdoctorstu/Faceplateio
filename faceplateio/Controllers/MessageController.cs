using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace faceplateio.Controllers
{
    public class MessageController : ApiController
    {
        // declare the data
        MyDataClassesDataContext mydcdc = new MyDataClassesDataContext();
        
        // GET: api/Message
        public HttpResponseMessage Get(string toIP6)
        {
            String messages = "";
            int row = 0;
            // var records = from p in mydcdc.Messages select p;
            // var results = from p in mydcdc.Messages select p;
            var rows = (from p in mydcdc.Messages orderby p.Time descending select p).Where(p => p.To.Equals(toIP6)).Take(1);
            foreach (Message z in rows)
            {
                messages += z.Msg.ToString();
                row++;
            }
            
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(rows);


            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(messages)

            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        // GET: api/Message/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Message
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Message/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Message/5
        public void Delete(int id)
        {
        }
    }
}
