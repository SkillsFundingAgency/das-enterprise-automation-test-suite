namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer.Onboarding
{
    public class EngagementWithApprenticeshipAmbassadorsPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Engagement with apprenticeship ambassadors";
        private static By SelectAnswerYes => By.Id("HasPreviousEngagement");

        public RegistrationConfirmationPage ConfirmEngagement()
        {
            formCompletionHelper.SelectRadioOptionByLocator(SelectAnswerYes);
            formCompletionHelper.ClickElement(ContinueButton);
            return new RegistrationConfirmationPage(context);
        }
    }
}
