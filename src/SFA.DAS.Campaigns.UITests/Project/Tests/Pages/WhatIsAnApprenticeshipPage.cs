using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class WhatIsAnApprenticeshipPage : ApprenticeshipBasePage
    {
        protected override string PageTitle => "WHAT IS AN APPRENTICESHIP?";

        public WhatIsAnApprenticeshipPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
