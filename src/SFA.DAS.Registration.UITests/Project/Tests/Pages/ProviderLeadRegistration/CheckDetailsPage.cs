using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class CheckDetailsPage(ScenarioContext context) : ProviderLeadRegistrationBasePage(context)
    {
        protected override string PageTitle => "Check details";

        #region locators
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[type='submit']");
        private static By EmployerOrganisationChangeLink => By.CssSelector(".govuk-link[type='submit'][value='Change']");
        private static By EmployerFirstNameChangeLink => By.CssSelector(".govuk-link[type='submit'][value='Change']");
        private static By EmployerLastNameChangeLink => By.CssSelector(".govuk-link[type='submit'][value='Change']");

        #endregion

        public EmployerAccountIsReadyPage InviteEmployer()
        {
            Continue();
            return new EmployerAccountIsReadyPage(context);
        }

        public EnterTheEmployerDetailsPage ClickEmployerOrganisationChange()
        {
            formCompletionHelper.ClickElement(EmployerOrganisationChangeLink);
            return new EnterTheEmployerDetailsPage(context);
        }

        public EnterTheEmployerDetailsPage ClickEmployerFirstNameChange()
        {
            formCompletionHelper.ClickElement(EmployerFirstNameChangeLink);
            return new EnterTheEmployerDetailsPage(context);
        }

        public EnterTheEmployerDetailsPage ClickEmployerLastNameChange()
        {
            formCompletionHelper.ClickElement(EmployerLastNameChangeLink);
            return new EnterTheEmployerDetailsPage(context);
        }

        public CheckDetailsPage VerifyEmailCannotBeEdited()
        {
            return this;
        }
    }
}