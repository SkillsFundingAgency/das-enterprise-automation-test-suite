using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.UI.Framework
{
    public class FrameworkConfig
    {
        public TimeOutConfig TimeOutConfig { get; set; }

        public BrowserStackSetting BrowserStackSetting { get; set; }

        public bool TakeEveryPageScreenShot { get; set; }
    }

    public class EnvironmentConfig
    {
        public string EnvironmentName { get; internal set; }

        public string ProjectName { get; internal set; }

    }

    public class TestExecutionConfig
    {
        public string Browser { get; internal set; }
    }

}
