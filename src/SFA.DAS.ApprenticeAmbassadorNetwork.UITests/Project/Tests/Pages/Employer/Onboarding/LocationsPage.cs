namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer.Onboarding
{
    public class LocationsPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Add locations for in-person events";

        protected static By Location => By.Id("Location");
        protected static By AddButton => By.Id("add");
        //private static By ContinueButton => By.Id("continue");

        public EngagementWithApprenticeshipAmbassadorsPage AddLocation_And_Continue()
        {
            EnterLocation("Tamarside, Devon");
            formCompletionHelper.ClickElement(AddButton);
            formCompletionHelper.ClickElement(ContinueButton);
            return new EngagementWithApprenticeshipAmbassadorsPage(context);
        }

        private void EnterLocation(string location)
        {
            formCompletionHelper.ClearText(Location);
            formCompletionHelper.EnterText(Location, location);
        }

    }
}
