using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class SearchForATrainingProviderPage : BasePage
    {
        protected override string PageTitle => "Search for a training provider";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By UKProviderReferenceNumberText => By.Id("Ukprn");
        private By ContinueButton => By.CssSelector(".govuk-button");

        public SearchForATrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ConfirmTrainingProviderUnderPermissionsPage SearchForATrainingProvider(string ukprn)
        {
            _formCompletionHelper.EnterText(UKProviderReferenceNumberText, ukprn);
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ConfirmTrainingProviderUnderPermissionsPage(_context);
        }
    }
}

