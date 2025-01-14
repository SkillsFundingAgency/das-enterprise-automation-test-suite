namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer.Onboarding
{
    public class YourRegionalNetworkPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Your regional network";

        private static By ContinueButton => By.Id("continue");

        public CreateYourAmbassadorProfilePage ConfirmRegionalNetwork()
        {
            formCompletionHelper.ClickElement(ContinueButton);
            return new CreateYourAmbassadorProfilePage(context);
        }
    }
}
