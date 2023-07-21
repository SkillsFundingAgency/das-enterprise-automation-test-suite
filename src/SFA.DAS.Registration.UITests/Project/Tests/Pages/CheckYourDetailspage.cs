using OpenQA.Selenium;
using SFA.DAS.MongoDb.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CheckYourDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Check your details";
        
        #region Locators
        protected override By ContinueButton => By.Id("continue-check-details");
        private By YesContinueButton => By.XPath("//input[@value='Yes, continue']");
        private By OrganisationName => By.XPath("//th[contains(text(),'Organisation')]/following-sibling::td");
        private By OrganisationAddress => By.XPath("//th[text()='Organisation address']/following-sibling::td");
        private By OrganisationNumber => By.XPath("//th[text()='Organisation number']/following-sibling::td");
        private By PayeScheme => By.XPath("//th[contains(text(),'Employer PAYE reference')]/following-sibling::td//dt");   
        private By OrganisationChangeLink => By.XPath($"//td[contains(text(), '{objectContext.GetOrganisationName()}')]/..//a");
        private By AornChangeLink => By.XPath($"//td[contains(text(), '{registrationDataHelper.AornNumber}')]/..//a");
        private By PayeSchemeChangeLink => By.XPath($"//dt[contains(text(), '{objectContext.GetGatewayPaye(0)}')]/../../following-sibling::td/a");
        #endregion

        public CheckYourDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public YouHaveAddedYourOrgAndPAYEScheme ContinueToSetAccountName()
        {
            Continue();
            return new YouHaveAddedYourOrgAndPAYEScheme(context);
        }

        public OrganisationHasBeenAddedPage ClickYesContinueButton()
        {
            formCompletionHelper.ClickElement(YesContinueButton);
            return new OrganisationHasBeenAddedPage(context);
        }

        public AccessDeniedPage ClickYesContinueButtonAndRedirectedToAccessDeniedPage()
        {
            formCompletionHelper.Click(YesContinueButton);
            return new AccessDeniedPage(context);
        }

        public string GetOrganisationName() => pageInteractionHelper.GetText(OrganisationName);

        public string GetOrganisationAddress() => pageInteractionHelper.GetText(OrganisationAddress);

        public string GetOrganisationNumber() => pageInteractionHelper.GetText(OrganisationNumber);

        public string GetPayeScheme() => pageInteractionHelper.GetText(PayeScheme);
      
        public SearchForYourOrganisationPage ClickOrganisationChangeLink()
        {
            formCompletionHelper.Click(OrganisationChangeLink);
            return new SearchForYourOrganisationPage(context);
        }

        public EnterYourPAYESchemeDetailsPage ClickAornChangeLink()
        {
            formCompletionHelper.Click(AornChangeLink);
            return new EnterYourPAYESchemeDetailsPage(context);
        }

        public AddAPAYESchemePage ClickPayeSchemeChangeLink()
        {
            formCompletionHelper.Click(PayeSchemeChangeLink);
            return new AddAPAYESchemePage(context);
        }
    }
}