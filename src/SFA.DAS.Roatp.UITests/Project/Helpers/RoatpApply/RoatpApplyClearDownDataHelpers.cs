using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply
{
    public class RoatpApplyClearDownDataHelpers
    {
        private readonly ObjectContext _objectContext;
        private readonly string _applyDatabaseConnectionString;
        private readonly string _qnaDatabaseConnectionString;

        private string Emptyguid => Guid.Empty.ToString();

        public RoatpApplyClearDownDataHelpers(ObjectContext objectContext, RoatpConfig roatpConfig)
        {
            _objectContext = objectContext;
            _applyDatabaseConnectionString = roatpConfig.ApplyDatabaseConnectionString;
            _qnaDatabaseConnectionString = roatpConfig.QnaDatabaseConnectionString;
        }

        public string ClearDownDataFromApply()
        {
            var applicationIdQuery = $"SELECT ApplicationId from dbo.Apply a " +
                                           $"inner join Contacts c on a.OrganisationId = c.ApplyOrganisationID " +
                                           $"where c.Email ='{_objectContext.GetEmail()}' ";

            var queryResult = SqlDatabaseConnectionHelper.ReadDataFromDataBase(applicationIdQuery, _applyDatabaseConnectionString);

            return queryResult == null || queryResult.Count == 0 ? Emptyguid : ClearDownDataFromApply(queryResult);
        }

        public int ClearDownDataFromQna(string applicationId)
        {
            var DeleteDataFromQnaQuery =
                $"DELETE FROM ApplicationSections WHERE applicationid = '{applicationId}'" +
                $"DELETE FROM ApplicationSequences WHERE applicationid = '{applicationId}' " +
                $"DELETE FROM Applications WHERE id = '{applicationId}' ;";

            return applicationId == Emptyguid ? 0 : SqlDatabaseConnectionHelper.ExecuteSqlCommand(_qnaDatabaseConnectionString, DeleteDataFromQnaQuery);
        }

        public int WhiteListProviders()
        {
            var insertWhiteListProviderQuery = 
                $"IF NOT EXISTS(SELECT * FROM WhitelistedProviders WHERE [UKPRN] = {_objectContext.GetUkprn()}) " +
                $"BEGIN " +
                $"INSERT INTO WhitelistedProviders([UKPRN]) VALUES({_objectContext.GetUkprn()}) " +
                $"END";

            return SqlDatabaseConnectionHelper.ExecuteSqlCommand(_applyDatabaseConnectionString, insertWhiteListProviderQuery);
        }

        private string ClearDownDataFromApply(List<object[]> queryResult)
        {
            var email = _objectContext.GetEmail();

            var applicationId = queryResult[0][0].ToString();

            var query = $"DECLARE @OrganisationID UNIQUEIDENTIFIER; " +
                $"SELECT @OrganisationID = ApplyOrganisationId FROM dbo.Contacts WHERE Email = '{email}';" +
                $"DELETE FROM dbo.Apply WHERE ApplicationId = '{applicationId}'; " +
                $"UPDATE dbo.Contacts SET ApplyOrganisationID = NULL WHERE Email = '{email}';" +
                $"DELETE FROM dbo.Organisations WHERE Id = @OrganisationID;";

            SqlDatabaseConnectionHelper.ExecuteSqlCommand(_applyDatabaseConnectionString, query);

            return applicationId;
        }


    }
}
