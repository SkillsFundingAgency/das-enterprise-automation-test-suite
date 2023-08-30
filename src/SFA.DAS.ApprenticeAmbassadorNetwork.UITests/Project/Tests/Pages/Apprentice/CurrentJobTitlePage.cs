namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class CurrentJobTitlePage : AanBasePage
    {
        protected override string PageTitle => "What is your current job title?";


        private static By CurrentJobTitle => By.Id("JobTitle");

        public CurrentJobTitlePage(ScenarioContext context) : base(context) => VerifyPage();

        public RegionsPage ConfirmJobtitleAndContinue()
        {
            formCompletionHelper.EnterText(CurrentJobTitle, aanDataHelpers.JobTitle);
            Continue();
            return new RegionsPage(context);
        }
        public CheckYourAnswersPage ChangeJobtitleAndContinue()
        {
            formCompletionHelper.EnterText(CurrentJobTitle, aanDataHelpers.NewJobTitle);
            Continue();
            return new CheckYourAnswersPage(context);
        }
    }
}



