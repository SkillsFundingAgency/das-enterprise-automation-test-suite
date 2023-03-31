namespace SFA.DAS.EPAO.UITests.Project.Helpers;

public class EPAOWithdrawalHelper
{
    private readonly ScenarioContext _context;

    public EPAOWithdrawalHelper(ScenarioContext context) => _context = context;

    public void StartOfStandardWithdrawalJourney()
    {
        AS_LoggedInHomePage aS_LoggedInHomePage = new(_context);
        aS_LoggedInHomePage.ClickWithdrawFromAStandardLink()
                           .ClickContinueOnWithdrawFromAStandardOrTheRegisterPage()
                           .ClickStartNewWithdrawalNotification()
                           .ClickAssessingASpecificStandard()
                           .ClickASpecificStandardToWithdraw()
                           .ContinueWithWithdrawalRequest();
    }

    public void StartOfRegisterWithdrawalJourney()
    {
        AS_LoggedInHomePage aS_LoggedInHomePage = new(_context);
        aS_LoggedInHomePage.ClickWithdrawFromTheRegisterLink()
                           .ClickContinueOnWithdrawFromAStandardOrTheRegisterPage()
                           .ClickStartNewWithdrawalNotification()
                           .ClickWithdrawFromRegister()
                           .ContinueWithWithdrawalRequest();
    }

    public void StandardApplicationFinalJourney()
    {
        AS_WithdrawalRequestOverviewPage aS_ApplicationOverviewPage = new(_context);
        aS_ApplicationOverviewPage.ClickGoToStandardWithdrawalQuestions()
                                  .ClickGoToReasonForWithdrawingQuestionLink()
                                  .ClickExternalQualityAssuranceProviderHasChanged()
                                  .ClickYesAndContinue()
                                  .EnterSupportingInformationForStandardWithdrawal()
                                  .EnterDateToWithdraw()
                                  .VerifyAndReturnToApplicationOverviewPage()
                                  .AcceptAndSubmit();
    }

    public void RegisterWithdrawalQuestions()
    {
        AS_WithdrawalRequestOverviewPage aS_ApplicationOverviewPage = new(_context);
        aS_ApplicationOverviewPage.ClickGoToRegisterWithdrawalQuestions()
            .ClickGoToReasonForWithdrawingFromRegisterQuestionLink()
            .ClickAssessmentPlanHasChangedAndEnterOptionalReason()
            .ClickNoAndContinue()
            .EnterAnswerForHowWillYouSupportLearnerYouAreNotGoingToAssess()
            .EnterSupportingInformationForRegisterWithdrawal()
            .EnterDateToWithdraw()
            .VerifyWithSupportingLearnersQuestionAndReturnToApplicationOverviewPage()
            .AcceptAndSubmitWithHowWillYouSuportQuestion();
    }

    public void VerifyStandardSubmitted() => new AS_WithdrawalApplicationSubmittedPage(_context);

    public void VerifyTheInProgressStatus()
    {
        new AS_LoggedInHomePage(_context)
            .ClickWithdrawFromAStandardLink()
            .ClickContinueOnWithdrawFromAStandardOrTheRegisterPage()
            .ValidateStatus("In progress");
    }

    public void VerifyInProgressViewLinkNavigatesToApplicationOverviewPage()
    {
        new AS_YourWithdrawalRequestsPage(_context).ClickOnViewLinkForInProgressApplication();
    }

    public AD_YouhaveApprovedThisWithdrawalNotification ApproveAStandardWithdrawal(StaffDashboardPage staffDashboardPage)
    {
        return staffDashboardPage
            .GoToNewWithdrawalApplications()
            .GoToStandardWithdrawlApplicationOverivewPage()
            .GoToWithdrawalRequestQuestionsPage()
            .MarkCompleteAndGoToWithdrawalApplicationOverviewPage()
            .ClickCompleteReview()
            .ContinueWithWithdrawalRequest()
            .ClickApproveApplication();
    }

    public AD_YouhaveApprovedThisWithdrawalNotification ApproveARegisterWithdrawal(StaffDashboardPage staffDashboardPage)
    {
        return staffDashboardPage
            .GoToNewWithdrawalApplications()
            .GoToRegisterWithdrawlApplicationOverviewPage()
            .GoToWithdrawalRequestQuestionsPage()
            .MarkCompleteAndGoToWithdrawalApplicationOverviewPage()
            .ClickCompleteReview()
            .ContinueWithWithdrawalRequest()
            .ClickApproveApplication();
    }

    public AD_WithdrawalApplicationsPage AddFeedbackToARegisterWithdrawalApplication(StaffDashboardPage staffDashboardPage)
    {
        return staffDashboardPage
            .GoToNewWithdrawalApplications()
            .GoToRegisterWithdrawlApplicationOverviewPage()
            .GoToWithdrawalRequestQuestionsPage()
            .ClickAddFeedbackToHowWillYouSupportLearnersQuestion()
            .AddFeedbackMessage()
            .MarkCompleteAndGoToWithdrawalApplicationOverviewPage()
            .ClickCompleteReview()
            .ContinueWithWithdrawalRequest()
            .ClickAddFeedback()
            .ReturnToWithdrawalApplications();
    }
    public void ReturnToWithdrawalApplicationsPage()
    {
        new AD_YouhaveApprovedThisWithdrawalNotification(_context).ReturnToWithdrawalApplications();
    }

    public void VerifyApplicationMovedFromNewToFeedback() => new AD_WithdrawalApplicationsPage(_context).VerifyAnApplicationAddedToFeedbackTab();

    public void VerifyApplicationIsMovedToApprovedTab() => new AD_WithdrawalApplicationsPage(_context).VerifyApprovedTabContainsRegisterWithdrawal();


    public void AmmendWithdrawalApplication()
    {
        AS_LoggedInHomePage aS_LoggedInHomePage = new(_context);
        aS_LoggedInHomePage.ClickWithdrawFromTheRegisterLink()
                           .ClickContinueOnWithdrawFromAStandardOrTheRegisterPage()
                           .ClickViewOnRegisterWithdrawalWithFeedbackAdded()
                           .ClickContinueButton()
                           .ClickSupportingCurrentLearnersFeedback()
                           .UpdateAnswerForHowWillYouSupportLearnersYouAreNotGoingToAssess()
                           .SubmitUpdatedAnswers();
    }

    public AD_YouhaveApprovedThisWithdrawalNotification ApproveAmmendedRegisterWithdrawal(StaffDashboardPage staffDashboardPage)
    {
        return staffDashboardPage
            .GoToFeedbackWithdrawalApplications()
            .GoToAmmendedWithdrawalApplicationOverviewPage()
            .VerifyAnswerUpdatedTag()
            .GoToWithdrawalRequestQuestionsPage()
            .MarkCompleteAndGoToWithdrawalApplicationOverviewPage()
            .ClickCompleteReview()
            .ContinueWithWithdrawalRequest()
            .ClickApproveApplication();
    }

    public AD_WithdrawalApplicationsPage VerifyWithdrawalFromRegisterApproved()
    {
        var approvedPage = new AD_YouhaveApprovedThisWithdrawalNotification(_context);

        return approvedPage.VerifyRegisterWithdrawalBodyText()
            .ReturnToWithdrawalApplications();
    }
}