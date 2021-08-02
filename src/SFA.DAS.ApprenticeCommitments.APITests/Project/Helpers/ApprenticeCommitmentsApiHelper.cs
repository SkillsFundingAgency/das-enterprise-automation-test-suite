using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers
{
    public class ApprenticeCommitmentsApiHelper : Outer_ApprenticeCommitmentsApiHelper
    {
        public ApprenticeCommitmentsApiHelper(ScenarioContext context) : base(context) { }

        public new void CreateApprenticeshipViaCommitmentsJob()
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