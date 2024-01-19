using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers
{
    public class ApprenticeCommitmentsApiHelper(ScenarioContext context) : Outer_ApprenticeCommitmentsApiHelper(context)
    {

        // This call can be used in TEST and TEST2 but can't be used in PP.
        public void CreateApprenticeshipViaCommitmentsJobApiRequest()
        {
            _assertHelper.RetryOnNUnitException(() =>
            {
                base.CreateApprenticeshipViaCommitmentsJob();
            });
        }

        public new void CreateApprovalsCreatedEvent()
        {
            _assertHelper.RetryOnNUnitException(() =>
            {
                base.CreateApprovalsCreatedEvent();
            });
        }
    }
}