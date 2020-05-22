using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EnterYourTrainingProviderNameReferenceNumberUKPRNPage : BasePage
    {
        protected override string PageTitle => "Enter your training provider’s name or reference number (UKPRN)";
        
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        protected override By PageHeader => By.Id("jsChgTitle");
        private By UKProviderReferenceNumberText => By.Id("Ukprn");

        public EnterYourTrainingProviderNameReferenceNumberUKPRNPage(ScenarioContext context) : base(context)
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
