using SFA.DAS.UI.Framework;

namespace SFA.DAS.FAA.UITests.Project
{
    public class FAAConfig
    {
        public string FAABaseUrl => UrlConfig.FAABaseUrl.ToLower();
        public string FAAUserName { get; set; }
        public string FAAPassword { get; set; }
        public string FAAFirstName { get; set; }
        public string FAALastName { get; set; }
    }
}
