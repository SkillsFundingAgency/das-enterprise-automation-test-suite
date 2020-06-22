using SFA.DAS.UI.Framework;

namespace SFA.DAS.RAA_V1.UITests.Project
{
    public class RAAV1Config
    {
        public string Recruit_BaseUrl => UrlConfig.Recruit_BaseUrl;
        public string Manage_BaseUrl => UrlConfig.Manage_BaseUrl;
        public string RecruitUserName { get; set; }
        public string RecruitPassword { get; set; }
        public string ManageUserName { get; set; }
        public string ManagePassword { get; set; }
    }
}
