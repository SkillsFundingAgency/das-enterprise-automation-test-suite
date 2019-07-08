//using System;

//namespace ESFA.UI.Specflow.Framework.Project.Tests.TestSupport
//{
//    public class Configurator
//    {
//        private static Configurator configuratorInstance = null;

//        private String browser;
//        private String baseUrl;

//        private Configurator()
//        {
//            browser = "chrome";//ConfigurationManager.AppSettings["Browser"];
//            baseUrl = "https://www.gov.uk/";// ConfigurationManager.AppSettings["BaseUrl"];
//        }

//        public static Configurator GetConfiguratorInstance()
//        {
//            if (configuratorInstance == null)
//            {
//                configuratorInstance = new Configurator();
//            }
//            return configuratorInstance;
//        }

//        public String GetBrowser()
//        {
//            return browser;
//        }

//        public String GetBaseUrl()
//        {
//            return baseUrl;
//        }
//    }
//}