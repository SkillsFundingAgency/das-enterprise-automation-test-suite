using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class ProviderMakeApplicationsUnsuccessfulBasePage : Raav2BasePage
    {
        protected override string PageTitle => $"Make application unsuccessful";
        protected override string AccessibilityPageTitle => "Make application unsuccessful";
        private static By ConfirmButton => By.CssSelector("#provider-applications-to-unsuccessful-confirm");

        private readonly string _status;

        public ProviderMakeApplicationsUnsuccessfulBasePage(ScenarioContext context, string status) : base(context, false)
        {
            _status = status;

            VerifyPage();
        }

        protected void Confirm()
        {
            SelectRadioOptionByForAttribute("applications-to-unsuccessful-confirm-yes");
            formCompletionHelper.Click(ConfirmButton);
        }

        public class ProviderAreYouSureMultiUnSuccessfulPage : ProviderMakeApplicationsUnsuccessfulBasePage
        {
            private static By Info => By.CssSelector("#main-content .govuk-body");

            public ProviderAreYouSureMultiUnSuccessfulPage(ScenarioContext context, string message) : base(context, "unsuccessful") => VerifyPage(Info, message);
            public ProviderApplicationUnsuccessfulPage ConfirmUnsuccessful() 
            {
                Confirm();
                return new ProviderApplicationUnsuccessfulPage(context);
            }
        }

       
    }
}
