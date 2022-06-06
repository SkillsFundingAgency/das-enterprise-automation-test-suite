using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project
{
    [Binding]
    public class AfterScenarioHooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public AfterScenarioHooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [AfterScenario(Order = 44)]
        public void AddIncentiveApplication()
        {
            if (_context.ScenarioInfo.Tags.Contains("addincentiveapplication"))
            {
                var accountId = _objectContext.GetDBAccountId();

                var orgName = _objectContext.GetOrganisationName();

                var accountLegalEntityId = _context.Get<RegistrationSqlDataHelper>().GetAccountLegalEntityId(accountId, orgName);

                var (apprenticeshipid, dob, fname, lname, startDate, trainningName, uln, ukprn) = _context.Get<CommitmentsSqlDataHelper>().GetDataFromComtDb(accountId);

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

                _context.Get<EISqlHelper>().AddIncentiveApplication(data);
            }
        }
    }
}
