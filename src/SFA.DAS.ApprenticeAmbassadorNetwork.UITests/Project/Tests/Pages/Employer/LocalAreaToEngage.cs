namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer
{
    public class LocalAreaToEngage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "What area would you like to engage with locally within the network?";

        private static By NorthEastRadio => By.Id("region-North-East");

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

