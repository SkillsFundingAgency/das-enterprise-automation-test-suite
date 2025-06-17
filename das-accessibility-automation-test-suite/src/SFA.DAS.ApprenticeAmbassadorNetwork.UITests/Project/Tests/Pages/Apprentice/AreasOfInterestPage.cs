namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class AreasOfInterestPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "How you want to be involved";

        private static By NetworkingCheckBox => By.Id("Events_0__IsSelected");
        private static By WritingCaseStudies => By.Id("Promotions_0__IsSelected");
        private static By OnlineEventsCheckBox => By.Id("Events_3__IsSelected");
        private static By DistrubtingCommunicationCheckBox => By.Id("Promotions_2__IsSelected");

        public WhyDoYouWantToJoinNetworkPage SelectEventsAndPromotions()
        {
            formCompletionHelper.SelectRadioOptionByLocator(NetworkingCheckBox);
            formCompletionHelper.SelectRadioOptionByLocator(WritingCaseStudies);
            Continue();
            return new WhyDoYouWantToJoinNetworkPage(context);
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



