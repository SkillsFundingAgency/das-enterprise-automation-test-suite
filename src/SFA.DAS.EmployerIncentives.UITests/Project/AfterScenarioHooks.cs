using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.TestDataExport.Helper;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project
{
    [Binding]
    public class AfterScenarioHooks(ScenarioContext context)
    {
        [AfterScenario(Order = 44)]
        public void AddIncentiveApplication()
        {
            if (!context.ScenarioInfo.Tags.Contains("addincentiveapplication")) return;

            context.Get<TryCatchExceptionHelper>().AfterScenarioException(() => 
            {
                var objectContext = context.Get<ObjectContext>();

                var accountId = objectContext.GetDBAccountId();

                var orgName = objectContext.GetOrganisationName();

                var accountLegalEntityId = context.Get<RegistrationSqlDataHelper>().GetAccountLegalEntityId(accountId, orgName);

                var (apprenticeshipid, dob, fname, lname, startDate, trainningName, uln, ukprn) = context.Get<CommitmentsSqlDataHelper>().GetDataFromComtDb(accountId);

                var data = new AddApplicationData
                {
                    AccountId = accountId,
                    AccountLegalEntityId = accountLegalEntityId,
                    SubmittedByEmail = objectContext.GetRegisteredEmail(),
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
            });
        }
    }
}
