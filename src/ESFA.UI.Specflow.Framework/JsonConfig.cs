using System;
using System.Collections.Generic;
using System.Text;

namespace ESFA.UI.Specflow.Framework
{
    public class JsonConfig
    {
        public string BaseUrl { get; set; }
        public string Browser { get; set; }
        public string BrowserstackUsername { get; set; }

        public string BrowserstackPassword { get; set; }
        public string BrowserstackBrowser { get; set; }

        public string BrowserstackServerName{ get; set; }

        public string BrowserstackProject { get; set; }

        public string BrowserstackOs { get; set; }

        public string BrowserstackOsversion { get; set; }

        public string BrowserstackVersion { get; set; }
        public string Resolution { get; set; }
    }
}
