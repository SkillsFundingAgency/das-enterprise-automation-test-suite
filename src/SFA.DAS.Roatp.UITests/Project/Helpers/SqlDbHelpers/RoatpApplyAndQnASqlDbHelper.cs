using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class RoatpApplyAndQnASqlDbHelper : SqlDbHelper
    {
        private readonly ObjectContext _objectContext;
        private readonly string _qnaDatabaseConnectionString;

        private string Emptyguid => Guid.Empty.ToString();

        public RoatpApplyAndQnASqlDbHelper(ObjectContext objectContext, RoatpConfig roatpConfig) : base(roatpConfig.ApplyDatabaseConnectionString)
        {
            _objectContext = objectContext;
            _qnaDatabaseConnectionString = roatpConfig.QnaDatabaseConnectionString;
        }

        public string ClearDownDataUkprnFromApply(string ukprn)
        {
            var applicationIdQuery = $"SELECT ApplicationId from dbo.Apply where ukprn = {ukprn}";

            var queryResult = SqlDatabaseConnectionHelper.ReadDataFromDataBase(applicationIdQuery, connectionString);

            return queryResult == null || queryResult.Count == 0 ? Emptyguid : ClearDownFullDataFromApply(queryResult);
        }

        public string ClearDownDataFromApply()
        {
            var applicationIdQuery = $"SELECT ApplicationId from dbo.Apply a " +
                                           $"inner join Contacts c on a.OrganisationId = c.ApplyOrganisationID " +
                                           $"where c.Email ='{_objectContext.GetEmail()}' ";

            var queryResult = SqlDatabaseConnectionHelper.ReadDataFromDataBase(applicationIdQuery, connectionString);

            return queryResult == null || queryResult.Count == 0 ? Emptyguid : ClearDownFullDataFromApply(queryResult);
        }

        public int ClearDownDataFromQna(string applicationId)
        {
            var deleteDataFromQnaQuery =
                $"DELETE FROM ApplicationSections WHERE applicationid = '{applicationId}'" +
                $"DELETE FROM ApplicationSequences WHERE applicationid = '{applicationId}' " +
                $"DELETE FROM Applications WHERE id = '{applicationId}' ;";

            return applicationId == Emptyguid ? 0 : SqlDatabaseConnectionHelper.ExecuteSqlCommand(deleteDataFromQnaQuery, _qnaDatabaseConnectionString);
        }

        public int WhiteListProviders(string ukprn)
        {
            ukprn ??= _objectContext.GetUkprn();

            var insertWhiteListProviderQuery =
                $"IF NOT EXISTS(SELECT * FROM WhitelistedProviders WHERE [UKPRN] = {ukprn}) " +
                $"BEGIN " +
                $"INSERT INTO WhitelistedProviders([UKPRN]) VALUES({ukprn}) " +
                $"END";

            return ExecuteSqlCommand(insertWhiteListProviderQuery);
        }


        private string ClearDownFullDataFromApply(List<object[]> queryResult)
        {
            var email = _objectContext.GetEmail();

            var applicationId = queryResult[0][0].ToString();

            var query = $"DECLARE @OrganisationID UNIQUEIDENTIFIER; " +
                $"SELECT @OrganisationID = ApplyOrganisationId FROM dbo.Contacts WHERE Email = '{email}';" +
                $"DELETE FROM dbo.Apply WHERE ApplicationId = '{applicationId}'; " +
                $"DELETE FROM dbo.AssessorPageReviewOutcome WHERE ApplicationId = '{applicationId}'; " +
                $"DELETE FROM dbo.FinancialData WHERE ApplicationId = '{applicationId}'; " +
                $"DELETE FROM dbo.Audit WHERE UpdatedState like '%{applicationId}%'; " +
                $"DELETE FROM dbo.GatewayAnswer WHERE ApplicationId = '{applicationId}'; " +
                $"DELETE FROM dbo.ModeratorPageReviewOutcome WHERE ApplicationId = '{applicationId}'; " +
                $"DELETE FROM dbo.OversightReview WHERE ApplicationId = '{applicationId}'; " +
                $"UPDATE dbo.Contacts SET ApplyOrganisationID = NULL WHERE Email = '{email}';" +
                $"DELETE FROM dbo.Organisations WHERE Id = @OrganisationID;";

            ExecuteSqlCommand(query);

            return applicationId;
        }
    }
}
