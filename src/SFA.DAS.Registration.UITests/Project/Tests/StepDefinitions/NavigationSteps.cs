using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;


namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class NavigationSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        public NavigationSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
        }

        private HomePage GoToEmployersHomePage() => new HomePage(_context, true);

        
        [Then(@"EI link is visible on the Employer Home page")]
        public void ThenEILinkIsVisibleOnTheEmployerHomePage()
        {
            GoToEmployersHomePage().ValidateEmployerIncentivesLink();
        }


    }
}
