using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class AssesmentAndCertificationPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Error";

        public AssesmentAndCertificationPage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }
    }
}
