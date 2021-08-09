using log4net;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Verademo_dotnet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Int32 customerID, string demoXml, string filePath)
        {
            string password = "123";

            string connectionString = "Data Source=ServerName;" +
                                      "Initial Catalog=DataBaseName;" +
                                      "User id=UserName;" +
                                      "Password=" + password;

            // Bad code         
            string queryString = "UPDATE Sales.Store SET Demographics = " + demoXml
                               + "WHERE CustomerID = " + customerID;
            // End of bad code

            // Good code
            //string queryString = "UPDATE Sales.Store SET Demographics = @demographics "
            //    + "WHERE CustomerID = @ID;";
            // End of good code

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, conn))
                {
                    // Bad code
                    command.ExecuteReader();
                    // End of bad code

                    // Good code
                    //command.Parameters.Add("@ID", SqlDbType.Int);
                    //command.Parameters["@ID"].Value = 100;
                    //command.ExecuteNonQuery();
                    // End of good code
                }
            }

            System.IO.File.Delete(filePath);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string demoXml)
        {
            ViewBag.Message = "Your contact page.";
            
            return View();
        }

        static private ILog logger = LogManager.GetLogger("VeraDemo:UserController");
    }
}