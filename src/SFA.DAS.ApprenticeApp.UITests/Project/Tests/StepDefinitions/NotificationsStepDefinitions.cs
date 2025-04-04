using SFA.DAS.ApprenticeApp.UITests.Project.Helpers;
using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class NotificationsStepDefinitions(ScenarioContext context)
    {
        private readonly AppStepsHelper _stepsHelper = new(context);
        private NotificationsPage notificationsPage;

        [When("the apprentice user clicks on the notifications tab")]
        public void WhenTheApprenticeUserClicksOnTheNotificationsTab()
        {
            notificationsPage = _stepsHelper.NavigateToNotificationsPage();
        }

        [Then("the notifications are displayed")]
        public void ThenTheNotificationsAreDisplayed()
        {
            Assert.AreEqual("Notifications", notificationsPage.NotificationsPageTitle());
        }
    }
}
