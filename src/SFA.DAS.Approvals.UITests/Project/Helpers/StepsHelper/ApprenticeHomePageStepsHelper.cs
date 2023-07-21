using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class ApprenticeHomePageStepsHelper
    {
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;
        private readonly ScenarioContext _context;

        public ApprenticeHomePageStepsHelper(ScenarioContext context)
        {
            _context = context;
            _homePageStepsHelper = new EmployerHomePageStepsHelper(_context);
        }

        public ManageYourApprenticesPage GoToManageYourApprenticesPage(bool openInNewTab = true) => GoToEmployerApprenticesHomePage(openInNewTab).ClickManageYourApprenticesLink();

        public HomePage GotoEmployerHomePage(bool openInNewTab = true) => _homePageStepsHelper.GotoEmployerHomePage(openInNewTab);

        public ApprenticesHomePage GoToEmployerApprenticesHomePage(bool openInNewTab = true)
        {
            GotoEmployerHomePage(openInNewTab);

            return new ApprenticesHomePage(_context);
        }
        public ApprovalsProviderHomePage GoToProviderApprenticesHomePage(bool openInNewTab = true)
        {
            GotoEmployerHomePage(openInNewTab);

            return new ApprovalsProviderHomePage(_context);
        }

    }
}