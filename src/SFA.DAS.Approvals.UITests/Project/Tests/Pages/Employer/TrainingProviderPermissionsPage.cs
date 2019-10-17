using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class TrainingProviderPermissionsPage : BasePage
    {
        protected override string PageTitle => "Training provider permissions";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

        private By AddANewTrainingProviderButton => By.LinkText("Add a new training provider");
        private By SetPermissionsLink => By.LinkText("Set permissions");


        public TrainingProviderPermissionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public SearchForATrainingProviderPage SelectAddANewTrainingProvider()
        {
            _formCompletionHelper.ClickElement(AddANewTrainingProviderButton);
            return new SearchForATrainingProviderPage(_context);
        }

        internal SetPermissionsPage SelectSetPermissions()
        {
            _formCompletionHelper.ClickElement(SetPermissionsLink);
            return new SetPermissionsPage(_context);
        }
    }
}

