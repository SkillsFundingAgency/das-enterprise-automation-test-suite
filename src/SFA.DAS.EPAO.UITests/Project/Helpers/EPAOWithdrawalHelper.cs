using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class EPAOWithdrawalHelper
    {
        private readonly ScenarioContext _context;
        public EPAOWithdrawalHelper(ScenarioContext context)
        {
            _context = context;
            
        }

        public void StartOfStandardWithdrawalJourney()
        {
            AS_LoggedInHomePage aS_LoggedInHomePage = new AS_LoggedInHomePage(_context);
            aS_LoggedInHomePage.ClickWithdrawFromAStandardLink()
                               .ClickContinueOnWithdrawFromAStandardOrTheRegisterPage()
                               .ClickStartNewWithdrawalNotification()
                               .ClickAssessingASpecificStandard()
                               .ClickASpecificStandardToWithdraw();
        }

        public void StandardApplicationFinalJourney()
        {
            AS_ApplicationOverviewPage aS_ApplicationOverviewPage = new AS_ApplicationOverviewPage(_context);
            aS_ApplicationOverviewPage.ClickGoToStandardWithdrawalQuestions()
                                      .ClickGoToWithdrawalNotificationQuestionsLink()
                                      .ClickExternalQualityAssuranceProviderHasChanged()
                                      .ClickYesAndContinue()
                                      .EnterSupportingInformation()
                                      .EnterDateToWithdraw()
                                      .VerifyAndReturnToApplicationOverviewPage()
                                      .AcceptAndSubmit();
        }

        public void VerifyStandardSubmitted()
        {
            new AS_WithdrawalApplicationSubmittedPage(_context).StandardSubmissionVerification();
        }

        public void VerifyTheInProgressStatus()
        {
            new AS_LoggedInHomePage(_context)
                .ClickWithdrawFromAStandardLink()
                .ClickContinueOnWithdrawFromAStandardOrTheRegisterPage()
                .ValidateStatus("In progress");
        }

        public void VerifyInProgressViewLinkNavigatesToApplicationOverviewPage()
        {
            new AS_YourWithdrawalNotificationsPage(_context).ClickOnViewLinkForInProgressApplication();
        }
    }
}