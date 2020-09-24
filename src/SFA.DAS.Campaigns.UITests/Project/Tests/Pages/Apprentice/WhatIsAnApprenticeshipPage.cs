using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class WhatIsAnApprenticeshipPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Page not found";

        public WhatIsAnApprenticeshipPage(ScenarioContext context) : base(context) 
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}
