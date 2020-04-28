using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddTrainingProviderDetailsPage : BasePage
    {
        protected override string PageTitle => "Add training provider details";
        protected override By ContinueButton => By.Id("continue-button");

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProviderConfig _config;
        #endregion

        private By UkprnField => By.CssSelector(".govuk-input");

        public AddTrainingProviderDetailsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _config = context.GetProviderConfig<ProviderConfig>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ConfirmTrainingProviderPage SubmitValidUkprn()
        {
            EnterUkprn();
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ConfirmTrainingProviderPage(_context);
        }

        private AddTrainingProviderDetailsPage EnterUkprn()
        {
            _formCompletionHelper.EnterText(UkprnField, _config.Ukprn);
            return this;
        }
    }
}