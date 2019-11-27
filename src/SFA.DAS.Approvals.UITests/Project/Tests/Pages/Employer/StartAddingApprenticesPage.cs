using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class StartAddingApprenticesPage : BasePage
    {
        protected override string PageTitle => "Start adding apprentices";
        private By WhoAddsApprenticesOptions => By.CssSelector(".govuk-radios__label");
        private By ContinueButton => By.CssSelector(".govuk-button");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

        public StartAddingApprenticesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AddApprenticeDetailsPage EmployerAddsApprentices()
        {
            EmployerAgreesToAdds();
            Continue();
            return new AddApprenticeDetailsPage(_context);
        }

        public MessageForYourTrainingProviderPage EmployerSendsToProviderToAddApprentices()
        {
            EmployerSendsToProviderToAdd();
            Continue();
            return new MessageForYourTrainingProviderPage(_context);
        }

        private StartAddingApprenticesPage EmployerAgreesToAdds()
        {
            _formCompletionHelper.SelectRadioOptionByText(WhoAddsApprenticesOptions, "I will add apprentices");
            return this;
        }

        private StartAddingApprenticesPage EmployerSendsToProviderToAdd()
        {
            _formCompletionHelper.SelectRadioOptionByText(WhoAddsApprenticesOptions, "I would like my provider to add apprentices");
            return this;
        }

        private void Continue()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
        }

        public AddApprenticeDetailsPage NonLevyEmployerAddsApprentices()
        {
            EmployerAgreesToAdds();
            Continue();
            return new AddApprenticeDetailsPage(_context);
        }
    }
}