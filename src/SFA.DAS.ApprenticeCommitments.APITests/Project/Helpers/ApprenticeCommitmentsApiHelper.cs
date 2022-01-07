using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers
{
    public class ApprenticeCommitmentsApiHelper : Outer_ApprenticeCommitmentsApiHelper
    {
        public ApprenticeCommitmentsApiHelper(ScenarioContext context) : base(context) { }

        // This call can be used in TEST and TEST2 but can't be used in PP.
        public void CreateApprenticeshipViaCommitmentsJobApiRequest()
        {
            _assertHelper.RetryOnNUnitException(() => 
            {
                base.CreateApprenticeshipViaCommitmentsJob();
            });
        }

        public new void CreateApprenticeshipViaApi()
        {
            _assertHelper.RetryOnNUnitException(() =>
            {
                base.CreateApprenticeshipViaApi();
            });
        }
    }
}