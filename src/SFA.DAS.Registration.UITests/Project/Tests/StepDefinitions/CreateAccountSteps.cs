using NUnit.Framework;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CreateAccountSteps
    {
        private readonly ScenarioContext _context;
        private GetApprenticeshipFunding getApprenticeshipFunding;
        private OrganisationSearchPage organistionSearchPage;
        private AboutYourAgreementPage aboutYourAgreementPage;
        private EoiAboutYourAgreementPage eoiAboutYourAgreementPage;
        private HomePage homePage;
        private readonly ObjectContext _objectContext;

        public CreateAccountSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
        }

        [Given(@"I create an Account")]
        public void GivenICreateAnAccount()
        {
            getApprenticeshipFunding = new IndexPage(_context)
                .CreateAccount()
                .Register()
                .ContinueToGetApprenticeshipFunding();
        }

        [Then(@"I do not add paye details")]
        public void WhenIDoNotAddPayeDetails()
        {
           getApprenticeshipFunding.DoNotAddPaye();
        }

        [When(@"I add paye details")]
        public void ThenIAddPayeDetails()
        {
            organistionSearchPage = getApprenticeshipFunding
                .AddPaye()
                .ContinueToGGSignIn()
                .SignInTo();
        }

        [When(@"organisation details")]
        public void WhenOrganisationDetails()
        {
            aboutYourAgreementPage = organistionSearchPage
                .SearchForAnOrganisation()
                .SelectYourOrganisation()
                .ContinueToAboutYourAgreementPage();
        }

        [When(@"eoi organisation details")]
        public void WhenEoiOrganisationDetails()
        {
            eoiAboutYourAgreementPage = organistionSearchPage
                .SearchForAnOrganisation()
                .SelectYourOrganisation()
                .ContinueToEoiAboutYourAgreementPage();
        }

        [When(@"I sign the agreement")]
        public void WhenISignTheAgreement()
        {
            homePage = aboutYourAgreementPage
                .Agreement()
                .SignAgreement();
        }

        [When(@"I do not sign the agreement")]
        public void WhenIDoNotSignTheAgreement()
        {
            homePage = aboutYourAgreementPage
                .Agreement()
                .DoNotSignAgreement();
        }

        [When(@"I do not sign the eoi agreement")]
        public void WhenIDoNotSignTheEoiAgreement()
        {
            homePage = eoiAboutYourAgreementPage
                .EoiAgreement()
                .DoNotSignAgreement();
        }


        [Then(@"I will land in the Organisation Agreement page")]
        public void ThenIWillLandInTheOrganisationAgreementPage()
        {
            aboutYourAgreementPage
                .AboutYourAgreementPage();
        }

        [Then(@"I will land in the User Home page")]
        public void ThenIWillLandInTheUserHomePage()
        {
            var accountid = new HomePage(_context)
                .HomePage()
                .AccountID();

            SetAccountId(accountid);
        }

        [Then(@"sucess message is displayed")]
        public void ThenSucessMessageIsDisplayed()
        {
            homePage.VerifySucessSummary();
        }

        private void SetAccountId(string accountid)
        {
            TestContext.Progress.WriteLine($"Account Id : {accountid}");
            _objectContext.SetAccountId(accountid);
        }
    }
}
