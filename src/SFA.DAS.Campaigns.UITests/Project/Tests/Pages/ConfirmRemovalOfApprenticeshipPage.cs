using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    internal class ConfirmRemovalOfApprenticeshipPage: BasePage
    {
        protected override string PageTitle => "";
        #region Constants
        private const string ExpectedViewSavedFavouritesHeader = "Confirm removal of apprenticeship";

        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Page Object Elements
        private readonly By _confirmRemovalOfApprenticeshipHeader =By.XPath("//hi[@class='govuk-heading-xl ']");
        //private readonly By _yesRemoveApprenticeship = By.XPath("//input[contains(@name, 'confirmDelete')]");
        private readonly By _yesRemoveApprenticeship = By.Id("changed-name");
        private readonly By _noKeepApprenticeship = By.XPath("//input[@id='changed-name-2']");
        private readonly By _saveAndContinueButton = By.XPath("//button[@class='govuk-button']");
        #endregion

        public ConfirmRemovalOfApprenticeshipPage(ScenarioContext context):base(context)
        {
           _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }


        internal YourSavedFavouritesGovUkPage ConfirmRemovalOfApprenticeship()
        {
            ClickYesApprenticeshipRemovalRadioButton();
            ClickToConfirmRemovalButton();
            return new YourSavedFavouritesGovUkPage(_context);
        }

        internal void ClickToConfirmRemovalButton()
        {
            _formCompletionHelper.ClickElement(_saveAndContinueButton);
        }
        internal void ClickYesApprenticeshipRemovalRadioButton()
        {
            _formCompletionHelper.SelectRadioButton(_yesRemoveApprenticeship);
        }
    }
}