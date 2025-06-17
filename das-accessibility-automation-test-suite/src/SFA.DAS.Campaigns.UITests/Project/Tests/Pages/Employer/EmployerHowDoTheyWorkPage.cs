using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerHowDoTheyWorkPage(ScenarioContext context) : EmployerBasePage(context)
    {
        protected override string PageTitle => "How do they work?";

        public void VerifyHowDoTheyWorkPageSubHeadings() => VerifyFiuCards(() => ClickHowDoTheyWorkLink());
    }
}