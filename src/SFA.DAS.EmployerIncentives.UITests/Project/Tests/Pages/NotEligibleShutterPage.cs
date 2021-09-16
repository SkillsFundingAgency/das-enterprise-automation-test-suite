using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class NotEligibleShutterPage : EIBasePage
    {
        protected override string PageTitle => $"Not eligible for the payment";

        public NotEligibleShutterPage(ScenarioContext context, bool verifypage = true) : base(context, verifypage)
        {
        }
    }
}
