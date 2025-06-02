using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static SFA.DAS.RAA.Service.Project.Tests.Pages.ProviderShareApplicationNotificationBasePage;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public abstract class ProviderDoYouWantToShareMultipleApplicationBasePage : RaaBasePage
    {
        protected override string PageTitle => "Share multiple applications";
        private static By ConfirmButton => By.CssSelector("#share-applications-confirm");
        private readonly string _status;

        public ProviderDoYouWantToShareMultipleApplicationBasePage(ScenarioContext context, string status) : base(context, false)
        {
            _status = status;

            VerifyPage();
        }
        protected override string AccessibilityPageTitle => "Are you sure you want to make candidate application page";

        protected void Confirm()
        {
            SelectRadioOptionByForAttribute("share-applications-confirm-yes");
            formCompletionHelper.Click(ConfirmButton);
        }

        public class ProviderDoYouWantToShareMultipleApplicationsPage(ScenarioContext context) : ProviderDoYouWantToShareMultipleApplicationBasePage(context, "share")
        {
            public ProviderApplicationSharePage ConfirmMultipleApplicationsSharing()
            {
                Confirm();
                return new ProviderApplicationSharePage(context);
            }
        }

        
    }
}
