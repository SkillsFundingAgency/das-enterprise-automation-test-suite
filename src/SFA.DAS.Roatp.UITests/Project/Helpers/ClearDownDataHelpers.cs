using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class ClearDownDataHelpers
    {
        private readonly ObjectContext _objectContext;
        private readonly SqlDatabaseConnectionHelper _sqlDatabasehelper;
        private readonly string _roatpDatabaseConnectionString;
        private readonly string _applyDatabaseConnectionString;
        private readonly string _qnaDatabaseConnectionString;
        
        private string Emptyguid => Guid.Empty.ToString();

        public ClearDownDataHelpers(ObjectContext objectContext, RoatpConfig roatpConfig, SqlDatabaseConnectionHelper sqlDatabasehelper)
        {
            _objectContext = objectContext;
            _sqlDatabasehelper = sqlDatabasehelper;
            _roatpDatabaseConnectionString = roatpConfig.RoatpDatabaseConnectionString;
            _applyDatabaseConnectionString = roatpConfig.ApplyDatabaseConnectionString;
            _qnaDatabaseConnectionString = roatpConfig.QnaDatabaseConnectionString;
        }

        public void DeleteTrainingProvider()
        {
            var DeleteProviderQuery = $"DELETE FROM Organisations WHERE UKPRN ='{_objectContext.GetUkprn()}'";
            _sqlDatabasehelper.ExecuteSqlCommand(_roatpDatabaseConnectionString, DeleteProviderQuery);
        }

        public string ClearDownDataFromApply()
        {
            var applicationIdQuery = $"SELECT ApplicationId from dbo.Apply a " +
                                           $"inner join Contacts c on a.OrganisationId = c.ApplyOrganisationID " +
                                           $"where c.Email ='{_objectContext.GetEmail()}' ";

            var queryResult = _sqlDatabasehelper.ReadDataFromDataBase(applicationIdQuery, _applyDatabaseConnectionString);

            return (queryResult == null || queryResult.Count == 0) ? Emptyguid : ClearDownDataFromApply(queryResult);
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

            _sqlDatabasehelper.ExecuteSqlCommand(_applyDatabaseConnectionString, query);

            return applicationId;
        }

        public int ClearDownDataFromQna(string applicationId)
        {
            var DeleteDataFromQnaQuery =
                $"DELETE FROM ApplicationSections WHERE applicationid = '{applicationId}'" +
                $"DELETE FROM ApplicationSequences WHERE applicationid = '{applicationId}' " +
                $"DELETE FROM Applications WHERE id = '{applicationId}' ;";

            return applicationId == Emptyguid ? 0 : _sqlDatabasehelper.ExecuteSqlCommand(_qnaDatabaseConnectionString, DeleteDataFromQnaQuery);
        }
    }
}
