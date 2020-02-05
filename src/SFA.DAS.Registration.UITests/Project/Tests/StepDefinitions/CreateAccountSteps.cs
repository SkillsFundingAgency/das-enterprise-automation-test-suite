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

        [Given(@"I create an Account")]
        public void CreateAnAccount()
        {
            TestContext.Progress.WriteLine($"Email : {_dataHelper.RandomEmail}");

            getApprenticeshipFunding = new IndexPage(_context)
                .CreateAccount()
                .Register()
                .ContinueToGetApprenticeshipFunding();
        }

        [Then(@"I do not add paye details")]
        public void DoNotAddPayeDetails()
        {
           getApprenticeshipFunding.DoNotAddPaye();
        }

        [When(@"I add paye details")]
        public void AddPayeDetails()
        {
            organistionSearchPage = getApprenticeshipFunding
                .AddPaye().ContinueToGGSignIn()
                .SignInTo();
        }

        [When(@"add organisation details")]
        public void AddOrganisationDetails()
        {
            _signAgreementPage = organistionSearchPage
                .SearchForAnOrganisation()
                .SelectYourOrganisation()
                .ContinueToAboutYourAgreementPage()
                .SelectViewAgreementNowAndContinue();
        }

        [When(@"I sign the agreement")]
        public void SignTheAgreement()
        {
            homePage = _signAgreementPage
                .SignAgreement();

            homePage.VerifySucessSummary();

            SetAgreementId(homePage);
        }

        [When(@"I do not sign the agreement")]
        public void DoNotSignTheAgreement()
        {
            homePage = _signAgreementPage
                .DoNotSignAgreement();
        }

        [Then(@"I will land in the Organisation Agreement page")]
        public void LandInTheOrganisationAgreementPage()
        {
            _signAgreementPage
                .VerifySignAgreementPage();
        }

        [Then(@"I will land in the User Home page")]
        public void ThenIWillLandInTheUserHomePage()
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
