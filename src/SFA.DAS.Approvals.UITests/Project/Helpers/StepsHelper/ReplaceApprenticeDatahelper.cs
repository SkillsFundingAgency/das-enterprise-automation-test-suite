using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.FrameworkHelpers;
using System;
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
            => ReplaceApprenticeDataInContext(GetApprentice(i));

        public void ReplaceApprenticeDataInContext(int i, Func<(ApprenticeDataHelper, ApprenticeCourseDataHelper), (ApprenticeDataHelper, ApprenticeCourseDataHelper)> func) 
            => ReplaceApprenticeDataInContext(func(GetApprentice(i)));

        private (ApprenticeDataHelper, ApprenticeCourseDataHelper) GetApprentice(int i) => _context.Get<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>().ToList()[i];

        private void ReplaceApprenticeDataInContext((ApprenticeDataHelper apprenticeDataHelper, ApprenticeCourseDataHelper apprenticeCourseDataHelper) data)
        {
            _context.Replace(data.apprenticeDataHelper);
            _context.Replace(data.apprenticeCourseDataHelper);
        }
    }
}