namespace SFA.DAS.EAS.AutomatedApiTests.ApiModels
{
    public class AccountWithBalanceViewModel
    {
        public string AccountName { get; set; }
        public string AccountHashId { get; set; }
        public string PublicAccountHashId { get; set; }
        public long AccountId { get; set; }
        public decimal Balance { get; set; }
        public decimal RemainingTransferAllowance { get; set; }
        public decimal StartingTransferAllowance { get; set; }
        public string Href { get; set; }
        public bool IsLevyPayer { get; set; }
    }
}
