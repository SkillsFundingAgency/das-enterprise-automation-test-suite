using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class YourTrainingProvidersLinkHomePage : HomePage
    {
        private static By YourTrainingProvidersLink => By.LinkText("Your training providers");

        public YourTrainingProvidersLinkHomePage(ScenarioContext context) : base(context) { }

        public YourTrainingProvidersPage OpenProviderPermissions()
        {
            formCompletionHelper.ClickElement(YourTrainingProvidersLink);
            return new YourTrainingProvidersPage(context);
        }
    }
}

