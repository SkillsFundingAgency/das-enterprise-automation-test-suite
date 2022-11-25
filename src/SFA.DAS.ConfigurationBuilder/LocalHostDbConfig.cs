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
                DatamartDbConnectionString = GetConnectionString(_dbDevConfig.DatamartDbName),
                AccountsDbConnectionString = GetConnectionString(_dbDevConfig.AccountsDbName),
                FinanceDbConnectionString = GetConnectionString(_dbDevConfig.FinanceDbName),
                FcastDbConnectionString = GetConnectionString(_dbDevConfig.FcastDbName),
                CommitmentsDbConnectionString = GetConnectionString(_dbDevConfig.CommitmentsDbName),
                ApprenticeCommitmentDbConnectionString = GetConnectionString(_dbDevConfig.ApprenticeCommitmentDbName),
                ApprenticeCommitmentLoginDbConnectionString = GetConnectionString(_dbDevConfig.ApprenticeCommitmentLoginDbName),
                ApprenticeCommitmentAccountsDbConnectionString = GetConnectionString(_dbDevConfig.ApprenticeCommitmentAccountsDbName),
                ApplyDatabaseConnectionString = GetConnectionString(_dbDevConfig.ApplyDatabaseName),
                LoginDatabaseConnectionString = GetConnectionString(_dbDevConfig.LoginDatabaseName),
                QnaDatabaseConnectionString = GetConnectionString(_dbDevConfig.QnaDatabaseName),
                RoatpDatabaseConnectionString = GetConnectionString(_dbDevConfig.RoatpDatabaseName),
                EmployerFeedbackDbConnectionString = GetConnectionString(_dbDevConfig.EmployerFeedbackDbName),
                ApprenticeFeedbackDbConnectionString = GetConnectionString(_dbDevConfig.ApprenticeFeedbackDbName),  
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
                EmploymentCheckDbConnectionString = GetConnectionString(_dbDevConfig.EmploymentCheckDbName),
                ManagingStandardsDbConnectionString = GetConnectionString(_dbDevConfig.ManagingStandardsDbName),
                EarningsDbConnectionString = GetConnectionString(_dbDevConfig.EarningsDbName)
            };
        }

        private string GetConnectionString(string dbName)
        {
            string GetDbName() => _useSqlLogin ? "Database" : "Initial Catalog";

            var x = $"Server={_dbDevConfig.Server};{GetDbName()}={dbName};{_dbDevConfig.ConnectionDetails};";

            return EnvironmentConfig.ReplaceEnvironmentName(x);
        }
    }
}