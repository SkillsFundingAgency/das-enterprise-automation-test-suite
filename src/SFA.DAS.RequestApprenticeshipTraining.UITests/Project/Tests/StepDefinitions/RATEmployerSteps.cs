using SFA.DAS.FAT_V2.UITests.Project.Tests.Pages;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RATEmployerSteps(ScenarioContext context)
    {
        private readonly EmployerPortalLoginHelper _employerLoginHelper = new(context);

        [Given(@"the user clicks on ask if training providers can run this course as employer owner")]
        public void GivenTheUserClicksOnAskIfTrainingProvidersCanRunThisCourseAsEmployerOwner() => new ProviderSearchResultsPage(context).ClickAskProviders();

        [Then(@"the Employer logs in using employer RAT Account")]
        public void ThenTheEmployerLogsInUsingEmployerRatAccount() => _employerLoginHelper.Login(context.GetUser<RATOwnerUser>(), true);

    }
}