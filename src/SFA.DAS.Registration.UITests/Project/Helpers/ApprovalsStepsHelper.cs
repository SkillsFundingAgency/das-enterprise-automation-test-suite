using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class ApprovalsStepsHelper
    {
        private readonly ObjectContext _objectContext;
        private readonly AccountCreationStepsHelper accountCreationStepsHelper;

        public ApprovalsStepsHelper(ScenarioContext context) { _objectContext = context.Get<ObjectContext>(); accountCreationStepsHelper = new AccountCreationStepsHelper(context); }

        public HomePage CreatesAccountAndSignAnAgreement()
        {
            var homePage = accountCreationStepsHelper.CreateUserAccount();

            _objectContext.SetHashedAccountId(homePage.AccountId());

            return homePage;
        }

        public HomePage AddNewAccountAndSignAnAgreement(HomePage homePage, int index) => accountCreationStepsHelper.AddNewAccount(homePage, index);
    }
}
