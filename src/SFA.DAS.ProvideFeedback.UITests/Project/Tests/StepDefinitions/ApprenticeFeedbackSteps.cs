using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Features.ConfirmIdentity;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page.StubPages;
using SFA.DAS.Login.Service.Project;

namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.StepDefinitions;

[Binding]
public class ApprenticeFeedbackSteps
{

    private readonly ScenarioContext _context;
    private readonly SetApprenticeDetailsHelper _setApprenticeDetailsHelper;

    public ApprenticeFeedbackSteps(ScenarioContext context)
    {
        _context = context;
        _setApprenticeDetailsHelper = new SetApprenticeDetailsHelper(_context);
    }

    [Given(@"the apprentice logs into apprentice portal")]
    public void GivenTheApprenticeLogsIntoApprenticePortal()
    {
        var user = _context.GetUser<ApprenticeFeedbackUser>();

        _setApprenticeDetailsHelper.SetApprenticeDetailsInObjectContext(user);

        new StubSignInApprenticeAccountsPage(_context).SubmitValidUserDetails(user).Continue();

        _ = new ApprenticeOverviewPage(_context, false);
    }

   
    [Given(@"the apprentice is eligible to give feedback on their providers")]
    public void GivenTheApprenticeIsEligibleToGiveFeedbackOnTheirProviders()
    {
        var objectContext = _context.Get<ObjectContext>();
        var dbConfig = _context.Get<DbConfig>();
        var apprenticeId = objectContext.GetApprenticeId();
        var sqlHelper = new ApprenticeFeedbackSqlHelper(objectContext, dbConfig);
        sqlHelper.ResetFeedbackEligibility(apprenticeId);
    }

    [When(@"apprentice completes the feedback journey for a training provider")]
    public void WhenApprenticeCompletesTheFeedbackJourneyForATrainingProvider()
    {
        new ApprenticeFeedbackSelectProviderPage(_context)
            .SelectATrainingProvider()
            .StartNow()
            .ProvideFeedback()
            .ProvideRating()
            .ChangeFeedbackAttribute()
            .GoToCheckYourAnswersPage()
            .ChangeOverallRating()
            .GoToCheckYourAnswersPage()
            .SubmitAnswers()
            .GiveFeedbackOnYourTrainingProvider();
    }

    [Given(@"the apprentice has not provided feedback previously")]
    public void GivenTheApprenticeHasNotProvidedFeedbackPreviously()
    {
        var objectContext = _context.Get<ObjectContext>();
        var dbConfig = _context.Get<DbConfig>();
        var apprenticeId = objectContext.GetApprenticeId();
        var sqlHelper = new ApprenticeFeedbackSqlHelper(objectContext, dbConfig);
        sqlHelper.RemoveAllFeedback(apprenticeId);
    }

    [Then(@"the feedback status shows as Pending")]
    public void ThenTheFeedbackStatusShowsAsPending()
    {
        var feedbackCompletePage = new ApprenticeFeedbackHomePage(_context);
        var selectProviderPage = feedbackCompletePage.GiveFeedbackOnYourTrainingProvider();
        selectProviderPage.VerifyFeedbackStatusAsPending();
    }

    [Then(@"the feedback status shows as Submitted")]
    public void ThenTheFeedbackStatusShowsAsSubmitted()
    {
        var selectProviderPage = new ApprenticeFeedbackSelectProviderPage(_context);
        selectProviderPage.VerifyFeedbackStatusAsSubmitted();
    }
}
