using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using System;
using System.Security.AccessControl;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport
{
    public class FlexiPaymentsCommitmentsDataModel
    {
        public DateTime? PriceEpisodeToDate_Date;
        public int ULNKey { get; set; }
        public Boolean IsPilot { get; set; }
        public DateTime PriceEpisodeFromDate { get; set; }
        public string PriceEpisodeToDate{ set {PriceEpisodeToDate_Date = DataHelpers.TryParse(value); } }
        public decimal PriceEpisodeCost { get; set; }
    }
}
