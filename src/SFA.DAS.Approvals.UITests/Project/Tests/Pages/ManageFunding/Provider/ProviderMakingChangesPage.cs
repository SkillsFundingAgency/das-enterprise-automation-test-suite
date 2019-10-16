using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderMakingChangesPage : BasePage
    {
        protected override string PageTitle => "Making changes";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        #endregion


        public ProviderMakingChangesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }
        private By GoToRadioButton => By.CssSelector(".govuk-radios__label");
        private By ContinueButton => By.CssSelector(".govuk-button");
        private By MessageLocator => By.TagName("body");

        internal ProviderHomePage GoToHomePage()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(GoToRadioButton, "WhatsNext-home");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ProviderHomePage(_context);
        }

        internal ProviderAddApprenticeDetailsPage GoToAddApprenticeDetailsPage()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(GoToRadioButton, "WhatsNext-add");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ProviderAddApprenticeDetailsPage(_context);
        }

        public ProviderMakingChangesPage VerifySucessMessage()
        {
            var expected = "You have successfully reserved funding for apprenticeship training";

            var actual = _pageInteractionHelper.GetText(MessageLocator);

            _pageInteractionHelper.VerifyText(actual, expected);

            return this;
        }
    }
}
