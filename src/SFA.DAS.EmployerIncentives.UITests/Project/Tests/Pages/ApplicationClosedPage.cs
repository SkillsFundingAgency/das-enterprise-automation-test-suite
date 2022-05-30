using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ApplicationClosedPage : EIBasePage
    {
        protected override string PageTitle => "Sorry, applications for incentive payments have closed";

        public ApplicationClosedPage(ScenarioContext context) : base(context) { }
    }
}
