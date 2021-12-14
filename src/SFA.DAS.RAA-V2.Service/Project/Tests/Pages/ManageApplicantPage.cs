using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ManageApplicantPage : RAAV2CSSBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        protected override string PageTitle => "About you";

        private By SaveStatus => By.CssSelector("button[type='submit'][class='govuk-button']");

        private By CandidateFeedback => By.CssSelector("#CandidateFeedback");

        public ManageApplicantPage(ScenarioContext context) : base(context) { }

        public ConfirmApplicantSucessfulPage MakeApplicantSucessful()
        {
            SelectRadioOptionByForAttribute("outcome-successful");
            formCompletionHelper.Click(SaveStatus);
            return new ConfirmApplicantSucessfulPage(context);
        }

        public ConfirmApplicantUnsucessfulPage MakeApplicantUnsucessful()
        {
            SelectRadioOptionByForAttribute("outcome-unsuccessful");
            formCompletionHelper.EnterText(CandidateFeedback, rAAV2DataHelper.OptionalMessage);
            formCompletionHelper.Click(SaveStatus);
            return new ConfirmApplicantUnsucessfulPage(context);
        }
    }
}
