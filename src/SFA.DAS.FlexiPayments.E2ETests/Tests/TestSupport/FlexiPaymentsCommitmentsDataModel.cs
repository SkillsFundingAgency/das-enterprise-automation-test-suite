using SFA.DAS.FlexiPayments.E2ETests.Tests.Helpers;
using System;
using System.Security.AccessControl;

namespace SFA.DAS.FlexiPayments.E2ETests.Tests.TestSupport
{
    public class FlexiPaymentsCommitmentsDataModel
    {
        public DateTime? PriceEpisodeToDate_Date;
        public string ULN { get; set; }
        public Boolean IsPilot { get; set; }
        public DateTime PriceEpisodeFromDate { get; set; }
        public string PriceEpisodeToDate{ set {PriceEpisodeToDate_Date = DateHelpers.TryParse(value); } }
        public decimal PriceEpisodeCost { get; set; }
    }
}
