using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RoatpAdmin.Service.Project;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class RoatpQnASqlDbHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.QnaDatabaseConnectionString)
    {
        private static string Emptyguid => Guid.Empty.ToString();

        public int ClearDownDataFromQna(string applicationId)
        {
            var deleteDataFromQnaQuery =
                $"DELETE FROM ApplicationSections WHERE applicationid = '{applicationId}'" +
                $"DELETE FROM ApplicationSequences WHERE applicationid = '{applicationId}' " +
                $"DELETE FROM Applications WHERE id = '{applicationId}' ;";

            return applicationId == Emptyguid ? 0 : ExecuteSqlCommand(deleteDataFromQnaQuery);
        }

        public int OversightReviewClearDownFromQnA_ReApplyRecord(string applicationId)
        {
            var deleteDataFromQnaQuery =
                $"DELETE FROM ApplicationSections WHERE ApplicationId = '{applicationId}'; " +
                $"DELETE FROM ApplicationSequences WHERE ApplicationId = '{applicationId}'; " +
                $"DELETE FROM Applications WHERE Id = '{applicationId}'; ";

            return applicationId == Emptyguid ? 0 : ExecuteSqlCommand(deleteDataFromQnaQuery);
        }
    }

    public class RoatpApplyAndQnASqlDbHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.ApplyDatabaseConnectionString)
    {
        private static string Emptyguid => Guid.Empty.ToString();

        public string GetApplicationId(string ukprn) => GetDataAsString($"Select applicationid from apply where ukprn = {ukprn} and ApplicationStatus = 'In Progress';");

        public string ClearDownDataUkprnFromApply(string ukprn)
        {
            var applicationIdQuery = $"SELECT ApplicationId from dbo.Apply where ukprn = {ukprn}";

            var queryResult = GetListOfData(applicationIdQuery);

            return queryResult == null || queryResult.Count == 0 ? Emptyguid : ClearDownFullDataFromApply(queryResult);
        }

        public string ClearDownDataFromApply()
        {
            var applicationIdQuery = $"SELECT ApplicationId from dbo.Apply a " +
                                           $"inner join Contacts c on a.OrganisationId = c.ApplyOrganisationID " +
                                           $"where c.Email ='{objectContext.GetEmail()}' ";

            var queryResult = GetListOfData(applicationIdQuery);

            return queryResult == null || queryResult.Count == 0 ? Emptyguid : ClearDownFullDataFromApply(queryResult);
        }



        public int AllowListProviders(string ukprn)
        {
            ukprn ??= objectContext.GetUkprn();

            var insertAllowListProviderQuery =
                $"IF NOT EXISTS(SELECT * FROM AllowedProviders WHERE [UKPRN] = {ukprn}) " +
                $"BEGIN " +
                $"INSERT INTO AllowedProviders([UKPRN]) VALUES({ukprn}) " +
                $"END";

            return ExecuteSqlCommand(insertAllowListProviderQuery);
        }


        private string ClearDownFullDataFromApply(List<object[]> queryResult)
        {
            var email = objectContext.GetEmail();

            var applicationId = queryResult[0][0].ToString();

            var query = $"DECLARE @OrganisationID UNIQUEIDENTIFIER; " +
                $"DELETE FROM Appeal WHERE ApplicationId = '{applicationId}'; " +
                $"DELETE FROM dbo.OversightReview where ApplicationId = '{applicationId}'; " +
                $"SELECT @OrganisationID = ApplyOrganisationId FROM dbo.Contacts WHERE Email = '{email}';" +
                $"DELETE FROM dbo.SubmittedApplicationAnswers WHERE ApplicationId = '{applicationId}'; " +
                $"DELETE FROM dbo.ExtractedApplications WHERE ApplicationId = '{applicationId}'; " +
                $"DELETE FROM dbo.Apply WHERE ApplicationId = '{applicationId}'; " +
                $"DELETE FROM dbo.AssessorPageReviewOutcome WHERE ApplicationId = '{applicationId}'; " +
                $"DELETE FROM dbo.FinancialReviewClarificationFile where ApplicationId = '{applicationId}'; " +
                $"DELETE FROM dbo.Financialreview where ApplicationId = '{applicationId}'; " +
                $"DELETE FROM dbo.FinancialData WHERE ApplicationId = '{applicationId}'; " +
                $"DELETE FROM dbo.Audit WHERE UpdatedState like '%{applicationId}%'; " +
                $"DELETE FROM dbo.GatewayAnswer WHERE ApplicationId = '{applicationId}'; " +
                $"DELETE FROM dbo.ModeratorPageReviewOutcome WHERE ApplicationId = '{applicationId}'; " +
                $"DELETE FROM dbo.AppealFile where ApplicationId ='{applicationId}'; " +
                $"UPDATE dbo.Contacts SET ApplyOrganisationID = NULL WHERE Email = '{email}';" +
                $"DELETE FROM dbo.OrganisationAddresses WHERE OrganisationId = @OrganisationID;" +
                $"DELETE FROM dbo.OrganisationManagement WHERE OrganisationId = @OrganisationID;" +
                $"DELETE FROM dbo.OrganisationPersonnel WHERE OrganisationId = @OrganisationID;" +
                $"DELETE FROM dbo.OrganisationSectorExpertDeliveredTrainingTypes WHERE OrganisationSectorExpertId IN (SELECT Id FROM dbo.OrganisationSectorExperts WHERE organisationSectorId IN (SELECT Id FROM dbo.OrganisationSectors WHERE OrganisationID = @OrganisationID));" +
                $"DELETE FROM dbo.OrganisationSectorExperts WHERE organisationSectorId IN (SELECT Id FROM dbo.OrganisationSectors WHERE OrganisationID = @organisationId);" +
                $"DELETE FROM dbo.OrganisationSectors WHERE OrganisationId = @OrganisationID;" +
                $"DELETE FROM dbo.Organisations WHERE Id = @OrganisationID;";

            ExecuteSqlCommand(query);

            return applicationId;
        }

        public int OversightReviewClearDownFromApply_ReapplyRecord(string applicationId) => applicationId == Emptyguid ? 0 : ExecuteSqlCommand($"DELETE FROM dbo.Apply WHERE ApplicationId = '{applicationId}'; ");
    }
}
