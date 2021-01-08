using OpenQA.Selenium;
using SFA.DAS.MongoDb.DataGenerator;
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
        private By OrganisationName => By.XPath("//th[contains(text(),'Organisation')]/following-sibling::td");
        private By OrganisationAddress => By.XPath("//th[text()='Organisation address']/following-sibling::td");
        private By OrganisationNumber => By.XPath("//th[text()='Organisation number']/following-sibling::td");
        private By PayeScheme => By.XPath("//th[contains(text(),'PAYE scheme')]/following-sibling::td//dt");   
        private By OrganisationChangeLink => By.XPath("//a[@href='/accounts/amendOrganisation']");
        private By AornChangeLink => By.XPath($"//td[contains(text(), '{registrationDataHelper.AornNumber}')]/..//a");
        private By PayeSchemeChangeLink => By.XPath($"//dt[contains(text(), '{objectContext.GetGatewayPaye(0)}')]/../../following-sibling::td/a");
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

        public AccessDeniedPage ClickYesContinueButtonAndRedirectedToAccessDeniedPage()
        {
            formCompletionHelper.Click(YesContinueButton);
            return new AccessDeniedPage(_context);
        }

        public string GetOrganisationName() => pageInteractionHelper.GetText(OrganisationName);

        public string GetOrganisationAddress() => pageInteractionHelper.GetText(OrganisationAddress);

        public string GetOrganisationNumber() => pageInteractionHelper.GetText(OrganisationNumber);

        public string GetPayeScheme() => pageInteractionHelper.GetText(PayeScheme);
      
        public WhenDoYouWantToViewEmpAgreementPage ClickYesTheseDetailsAreCorrectButtonInCheckYourDetailsPage()
        {
            Continue();
            return new WhenDoYouWantToViewEmpAgreementPage(_context);
        }

        public SearchForYourOrganisationPage ClickOrganisationChangeLink()
        {
            formCompletionHelper.Click(OrganisationChangeLink);
            return new SearchForYourOrganisationPage(_context);
        }

        public EnterYourPAYESchemeDetailsPage ClickAornChangeLink()
        {
            formCompletionHelper.Click(AornChangeLink);
            return new EnterYourPAYESchemeDetailsPage(_context);
        }

        public AddAPAYESchemePage ClickPayeSchemeChangeLink()
        {
            formCompletionHelper.Click(PayeSchemeChangeLink);
            return new AddAPAYESchemePage(_context);
        }
    }
}