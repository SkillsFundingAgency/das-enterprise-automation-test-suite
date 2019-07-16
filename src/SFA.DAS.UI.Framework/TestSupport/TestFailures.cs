using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Text;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class TestFailures
    {

        private readonly ScenarioContext _context;

        public TestFailures(ScenarioContext context)
        {
            _context = context;
        }

        public static void MarkBrowsertackTestAsFailed(RemoteWebDriver driver, JsonConfig options, ScenarioContext _context, string message)
        {
            String scenarioTitle = _context.ScenarioInfo.Title;
            DateTime dateTime = DateTime.Now;
            String failureImageName = dateTime.ToString("HH-mm-ss")
                + "_"
                + scenarioTitle
                + ".png";
            String screenshotsDirectory = AppDomain.CurrentDomain.BaseDirectory
                + "../../"
                + "\\Project\\Screenshots\\"
                + dateTime.ToString("dd-MM-yyyy")
                + "\\";
            if (!Directory.Exists(screenshotsDirectory))
            {
                Directory.CreateDirectory(screenshotsDirectory);
            }
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            String screenshotPath = Path.Combine(screenshotsDirectory, failureImageName);
            ss.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            Console.WriteLine($"{scenarioTitle} -- Scenario under feature failed and the screenshot is available at -- {screenshotPath}");
            string reqString = "{\"status\":\"failed\", \"reason\":\"" + message + "\"}";
            byte[] requestData = Encoding.UTF8.GetBytes(reqString);
            var sessionId = driver.SessionId.ToString();
            Uri myUri = new Uri(string.Format("https://www.browserstack.com/automate/sessions/" + sessionId + ".json"));
            WebRequest myWebRequest = HttpWebRequest.Create(myUri);
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;
            myWebRequest.ContentType = "application/json";
            myWebRequest.Method = "PUT";
            myWebRequest.ContentLength = requestData.Length;
            using (Stream st = myWebRequest.GetRequestStream()) st.Write(requestData, 0, requestData.Length);
            var myNetworkCredential = new NetworkCredential(options.BrowserstackUsername, options.BrowserstackPassword);
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
