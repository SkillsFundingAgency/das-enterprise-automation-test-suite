using System.Text.RegularExpressions;

namespace SFA.DAS.ConfigurationBuilder
{
    public class LocalHostDbConfig
    {
        private readonly DbDevConfig _dbDevConfig;

        private readonly bool _useSqlLogin;

        public LocalHostDbConfig(DbDevConfig dbDevConfig, bool useSqlLogin)
        {
            _useSqlLogin = useSqlLogin;
            
            _dbDevConfig = dbDevConfig;
        }

        internal DbConfig GetLocalHostDbConfig()
        {
            return new DbConfig
            {
                AccountsDbConnectionString = GetConnectionString(_dbDevConfig.AccountsDbName),
                FinanceDbConnectionString = GetConnectionString(_dbDevConfig.FinanceDbName),
                FcastDbConnectionString = GetConnectionString(_dbDevConfig.FcastDbName),
                CommitmentsDbConnectionString = GetConnectionString(_dbDevConfig.CommitmentsDbName),
                ApprenticeCommitmentDbConnectionString = GetConnectionString(_dbDevConfig.ApprenticeCommitmentDbName),
                ApprenticeCommitmentLoginDbConnectionString = GetConnectionString(_dbDevConfig.ApprenticeCommitmentLoginDbName),
                ApplyDatabaseConnectionString = GetConnectionString(_dbDevConfig.ApplyDatabaseName),
                LoginDatabaseConnectionString = GetConnectionString(_dbDevConfig.LoginDatabaseName),
                QnaDatabaseConnectionString = GetConnectionString(_dbDevConfig.QnaDatabaseName),
                RoatpDatabaseConnectionString = GetConnectionString(_dbDevConfig.RoatpDatabaseName),
                ProviderFeedbackDbConnectionString = GetConnectionString(_dbDevConfig.ProviderFeedbackDbName),
                AssessorDbConnectionString = GetConnectionString(_dbDevConfig.AssessorDbName),
                IncentivesDbConnectionString = GetConnectionString(_dbDevConfig.EmployerIncentivesDbName),
                ReservationsDbConnectionString = GetConnectionString(_dbDevConfig.ReservationsDbName),
                PermissionsDbConnectionString = GetConnectionString(_dbDevConfig.PermissionsDbName),
                PublicSectorReportingConnectionString = GetConnectionString(_dbDevConfig.PublicSectorReportingDbName),
                PregDbConnectionString = GetConnectionString(_dbDevConfig.PregDbName),
                TPRDbConnectionString = GetConnectionString(_dbDevConfig.TPRDbName),
                UsersDbConnectionString = GetConnectionString(_dbDevConfig.UsersDbName),
                TMDbConnectionString = GetConnectionString(_dbDevConfig.TMDbName),
                CRSDbConnectionString = GetConnectionString(_dbDevConfig.CrsDbName),
                EmploymentCheckDbConnectionString = GetConnectionString(_dbDevConfig.EmploymentCheckDbName)
            };
        }

        private string GetConnectionString(string dbName)
        {
           var x = _useSqlLogin ? $"Server={_dbDevConfig.Server};Database={dbName};{_dbDevConfig.ConnectionDetails};" : $"Server={_dbDevConfig.Server};Initial Catalog={dbName};{_dbDevConfig.ConnectionDetails};";

            return Regex.Replace(x, "{environmentname}", EnvironmentConfig.EnvironmentName.ToLower());
        }
    }
}