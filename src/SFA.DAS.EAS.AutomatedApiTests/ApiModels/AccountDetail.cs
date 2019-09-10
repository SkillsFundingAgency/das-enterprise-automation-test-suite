using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.EAS.AutomatedApiTests.ApiModels
{
    public class AccountDetail
    {
        public long AccountId { get; set; }
        public string HashedAccountId { get; set; }
        public string PublicHashedAccountId { get; set; }
        public string DasAccountName { get; set; }
        public DateTime DateRegistered { get; set; }
        public string OwnerEmail { get; set; }
        public ResourceList LegalEntities { get; set; }
        public ResourceList PayeSchemes { get; set; }
        
        public AccountAgreementType AccountAgreementType { get; set; }
        public string ApprenticeshipEmployerType { get; set; }
    }

    public enum AccountAgreementType
    {
        Levy = 0,
        NonLevyExpressionOfInterest = 1,
        Inconsistent = 2,
        Unknown
    }
}
