using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "roatpoutcome")]
    public class NewRoatpAdminRoatpOversightHooks : RoatpBaseHooks
    {
        private readonly ScenarioContext _context;
        private readonly RoatpApplySqlDbHelper _roatpApplyClearDownDataHelpers;

        public NewRoatpAdminRoatpOversightHooks(ScenarioContext context) : base(context)
        {
            _context = context;
            _roatpApplyClearDownDataHelpers = new RoatpApplySqlDbHelper(_dbConfig);
        }

        [BeforeScenario(Order = 33)]
        public void OversightReviewClearDownFromApply() => _roatpApplyClearDownDataHelpers.OversightReviewClearDownFromApply(GetUkprn());

        [BeforeScenario(Order = 34)]
        public void ClearDownTrainingProvider()
        {
            if (_context.ScenarioInfo.Tags.Contains("roatpoutcome01"))
            {
                DeleteTrainingProvider();
            }
        }
    }
}
