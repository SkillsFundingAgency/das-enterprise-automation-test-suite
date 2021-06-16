using TechTalk.SpecFlow;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages;
using SFA.DAS.FAT_V2.UITests.Project.Helpers;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers
{
    public class AEDStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly FATV2StepsHelper _fATV2StepsHelper;

        public AEDStepsHelper(ScenarioContext context)
        {
            _context = context;
            _fATV2StepsHelper = new FATV2StepsHelper(_context);
        }

        public GetHelpWithFindingATrainingProviderPage GetHelpWithFindingATrainingProvider()
        {
            new AEDIndexPage(_context).ClickGetHelpWithFindingATrainingProviderLink()
                .ClickStartNow();
            return new GetHelpWithFindingATrainingProviderPage(_context);
        }
        public AEDIndexPage NavigateToShareYourInterestWithTrainingProvidersPage()
        {
            _fATV2StepsHelper.SelectTrainingCourseAndNavigateToProviderListPage();
            return new AEDIndexPage(_context);
        }

    }
}
