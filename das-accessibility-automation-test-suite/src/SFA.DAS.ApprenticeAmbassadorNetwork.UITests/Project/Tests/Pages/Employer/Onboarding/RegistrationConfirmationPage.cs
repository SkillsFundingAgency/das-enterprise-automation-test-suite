namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer.Onboarding
{
    public class RegistrationConfirmationPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Register with the Apprenticeship Ambassador Network";

        private static By SubmitButton => By.Id("continue-button");
        private static By ChangeLinkToRegions => By.XPath("(//a[text()='Change'])[1]");
        private static By ChangeLinkToWhatCanYouOffer => By.XPath("(//a[text()='Change'])[2]");

        public FindYourRegionalNetworkPage ChangeRegions()
        {
            formCompletionHelper.Click(ChangeLinkToRegions);
            return new FindYourRegionalNetworkPage(context);
        }

        public HowYouWantToBeInvolvedPage ChangeWhatCanYouOffer()
        {
            formCompletionHelper.Click(ChangeLinkToWhatCanYouOffer);
            return new HowYouWantToBeInvolvedPage(context);
        }

        public RegistrationComplete_EmployerPage SubmitApplication()
        {
            formCompletionHelper.Click(SubmitButton);
            return new RegistrationComplete_EmployerPage(context);
        }
    }

}
