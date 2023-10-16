using System;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EISqlHelper : SqlDbHelper
    {
        public EISqlHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.IncentivesDbConnectionString) { }

        public void AddIncentiveApplication(AddApplicationData data)
        {
            var query = $@"EXEC [support].[CreateRetrospectiveApplication]   
                        @accountId = {data.AccountId},    
                        @accountLegalEntityId = {data.AccountLegalEntityId},    
                        @submittedByEmail = '{data.SubmittedByEmail}',    
                        @submittedByName = '{data.SubmittedByName}',    
                        @apprenticeshipId = {data.ApprenticeshipId},    
                        @firstName = '{data.FirstName}',    
                        @LastName = '{data.LastName}',    
                        @dateOfBirth = '{data.Dob}',    
                        @uln = {data.Uln},    
                        @plannedStartDate = '{data.StartDate}',    
                        @apprenticeshipEmployerTypeOnApproval = 1,    
                        @ukprn = {data.Ukprn},    
                        @courseName = '{data.TrainingName}',    
                        @phase = 'Phase3'";

            ExecuteSqlCommand(query);
        }

        public void ResetVrfDetails(string accountId) => ExecuteSqlCommand($"update [dbo].[Accounts] set VRFVendorid= NULL , VRFCaseID= NULL, VRFCaseStatus=NULL, VrfCaseStatusLastUpdatedDateTime= NULL where id = {accountId}");

        public void ResetPeriodEndInProgress() => ExecuteSqlCommand("UPDATE incentives.CollectionCalendar SET PeriodEndInProgress = 0");

        public int FetchAccountId(string email) => Convert.ToInt32(GetListOfData($"SELECT AccountId FROM [dbo].[IncentiveApplication] WHERE SubmittedByEmail = '{email}'")[0][0]);
    }
}
