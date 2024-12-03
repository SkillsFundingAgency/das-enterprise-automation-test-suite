using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AccountSettingsSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;
        private ProviderNotificationSettingsPage _providerNotification;

        public AccountSettingsSteps(ScenarioContext context)
        {
            _context = context;
            _loginHelper = new EmployerPortalLoginHelper(context);
            _providerCommonStepsHelper = new ProviderCommonStepsHelper(_context);
        }

        [Given(@"Employer navigates to Apprentices home page")]
        public void EmployerNavigatesToApprenticesHomePage()
        {
            _loginHelper.Login(_context.GetUser<LevyUser>(), true);

            _ = new ApprenticesHomePage(_context);
        }

        [Given(@"Provider navigates to notification settings page")]
        public void ProviderNavigatesToNotificationSettingsPage() => _providerNotification = _providerCommonStepsHelper.GoToProviderHomePage().GoToProviderNotificationSettingsPage();

        [Then(@"Provider is able to choose to receive notification emails")]
        public void ProviderIsAbleToChooseToReceiveNotificationEmails()
        {
            _providerNotification = _providerNotification.ChooseToReceiveEmails();

            Assert.IsTrue(_providerNotification.IsSettingsUpdated(), $"Choose to receive notification emails success message is not displayed");
        }

        [Then(@"Provider is able to choose No notification emails")]
        public void ProviderIsAbleToChooseNoNotificationEmails()
        {
            _providerNotification = _providerNotification.ChooseNotToReceiveEmails();

            Assert.IsTrue(_providerNotification.IsSettingsUpdated(), $"Choose not to receive notification emails success message is not displayed");
        }
    }
}
