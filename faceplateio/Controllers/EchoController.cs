using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace faceplateio.Controllers
{
    public class EchoController : ApiController
    {
        MyDataClassesDataContext mydcdc = new MyDataClassesDataContext();



        // GET api/<controller>
        // this isn't used, i only put it together for testing
        public HttpResponseMessage Get()
        {


            String rspJSON = "";

            //rspJSON = "{'version': '','response': {'outputSpeech': {'type': 'Plain Text','text': 'Hello',},'shouldEndSession': true}}";
            rspJSON = "{\"version\": \"1.0\",\"response\": {\"outputSpeech\": {\"type\": \"PlainText\",\"text\": \"Hello\"},\"shouldEndSession\": true}}";
            JObject jo = JObject.Parse(rspJSON);
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(rspJSON)

            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
            
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]JToken jsonbody)
        {

            
            // String jsonmessage = jsonbody.ToString();
            var whatToWrite = jsonbody["request"]["intent"]["slots"];
            var room = jsonbody["request"]["intent"]["slots"]["room"]["value"].ToString();
            var device = jsonbody["request"]["intent"]["slots"]["device"]["value"].ToString();
            var state = jsonbody["request"]["intent"]["slots"]["state"]["value"].ToString();

            string act = room.ToString() + " " + device.ToString() + " " + state.ToString();

            Message myNewMessage = new Message();
            myNewMessage.To = "me8c";
            myNewMessage.From = "echo";
            // myNewMessage.Msg = act;
            myNewMessage.Msg = whatToWrite.ToString();
            myNewMessage.Time = DateTime.Now;

            mydcdc.Messages.InsertOnSubmit(myNewMessage);

            // execute the changes to the database
            mydcdc.SubmitChanges();
            // Build a response for Alexa
            // 
            String rspJSON = "";
            
            //rspJSON = "{'version': '','response': {'outputSpeech': {'type': 'Plain Text','text': 'Hello',},'shouldEndSession': true}}";
            rspJSON = "{\"version\": \"1.0\",\"response\": {\"outputSpeech\": {\"type\": \"PlainText\",\"text\": \""+act+ "\"},\"shouldEndSession\": true}}";
            JObject jo = JObject.Parse(rspJSON);
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(rspJSON)
                
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
 
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        
    }
    


}