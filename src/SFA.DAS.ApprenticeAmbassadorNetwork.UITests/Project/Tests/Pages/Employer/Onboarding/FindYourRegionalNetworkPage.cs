namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer.Onboarding
{
    public class FindYourRegionalNetworkPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Why do you want to join the network?";

        private static By NorthEastCheckbox => By.Id("4");

        public YourRegionalNetworkPage SelectNorthEastRegion_Continue()
        {
            formCompletionHelper.SelectCheckbox(NorthEastCheckbox);
            Continue();
            return new YourRegionalNetworkPage(context);
        }
    }
}
