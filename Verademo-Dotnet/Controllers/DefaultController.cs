using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Verademo_dotnet.Controllers
{
    public class DefaultController : Controller
    {
        private static readonly RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        private static readonly ILog log = LogManager.GetLogger("VeraDemo:UserController");
        // GET: Default
        public ActionResult Index(string filePath)
        {
            string fileData;
            using (StreamReader userData = System.IO.File.OpenText(filePath))
            {
                fileData = userData.ReadToEnd();
            }

            log.Info("File path :" + filePath);

            return View();
        }         

        /// <summary>
        /// Generates random bytes used for Nonce values.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static byte[] GenerateRandomBytes(int size)
        {
            // Create a random key using a random number generator. This would be the secret key shared by sender and receiver.
            byte[] secretkey = new Byte[size];

            // The array is now filled with cryptographically strong random bytes.
            rng.GetBytes(secretkey);
            return secretkey;
        }
    }
}