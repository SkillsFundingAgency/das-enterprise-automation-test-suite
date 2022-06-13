namespace SFA.DAS.ProvideFeedback.UITests;

[Binding]
public class ProvideFeedbackSteps
{
    private readonly ScenarioContext _context;
    private ProvideFeedbackCheckYourAnswersPage _providerFeedbackCheckYourAnswers;
    private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
    private readonly ProvideFeedbackSqlHelper _provideFeedbackSqlHelper;
    private readonly ObjectContext _objectContext;

    public ProvideFeedbackSteps(ScenarioContext context)
    {
        _context = context;
        _objectContext = context.Get<ObjectContext>();
        _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
        _provideFeedbackSqlHelper = context.Get<ProvideFeedbackSqlHelper>();
    }

    [Given(@"the Employer logins into Employer Portal")]
    public void WhenTheEmployerLoginsIntoEmployerPortal()
    {
        var user = _context.GetUser<ProvideFeedbackUser>();

        _employerPortalLoginHelper.Login(user, true);

        _objectContext.SetTestData(_provideFeedbackSqlHelper.GetTestData(user.Username));
    }

    [Given(@"completes the feedback journey for a training provider")]
    public void GivenCompletesTheFeedbackJourneyForATrainingProvider()
    {
        _providerFeedbackCheckYourAnswers = GoToCheckYourAnswersPage(new EmployerDashboardPage(_context)
           .ClickFeedbackLink()
           .SelectTrainingProvider()
           .ConfirmTrainingProvider());

        _providerFeedbackCheckYourAnswers.SubmitAnswersNow();
    }

    [Given(@"completes the feedback journey for a training provider via survey code")]
    public void GivenCompletesTheFeedbackJourneyForATrainingProviderViaSurveyCode()
    {
        _providerFeedbackCheckYourAnswers = GoToCheckYourAnswersPage(new EmployerDashboardPage(_context)
            .OpenFeedbackLinkWithSurveyCode());
    }

    [Then(@"the user can change the answers and submits")]
    public void ThenTheUserCanChangeTheAnswersAndSubmits()
    {
        _providerFeedbackCheckYourAnswers.ChangeQuestionOne()
            .ContinueToCheckYourAnswers()
            .ChangeQuestionTwo()
            .ContinueToCheckYourAnswers()
            .ChangeQuestionThree()
            .SelectGoodAndContinue()
            .SubmitAnswersNow();
    }

    [Then(@"the user can not resubmit the feedback")]
    public void ThenTheUserCanNotResubmitTheFeedback() => new ProvideFeedbackAlreadySubmittedPage(_context);

    private static ProvideFeedbackCheckYourAnswersPage GoToCheckYourAnswersPage(ProvideFeedbackHomePage page)
    {
       return page.StartNow().SelectOptionsForDoingWell().ContinueToOverallRating().SelectVPoorAndContinue();
    }
}
