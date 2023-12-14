using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class StopApprenticeshipPage(ScenarioContext context) : ChangeApprenticeStatus(context)
    {
        protected override string PageTitle => "Confirm apprenticeship stop";

        protected override bool TakeFullScreenShot => false;

        private static By WarningMessage => By.TagName("strong");

        public new StoppedApprenticeDetailsPage SelectYesAndConfirm()
        {
            ConfirmChangesAndContinue();
            return new StoppedApprenticeDetailsPage(context);
        }

        public ApprenticeshipRecordStoppedPage ValidateWarningSelectYesAndConfirm(string expectedWarningMsg)
        {
            pageInteractionHelper.VerifyText(pageInteractionHelper.GetText(WarningMessage), expectedWarningMsg);
            ConfirmChangesAndContinue();
            return new ApprenticeshipRecordStoppedPage(context);
        }

        public StopApprenticeshipPage SelectYesandConfirmForANonStartedApprentice()
        {
            ConfirmChangesAndContinue();
            return new StopApprenticeshipPage(context);
        }

        private StopApprenticeshipPage ConfirmChangesAndContinue()
        {
            base.SelectYesAndConfirm();
            return this;
        }
    }
}