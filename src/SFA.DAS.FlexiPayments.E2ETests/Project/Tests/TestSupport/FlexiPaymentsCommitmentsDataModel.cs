using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using System;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport
{
    public class FlexiPaymentsCommitmentsDataModel
    {
        public DateTime? PriceEpisodeFromDate;
        public DateTime? PriceEpisodeToDate;
        public int ULNKey { get; set; }
        public Boolean IsPilot { get; set; }
        public string PriceEpisodeFromDateStr
        {
            set
            {
                PriceEpisodeFromDate = value == "Today" ? DataHelpers.CalculateStartDate()
                    : value == "StartPreviousMonth" ? DataHelpers.CalculateStartDate(true)
                    : value == "StartFirstDayOfPreviousMonth" ? DataHelpers.GetFirstDateOfPreviousMonth()
                    : value == "StartCurrentMonth" ? DataHelpers.GetFirstDateOfCurrentMonth()
                    : DataHelpers.TryParseDate(value);
            }
        }
        public string PriceEpisodeToDateStr { set { PriceEpisodeToDate = DataHelpers.TryParseDate(value); } }
        public decimal PriceEpisodeCost { get; set; }
        public string TrainingPrice { get; set; } = "";
        public string EndpointAssessmentPrice { get; set; } = "";
    }
}
