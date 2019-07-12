using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using NUnit.Framework;

namespace ESFA.UI.Specflow.Framework.TestSupport
{
   

    class TestFailures
    {
        public static NameValueCollection Settings { get; set; }

        public static void MarkBrowsertackTestAsFailed(RemoteWebDriver driver, string exceptionMessage)
        {
          //  CheckBrowserStackSettings();

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
