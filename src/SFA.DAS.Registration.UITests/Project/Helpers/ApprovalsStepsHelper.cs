using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class ApprovalsStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly AccountCreationStepsHelper accountCreationStepsHelper;

        public ApprovalsStepsHelper(ScenarioContext context) { _context = context; accountCreationStepsHelper = new AccountCreationStepsHelper(_context); }

        public HomePage CreatesAccountAndSignAnAgreement() => SetAccountDetails(accountCreationStepsHelper.CreateUserAccount(), 0);

        public HomePage AddNewAccountAndSignAnAgreement(HomePage homePage, int index) => SetAccountDetails(accountCreationStepsHelper.AddNewAccount(homePage, index), index);

        private HomePage SetAccountDetails(HomePage homePage, int index)
        {
            var objectContext = _context.Get<ObjectContext>();

            (string accountId, string publicAccountId) = GetAccountDetails(homePage);

            switch (index)
            {
                case 0:
                    objectContext.SetHashedAccountId(accountId);
                    objectContext.SetPublicHashedAccountId(publicAccountId);
                    break;
                case 1:
                    objectContext.SetSecondAccountHashedId(accountId);
                    objectContext.SetSecondAccountPublicHashedId(publicAccountId);
                    break;
                case 2:
                    objectContext.SetThirdAccountHashedId(accountId);
                    objectContext.SetThirdAccountPublicHashedId(publicAccountId);
                    break;
            }

            return homePage;
        }

        private (string, string) GetAccountDetails(HomePage homePage) => (homePage.AccountId(), homePage.PublicAccountId());
    }
}
