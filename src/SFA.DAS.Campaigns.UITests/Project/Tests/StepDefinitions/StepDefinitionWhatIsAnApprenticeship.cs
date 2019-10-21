using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class WhatIsAnApprenticeship
    {
        #region Private Variables
        private readonly ScenarioContext _context;
        private WhatIsAnApprenticeshipPage whatIsAnApprenticeshipPage;
        #endregion

        public WhatIsAnApprenticeship(ScenarioContext context)
        {
            _context = context;
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