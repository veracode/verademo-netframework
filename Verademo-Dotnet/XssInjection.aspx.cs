using System;

namespace Verademo_dotnet
{
    public partial class XssInjection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["text"] != null)
            {
                // to quickly comment out code control-k, control-c
                // to quickly comment in code control-k, control-u

                // bad code.  When ran, the following parameter added to the querystring results in XSS.  
                // text=<script>alert(1);</script>
                Response.Write(Request.QueryString["text"]);

                // good code
                Response.Write(System.Net.WebUtility.HtmlEncode(Request.QueryString["text"]));
            }
        }
    }
}