using SFA.DAS.FlexiPayments.E2ETests.Tests.Helpers;
using System;

namespace SFA.DAS.FlexiPayments.E2ETests.Tests.TestSupport
{
    public class FlexiPaymentsCommitmentsDataModel
    {
        public string ULN { get; set; }
        public Boolean IsPilot { get; set; }
        public DateTime PriceEpisodeFromDate { get; set; }
        public decimal PriceEpisodeCost { get; set; }
    }
}
