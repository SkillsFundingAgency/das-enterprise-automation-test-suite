using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class TrainingProviderAddedPage : BasePage
    {
        protected override string PageTitle => "You've successfully added";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion
        private By ReturnToTrainingProviders = By.CssSelector(".govuk-button");
        public TrainingProviderAddedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        public YourTrainingProvidersPage SelectContinueInEmployerTrainingProviderAddedPage()
        {
            _formCompletionHelper.ClickElement(ReturnToTrainingProviders);
            return new YourTrainingProvidersPage(_context);
        }
    }
}