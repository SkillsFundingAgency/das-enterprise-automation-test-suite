using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EnterYourTrainingProvidersUKProviderReferenceNumberUKPRN: BasePage
    {
        protected override string PageTitle => "Enter your training provider's UK Provider Reference Number (UKPRN)";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By UKProviderReferenceNumberText => By.Id("Ukprn");

        public EnterYourTrainingProvidersUKProviderReferenceNumberUKPRN(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ConfirmTrainingProviderUnderPermissionsPage SearchForATrainingProvider(string ukprn)
        {
            _formCompletionHelper.EnterText(UKProviderReferenceNumberText, ukprn);
            Continue();
            return new ConfirmTrainingProviderUnderPermissionsPage(_context);
        }
    }
}
