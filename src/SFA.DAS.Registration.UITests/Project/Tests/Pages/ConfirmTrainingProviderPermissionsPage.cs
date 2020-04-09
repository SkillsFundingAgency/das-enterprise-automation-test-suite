using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ConfirmTrainingProviderPermissionsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Confirm permissions";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmTrainingProviderPermissionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public PermissionsUpdatedPage ConfirmTrainingProviderPermissions()
        {
            Continue();
            return new PermissionsUpdatedPage(_context);
        }
    }
}

