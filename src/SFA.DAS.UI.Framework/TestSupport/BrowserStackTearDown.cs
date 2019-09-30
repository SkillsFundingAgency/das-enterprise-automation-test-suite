using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Text;
using System.Net;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class BrowserStackTeardown
    {
        public static void MarkTestAsFailed(RemoteWebDriver webDriver, BrowserStackSetting options,string directory, string scenarioTitle, string message)
        {
            ScreenshotHelper.TakeScreenShot(webDriver, directory, scenarioTitle, true);

            string reqString = "{\"status\":\"failed\", \"reason\":\"" + message + "\"}";

            byte[] requestData = Encoding.UTF8.GetBytes(reqString);

            var sessionId = webDriver.SessionId.ToString();

            Uri myUri = new Uri($"{options.AutomateSessions}{sessionId}.json");

            WebRequest myWebRequest = HttpWebRequest.Create(myUri);

            HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;

            myWebRequest.ContentType = "application/json";

            myWebRequest.Method = "PUT";

            myWebRequest.ContentLength = requestData.Length;

            using (Stream st = myWebRequest.GetRequestStream()) st.Write(requestData, 0, requestData.Length);

            var myCredentialCache = new CredentialCache
            {
                { myUri, "Basic", new NetworkCredential(options.User, options.Key) }
            };

            myHttpWebRequest.PreAuthenticate = true;

            myHttpWebRequest.Credentials = myCredentialCache;

            WebResponse myWebResponse = myWebRequest.GetResponse();

            Stream responseStream = myWebResponse.GetResponseStream();

            StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

            string pageContent = myStreamReader.ReadToEnd();

            NUnit.Framework.TestContext.Progress.WriteLine(pageContent);

            responseStream.Close();

            myWebResponse.Close();
        }
    }
}
