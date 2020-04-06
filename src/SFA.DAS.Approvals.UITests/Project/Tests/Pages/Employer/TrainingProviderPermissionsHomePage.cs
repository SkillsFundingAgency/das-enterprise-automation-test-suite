using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class TrainingProviderPermissionsHomePage : HomePage
    {
        private readonly ScenarioContext _context;
        private By TrainingProviderPermissionLink => By.LinkText("Training provider permissions");

        public TrainingProviderPermissionsHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public YourTrainingProvidersPage OpenProviderPermissions()
        {
            formCompletionHelper.ClickElement(TrainingProviderPermissionLink);
            return new YourTrainingProvidersPage(_context);
        }
    }
}

