using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.EPAO.UITests.Project.Helpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails
{
    public class AS_ChangeEmailPage : BasePage
    {
        protected override string PageTitle => "Change email address";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly EPAODataHelper _ePAODataHelper;
        #endregion

        #region Locators
        private By EmailTextBox => By.Id("Email");
        #endregion

        public AS_ChangeEmailPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _ePAODataHelper = context.Get<EPAODataHelper>();
            VerifyPage();
        }

        public AS_ConfirmEmailAddressPage EnterRandomEmailAndClickChange()
        {
            _formCompletionHelper.EnterText(EmailTextBox, _ePAODataHelper.GetRandomEmail);
            Continue();
            return new AS_ConfirmEmailAddressPage(_context);
        }
    }

    public class AS_ConfirmEmailAddressPage : BasePage
    {
        protected override string PageTitle => "Confirm email address";
        private readonly ScenarioContext _context;

        public AS_ConfirmEmailAddressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_EmailAddressUpdatedPage ClickConfirmButtonInConfirmEmailAddressPage()
        {
            Continue();
            return new AS_EmailAddressUpdatedPage(_context);
        }
    }

    public class AS_EmailAddressUpdatedPage : AS_ChangeOrgDetailsBasePage
    {
        protected override string PageTitle => "Email address updated";

        public AS_EmailAddressUpdatedPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}