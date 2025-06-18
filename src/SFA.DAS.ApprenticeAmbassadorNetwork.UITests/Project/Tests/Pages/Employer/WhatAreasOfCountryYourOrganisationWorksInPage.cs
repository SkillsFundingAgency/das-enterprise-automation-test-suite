namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer
{
    public class WhatAreasOfCountryYourOrganisationWorksInPage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Tell us what areas of the country your organisation works in";

        private static By LondonRadio => By.Id("3");
        private static By EastMidlandsRadio => By.Id("1");
        private static By EastOfEnglandRadio => By.Id("2");
        private static By NorthEastRadio => By.Id("4");
        private static By NorthWestRadio => By.Id("5");

        public NetworkSupportAndNetworkJoinPage ConfirmAreasOfWorkAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(LondonRadio);
            Continue();
            return new NetworkSupportAndNetworkJoinPage(context);
        }

        public LocalAreaToEngage UserSelectUpTo4Regions()
        {
            formCompletionHelper.SelectRadioOptionByLocator(EastMidlandsRadio);
            formCompletionHelper.SelectRadioOptionByLocator(EastOfEnglandRadio);
            formCompletionHelper.SelectRadioOptionByLocator(NorthEastRadio);
            formCompletionHelper.SelectRadioOptionByLocator(NorthWestRadio);
            Continue();
            return new LocalAreaToEngage(context);
        }
        public LocalAreaToEngage Add3MoreRegionsAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(EastOfEnglandRadio);
            formCompletionHelper.SelectRadioOptionByLocator(NorthEastRadio);
            formCompletionHelper.SelectRadioOptionByLocator(NorthWestRadio);
            Continue();
            return new LocalAreaToEngage(context);
        }

        public PrimarilyEnagageWithinNetworkPage Add1MoreRegionsAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(EastMidlandsRadio);
            Continue();
            return new PrimarilyEnagageWithinNetworkPage(context);
        }

        public PrimarilyEnagageWithinNetworkPage UserSelectMoreThan4Regions()
        {
            formCompletionHelper.SelectRadioOptionByLocator(EastMidlandsRadio);
            formCompletionHelper.SelectRadioOptionByLocator(EastOfEnglandRadio);
            formCompletionHelper.SelectRadioOptionByLocator(NorthEastRadio);
            formCompletionHelper.SelectRadioOptionByLocator(NorthWestRadio);
            formCompletionHelper.SelectRadioOptionByLocator(LondonRadio);
            Continue();
            return new PrimarilyEnagageWithinNetworkPage(context);
        }
    }
}

