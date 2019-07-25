using SFA.DAS.PocProject.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CreateAccountSteps
    {
        private ScenarioContext _context;
        private GetApprenticeshipFunding getApprenticeshipFunding;

        public CreateAccountSteps(ScenarioContext context)
        {
            _context = context;
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
    }
}
