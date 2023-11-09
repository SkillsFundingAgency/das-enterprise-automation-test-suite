namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class BeforeYouStartPage : AanBasePage
    {
        protected override string PageTitle => "Become an Apprentice Ambassador";

        private static By StartButton => By.Id("start-now");

        public BeforeYouStartPage(ScenarioContext context) : base(context) => VerifyPage();

        public TermsAndConditionsPage StartApprenticeOnboardingJourney()
        {
            formCompletionHelper.Click(StartButton);
            return new TermsAndConditionsPage(context);
        }
    }
}