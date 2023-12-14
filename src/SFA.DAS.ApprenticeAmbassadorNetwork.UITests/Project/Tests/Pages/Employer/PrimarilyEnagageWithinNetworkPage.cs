namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer
{
    public class PrimarilyEnagageWithinNetworkPage : AanBasePage
    {
        protected override string PageTitle => "Who would you like to primarily engage with in the network?";

        private static By LocallyRadio => By.Id("IsLocalOrganisation");
        private static By MultiRegionalOrganisationRadio => By.Id("multiRegionalOrganisation");

        public PrimarilyEnagageWithinNetworkPage(ScenarioContext context) : base(context) => VerifyPage();

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

