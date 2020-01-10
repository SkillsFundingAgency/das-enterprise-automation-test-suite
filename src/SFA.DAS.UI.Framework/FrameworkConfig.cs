using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.UI.Framework
{
    public class FrameworkConfig
    {
        public TimeOutConfig TimeOutConfig { get; internal set; }

        public BrowserStackSetting BrowserStackSetting { get; internal set; }

        public bool IsVstsExecution { get; internal set; }
    }
}
