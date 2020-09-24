using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class ChooseTheTrainingProviderPage : EmployerBasePage
    {
        protected override string PageTitle => "Page not found";

        public ChooseTheTrainingProviderPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}

