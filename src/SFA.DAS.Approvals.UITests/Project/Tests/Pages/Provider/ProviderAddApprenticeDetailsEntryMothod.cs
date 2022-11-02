using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddApprenticeDetailsEntryMothod : ApprovalsBasePage
    {

        public ProviderAddApprenticeDetailsEntryMothod(ScenarioContext context) : base(context) { }

        protected override string PageTitle => "Add apprentice details";
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        internal ProviderAddApprenticeDetailsViaSelectJourneyPage SelectAddManually()
        {
            SelectRadioOptionByForAttribute("confirm-Manual");
            Continue();
            return new ProviderAddApprenticeDetailsViaSelectJourneyPage(context);
        }

        internal ProviderBeforeYouStartBulkUploadPage SelectBulkUpload()
        {
            SelectRadioOptionByForAttribute("confirm-BulkCsv");
            Continue();
            return new ProviderBeforeYouStartBulkUploadPage(context);
        }
    }
}
