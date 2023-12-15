namespace SFA.DAS.ProvideFeedback.UITests;


[Binding]
public class EmployerFeedbackSteps(ScenarioContext context)
{
    private EmployerFeedbackCheckYourAnswersPage _providerFeedbackCheckYourAnswers;
    private readonly EmployerPortalLoginHelper _employerPortalLoginHelper = new(context);
    private readonly EmployerFeedbackSqlHelper _provideFeedbackSqlHelper = context.Get<EmployerFeedbackSqlHelper>();
    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

    [Given(@"the Employer logins into Employer Portal")]
    public void WhenTheEmployerLoginsIntoEmployerPortal()
    {
        var user = context.GetUser<EmployerFeedbackUser>();

        _employerPortalLoginHelper.Login(user, true);

        _objectContext.SetTestData(_provideFeedbackSqlHelper.GetTestData(user.Username));
    }

    [Given(@"completes the feedback journey for a training provider")]
    public void GivenCompletesTheFeedbackJourneyForATrainingProvider()
    {
        _providerFeedbackCheckYourAnswers = GoToCheckYourAnswersPage(new EmployerDashboardPage(context)
           .ClickFeedbackLink()
           .SelectTrainingProvider()
           .ConfirmTrainingProvider());

        _providerFeedbackCheckYourAnswers.SubmitAnswersNow();
    }

    [Given(@"completes the feedback journey for a training provider via survey code")]
    public void GivenCompletesTheFeedbackJourneyForATrainingProviderViaSurveyCode()
    {
        _providerFeedbackCheckYourAnswers = GoToCheckYourAnswersPage(new EmployerDashboardPage(context)
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
    public void ThenTheUserCanNotResubmitTheFeedback() => _ = new EmployerFeedbackAlreadySubmittedPage(context);

    private static EmployerFeedbackCheckYourAnswersPage GoToCheckYourAnswersPage(EmployerFeedbackHomePage page)
    {
        return page.StartNow().SelectOptionsForDoingWell().ContinueToOverallRating().SelectVPoorAndContinue();
    }
}
