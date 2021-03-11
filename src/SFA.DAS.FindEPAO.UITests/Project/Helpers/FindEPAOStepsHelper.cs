using TechTalk.SpecFlow;
using SFA.DAS.FindEPAO.UITests.Project.Tests.Pages;

namespace SFA.DAS.FindEPAO.UITests.Project.Helpers
{
    class FindEPAOStepsHelper
    {
        private readonly ScenarioContext _context;

        public FindEPAOStepsHelper(ScenarioContext context)
        {
            _context = context;
        }
        public EPAOOrganisationsPage SearchForApprenticeshipStandard(string standard = "")
        {
            new FindEPAOIndexPage(_context).ClickStartButton().SearchForApprenticeshipStandardInSearchApprenticeshipTrainingCoursePage(standard);
            return new EPAOOrganisationsPage(_context);
        }

        public ZeroAssessmentOrganisationsPage SearchForApprenticeshipStandardWithNoEPAO(string standard = "")
        {
            new FindEPAOIndexPage(_context).ClickStartButton().SearchForApprenticeshipStandardWithNoEPAO(standard);
            return new ZeroAssessmentOrganisationsPage(_context);
        }

        public EPAOOrganisationDetailsPage SearchForApprenticeshipStandardWithSingleEPAO(string standard = "")
        {
            new FindEPAOIndexPage(_context).ClickStartButton().SearchForApprenticeshipStandardWithSingleEPAO(standard);
            return new EPAOOrganisationDetailsPage(_context);
        }

        public EPAOOrganisationsPage SearchForIntegratedApprenticeshipStandard(string standard = "")
        {
            new FindEPAOIndexPage(_context).ClickStartButton().SearchForAnIntegratedApprenticeshipStandard(standard);
            return new EPAOOrganisationsPage(_context);
        }
    }
}
