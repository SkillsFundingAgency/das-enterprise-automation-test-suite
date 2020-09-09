using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class ChooseTheRightApprenticeshipPage : EmployerBasePage
    {
        protected override string PageTitle => "Page not found";
        public ChooseTheRightApprenticeshipPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}

