using SFA.DAS.UI.Framework;

namespace SFA.DAS.Roatp.UITests.Project
{
    public class RoatpConfig
    {
        public string Admin_BaseUrl => UrlConfig.Admin_BaseUrl;
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }
        public string Apply_BaseUrl => UrlConfig.Apply_BaseUrl;
        public string ApplyPassword { get; set; }
        public string RoatpDatabaseConnectionString { get; set; }
        public string ApplyDatabaseConnectionString{ get; set; }
        public string QnaDatabaseConnectionString { get; set; }
    }
}
