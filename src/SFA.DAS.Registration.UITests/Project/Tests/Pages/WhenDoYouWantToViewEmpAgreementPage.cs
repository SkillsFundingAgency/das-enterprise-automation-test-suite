using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using OpenQA.Selenium;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class WhenDoYouWantToViewEmpAgreementPage : BasePage
    {
        protected override string PageTitle => "When do you want to view the employer agreement?";
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");
        protected override By ContinueButton => By.Id("submit-when-do-you-want-to-view-button");

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Locators
        private By ViewItNowRadionButton => By.CssSelector("label");
        #endregion

        public WhenDoYouWantToViewEmpAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public SignAgreementPage SelectViewAgreementNowAndContinue()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ViewItNowRadionButton, "view-it-now");
            Continue();
            return new SignAgreementPage(_context);
        }
    }
}
