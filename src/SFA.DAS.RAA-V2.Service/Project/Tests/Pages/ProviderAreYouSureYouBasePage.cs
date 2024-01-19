using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class ProviderAreYouSureYouBasePage : Raav2BasePage
    {
        private static By ConfirmButton => By.CssSelector("input[value='Confirm'][class='govuk-button']");

        private readonly string _status;

        public ProviderAreYouSureYouBasePage(ScenarioContext context, string status) : base(context, false)
        {
            _status = status;

            VerifyPage();
        }

        protected override string PageTitle => $"Are you sure you want to make {rAAV2DataHelper.CandidateFullName}'s application {_status}?";

        protected override string AccessibilityPageTitle => "Are you sure you want to make candidate application page";

        protected void Confirm()
        {
            SelectRadioOptionByForAttribute("notify-candidate-yes");
            formCompletionHelper.Click(ConfirmButton);
        }
    }

    public class ProviderAreYouSureSuccessfulPage(ScenarioContext context) : ProviderAreYouSureYouBasePage(context, "successful")
    {
        public ProviderApplicationSuccessfulPage ConfirmSuccessful()
        {
            Confirm();
            return new ProviderApplicationSuccessfulPage(context);
        }
    }

    public class ProviderAreYouSureUnSuccessfulPage : ProviderAreYouSureYouBasePage
    {
        private static By Info => By.CssSelector("#main-content .govuk-body");

        public ProviderAreYouSureUnSuccessfulPage(ScenarioContext context, string message) : base(context, "unsuccessful") => VerifyPage(Info, message);

        public ProviderApplicationUnsuccessfulPage ConfirmUnsuccessful()
        {
            Confirm();
            return new ProviderApplicationUnsuccessfulPage(context);
        }
    }
}
