namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class RegionsPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Tell us what area of the country you work in as an apprentice";
        private static By LondonRadio => By.Id("region-London");
        private static By NorthEasstRadio => By.Id("region-North-East");

        public WhyDoYouWantToJoinNetworkPage ConfirmRegionAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(LondonRadio);
            Continue();
            return new WhyDoYouWantToJoinNetworkPage(context);
        }
        public CheckYourAnswersPage AddOneMoreRegionAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(NorthEasstRadio);
            Continue();
            return new CheckYourAnswersPage(context);
        }
    }
}



