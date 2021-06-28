namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Models
{
    public class PeriodDto
    {
        public byte Period { get; set; }
        public long? ApprenticeshipId { get; set; }
        public bool IsPayable { get; set; }
    }
}
