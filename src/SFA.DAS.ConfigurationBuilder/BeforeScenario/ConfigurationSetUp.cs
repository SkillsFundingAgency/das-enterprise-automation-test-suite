using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConfigurationBuilder
{
    [Binding]
    public class ConfigurationSetup
    {
        private readonly ScenarioContext _context;

        private readonly IConfigurationRoot _configurationRoot;

        private readonly IConfigSection _configSection;

        private readonly bool _isLocalhost;

        private DbDevConfig _dbDevConfig;

        public ConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configurationRoot = Configurator.GetConfig();
            _configSection = new ConfigSection(_configurationRoot);
            _isLocalhost = !Configurator.IsVstsExecution;
        }

        [BeforeScenario(Order = 1)]
        public void SetUpConfiguration()
        {
            _context.Set(_configSection);

             var dbConfig = _configSection.GetConfigSection<DbConfig>();
            
            if (_isLocalhost) dbConfig = GetLocalHostDbConfig();

            _context.Set(dbConfig);
        }

        private DbConfig GetLocalHostDbConfig()
        {
            _dbDevConfig = _configSection.GetConfigSection<DbDevConfig>();

            return new DbConfig
            {
                AccountsDbConnectionString = GetConnectionString(_dbDevConfig.AccountsDbName),
                CommitmentsDbConnectionString = GetConnectionString(_dbDevConfig.CommitmentsDbName),
                ApprenticeCommitmentDbConnectionString = GetConnectionString(_dbDevConfig.ApprenticeCommitmentDbName),
                ApprenticeCommitmentLoginDbConnectionString = GetConnectionString(_dbDevConfig.ApprenticeCommitmentLoginDbName),
                ApplyDatabaseConnectionString = GetConnectionString(_dbDevConfig.ApplyDatabaseName),
                LoginDatabaseConnectionString = GetConnectionString(_dbDevConfig.LoginDatabaseName),
                QnaDatabaseConnectionString = GetConnectionString(_dbDevConfig.QnaDatabaseName),
                RoatpDatabaseConnectionString = GetConnectionString(_dbDevConfig.RoatpDatabaseName),
                ProviderFeedbackDbConnectionString = GetConnectionString(_dbDevConfig.ProviderFeedbackDbName),
                AssessorDbConnectionString = GetConnectionString(_dbDevConfig.AssessorDbName)
            };
        }

        private string GetConnectionString(string dbName)
        {
             var connectionString = $"Server={_dbDevConfig.Server};Database={dbName};User ID={_dbDevConfig.UserID};Password={_dbDevConfig.Password};{_dbDevConfig.ConnectionDetails};";

            return Regex.Replace(connectionString, "{environmentname}", EnvironmentConfig.EnvironmentName.ToLower());
        }
    }
}