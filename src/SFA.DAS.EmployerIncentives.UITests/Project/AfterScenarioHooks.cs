using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project
{
    [Binding]
    public class AfterScenarioHooks(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        [AfterScenario(Order = 44)]
        public void AddIncentiveApplication()
        {
            if (context.ScenarioInfo.Tags.Contains("addincentiveapplication"))
            {
                var accountId = _objectContext.GetDBAccountId();

                var orgName = _objectContext.GetOrganisationName();

                var accountLegalEntityId = context.Get<RegistrationSqlDataHelper>().GetAccountLegalEntityId(accountId, orgName);

                var (apprenticeshipid, dob, fname, lname, startDate, trainningName, uln, ukprn) = context.Get<CommitmentsSqlDataHelper>().GetDataFromComtDb(accountId);

                var data = new AddApplicationData
                {
                    AccountId = accountId,
                    AccountLegalEntityId = accountLegalEntityId,
                    SubmittedByEmail = _objectContext.GetRegisteredEmail(),
                    SubmittedByName = orgName,
                    ApprenticeshipId = apprenticeshipid,
                    Dob = dob,
                    FirstName = fname,
                    LastName = lname,
                    StartDate = startDate,
                    TrainingName = trainningName,
                    Ukprn = ukprn,
                    Uln = uln
                };

                context.Get<EISqlHelper>().AddIncentiveApplication(data);
            }
        }
    }
}
