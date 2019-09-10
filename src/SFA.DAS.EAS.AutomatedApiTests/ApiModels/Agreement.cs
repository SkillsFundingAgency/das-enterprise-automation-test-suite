using System;

namespace SFA.DAS.EAS.AutomatedApiTests.ApiModels
{
    public class Agreement
    {
        public long Id { get; set; }
        public DateTime? SignedDate { get; set; }
        public string SignedByName { get; set; }
        public EmployerAgreementStatus Status { get; set; }
        public int TemplateVersionNumber { get; set; }
        public AgreementType AgreementType { get; set; }
    }

    public enum AgreementType : byte
    {
        Levy = 0,
        NoneLevyExpressionOfInterest = 1
    }

    public enum EmployerAgreementStatus : byte
    {
        Pending = 1,
        Signed = 2,
        Expired = 3,
        Superseded = 4,
        Removed = 5
    }
}
