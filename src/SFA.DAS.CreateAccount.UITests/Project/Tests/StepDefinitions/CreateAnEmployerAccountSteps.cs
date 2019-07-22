using NUnit.Framework;
using SFA.DAS.CreateAccount.Helpers;
using SFA.DAS.CreateAccount.UITests.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CreateAnEmployerAccountSteps
    {
        private readonly ScenarioContext _context;
        private readonly CreateAccountConfig _createAccountConfig;
        private readonly AccountHelpers _accountHelpers;

        public CreateAnEmployerAccountSteps(ScenarioContext context)
        {
            _context = context;
            _createAccountConfig = _context.Get<CreateAccountConfig>();
            _accountHelpers = new AccountHelpers(_context);
        }

        [Given(@"I navigate to the Create Account page")]
        public void GivenINavigateToTheCreateAccountPage()
        {
            _context
            .SiteHomepage()
            .ClickCreateAccountButton();
        }

        [When(@"I submit the form with the mandatory data items supplied")]
        public void WhenISubmitTheFormWithTheMandatoryDataItemsSupplied()
        {
            _context
                .SetUpAsAUserPage()
                .SubmitValidForm(UserAccountConstants.FirstName, UserAccountConstants.LastName, _accountHelpers.GenerateRandEmail(), _createAccountConfig.MACurrentUserPassword, _createAccountConfig.MACurrentUserPassword);
        }

        [When(@"I submit the activation code recieved as a consequence of a successful form submission")]
        public void WhenISubmitTheActivationCodeRecievedAsAConsequenceOfASuccessfulFormSubmission()
        {
            _context
            .ConfirmYourIdentityPage()
            .ValidAccesCode(UserAccountConstants.ValidAccessCode);
        }

        [Then(@"a DAS account will be created")]
        public void ThenADASAccountWillBeCreated()
        {
            var page = _context.AccountSettingsPage();
            Assert.AreEqual("Settings", page.AccountName());
        }
    }
}
