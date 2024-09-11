using TechTalk.SpecFlow;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Helpers.StubPages;
using SFA.DAS.Registration.UITests.Project.Helpers;


namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Helpers
{
    public class RATLoginHelper(ScenarioContext context)

    {
        private readonly RATTransitionLinkPage _rATTransitionLinkPage;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper = new(context);
        internal HomePage GoToHomePage(EasAccountUser loginUser) => _homePageStepsHelper.Login(loginUser);

        public void RATTransitionLinkPage()
        {
            _rATTransitionLinkPage.TransitionToRATFromFAT();
            //return new RATStubSignInBasePage(context);
        }


    }
}
