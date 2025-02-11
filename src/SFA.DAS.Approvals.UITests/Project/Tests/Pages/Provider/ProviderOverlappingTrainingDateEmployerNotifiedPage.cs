using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderOverlappingTrainingDateEmployerNotifiedPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        protected override string PageTitle => "Request sent to employer";

        private static By IWillAddAnotherApprenticeRadionButton => By.CssSelector("#radio-add-another-apprentice");

        protected override bool TakeFullScreenShot => false;

        public ProviderApproveApprenticeDetailsPage IWillAddAnotherApprentice()
        {
            formCompletionHelper.SelectRadioOptionByLocator(IWillAddAnotherApprenticeRadionButton);
            Continue();

            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderApproveApprenticeDetailsPage NavigateToDraftApprenticePage()
        {
            string currenturl = pageInteractionHelper.GetUrl();
            string newurl = currenturl.Replace("OverlappingTrainingDateRequest/", "").Replace("employer-notified", "details");
            context.Get<TabHelper>().GoToUrl(newurl);

            return new ProviderApproveApprenticeDetailsPage(context);
        }
        
    }
}
