using SFA.DAS.FAAV2.UITests.Project.Pages;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAASteps(ScenarioContext context)
    {

        private readonly TabHelper _tabHelper = context.Get<TabHelper>();


        [Then(@"the candidate can login")]
        public void ThenTheCandidateCanLogin()
        {
            _tabHelper.GoToUrl(UrlConfig.FAAV2_BaseUrl);

            new FAASignedOutLandingpage(context).GoToSignInPage().SubmitValidUserDetails(context.GetUser<FAAApplyUser>()).Continue();

            new FAASignedInLandingpage(context);
        }

    }
}