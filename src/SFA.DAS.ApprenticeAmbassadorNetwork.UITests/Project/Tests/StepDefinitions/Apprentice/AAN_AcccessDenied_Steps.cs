using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Apprentice
{
    [Binding]
    public class AAN_AcccessDenied_Steps
    {
        private readonly ScenarioContext context;

        private AccessDeniedPage accessDeniedPage;

        public AAN_AcccessDenied_Steps(ScenarioContext context) => this.context = context;

        [Given(@"the non Private beta apprentice logs into AAN portal")]
        public void GivenTheNonPrivateBetaApprenticeLogsIntoAANPortal() => accessDeniedPage = new SignInPage(context).NonPrivateBetaUserDetails(context.Get<AanNonBetaUser>());

        [Then(@"an Access Denied page should be displayed")]
        public void ThenAccessDeniedPageShouldBeDisplayed() => accessDeniedPage.VerifyHomeLink();
    }
}
