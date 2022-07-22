using SFA.DAS.Registration.UITests.Project.Helpers;

namespace SFA.DAS.SupportConsole.UITests.Project.Helpers
{
    public class EmployerStepsHelper : EmployerHomePageStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;


        public EmployerStepsHelper(ScenarioContext context) : base(context)
        {
            _context = context;            
            _tabHelper = context.Get<TabHelper>();
        }

        public void NavigateToEmployerHomePage()
        {
            var baseUrl = UrlConfig.EmployerApprenticeshipService_BaseUrl;
            _tabHelper.GoToUrl(baseUrl);
            //_tabHelper.OpenInNewTab(baseUrl);
        }

    }
}
