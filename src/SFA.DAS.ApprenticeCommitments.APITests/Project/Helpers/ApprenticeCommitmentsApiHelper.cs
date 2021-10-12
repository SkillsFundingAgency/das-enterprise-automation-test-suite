using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers
{
    public class ApprenticeCommitmentsApiHelper : Outer_ApprenticeCommitmentsApiHelper
    {
        public ApprenticeCommitmentsApiHelper(ScenarioContext context) : base(context) { }

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