namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer
{
    public class AreYouJoiningBecauseYouHaveEngagedPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Did you previously engage with an ambassador before deciding to join the network?";

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

