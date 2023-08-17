using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class ProviderCommonStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;
        private readonly SetApprenticeDetailsHelper _setApprenticeDetailsHelper;

        public ProviderCommonStepsHelper(ScenarioContext context)
        {
            _context = context;
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);
            _setApprenticeDetailsHelper = new SetApprenticeDetailsHelper(_context);
        }

        public ProviderConfirmEmployerPage ChooseALevyEmployer() => GoToProviderHomePage().GotoSelectJourneyPage().SelectAddManually().SelectOptionCreateNewCohort().ChooseAnEmployer("Levy");

        internal ApprovalsProviderHomePage GoToProviderHomePage(ProviderConfig login, bool newTab)
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(login, newTab);
            return new ApprovalsProviderHomePage(_context);
        }

        internal ApprovalsProviderHomePage GoToProviderHomePage(ProviderLoginUser login, bool newTab = true)
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(login, newTab);
            return new ApprovalsProviderHomePage(_context);
        }

        public ApprovalsProviderHomePage NavigateToProviderHomePage() => new(_context, true);

        public ApprovalsProviderHomePage GoToProviderHomePage(bool newTab = true)
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(newTab);
            return new ApprovalsProviderHomePage(_context);
        }

        internal ProviderApproveApprenticeDetailsPage ViewCurrentCohortDetails() => GoToProviderHomePage().GoToApprenticeRequestsPage().ViewCurrentCohortDetails();

        internal ProviderApproveApprenticeDetailsPage SetApprenticeDetails(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, int numberOfApprentices)
        {
            _setApprenticeDetailsHelper.SetApprenticeDetails(providerApproveApprenticeDetailsPage, numberOfApprentices);

            return providerApproveApprenticeDetailsPage;
        }

        public ProviderApproveApprenticeDetailsPage CurrentCohortDetails() => CurrentCohortDetails(GoToProviderHomePage());

        public ProviderApproveApprenticeDetailsPage CurrentCohortDetails(ApprovalsProviderHomePage _) => new ProviderApprenticeRequestsPage(_context, true).GoToCohortsToReviewPage().SelectViewCurrentCohortDetails();
    }
}