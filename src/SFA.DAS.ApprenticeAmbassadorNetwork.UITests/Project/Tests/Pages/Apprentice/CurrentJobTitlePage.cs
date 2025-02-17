namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class CurrentJobTitlePage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "What is your job title?";


        private static By CurrentJobTitle => By.Id("JobTitle");

        public AreasOfInterestPage ConfirmJobtitleAndContinue()
        {
            formCompletionHelper.EnterText(CurrentJobTitle, aanDataHelpers.JobTitle);
            Continue();
            return new AreasOfInterestPage(context);
        }
        public CheckYourAnswersPage ChangeJobtitleAndContinue()
        {
            formCompletionHelper.EnterText(CurrentJobTitle, aanDataHelpers.NewJobTitle);
            Continue();
            return new CheckYourAnswersPage(context);
        }
    }
}



