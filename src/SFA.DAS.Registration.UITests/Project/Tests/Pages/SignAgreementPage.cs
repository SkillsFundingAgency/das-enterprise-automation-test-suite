using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Configuration;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SignAgreementPage : BasePage
    {
        protected override string PageTitle => _objectContext.GetOrganisationName();

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        private By WantToSignRadioButton => By.CssSelector("label[for=want-to-sign]");

        private By DoNotWantToSignRadioButton => By.CssSelector("label[for=do-not-want-to-sign]");

        private By ContinueButton => By.CssSelector("input.govuk-button, input.button");

        public SignAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public HomePage SignAgreement()
        {
            Sign();
            return new HomePage(_context);
        }

        public HomePage DoNotSignAgreement()
        {
            DoNotSign();
            return new HomePage(_context);
        }

        private void Sign()
        {
            Continue(WantToSignRadioButton);
        }

        private void DoNotSign()
        {
            Continue(DoNotWantToSignRadioButton);
        }

        private void Continue(By by)
        {
            _formCompletionHelper.ClickElement(by);
            _formCompletionHelper.ClickElement(ContinueButton);
        }
    }
}