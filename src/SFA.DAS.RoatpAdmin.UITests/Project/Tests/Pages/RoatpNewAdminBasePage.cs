using OpenQA.Selenium;
using SFA.DAS.EsfaAdmin.Service.Project;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages
{
    public abstract class RoatpNewAdminBasePage : RoatpBasePage
    {
        protected virtual By ClarificationTab => By.CssSelector("a[href='/Dashboard/InClarification']");

        protected virtual By OutcomeTab => By.CssSelector("a[href='/Dashboard/Outcome']");

        protected virtual By OutcomeStatus => By.CssSelector("[data-label='Outcome']");

        private By ProviderLink => By.LinkText(objectContext.GetProviderName());

        protected static By ModerationTab => By.CssSelector("a[href='/Dashboard/InModeration']");

        private static By FailInternalComments => By.CssSelector("textarea.govuk-textarea#OptionFailText");

        private static By ClarificationResponse => By.CssSelector("textarea.govuk-textarea#ClarificationResponse");

        private static By AskForClarificationInternalComments => By.CssSelector("textarea.govuk-textarea#OptionAskForClarificationText");
        
        private static By ReturnToDashBoard => By.CssSelector("a[href='/Dashboard']");

        private static By SearchField => By.CssSelector("#SearchTerm");
        
        protected static By UkprnStatus => By.CssSelector("[data-label='UKPRN']");

        private static By SearchButton => By.CssSelector(".app-search-form__button-wrap");

        public RoatpNewAdminBasePage(ScenarioContext context, bool verifyPage = true) : base(context)
        {
            if (verifyPage)
            {
                try
                {
                    VerifyPage();
                }
                catch (Exception)
                {
                    if (IsAccessibilityTesting())
                    {
                        if (new CheckEsfaSignInPage(context).IsPageDisplayed())
                        {
                            var (username, password) = objectContext.GetEsfaAdminLoginCreds();

                            new EsfaSignInPage(context, false).SubmitValidLoginDetails(username, password);

                            VerifyPage();
                        }
                    }
                    else
                    {
                        throw;
                    }
                }
            }
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
            
            return new StaffDashboardPage(context);
        }

        public bool VerifyApplication() => pageInteractionHelper.IsElementDisplayed(ProviderLink);

        public void SelectClarificationAndContinueToSubSection()
        {
            SelectRadioOptionByText("Ask for clarification");
            EnterAskForClarificationInternalComments();
            Continue();
        }

        protected void SearchProviderByName() => SearchProvider(objectContext.GetProviderName());
        protected void SearchProviderByUKPRN() => SearchProvider(objectContext.GetUkprn());
        private void SearchProvider(string searchText)
        {
            formCompletionHelper.EnterText(SearchField, searchText);
            formCompletionHelper.ClickElement(SearchButton);
        }

        public void VerifyStatusBesideGenericQuestion(string linkText, string expectedStatus) =>
                    VerifyElement(() => pageInteractionHelper.FindElement(StatusTextLocator(linkText)), expectedStatus, null);

        protected void VerifyOutcomeStatus(string expectedStatus) => 
            VerifyOutcomeStatus(OutcomeTab, OutcomeStatus, expectedStatus);

        protected void VerifyOutcomeStatus(By outcomeTab, By outcomeStatus, string expectedStatus) => 
            VerifyApplicationStatus(outcomeStatus, expectedStatus, () => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(outcomeTab)));
        

        protected void VerifyClarificationStatus(By statusSelector, string expectedStatus) => 
            VerifyApplicationStatus(statusSelector, expectedStatus, () => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ClarificationTab)));

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
