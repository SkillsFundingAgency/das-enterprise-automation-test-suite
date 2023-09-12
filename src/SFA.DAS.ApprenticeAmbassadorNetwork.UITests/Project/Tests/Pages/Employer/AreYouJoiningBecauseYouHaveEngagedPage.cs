namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer
{
    public class AreYouJoiningBecauseYouHaveEngagedPage : AanBasePage
    {
        protected override string PageTitle => "Are you joining because you have engaged with an ambassador in the network?";

        public AreYouJoiningBecauseYouHaveEngagedPage(ScenarioContext context) : base(context) => VerifyPage();

        public Employer_CheckTheInformationPage YesHaveEngagedWithAmbassadorAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            Continue();
            return new Employer_CheckTheInformationPage(context);
        }

        public Employer_CheckTheInformationPage NoHaveEngagedWithAmbassadorAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("No");
            Continue();
            return new Employer_CheckTheInformationPage(context);
        }
    }
}

