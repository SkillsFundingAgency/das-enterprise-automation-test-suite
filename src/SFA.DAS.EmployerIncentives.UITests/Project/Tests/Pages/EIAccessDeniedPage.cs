using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class EIAccessDeniedPage : AccessDeniedPage
    {
        protected override string PageTitle => "Your account does not have the right access";

        protected override string HomePageLinkText => "Return to account home";

        public EIAccessDeniedPage(ScenarioContext context) : base(context) { }
    }
}
