using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers
{
    public class ApprenticeCommitmentsApiHelper : Outer_ApprenticeCommitmentsApiHelper
    {
        public ApprenticeCommitmentsApiHelper(ScenarioContext context) : base(context) { }

        public new void CreateApprenticeship()
        {
            _assertHelper.RetryOnNUnitException(() => 
            {
                base.CreateApprenticeship();

                AssertResponse(HttpStatusCode.Accepted);
            });
        }
    }
}