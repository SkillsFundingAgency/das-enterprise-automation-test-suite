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

        [Given(@"an employer requests apprenticeship trainning")]
        public void AnEmployerRequestsApprenticeshipTrainning()
        {
            var courseTitles = context.Get<RoatpV2SqlDataHelper>().GetCourseTitlesthatProviderDeosNotOffer(context.GetProviderConfig<ProviderConfig>()?.Ukprn);

            var randomCourse = RandomDataGenerator.GetRandomElementFromListOfElements(courseTitles);

            _fATV2StepsHelper.SearchForTrainingCourse(randomCourse).SelectFirstTrainingResult().ClickViewProvidersForThisCourse().ClickAskProviders();
        }

        [When(@"the employer logs in to rat employer account")]
        public void WhenTheEmployerLogsInToRatEmployerAccount()
        {
            landingPage = new EmployerPortalViaRatLoginHelper(context).LoginViaRat(context.GetUser<RATOwnerUser>());
        }

        [Then(@"the employer submits the request for single location")]
        public void TheEmployerSubmitsTheRequestForSingleLocation()
        {
            landingPage.ClickStarNow().EnterMoreThan1Apprentices().ClickYesForASingleLocation().EnterCityTownPostcode().SelectTrainingOptions().SubmitAnswers();
        }

        [Then(@"the employer submits the request for multiple location")]
        public void TheEmployerSubmitsTheRequest()
        {
            landingPage.ClickStarNow().EnterMoreThan1Apprentices().ClickNoForAMultipleLocation().ChooseRegion().SelectTrainingOptions().SubmitAnswers();
        }
    }
}