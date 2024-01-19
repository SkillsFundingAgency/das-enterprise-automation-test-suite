namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class CurrentJobTitlePage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "What is your current job title?";


        private static By CurrentJobTitle => By.Id("JobTitle");

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



