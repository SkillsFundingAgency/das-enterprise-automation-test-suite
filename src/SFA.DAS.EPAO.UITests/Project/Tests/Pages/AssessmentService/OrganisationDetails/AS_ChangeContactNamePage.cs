using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails
{
    public class AS_ChangeContactNamePage : EPAO_BasePage
    {
        protected override string PageTitle => "Change contact name";
        private readonly ScenarioContext _context;

        #region Locators
        private By PrimaryContactNameRadioButton => By.XPath("//label[contains(text(),'Mr Preprod Epao0007')]/../input");
        private By SecondaryContactNameRadioButton => By.XPath("//label[contains(text(),'Liz Kemp')]/../input");
        #endregion

        public AS_ChangeContactNamePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_ConfirmContactNamePage SelectContactNameRadioButtonAndClickSave()
        {
            var radioButtonToClick = pageInteractionHelper.GetElementSelectedStatus(PrimaryContactNameRadioButton) ? SecondaryContactNameRadioButton : PrimaryContactNameRadioButton;
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(radioButtonToClick));

            Continue();
            return new AS_ConfirmContactNamePage(_context);
        }
    }

    public class AS_ConfirmContactNamePage : EPAO_BasePage
    {
        protected override string PageTitle => "Confirm contact name";
        private readonly ScenarioContext _context;

        public AS_ConfirmContactNamePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_ContactNameUpdatedPage ClickConfirmButtonInConfirmContactNamePage()
        {
            Continue();
            return new AS_ContactNameUpdatedPage(_context);
        }
    }

    public class AS_ContactNameUpdatedPage : AS_ChangeOrgDetailsBasePage
    {
        protected override string PageTitle => "Contact name updated";

        public AS_ContactNameUpdatedPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
