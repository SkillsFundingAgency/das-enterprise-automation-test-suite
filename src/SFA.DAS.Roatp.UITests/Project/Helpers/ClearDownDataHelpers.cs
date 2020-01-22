using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class ClearDownDataHelpers
    {
        private readonly SqlDatabaseConnectionHelper _sqlDatabase;
        public readonly string _roatpDatabaseConnectionString;
        public readonly string _applyDatabaseConnectionString;
        public readonly string _qnaDatabaseConnectionString;

        public ClearDownDataHelpers(RoatpConfig roatpConfig, SqlDatabaseConnectionHelper sqlDatabase)
        {
            _sqlDatabase = sqlDatabase;
            _roatpDatabaseConnectionString = roatpConfig.RoatpDatabaseConnectionString;
            _applyDatabaseConnectionString = roatpConfig.ApplyDatabaseConnectionString;
            _qnaDatabaseConnectionString = roatpConfig.QnaDatabaseConnectionString;
        }

        public void DeleteTrainingProvider(String ukprn)
        {
            String DeleteProviderQuery = $"DELETE FROM Organisations WHERE UKPRN ='{ukprn}'";
            _sqlDatabase.ExecuteSqlCommand(DeleteProviderQuery, _roatpDatabaseConnectionString);
        }
        public string ClearDownDataFromApply(String email)
        {
            String GetApplicationIdQuery = $"SELECT ApplicationId from dbo.Apply a " +
                                           $"inner join Contacts c on a.OrganisationId = c.ApplyOrganisationID " +
                                           $"where c.Email ='{email}' ";

            var queryResult = _sqlDatabase.ReadDataFromDataBase(GetApplicationIdQuery, _applyDatabaseConnectionString);

            if (queryResult == null || queryResult.Count == 0)
            {
                return Guid.Empty.ToString();
            }

            String applicationId = queryResult[0][0].ToString();

            String DeleteDataFromApplyQuery = $"DECLARE @OrganisationID UNIQUEIDENTIFIER; DECLARE @Email VARCHAR(256) ; SET @Email = '{email}'	;" +
                $"SELECT @OrganisationID = ApplyOrganisationId FROM dbo.Contacts WHERE Email = @Email ;" +
                $"DELETE FROM dbo.Apply WHERE ApplicationId = '{applicationId}' ;" +
                $"UPDATE dbo.Contacts SET ApplyOrganisationID = NULL WHERE Email = @Email ;" +
                $"DELETE FROM dbo.Organisations WHERE Id = @OrganisationID ;";
            _sqlDatabase.ExecuteSqlCommand(DeleteDataFromApplyQuery, _applyDatabaseConnectionString);

            return applicationId;
        }
        public void ClearDownDataFromQna(string applicationId)
        {
            String DeleteDataFromQnaQuery =
                $"DELETE FROM ApplicationSections WHERE applicationid = '{applicationId}'" +
                $"DELETE FROM ApplicationSequences WHERE applicationid = '{applicationId}' " +
                $"DELETE FROM Applications WHERE id = '{applicationId}' ;";

            _sqlDatabase.ExecuteSqlCommand(DeleteDataFromQnaQuery, _qnaDatabaseConnectionString);
        }
    }
}
