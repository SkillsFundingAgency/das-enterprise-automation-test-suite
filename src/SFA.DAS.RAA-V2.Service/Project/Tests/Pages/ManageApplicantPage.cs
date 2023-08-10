using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ManageApplicantPage : Raav2BasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        protected override string PageTitle => "About you";

        private static By SaveStatus => By.CssSelector("button[type='submit'][class='govuk-button']");

        public ManageApplicantPage(ScenarioContext context) : base(context) { }

        public ConfirmApplicantSucessfulPage MakeApplicantSucessful()
        {
            Outcomesuccessful();
            return new ConfirmApplicantSucessfulPage(context);
        }

        public ConfirmApplicantUnsuccessfulPage MakeApplicantUnsucessful()
        {
            OutcomeUnsuccessful(() => formCompletionHelper.EnterText(CandidateFeedback, rAAV2DataHelper.OptionalMessage));
            return new ConfirmApplicantUnsuccessfulPage(context);
        }

        public ProviderAreYouSureSuccessfulPage ProviderMakeApplicantSucessful()
        {
            Outcomesuccessful();
            return new ProviderAreYouSureSuccessfulPage(context);
        }

        public ProviderGiveFeedbackPage ProviderMakeApplicantUnsucessful()
        {
            OutcomeUnsuccessful(null);
            return new ProviderGiveFeedbackPage(context);
        }

        private void Outcomesuccessful()
        {
            SelectRadioOptionByForAttribute("outcome-successful");
            SaveAndContinue();
        }


        private void OutcomeUnsuccessful(Action action)
        {
            SelectRadioOptionByForAttribute("outcome-unsuccessful");

            action?.Invoke();

            SaveAndContinue();
        }

        private new void SaveAndContinue() => formCompletionHelper.Click(SaveStatus);
    }
}
