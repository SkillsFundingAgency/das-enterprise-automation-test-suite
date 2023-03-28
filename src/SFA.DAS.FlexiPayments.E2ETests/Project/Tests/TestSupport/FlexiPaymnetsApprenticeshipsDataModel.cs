using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using System;
using System.ComponentModel;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport
{
    public  class FlexiPaymnetsApprenticeshipsDataModel
    {
        public DateTime? StartDate;
        public DateTime? ActualStartDate;
        public DateTime? PlannedEndDate;

        public int ULNKey { get; set; }
        public FundingPlatform FundingPlatform { get; set; }
        public string StartDateStr { set { StartDate = value == "Today" ? DataHelpers.CalculateStartDate()
                    : value == "StartCurrentMonth" ? DataHelpers.GetFirstDateOfCurrentMonth()
                    : DataHelpers.TryParseDate(value); } }
        public string ActualStartDateStr { set { ActualStartDate = value == "Today" ? DataHelpers.CalculateStartDate()
                    : DataHelpers.TryParseDate(value); } }
        public string PlannedEndDateStr { set { PlannedEndDate = value == "+24Months" ? DataHelpers.CalculatePlannedEndDate(DateTime.Today, value, FundingPlatform) 
                    : DataHelpers.TryParseDate(value); } }
        public double AgreedPrice { get; set; }
        public FundingType FundingType { get; set; }
        public double FundingBandMaximum { get; set; }
    }

    public enum FundingType
    {
        [Description("Levy")]
        Levy = 0,
        [Description("Non Levy")]
        NonLevy = 1,
        [Description("Transfer")]
        transfer = 2
    }

    public enum FundingPlatform
    {
        [Description("Pilot")]
        Pilot = 1,
        [Description("NonPilot")]
        NonPilot = 2,
    }
}
