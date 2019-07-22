using OpenQA.Selenium;
using SFA.DAS.CreateAccount.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CreateAnEmployerAccountSteps
    {
        private readonly ScenarioContext _context;
        private readonly CreateAccountConfig _createAccountConfig;

        public CreateAnEmployerAccountSteps(ScenarioContext context)
        {
            _context = context;
            _createAccountConfig = _context.Get<CreateAccountConfig>();
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
                .SetUpAsAUserPage();
            //    .SubmitValidForm(UserAccountConstants.FirstName, UserAccountConstants.LastName, AccountHelpers.GenerateRandEmail(), MACurrentUserPassword, MACurrentUserPassword);
        }

        [When(@"I submit the activation code recieved as a consequence of a successful form submission")]
        public void WhenISubmitTheActivationCodeRecievedAsAConsequenceOfASuccessfulFormSubmission()
        {
            throw new PendingStepException();
        }

        [Then(@"a DAS account will be created")]
        public void ThenADASAccountWillBeCreated()
        {
            throw new PendingStepException();
        }
    }
}
