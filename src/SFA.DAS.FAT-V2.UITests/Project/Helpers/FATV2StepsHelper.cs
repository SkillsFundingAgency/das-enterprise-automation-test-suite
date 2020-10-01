using NUnit.Framework;
using SFA.DAS.FAT_V2.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Helpers
{
    class FATV2StepsHelper
    {
        private readonly ScenarioContext _context;

        public FATV2StepsHelper(ScenarioContext context)
        {
            _context = context;
        }
        public TrainingCourseSearchResultsPage SearchForTrainingCourse(string course = "")
        {
            new FATV2IndexPage(_context).ClickStartButton().SearchApprenticeshipInFindApprenticeshipTrainingSearchPage(course);
            return new TrainingCourseSearchResultsPage(_context);
        }
    }
}
