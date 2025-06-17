using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class CohortReferenceHelper
    {
        private readonly ObjectContext _objectContext;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;

        public CohortReferenceHelper(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(_objectContext, context.Get<DbConfig>());
        }

        public void SetCohortReference(string cohortReference) => _objectContext.SetCohortReference(cohortReference);

        public void UpdateCohortReference(string cohortReference) => _objectContext.UpdateCohortReference(cohortReference);

        public void UpdateCohortReference()
        {
            string ULN = Convert.ToString(_dataHelper.ApprenticeULN);

            var cohortRef = _commitmentsSqlDataHelper.GetNewcohortReference(ULN);

            UpdateCohortReference(cohortRef);
        }
    }
}