using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class YourTrainingProvidersPage : BasePage
    {
        protected override string PageTitle => "Your training providers";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

        private By AddANewTrainingProviderButton => By.LinkText("Add a training provider");
        private By SetPermissionsLink => By.LinkText("Change permissions");


        public YourTrainingProvidersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public EnterYourTrainingProvidersUKProviderReferenceNumberUKPRN SelectAddANewTrainingProvider()
        {
            _formCompletionHelper.ClickElement(AddANewTrainingProviderButton);
            return new EnterYourTrainingProvidersUKProviderReferenceNumberUKPRN(_context);
        }

        internal SetPermissionsPage SelectSetPermissions()
        {
            _formCompletionHelper.ClickElement(SetPermissionsLink);
            return new SetPermissionsPage(_context);
        }
    }
}

