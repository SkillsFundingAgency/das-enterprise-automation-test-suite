using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using System;
using System.Security.AccessControl;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport
{
    public class FlexiPaymentsCommitmentsDataModel
    {
        public DateTime? PriceEpisodeFromDate;
        public DateTime? PriceEpisodeToDate_Date;
        public int ULNKey { get; set; }
        public Boolean IsPilot { get; set; }
        public string PriceEpisodeFromDateStr { set { PriceEpisodeFromDate = value == "Today" ? DateTime.Now : DataHelpers.TryParse(value); } }
        public string PriceEpisodeToDate{ set {PriceEpisodeToDate_Date = DataHelpers.TryParse(value); } }
        public decimal PriceEpisodeCost { get; set; }
    }
}
