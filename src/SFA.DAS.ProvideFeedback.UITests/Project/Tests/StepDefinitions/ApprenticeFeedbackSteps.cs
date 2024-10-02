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

    [Given(@"apprentice completes the feedback journey for a training provider")]
    public void GivenApprenticeCompletesTheFeedbackJourneyForATrainingProvider()
    {
        new ApprenticeFeedbackHomePage(_context)
            .GiveFeedbackOnYourTrainingProvider()
            .SelectATrainingProvider()
            .StartNow()
            .ProvideFeedback()
            .ProvideRating()
            .ChangeFeedbackAttribute()
            .GoToCheckYourAnswersPage()
            .ChangeOverallRating()
            .GoToCheckYourAnswersPage()
            .SubmitAnswers();
    }

    [Given(@"the apprentice is eligible to give feedback on their providers")]
    public void GivenTheApprenticeIsEligibleToGiveFeedbackOnTheirProviders()
    {
        var objectContext = _context.Get<ObjectContext>();
        var dbConfig = _context.Get<DbConfig>();

        var apprenticeId = objectContext.GetApprenticeId();

        var sqlHelper = new ApprenticeFeedbackSqlHelper(objectContext, dbConfig);

        sqlHelper.SetFeedbackEligibility(apprenticeId);
    }
}
