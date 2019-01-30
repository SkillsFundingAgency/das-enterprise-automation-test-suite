using System;
using System.Configuration;

namespace ESFA.UI.Specflow.Framework.Project.Tests.TestSupport
{
    public class Configurator
    {
        public String browser;
        public String baseUrl;

        public Configurator()
        {
            browser = ConfigurationManager.AppSettings["Browser"];
            baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        }

    }
}