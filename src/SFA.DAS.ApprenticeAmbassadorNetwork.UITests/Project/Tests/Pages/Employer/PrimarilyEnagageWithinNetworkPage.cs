namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer
{
    public class PrimarilyEnagageWithinNetworkPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Who would you like to primarily engage with in the network?";

        private static By LocallyRadio => By.Id("IsLocalOrganisation");
        private static By MultiRegionalOrganisationRadio => By.Id("multiRegionalOrganisation");

        public LocalAreaToEngage ConfirmLocallyAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(LocallyRadio);
            Continue();
            return new LocalAreaToEngage(context);
        }

        public NetworkSupportAndNetworkJoinPage ConfirmMultiRegionalOrganisationAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(MultiRegionalOrganisationRadio);
            Continue();
            return new NetworkSupportAndNetworkJoinPage(context);
        }

        public Employer_CheckTheInformationPage ChangeJ_ConfirmMultiRegionalOrganisationAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(MultiRegionalOrganisationRadio);
            Continue();
            return new Employer_CheckTheInformationPage(context);
        }
    }
}

