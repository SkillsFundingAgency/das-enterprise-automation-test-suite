using SFA.DAS.UI.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.RAA_V1.UITests.Project
{
    public class RAAV1Config
    {
        public string RecruitBaseUrl => UrlConfig.RecruitBaseUrl;
        public string ManageBaseUrl => UrlConfig.ManageBaseUrl;
        public string RecruitUserName { get; set; }
        public string RecruitPassword { get; set; }
        public string ManageUserName { get; set; }
        public string ManagePassword { get; set; }
    }
}
