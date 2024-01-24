namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class BeforeYouStartPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Become an Apprentice Ambassador";

        private static By StartButton => By.Id("start-now");

        public TermsAndConditionsPage StartApprenticeOnboardingJourney()
        {
            formCompletionHelper.Click(StartButton);
            return new TermsAndConditionsPage(context);
        }
    }
}