using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class HowDoYouWantToAddLearnerDetailsEntryMothod(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "How do you want to add learner details?";
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        internal DoYouWantToCreateANewCohortPage SelectAddManually()
        {
            SelectRadioOptionByForAttribute("confirm-Manual");
            Continue();
            return new DoYouWantToCreateANewCohortPage(context);
        }

        internal ProviderBeforeYouStartBulkUploadPage SelectBulkUpload()
        {
            SelectRadioOptionByForAttribute("confirm-BulkCsv");
            Continue();
            return new ProviderBeforeYouStartBulkUploadPage(context);
        }
    }
}
