namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class BeforeYouStartPage : SignInPage
    {
        protected override string PageTitle => "Apply to become an Apprenticeship Ambassador";

        private By StartButton => By.Id("start-now");

        public BeforeYouStartPage(ScenarioContext context) : base(context) => VerifyPage();

        public TermsAndConditionsPage StartApprenticeOnboardingJourney()
        {
            formCompletionHelper.Click(StartButton);
            return new TermsAndConditionsPage(context);
        }
    }
}