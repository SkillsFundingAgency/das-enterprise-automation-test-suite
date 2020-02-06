using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CreateAccountSteps
    {
        private readonly ScenarioContext _context;
        private GetApprenticeshipFunding getApprenticeshipFunding;
        private OrganisationSearchPage organistionSearchPage;
        private SignAgreementPage _signAgreementPage;
        private HomePage homePage;
        private readonly ObjectContext _objectContext;
        private readonly RegistrationDatahelpers _dataHelper;

        public CreateAccountSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _dataHelper = context.Get<RegistrationDatahelpers>();
        }

        [Given(@"an User Account is created")]
        [When(@"an User Account is created")]
        public void AnUserAccountIsCreated()
        {
            TestContext.Progress.WriteLine($"Email : {_dataHelper.RandomEmail}");

            getApprenticeshipFunding = new IndexPage(_context)
                .CreateAccount()
                .Register()
                .ContinueToGetApprenticeshipFunding();
        }

        [Then(@"My Account Home page is displayed when PAYE details are not added")]
        public void DoNotAddPayeDetails()
        {
           getApprenticeshipFunding.DoNotAddPaye();
        }

        [When(@"the User adds PAYE details")]
        public void AddPayeDetails()
        {
            organistionSearchPage = getApprenticeshipFunding
                .AddPaye().ContinueToGGSignIn()
                .SignInTo();
        }

        [When(@"adds Organisation details")]
        public void AddOrganisationDetails()
        {
            _signAgreementPage = organistionSearchPage
                .SearchForAnOrganisation()
                .SelectYourOrganisation()
                .ContinueToAboutYourAgreementPage()
                .SelectViewAgreementNowAndContinue();
        }

        [When(@"the Employer is able to Sign the Agreement")]
        [Then(@"the Employer is able to Sign the Agreement")]
        public void SignTheAgreement()
        {
            homePage = _signAgreementPage
                .SignAgreement();

            homePage.VerifySucessSummary();

            SetAgreementId(homePage);
        }

        [When(@"the Employer does not sign the Agreement")]
        public void DoNotSignTheAgreement()
        {
            homePage = _signAgreementPage
                .DoNotSignAgreement();
        }

        [Then(@"the Employer lands on the Organisation Agreement page")]
        public void LandInTheOrganisationAgreementPage()
        {
            _signAgreementPage
                .VerifySignAgreementPage();
        }

        [Then(@"the Employer Home page is displayed")]
        public void TheEmployerHomePageIsDisplayed()
        {
            var accountid = new HomePage(_context)
                .HomePage()
                .AccountId();

            _objectContext.SetAccountId(accountid);
        }

        private HomePage SetAgreementId(HomePage homePage)
        {
            homePage
                 .GoToYourOrganisationsAndAgreementsPage()
                 .SetAgreementId();

            return new HomePage(_context, true);
        }
    }
}
