namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class EngagedWithAmbassadorPage : AanBasePage
    {
        protected override string PageTitle => "Did you previously engage with an ambassador before deciding to join the network?";

        public EngagedWithAmbassadorPage(ScenarioContext context) : base(context) => VerifyPage();

        public CheckYourAnswersPage YesHaveEngagedWithAnAmbassadaorAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            Continue();
            return new CheckYourAnswersPage(context);
        }

        public CheckYourAnswersPage NoHaveEngagedWithAnAmbassadaorAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("No");
            Continue();
            return new CheckYourAnswersPage(context);
        }
    }
}



