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
            var page = new CreateAnAccountToManageApprenticeshipsPage(_context)
                 .CreateAccount()
                 .Register()
                 .ContinueToGetApprenticeshipFunding();
            
            var homePage = AddPayeAndOrgDetailsAndSignAgreement(page, 0);

            var accountId = homePage.AccountId();
            _objectContext.SetHashedAccountId(accountId);

            var publicAccountId = homePage.PublicAccountId();
            _objectContext.SetPublicHashedAccountId(publicAccountId);

            return homePage;
        }

        public HomePage AddNewAccountAndSignAnAgreement(HomePage homePage, int index)
        {
            var page = homePage.GoToYourAccountsPage().AddNewAccount();

            homePage = AddPayeAndOrgDetailsAndSignAgreement(page, index);
                 
            var accountId = homePage.AccountId();
            var publicAccountId = homePage.PublicAccountId();

            if (index == 1)
            {
                _objectContext.SetSecondAccountId(accountId);
                _objectContext.SetPublicSecondAccountId(publicAccountId);
            }
            else if(index == 2)
            {
                _objectContext.SetThirdAccountId(accountId);
                _objectContext.SetPublicThirdAccountId(publicAccountId);
            }

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
