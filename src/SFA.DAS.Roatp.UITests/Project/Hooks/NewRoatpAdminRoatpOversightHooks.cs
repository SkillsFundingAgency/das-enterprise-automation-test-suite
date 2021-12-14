using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "roatpoutcome")]
    public class NewRoatpAdminRoatpOversightHooks : RoatpBaseHooks
    {
        private readonly string[] _tags;
        private readonly RoatpApplySqlDbHelper _roatpApplyClearDownDataHelpers;

        public NewRoatpAdminRoatpOversightHooks(ScenarioContext context) : base(context)
        {
            _tags = context.ScenarioInfo.Tags;
            _roatpApplyClearDownDataHelpers = new RoatpApplySqlDbHelper(_dbConfig);
        }

        [BeforeScenario(Order = 33)]
        public void OversightReviewClearDownFromApply() => _roatpApplyClearDownDataHelpers.OversightReviewClearDownFromApply(GetUkprn());

        [BeforeScenario(Order = 34)]
        public void ClearDownTrainingProviderFromRegister()
        {
            if (_tags.Contains("rpadoutcomeappeals01") ||
                (_tags.Contains("rpadgatewayfailappeals01")) ||
                (_tags.Contains("rpadoutcome01")))
            {
                DeleteTrainingProvider();
            }
        }
    } 
}
