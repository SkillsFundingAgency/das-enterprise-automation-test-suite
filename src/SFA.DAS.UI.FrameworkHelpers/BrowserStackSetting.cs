namespace SFA.DAS.UI.FrameworkHelpers
{
    public class BrowserStackSetting
    {
        public string User { get; set; }

        public string Key { get; set; }

        public string Browser { get; set; }

        public string ServerName => "http://hub-cloud.browserstack.com/wd/hub/";

        public string AutomateSessions => "https://www.browserstack.com/automate/sessions/";

        public string Build { get; set; }

        public string Project { get; set; }

        public string Os { get; set; }

        public string Osversion { get; set; }

        public string BrowserVersion { get; set; }

        public string Resolution { get; set; }

        public string Name { get; set; }

        public bool EnableNetworkLogs { get; set; }

        public string TimeZone => "London";
    }
}
