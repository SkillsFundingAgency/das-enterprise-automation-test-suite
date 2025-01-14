namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer.Onboarding
{
    public class MonthlyEmailPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Do you want to receive a monthly email about upcoming events?";

        private static By RadioButtonYes => By.Id("ReceiveNotifications");
        private static By ContinueButton => By.Id("continue");

        public EventTypesPage SelectReceiveNotifications()
        {
            formCompletionHelper.SelectRadioOptionByLocator(RadioButtonYes);
            formCompletionHelper.ClickElement(ContinueButton);
            return new EventTypesPage(context);
        }
    }
}
