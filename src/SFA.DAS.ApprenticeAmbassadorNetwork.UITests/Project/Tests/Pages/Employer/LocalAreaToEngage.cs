namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer
{
    public class LocalAreaToEngage : AanBasePage
    {
        protected override string PageTitle => "What area would you like to engage with locally within the network?";

        private static By NorthEastRadio => By.Id("region-North-East");

        public LocalAreaToEngage(ScenarioContext context) : base(context) => VerifyPage();

        public NetworkSupportAndNetworkJoinPage ConfirmLocalAsNorthEastAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(NorthEastRadio);
            Continue();
            return new NetworkSupportAndNetworkJoinPage(context);
        }
        public Employer_CheckTheInformationPage ChangeJourney_ConfirmLocalAsNorthEastAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(NorthEastRadio);
            Continue();
            return new Employer_CheckTheInformationPage(context);
        }
    }
}

