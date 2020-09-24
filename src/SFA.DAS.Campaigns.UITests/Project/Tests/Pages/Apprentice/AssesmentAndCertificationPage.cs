using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class AssesmentAndCertificationPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Page not found";

        public AssesmentAndCertificationPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}
