using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using System;
using System.Linq;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class CohortReferenceHelper
    {
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;

        public CohortReferenceHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
        }

        public void SetCohortReference(string cohortReference) => _objectContext.SetCohortReference(cohortReference);

        public void UpdateCohortReference(string cohortReference) => _objectContext.UpdateCohortReference(cohortReference);

        public void UpdateNewCohortReference()
        {
            string ULN = Convert.ToString(_dataHelper.Ulns.First());

            var cohortRef = _commitmentsSqlDataHelper.GetNewcohortReference(ULN, _context.ScenarioInfo.Title);

            UpdateCohortReference(cohortRef);
        }


    }
}