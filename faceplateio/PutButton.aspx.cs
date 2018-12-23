using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// this code supports the PutButton Page that allows the user to test JSON puts to the alexa service
namespace faceplateio
{
    public partial class Put_Button : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // test has been pressed
            // we're going to send some JSON to ourselves and then see what comes back
            String inputJSON = TextBox1.Text;
            // We need to check the json

            // post it to ourselves at the faceplate server

            // Get the response

            // post it back to the browser
        }
    }
}