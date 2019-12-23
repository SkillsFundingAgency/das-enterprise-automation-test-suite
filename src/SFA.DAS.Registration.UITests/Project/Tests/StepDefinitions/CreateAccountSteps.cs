using NUnit.Framework;
using SFA.DAS.Configuration;
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
        private AboutYourAgreementPage aboutYourAgreementPage;
        private EoiAboutYourAgreementPage eoiAboutYourAgreementPage;
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
            aboutYourAgreementPage = organistionSearchPage
                .SearchForAnOrganisation()
                .SelectYourOrganisation()
                .ContinueToAboutYourAgreementPage();
        }

        [When(@"add eoi organisation details")]
        public void AddEoiOrganisationDetails()
        {
            eoiAboutYourAgreementPage = organistionSearchPage
                .SearchForAnOrganisation()
                .SelectYourOrganisation()
                .ContinueToEoiAboutYourAgreementPage();
        }

        [When(@"I sign the agreement")]
        public void SignTheAgreement()
        {
            homePage = aboutYourAgreementPage
                .ContinueWithAgreement()
                .SignAgreement();

            homePage.VerifySucessSummary();

            SetAgreementId(homePage);
        }

        [When(@"I do not sign the agreement")]
        public void DoNotSignTheAgreement()
        {
            homePage = aboutYourAgreementPage
                .ContinueWithAgreement()
                .DoNotSignAgreement();
        }

        [When(@"I sign the eoi agreement")]
        public void WhenISignTheEoiAgreement()
        {
            homePage = eoiAboutYourAgreementPage
                .ContinueWithEoiAgreement()
                .SignAgreement();

            SetAgreementId(homePage);
        }

        [When(@"I do not sign the eoi agreement")]
        public void DoNotSignTheEoiAgreement()
        {
            homePage = eoiAboutYourAgreementPage
                .ContinueWithEoiAgreement()
                .DoNotSignAgreement();
        }

        [Then(@"I will land in the Organisation Agreement page")]
        public void LandInTheOrganisationAgreementPage()
        {
            aboutYourAgreementPage
                .AboutYourAgreementPage();
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
