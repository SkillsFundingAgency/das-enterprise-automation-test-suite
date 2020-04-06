using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class GovUKConfirmRemovalPage : BasePage
    {
        protected override string PageTitle => "Confirm removal of apprenticeship";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By Yes => By.CssSelector("#changed-name");

        public GovUKConfirmRemovalPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public GovUkYourSavedFavouritesPage SelectYesAndContinue()
        {
            _formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(Yes));
            Continue();
            return new GovUkYourSavedFavouritesPage(_context);
        }
    }
}
