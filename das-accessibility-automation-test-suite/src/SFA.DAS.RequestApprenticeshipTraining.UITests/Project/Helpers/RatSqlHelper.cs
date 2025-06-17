namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Helpers;

public class RatSqlHelper(ObjectContext objectContext, DbConfig config) : SqlDbHelper(objectContext, config.RatDbConnectionString)
{
    public void ClearDownRatData(string accountid, string requestId)
    {
        //--List of the ProviderResponseIds that can be deleted as they are responses *only * to the specified account
        //--Delete from ProviderResponseEmployerRequest* all*responses for the given account
        //-- Delete from EmployerRequestRegion
        //--Delete the ProviderResponses that are *only * linked to the specified AccountId
        //--Delete the EmployerRequest records
        var query = @$"DECLARE @AccountId INT = {accountid}; DECLARE @EmpRequestId UNIQUEIDENTIFIER = '{requestId}';
                    DECLARE @ProviderResponseIds TABLE(Id UNIQUEIDENTIFIER);
                                        
                    INSERT INTO @ProviderResponseIds(Id)
                    SELECT pr.Id
                    FROM ProviderResponse pr
                    INNER JOIN ProviderResponseEmployerRequest prer ON pr.Id = prer.ProviderResponseId
                    INNER JOIN EmployerRequest er ON prer.EmployerRequestId = er.Id
                    WHERE er.id = @EmpRequestId;
                                        
                    DELETE FROM ProviderResponseEmployerRequest WHERE EmployerRequestId = @EmpRequestId;
                    
                    DELETE FROM EmployerRequestRegion WHERE EmployerRequestId = @EmpRequestId;
                                       
                    DELETE FROM ProviderResponse
                    WHERE Id IN(SELECT Id FROM @ProviderResponseIds);
                                        
                    DELETE FROM EmployerRequest
                    WHERE AccountId = @AccountId
                    AND id = @EmpRequestId;";

        ExecuteSqlCommand(query);
    }
}
