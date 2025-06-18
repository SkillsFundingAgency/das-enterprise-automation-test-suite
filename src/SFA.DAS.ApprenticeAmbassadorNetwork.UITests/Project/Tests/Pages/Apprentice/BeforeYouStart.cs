namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class BeforeYouStartPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Join the Apprenticeship Ambassador Network as an apprentice";

        private static By StartButton => By.Id("start-now");

        public TermsAndConditionsPage StartApprenticeOnboardingJourney()
        {
            formCompletionHelper.Click(StartButton);
            return new TermsAndConditionsPage(context);
        }
    }
}