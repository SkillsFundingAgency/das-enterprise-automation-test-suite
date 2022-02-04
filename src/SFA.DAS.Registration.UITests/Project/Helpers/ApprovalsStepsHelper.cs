using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class ApprovalsStepsHelper
    {
        private readonly ScenarioContext _context;

        public ApprovalsStepsHelper(ScenarioContext context) => _context = context;

        public HomePage CreatesAccountAndSignAnAgreement()
        {
            var page = new CreateAnAccountToManageApprenticeshipsPage(_context)
                 .CreateAccount()
                 .Register()
                 .ContinueToGetApprenticeshipFunding();
            
            var homePage = AddPayeAndOrgDetailsAndSignAgreement(page, 0);

            SetAccountDetails(homePage, 0);

            return homePage;
        }

        public HomePage AddNewAccountAndSignAnAgreement(HomePage homePage, int index)
        {
            var page = homePage.GoToYourAccountsPage().AddNewAccount();

            homePage = AddPayeAndOrgDetailsAndSignAgreement(page, index);

            SetAccountDetails(homePage, index);

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

        private void SetAccountDetails(HomePage homePage, int index)
        {
            var objectContext = _context.Get<ObjectContext>();

            (string accountId, string publicAccountId) = GetAccountDetails(homePage);

            if (index == 0)
            {
                objectContext.SetHashedAccountId(accountId);
                objectContext.SetPublicHashedAccountId(publicAccountId);
            }
            else if (index == 1)
            {
                objectContext.SetSecondAccountHashedId(accountId);
                objectContext.SetSecondAccountPublicHashedId(publicAccountId);
            }
            else if (index == 2)
            {
                objectContext.SetThirdAccountHashedId(accountId);
                objectContext.SetThirdAccountPublicHashedId(publicAccountId);
            }
        }

        private (string, string) GetAccountDetails(HomePage homePage) => (homePage.AccountId(), homePage.PublicAccountId());
    }
}
