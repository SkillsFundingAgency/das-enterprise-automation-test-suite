namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer.Onboarding
{
    public class EventTypesPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Which types of events do you want to be emailed about?";

        private static By InPersonCheckbox => By.Id("eventType-0");
        //private static By Continue => By.Id("continue-button");

        public LocationsPage SelectEventTypes()
        {
            formCompletionHelper.SelectCheckbox(InPersonCheckbox);
            formCompletionHelper.ClickElement(ContinueButton);
            return new LocationsPage(context);
        }
    }
}
