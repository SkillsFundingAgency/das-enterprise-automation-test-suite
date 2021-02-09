using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.FindEPAO.UITests.Project.Tests.Pages
{
    public class SearchApprenticeshipTrainingCoursePage : FindEPAOBasePage
    {
        protected override string PageTitle => "What is the apprenticeship training course?";
        private readonly ScenarioContext _context;
        public SearchApprenticeshipTrainingCoursePage(ScenarioContext context) : base(context) => _context = context;

        public EPAOOrganisationsPage SearchForApprenticeshipStandardInSearchApprenticeshipTrainingCoursePage(string searchTerm)
        {
            SearchApprenticeshipStandard(searchTerm);
            return new EPAOOrganisationsPage(_context);
        }

        public ZeroAssessmentOrganisationsPage SearchForApprenticeshipStandardWithNoEPAO(string searchTerm)
        {
            SearchApprenticeshipStandard(searchTerm);
            return new ZeroAssessmentOrganisationsPage(_context);
        }

        public EPAOOrganisationDetailsPage SearchForApprenticeshipStandardWithSingleEPAO(string searchTerm)
        {
            SearchApprenticeshipStandard(searchTerm);
            return new EPAOOrganisationDetailsPage(_context);
        }

        public IntegratedAppreticeshipStandardPage SearchForAnIntegratedApprenticeshipStandard(string searchTerm)
        {
            SearchApprenticeshipStandard(searchTerm);
            return new IntegratedAppreticeshipStandardPage(_context);
        }
    }
}
