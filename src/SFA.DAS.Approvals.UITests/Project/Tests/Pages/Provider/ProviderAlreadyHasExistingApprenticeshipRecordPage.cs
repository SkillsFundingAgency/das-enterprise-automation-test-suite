using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAlreadyHasExistingApprenticeshipRecordPage : ApprovalsBasePage
    {
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        protected override string PageTitle => "This apprentice already has an existing apprenticeship record";

        protected override bool TakeFullScreenShot => false;

        public ProviderAlreadyHasExistingApprenticeshipRecordPage(ScenarioContext context) : base(context) { }

        private static By IWillAddLaterRadionButton => By.CssSelector("#overlap-option-3");

        public void SelectIWillAddApprenticesLater()
        {
            formCompletionHelper.SelectRadioOptionByLocator(IWillAddLaterRadionButton);
            Continue();
        }
    }
}
