using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Verademo_dotnet
{
    public partial class FormOpenRedirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["url"] != null)
            {
                // to quickly comment out code control-k, control-c
                // to quickly comment in code control-k, control-u

                // bad code
                Response.Redirect(Request.QueryString["url"]);

                // approved cleanser
                Response.Redirect(System.Net.WebUtility.UrlEncode(Request.QueryString["url"]));
                
                // custom cleanser 
                Response.Redirect(MyCustomCleanser(Request.QueryString["url"]));
            }
        }

        [Veracode.Attributes.RedirectUrlCleanser]
        protected string MyCustomCleanser(string s)
        {
            // do nothing :)  
            return s;
        }
    }
}