using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages
{
    public abstract class RoatpNewAdminBasePage : RoatpBasePage
    {
        protected By ClarificationTab => By.CssSelector("a[href='/Dashboard/InClarification']");

        protected By OutcomeTab => By.CssSelector("a[href='/Dashboard/Outcome']");

        protected By ModerationTab => By.CssSelector("a[href='/Dashboard/InModeration']");

        private By FailInternalComments => By.CssSelector("textarea.govuk-textarea#OptionFailText");

        private By ClarificationResponse => By.CssSelector("textarea.govuk-textarea#ClarificationResponse");

        private By AskForClarificationInternalComments => By.CssSelector("textarea.govuk-textarea#OptionAskForClarificationText");

        public RoatpNewAdminBasePage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }

        public void SelectPassAndContinueToSubSection()
        {
            EnterClarificationResponse();
            SelectRadioOptionByText("Pass");
            Continue();
        }

        public void SelectFailAndContinueToSubSection()
        {
            SelectRadioOptionByText("Fail");
            EnterFailInternalComments();
            Continue();
        }

        public void SelectClarificationAndContinueToSubSection()
        {
            SelectRadioOptionByText("Ask for clarification");
            EnterAskForClarificationInternalComments();
            Continue();
        }

        public void VerifyStatusBesideGenericQuestion(string linkText, string expectedStatus) =>
                    VerifyElement(() => pageInteractionHelper.FindElement(StatusTextLocator(linkText)), expectedStatus, null);

        protected void EnterFailInternalComments() => formCompletionHelper.EnterText(FailInternalComments, "Internal comments");

        protected void EnterAskForClarificationInternalComments() => formCompletionHelper.EnterText(AskForClarificationInternalComments, "Internal comments");

        private void EnterClarificationResponse() 
        { 
            if (pageInteractionHelper.FindElements(ClarificationResponse).Any())
            formCompletionHelper.EnterText(ClarificationResponse, "Clarification Response"); 
        }

        protected By StatusTextLocator(string linkText) =>
                        By.XPath($"//span[contains(text(), '{linkText}')]/following-sibling::strong | //a[contains(text(),'{linkText}')]/../following-sibling::strong");

    }
}
