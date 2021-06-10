using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages
{
    public abstract class RoatpNewAdminBasePage : RoatpBasePage
    {
        private readonly ScenarioContext _context;

        protected virtual By ClarificationTab => By.CssSelector("a[href='/Dashboard/InClarification']");

        protected virtual By OutcomeTab => By.CssSelector("a[href='/Dashboard/Outcome']");

        private By ProviderLink => By.LinkText(objectContext.GetProviderName());

        protected By ModerationTab => By.CssSelector("a[href='/Dashboard/InModeration']");

        private By FailInternalComments => By.CssSelector("textarea.govuk-textarea#OptionFailText");

        private By ClarificationResponse => By.CssSelector("textarea.govuk-textarea#ClarificationResponse");

        private By AskForClarificationInternalComments => By.CssSelector("textarea.govuk-textarea#OptionAskForClarificationText");
        
        private By ReturnToDashBoard => By.CssSelector("a[href='/Dashboard']");

        protected virtual By OutcomeStatus => By.CssSelector("[data-label='Outcome']");

        protected By UkprnStatus => By.CssSelector("[data-label='UKPRN']");

        public RoatpNewAdminBasePage(ScenarioContext context, bool verifyPage = true) : base(context)
        {
            _context = context;

            if (verifyPage) VerifyPage();
        }

        public void SelectPassAndContinueToSubSection()
        {
            EnterClarificationResponse();
            SelectRadioOptionByText("Pass");
            Continue();
        }

        public void SelectFailAndContinueToSubSection()
        {
            EnterClarificationResponse();
            SelectRadioOptionByText("Fail");
            EnterFailInternalComments();
            Continue();
        }

        public StaffDashboardPage ClickReturnToStaffDashBoard()
        {
            if (pageInteractionHelper.IsElementDisplayed(ReturnToDashBoard))
                formCompletionHelper.ClickElement(ReturnToDashBoard);
            
            return new StaffDashboardPage(_context);
        }

        public bool VerifyApplication() => pageInteractionHelper.IsElementDisplayed(ProviderLink);

        public void SelectClarificationAndContinueToSubSection()
        {
            SelectRadioOptionByText("Ask for clarification");
            EnterAskForClarificationInternalComments();
            Continue();
        }

        public void VerifyStatusBesideGenericQuestion(string linkText, string expectedStatus) =>
                    VerifyElement(() => pageInteractionHelper.FindElement(StatusTextLocator(linkText)), expectedStatus, null);

        protected void VerifyOutcomeStatus(string expectedStatus) => VerifyOutcomeStatus(OutcomeTab, OutcomeStatus, expectedStatus);

        protected void VerifyOutcomeStatus(By outcomeTab, By outcomeStatus, string expectedStatus)
        {
            VerifyApplicationStatus(outcomeStatus, expectedStatus, () => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(outcomeTab)));
        }

        protected void VerifyClarificationStatus(By statusSelector, string expectedStatus)
        {
            VerifyApplicationStatus(statusSelector, expectedStatus, () => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ClarificationTab)));
        }

        protected void VerifyApplicationStatus(By statusSelector, string expectedStatus, Action action)
        {
            var linkText = objectContext.GetProviderName();

            action.Invoke();

            VerifyElement(() => tableRowHelper.GetColumn(linkText, statusSelector), expectedStatus, action);
        }

        protected void EnterFailInternalComments() => formCompletionHelper.EnterText(FailInternalComments, "Internal comments");

        protected void EnterAskForClarificationInternalComments() => formCompletionHelper.EnterText(AskForClarificationInternalComments, "Internal comments");

        private void EnterClarificationResponse() 
        { 
            if (objectContext.IsClarificationJourney())
            {
                if (objectContext.IsUploadFile())
                {
                    ChooseFile();
                    objectContext.ResetIsUploadFile();
                }
                else
                {
                    formCompletionHelper.EnterText(ClarificationResponse, "Clarification Response");
                }
            }
        }

        protected By StatusTextLocator(string linkText) =>
                        By.XPath($"//span[contains(text(), '{linkText}')]/following-sibling::strong | //a[contains(text(),'{linkText}')]/../following-sibling::strong");

    }
}
