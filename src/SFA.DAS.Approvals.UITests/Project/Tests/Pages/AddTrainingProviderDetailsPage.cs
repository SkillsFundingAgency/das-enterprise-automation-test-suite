using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages
{
    public class AddTrainingProviderDetailsPage : BasePage
    {
        protected override string PageTitle => "Add training provider details";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        #endregion

        private By ukprnField => By.Id("ProviderId");

        private By continueButton => By.CssSelector(".button");

        public AddTrainingProviderDetailsPage(ScenarioContext context): base(context)
        {
            _context = context;
            _config = context.GetProjectConfig<ProjectConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ConfirmTrainingProviderPage SubmitValidUkprn()
        {
            EnterUkprn();
            return Continue();
        }

        private AddTrainingProviderDetailsPage EnterUkprn()
        {
            _formCompletionHelper.EnterText(ukprnField, Constants.ProviderUkPrn);
            return this;
        }

        private ConfirmTrainingProviderPage Continue()
        {
            _formCompletionHelper.ClickElement(continueButton);
            return new ConfirmTrainingProviderPage(_context);
        }
    }
}