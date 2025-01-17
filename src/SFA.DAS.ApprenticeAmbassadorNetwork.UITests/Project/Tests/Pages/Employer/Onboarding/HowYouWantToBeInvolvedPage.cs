namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer.Onboarding
{
    public class HowYouWantToBeInvolvedPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "How you want to be involved";

        private static By ContinueButton => By.Id("continue-button");
        private static By ShareYourKnowledgeCheckbox => By.Id("42");
        private static By IncreaseEngagementCheckbox => By.Id("52");
        private static By AdditionalCheckbox => By.Id("43");
        private static By AdditionalCheckboxTwo => By.Id("53");

        public MonthlyEmailPage SelectHowYouWantToBeInvolved()
        {
            formCompletionHelper.SelectCheckbox(ShareYourKnowledgeCheckbox); // why do you want to join the network?
            formCompletionHelper.SelectCheckbox(IncreaseEngagementCheckbox); // What support would you need from the network?
            formCompletionHelper.ClickElement(ContinueButton);
            return new MonthlyEmailPage(context);
        }

        public RegistrationConfirmationPage Add1MoreSelection()
        {
            formCompletionHelper.SelectCheckbox(AdditionalCheckbox); // why do you want to join the network?
            formCompletionHelper.SelectCheckbox(AdditionalCheckboxTwo); // What support would you need from the network?
            formCompletionHelper.ClickElement(ContinueButton);
            return new RegistrationConfirmationPage(context);
        }
    }
}
