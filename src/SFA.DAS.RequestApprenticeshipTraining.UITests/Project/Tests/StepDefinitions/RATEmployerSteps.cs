using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.FAT.UITests.Project.Helpers;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Helpers;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.StepDefinitions;

[Binding]
public class RatEmployerSteps(ScenarioContext context)
{
    private readonly FATStepsHelper _fATV2StepsHelper = new(context);

    private AskIfTrainingProvidersCanRunThisCoursePage landingPage;

    private TrainingRequestDetailPage trainingRequestDetailPage;

    private readonly EmployerHomePageStepsHelper _homePageStepsHelper = new(context);

    [Given(@"an employer requests apprenticeship training")]
    public void AnEmployerRequestsApprenticeshipTraining() => RequestTrainingProvider(false);

    [Given(@"an employer adds location to requests apprenticeship training")]
    public void AnEmployerAddsLocationToRequestsApprenticeshipTraining() => RequestTrainingProvider(true);

    [When(@"the employer logs in to rat employer account")]
    public void WhenTheEmployerLogsInToRatEmployerAccount() => LoginViaRat(context.GetUser<RatEmployerUser>());

    [When(@"the employer logs in to rat cancel employer account")]
    public void TheEmployerLogsInToRatCancelEmployerAccount() => LoginViaRat(context.GetUser<RatCancelEmployerUser>());

    [When(@"the employer logs in to rat multi employer account")]
    public void TheEmployerLogsInToRatMultiEmployerAccount() => LoginViaRat(context.GetUser<RatMultiEmployerUser>());

    [Then(@"the employer submits the request for single location")]
    public void TheEmployerSubmitsTheRequestForSingleLocation()
    {
        SelectActiveRequest(landingPage.ClickStarNow().EnterMoreThan1Apprentices().ClickYesToChooseSingleLocation().GoToTrainingOptionsPage(true));
    }

    [Then(@"the employer submits the request for multiple location")]
    public void TheEmployerSubmitsTheRequest()
    {
        SelectActiveRequest(landingPage.ClickStarNow().EnterMoreThan1Apprentices().ClickNoToChooseMultipleLocation().ChooseRegion());
    }

    [Then(@"the employer submits the request for one apprentice")]
    public void TheEmployerSubmitsTheRequestForOneApprentice()
    {
        SelectActiveRequest(landingPage.ClickStarNow().Enter1Apprentices().GoToTrainingOptionsPage(false));
    }

    [Then(@"the employer can cancel the request")]
    public void TheEmployerCanCancelTheRequest()
    {
        trainingRequestDetailPage.CancelYourRequest().SubmitCancelRequest();
    }

    [Then(@"the employer receives the response")]
    public void TheEmployerReceivesTheResponse()
    {
        _homePageStepsHelper.GotoEmployerHomePage();

        new RatEmployerHomePage(context).NavigateToFindApprenticeshipPage().SelectActiveRequest().VerifyProviderResponse();
    }

    private void LoginViaRat(RatEmployerBaseUser loginUser) => landingPage = new EmployerPortalViaRatLoginHelper(context).LoginViaRat(loginUser);

    private void SelectActiveRequest(SelectTrainingOptionsPage selectTrainingOptionsPage) => trainingRequestDetailPage = selectTrainingOptionsPage.SelectTrainingOptions().SubmitAnswers().ReturnToRequestPage().SelectActiveRequest();

    private void RequestTrainingProvider(bool filterLocation)
    {
        var title = context.Get<RoatpV2SqlDataHelper>().GetTitlethatProviderDeosNotOffer(context.GetProviderConfig<ProviderConfig>().Ukprn);

        _fATV2StepsHelper.SearchForTrainingCourse(title).SelectFirstTrainingResult().ViewProvidersForThisCourse(filterLocation, string.Empty).RequestTrainingProvider();
    }

}