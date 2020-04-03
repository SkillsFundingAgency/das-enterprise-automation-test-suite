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
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By AddANewTrainingProviderButton => By.LinkText("Add a training provider");
        private By ChangePermissionsLink => By.LinkText("Change permissions");

        public YourTrainingProvidersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public EnterYourTrainingProvidersUKProviderReferenceNumberUKPRN SelectAddANewTrainingProvider()
        {
            _formCompletionHelper.ClickElement(AddANewTrainingProviderButton);
            return new EnterYourTrainingProvidersUKProviderReferenceNumberUKPRN(_context);
        }

        public DoYouGiveTrainingProviderPermissionToAddApprenticeRecordsPage SelectChangePermissions()
        {
            _formCompletionHelper.ClickElement(ChangePermissionsLink);
            return new DoYouGiveTrainingProviderPermissionToAddApprenticeRecordsPage(_context);
        }
    }
}