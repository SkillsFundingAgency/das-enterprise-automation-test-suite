using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;

namespace SFA.DAS.ProvideFeedback.UITests;

[Binding]
public class ApprenticeFeedbackSteps
{

    private readonly ScenarioContext _context;
    private readonly ObjectContext _objectContext;
    private readonly SetApprenticeDetailsHelper _setApprenticeDetailsHelper;

    public ApprenticeFeedbackSteps(ScenarioContext context)
    {
        _context = context;
        _objectContext = context.Get<ObjectContext>();
        _setApprenticeDetailsHelper = new SetApprenticeDetailsHelper(_context);
    }

    [Given(@"the apprentice logs into apprentice portal")]
    public void GivenTheApprenticeLogsIntoApprenticePortal()
    {
        var (firstName, lastName) = _setApprenticeDetailsHelper.SetApprenticeDetailsInObjectContext(_context.GetUser<ApprenticeFeedbackUser>());

        var apprenticeOverviewPage = new SignIntoMyApprenticeshipPage(_context).GoToApprenticeOverviewPage(false);

        new ApprenticeOverview_FeedbackPage(_context).GiveFeedbackOnYourTrainingProvider();
    }

}
