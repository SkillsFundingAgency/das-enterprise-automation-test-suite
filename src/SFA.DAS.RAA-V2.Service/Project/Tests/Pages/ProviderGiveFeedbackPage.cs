using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ProviderGiveFeedbackPage : Raav2BasePage
    {
        private static By CandidateFeedback => By.CssSelector("#CandidateFeedback");

        private static By ConfirmButton => By.CssSelector("input[value='Confirm'][class='govuk-button']");

        public ProviderGiveFeedbackPage(ScenarioContext context) : base(context)
        {
                
        }

        protected override string PageTitle => $"Give feedback to {rAAV2DataHelper.CandidateFullName}";

        public ProviderAreYouSureYouWantToMakeUnSuccessful FeedbackForUnsuccessful()
        {
            var messsage = rAAV2DataHelper.OptionalMessage;
            formCompletionHelper.EnterText(CandidateFeedback, messsage);
            formCompletionHelper.Click(ConfirmButton);
            return new ProviderAreYouSureYouWantToMakeUnSuccessful(context, messsage);
        }
    }
}
