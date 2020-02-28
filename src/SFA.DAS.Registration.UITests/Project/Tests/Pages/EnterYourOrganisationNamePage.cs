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
        #endregion

        public EnterYourOrganisationNamePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            VerifyPage();
        }

        public FindOrganisationAddressPage EnterOrganisationNameAndContinue()
        {
            formCompletionHelper.EnterText(NameTextBox, _registrationDataHelper.ManuallyAddedOrgName);
            Continue();
            return new FindOrganisationAddressPage(_context);
        }
    }
}
