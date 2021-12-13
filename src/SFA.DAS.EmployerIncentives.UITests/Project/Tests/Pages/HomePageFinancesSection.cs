using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class HomePageFinancesSection_EI : HomePage
    {
        public HomePageFinancesSection_EI(ScenarioContext context) : base(context) { }

        public EIAccessDeniedPage AccessEIHubLinkRedirectsToAccessDeniedPage()
        {
            formCompletionHelper.Click(EIHubLink);
            return new EIAccessDeniedPage(_context);
        }

        public EIHubPage NavigateToEIHubPage()
        {
            formCompletionHelper.Click(EIHubLink);
            return new EIHubPage(_context);
        }

        public ChooseOrganisationPage NavigateToChooseOrgPage()
        {
            formCompletionHelper.Click(EIHubLink);
            return new ChooseOrganisationPage(_context);
        }
    }
}
