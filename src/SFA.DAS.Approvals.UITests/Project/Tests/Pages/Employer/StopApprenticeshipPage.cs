using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class StopApprenticeshipPage : ChangeApprenticeStatus
    {
        protected override string PageTitle => "Confirm apprenticeship stop";

        private By WarningMessage => By.TagName("strong");

        public StopApprenticeshipPage(ScenarioContext context) : base(context)  { }

        public new StoppedApprenticeDetailsPage SelectYesAndConfirm()
        {
            ConfirmChangesAndContinue();
            return new StoppedApprenticeDetailsPage(_context);
        }

        public ApprenticeshipRecordStoppedPage ValidateWarningSelectYesAndConfirm(string expectedWarningMsg)
        {
            pageInteractionHelper.VerifyText(pageInteractionHelper.GetText(WarningMessage), expectedWarningMsg);
            ConfirmChangesAndContinue();
            return new ApprenticeshipRecordStoppedPage(_context);
        }

        public StopApprenticeshipPage SelectYesandConfirmForANonStartedApprentice()
        {
            ConfirmChangesAndContinue();
            return new StopApprenticeshipPage(_context);
        }
        
        private StopApprenticeshipPage ConfirmChangesAndContinue()
        {
            base.SelectYesAndConfirm();
            return this;
        }
    }
}