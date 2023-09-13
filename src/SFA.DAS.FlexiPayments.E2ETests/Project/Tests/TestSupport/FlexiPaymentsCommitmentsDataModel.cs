using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using System;
using System.Security.AccessControl;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport
{
    public class FlexiPaymentsCommitmentsDataModel
    {
        public DateTime? PriceEpisodeFromDate;
        public DateTime? PriceEpisodeToDate;
        public int ULNKey { get; set; }
        public Boolean IsPilot { get; set; }
        public string PriceEpisodeFromDateStr { set { PriceEpisodeFromDate = value == "Today" ? DataHelpers.CalculateStartDate()
                    : value == "StartCurrentMonth" ? DataHelpers.GetFirstDateOfCurrentMonth() 
                    : DataHelpers.TryParseDate(value); } }
        public string PriceEpisodeToDateStr { set {PriceEpisodeToDate = DataHelpers.TryParseDate(value); } }
        public decimal PriceEpisodeCost { get; set; }
        public decimal? TrainingPrice { get; set; }
        public decimal? EndpointAssessmentPrice {  get; set; }
    }
}
