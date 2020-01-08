using System;
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
            var homePage = new IndexPage(_context)
                 .CreateAccount()
                 .Register()
                 .ContinueToGetApprenticeshipFunding()
                 .AddPaye()
                 .ContinueToGGSignIn()
                 .SignInTo()
                 .SearchForAnOrganisation()
                 .SelectYourOrganisation()
                 .ContinueToAboutYourAgreementPage()
                 .SelectViewAgreementNowAndContinue()
                 .SignAgreement();

            var accountid = homePage.AccountId();
            _objectContext.SetAccountId(accountid);

            return homePage;
        }

        public HomePage AddNewAccountAndSignAnAgreement(HomePage homePage)
        {
            homePage.GoToYourAccountsPage()
                 .AddNewAccount()
                 .ContinueToGGSignIn()
                 .SignInTo()
                 .SearchForAnOrganisation()
                 .SelectYourOrganisation()
                 .ContinueToAboutYourAgreementPage()
                 .SelectViewAgreementNowAndContinue()
                 .SignAgreement();

            var accountid = homePage.AccountId();
            _objectContext.SetReceiverAccountId(accountid);

            var publicAccountid = homePage.PublicAccountId();
            _objectContext.SetReceiverPublicAccountId(publicAccountid);

            return homePage;
        }
    }
}
