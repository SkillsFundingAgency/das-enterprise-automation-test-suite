namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class EngagedWithAmbassadorPage : AanBasePage
    {
        protected override string PageTitle => "Are you joining because you have engaged with an ambassador in the network?";

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



