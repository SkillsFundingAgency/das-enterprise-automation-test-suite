using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class GovUKConfirmRemovalPage : CampaingnsBasePage
    {
        protected override string PageTitle => "Confirm removal of apprenticeship";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Yes => By.CssSelector("#changed-name");

        public GovUKConfirmRemovalPage(ScenarioContext context) : base(context) => _context = context;

        public GovUkYourSavedFavouritesPage SelectYesAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(Yes));
            Continue();
            return new GovUkYourSavedFavouritesPage(_context);
        }
    }
}
