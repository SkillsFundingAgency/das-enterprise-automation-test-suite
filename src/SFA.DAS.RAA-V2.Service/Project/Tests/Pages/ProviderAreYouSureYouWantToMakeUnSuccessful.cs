using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ProviderAreYouSureYouWantToMakeUnSuccessful : Raav2BasePage
    {
        private static By Info => By.CssSelector("#main-content .govuk-body");

        private static By ConfirmButton => By.CssSelector("input[value='Confirm'][class='govuk-button']");

        public ProviderAreYouSureYouWantToMakeUnSuccessful(ScenarioContext context, string message) : base(context) => VerifyPage(Info, message);

        protected override string PageTitle => $"Are you sure you want to make {rAAV2DataHelper.CandidateFullName}'s application unsuccessful?";

        public ProviderApplicationUnsuccessfulPage ConfirmUnsuccessful()
        {
            SelectRadioOptionByForAttribute("notify-candidate-yes");
            formCompletionHelper.Click(ConfirmButton);
            return new ProviderApplicationUnsuccessfulPage(context);
        }
    }
}
