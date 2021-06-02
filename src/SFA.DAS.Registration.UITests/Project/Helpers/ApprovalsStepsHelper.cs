using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class ApprovalsStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public ApprovalsStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
        }

        public HomePage CreatesAccountAndSignAnAgreement()
        {
            var page = new IndexPage(_context)
                 .CreateAccount()
                 .Register()
                 .ContinueToGetApprenticeshipFunding();
            
            var homePage = AddPayeAndOrgDetailsAndSignAgreement(page, 0);

            var accountid = homePage.AccountId();
            _objectContext.SetHashedAccountId(accountid);

            return homePage;
        }

        public HomePage AddNewAccountAndSignAnAgreement(HomePage homePage, int index)
        {
            var page = homePage.GoToYourAccountsPage().AddNewAccount();

            homePage = AddPayeAndOrgDetailsAndSignAgreement(page, index);
                 
            var accountid = homePage.AccountId();
            _objectContext.SetReceiverAccountId(accountid);

            var publicAccountid = homePage.PublicAccountId();
            _objectContext.SetReceiverPublicAccountId(publicAccountid);

            return homePage;
        }

        private HomePage AddPayeAndOrgDetailsAndSignAgreement(AddAPAYESchemePage addAPAYESchemePage, int index)
        {
            return addAPAYESchemePage
                 .AddPaye()
                 .ContinueToGGSignIn()
                 .SignInTo(index)
                 .SearchForAnOrganisation()
                 .SelectYourOrganisation()
                 .ContinueToAboutYourAgreementPage()
                 .SelectViewAgreementNowAndContinue()
                 .SignAgreement()
                 .ClickOnViewYourAccountButton();
        }
    }
}
