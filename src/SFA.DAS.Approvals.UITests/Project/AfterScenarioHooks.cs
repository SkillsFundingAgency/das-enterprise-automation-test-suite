using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class AfterScenarioHooks
    {
        private readonly ObjectContext _objectcontext;
        private readonly ApprenticeDataHelper _datahelper;
        private readonly TryCatchException _tryCatch;

        public AfterScenarioHooks(ScenarioContext context)
        {
            _tryCatch = context.Get<TryCatchException>();
            _objectcontext = context.Get<ObjectContext>();
            _datahelper = context.Get<ApprenticeDataHelper>();
        }

        [AfterScenario(Order = 10)]
        public void AddUln() => _tryCatch.AfterScenarioException(() => _datahelper?.Ulns.ForEach((x) => _objectcontext.SetUln(x)));
    }
}
