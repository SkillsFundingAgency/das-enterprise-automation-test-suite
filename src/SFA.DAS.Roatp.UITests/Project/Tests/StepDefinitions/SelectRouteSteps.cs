using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SelectRouteSteps
    {
        private readonly ScenarioContext _context;
        private readonly SelectRouteStepsHelper _selectRouteStepsHelper;
        private AlreadyOnRoatpPage _alreadyOnRoatpPage;

        public SelectRouteSteps(ScenarioContext context)
        {
            _context = context;
            _selectRouteStepsHelper = new SelectRouteStepsHelper(_context);
        }

        [Given(@"the provider initates an application as employer who is already on Roatp as employer")]
        public void GivenTheProviderInitatesAnApplicationAsEmployerWhoIsAlreadyOnRoatpAsEmployer() => _alreadyOnRoatpPage = _selectRouteStepsHelper.CompleteProviderCharityRouteWhoisAlreayOnRoatp();

        [Then(@"the provider can change the route as main provider")]
        public void ThenTheProviderCanChangeTheRouteAsMainProvider() => _alreadyOnRoatpPage.SelectYesToChangeProviderRouteAndContinue().SelectApplicationRouteAsMain().AcceptAndContinue();
    }
}
