namespace SFA.DAS.ConfigurationBuilder
{
    public class DbConfig
    {
        public string AccountsDbConnectionString { get; set; }
        public string CommitmentsDbConnectionString { get; set; }
        public string ApprenticeCommitmentLoginDbConnectionString { get; set; }
        public string ApprenticeCommitmentDbConnectionString { get; set; }
        public string RoatpDatabaseConnectionString { get; set; }
        public string ApplyDatabaseConnectionString { get; set; }
        public string QnaDatabaseConnectionString { get; set; }
        public string LoginDatabaseConnectionString { get; set; }
        public string ProviderFeedbackDbConnectionString { get; set; }
        public string AssessorDbConnectionString { get; set; }
    }

    public class DbDevConfig
    {
        public string Server { get; set; }
        public string ConnectionDetails { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string AccountsDbName { get; set; }
        public string CommitmentsDbName { get; set; }
        public string ApprenticeCommitmentLoginDbName { get; set; }
        public string ApprenticeCommitmentDbName { get; set; }
        public string RoatpDatabaseName { get; set; }
        public string ApplyDatabaseName { get; set; }
        public string QnaDatabaseName { get; set; }
        public string LoginDatabaseName { get; set; }
        public string ProviderFeedbackDbName { get; set; }
        public string AssessorDbName { get; set; }
        public string EmployerIncentivesDbName { get; set; }
        public string PublicSectorReportingDbName { get; set; }
    }
}