namespace SFA.DAS.EPAO.UITests.Project.Helpers.SqlHelpers;

public class EPAOApplySqlDataHelper : SqlDbHelper
{
    public EPAOApplySqlDataHelper(DbConfig dbConfig) : base(dbConfig.AssessorDbConnectionString) { }

    public void DeleteCertificate(string uln)
    {
        ExecuteSqlCommand($"DELETE FROM [CertificateLogs] WHERE CertificateId IN (SELECT Id FROM [Certificates] WHERE ULN = '{uln}')");
        ExecuteSqlCommand($"DELETE FROM [Certificates] WHERE ULN = '{uln}'");
    }

    public void DeleteOrganisationStandardVersion()
    {
        ExecuteSqlCommand($"DELETE FROM [OrganisationStandardVersion] where OrganisationStandardId " +
            $"in(select Id from OrganisationStandard where StandardCode = 128 And EndPointAssessorOrganisationId = 'EPA0008') And Version in (1.1)");
    }

    public void ResetApplyUserOrganisationId(string applyUserEmail)
    {
        var organisationId = GetDataAsString($"SELECT OrganisationId from Contacts where Email = '{applyUserEmail}'");
        if (organisationId.Equals("")) return;
        ExecuteSqlCommand($"UPDATE Contacts SET OrganisationID = null WHERE Email = '{applyUserEmail}'");
        ExecuteSqlCommand($"DELETE from Apply where OrganisationId = '{organisationId}'");
    }

    public void DeleteAnyOtherOrganisationId(string applyUserEmail)
    {
        ExecuteSqlCommand($"DELETE from Contacts where OrganisationId = " +
            $"(select id from Organisations where EndPointAssessorOrganisationId = " +
            $"(select EndPointAssessorOrganisationId from Contacts where Email = '{applyUserEmail}') " +
            $"and Email != '{applyUserEmail}')");
    }

    public void ResetApplyUserEPAOId(string applyUserEmail) => ExecuteSqlCommand($"update Contacts set EndPointAssessorOrganisationId = null, [Status] = 'New' where Email = '{applyUserEmail}'");

    public void DeleteStandardApplicication(string standardcode, string organisationId, string userid) => ExecuteSqlCommand($"DELETE from [Apply] where OrganisationId = (select Id from Organisations WHERE EndPointAssessorOrganisationId = '{organisationId}') and CreatedBy = (select Id from Contacts where Email = '{userid}') and StandardCode = {standardcode}");

    public bool HasWithdrawals(string email)
    {
        var sqlQueryFromFile = Regex.Replace(FileHelper.GetSql("HasWithdrawals"), @"__email__", email);
        var data = GetData(sqlQueryFromFile, connectionString);

        return data.Any() && data.First() == "1"
                ? true
                : false;
    }

    public void ResetStandardWithdrawals(string email)
    {
        var sqlQueryFromFile = Regex.Replace(FileHelper.GetSql("ResetStandardWithdrawals"), @"__email__", email);
        ExecuteSqlCommand(sqlQueryFromFile, connectionString);
    }

    public void ResetRegisterWithdrawals(string email)
    {
        var sqlQueryFromFile = Regex.Replace(FileHelper.GetSql("ResetRegisterWithdrawals"), @"__email__", email);
        ExecuteSqlCommand(sqlQueryFromFile, connectionString);
    }
}