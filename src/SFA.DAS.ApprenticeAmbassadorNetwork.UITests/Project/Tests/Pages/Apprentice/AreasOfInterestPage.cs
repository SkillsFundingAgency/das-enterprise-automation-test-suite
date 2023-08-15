namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class AreasOfInterestPage : AanBasePage
    {
        protected override string PageTitle => "Please tell us which areas interest you most in your role as an ambassador";

        private static By NetworkingCheckBox => By.Id("Events_0__IsSelected");
        private static By WritingCaseStudies => By.Id("Promotions_0__IsSelected");
        private static By OnlineEventsCheckBox => By.Id("Events_3__IsSelected");
        private static By DistrubtingCommunicationCheckBox => By.Id("Promotions_2__IsSelected");

        public AreasOfInterestPage(ScenarioContext context) : base(context) => VerifyPage();
        public EngagedWithAmbassadorPage SelectEventsAndPromotions()
        {
            formCompletionHelper.SelectRadioOptionByLocator(NetworkingCheckBox);
            formCompletionHelper.SelectRadioOptionByLocator(WritingCaseStudies);
            Continue();
            return new EngagedWithAmbassadorPage(context);
        }

        public CheckYourAnswersPage AddMoreEventsAndPromotions()
        {
            formCompletionHelper.SelectRadioOptionByLocator(OnlineEventsCheckBox);
            formCompletionHelper.SelectRadioOptionByLocator(DistrubtingCommunicationCheckBox);
            Continue();
            return new CheckYourAnswersPage(context);
        }

    }
}



