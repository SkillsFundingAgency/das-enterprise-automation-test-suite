using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public class ManageStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RAAV1Config _config;
        private readonly RestartWebDriverHelper _helper;
        private readonly TabHelper _tabHelper;
        private const string _applicationName = "Manage";

        public ManageStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _helper = new RestartWebDriverHelper(context);
            _tabHelper = context.Get<TabHelper>();
            _config = context.GetRAAV1Config<RAAV1Config>();
        }

        public void ApproveAVacancy(bool restart) => GoToManageHomePage(restart).ReviewAVacancy().ApproveAVacancy();
       
        public Manage_HomePage GoToManageHomePage(bool restart)
        {
            if (restart)
            {
                _helper.RestartWebDriver(_config.ManageBaseUrl, _applicationName);
            }
            else
            {
                _objectContext.SetCurrentApplicationName(_applicationName);
                _tabHelper.GoToUrl(_config.ManageBaseUrl);
            }

            new Manage_IndexPage(_context).ClickAgencyButton().LoginToAccess1Staff();

            return new SignInPage(_context).SubmitManageLoginDetails();
        }

        public void SearchForACandidate() => Search().ViewApplications();

        public void SearchForDeletedCandidate() => Search().VerifyCandidateDeletion();

        private Manage_SearchForACandidatePage Search() => GoToManageHomePage(true).HelpdeskAdviser().SearchForACandidate().Search();

        public void VerifyUpdatedCandidateDetails() => Search().VerifyUpdatedCandidateDetails();
    }
}