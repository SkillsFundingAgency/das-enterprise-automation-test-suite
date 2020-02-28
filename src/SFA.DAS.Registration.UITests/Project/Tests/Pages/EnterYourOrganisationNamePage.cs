using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EnterYourOrganisationNamePage : RegistrationBasePage
    {
        protected override string PageTitle => "Enter your organisation name";
        private readonly ScenarioContext _context;
        private readonly RegistrationDataHelper _registrationDataHelper;

        #region Locators
        protected override By ContinueButton => By.Id("accept");
        private By NameTextBox => By.Id("Name");
        private By ErrorMessageAboveNameTextBox => By.XPath("//span[text()='Enter a name']");
        private By ErrorMessageAtHeader => By.LinkText("Enter a name");
        #endregion

        public EnterYourOrganisationNamePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            VerifyPage();
        }

        public FindOrganisationAddressPage EnterOrganisationNameAndContinueInEnterYourOrganisationNamePage()
        {
            formCompletionHelper.EnterText(NameTextBox, _registrationDataHelper.OrgNameForManualEntry);
            Continue();
            return new FindOrganisationAddressPage(_context);
        }

        public EnterYourOrganisationNamePage LeaveOrganisationNameBlankAndContinueInEnterYourOrganisationNamePage()
        {
            formCompletionHelper.EnterText(NameTextBox, "");
            Continue();
            return this;
        }

        public EnterYourOrganisationNamePage VerifyErrorMessagesInEnterYourOrganisationNamePage()
        {
            VerifyPage(ErrorMessageAtHeader);
            VerifyPage(ErrorMessageAboveNameTextBox);
            return this;
        }
    }
}
