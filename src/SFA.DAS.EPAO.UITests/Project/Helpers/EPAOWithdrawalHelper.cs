namespace SFA.DAS.EPAO.UITests.Project.Helpers;

public class EPAOWithdrawalHelper(ScenarioContext context)
{
    private readonly EPAOApplySqlDataHelper _ePAOSqlDataHelper = context.Get<EPAOApplySqlDataHelper>();

    public void StartOfStandardWithdrawalJourney()
    {
        AS_LoggedInHomePage aS_LoggedInHomePage = new(context);

        if (_ePAOSqlDataHelper.HasWithdrawals(context.GetUser<EPAOWithdrawalUser>().Username))
        {
            aS_LoggedInHomePage.ClickWithdrawFromAStandardLink()
               .ClickContinueOnWithdrawFromAStandardOrTheRegisterPageWhenWithdrawalsExist()
               .ClickStartNewWithdrawalNotification()
               .ClickAssessingASpecificStandard()
               .ClickASpecificStandardToWithdraw()
               .ContinueWithWithdrawalRequest();
        }
        else
        {
            aS_LoggedInHomePage.ClickWithdrawFromAStandardLink()
                .ClickContinueOnWithdrawFromAStandardOrTheRegisterPageWhenNoWithdrawalsExist()
                .ClickAssessingASpecificStandard()
                .ClickASpecificStandardToWithdraw()
                .ContinueWithWithdrawalRequest();
        }
    }

    public void StartOfRegisterWithdrawalJourney()
    {
        AS_LoggedInHomePage aS_LoggedInHomePage = new(context);

        if (_ePAOSqlDataHelper.HasWithdrawals(context.GetUser<EPAOWithdrawalUser>().Username))
        {
            aS_LoggedInHomePage.ClickWithdrawFromTheRegisterLink()
                .ClickContinueOnWithdrawFromAStandardOrTheRegisterPageWhenWithdrawalsExist()
                .ClickStartNewWithdrawalNotification()
                .ClickWithdrawFromRegister()
                .ContinueWithWithdrawalRequest();
        }
        else
        {
            aS_LoggedInHomePage.ClickWithdrawFromTheRegisterLink()
                .ClickContinueOnWithdrawFromAStandardOrTheRegisterPageWhenNoWithdrawalsExist()
                .ClickWithdrawFromRegister()
                .ContinueWithWithdrawalRequest();
        }
    }

    public void StandardApplicationFinalJourney()
    {
        AS_WithdrawalRequestOverviewPage aS_ApplicationOverviewPage = new(context);
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
        AS_WithdrawalRequestOverviewPage aS_ApplicationOverviewPage = new(context);
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

    public void VerifyStandardSubmitted() => _ = new AS_WithdrawalApplicationSubmittedPage(context);

    public void VerifyTheInProgressStatus()
    {
        new AS_LoggedInHomePage(context)
            .ClickWithdrawFromAStandardLink()
            .ClickContinueOnWithdrawFromAStandardOrTheRegisterPageWhenWithdrawalsExist()
            .ValidateStatus("In progress");
    }

    public void VerifyInProgressViewLinkNavigatesToApplicationOverviewPage()
    {
        new AS_YourWithdrawalRequestsPage(context).ClickOnViewLinkForInProgressApplication();
    }

    public static AD_YouhaveApprovedThisWithdrawalNotification ApproveAStandardWithdrawal(StaffDashboardPage staffDashboardPage)
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

    public static AD_YouhaveApprovedThisWithdrawalNotification ApproveARegisterWithdrawal(StaffDashboardPage staffDashboardPage)
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

    public static AD_WithdrawalApplicationsPage AddFeedbackToARegisterWithdrawalApplication(StaffDashboardPage staffDashboardPage)
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
        new AD_YouhaveApprovedThisWithdrawalNotification(context).ReturnToWithdrawalApplications();
    }

    public void VerifyApplicationMovedFromNewToFeedback() => new AD_WithdrawalApplicationsPage(context).VerifyAnApplicationAddedToFeedbackTab();

    public void VerifyApplicationIsMovedToApprovedTab() => new AD_WithdrawalApplicationsPage(context).VerifyApprovedTabContainsRegisterWithdrawal();


    public void AmmendWithdrawalApplication()
    {
        AS_LoggedInHomePage aS_LoggedInHomePage = new(context);
        aS_LoggedInHomePage.ClickWithdrawFromTheRegisterLink()
                           .ClickContinueOnWithdrawFromAStandardOrTheRegisterPageWhenWithdrawalsExist()
                           .ClickViewOnRegisterWithdrawalWithFeedbackAdded()
                           .ClickContinueButton()
                           .ClickSupportingCurrentLearnersFeedback()
                           .UpdateAnswerForHowWillYouSupportLearnersYouAreNotGoingToAssess()
                           .SubmitUpdatedAnswers();
    }

    public static AD_YouhaveApprovedThisWithdrawalNotification ApproveAmmendedRegisterWithdrawal(StaffDashboardPage staffDashboardPage)
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
        var approvedPage = new AD_YouhaveApprovedThisWithdrawalNotification(context);

        return approvedPage.VerifyRegisterWithdrawalBodyText()
            .ReturnToWithdrawalApplications();
    }
}