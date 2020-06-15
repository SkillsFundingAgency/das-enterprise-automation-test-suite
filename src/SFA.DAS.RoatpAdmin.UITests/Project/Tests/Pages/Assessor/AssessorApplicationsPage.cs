using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor
{
    public class AssessorApplicationsPage : AssessorBasePage
    {
        protected override string PageTitle => "RoATP assessor applications";
        private readonly ScenarioContext _context;

        public By AssignToMeLinkForMainProvider => By.XPath("//td[contains(text(),'Main provider')]//following-sibling::td//a");

        public AssessorApplicationsPage(ScenarioContext context) : base(context) => _context = context;

        public ApplicationAssessmentOverviewPage AssessorSelectsAssignToMeForMainProvider()
        {
            formCompletionHelper.Click(AssignToMeLinkForMainProvider);
            return new ApplicationAssessmentOverviewPage(_context);
        }
    }
}
