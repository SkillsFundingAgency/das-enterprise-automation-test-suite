using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class StartAddingApprenticesPage : BasePage
    {
        protected override string PageTitle => "Start adding apprentices";

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
        private By WhoAddsApprenticesOptions => By.CssSelector(".selection-button-radio");

        private By ContinueButton => By.CssSelector(".button");

        public ReviewYourCohortPage EmployerAddsApprentices()
        {
            EmployerAgreesToAdds();
            Continue();
            return new ReviewYourCohortPage(_context);
        }

        public MessageForYourTrainingProviderPage EmployerSendsToProviderToAddApprentices()
        {
            EmployerSendsToProviderToAdd();
            Continue();
            return new MessageForYourTrainingProviderPage(_context);
        }

        private StartAddingApprenticesPage EmployerAgreesToAdds()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(WhoAddsApprenticesOptions, "SelectedRoute-Employer");
            return this;
        }

        private StartAddingApprenticesPage EmployerSendsToProviderToAdd()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(WhoAddsApprenticesOptions, "SelectedRoute-Provider");
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