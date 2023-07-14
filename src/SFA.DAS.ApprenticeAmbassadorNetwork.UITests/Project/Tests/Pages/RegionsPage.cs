namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class RegionsPage : AanBasePage
    {
        protected override string PageTitle => "Tell us what area of the country you work in as an apprentice";
        private static By LondonRadio => By.CssSelector("#SelectedRegionId[value='3']");
        private static By NorthEasstRadio => By.CssSelector("#SelectedRegionId[value='4']");

        public RegionsPage(ScenarioContext context) : base(context) => VerifyPage();


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



