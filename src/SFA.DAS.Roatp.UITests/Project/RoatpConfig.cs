using SFA.DAS.UI.Framework;

namespace SFA.DAS.Roatp.UITests.Project
{
    public class RoatpConfig
    {
        public string AdminBaseUrl => UrlConfig.AdminBaseUrl;
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }
        public string ApplyBaseUrl => UrlConfig.ApplyBaseUrl;
        public string ApplyPassword { get; set; }
        public string RoatpDatabaseConnectionString { get; set; }
        public string ApplyDatabaseConnectionString{ get; set; }
        public string QnaDatabaseConnectionString { get; set; }
    }
}
