using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EnterYourTrainingProviderNameReferenceNumberUKPRNPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Enter your training provider’s name or reference number (UKPRN)";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By PageHeader => By.Id("jsChgTitle");
        private By UKProviderReferenceNumberText => By.Id("Ukprn");

        public EnterYourTrainingProviderNameReferenceNumberUKPRNPage(ScenarioContext context) : base(context) => _context = context;

        internal ConfirmTrainingProviderUnderPermissionsPage SearchForATrainingProvider(string ukprn)
        {
            formCompletionHelper.EnterText(UKProviderReferenceNumberText, ukprn);
            Continue();
            return new ConfirmTrainingProviderUnderPermissionsPage(_context);
        }
    }
}
