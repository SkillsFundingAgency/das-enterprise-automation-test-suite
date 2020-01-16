using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails
{
    public class AS_ChangeContactNamePage : BasePage
    {
        protected override string PageTitle => "Change contact name";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        #region Locators
        private By PrimaryContactNameRadioButton => By.XPath("//label[contains(text(),'Mr Preprod Epao0007')]/../input");
        private By SecondaryContactNameRadioButton => By.XPath("//label[contains(text(),'Liz Kemp')]/../input");
        #endregion

        public AS_ChangeContactNamePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public AS_ConfirmContactNamePage SelectContactNameRadioButtonAndClickSave(string selection)
        {
            var radionButton = selection.Equals("Primary") ? PrimaryContactNameRadioButton : SecondaryContactNameRadioButton;

            _formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(radionButton));
            Continue();
            return new AS_ConfirmContactNamePage(_context);
        }
    }

    public class AS_ConfirmContactNamePage : BasePage
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
