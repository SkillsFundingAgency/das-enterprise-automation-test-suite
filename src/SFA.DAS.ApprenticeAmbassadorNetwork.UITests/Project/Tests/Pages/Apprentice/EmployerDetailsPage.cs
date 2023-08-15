namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice
{
    public class EmployerDetailsPage : AanBasePage
    {
        protected override string PageTitle => "your employer's name and address";

        private By AddressLine1 = By.Id("AddressLine1");
        private By EmployerName = By.Id("EmployerName");
        private By AddressLine2 = By.Id("AddressLine2");
        private By County = By.Id("County");
        private By Town = By.Id("Town");
        private By Postcode = By.Id("Postcode");
        public EmployerDetailsPage(ScenarioContext context) : base(context) { }

        public CurrentJobTitlePage EnterEmployersDetailsAndContinue()
        {
            formCompletionHelper.EnterText(EmployerName, aanDataHelpers.VenueName);
            Continue();
            return new CurrentJobTitlePage(context);
        }

        public CurrentJobTitlePage EnterFullEmployersDetailsAndContinue()
        {
            formCompletionHelper.EnterText(EmployerName, aanDataHelpers.VenueName);
            formCompletionHelper.EnterText(AddressLine1, aanDataHelpers.AddressLine1);
            formCompletionHelper.EnterText(AddressLine2, aanDataHelpers.AddressLine2);
            formCompletionHelper.EnterText(County, aanDataHelpers.County);
            formCompletionHelper.EnterText(Town, aanDataHelpers.Town);
            formCompletionHelper.EnterText(Postcode, aanDataHelpers.PostCode);
            Continue();
            return new CurrentJobTitlePage(context);
        }
        public CheckYourAnswersPage ChangeVenueNameAndContinue()
        {
            formCompletionHelper.EnterText(EmployerName, aanDataHelpers.NewVenueName);
            Continue();
            return new CheckYourAnswersPage(context);
        }
    }
}



