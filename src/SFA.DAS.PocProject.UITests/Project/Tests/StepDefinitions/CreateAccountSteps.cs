using NUnit.Framework;
using SFA.DAS.PocProject.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CreateAccountSteps
    {
        private readonly ScenarioContext _context;
        private GetApprenticeshipFunding getApprenticeshipFunding;
        private OrganisationSearchPage organistionSearchPage;
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

        [Then(@"I can land in the User Home page")]
        public void ThenICanLandInTheUserHomePage()
        {
            var accountid = organistionSearchPage
                .SearchForAnOrganisation()
                .SelectYourOrganisation()
                .TheseDetailsAreCorrect()
                .GoToHomePage()
                .AccountID();
            TestContext.Progress.WriteLine($"Account Id : {accountid}");

            _objectContext.SetAccountId(accountid);
        }
    }
}
