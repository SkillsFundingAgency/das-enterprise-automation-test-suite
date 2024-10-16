using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.FAT.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Helpers;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RATEmployerSteps(ScenarioContext context)
    {
        private readonly FATStepsHelper _fATV2StepsHelper = new(context);

        private AskIfTrainingProvidersCanRunThisCoursePage landingPage;

        private WeHaveveSharedThisWithTrainingProvidersPage submitConfirmationPage;

        [Given(@"an employer requests apprenticeship training")]
        public void AnEmployerRequestsApprenticeshipTraining() => RequestTrainingProvider(false);

        [Given(@"an employer adds location to requests apprenticeship training")]
        public void AnEmployerAddsLocationToRequestsApprenticeshipTraining() => RequestTrainingProvider(true);

        [When(@"the employer logs in to rat employer account")]
        public void WhenTheEmployerLogsInToRatEmployerAccount() => LoginViaRat(context.GetUser<RatEmployerUser>());

        [When(@"the employer logs in to rat cancel employer account")]
        public void TheEmployerLogsInToRatCancelEmployerAccount() => LoginViaRat(context.GetUser<RatCancelEmployerUser>());


        [Then(@"the employer submits the request for single location")]
        public void TheEmployerSubmitsTheRequestForSingleLocation()
        {
            SubmitAnswers(landingPage.ClickStarNow().EnterMoreThan1Apprentices().ClickYesForASingleLocation().GoToTrainingOptionsPage(true));
        }

        [Then(@"the employer submits the request for multiple location")]
        public void TheEmployerSubmitsTheRequest()
        {
            SubmitAnswers(landingPage.ClickStarNow().EnterMoreThan1Apprentices().ClickNoForAMultipleLocation().ChooseRegion());
        }

        [Then(@"the employer submits the request for one apprentice")]
        public void TheEmployerSubmitsTheRequestForOneApprentice()
        {
            SubmitAnswers(landingPage.ClickStarNow().Enter1Apprentices().GoToTrainingOptionsPage(false));
        }

        [Then(@"the employer can cancel the request")]
        public void TheEmployerCanCancelTheRequest()
        {
            submitConfirmationPage.ReturnToRequestPage().SelectActiveRequest().CancelYourRequest().SubmitCancelRequest();
        }

        private void LoginViaRat(RatEmployerBaseUser loginUser) => landingPage = new EmployerPortalViaRatLoginHelper(context).LoginViaRat(loginUser);

        private void SubmitAnswers(SelectTrainingOptionsPage selectTrainingOptionsPage) => submitConfirmationPage = selectTrainingOptionsPage.SelectTrainingOptions().SubmitAnswers();


        private void RequestTrainingProvider(bool filterLocation)
        {
            var courseTitles = context.Get<RoatpV2SqlDataHelper>().GetCourseTitlesthatProviderDeosNotOffer(context.GetProviderConfig<ProviderConfig>()?.Ukprn);

            var randomCourse = RandomDataGenerator.GetRandomElementFromListOfElements(courseTitles);

            _fATV2StepsHelper.SearchForTrainingCourse(randomCourse).SelectFirstTrainingResult().ViewProvidersForThisCourse(filterLocation, string.Empty).RequestTrainingProvider();
        }

    }
}