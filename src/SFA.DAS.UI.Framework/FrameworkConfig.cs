using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.UI.Framework
{
    public class FrameworkConfig
    {
        public NServiceBusConfig NServiceBusConfig { get; internal set; }

        public TimeOutConfig TimeOutConfig { get; internal set; }

        public BrowserStackSetting BrowserStackSetting { get; internal set; }

        internal bool IsVstsExecution { get; set; }

        internal bool CanCaptureUrl { get; set; }

        internal bool CanTakeFullScreenShot { get; set; }

        internal bool IsAccessibilityTesting { get; set; }

        public string SampleFileName => "Sample.pdf";
    }
}
