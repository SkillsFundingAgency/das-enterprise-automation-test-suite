using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CheckYourDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Check your details";
        private readonly ScenarioContext _context;

        #region Locators
        protected override By ContinueButton => By.Id("continue");
        private By YesContinueButton => By.CssSelector("input.button");
        private By OrganisationName => By.XPath("//th[text()='Organisation name']/following-sibling::td");
        private By OrganisationAddress => By.XPath("//th[text()='Organisation address']/following-sibling::td");
        private By OrganisationNumber => By.XPath("//th[text()='Organisation number']/following-sibling::td");
        private By ManuallyAddedOrganisationNumber => By.XPath("//th/span[text()='Charity number']/../following-sibling::td/span");
        private By ManuallyAddedOrganisationName => By.XPath("//th[contains(text(), 'Organisation')]/following-sibling::td");
        private By ManuallyAddedOrganisationAddress => By.XPath("//th[contains(text(), 'Address')]/following-sibling::td");
        #endregion

        public CheckYourDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhenDoYouWantToViewEmpAgreementPage ContinueToAboutYourAgreementPage()
        {
            Continue();
            return new WhenDoYouWantToViewEmpAgreementPage(_context);
        }

        public OrganisationHasBeenAddedPage ClickYesContinueButton()
        {
            formCompletionHelper.Click(YesContinueButton);
            return new OrganisationHasBeenAddedPage(_context);
        }

        public string GetOrganisationNumber() => pageInteractionHelper.GetText(OrganisationNumber);

        public string GetOrganisationName() => pageInteractionHelper.GetText(OrganisationName);

        public string GetOrganisationAddress() => pageInteractionHelper.GetText(OrganisationAddress);

        public string GetManuallyAddedOrganisationNumber() => pageInteractionHelper.GetText(ManuallyAddedOrganisationNumber);

        public string GetManuallyAddedOrganisationName() => pageInteractionHelper.GetText(ManuallyAddedOrganisationName);

        public string GetManuallyAddedOrganisationAddress() => pageInteractionHelper.GetText(ManuallyAddedOrganisationAddress).Replace("\r\n", " ");

        public WhenDoYouWantToViewEmpAgreementPage ClickYesTheseDetailsAreCorrectButtonInCheckYourDetailsPage()
        {
            Continue();
            return new WhenDoYouWantToViewEmpAgreementPage(_context);
        }
    }
}