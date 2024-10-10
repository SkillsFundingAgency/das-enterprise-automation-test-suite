using SFA.DAS.FAT.UITests.Project.Tests.Pages;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Helpers;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages;
using TechTalk.SpecFlow;


namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RATEmployerSteps(ScenarioContext context)
    {
        private AskIfTrainingProvidersCanRunThisCoursePage landingPage; 

        [Given(@"the user clicks on ask if training providers can run this course as employer owner")]
        public void GivenTheUserClicksOnAskIfTrainingProvidersCanRunThisCourseAsEmployerOwner() => new ProviderSearchResultsPage(context).ClickAskProviders();

        [Then(@"the Employer logs in using employer RAT Account")]
        public void ThenTheEmployerLogsInUsingEmployerRatAccount() => landingPage = new EmployerPortalViaRatLoginHelper(context).LoginViaRat(context.GetUser<RATOwnerUser>());

        [Then(@"the employer submits the request for single location")]
        public void TheEmployerSubmitsTheRequestForSingleLocation()
        {
            landingPage.ClickStarNow().EnterMoreThan1Apprentices().ClickYesForSameLocation().EnterCityTownPostcode().SelectTrainingOptions().SubmitAnswers();
        }

        [Then(@"the employer submits the request for multiple location")]
        public void TheEmployerSubmitsTheRequest()
        {
            landingPage.ClickStarNow().EnterMoreThan1Apprentices().ClickNoForADifferentLocation().ChooseRegion().SelectTrainingOptions().SubmitAnswers();
        }
    }
}