using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.TestDataExport;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding, Scope(Tag = "limitingstandards")]
    public class LimitingStandardsSteps
    {
        private readonly ScenarioContext _context;

        private readonly ObjectContext _objectContext;

        private readonly LimitingStandardConfig _config;

        public LimitingStandardsSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetLimitingStandardConfig<LimitingStandardConfig>();
        }

        [Given(@"Provider does not offer Standard-X")]
        public void GivenProviderDoesNotOfferStandard_X()
        {
            var listOfApprentices = _context.Get<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>();

            var course = listOfApprentices.FirstOrDefault().Item2.ProviderCourses;

            _objectContext.SetDebugInformation($"Provider deos not offer {course.Course.larsCode} - '{course.Course.title}' course ");

            course = listOfApprentices.LastOrDefault().Item2.ProviderCourses;

            _objectContext.SetDebugInformation($"Provider deos not offer {course.Course.larsCode} - '{course.Course.title}' course ");
        }

        [Given(@"Provider receives a cohort that contains Standard-X")]
        public void GivenProviderReceivesACohortThatContainsStandard_X()
        {
            
        }


    }
}
