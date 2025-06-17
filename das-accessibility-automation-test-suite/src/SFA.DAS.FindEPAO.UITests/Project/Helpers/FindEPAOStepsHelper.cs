using SFA.DAS.FindEPAO.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.FindEPAO.UITests.Project.Helpers
{
    class FindEPAOStepsHelper(ScenarioContext context)
    {
        public EPAOOrganisationsPage SearchForApprenticeshipStandard(string standard = "") => FindEPAO().SearchForApprenticeshipStandardInSearchApprenticeshipTrainingCoursePage(standard);

        public ZeroAssessmentOrganisationsPage SearchForApprenticeshipStandardWithNoEPAO(string standard = "") => FindEPAO().SearchForApprenticeshipStandardWithNoEPAO(standard);

        public EPAOOrganisationDetailsPage SearchForApprenticeshipStandardWithSingleEPAO(string standard = "") => FindEPAO().SearchForApprenticeshipStandardWithSingleEPAO(standard);

        public EPAOOrganisationsPage SearchForIntegratedApprenticeshipStandard(string standard = "") => FindEPAO().SearchForAnIntegratedApprenticeshipStandard(standard);

        private SearchApprenticeshipTrainingCoursePage FindEPAO() => new FindEPAOIndexPage(context).ClickStartButton();
    }
}
