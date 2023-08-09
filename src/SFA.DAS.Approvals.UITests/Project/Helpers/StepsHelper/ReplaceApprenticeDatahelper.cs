using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class ReplaceApprenticeDatahelper
    {
        private readonly ScenarioContext _context;

        public ReplaceApprenticeDatahelper(ScenarioContext context) => _context = context;

        public void ReplaceApprenticeDataInContext(int i)
        {
            var listOfApprentice = _context.Get<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>().ToList();

            var apprentice = listOfApprentice[i];

            _context.Replace(apprentice.Item1);
            _context.Replace(apprentice.Item2);
        }
    }
}