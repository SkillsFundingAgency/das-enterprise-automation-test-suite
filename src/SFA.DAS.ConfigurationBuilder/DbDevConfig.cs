namespace SFA.DAS.ConfigurationBuilder
{
    public class DbDevConfig
    {
        public string Server { get; set; }
        public string ConnectionDetails { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string DatamartDbName { get; set; }
        public string AccountsDbName { get; set; }
        public string FinanceDbName { get; set; }
        public string FcastDbName { get; set; }
        public string CommitmentsDbName { get; set; }
        public string ApprenticeCommitmentLoginDbName { get; set; }
        public string ApprenticeCommitmentDbName { get; set; }
        public string ApprenticeCommitmentAccountsDbName { get; set; }
        public string RoatpDatabaseName { get; set; }
        public string ApplyDatabaseName { get; set; }
        public string QnaDatabaseName { get; set; }
        public string LoginDatabaseName { get; set; }
        public string EmployerFeedbackDbName { get; set; }
        public string ApprenticeFeedbackDbName { get; init; }
        public string AssessorDbName { get; set; }
        public string EmployerIncentivesDbName { get; set; }
        public string ReservationsDbName { get; set; }
        public string UsersDbName { get; set; }
        public string PublicSectorReportingDbName { get; set; }
        public string PermissionsDbName { get; set; }
        public string PregDbName { get; set; }
        public string TPRDbName { get; set; }
        public string TMDbName { get; set; }
        public string CrsDbName { get; set; }
        public string EmploymentCheckDbName { get; set; }
        public string ManagingStandardsDbName { get; set; }
        public string EarningsDbName { get; set; }
    }
}