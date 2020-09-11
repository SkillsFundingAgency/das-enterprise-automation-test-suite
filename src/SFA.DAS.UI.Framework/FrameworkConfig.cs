using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.UI.Framework
{
    public class FrameworkConfig
    {
        public NServiceBusConfig NServiceBusConfig { get; internal set; }

        public TimeOutConfig TimeOutConfig { get; internal set; }

        public BrowserStackSetting BrowserStackSetting { get; internal set; }

        public bool IsVstsExecution { get; internal set; }

        public string SampleFileName => "Sample.pdf";
    }
}
