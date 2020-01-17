using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.EPAO.UITests.Project.Helpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails
{
    public class AS_ChangePhoneNumberPage : BasePage
    {
        protected override string PageTitle => "Change phone number";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly EPAODataHelper _ePAODataHelper;
        #endregion

        #region Locators
        private By PhoneNumberTextBox => By.CssSelector(".govuk-input");
        #endregion

        public AS_ChangePhoneNumberPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _ePAODataHelper = context.Get<EPAODataHelper>();
            VerifyPage();
        }

        public AS_ConfirmPhoneNumberPage EnterRandomPhoneNumberAndClickUpdate()
        {
            _formCompletionHelper.EnterText(PhoneNumberTextBox, _ePAODataHelper.Get10DigitRandomNumber);
            Continue();
            return new AS_ConfirmPhoneNumberPage(_context);
        }
    }

    public class AS_ConfirmPhoneNumberPage : BasePage
    {
        protected override string PageTitle => "Confirm phone number";
        private readonly ScenarioContext _context;

        public AS_ConfirmPhoneNumberPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_ContactPhoneNumberUpdatedPage ClickConfirmButtonInConfirmPhoneNumberPage()
        {
            Continue();
            return new AS_ContactPhoneNumberUpdatedPage(_context);
        }
    }

    public class AS_ContactPhoneNumberUpdatedPage : AS_ChangeOrgDetailsBasePage
    {
        protected override string PageTitle => "Contact phone number updated";

        public AS_ContactPhoneNumberUpdatedPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
