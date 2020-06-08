using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class YourTrainingProvidersPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Your training providers";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AddANewTrainingProviderButton => By.LinkText("Add a training provider");
        private By SetPermissionsLink => By.LinkText("Set permissions");
        private By ChangePermissionsLink => By.LinkText("Change permissions");

        public YourTrainingProvidersPage(ScenarioContext context) : base(context) => _context = context;

        public EnterYourTrainingProviderNameReferenceNumberUKPRNPage SelectAddANewTrainingProvider()
        {
            formCompletionHelper.ClickElement(AddANewTrainingProviderButton);
            return new EnterYourTrainingProviderNameReferenceNumberUKPRNPage(_context);
        }

        public DoYouGiveTrainingProviderPermissionToAddApprenticeRecordsPage SelectSetPermissions()
        {
            formCompletionHelper.ClickElement(SetPermissionsLink);
            return new DoYouGiveTrainingProviderPermissionToAddApprenticeRecordsPage(_context);
        }
        public DoYouGiveTrainingProviderPermissionToAddApprenticeRecordsPage SelectChangePermissions()
        {
            formCompletionHelper.ClickElement(ChangePermissionsLink);
            return new DoYouGiveTrainingProviderPermissionToAddApprenticeRecordsPage(_context);
        }        
    }
}