using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerHowDoTheyWorkPage : EmployerBasePage
    {
        protected override string PageTitle => "How do they work?";

        public EmployerHowDoTheyWorkPage(ScenarioContext context) : base(context) { }

        public void VerifyHowDoTheyWorkPageSubHeadings() => VerifyFiuCards(() => ClickHowDoTheyWorkLink());
    }
}