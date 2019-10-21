using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class WhatIsAnApprenticeship
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private WhatIsAnApprenticeshipPage whatIsAnApprenticeshipPage;
        #endregion

        public WhatIsAnApprenticeship(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaingnsProjectConfig<CampaignsConfig>();
            _objectContext = context.Get<ObjectContext>();
            whatIsAnApprenticeshipPage = new WhatIsAnApprenticeshipPage(_context);
        }

        [Then(@"I verify the content under WHAT IS AN APPRENTICESHIP section")]
        public void VerifySoYouHaveFoundTheApprenticeshipSection()
        {
            whatIsAnApprenticeshipPage.VerifyContentUnderWhatIsAnApprenticeshipSection();
        }

        [Then(@"I verify the content under WHAT ARE THE DIFFERENT TYPES OF APPRENTICESHIPS section")]
        public void VerifyDIFFERENTTYPESOFAPPRENTICESHIPSSection()
        {
            whatIsAnApprenticeshipPage.VerifyContentUnderDifferentTypesOfApprenticeshipsSection();
        }

    }
}