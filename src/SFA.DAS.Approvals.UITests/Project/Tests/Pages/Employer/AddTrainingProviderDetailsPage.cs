using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddTrainingProviderDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Add training provider details";
        protected override By ContinueButton => By.Id("continue-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By UkprnField => By.CssSelector(".govuk-input");

        public AddTrainingProviderDetailsPage(ScenarioContext context): base(context) => _context = context;

        public ConfirmTrainingProviderPage SubmitValidUkprn()
        {
            EnterUkprn();
            Continue();
            return new ConfirmTrainingProviderPage(_context);
        }

        private AddTrainingProviderDetailsPage EnterUkprn()
        {
            formCompletionHelper.EnterText(UkprnField, providerConfig.Ukprn);
            return this;
        }
    }
}
