using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using NUnit.Framework;

namespace ESFA.UI.Specflow.Framework.Project.Tests.TestSupport
{
    public class BrowserStackService
    {
        public static NameValueCollection Settings { get; set; }
        public static NameValueCollection Environments { get; set; }

        public static string Username { get; set; }
        public static string Browser { get; set; }
        public static string BrowserstackOsversion { get; set; }
        public static string BrowserstackOs { get; set; }
        public static string BrowserstackUsername { get; set; }
        public static string BrowserstackPassword { get; set; }
        public static string BrowserstackProjectName { get; set; }
        public static string BrowserstackBrowserVersion { get; set; }
        public static string Resolution { get; set; }

        public static string BrowserstackServerName { get; set; }

        private static readonly string _buildDateTime;

        static BrowserStackService()
        {
            _buildDateTime = DateTime.Now.ToString("ddMMMyyyy HH:mm").ToUpper();
        }

        private static void CheckBrowserStackSettings()
        {
            if (Environments == null || Settings == null)
                throw new Exception("Invalid BrowserStack settings. Please, check available options in app.config or extend the last one.");
        }

        public static IWebDriver Init()
        {
          //CheckBrowserStackSettings();

            var capability = new DesiredCapabilities();

            capability.SetCapability("browser", Username);

            capability.SetCapability("browser_version", BrowserstackBrowserVersion);

            capability.SetCapability("os", "Windows");

            capability.SetCapability("os_version", "10");

            capability.SetCapability("resolution", Resolution);
            
            capability.SetCapability("browserstack.user", BrowserstackUsername);

            capability.SetCapability("browserstack.key", BrowserstackPassword);

            capability.SetCapability("browserstack.debug", "true");

            capability.SetCapability("name", "testName");
         
            return new RemoteWebDriver(new Uri($"http://{BrowserstackServerName}/wd/hub/"), capability);
        }

        public static void MarkTestAsFailed(RemoteWebDriver driver, string exceptionMessage)
        {
            CheckBrowserStackSettings();

            string reqString = "{\"status\":\"failed\", \"reason\":\"" + exceptionMessage + "\"}";

            byte[] requestData = Encoding.UTF8.GetBytes(reqString);
            var sessionId = driver.SessionId.ToString();
            Uri myUri = new Uri(string.Format("https://www.browserstack.com/automate/sessions/" + sessionId + ".json"));
            WebRequest myWebRequest = HttpWebRequest.Create(myUri);
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;
            myWebRequest.ContentType = "application/json";
            myWebRequest.Method = "PUT";
            myWebRequest.ContentLength = requestData.Length;
            using (Stream st = myWebRequest.GetRequestStream()) st.Write(requestData, 0, requestData.Length);

            var myNetworkCredential = new NetworkCredential(Settings["BrowserstackUsername"], Settings["BrowserstackPassword"]);
            var myCredentialCache = new CredentialCache();
            myCredentialCache.Add(myUri, "Basic", myNetworkCredential);
            myHttpWebRequest.PreAuthenticate = true;
            myHttpWebRequest.Credentials = myCredentialCache;

            WebResponse myWebResponse = myWebRequest.GetResponse();
            Stream responseStream = myWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

            string pageContent = myStreamReader.ReadToEnd();
            Console.Write(pageContent);
            responseStream.Close();

            myWebResponse.Close();
        }
    }
}
