using System.Collections;
using System.Collections.Generic;

namespace SFA.DAS.EmployerFinance.APITests.Project.Helpers
{
    public class TransactionSummary
    {
        public int Year { get; set; }
        public int Month { get; set; }
    }

    public class LevyDeclaration
    {
        public string PayrollYear { get; set; }
        public short? PayrollMonth { get; set; }
    }

    public class ProviderSummary
    {
        public ICollection<Provider> Providers { get; set; }
    }

    public class Provider
    {
        public string Ukprn { get; set; }
        public string Name { get; set; }
        public string ContactUrl { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}