using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class AfterScenarioHooks
    {
        private readonly ObjectContext _objectcontext;
        private readonly ApprenticeDataHelper _datahelper;

        public AfterScenarioHooks(ScenarioContext context)
        {
            _objectcontext = context.Get<ObjectContext>();
            _datahelper = context.Get<ApprenticeDataHelper>();
        }

        [AfterScenario(Order = 9)]
        public void AddUln()
        {
            _datahelper?.Ulns.ForEach((x) => _objectcontext.SetUln(x));
        }
    }
}
